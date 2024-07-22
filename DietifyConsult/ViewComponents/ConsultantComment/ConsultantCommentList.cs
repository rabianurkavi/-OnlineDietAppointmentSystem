using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.ViewComponents.ConsultantComment
{
	public class ConsultantCommentList:ViewComponent
	{
		CommentManager commentManager = new CommentManager(new EfCommentDal());
		public IViewComponentResult Invoke(int id)
		{
			var values=commentManager.GetList(id);
			return View(values);
		}
	}
}
