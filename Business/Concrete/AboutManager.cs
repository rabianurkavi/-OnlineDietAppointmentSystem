using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class AboutManager : IAboutService
{
    private readonly IAboutDal _aboutDal;

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
        return _aboutDal.Get(x => x.AboutID == id);
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