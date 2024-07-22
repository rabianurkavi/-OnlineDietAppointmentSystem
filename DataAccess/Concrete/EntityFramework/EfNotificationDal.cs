using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfNotificationDal : GenericRepository<Notification, DietifyConsultContext>, INotificationDal
    {
        public List<Notification> ListWithAdmin()
        {

            using (var context = new DietifyConsultContext())
            {
                return context.Notifications.Include(x => x.Admin).ToList();
            }

        }
    }
}
