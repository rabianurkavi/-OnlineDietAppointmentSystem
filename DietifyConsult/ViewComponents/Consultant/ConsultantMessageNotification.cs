using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.ViewComponents.Consultant
{
    public class ConsultantMessageNotification:ViewComponent
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        DietifyConsultContext context=new DietifyConsultContext();
        public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;
            int userID = context.Clients.Where(x => x.ClientEmail == userName).Select(t => t.ClientID).FirstOrDefault();
            var values = messageManager.GetInboxListByClient(userID).TakeLast(3).ToList();
            return View(values);
        }
    }
}
