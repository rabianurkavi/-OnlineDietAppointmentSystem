using DataAccess.Concrete.EntityFramework;
using DietifyConsult.Models;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DietifyConsult.Controllers
{
    public class TestController : Controller
    {
        DietifyConsultContext context = new DietifyConsultContext();

        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialDetails(int id, DateTime? selectedDate = null)
        {
            var dietitian = context.Consultants.Include(d => d.Appointments)
                .FirstOrDefault(d => d.ConsultantID == id);

            if (dietitian == null)
            {
                return PartialView();
            }

            DateTime startDate = selectedDate ?? DateTime.Today; // Use selectedDate if provided, otherwise default to today
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

            return PartialView(model); // Partial view olarak geri dön
        }
        public IActionResult Details(int id, DateTime? selectedDate = null)
        {
            var dietitian = context.Consultants.Include(d => d.Appointments)
                .FirstOrDefault(d => d.ConsultantID == id);

            if (dietitian == null)
            {
                return NotFound();
            }

            DateTime startDate = selectedDate ?? DateTime.Today; // Use selectedDate if provided, otherwise default to today
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

            return View(model); // Partial view olarak geri dön
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
    }
}
