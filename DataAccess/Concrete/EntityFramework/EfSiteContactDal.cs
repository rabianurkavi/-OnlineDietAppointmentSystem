using DataAccess.Abstract.Repositories;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSiteContactDal:GenericRepository<SiteContact,DietifyConsultContext>,ISiteContactDal
    {
        public SiteContact GetRecentSiteContact()
        {
            using (var context = new DietifyConsultContext())
            {

                return context.SiteContacts.OrderByDescending(x => x.SiteContactID).FirstOrDefault();
            }
        }
    }
}
