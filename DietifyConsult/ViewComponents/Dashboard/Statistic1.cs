using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace DietifyConsult.ViewComponents.Dashboard
{
    public class Statistic1:ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        DietifyConsultContext context = new DietifyConsultContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.cv = blogManager.GetAll().Count();

            var userName = User.Identity.Name;
            var clientId = context.Clients.Where(x => x.ClientEmail == userName).Select(y => y.ClientID).FirstOrDefault();
            var messageCount = context.Messages.Where(x => x.ReceiverID == clientId).Select(y => y.MessageID).Count();
            ViewBag.ms = messageCount;
            ViewBag.cc = context.BlogComments.Count();
            ViewBag.messageCount = messageCount;
            string api = "6fd2dfcc6c9fce3cb2f9ff2aa57e7c56";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=ankara&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.havaDurumu = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
