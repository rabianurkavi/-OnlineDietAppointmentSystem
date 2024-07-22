using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.ViewComponents.Consultant
{
	public class ConsultantNavbarName:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			DietifyConsultContext context = new DietifyConsultContext();
			var userName = User.Identity.Name;
			var clientName = context.Clients.Where(x => x.ClientEmail == userName).Select(y => y.ClientName).FirstOrDefault();
			var clientSurName = context.Clients.Where(x => x.ClientEmail == userName).Select(y => y.ClientSurName).FirstOrDefault();
			var clientImage = context.Clients.Where(x => x.ClientEmail == userName).Select(y => y.ClientImage).FirstOrDefault();
			ViewBag.name = clientName;
			ViewBag.surname = clientSurName;
			ViewBag.img = clientImage;
			return View();
		}
	}
}
