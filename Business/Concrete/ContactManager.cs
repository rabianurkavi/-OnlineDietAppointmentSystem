using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class ContactManager : IContactService
{
    private readonly IContactDal _contactDal;

    public ContactManager(IContactDal contactDal)
    {
        _contactDal = contactDal;
    }

    public List<Contact> GetAll()
    {
        return _contactDal.GetAll();
    }

    public Contact GetById(int id)
    {
        return _contactDal.Get(x => x.ContactId == id);
    }

    public void TAdd(Contact t)
    {
        _contactDal.Insert(t);
    }

    public void TDelete(Contact t)
    {
        _contactDal.Delete(t);
    }

    public void TUpdate(Contact t)
    {
        _contactDal.Update(t);
    }
}