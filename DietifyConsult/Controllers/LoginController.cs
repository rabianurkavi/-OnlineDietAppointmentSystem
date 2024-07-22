using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace DietifyConsult.Controllers
{
	public class LoginController : Controller
	{
		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(Client client)
        {
            DietifyConsultContext context = new DietifyConsultContext();
            var dataValue = context.Clients.FirstOrDefault(x => x.ClientEmail == client.ClientEmail && x.ClientPassword == client.ClientPassword);
            if(dataValue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,client.ClientEmail)
                };
                var useridentity=new ClaimsIdentity(claims,"a");
                ClaimsPrincipal principal=new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                return View();
            }
        }
		public async Task<IActionResult> LogOut()
		{
            await HttpContext.SignOutAsync();
			return RedirectToAction("Index", "Login");
		}
	}
//    DietifyConsultContext context = new DietifyConsultContext();
//    var dataValue = context.Clients.FirstOrDefault(x => x.ClientEmail == client.ClientEmail && x.ClientPassword == client.ClientPassword);
//			if(dataValue!=null)
//			{
//				HttpContext.Session.SetString("username",client.ClientEmail);
//				return RedirectToAction("Index","Blog");
//}

//            else
//{
//    return View();
}
            

