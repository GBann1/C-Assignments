using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers;

public class WeddingController : Controller
{
    private readonly ILogger<WeddingController> _logger;
    private MyContext _context;

    public WeddingController(ILogger<WeddingController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("wedding/dashboard")]
    public IActionResult Dashboard()
    {
        List<Wedding> AllWeddings = _context.Weddings.Include(wedd => wedd.Planner).ToList();
        return View(AllWeddings);
    }

    [HttpGet("wedding/add")]
    public IActionResult AddWedding()
    {
        return View();
    }

    [HttpPost("wedding/write")]
    public IActionResult WriteWedding(Wedding newWedding)
    {
        if(ModelState.IsValid)
        {
            newWedding.UserID = (int)HttpContext.Session.GetInt32("UserID");
            _context.Add(newWedding);
            _context.SaveChanges();
            return RedirectToAction("Dashboard", "Wedding");
        }else {
            return View("AddWedding");
        }
    }
}