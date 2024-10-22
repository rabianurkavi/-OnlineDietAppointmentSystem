﻿using Business.Abstract.Generic;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAppointmentService : IGenericService<Appointment>
    {
        List<Appointment> GetClientByAppointment(int id);
        List<Appointment> ClientAndConsultantByAppointment();

    }
}
