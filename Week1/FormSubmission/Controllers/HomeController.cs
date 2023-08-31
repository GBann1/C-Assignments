using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormSubmission.Models;

namespace FormSubmission.Controllers;

public class HomeController : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("Home/submit")]
    public IActionResult Submission(ProfileModel submit)
    {
        if(ModelState.IsValid)
        {
            return RedirectToAction("Display", submit);
        }
        else
        {
            return View("Index");
        }
    }

    [HttpGet("Display")]
    public IActionResult Display(ProfileModel submit)
    {
        return View(submit);
    }
}
