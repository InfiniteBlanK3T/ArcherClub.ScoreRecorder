using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models;

public class RoundRangeMapping
{
    [Key]
    [ForeignKey("Rounds")]
    public int RoundId { get; set; }
    [Key]
    [ForeignKey("Ranges")]
    public int RangeID { get; set; }
    public Rounds? Rounds { get; set; }
    public Ranges? Ranges { get; set; }
}
