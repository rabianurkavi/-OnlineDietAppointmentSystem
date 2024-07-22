using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.Controllers
{
	public class AboutController : Controller
	{
		AboutManager aboutManager = new AboutManager(new EfAboutDal());
		public IActionResult Index()
		{
			var values = aboutManager.Get();
			return View(values);
		}
	}
}
