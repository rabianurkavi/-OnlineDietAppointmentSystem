using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.ViewComponents.Dashboard;

public class Statistic2 : ViewComponent
{
    private readonly DietifyConsultContext context = new();

    public IViewComponentResult Invoke()
    {
        ViewBag.v1 = context.Blogs.OrderByDescending(x => x.BlogCreateDate).Select(x => x.BlogTitle).Take(1).FirstOrDefault();
        ViewBag.v2 = context.Blogs
            .OrderByDescending(x => x.BlogID)
            .Select(x => x.Consultant.ConsultantName + " " + x.Consultant.ConsultantSurName)
            .FirstOrDefault();
        var totalPrice = context.Appointments
                .Where(a => a.PaymentStatus)
                .Sum(a => a.Consultant.Price);
        ViewBag.TotalPrice = totalPrice;
        return View();
    }
}