using Business.Concrete;
using Business.FluentValidation;
using DataAccess.Concrete.EntityFramework;
using DietifyConsult.Models;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.Controllers;

public class BlogController : Controller
{
    private readonly BlogManager blogManager = new(new EfBlogDal());
    private readonly DietifyConsultContext context = new();
    private readonly NewsLetterManager newsLetterManager = new(new EfNewsLetterDal());

    public IActionResult Index()
    {
        var values = blogManager.GetBlogListWithConsultant();
        return View(values);
    }

    public IActionResult BlogDetails(int id)
    {
        ViewBag.i = id;
        TempData["BlogId"] = id;
        var values = blogManager.GetBlogById(id);
        return View(values);
    }

    [HttpGet]
    public PartialViewResult PartialSubscribe()
    {
        return PartialView();
    }

    [HttpPost]
    public IActionResult PartialSubscribe(NewsLetter newsLetter)
    {
        var validationRules = new NewsLetterValidator();
        var validationResult = validationRules.Validate(newsLetter);
        if (validationResult.IsValid)
        {
            newsLetter.MailStatus = true;
            newsLetterManager.TAdd(newsLetter);
        }
        else
        {
            foreach (var item in validationResult.Errors) ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        }


        return PartialView(newsLetter);
    }

    //DİYETİSYEN PANELİ
    public IActionResult BlogListByConsultant()
    {
        var userName = User.Identity.Name;
        var userID = context.Clients.Where(x => x.ClientEmail == userName).Select(t => t.ClientID).FirstOrDefault();
        var consultantID = context.Consultants.Where(x => x.ClientID == userID).Select(t => t.ConsultantID).FirstOrDefault();
        var values = blogManager.GetBlogByConsultantId(consultantID);
        return View(values);
    }

    [HttpGet]
    public IActionResult EditBlog(int id)
    {
        var blogValue = blogManager.GetById(id);
        return View(blogValue);
    }

    [HttpPost]
    public IActionResult EditBlog(AddBlogImage modelBlog)
    {
        // Mevcut blogu veritabanından alın
        var existingBlog = blogManager.GetById(modelBlog.BlogID);

        if (existingBlog == null) return NotFound();

        // Yeni bir görsel dosyası sağlanıp sağlanmadığını kontrol edin
        if (modelBlog.BlogImage != null && modelBlog.BlogImage.Length > 0)
        {
            var extension = Path.GetExtension(modelBlog.BlogImage.FileName);
            var newImageName = Guid.NewGuid() + extension;
            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/resim/", newImageName);
            using (var stream = new FileStream(location, FileMode.Create))
            {
                modelBlog.BlogImage.CopyTo(stream);
            }

            existingBlog.BlogImage = newImageName;
        }

        // Blog özelliklerini güncelleyin
        existingBlog.BlogTitle = modelBlog.BlogTitle;
        existingBlog.BlogDescription = modelBlog.BlogDescription;
        existingBlog.Status = modelBlog.Status;
        existingBlog.ConsultantID = modelBlog.ConsultantID;
        existingBlog.BlogCreateDate = modelBlog.BlogCreateDate;
        existingBlog.BlogScore = modelBlog.BlogScore;

        blogManager.TUpdate(existingBlog);

        return RedirectToAction("BlogListByConsultant", "Blog");
    }

    public IActionResult BlogDelete(int id)
    {
        var blogValue = blogManager.GetById(id);
        blogValue.Status = false;
        blogManager.TUpdate(blogValue);
        return RedirectToAction("BlogListByConsultant", "Blog");
    }

    [HttpGet]
    public IActionResult BlogAdd()
    {
        return View();
    }

    [HttpPost]
    public IActionResult BlogAdd(AddBlogImage modelBlog)
    {
        var blog = new Blog();
        blog.BlogTitle = modelBlog.BlogTitle;
        blog.BlogDescription = modelBlog.BlogDescription;
        var validationRules = new BlogValidator();
        var validationResult = validationRules.Validate(blog);


        if (validationResult.IsValid)
        {
            var extension = Path.GetExtension(modelBlog.BlogImage.FileName);
            var newImageName = Guid.NewGuid() + extension;
            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/resim/", newImageName);
            var stream = new FileStream(location, FileMode.Create);
            modelBlog.BlogImage.CopyTo(stream);
            blog.BlogImage = newImageName;
            blog.BlogScore = 0;
            blog.Status = true;
            blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            var userName = User.Identity.Name;
            var userID = context.Clients.Where(x => x.ClientEmail == userName).Select(t => t.ClientID).FirstOrDefault();
            var consultantID = context.Consultants.Where(x => x.ClientID == userID).Select(t => t.ConsultantID).FirstOrDefault();
            blog.ConsultantID = consultantID;
            blogManager.TAdd(blog);

            return RedirectToAction("Index", "Blog");
        }

        foreach (var item in validationResult.Errors) ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        return View();
    }
}