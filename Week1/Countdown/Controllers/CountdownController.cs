using Microsoft.AspNetCore.Mvc;

namespace Countdown.Controllers;

public class CountdownController: Controller
{

    [HttpGet("/")]
    public ViewResult Index()
    {
        DateTime futureDate = new DateTime(2023, 9, 20,12,32,18);
        ViewBag.FutureDate = futureDate;
        return View("Countdown");
    }
}