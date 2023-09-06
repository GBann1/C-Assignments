using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private DishContext _context;

    public HomeController(ILogger<HomeController> logger, DishContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        List<Dish> AllDishes = _context.dishes.ToList();
        return View(AllDishes);
    }

    [HttpGet("dishes/new")]
    public IActionResult NewDish()
    {
        return View("NewDish");
    }

    [HttpPost("dishes/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return RedirectToAction("NewDish");
        }
    }

    [HttpGet("dishes/{id}")]
    public IActionResult ViewDish(int id)
    {
        Dish? OneDish = _context.dishes.SingleOrDefault(dish => dish.DishId == id);
        return View(OneDish);
    }

    [HttpGet("dishes/{DishId}/edit")]
    public IActionResult EditDish(int DishId)
    {
        Dish? DishToEdit = _context.dishes.SingleOrDefault(dish => dish.DishId == DishId);
        if(DishToEdit != null)
        {
            return View(DishToEdit);
        }else{
            return RedirectToAction("Index");
        }
    }

    [HttpPost("dishes/{DishId}/update")]
    public IActionResult UpdateDish(int dishId, Dish updateDish)
    {
        Dish? OldDish = _context.dishes.SingleOrDefault(dish => dish.DishId == dishId);

        if(ModelState.IsValid)
        {
            OldDish.Name = updateDish.Name;
            OldDish.Chef = updateDish.Chef;
            OldDish.Tastiness = updateDish.Tastiness;
            OldDish.Calories = updateDish.Calories;
            OldDish.Description = updateDish.Description;
            OldDish.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("ViewDish",new {
                id = dishId
            });
        }
        else{
            // Passes in old data
            // return View("EditDish",OldDish);
            // Passes in attempted data changes
            return View("EditDish",updateDish);
        }
    }

    [HttpPost("dishes/{DishId}/destroy")]
    public IActionResult DeleteDish(int DishId)
    {
        Dish? DishToDelete = _context.dishes.SingleOrDefault(dish => dish.DishId == DishId);
        _context.dishes.Remove(DishToDelete);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
