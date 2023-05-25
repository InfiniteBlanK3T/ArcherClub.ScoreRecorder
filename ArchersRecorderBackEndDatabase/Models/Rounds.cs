using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArchersRecorderBackEndDatabase.Models;

public class Rounds
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RoundId { get; set; }
    [Required, StringLength(50)]
    public string RoundName { get; set; }
    [Required]
    public int TotalArrows { get; set; }
}
