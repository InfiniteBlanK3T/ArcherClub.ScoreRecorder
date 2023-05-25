using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models;

public class EquivalentRounds
{
    [Key, StringLength(50)]
    public string EquivalentRound { get; set; }
    [Required]
    public int NumberOfEndsPerRange { get; set; }

}
