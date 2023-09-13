using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using ChefsNDishes.Models;

namespace ChefsDishes.Controllers;

public class ChefController : Controller
{
    private readonly ILogger<ChefController> _logger;

    private MyContext _context;

    public ChefController(ILogger<ChefController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("")]
    public IActionResult ViewChefs()
    {
        List<Chef> Cooks = _context.Chefs.Include(c => c.AllDishes).ToList();
        return View(Cooks);
    }

    [HttpGet("Chefs/New")]
    public IActionResult NewChef()
    {
        return View();
    }

    [HttpPost("Chefs/Write")]
    public IActionResult WriteChef(Chef newChef)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newChef);
            _context.SaveChanges();
            return RedirectToAction("ViewChefs");
        }
        return View("NewChef", newChef);
    }
}