using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.ViewComponents.ConsultantComment;

public class ConsultantCommentList : ViewComponent
{
    private readonly CommentManager commentManager = new(new EfCommentDal());

    public IViewComponentResult Invoke(int id)
    {
        var values = commentManager.GetList(id);
        return View(values);
    }
}