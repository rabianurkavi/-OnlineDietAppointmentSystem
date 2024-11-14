using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.Controllers;

public class AdminBlogController : Controller
{
    private readonly BlogManager blogManager = new(new EfBlogDal());

    public IActionResult Index()
    {
        var values = blogManager.GetBlogListWithConsultant();
        return View(values);
    }

    public IActionResult BlogReadAll(int id)
    {
        ViewBag.i = id;
        var values = blogManager.GetListWithConsultantById(id);
        return View(values);
    }
}