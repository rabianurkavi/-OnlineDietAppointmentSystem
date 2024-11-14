using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class EducationManager : IEducationService
{
    private readonly IEducationDal _educationDal;

    public EducationManager(IEducationDal educationDal)
    {
        _educationDal = educationDal;
    }

    public List<Education> GetAll()
    {
        return _educationDal.GetAll();
    }

    public Education GetById(int id)
    {
        return _educationDal.Get(x => x.EducationID == id);
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