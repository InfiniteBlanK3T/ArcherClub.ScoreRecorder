using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models;

public class Clubs
{
    [Key]
    [StringLength(50)]
    public string ClubName { get; set; }
    [Required]
    public int ClubMaxedAge { get; set; }
    [Required]
    public char ClubGender { get; set; }
    
}
