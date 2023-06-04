import React, { useState, useEffect } from 'react';
import ScoreInput from './ScoreInput';
import './App.css';

const SelectBox = () => {
  const [rounds, setRounds] = useState([]);
  const [archers, setArchers] = useState([]);
  const [weapons, setWeapons] = useState([]);
  const [selectedRound, setSelectedRound] = useState(null);
  const [selectedArcher, setSelectedArcher] = useState(null);
  const [selectedWeapon, setSelectedWeapon] = useState('');
  const [doneClicked, setDoneClicked] = useState(false);

  useEffect(() => {
    fetch('http://localhost:5034/api/Rounds')
      .then(response => response.json())
      .then(data => setRounds(data))
      .catch(error => console.error('There was a Round Selection error!', error));

    fetch('http://localhost:5034/api/Archers')
      .then(response => response.json())
      .then(data => setArchers(data))
      .catch(error => console.error('There was an Archer Selection error!', error));
  }, []);

  useEffect(() => {
    if (selectedArcher && selectedRound) {
      fetch('http://localhost:5034/api/Equipments')
        .then(response => response.json())
        .then(data => {
          setWeapons(data);
          setSelectedWeapon('Recurve');
        })
        .catch(error => console.error('There was an Equipment Selection Error!', error));
    }
  }, [selectedRound, selectedArcher]);

  const handleDoneClick = async () => {
    if (selectedRound && selectedArcher && selectedWeapon) {
      try {
        const roundScore = {
          roundId: selectedRound.roundId,
          ArcherId: selectedArcher.archerId,
          EquipmentName: selectedWeapon
        };
        
        const response = await fetch('http://localhost:5034/api/RoundScore', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify(roundScore),
        });

        if (response.ok) {
          setDoneClicked(true);
        } else {
          console.error('Error: ', response);
        }
      } catch (error) {
        console.error('Error occurred when trying to POST round score:', error);
      }
    } else {
      alert('Please select a round, an archer, and a weapon before clicking Done.');
    }
  };

  const handleRoundChange = (e) => {
    const roundId = Number(e.target.value);
    const round = rounds.find(r => r.roundId === roundId);
    setSelectedRound(round);
  };
  
  const handleArcherChange = (e) => {
    const archerId = Number(e.target.value);
    const archer = archers.find(a => a.archerId === archerId);
    setSelectedArcher(archer);
  };  

  return (
    <div className="select-box">
      {!doneClicked ? (
        <>
          <h2>Choose Round</h2>
          <select value={selectedRound && selectedRound.roundId} onChange={handleRoundChange}>
            <option value="">Choose a round</option>
            {rounds.map(round => (
              <option key={round.roundId} value={round.roundId}>{round.roundName}, {round.totalArrows} arrows</option>
            ))}
          </select>

          <h2>Choose An Archer</h2>
          <select value={selectedArcher && selectedArcher.archerId} onChange={handleArcherChange}>
            <option value="">Choose an Archer</option>
            {archers.map(archer => (
              <option key={archer.archerId} value={archer.archerId}>{archer.givenName} {archer.familyName}</option>
            ))}
          </select>

          {selectedArcher && selectedRound && (
            <>
            <h2>Choose Weapon</h2>
            <select value={selectedWeapon} onChange={e => setSelectedWeapon(e.target.value)}>
              <option value="Recurve">Recurve</option>  // Change the value of the "Recurve" option to "Recurve"
              {weapons.map((weapon, index) => (
                <option key={index} value={weapon.equipmentName}>{weapon.equipmentName}</option>
              ))}
            </select>
            <br></br>
            <button className="button" onClick={handleDoneClick}>Done</button>
            </>
          )}
        </>
      ) : (
        <ScoreInput selectedRound={selectedRound} selectedArcher={selectedArcher} selectedWeapon={selectedWeapon} />
      )}
    </div>
  );
};

export default SelectBox;
