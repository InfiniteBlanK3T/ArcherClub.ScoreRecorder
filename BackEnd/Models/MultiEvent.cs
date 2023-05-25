using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models;

public class MultiEvent
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MultiEventID { get; set; }
    [Required]
    [ForeignKey("Events")]
    public int EventID { get; set; }
    [Required]
    [ForeignKey("Rounds")]
    public int RoundID { get; set; }
    [Required, StringLength(50)]
    [ForeignKey("Clubs")]
    public string ClubName { get; set; }
    public Events? Events { get; set; }
    public Rounds? Rounds { get; set; }
    public Clubs? Clubs { get; set; }

}
