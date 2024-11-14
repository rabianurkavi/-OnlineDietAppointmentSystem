using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.ViewComponents.LatestBlogs;

public class LastBlogs : ViewComponent
{
    private readonly BlogManager blogManager = new(new EfBlogDal());

    public IViewComponentResult Invoke()
    {
        var values = blogManager.Latest3Blog();
        return View(values);
    }
}