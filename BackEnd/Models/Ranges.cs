using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models;

public class Ranges
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RangeID { get; set; }
    [Required]
    [ForeignKey("Distances")]
    public int Distance { get; set; }
    [Required]
    [ForeignKey("FaceSizes")]
    public int FaceSize { get; set; }
    public Distances? Distances { get; set; }
    public FaceSizes? FaceSizes { get; set; }
}
