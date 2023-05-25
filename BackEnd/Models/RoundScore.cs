using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models;

public class RoundScore
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RoundScoreID { get; set; }
    [Required]
    [ForeignKey("Archers")]
    public int ArcherID { get; set; }
    [Required]
    [ForeignKey("Events")]
    public int EventID { get; set; }
    [Required]
    [ForeignKey("Rounds")]
    public int RoundID { get; set; }
    [Required]
    public DateTime RoundDate { get; set; }
    [Required, StringLength(50)]
    public string EquipmentID { get; set; }
    public Equipments? Equipments { get; set; }
    public Archers? Archers { get; set; }
    public Events? Events { get; set; }
    public Rounds? Rounds { get; set; }

}
