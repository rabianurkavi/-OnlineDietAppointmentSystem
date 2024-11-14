using DataAccess.Abstract.Repositories;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IAppointmentDal : IGenericDal<Appointment>
{
    List<Appointment> ClientByAppointment(int consultantId);
    List<Appointment> ClientAndConsultantByAppointment();
    List<Appointment> ClientAppointmentList(int clientID);
    Appointment GetAppointmentById(int appointmentID);
}