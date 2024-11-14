using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DietifyConsult.Models;
using Entities.Concrete;
using Meeting.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DietifyConsult.Controllers
{
    public class IntegrationAppointmentController : Controller
    {
        DietifyConsultContext context = new DietifyConsultContext();
        AppointmentManager appointmentManager = new AppointmentManager(new EfAppointmentDal());
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id, DateTime? selectedDate = null)
        {
            var dietitian = context.Consultants.Include(d => d.Appointments)
                .FirstOrDefault(d => d.ConsultantID == id);

            if (dietitian == null)
            {
                return NotFound();
            }

            DateTime startDate = selectedDate ?? DateTime.Today; 
            DateTime endDate = startDate.AddDays(14);

            var recentAppointments = dietitian.Appointments
                .Where(a => a.AppointmentDateTime >= startDate && a.AppointmentDateTime <= endDate)
                .ToList();

            var availableTimesByDay = GetAvailableTimes(recentAppointments, startDate, endDate);

            var model = new DietitianDetailsViewModel
            {
                Consultant = dietitian,
                AvailableTimesByDay = availableTimesByDay,
                SelectedDate = selectedDate
            };

            return View(model);
        }

        public IActionResult CompleteAppointment()
        {
            return View();
        }
        private Dictionary<DateTime, List<TimeSpan>> GetAvailableTimes(ICollection<Appointment> appointments, DateTime startDate, DateTime endDate)
        {
            var availableTimesByDay = new Dictionary<DateTime, List<TimeSpan>>();

            for (var date = startDate.Date; date <= endDate.Date; date = date.AddDays(1))
            {
                var availableTimes = new List<TimeSpan>();
                var existingAppointments = appointments.Where(a => a.AppointmentDateTime.Date == date).ToList();

                for (var time = new TimeSpan(9, 0, 0); time < new TimeSpan(17, 0, 0); time = time.Add(TimeSpan.FromHours(1)))
                {
                    if (!existingAppointments.Any(a => a.AppointmentDateTime.TimeOfDay == time))
                    {
                        availableTimes.Add(time);
                    }
                }

                availableTimesByDay[date] = availableTimes;
            }

            return availableTimesByDay;
        }

        [HttpPost]
        public async Task<IActionResult> SaveAppointment(int ConsultantID, DateTime SelectedDate, TimeSpan SelectedTime)
        {
            DateTime appointmentDateTime = SelectedDate.Date + SelectedTime;

            var accountId = "Hn5iE5JyRh2FZF91_c9WKQ";
            var clientId = "caQMUOHCTzGvk2W0hV6r_g";
            var clientSecret = "dhM2KYg21Bx1EF96cMkJNEJjZbhdi1zU";

            var meetingManager = new MeetingManager(new Meeting.Models.Integrations.Zoom.ZoomIntegrationModel
            {
                AccountId = accountId,
                ClientId = clientId,
                ClientSecret = clientSecret,
            });

            var result = await meetingManager.Create(MeetingType.Zoom, "Diyetisyen Randevu", "Diyetisyen Randevu", appointmentDateTime, 60);
            var userName = User.Identity.Name;
            var userID = context.Clients.Where(x => x.ClientEmail == userName).Select(t => t.ClientID).FirstOrDefault();
            var appointment = new Appointment
            {
                ConsultantID = ConsultantID,
                ClientID = userID,
                AppointmentDateTime = appointmentDateTime,
                JoinID=result.JoinID,
                Link = result.DirectUrl,
                JoinUrl = result.JoinUrl,
                Password = result.Password,
                AppointmentStatus = "Bekleniyor",
                Status=true,
            };

            appointmentManager.TAdd(appointment);

            return RedirectToAction("CompleteAppointment", "IntegrationAppointment");
            //return Ok(JsonConvert.SerializeObject(result, Formatting.Indented));
        }
    }
}