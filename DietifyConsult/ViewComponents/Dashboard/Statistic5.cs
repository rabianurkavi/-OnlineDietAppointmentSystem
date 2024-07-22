using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.ViewComponents.Dashboard
{
	public class Statistic5 : ViewComponent
	{
		DietifyConsultContext context = new DietifyConsultContext();
		ConsultantManager consultantManager = new ConsultantManager(new EfConsultantDal());
		public IViewComponentResult Invoke()
		{
			var topConsultantId = context.Blogs
	                             .GroupBy(b => b.ConsultantID)
	                             .OrderByDescending(g => g.Count())
                                 .Select(g => g.Key)
	                             .FirstOrDefault(); 
			var values= consultantManager.GetById(topConsultantId);
			ViewBag.consultantFullName = values.ConsultantName + " " + values.ConsultantSurName;
			ViewBag.image = values.ConsultantImage;
			return View();
		}
	}
}
