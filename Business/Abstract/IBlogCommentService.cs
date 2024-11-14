using Business.Abstract.Generic;
using Entities.Concrete;

namespace Business.Abstract;

public interface IBlogCommentService : IGenericService<BlogComment>
{
    List<BlogComment> GetList(int id);
    List<BlogComment> GetTopTwoBlogs();
    List<BlogComment> ListWithBlog();
}