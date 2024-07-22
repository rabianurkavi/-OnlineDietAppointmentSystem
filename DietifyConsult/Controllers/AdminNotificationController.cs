using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.Controllers
{
    public class AdminNotificationController : Controller
    {
        NotificationManager notificationManager = new NotificationManager(new EfNotificationDal());
        DietifyConsultContext context=new DietifyConsultContext();
        public IActionResult Index()
        {
            var values=notificationManager.ListWithAdmin();
            return View(values);
        }
        public IActionResult NotificationDelete(int id)
        {
            var values = notificationManager.GetById(id);
            values.NotificationStatus = false;
            notificationManager.TUpdate(values);
            return RedirectToAction("Index", "AdminNotification");
        }
        [HttpGet]
        public IActionResult NotificationCreate()
        {         
            return View();
        }
        [HttpPost]
        public IActionResult NotificationCreate(Notification notification)
        {
            var userName = User.Identity.Name;
            int userID = context.Clients.Where(x => x.ClientEmail == userName).Select(t => t.ClientID).FirstOrDefault();
            int adminID = context.Admins.Where(x => x.ClientID == userID).Select(t => t.AdminID).FirstOrDefault();
            notification.NotificationColor = " s";
            notification.NotificationDate = DateTime.Now;
            notification.NotificationStatus = true;
            notification.AdminID = adminID;
            notificationManager.TAdd(notification);
            return RedirectToAction("Index", "AdminNotification");
        }
    }
}
