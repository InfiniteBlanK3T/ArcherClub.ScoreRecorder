using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArchersRecorderBackEndDatabase.Models;

public class Ranges
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RangeID { get; set; }
    [Required]
    public int Distance { get; set; }
    [Required]
    public int NumberOfEnds { get; set; }
    [Required]
    public int FaceSize { get; set; }
}
