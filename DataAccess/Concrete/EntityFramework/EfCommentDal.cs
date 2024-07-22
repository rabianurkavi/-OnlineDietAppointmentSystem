using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCommentDal: GenericRepository<Comment, DietifyConsultContext>, ICommentDal
    {
        public List<Comment> GetListWithClient(int id)
        {

            using (var context = new DietifyConsultContext())
            {
                return context.Comments.Where(x=>x.ConsultantID==id).Include(x => x.Client).ToList();
            }

        }
        public List<Comment> ListWİthConsultantandClient()
        {

            using (var context = new DietifyConsultContext())
            {
                return context.Comments.Include(x => x.Client).Include(x=>x.Consultant).ToList();
            }

        }
    }
}
