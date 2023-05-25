using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models;

public class RoundGroups
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RoundGroupId { get; set; }
    [Required]
    [ForeignKey("Rounds")]
    public int RoundId { get; set; }
    [Required, StringLength(50)]
    [ForeignKey("Clubs")]
    public string ClubName { get; set; }
    [Required, StringLength(5)]
    [ForeignKey("Equipments")]
    public string EquipmentID { get; set; }
    public Rounds? Rounds { get; set; }
    public Clubs? Clubs { get; set; }
    public Equipments? Equipments { get; set;}

}
