using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LoginAndRegistration.Models;
using Microsoft.AspNetcore.Identity;
using AspNetCore;

namespace LoginAndRegistration.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("users/create")]
    public IActionResult Create(User newUser)
    {
        if(MidelState.IsValid)
        {
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            _context.Add(newUser);
            _context.Savechanges();
            return RedirectToAction("Success");
        }else {
            return RedirectToAction("Index");
        }
    }
    [HttpGet("Success")]
    public IActionResult Success()
    {
        return View();
    }

    [HttpGet("Login")]
    public IActionResult Login(Login userLogin)
    {
        if(ModelState.Isvalid)
        {
            User? userInDB = _context.users.SingleOrDefault(user => user.userLogin.Email);
            if(userInDB == null)
            {
                ModelState.AddModelError("Email","Invalid Email or Password");
                return RedirectToAction("Index");
            }
            PasswordHasher<Login> hasher = new PasswordHasher<Login>();
            var result = hasher.VerifyHashedPassword(userLogin, userInDB.Password, userLogin.Password);
            if(result == 0)
            {
                ModelState.AddModelError("Password", "Invalid Email or Password");
                return RedirectToAction("Index");
            }
            return RedirectToAction("Success");
        }else{
            return RedirectToAction("Index");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
