using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfClientDal : GenericRepository<Client, DietifyConsultContext>, IClientDal
{
}