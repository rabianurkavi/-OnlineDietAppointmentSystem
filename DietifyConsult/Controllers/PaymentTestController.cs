using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;

namespace DietifyConsult.Controllers
{
    public class PaymentTestController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Route("create-product")]
        public async Task<ActionResult> CreateProduct()
        {
            var productService = new Stripe.ProductService();
            ProductCreateOptions options = new ProductCreateOptions();
            options.Name = "Deneme Ürünü 4";
            options.Description = "Deneme Ürünü Açıklamaası 4";
            options.DefaultPriceData = new ProductDefaultPriceDataOptions()
            {
                Currency = "TRY",
                UnitAmount = 1000000
            };
            var result = await productService.CreateAsync(options);
            return Ok(result);
        }

        [Route("create-checkout-session")]
        public ActionResult Create()
        {
            var domain = "https://localhost:7153";
            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
                {
                  new SessionLineItemOptions
                  {
                    Price = "price_1PKOkQKxKaGWHxtV7yXrbn5R",
                    Quantity = 1,
                  },
                },
                Mode = "payment",
                SuccessUrl = domain + "/success.html",
                CancelUrl = domain + "/cancel.html",
            };
            var service = new SessionService();
            Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }
    }

}
