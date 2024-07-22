using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.Controllers
{
    public class AdminAppointmentController : Controller
    {
        AppointmentManager appointmentManager = new AppointmentManager(new EfAppointmentDal());
        DietifyConsultContext context = new DietifyConsultContext();
        public IActionResult Index()
        {
            // Percentage calculation
            var now = DateTime.Now;

            var firstDayOfCurrentMonth = new DateTime(now.Year, now.Month, 1);
            var firstDayOfNextMonth = firstDayOfCurrentMonth.AddMonths(1);

            var firstDayOfPreviousMonth = firstDayOfCurrentMonth.AddMonths(-1);
            var lastDayOfPreviousMonth = firstDayOfCurrentMonth.AddDays(-1);

            var previousMonthAppointmentsCount = context.Appointments
                .Where(a => a.AppointmentDateTime.Date >= firstDayOfPreviousMonth.Date &&
                             a.AppointmentDateTime.Date <= lastDayOfPreviousMonth.Date)
                .Count();

            var currentMonthAppointmentsCount = context.Appointments
                .Where(a => a.AppointmentDateTime.Date >= firstDayOfCurrentMonth.Date &&
                             a.AppointmentDateTime.Date < firstDayOfNextMonth.Date)
                .Count();

            double percentageChange;
            if (previousMonthAppointmentsCount == 0)
            {
                percentageChange = currentMonthAppointmentsCount > 0 ? 100 : 0; 
            }
            else
            {
                percentageChange = ((double)(currentMonthAppointmentsCount - previousMonthAppointmentsCount) / previousMonthAppointmentsCount) * 100;
            }

            ViewBag.AppointmentCount = context.Appointments.Count();

            var oneMonthAgo = DateTime.Now.AddMonths(-1);
            var recentAppointmentsCount = context.Appointments
                .Where(a => a.AppointmentDateTime.Date >= oneMonthAgo.Date)
                .Count();
            ViewBag.LastMonthApp = recentAppointmentsCount;

            ViewBag.PercentApp = percentageChange;

            var values = appointmentManager.ClientAndConsultantByAppointment();

            return View(values);
        }
        public IActionResult AppointmentDelete(int id)
        {
            var appointmentValue = appointmentManager.GetById(id);
            appointmentValue.Status = false;
            appointmentManager.TUpdate(appointmentValue);
            return RedirectToAction("AdminAppointment", "Index");
        }
    }
}
