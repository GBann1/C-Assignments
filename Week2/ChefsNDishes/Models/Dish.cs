#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ChefsNDishes.Models;

public class Dish
{
    [Key]
    public int DishID {get; set;}

    [Required]
    public string Name {get; set;}

    [Required]
    [Min(1, ErrorMessage = "Must have calories")]
    public int Calories {get; set;}

    [Required]
    [Range(1, 5)]
    public int Tastiness {get; set;}

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    // Now the part I still don't fully understand
    public int ChefID {get; set;}
    public Chefs? Cook {get; set;}
}