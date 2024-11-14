using System.Security.Claims;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.Controllers;

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
        var context = new DietifyConsultContext();
        var dataValue = context.Clients.FirstOrDefault(x => x.ClientEmail == client.ClientEmail && x.ClientPassword == client.ClientPassword);
        if (dataValue != null)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, client.ClientEmail)
            };
            var useridentity = new ClaimsIdentity(claims, "a");
            var principal = new ClaimsPrincipal(useridentity);
            await HttpContext.SignInAsync(principal);
            return RedirectToAction("Index", "Blog");
        }

        return View();
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