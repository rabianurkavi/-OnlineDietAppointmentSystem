using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.Controllers;

public class AboutController : Controller
{
    private readonly AboutManager aboutManager = new(new EfAboutDal());

    public IActionResult Index()
    {
        var values = aboutManager.Get();
        return View(values);
    }
}