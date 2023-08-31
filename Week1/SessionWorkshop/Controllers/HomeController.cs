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
    public IActionResult Login(string name)
    {
        HttpContext.Session.SetString("Name", name);
        HttpContext.Session.SetInt32("Number", 22);
        return RedirectToAction("Dashboard");
    }

    // Does the submission work to mod the Number in session
    [HttpPost("Submit")]
    public IActionResult Submit(string submission)
    {
        // Add the value from the Hidden Input to the value in session
        if (int.TryParse(submission, out int val)){
            int? num = HttpContext.Session.GetInt32("Number");
            int newNum = (int)(num + val);
            HttpContext.Session.SetInt32("Number", newNum);
        }
        
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
