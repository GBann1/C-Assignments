using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
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

    [HttpGet("Dishes/View")]
    public IActionResult ViewDishes()
    {
        List<Dish> dishes = _context.Dishes.Include(dish => dish.Cook).ToList();
        return View(dishes);
    }

    [HttpGet("Dishes/New")]
    public IActionResult NewDish()
    {
        List<Chef> cooks = _context.Chefs.ToList();
        ViewBag.CookList = new SelectList(cooks, "ChefID", "FirstName");
        return View();
    }

    [HttpPost("Dishes/Write")]
    public IActionResult WriteDish(Dish newModel)
    {
        if(ModelState.IsValid)
        {
            // Grab Chef ID
            int CookID = newModel.ChefID;
            // Assigns Dish to Chef/Cook
            newModel.Cook = _context.Chefs.FirstOrDefault(chef => chef.ChefID == CookID);
            // write & save changes
            _context.Add(newModel);
            _context.SaveChanges();
            return RedirectToAction("ViewDishes");
        }
        return View("AddDish", newModel);
    }
}