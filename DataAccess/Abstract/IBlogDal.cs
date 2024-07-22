using DataAccess.Abstract.Repositories;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IBlogDal:IGenericDal<Blog>
    {
        List<Blog> GetListWithConsultant();
        Blog GetTopBlog();
        Blog GetRecentBlog();
        List<Blog> GetRecentBlogs();
        List<Blog> GetListWithConsultantById(int id);



    }
}
