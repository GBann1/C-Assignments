#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace WeddingPlanner.Models;

public class Login
{
    [Required]
    [EmailAddress]
    public string LogEmail { get; set; }
    
    [Required]
    [MinLength(8)]
    public string LogPassword {get;set;}
}
