#pragma warning disable CS8618
namespace DateValidator.Models;
using System.ComponentModel.DataAnnotations;

public class FormModel
{
    [Required]
    [MinLength(2)]
    public string Name { get; set; }

    [Required]
    public string Location { get; set; }

    [Required]
    [DatePassed]
    public DateTime DateOfBirth { get; set; }

    [MinLength(20)]
    public string? Comment { get; set; }
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