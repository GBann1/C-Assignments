#pragma warning disable CS8618
namespace DojoSurvey_Validations.Models;
using System.ComponentModel.DataAnnotations;

public class SurveyModel
{
    [Required]
    [MinLength(2)]
    public string Name {get;set;}

    [Required]
    public string Location {get;set;}

    [Required]
    public string Language {get;set;}

    [MinLength(20)]
    public string? Comment {get;set;}
}