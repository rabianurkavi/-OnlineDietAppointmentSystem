using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class EfAdminDal : GenericRepository<Admin, DietifyConsultContext>, IAdminDal
{
    public List<Admin> ListWithAdminInclude()
    {
        using (var context = new DietifyConsultContext())
        {
            return context.Admins.Include(x => x.Role).Include(x => x.Client).ToList();
        }
    }
}