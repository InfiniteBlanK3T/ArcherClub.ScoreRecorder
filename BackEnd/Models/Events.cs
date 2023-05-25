using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models;

public class Events
{
    [Key]
    public int EventID { get; set; }
    [Required, StringLength(50)]
    public string EventName { get; set; }
}
