using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.Controllers;

public class AdminContactController : Controller
{
    private readonly SiteContactManager siteContactManager = new(new EfSiteContactDal());

    public IActionResult Index()
    {
        var value = siteContactManager.GetRecentSiteContact();
        return View(value);
    }

    [HttpGet]
    public IActionResult ContactUpdate(int id)
    {
        var value = siteContactManager.GetById(id);
        return View(value);
    }

    [HttpPost]
    public IActionResult ContactUpdate(SiteContact siteContact)
    {
        siteContactManager.TUpdate(siteContact);
        return RedirectToAction("Index", "AdminContact");
    }
}