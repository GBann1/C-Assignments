using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using ChefsNDishes.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers;

public class DishController : Controller
{
    private readonly ILogger<DishController> _logger;

    private MyContext _context;

    public DishController(ILogger<DishController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("Dishes/New")]
    public IActionResult AddDish()
    {
        return View();
    }

    [HttpPost("Dishes/Write")]
    public IActionResult WriteDish(Dish newDish)
    {
        if(ModelState.IsValid)
        {
            // Grab Chef ID
            int CookID = newDish.ChefID;
            // Assigns Dish to Chef/Cook
            newDish.Cook = _context.Chefs.FirstOrDefault(chef => chef.ChefID == CookID);
            // write & save changes
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Home");
        } else {
            return View("AddDish");
        }
    }
}