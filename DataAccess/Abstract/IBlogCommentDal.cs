using DataAccess.Abstract.Repositories;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IBlogCommentDal : IGenericDal<BlogComment>
{
    List<BlogComment> GetListWithBlog(int blogId);
    List<BlogComment> ListWithBlog();
}