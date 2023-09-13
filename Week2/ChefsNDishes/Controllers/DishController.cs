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

    [HttpGet("Dishes/View")]
    public IActionResult ViewDishes()
    {
        List<Dish> dishes = _context.Dishes.ToList();
        return View(dishes);
    }

    [HttpGet("Dishes/New")]
    public IActionResult NewDish()
    {
        DishChefModel newModel = new DishChefModel();
        newModel.NewDish = new Dish();
        newModel.Chefs = _context.Chefs.ToList();
        return View(newModel);
    }

    [HttpPost("Dishes/Write")]
    public IActionResult WriteDish(DishChefModel newModel)
    {
        if(ModelState.IsValid)
        {
            // Grab Chef ID
            int CookID = newModel.NewDish.ChefID;
            // Assigns Dish to Chef/Cook
            newModel.NewDish.Cook = _context.Chefs.FirstOrDefault(chef => chef.ChefID == CookID);
            // write & save changes
            _context.Add(newModel.NewDish);
            _context.SaveChanges();
            return RedirectToAction("Home");
        }
        newModel.Chefs = _context.Chefs.ToList();
        return View("AddDish", newModel);
    }
}