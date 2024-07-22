using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.ViewComponents.BlogScore
{
    public class BlogTopWeek:ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        public IViewComponentResult Invoke()
        {
            var values= blogManager.GetTopWeek();
            return View(values);
        }
    }
}
