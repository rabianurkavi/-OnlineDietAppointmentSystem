using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.ViewComponents.Consultant;

public class ConsultantMessageNotification : ViewComponent
{
    private readonly DietifyConsultContext context = new();
    private readonly MessageManager messageManager = new(new EfMessageDal());

    public IViewComponentResult Invoke()
    {
        var userName = User.Identity.Name;
        var userID = context.Clients.Where(x => x.ClientEmail == userName).Select(t => t.ClientID).FirstOrDefault();
        var values = messageManager.GetInboxListByClient(userID).TakeLast(3).ToList();
        return View(values);
    }
}