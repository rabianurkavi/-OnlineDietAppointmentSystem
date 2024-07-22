using Business.Concrete;
using Business.FluentValidation;
using DataAccess.Concrete.EntityFramework;
using DietifyConsult.Models;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace DietifyConsult.Controllers
{
    public class BlogController : Controller
    {
        NewsLetterManager newsLetterManager = new NewsLetterManager(new EfNewsLetterDal());
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        DietifyConsultContext context = new DietifyConsultContext();
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
            NewsLetterValidator validationRules = new NewsLetterValidator();
            ValidationResult validationResult = validationRules.Validate(newsLetter);
            if (validationResult.IsValid)
            {
                newsLetter.MailStatus = true;
                newsLetterManager.TAdd(newsLetter);

            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }


            return PartialView(newsLetter);
        }
        //DİYETİSYEN PANELİ
        public IActionResult BlogListByConsultant()
        {
            var userName = User.Identity.Name;
            int userID = context.Clients.Where(x => x.ClientEmail == userName).Select(t => t.ClientID).FirstOrDefault();
            int consultantID = context.Consultants.Where(x => x.ClientID == userID).Select(t => t.ConsultantID).FirstOrDefault();
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
            var existingBlog = blogManager.GetById(modelBlog.BlogID);

            if (existingBlog == null)
            {
                return NotFound();
            }

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
            Blog blog = new Blog();
            blog.BlogTitle = modelBlog.BlogTitle;
            blog.BlogDescription = modelBlog.BlogDescription;
            BlogValidator validationRules = new BlogValidator();
            ValidationResult validationResult = validationRules.Validate(blog);
            

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
                int userID = context.Clients.Where(x => x.ClientEmail == userName).Select(t => t.ClientID).FirstOrDefault();
                int consultantID = context.Consultants.Where(x => x.ClientID == userID).Select(t => t.ConsultantID).FirstOrDefault();
                blog.ConsultantID = consultantID;
                blogManager.TAdd(blog);

                return RedirectToAction("Index", "Blog");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }
            return View();
        }
     
    }
}
