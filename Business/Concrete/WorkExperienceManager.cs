using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class WorkExperienceManager : IWorkExperienceService
{
    private readonly IWorkExperienceDal _workExperienceDal;

    public WorkExperienceManager(IWorkExperienceDal workExperienceDal)
    {
        _workExperienceDal = workExperienceDal;
    }

    public List<WorkExperience> GetAll()
    {
        return _workExperienceDal.GetAll();
    }

    public WorkExperience GetById(int id)
    {
        return _workExperienceDal.Get(x => x.WorkExperienceID == id);
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