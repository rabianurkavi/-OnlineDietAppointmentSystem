using DataAccess.Abstract;
using DataAccess.Abstract.Repositories;
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
    public class EfAdminDal: GenericRepository<Admin, DietifyConsultContext>,IAdminDal
    {
        public List<Admin> ListWithAdminInclude()
        {

            using (var context = new DietifyConsultContext())
            {
                return context.Admins.Include(x => x.Role).Include(x => x.Client).ToList();
            }

        }

    }
}
