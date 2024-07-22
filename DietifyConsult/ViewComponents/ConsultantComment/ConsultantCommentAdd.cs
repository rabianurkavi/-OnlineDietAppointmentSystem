using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.ViewComponents.ConsultantComment
{
    public class ConsultantCommentAdd:ViewComponent
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());
        public IViewComponentResult Invoke(Comment comment,int id)
        {
            comment.ClientID = 3;
            comment.ConsultantID = id;
            comment.CommentDate = DateTime.Now;
            comment.CommentStatus = true;
            commentManager.TAdd(comment);
            return View();
        }

    }
}
