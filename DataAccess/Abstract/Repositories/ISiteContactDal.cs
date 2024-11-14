using Entities.Concrete;

namespace DataAccess.Abstract.Repositories;

public interface ISiteContactDal : IGenericDal<SiteContact>
{
    SiteContact GetRecentSiteContact();
}