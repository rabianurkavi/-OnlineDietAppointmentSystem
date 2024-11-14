using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

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