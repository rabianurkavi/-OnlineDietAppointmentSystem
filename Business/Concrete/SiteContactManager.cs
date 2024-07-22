using Business.Abstract;
using DataAccess.Abstract.Repositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SiteContactManager : ISiteContactService
    {
        ISiteContactDal _siteContactDal;
        public SiteContactManager(ISiteContactDal siteContactDal)
        {
            _siteContactDal = siteContactDal;
        }
        public List<SiteContact> GetAll()
        {
            return _siteContactDal.GetAll();
        }

        public SiteContact GetById(int id)
        {
            return _siteContactDal.Get(x => x.SiteContactID == id);
        }

        public SiteContact GetRecentSiteContact()
        {
            return _siteContactDal.GetRecentSiteContact();
        }

        public void TAdd(SiteContact t)
        {
            _siteContactDal.Insert(t);
        }

        public void TDelete(SiteContact t)
        {
            _siteContactDal.Delete(t);
        }

        public void TUpdate(SiteContact t)
        {
            _siteContactDal.Update(t);
        }
    }
}
