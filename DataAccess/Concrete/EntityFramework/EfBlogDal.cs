using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class EfBlogDal : GenericRepository<Blog, DietifyConsultContext>, IBlogDal
{
    public List<Blog> GetRecentBlogs()
    {
        using (var context = new DietifyConsultContext())
        {
            return context.Blogs
                .OrderByDescending(x => x.BlogID)
                .Take(3)
                .ToList();
        }
    }

    public List<Blog> GetListWithConsultant()
    {
        using (var context = new DietifyConsultContext())
        {
            return context.Blogs.Include(x => x.Consultant).ToList();
        }
    }

    public List<Blog> GetListWithConsultantById(int id)
    {
        using (var context = new DietifyConsultContext())
        {
            return context.Blogs.Where(b => b.BlogID == id).Include(x => x.Consultant).ToList();
        }
    }

    public Blog GetRecentBlog()
    {
        using (var context = new DietifyConsultContext())
        {
            return context.Blogs.OrderByDescending(x => x.BlogID).FirstOrDefault();
        }
    }

    public Blog GetTopBlog()
    {
        using (var context = new DietifyConsultContext())
        {
            // Her bir blog için ortalama puanları hesapla ve en yüksek puan alan blogu al
            var topBlog = context.BlogComments
                .GroupBy(c => c.BlogId)
                .Select(g => new
                {
                    BlogId = g.Key,
                    AverageScore = g.Average(c => c.BlogScore)
                })
                .OrderByDescending(b => b.AverageScore)
                .FirstOrDefault(); // En yüksek ortalama puanı alan blogu al

            if (topBlog != null)
            {
                // En yüksek puan alan blogun detaylarını al ve döndür
                var topBlogDetails = context.Blogs
                    .FirstOrDefault(b => b.BlogID == topBlog.BlogId);
                return topBlogDetails;
            }

            return null; // Eğer hiç blog yoksa null döndür
        }
    }
}