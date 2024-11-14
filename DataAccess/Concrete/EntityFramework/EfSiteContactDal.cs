using DataAccess.Abstract.Repositories;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfSiteContactDal : GenericRepository<SiteContact, DietifyConsultContext>, ISiteContactDal
{
    public SiteContact GetRecentSiteContact()
    {
        using (var context = new DietifyConsultContext())
        {
            return context.SiteContacts.OrderByDescending(x => x.SiteContactID).FirstOrDefault();
        }
    }
}