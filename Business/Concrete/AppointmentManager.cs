using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class AppointmentManager : IAppointmentService
{
    private readonly IAppointmentDal _appointmentDal;

    public AppointmentManager(IAppointmentDal appointmentDal)
    {
        _appointmentDal = appointmentDal;
    }

    public List<Appointment> ClientAndConsultantByAppointment()
    {
        return _appointmentDal.ClientAndConsultantByAppointment();
    }

    public List<Appointment> ClientAppointmentList(int clientID)
    {
        return _appointmentDal.ClientAppointmentList(clientID);
    }

    public List<Appointment> GetAll()
    {
        return _appointmentDal.GetAll();
    }

    public Appointment GetAppointmentById(int appointmentID)
    {
        return _appointmentDal.GetAppointmentById(appointmentID);
    }

    public Appointment GetById(int id)
    {
        return _appointmentDal.Get(x => x.AppointmentID == id);
    }

    public List<Appointment> GetClientByAppointment(int consultantId)
    {
        return _appointmentDal.ClientByAppointment(consultantId).ToList();
    }

    public void TAdd(Appointment t)
    {
        _appointmentDal.Insert(t);
    }

    public void TDelete(Appointment t)
    {
        _appointmentDal.Delete(t);
    }

    public void TUpdate(Appointment t)
    {
        _appointmentDal.Update(t);
    }
}