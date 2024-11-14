using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class EfAppointmentDal : GenericRepository<Appointment, DietifyConsultContext>, IAppointmentDal
{
    public List<Appointment> ClientByAppointment(int consultantId)
    {
        using (var context = new DietifyConsultContext())
        {
            return context.Appointments
                .Where(x => x.ConsultantID == consultantId)
                .Include(x => x.Client).ToList();
        }
    }
    public List<Appointment> ClientAppointmentList(int clientID)
    {
        using (var context = new DietifyConsultContext())
        {
            return context.Appointments
              .Where(x => x.ClientID == clientID)
              .Include(x => x.Client)
              .Include(x => x.Consultant)
              .OrderByDescending(x => x.AppointmentDateTime) 
              .ToList();
        }
    }
    public Appointment GetAppointmentById(int appointmentID)
    {
        using (var context = new DietifyConsultContext())
        {
            return context.Appointments
              .Where(x => x.AppointmentID == appointmentID)
              .Include(x => x.Client)
              .Include(x => x.Consultant)
              .FirstOrDefault();

        }
    }

    public List<Appointment> ClientAndConsultantByAppointment()
    {
        using (var context = new DietifyConsultContext())
        {
            return context.Appointments
                .Include(x => x.Client)
                .Include(x => x.Consultant)
                .ToList();
        }
    }
}