using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models;

public class Ends
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EndID { get; set; }
    [Required]
    [ForeignKey("Ranges")]
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
    public int ArrowScore6 { get; set; }
    public Ranges? Ranges { get; set; }
}
