using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class NewsLetterManager : INewsLetterService
{
    private readonly INewsLetterDal _newsLetterDal;

    public NewsLetterManager(INewsLetterDal newsLetterDal)
    {
        _newsLetterDal = newsLetterDal;
    }

    public List<NewsLetter> GetAll()
    {
        return _newsLetterDal.GetAll();
    }

    public NewsLetter GetById(int id)
    {
        return _newsLetterDal.Get(x => x.MailId == id);
    }

    public void TAdd(NewsLetter t)
    {
        _newsLetterDal.Insert(t);
    }

    public void TDelete(NewsLetter t)
    {
        _newsLetterDal.Delete(t);
    }

    public void TUpdate(NewsLetter t)
    {
        _newsLetterDal.Update(t);
    }
}