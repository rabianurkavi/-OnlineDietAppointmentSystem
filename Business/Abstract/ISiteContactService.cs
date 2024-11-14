using Business.Abstract.Generic;
using Entities.Concrete;

namespace Business.Abstract;

public interface ISiteContactService : IGenericService<SiteContact>
{
    SiteContact GetRecentSiteContact();
}