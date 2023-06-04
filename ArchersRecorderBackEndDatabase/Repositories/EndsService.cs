using ArchersRecorderBackEndDatabase.Models;

namespace ArchersRecorderBackEndDatabase.Repositories;

public class EndsService
{
    private readonly IEndsRepository _endsRepository;
    private readonly IRoundScoresRepository _roundScoresRepository;
    private readonly IRoundRangeMappingRepository _roundRangeMappingRepository;
    private readonly IRepository<Ranges> _rangesRepository;

    public EndsService(IEndsRepository endsRepository,
                       IRoundScoresRepository roundScoresRepository,
                       IRoundRangeMappingRepository roundRangeMappingRepository,
                       IRepository<Ranges> rangesRepository)
    {
        _endsRepository = endsRepository;
        _roundScoresRepository = roundScoresRepository;
        _roundRangeMappingRepository = roundRangeMappingRepository;
        _rangesRepository = rangesRepository;
    }

    public async Task AddEndsAsync(Ends ends)
    {
        // Check if the RoundScore exists
        var roundScore = await _roundScoresRepository.GetByIdAsync(ends.RoundScoreID);
        if (roundScore == null)
        {
            throw new Exception("RoundScore not found");
        }

        // Check if the Range exists
        var range = await _rangesRepository.GetByIdAsync(ends.RangeID);
        if (range == null)
        {
            throw new Exception("Range not found");
        }

        // Check if the RoundScore's RoundId is associated with the RangeId in the RoundRangeMapping
        var roundRangeMapping = await _roundRangeMappingRepository.GetBySpecificIdAsync(roundScore.RoundId, ends.RangeID);
        if (roundRangeMapping == null)
        {
            throw new Exception("RoundScore's RoundId is not associated with the RangeId");
        }

        // Check if the number of ArrowScores matches the NumberOfEnds in the Range
        var arrowScores = new[] { ends.ArrowScore1, ends.ArrowScore2, ends.ArrowScore3, ends.ArrowScore4, ends.ArrowScore5, ends.ArrowScore6 };
        var numberOfArrowScores = arrowScores.Take(range.NumberOfEnds).Count();
        if (numberOfArrowScores != range.NumberOfEnds)
        {
            throw new Exception("Number of ArrowScores does not match the NumberOfEnds in the Range");
        }

        // If all checks pass, add the Ends
        await _endsRepository.AddAsync(ends);
    }
}
