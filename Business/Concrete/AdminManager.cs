using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class AdminManager : IAdminService
{
    private readonly IAdminDal _adminDal;

    public AdminManager(IAdminDal adminDal)
    {
        _adminDal = adminDal;
    }

    public List<Admin> GetAll()
    {
        return _adminDal.GetAll();
    }

    public Admin GetById(int id)
    {
        return _adminDal.Get(x => x.AdminID == id);
    }

    public List<Admin> ListWithAdminInclude()
    {
        return _adminDal.ListWithAdminInclude();
    }

    public void TAdd(Admin t)
    {
        _adminDal.Insert(t);
    }

    public void TDelete(Admin t)
    {
        _adminDal.Delete(t);
    }

    public void TUpdate(Admin t)
    {
        _adminDal.Update(t);
    }
}