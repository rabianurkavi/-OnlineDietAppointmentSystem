using DataAccess.Abstract.Repositories;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface ICommentDal : IGenericDal<Comment>
{
    List<Comment> GetListWithClient(int id);
    List<Comment> ListWİthConsultantandClient();
}