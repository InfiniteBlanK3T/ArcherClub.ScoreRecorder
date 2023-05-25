using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArchersRecorderBackEndDatabase.Models;

public class Ends
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EndId { get; set; }
    [Required, ForeignKey("RoundScores")]
    public int RoundScoreID { get; set; }
    [Required, ForeignKey("Ranges")]
    public int RangeID { get; set; }
    [Required]
    public int ArrowScore1 { get; set; }
    [Required]
    public int ArrowScore2 { get; set; }
    [Required]
    public int ArrowScore3 { get; set; }
    [Required]
    public int ArrowScore4 { get; set; }
    [Required]
    public int ArrowScore5 { get; set; }
    [Required]
    public int ArrowScore6 { get; set; }
    public RoundScores? RoundScores { get; set; }
    public Ranges? Ranges { get; set; }

}
