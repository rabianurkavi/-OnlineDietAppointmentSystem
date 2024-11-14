using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.Controllers;

public class NotificationController : Controller
{
    private readonly NotificationManager notificationManager = new(new EfNotificationDal());

    public IActionResult Index()
    {
        var values = notificationManager.GetAll();
        return View(values);
    }
}