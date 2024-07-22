using DataAccess.Abstract.Repositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IMessageDal:IGenericDal<Message>
    {
        List<Message> GetInBoxListWithMessageByClient(int id);
        List<Message> GetSendBoxListWithMessageByClient(int id);
        Message GetMessageIncludeClientById(int id);
    }
}
