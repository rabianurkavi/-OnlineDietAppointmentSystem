using DataAccess.Abstract.Repositories;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IMessageDal : IGenericDal<Message>
{
    List<Message> GetInBoxListWithMessageByClient(int id);
    List<Message> GetSendBoxListWithMessageByClient(int id);
    Message GetMessageIncludeClientById(int id);
}