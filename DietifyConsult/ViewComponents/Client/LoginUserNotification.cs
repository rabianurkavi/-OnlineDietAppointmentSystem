using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.ViewComponents.Client;

public class LoginUserNotification : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var context = new DietifyConsultContext();
        var userName = User.Identity.Name;
        var clientName = context.Clients.Where(x => x.ClientEmail == userName).Select(y => y.ClientName).FirstOrDefault();
        var clientSurName = context.Clients.Where(x => x.ClientEmail == userName).Select(y => y.ClientSurName).FirstOrDefault();
        var clientImage = context.Clients.Where(x => x.ClientEmail == userName).Select(y => y.ClientImage).FirstOrDefault();
        var dietitianStatus = context.Clients.Where(x => x.ClientEmail == userName).Select(y => y.DietitianStatus).FirstOrDefault();
        var adminStatus = context.Clients.Where(x => x.ClientEmail == userName).Select(y => y.AdminStatus).FirstOrDefault();
        if (clientName == null)
        {
            ViewBag.name = "Giriş Yap";
            ViewBag.img = "/image/person.jpg/";
        }
        else
        {
            ViewBag.name = clientName;
            ViewBag.surname = clientSurName;
            ViewBag.img = clientImage;
            ViewBag.status = dietitianStatus;
            ViewBag.adminStatus = adminStatus;
        }

        return View();
    }
}