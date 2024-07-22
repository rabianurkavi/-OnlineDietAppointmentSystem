using DataAccess.Abstract.Repositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
	public interface IBlogCommentDal : IGenericDal<BlogComment>
	{
		List<BlogComment> GetListWithBlog(int blogId);
		List<BlogComment> ListWithBlog();

    }
}
