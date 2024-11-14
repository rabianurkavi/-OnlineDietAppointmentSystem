using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.Controllers;

public class ConsultantCommentController : Controller
{
    private readonly CommentManager commentManager = new(new EfCommentDal());
    private readonly DietifyConsultContext context = new();

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public PartialViewResult PartialAddConsultantComment()
    {
        return PartialView();
    }

    [HttpPost]
    public IActionResult PartialAddConsultantComment(Comment comment)
    {
        var userName = User.Identity.Name;
        var userID = context.Clients.Where(x => x.ClientEmail == userName).Select(t => t.ClientID).FirstOrDefault();
        comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
        comment.ConsultantID = (int)TempData["ConsultantId"];
        comment.ClientID = userID;
        comment.CommentStatus = true;
        commentManager.TAdd(comment);
        return PartialView();
    }
}