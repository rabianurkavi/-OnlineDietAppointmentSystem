using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.ViewComponents.Dashboard
{
    public class Statistic4:ViewComponent
    {
        DietifyConsultContext context=new DietifyConsultContext();
        public IViewComponentResult Invoke()
        {
            DateTime oneWeekAgo = DateTime.Today.AddDays(-7);
            ViewBag.userCount=context.Clients.Where(c=>c.DietitianStatus==true).Count();
            var highestScoringConsultant = context.Consultants
                                          .OrderByDescending(c => c.RatingScore)
                                          .FirstOrDefault();
            ViewBag.consultantName = highestScoringConsultant.ConsultantName + " " + highestScoringConsultant.ConsultantSurName;
            ViewBag.consultantImage = highestScoringConsultant.ConsultantImage;
            ViewBag.score = highestScoringConsultant.RatingScore;
            ViewBag.clientCount= context.Clients.Where(c => c.DietitianStatus == false && c.AdminStatus==false).Count();
            ViewBag.falseBlog = context.Blogs.Where(x => x.Status == false).Count();
            return View();
        }
    }
}
