using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfEducationDal : GenericRepository<Education, DietifyConsultContext>, IEducationDal
{
}