
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.Controllers;

public class AppointmentController : Controller
{
    private readonly AppointmentManager appointmentManager = new(new EfAppointmentDal());
    private readonly DietifyConsultContext context = new();

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ConsultantByAppointment()
    {
        var userName = User.Identity.Name;
        var userID = context.Clients.Where(x => x.ClientEmail == userName).Select(t => t.ClientID).FirstOrDefault();
        var consultantID = context.Consultants.Where(x => x.ClientID == userID).Select(t => t.ConsultantID).FirstOrDefault();
        var values = appointmentManager.GetClientByAppointment(consultantID);
        return View(values);
    }
    public IActionResult ClientByAppointment()
    {
        var userName = User.Identity.Name;
        var userID = context.Clients.Where(x => x.ClientEmail == userName).Select(t => t.ClientID).FirstOrDefault();
        var values=appointmentManager.ClientAppointmentList(userID);
        return View(values);
    }
    public IActionResult ConfirmedAppointment()
    {
        var userName = User.Identity.Name;
        var userID = context.Clients.Where(x => x.ClientEmail == userName).Select(t => t.ClientID).FirstOrDefault();
        var consultantID = context.Consultants.Where(x => x.ClientID == userID).Select(t => t.ConsultantID).FirstOrDefault();
        var values = appointmentManager.GetClientByAppointment(consultantID);
        return View(values);
    }
    public IActionResult PendingAppointment()
    {
        var userName = User.Identity.Name;
        var userID = context.Clients.Where(x => x.ClientEmail == userName).Select(t => t.ClientID).FirstOrDefault();
        var consultantID = context.Consultants.Where(x => x.ClientID == userID).Select(t => t.ConsultantID).FirstOrDefault();
        var values = appointmentManager.GetClientByAppointment(consultantID);
        return View(values);
    }
    public IActionResult ListCompletedAppointment()
    {
        var userName = User.Identity.Name;
        var userID = context.Clients.Where(x => x.ClientEmail == userName).Select(t => t.ClientID).FirstOrDefault();
        var consultantID = context.Consultants.Where(x => x.ClientID == userID).Select(t => t.ConsultantID).FirstOrDefault();
        var values = appointmentManager.GetClientByAppointment(consultantID);
        return View(values);
    }

    public IActionResult AppointmentDelete(int id)
    {
        var appointmentValue = appointmentManager.GetById(id);
        appointmentValue.Status = false;
        appointmentValue.AppointmentStatus = "İptal";
        appointmentManager.TUpdate(appointmentValue);
        return RedirectToAction("ConsultantByAppointment", "Appointment");
    }
    public IActionResult ApprovedAppointment(int id)
    {
        var appointmentValue = appointmentManager.GetById(id);
        appointmentValue.AppointmentStatus = "Onaylandı";
        appointmentManager.TUpdate(appointmentValue);
        return RedirectToAction("PendingAppointment", "Appointment");
    }
    public IActionResult CompletedAppointment(int id)
    {
        var appointmentValue = appointmentManager.GetById(id);
        appointmentValue.AppointmentStatus = "Tamamlandı";
        appointmentValue.Status = false;
        appointmentManager.TUpdate(appointmentValue);
        return RedirectToAction("ConsultantByAppointment", "Appointment");
    }
}