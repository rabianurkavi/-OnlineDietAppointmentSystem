using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ConsultantManager:IConsultantService
    {
        IConsultantDal _consultantDal;
        public ConsultantManager(IConsultantDal consultantDal)
        {
            _consultantDal = consultantDal;
        }
        public List<Consultant> GetAll()
        {
            return _consultantDal.GetAll();
        }

        public Consultant GetById(int id)
        {
            return _consultantDal.Get(x=>x.ConsultantID==id);
        }

        public List<Consultant> GetConsultantById(int id)
        {
            return _consultantDal.GetAll(x => x.ConsultantID == id);
        }

        public List<Consultant> GetConsultantDetailById(int id)
        {
            return _consultantDal.GetConsultantDetailById(id);
        }

        public void TAdd(Consultant t)
        {
            _consultantDal.Insert(t);
        }

        public void TDelete(Consultant t)
        {
            _consultantDal.Delete(t);
        }

        public void TUpdate(Consultant t)
        {
            _consultantDal.Update(t);
        }
    }
}
