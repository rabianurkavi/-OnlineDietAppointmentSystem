using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.ViewComponents.Admin;

public class AdminViewProfile : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var context = new DietifyConsultContext();
        var clientManager = new ClientManager(new EfClientDal());
        var userName = User.Identity.Name;
        var clientId = context.Clients.Where(x => x.ClientEmail == userName).Select(y => y.ClientID).FirstOrDefault();
        var values = clientManager.GetById(clientId);
        ViewBag.name = values.ClientName;
        ViewBag.surname = values.ClientSurName;
        ViewBag.img = values.ClientImage;
        var roleName = (from admin in context.Admins
            join role in context.Roles on admin.RoleID equals role.RoleID
            where admin.ClientID == clientId
            select role.RoleName).FirstOrDefault();
        ViewBag.roleName = roleName;
        return View();
    }
}