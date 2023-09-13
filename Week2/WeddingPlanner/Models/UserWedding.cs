#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models;

public class UserWedding
{
    [Key]    
    public int UserWeddingID { get; set; } 
    // The IDs linking to the adjoining tables   
    public int UserID { get; set; }    
    public int WeddingID { get; set; }
    // Our navigation properties - don't forget the ?    
    public User? User { get; set; }    
    public Wedding? Wedding { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
