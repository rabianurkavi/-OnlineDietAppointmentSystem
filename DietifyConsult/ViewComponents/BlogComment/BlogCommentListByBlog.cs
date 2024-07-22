using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.ViewComponents.BlogComment
{
    public class BlogCommentListByBlog:ViewComponent
    {
        BlogCommentManager blogCommentManager = new BlogCommentManager(new EfBlogCommentDal());
        public IViewComponentResult Invoke(int id)
        {
            var values = blogCommentManager.GetList(id);
            return View(values);
        }
    }
}
