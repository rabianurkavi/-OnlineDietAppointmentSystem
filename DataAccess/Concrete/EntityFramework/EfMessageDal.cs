using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMessageDal: GenericRepository<Message,DietifyConsultContext>, IMessageDal
    {
        public List<Message> GetInBoxListWithMessageByClient(int id)
        {
            using (var context = new DietifyConsultContext())
            {
                return context.Messages.Include(x=>x.SenderUser).Where(x=>x.ReceiverID == id).ToList();
            }
        }

        public List<Message> GetSendBoxListWithMessageByClient(int id)
        {
            using (var context = new DietifyConsultContext())
            {
                return context.Messages.Include(x => x.ReceiverUser).Where(x => x.SenderID == id).ToList();
            }
        }

        public Message GetMessageIncludeClientById(int id)
        {
            using (var context = new DietifyConsultContext())
            {

                return context.Messages.Include(x => x.SenderUser).Where(x => x.MessageID == id).FirstOrDefault();
            }
        }
    }
}
