﻿using Microsoft.AspNetCore.Mvc;
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
        // sets default number
        HttpContext.Session.SetInt32("Number", 22);
        return RedirectToAction("Dashboard");
    }

    // Does the submission work to mod the Number in session
    [HttpPost("Submit")]
    public IActionResult Submit(string submission)
    {
        int? num = HttpContext.Session.GetInt32("Number");
        // Add the value from the Hidden Input to the value in session
        if (submission == "x2"){
            int newNum = (int)(num *2);
            
        }else if (int.TryParse(submission, out int val)){
            int newNum = (int)(num + val);

        }else {
            Random rand = new Random();
            int randNum = rand.Next(1,11);
            int newNum = (int)(num + randNum);
        }
        HttpContext.Session.SetInt32("Number", newNum);
        
        return RedirectToAction("Dashboard");
    }

    // Renders the dashboard view
    [HttpGet("Dashboard")]
    public IActionResult Dashboard()
    {
        // Idk how to make sure something is valid in Session
        string? name = HttpContext.Session.GetString("Name");
        if (name == null){
            return RedirectToAction("Index");
        }
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
