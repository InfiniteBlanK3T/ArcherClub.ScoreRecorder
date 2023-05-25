using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArchersRecorderBackEndDatabase.Models;

public class Equipments
{
    [Key, StringLength (50)]
    public string EquipmentName { get; set; }
}
