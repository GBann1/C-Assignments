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

    [HttpGet("wedding/view/{id}")]
    public IActionResult ViewWedding(int id )
    {
        Wedding? wedd = _context.Weddings.Include(p => p.Planner)
                                .Include(p => p.Guests)
                                .ThenInclude(mid => mid.User)
                                .FirstOrDefault(p => p.WeddingID == id);
        if(wedd == null)
        {
            return RedirectToAction("Dashboard");
        }
        return View(wedd);
    }

    [HttpPost("wedding/{id}/rsvp")]
    public IActionResult AddGuest(int id)
    {
        int UUID = (int)HttpContext.Session.GetInt32("UserID");
        UserWedding going = _context.UserWeddings.FirstOrDefault(rsvp => rsvp.WeddingID == id && rsvp.UserID == UUID);
        if(going == null)
        {
            UserWedding isGoing = new()
            {
                UserID = UUID,
                WeddingID = id
            };
            _context.Add(isGoing);
        }else{
            _context.Remove(going);
        }
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }

    [HttpPost("wedding/{id}/delete")]
    public IActionResult Delete(int id)
    {
        Wedding? deleteWedding = _context.Weddings.SingleOrDefault(wedd => wedd.WeddingID == id);
        if(deleteWedding != null)
        {
            _context.Remove(deleteWedding);
            _context.SaveChanges();
        }
        return RedirectToAction("Dashboard");
    }
}