using Business.Abstract.Generic;
using Entities.Concrete;

namespace Business.Abstract;

public interface ICommentService : IGenericService<Comment>
{
    List<Comment> GetList(int id);
    List<Comment> ListWİthConsultantandClient();
}