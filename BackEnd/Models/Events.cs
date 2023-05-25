using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models;

public class Events
{
    [Key, StringLength(50)]
    public string EventName { get; set; }
    [Required]
    public int EventYear { get; set; }
}
