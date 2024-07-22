using Business.Abstract.Generic;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMessageService:IGenericService<Message>
    {
        List<Message> GetInboxListByClient(int id);
        List<Message> GetSendBoxListByClient(int id);
        Message GetMessageClientById(int id);
    }
}
