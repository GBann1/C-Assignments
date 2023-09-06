using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LoginAndRegistration.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LoginAndRegistration.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private UserContext _context;
    public HomeController(ILogger<HomeController> logger, UserContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("users/create")]
    public IActionResult Create(User newUser)
    {
        if(ModelState.IsValid)
        {
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            _context.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("UserId", newUser.UserId);
            return RedirectToAction("Success");
        }else {
            return RedirectToAction("Index");
        }
    }

    [SessionCheck]
    [HttpGet("Success")]
    public IActionResult Success()
    {
        return View();
    }

    [HttpPost("Login")]
    public IActionResult Login(Login userLogin)
    {
        if(ModelState.IsValid)
        {
            User? userInDB = _context.Users.SingleOrDefault(user => user.Email == userLogin.Email);
            if(userInDB == null)
            {
                ModelState.AddModelError("Email","Invalid Email or Password");
                return View("Index");
            }
            PasswordHasher<Login> hasher = new PasswordHasher<Login>();
            var result = hasher.VerifyHashedPassword(userLogin, userInDB.Password, userLogin.Password);
            if(result == 0)
            {
                ModelState.AddModelError("Password", "Invalid Email or Password");
                return View("Index");
            }
            HttpContext.Session.SetInt32("UserId", userInDB.UserId);
            return RedirectToAction("Success");
        }else{
            return RedirectToAction("Index");
        }
    }
    // Clears session and redirects to login page
    [HttpPost("Logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

// Name this anything you want with the word "Attribute" at the end
public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Find the session, but remember it may be null so we need int?
        int? userId = context.HttpContext.Session.GetInt32("UserId");
        // Check to see if we got back null
        if(userId == null)
        {
            // Redirect to the Index page if there was nothing in session
            // "Home" here is referring to "HomeController", you can use any controller that is appropriate here
            context.Result = new RedirectToActionResult("Index", "Home", null);
        }
    }
}

