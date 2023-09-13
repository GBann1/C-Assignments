#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ChefsNDishes.Models;

public class Chef
{
    [Key]
    public int ChefID {get; set;}

    [Required]
    [MinLength(2)]
    public string FirstName {get; set;}

    [Required]
    [MinLength(2)]
    public string LastName {get; set;}

    [Required(ErrorMessage="Chef's birthday is required")]
    [DateValidation(ErrorMessage="Chef must be over 18")]
    public DateTime BirthDate {get; set;}

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    public List<Dish> AllDishes {get; set;} = new List<Dish>();
}

public class DateValidation : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        // check value is formatted correctly & in past
        if (value is DateTime BirthDate && BirthDate < DateTime.Now)
        {
            // find age
            int age = DateTime.Now.Year - BirthDate.Year;
            // check to see if they're over 18
            return age >= 18;
        }
        return false;
    }
}