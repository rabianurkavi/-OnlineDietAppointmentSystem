using DietifyConsult.Helper;
using DietifyConsult.Models;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            var cart = WorkingWithSession.GetObjectFromJson<List<PaymentVM>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Consultants.Price);
            return View();
        }
    }
}
