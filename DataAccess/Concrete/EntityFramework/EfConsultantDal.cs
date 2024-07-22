using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfConsultantDal : GenericRepository<Consultant, DietifyConsultContext>, IConsultantDal
    {
       
        public List<Consultant> GetConsultantDetailById(int consultantId)
        {
            using (var context = new DietifyConsultContext())
            {
                var consultantDetailsQuery = (from consultant in context.Consultants
                                              where consultant.ConsultantID == consultantId
                                              select new Consultant
                                              {
                                                  ConsultantID = consultant.ConsultantID,
                                                  ConsultantName = consultant.ConsultantName,
                                                  ConsultantImage = consultant.ConsultantImage,
                                                  ConsultantSurName = consultant.ConsultantSurName,
                                                  ConsultantEmail = consultant.ConsultantEmail,
                                                  Price = consultant.Price,
                                                  Specialization = consultant.Specialization,
                                                  RatingScore = consultant.RatingScore,
                                                  ConsultantAddress = consultant.ConsultantAddress,
                                                  PhoneNumber = consultant.PhoneNumber,
                                                  ConsultantStatus = consultant.ConsultantStatus,                                                  
                                                  Educations = context.Educations.Where(e => e.ConsultantID == consultantId).ToList(),
                                                  WorkExperiences = context.WorkExperiences.Where(w => w.ConsultantID == consultantId).ToList(),
                                                  Comments=context.Comments.Where(c=>c.ConsultantID== consultantId).Include(x => x.Client).ToList(),
                                                  Appointments=context.Appointments.Where(a=>a.ConsultantID==consultantId).ToList(),
                                                  Blogs=context.Blogs.Where(b=>b.ConsultantID==consultantId).ToList(),
                                              }).ToList();

                return consultantDetailsQuery;
            }
        }
    }
}
