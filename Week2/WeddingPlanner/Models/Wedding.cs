#pragma warning disable CS8618
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Models;

public class Wedding
{
    [Key]
    public int WeddingID {get; set;}

    [Required]
    public string WedderOne {get; set;}

    [Required]
    public string WedderTwo {get; set;}

    [Required(ErrorMessage="Date is required")]
    [DataType(DataType.Date)]
    [DateValidation(ErrorMessage = "Date must be in the future")]
    public DateTime Date {get; set;}

    [Required]
    public string Address {get; set;}
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public int UserID {get; set;}
    public User? Planner {get; set;}

    public List<UserWedding> Guests {get; set;} = new List<UserWedding>();
}

public class DateValidation : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value is DateTime Date)
        {
            return Date > DateTime.Today;
        }
        return false;
    }
}