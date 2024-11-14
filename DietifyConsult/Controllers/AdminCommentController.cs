using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.Controllers;

public class AdminCommentController : Controller
{
    private readonly BlogCommentManager blogCommentManager = new(new EfBlogCommentDal());
    private readonly CommentManager commentManager = new(new EfCommentDal());

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult BlogComment()
    {
        var values = blogCommentManager.ListWithBlog();
        return View(values);
    }

    public IActionResult BlogCommentDelete(int id)
    {
        var values = blogCommentManager.GetById(id);
        values.CommentStatus = false;
        blogCommentManager.TUpdate(values);
        return View();
    }

    public IActionResult ConsultantComment()
    {
        var values = commentManager.ListWİthConsultantandClient();
        return View(values);
    }

    public IActionResult ConsultantCommentDelete(int id)
    {
        var values = commentManager.GetById(id);
        values.CommentStatus = false;
        commentManager.TUpdate(values);
        return View();
    }
}