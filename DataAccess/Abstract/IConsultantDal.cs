using DataAccess.Abstract.Repositories;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IConsultantDal : IGenericDal<Consultant>
{
    List<Consultant> GetConsultantDetailById(int consultantId);
}