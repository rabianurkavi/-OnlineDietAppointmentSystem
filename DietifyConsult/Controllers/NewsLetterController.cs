using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.Controllers;

public class NewsLetterController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}