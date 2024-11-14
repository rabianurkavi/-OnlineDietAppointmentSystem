using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class EfBlogCommentDal : GenericRepository<BlogComment, DietifyConsultContext>, IBlogCommentDal
{
    public List<BlogComment> GetListWithBlog(int blogId)
    {
        using (var context = new DietifyConsultContext())
        {
            return context.BlogComments
                .Include(x => x.Blogs)
                .Where(x => x.BlogId == blogId)
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