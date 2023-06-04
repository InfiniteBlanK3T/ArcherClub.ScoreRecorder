import React, { useState, useEffect } from 'react';

const ScoreInput = ({ selectedRound, selectedArcher, selectedWeapon }) => {
    const [ranges, setRanges] = useState([]);
    const [selectedRange, setSelectedRange] = useState('');
    const [rangeDetails, setRangeDetails] = useState(null);
    const [ setSelectedInputIndex] = useState(-1);
    const [inputs, setInputs] = useState(Array(6).fill(''));
    const [ends, setEnds] = useState([]);
    const [currentEnd, setCurrentEnd] = useState(0);
    const [totalScore, setTotalScore] = useState(0);
    const [finalScore, setFinalScore] = useState(0);
    const [scoreSubmitted, setScoreSubmittedLocal] = useState(false);
    const characters = ['X', '10', '9', '8', '4', '5', '6', '7', '3', '2', '1', 'M'];
    const charToColor = (char) => {
    switch(char) {
      case 'X':
      case '10':
      case '9':
        return { backgroundColor: 'yellow', color: 'black' };
      case '8':
      case '7':
        return { backgroundColor: 'red', color: 'black' };
      case '6':
      case '5':
        return { backgroundColor: 'blue', color: 'white' };

      case '4':
      case '3':
        return { backgroundColor: 'black', color: 'white' };
      default:
        return { backgroundColor: 'white', color: 'black' };
    }
  };
  
  useEffect(() => {
    const fetchRanges = async () => {
      if (selectedRound) {
        try {
          const response = await fetch(`http://localhost:5034/api/RoundRangeMapping/${selectedRound.roundId}`);
          const data = await response.json();
          const rangeIds = data.map(mapping => mapping.rangeId);
          const ranges = await Promise.all(rangeIds.map(async id => {
            const response = await fetch(`http://localhost:5034/api/Ranges/${id}`);
            return await response.json();
          }));
          setRanges(ranges);
        } catch (error) {
          console.error('There was an error fetching the ranges!', error);
        }
      }
    };

    fetchRanges();
  }, [selectedRound]);

  useEffect(() => {
    if (selectedRange) {
      const range = ranges.find(r => r.rangeID === Number(selectedRange));
      setRangeDetails(range);
    }
  }, [selectedRange, ranges]);

  useEffect(() => {
    if (rangeDetails && rangeDetails.numberOfEnds) {
      const initialEnds = Array.from({ length: rangeDetails.numberOfEnds }, () => Array(6).fill(''));
      setEnds(initialEnds);
      setCurrentEnd(0);
    }
  }, [rangeDetails]);

  const handleGridClick = (char) => {
    const val = char === 'X' ? 10 : (char === 'M' ? 0 : parseInt(char));
    setInputs(prevInputs => {
      const newInputs = [...prevInputs];
      const index = newInputs.findIndex(input => input === '');
      if (index !== -1) {
        newInputs[index] = val;
      }
      setEnds(prevEnds => {
        const newEnds = [...prevEnds];
        newEnds[currentEnd] = newInputs;
        return newEnds;
      });

      return newInputs;
    });

    setTotalScore(prevScore => prevScore + val);
  };

  const getRoundScoreId = async () => {
    const response = await fetch(`http://localhost:5034/api/RoundScore/${selectedRound.roundId}/${selectedArcher.archerId}/${selectedWeapon}`);
    const data = await response.json();
    const highestRoundScoreId = Math.max(...data.map(item => item.roundScoreId));
    return highestRoundScoreId;
  };

  const handleSaveClick = async () => {
    setEnds(prevEnds => {
      const newEnds = [...prevEnds];
      newEnds[currentEnd] = inputs;
      return newEnds;
    });

    const currentEndScores = ends[currentEnd];
    const roundScoreId = await getRoundScoreId();
    const payload = {
      roundScoreID: roundScoreId,
      RangeID: selectedRange,
      ArrowScore1: currentEndScores[0],
      ArrowScore2: currentEndScores[1],
      ArrowScore3: currentEndScores[2],
      ArrowScore4: currentEndScores[3],
      ArrowScore5: currentEndScores[4],
      ArrowScore6: currentEndScores[5]
    };
    const response = await fetch('http://localhost:5034/api/Ends', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(payload),
    });

    if (currentEnd < ends.length) {
      setCurrentEnd(prevEnd => prevEnd + 1);
      setInputs(Array(6).fill(''));
    }
    if (response.ok) {
        setFinalScore(prevScore => prevScore + totalScore);
    }
  };

  const handleClearClick = () => {
    setInputs(Array(6).fill(''));
    
    setEnds(prevEnds => {
      const newEnds = [...prevEnds];
      newEnds[currentEnd] = Array(6).fill('');
      return newEnds;
    });
  };  

  useEffect(() => {
    setTotalScore(inputs.reduce((acc, input) => acc + input, 0));
  }, [inputs]);
  
  const handleSubmitScoreClick = () => {
    setScoreSubmittedLocal(true);
  };
  
  return (
    <>
      <h1>Score Input</h1>
      <p><strong>Archer: </strong>{selectedArcher && selectedArcher.givenName} {selectedArcher && selectedArcher.familyName}</p>
      <p><strong>Round: </strong>{selectedRound && selectedRound.roundName}, {selectedRound && selectedRound.totalArrows} arrows</p>
      <p><strong>Equipment: </strong>{selectedWeapon}</p>

      <h3>Choose your ranges</h3>
      <select value={selectedRange} onChange={e => setSelectedRange(e.target.value)}>
        <option value="">Choose a range</option>
        {ranges.map(range => (
          <option key={range.rangeID} value={range.rangeID}>{range.distance}m, {range.numberOfEnds} ends, {range.faceSize}cm</option>
        ))}
      </select>
      {rangeDetails && (
        <>
          <p><strong>Distance: </strong>{rangeDetails.distance}m</p>
          <p><strong>Number Of Ends: </strong>{rangeDetails.numberOfEnds}</p>
          <p><strong>Face Size: </strong>{rangeDetails.faceSize}cm</p>
        </>
      )}
        {selectedRange && currentEnd < ends.length && (
        <>
            <div className='score-box'>
                <div className="areaOne">
                    <h2>{`End ${currentEnd + 1}`}</h2>
                    <div className="inputRow">
                    {inputs.map((input, j) => (
                        <input 
                        key={j} 
                        type="text" 
                        value={input} 
                        readOnly 
                        onClick={() => setSelectedInputIndex(j)} 
                        />
                    ))}
                    </div>
                    <h2 className="centerTitle">Score: {totalScore}</h2>
                </div>
                <div className="areaTwo">
                    <div className="grid">
                    {characters.map((char, k) => (
                        <div
                        key={k} 
                        className="gridBox" 
                        style={charToColor(char)}
                        onClick={() => handleGridClick(char)}
                        >
                        {char}
                        </div>
                    ))}
                    </div>
                    <div className="buttons">
                    <button className='button' onClick={handleSaveClick}>Save</button>
                    <button className='button' onClick={handleClearClick}>Clear</button>
                    </div>
                </div>
            </div>
        </>
        )}
        {!scoreSubmitted ? (
            <>
                {selectedRange && currentEnd === ends.length && (
                    <>
                        <h2>Total Final Score: {finalScore}</h2>
                        <button className='button' onClick={handleSubmitScoreClick}>Submit your score</button>
                    </>
                )}
            </>
        ) : (
            <>
            <h2>You have successfully submitted your score!</h2>
            <button className='button' onClick={() => window.location.reload()}>Return</button>
          </>
        )}        
    </>
  );
};

export default ScoreInput;
