using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using SessionWorkshop.Models;

namespace SessionWorkshop.Controllers;

public class HomeController : Controller
{
    // Show "Input name screen"
    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    // Does the work & redirects to the dashboard
    [HttpPost("Login")]
    public IActionResult Login()
    {
        HttpContext.Session.SetString("Name", "Gordon");
        HttpContext.Session.SetInt32("Number", 22);
        return RedirectToAction("Dashboard");
    }

    // Does the submission work to mod the Number in session
    [HttpGet("Submit")]
    public IActionResult Submit()
    {
        // I don't know how to set a default and then overwrite it
        // HttpContext.Session.SetInt32("Number", (HttpContext.Session.GetInt32("Number")+"###HIDDENINPUTVALUE###"));
        return RedirectToAction("Dashboard");
    }

    // Renders the dashboard view
    [HttpGet("Dashboard")]
    public IActionResult Dashboard()
    {
        return View();
    }

    // Clears session and redirects to login page
    [HttpPost("Logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
}
