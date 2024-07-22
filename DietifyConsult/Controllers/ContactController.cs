using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.Controllers
{
	public class ContactController : Controller
	{
		ContactManager contactManager = new ContactManager(new EfContactDal());
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(Contact contact)
		{
			contact.MessageDate =DateTime.Parse(DateTime.Now.ToShortDateString());
			contactManager.TAdd(contact);
			return RedirectToAction("Index","Blog");
		}
	}
}

