using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EducationManager : IEducationService
    {
        IEducationDal _educationDal;
        public EducationManager(IEducationDal educationDal )
        {
            _educationDal = educationDal;
        }
        public List<Education> GetAll()
        {
            return _educationDal.GetAll();
        }

        public Education GetById(int id)
        {
            return _educationDal.Get(x=>x.EducationID == id);
        }

        public void TAdd(Education t)
        {
            _educationDal.Insert(t);
        }

        public void TDelete(Education t)
        {
            _educationDal.Delete(t);
        }

        public void TUpdate(Education t)
        {
            _educationDal.Update(t);
        }
    }
}
