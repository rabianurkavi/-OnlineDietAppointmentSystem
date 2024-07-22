using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.Controllers
{
    public class AppointmentController : Controller
    {
        DietifyConsultContext context = new DietifyConsultContext();
        AppointmentManager appointmentManager = new AppointmentManager(new EfAppointmentDal());
        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult ConsultantByAppointment()
        {
            var userName = User.Identity.Name;
            int userID = context.Clients.Where(x => x.ClientEmail == userName).Select(t => t.ClientID).FirstOrDefault();
            int consultantID = context.Consultants.Where(x => x.ClientID == userID).Select(t => t.ConsultantID).FirstOrDefault();
            var values=appointmentManager.GetClientByAppointment(consultantID);
            return View(values);
        }
        public IActionResult AppointmentDelete(int id)
        {
            var appointmentValue = appointmentManager.GetById(id);
            appointmentValue.Status = false;
            appointmentManager.TUpdate(appointmentValue);
            return RedirectToAction("ConsultantByAppointment", "Appointment");
        }
    }
}
