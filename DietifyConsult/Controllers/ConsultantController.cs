using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DietifyConsult.Models;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace DietifyConsult.Controllers
{
    [AllowAnonymous]
    public class ConsultantController : Controller
    {
        DietifyConsultContext context = new DietifyConsultContext();
        ConsultantManager consultantManager = new ConsultantManager(new EfConsultantDal());
        public IActionResult Index()
        {
            var values = consultantManager.GetAll();
            return View(values);
        }
        public IActionResult Test()
        {
            return View();
        }
        public IActionResult Test2()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ConsultantProfile()
        {
            var userName = User.Identity.Name;
            int userID = context.Clients.Where(x => x.ClientEmail == userName).Select(t => t.ClientID).FirstOrDefault();
            int consultantID = context.Consultants.Where(x => x.ClientID == userID).Select(t => t.ConsultantID).FirstOrDefault();
            var values=consultantManager.GetById(consultantID);
            return View(values);
        }

        [HttpPost]
        public IActionResult ConsultantProfile(Consultant consultant)
        {
            consultantManager.TUpdate(consultant);
            return RedirectToAction("ConsultantProfile", "Consultant");
        }

        public PartialViewResult ConsultantNavbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult ConsultantFooterPartial()
        {
            return PartialView();
        }
        public IActionResult ConsultantDetails(int id)
        {
            ViewBag.i = id;
            TempData["ConsultantId"] = id;
            var values = consultantManager.GetConsultantDetailById(id);

            return View(values);
        }
        [HttpGet]
        public IActionResult TestConsultantProfile()
        {
            var userName = User.Identity.Name;
            int userID = context.Clients.Where(x => x.ClientEmail == userName).Select(t => t.ClientID).FirstOrDefault();
            int consultantID = context.Consultants.Where(x => x.ClientID == userID).Select(t => t.ConsultantID).FirstOrDefault();
            var values = consultantManager.GetById(consultantID);
            return View(values);
        }
        [HttpPost]
        public IActionResult TestConsultantProfile(AddProfileImage profile)
        {
            var existingConsultant = consultantManager.GetById(profile.ConsultantID);
            if (profile.ConsultantImage!=null && profile.ConsultantImage.Length > 0)
            {
                var extension = Path.GetExtension(profile.ConsultantImage.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/resim/", newImageName);
                using(var stream = new FileStream(location, FileMode.Create)) 
                {
                    profile.ConsultantImage.CopyTo(stream);
                }
               existingConsultant.ConsultantImage = newImageName;
            }
            existingConsultant.ConsultantID = profile.ConsultantID;
            existingConsultant.ConsultantName = profile.ConsultantName;
            existingConsultant.ConsultantSurName = profile.ConsultantSurName;
            existingConsultant.ConsultantEmail = profile.ConsultantEmail;
            existingConsultant.ConsultantAddress = profile.ConsultantAddress;
            existingConsultant.ConsultantStatus = profile.ConsultantStatus;
            existingConsultant.PhoneNumber = profile.PhoneNumber;
            existingConsultant.Price = profile.Price;
            existingConsultant.ConsultantPassword = profile.ConsultantPassword;
            existingConsultant.RatingScore = profile.RatingScore;
            existingConsultant.Specialization = profile.Specialization;
            existingConsultant.ClientID = profile.ClientID;
            consultantManager.TUpdate(existingConsultant);
            return RedirectToAction("TestConsultantProfile", "Consultant");
        }

    }
    //var query = (from consultant in context.Consultants
    //             join education in context.Educations on consultant.ConsultantID equals education.ConsultantID into educationGroup
    //             join workExperience in context.WorkExperiences on consultant.ConsultantID equals workExperience.ConsultantID into workExperienceGroup
    //             select new
    //             {
    //                 ConsultantId = consultant.ConsultantID,
    //                 FirstName = consultant.ConsultantName,
    //                 LastName = consultant.ConsultantSurName,
    //                 Email = consultant.ConsultantEmail,
    //                 Specialization = consultant.Specialization,
    //                 PhoneNumber = consultant.PhoneNumber,
    //                 Educations = educationGroup.Select(e => new {
    //                     EducationId = e.EducationID,
    //                     Degree = e.EducationLevel,
    //                     UniversityName = e.UniversityName,
    //                     StartDate = e.UniversityGraduateHistory,
    //                     EndDate = e.UniversityEndDate
    //                 }).ToList(),
    //                 WorkExperiences = workExperienceGroup.Select(w => new {
    //                     WorkExperienceId = w.WorkExperienceID,
    //                     Company = w.CompanyName,
    //                     Continues = w.Continues,
    //                     StartDate = w.StartingDate,
    //                     EndDate = w.EndDate
    //                 }).ToList()
    //             }).FirstOrDefault(c => c.ConsultantId == id);


//    ViewBag.i = id;
//            var values = consultantManager.GetConsultantById(id);

//    var education = context.Educations.FirstOrDefault(x => x.ConsultantID == id);
//    ViewBag.UniversityName = education?.UniversityName;
//			ViewBag.UniversityGraduateHistory = education?.UniversityGraduateHistory.ToString("yyyy");
//			ViewBag.UniversityEndDate = education?.UniversityEndDate.ToString("yyyy");
//            ViewBag.EducationLevel = education?.EducationLevel;

//            var workExperience = context.WorkExperiences.FirstOrDefault(x => x.ConsultantID == id);
//    ViewBag.CompanyName = workExperience?.CompanyName;
//            ViewBag.StartingDate = workExperience?.StartingDate.ToString("yyyy");

//            var result = context.WorkExperiences.Where(x => x.ConsultantID == id).Select(y => y.EndDate).FirstOrDefault();
//            if(result != null)
//            {
//                ViewBag.EndDate=result;
//            }
//            else
//{
//    ViewBag.EndDate = "Devam Ediyor. ";
//}
//return View(values);
}
