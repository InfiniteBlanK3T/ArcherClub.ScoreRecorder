using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models;

public class Equipments
{
    [Key]
    [StringLength(5)]
    public string EquipmentID { get; set; }
    [Required]
    [StringLength(50)]
    public string EquipmentName { get; set; }
}
