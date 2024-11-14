using DataAccess.Abstract.Repositories;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IBlogDal : IGenericDal<Blog>
{
    List<Blog> GetListWithConsultant();
    Blog GetTopBlog();
    Blog GetRecentBlog();
    List<Blog> GetRecentBlogs();
    List<Blog> GetListWithConsultantById(int id);
}