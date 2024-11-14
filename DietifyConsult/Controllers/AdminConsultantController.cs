using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.Controllers;

public class AdminConsultantController : Controller
{
    private BlogManager blogManager = new(new EfBlogDal());
    private CommentManager commentManager = new(new EfCommentDal());
    private readonly ConsultantManager consultantManager = new(new EfConsultantDal());
    private readonly DietifyConsultContext context = new();

    public IActionResult Index()
    {
        var values = consultantManager.GetAll();
        return View(values);
    }

    public IActionResult ConsultantDetails(int id)
    {
        ViewBag.i = id;
        TempData["ConsultantId"] = id;
        var consultantId = context.Blogs.Where(c => c.ConsultantID == id).Count();

        ViewBag.TotalAppointment = context.Appointments.Where(c => c.ConsultantID == id).Count();
        ViewBag.TotalBlog = consultantId;
        ViewBag.TotalComment = context.Comments.Where(c => c.ConsultantID == id).Count();
        var values = consultantManager.GetConsultantDetailById(id);
        return View(values);
    }

    public IActionResult ConsultantDelete(int id)
    {
        var values = consultantManager.GetById(id);
        values.ConsultantStatus = false;
        consultantManager.TUpdate(values);
        return RedirectToAction("Index", "AdminConsultant");
    }

    public IActionResult ConsultantStatusAdd(int id)
    {
        var values = consultantManager.GetById(id);
        values.ConsultantStatus = true;
        consultantManager.TUpdate(values);
        return RedirectToAction("Index", "AdminConsultant");
    }
}