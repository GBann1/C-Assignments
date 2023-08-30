using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers;

public class PortfolioController: Controller
{

    [HttpGet("/")]
    public ViewResult Index()
    {
        return View("Index");
    }

    [HttpGet]
    [Route("/contact")]
    public ViewResult Contact()
    {
        return View("Contact");
    }

    [HttpGet]
    [Route("/projects")]
    public ViewResult Projects()
    {
        return View("Projects");
    }
}