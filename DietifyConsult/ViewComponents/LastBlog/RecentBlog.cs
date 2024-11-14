using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.ViewComponents.LastBlog;

public class RecentBlog : ViewComponent
{
    private readonly BlogManager blogManager = new(new EfBlogDal());

    public IViewComponentResult Invoke()
    {
        var values = blogManager.RecentBlog();
        return View(values);
    }
}