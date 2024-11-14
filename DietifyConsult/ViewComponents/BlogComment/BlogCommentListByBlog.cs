using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.ViewComponents.BlogComment;

public class BlogCommentListByBlog : ViewComponent
{
    private readonly BlogCommentManager blogCommentManager = new(new EfBlogCommentDal());

    public IViewComponentResult Invoke(int id)
    {
        var values = blogCommentManager.GetList(id);
        return View(values);
    }
}