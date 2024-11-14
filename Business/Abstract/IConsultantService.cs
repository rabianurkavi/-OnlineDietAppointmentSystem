using Business.Abstract.Generic;
using Entities.Concrete;

namespace Business.Abstract;

public interface IConsultantService : IGenericService<Consultant>
{
    List<Consultant> GetConsultantDetailById(int id);

}