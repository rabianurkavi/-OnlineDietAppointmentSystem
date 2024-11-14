using Business.Abstract.Generic;
using Entities.Concrete;

namespace Business.Abstract;

public interface IAppointmentService : IGenericService<Appointment>
{
    List<Appointment> GetClientByAppointment(int id);
    List<Appointment> ClientAndConsultantByAppointment();
    List<Appointment> ClientAppointmentList(int clientID);
    Appointment GetAppointmentById(int appointmentID);

}