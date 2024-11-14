using DataAccess.Abstract.Repositories;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IAdminDal : IGenericDal<Admin>
{
    List<Admin> ListWithAdminInclude();
}