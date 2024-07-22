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
    public class WorkExperienceManager : IWorkExperienceService
    {
        IWorkExperienceDal _workExperienceDal;
        public WorkExperienceManager(IWorkExperienceDal workExperienceDal )
        {
            _workExperienceDal = workExperienceDal;
        }
        public List<WorkExperience> GetAll()
        {
            return _workExperienceDal.GetAll();
        }

        public WorkExperience GetById(int id)
        {
            return _workExperienceDal.Get(x=>x.WorkExperienceID==id);
        }

        public void TAdd(WorkExperience t)
        {
            _workExperienceDal.Insert(t);
        }

        public void TDelete(WorkExperience t)
        {
            _workExperienceDal.Delete(t);
        }

        public void TUpdate(WorkExperience t)
        {
           _workExperienceDal.Update(t);
        }
    }
}
