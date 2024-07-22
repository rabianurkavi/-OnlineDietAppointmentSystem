using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAppointmentDal : GenericRepository<Appointment, DietifyConsultContext>, IAppointmentDal
    {
        public List<Appointment> ClientByAppointment(int consultantId)
        {

            using (var context = new DietifyConsultContext())
            {
                return context.Appointments
                    .Where(x=>x.ConsultantID== consultantId)
                    .Include(x => x.Client).ToList();
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
}
