﻿using Business.Abstract.Generic;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IBlogCommentService:IGenericService<BlogComment>
	{
		List<BlogComment> GetList(int id);
		List<BlogComment> GetTopTwoBlogs();
        List<BlogComment> ListWithBlog();
    }
}