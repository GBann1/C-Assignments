using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurvey_Validations.Models;

namespace DojoSurvey_Validations.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("/")]
    public ViewResult Index()
    {
        return View("Index");
    }
    
    [HttpPost("submission")]
    public IActionResult Submission(SurveyModel submit)
    {
        if(ModelState.IsValid)
        {
            return RedirectToAction("Display",submit);
        }
        else
        {
            return View("Index");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
