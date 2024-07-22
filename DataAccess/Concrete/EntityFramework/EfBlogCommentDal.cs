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
	public class EfBlogCommentDal : GenericRepository<BlogComment, DietifyConsultContext>, IBlogCommentDal
	{
		public List<BlogComment> GetListWithBlog(int blogId)
		{

			using (var context = new DietifyConsultContext())
			{
				return context.BlogComments
					.Include(x => x.Blogs)
					.Where(x=>x.BlogId==blogId)
					.ToList();
			}

		}
        public List<BlogComment> ListWithBlog()
        {

            using (var context = new DietifyConsultContext())
            {
                return context.BlogComments
                    .Include(x => x.Blogs)
                    .ToList();
            }

        }

    }
}
