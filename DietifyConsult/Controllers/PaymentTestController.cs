using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DietifyConsult.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;

namespace DietifyConsult.Controllers
{
    public class PaymentTestController : Controller
    {
        AppointmentManager appointmentManager = new AppointmentManager(new EfAppointmentDal());
        private readonly StripeSettings _stripeSettings;
        public string SessionId { get; set; }
        public PaymentTestController(IOptions<StripeSettings> stripeSettings)
        {
            _stripeSettings = stripeSettings.Value;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateCheckoutSession(int id)
        {
            var values = appointmentManager.GetAppointmentById(id);
            var currency = "try";
            var successUrl = Url.Action("Success", "PaymentTest", new { id = id }, Request.Scheme);
            var cancelUrl = "https://localhost:7153/PaymentTest/cancel";
            StripeConfiguration.ApiKey = _stripeSettings.SecretKey;
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                    "card"
                },
                LineItems = new List<SessionLineItemOptions>()
                {
                    new SessionLineItemOptions
                    {
                        PriceData= new SessionLineItemPriceDataOptions
                        {
                            Currency = currency,
                            UnitAmount=values.Consultant.Price*100,
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name=values.Consultant.ConsultantName+values.Consultant.ConsultantSurName,
                                Description="Seans Ücreti Ödemesi"

                            }

                        },
                       Quantity=1

                    }

                },
                Mode = "payment",
                SuccessUrl = successUrl,
                CancelUrl = cancelUrl

            };
            var service = new SessionService();
            var session= service.Create(options);
            SessionId=session.Id;
            return Redirect(session.Url);
        }
        public async Task<IActionResult> success(int id)
        {
            var appointment = appointmentManager.GetById(id);
            appointment.PaymentStatus = true;
            appointmentManager.TUpdate(appointment);
            return RedirectToAction("ClientByAppointment", "Appointment");
        }
        public IActionResult cancel()
        {
            return RedirectToAction("ClientByAppointment", "Appointment");
        }
    }
}
