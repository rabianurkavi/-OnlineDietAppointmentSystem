using Business.Abstract.Generic;
using Entities.Concrete;

namespace Business.Abstract;

public interface IAdminService : IGenericService<Admin>
{
    List<Admin> ListWithAdminInclude();
}