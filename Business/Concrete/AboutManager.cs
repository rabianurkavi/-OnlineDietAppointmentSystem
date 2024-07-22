using Business.Abstract;
using Business.Abstract.Generic;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class AboutManager : IAboutService
	{
		IAboutDal _aboutDal;
        public AboutManager(IAboutDal aboutDal)
        {
			_aboutDal = aboutDal;
		}

		public About Get()
		{
			return _aboutDal.Get(x => x.AboutID == 4);
		}

		public List<About> GetAll()
		{
			return _aboutDal.GetAll();
		}

		public About GetById(int id)
		{
			return _aboutDal.Get(x=>x.AboutID==id);
		}

		public void TAdd(About t)
		{
			_aboutDal.Insert(t);
		}

		public void TDelete(About t)
		{
			_aboutDal.Delete(t);
		}

		public void TUpdate(About t)
		{
			_aboutDal.Update(t);
		}
	}
}
