using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.ViewComponents.Dashboard;

public class Statistic5 : ViewComponent
{
    private readonly ConsultantManager consultantManager = new(new EfConsultantDal());
    private readonly DietifyConsultContext context = new();

    public IViewComponentResult Invoke()
    {
        var topConsultantId = context.Blogs
            .GroupBy(b => b.ConsultantID)
            .OrderByDescending(g => g.Count())
            .Select(g => g.Key)
            .FirstOrDefault();
        var values = consultantManager.GetById(topConsultantId);
        ViewBag.consultantFullName = values.ConsultantName + " " + values.ConsultantSurName;
        ViewBag.image = values.ConsultantImage;
        return View();
    }
}