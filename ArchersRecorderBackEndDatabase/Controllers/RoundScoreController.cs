using ArchersRecorderBackEndDatabase.Models;
using ArchersRecorderBackEndDatabase.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ArchersRecorderBackEndDatabase.Controllers;

public class RoundScoreController : GenericController<RoundScores>
{
    private readonly IRoundScoresRepository _roundScoreRepository;
    public RoundScoreController(IRoundScoresRepository roundScoreRepository) : base(roundScoreRepository)
    {
        _roundScoreRepository = roundScoreRepository;
    }
    [HttpGet("{roundId}/{archerId}/{equipmentName}")]
    public async Task<ActionResult<RoundScores>> GetIdAsync(int roundId, int archerId, string equipmentName)
    {
        var roundscore = await _roundScoreRepository.GetIdAsync(roundId, archerId, equipmentName);
        if (roundscore == null)
        {
            return NotFound();
        }
        return Ok(roundscore);
    }
    [HttpPost]
    public async Task<ActionResult<RoundScores>> PostRoundScores(RoundScores roundScores)
    {
        await _roundScoreRepository.AddAsync(roundScores);
        return CreatedAtAction("Get", new { id = roundScores.RoundScoreId }, roundScores);
    }
}
