using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DateValidator.Models;

namespace DateValidator.Controllers;

public class HomeController : Controller
{

    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("submission")]
    public IActionResult Submission(FormModel submit)
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
    public IActionResult Display(FormModel submit)
    {
        return View(submit);
    }
}
