using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.ViewComponents.BlogScore;

public class BlogTopWeek : ViewComponent
{
    private readonly BlogManager blogManager = new(new EfBlogDal());

    public IViewComponentResult Invoke()
    {
        var values = blogManager.GetTopWeek();
        return View(values);
    }
}