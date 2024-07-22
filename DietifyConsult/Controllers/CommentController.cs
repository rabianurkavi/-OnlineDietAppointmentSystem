using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());
        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult CommentDelete(int id)
        {
            var values=commentManager.GetById(id);
            commentManager.TDelete(values);
            return RedirectToAction("AdminComment", "Index");
        }
    }
}
