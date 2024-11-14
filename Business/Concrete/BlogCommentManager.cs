using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class BlogCommentManager : IBlogCommentService
{
    private readonly IBlogCommentDal _blogCommentDal;

    public BlogCommentManager(IBlogCommentDal blogCommentDal)
    {
        _blogCommentDal = blogCommentDal;
    }

    public List<BlogComment> GetAll()
    {
        return _blogCommentDal.GetAll();
    }

    public BlogComment GetById(int id)
    {
        return _blogCommentDal.Get(x => x.BlogCommentId == id);
    }

    public List<BlogComment> GetList(int id)
    {
        return _blogCommentDal.GetAll(x => x.BlogId == id);
    }

    public List<BlogComment> GetTopTwoBlogs()
    {
        // 1. Blog yorumlarını ve puanları al
        var comments = _blogCommentDal.GetAll()
            .Select(c => new { c.BlogId, c.BlogScore });

        // 2. Her blog için ortalama puanı hesapla
        var blogScores = comments
            .GroupBy(c => c.BlogId)
            .Select(g => new
            {
                BlogId = g.Key,
                AverageScore = g.Average(c => c.BlogScore)
            })
            .ToList();

        // 3. En yüksek puana sahip 2 blogu seç
        var topTwoBlogs = blogScores
            .OrderByDescending(b => b.AverageScore)
            .Take(1)
            .ToList();

        // 4. En yüksek puana sahip blogların bilgilerini al
        var blogIds = topTwoBlogs.Select(b => b.BlogId);
        //var topTwoBlogDetails = _blogCommentDal.GetListWithBlog();


        // 5. Sonuçları döndür
        return null;
    }

    public List<BlogComment> ListWithBlog()
    {
        return _blogCommentDal.ListWithBlog();
    }

    public void TAdd(BlogComment t)
    {
        _blogCommentDal.Insert(t);
    }

    public void TDelete(BlogComment t)
    {
        _blogCommentDal.Delete(t);
    }

    public void TUpdate(BlogComment t)
    {
        _blogCommentDal.Update(t);
    }
}