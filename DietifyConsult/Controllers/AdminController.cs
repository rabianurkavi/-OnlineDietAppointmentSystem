using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.Controllers
{
    public class AdminController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        public IActionResult Index()
        {
            var values = adminManager.ListWithAdminInclude();
            return View(values);
        }
        public IActionResult GetList()
        {
            var values=adminManager.GetAll();
            return View(values);
        }
        public IActionResult Dashboard() 
        { 
            return View();
        }
        public IActionResult Dashboard2()
        {
            return View();
        }
        public PartialViewResult AdminNavbarPartial()
        {
            return PartialView();
        }
    }
}
