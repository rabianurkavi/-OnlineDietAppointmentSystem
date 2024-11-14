using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class MessageManager : IMessageService
{
    private readonly IMessageDal _messageDal;

    public MessageManager(IMessageDal messageDal)
    {
        _messageDal = messageDal;
    }

    public List<Message> GetAll()
    {
        return _messageDal.GetAll();
    }

    public Message GetById(int id)
    {
        return _messageDal.Get(x => x.MessageID == id);
    }

    public List<Message> GetInboxListByClient(int id)
    {
        return _messageDal.GetInBoxListWithMessageByClient(id);
    }

    public Message GetMessageClientById(int id)
    {
        return _messageDal.GetMessageIncludeClientById(id);
    }

    public List<Message> GetSendBoxListByClient(int id)
    {
        return _messageDal.GetSendBoxListWithMessageByClient(id);
    }

    public void TAdd(Message t)
    {
        _messageDal.Insert(t);
    }

    public void TDelete(Message t)
    {
        _messageDal.Delete(t);
    }

    public void TUpdate(Message t)
    {
        _messageDal.Update(t);
    }
}