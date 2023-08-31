#pragma warning disable CS8618
namespace FormSubmission.Models;
using System.ComponentModel.DataAnnotations;

public class ProfileModel
{
    [Required]
    [MinLength(2)]
    public string Name {get;set;}
    [Required]
    [EmailAddress]
    public string Email {get;set;}
    [Required]
    [DatePassed]
    public DateTime DateOfBirth { get; set; }
    [Required]
    [MinLength(8)]
    public string Password {get;set;}
    [Required]
    [OddNum]
    public int FavoriteOddNumber {get;set;}

}

public class DatePassedAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is DateTime date)
        {
            DateTime CurrentTime = DateTime.Now;
            if (date >= CurrentTime)
            {
                return new ValidationResult("Date must be in the future");
            }
        }
        return ValidationResult.Success;
    }
}

public class OddNumAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is int oddNum)
        {
            if (oddNum %2 ==0)
            {
                return new ValidationResult("Number must be odd");
            }
        }
        return ValidationResult.Success;
    }
}