using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.Controllers
{
    public class BlogCommentController : Controller
    {
        BlogCommentManager _blogCommentManager = new BlogCommentManager(new EfBlogCommentDal());
        DietifyConsultContext context = new DietifyConsultContext();

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult PartialAddComment(BlogComment comment)
        {
            var userName = User.Identity.Name;
            string fullName = context.Clients
                           .Where(x => x.ClientEmail == userName)
                           .Select(t => t.ClientName + " " + t.ClientSurName)
                           .FirstOrDefault();
            comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            comment.CommentStatus = true;
            comment.CommentUserName = fullName;
            comment.BlogId = (int)TempData["BlogId"];
            _blogCommentManager.TAdd(comment);
            return PartialView();
        }

    }
}
