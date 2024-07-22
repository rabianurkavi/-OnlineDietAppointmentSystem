using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.Controllers
{
    public class AdminClientController : Controller
    {
        ClientManager clientManager = new ClientManager(new EfClientDal());
        public IActionResult Index()
        {
            var values=clientManager.GetAll();
            return View(values);
        }
    }
}
