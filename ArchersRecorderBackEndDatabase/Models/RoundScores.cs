using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArchersRecorderBackEndDatabase.Models;

public class RoundScores
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RoundScoreId { get; set; }
    [Required, ForeignKey("Rounds")]
    public int RoundId { get; set; }
    [Required, ForeignKey("Archers")]
    public int ArcherId { get; set; }
    [Required, StringLength(50)]
    public string EquipmentName { get; set; }
}
