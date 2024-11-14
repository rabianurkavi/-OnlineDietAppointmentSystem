using Business.Abstract.Generic;
using Entities.Concrete;

namespace Business.Abstract;

public interface IMessageService : IGenericService<Message>
{
    List<Message> GetInboxListByClient(int id);
    List<Message> GetSendBoxListByClient(int id);
    Message GetMessageClientById(int id);
}