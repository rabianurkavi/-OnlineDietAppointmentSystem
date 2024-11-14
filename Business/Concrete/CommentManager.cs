using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class CommentManager : ICommentService
{
    private readonly ICommentDal _commentDal;

    public CommentManager(ICommentDal commentDal)
    {
        _commentDal = commentDal;
    }

    public List<Comment> GetAll()
    {
        return _commentDal.GetAll();
    }

    public Comment GetById(int id)
    {
        return _commentDal.Get(x => x.CommentID == id);
    }

    public List<Comment> GetList(int id)
    {
        return _commentDal.GetListWithClient(id);
    }

    public List<Comment> ListWİthConsultantandClient()
    {
        return _commentDal.ListWİthConsultantandClient();
    }

    public void TAdd(Comment t)
    {
        _commentDal.Insert(t);
    }

    public void TDelete(Comment t)
    {
        _commentDal.Delete(t);
    }

    public void TUpdate(Comment t)
    {
        _commentDal.Update(t);
    }
}