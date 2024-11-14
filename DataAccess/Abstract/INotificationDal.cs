using DataAccess.Abstract.Repositories;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface INotificationDal : IGenericDal<Notification>
{
    List<Notification> ListWithAdmin();
}