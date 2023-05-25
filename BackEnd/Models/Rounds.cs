using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models;

public class Rounds
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RoundId { get; set; }
    [Required, StringLength(50)]
    [ForeignKey("Clubs")]
    public string ClubName { get; set; }

    public Clubs? Clubs { get; set; }
}
