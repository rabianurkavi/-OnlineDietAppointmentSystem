using Business.Abstract.Generic;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {
        List<Blog> GetBlogListWithConsultant();
        List<Blog> GetBlogById(int id);
        List<Blog> GetBlogByConsultantId(int id);
        Blog GetTopWeek();
        Blog RecentBlog();
        List<Blog> Latest3Blog();
        List<Blog> GetListWithConsultantById(int id);

    }
}
