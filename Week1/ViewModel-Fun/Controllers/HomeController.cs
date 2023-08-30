using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewModel_Fun.Models;

namespace ViewModel_Fun.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // public IActionResult Index()
    // {
    //     return View();
    // }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        string message = "Hello there, this is a backend message";
        return View("Index",message);
    }

    [HttpGet("numbers")]
    public IActionResult Number()
    {
        
        int[] nums = {1,2,3,4,5,6,7,8};
        NumbersModel NumModel = new NumbersModel
        {
            NumArr = nums
        };
        return View(NumModel);
    }
    [HttpGet("user")]
    public IActionResult User()
    {
        
        string firstName = "Steve";
        string lastName = "Bronson";
        UserModel UsrMod = new UserModel
        {
            FirstName = firstName,
            LastName = lastName
        };
        return View(UsrMod);
    }
    [HttpGet("users")]
    public IActionResult Users()
    {
        
        List<UserModel> UserList = new List<UserModel>()
        {
            new UserModel {FirstName="James",LastName="Bond"},
            new UserModel {FirstName="Steve",LastName="Rider"},
            new UserModel {FirstName="Dave",LastName="Erwin"},
            new UserModel {FirstName="Tom",LastName="Asdf"},

        };
        
        return View(UserList);
    }
}
