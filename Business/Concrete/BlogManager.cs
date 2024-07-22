using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BlogManager : IBlogService
    {

        IBlogDal _blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
        public List<Blog> GetAll()
        { 
            return _blogDal.GetAll();
        }

		public List<Blog> GetBlogByConsultantId(int id)
		{
			return _blogDal.GetAll(x=>x.ConsultantID == id);
		}

		public List<Blog> GetBlogListWithConsultant()
		{
			return _blogDal.GetListWithConsultant().ToList();
		}

		public Blog GetById(int id)
        {
            return _blogDal.Get(x => x.BlogID == id);
        }

		public List<Blog> GetBlogById(int id)
		{
			return _blogDal.GetAll(x=>x.BlogID==id);
		}

		public void TAdd(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void TDelete(Blog t)
        {
            _blogDal.Delete(t);
        }

        public void TUpdate(Blog t)
        {
            _blogDal.Update(t);
        }

		public Blog GetTopWeek()
		{
            return _blogDal.GetTopBlog();
		}

		public Blog RecentBlog()
		{
            return _blogDal.GetRecentBlog();
		}

		public List<Blog> Latest3Blog()
		{
			return _blogDal.GetRecentBlogs();
		}

        public List<Blog> GetListWithConsultantById(int id)
        {
            return _blogDal.GetListWithConsultantById(id);
        }
    }
}
