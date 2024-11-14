using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.Controllers;

public class AdminAboutController : Controller
{
    private readonly AboutManager aboutManager = new(new EfAboutDal());

    public IActionResult Index()
    {
        var values = aboutManager.GetAll();
        return View(values);
    }

    [HttpGet]
    public IActionResult AboutUpdate(int id)
    {
        var value = aboutManager.GetById(id);
        return View(value);
    }

    [HttpPost]
    public IActionResult AboutUpdate(About about)
    {
        aboutManager.TUpdate(about);
        return RedirectToAction("Index", "AdminAbout");
    }
}