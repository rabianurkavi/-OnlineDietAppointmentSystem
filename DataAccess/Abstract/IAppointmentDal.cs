using DataAccess.Abstract.Repositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IAppointmentDal:IGenericDal<Appointment>
    {
        List<Appointment> ClientByAppointment(int consultantId);
        List<Appointment> ClientAndConsultantByAppointment();
    }
}
