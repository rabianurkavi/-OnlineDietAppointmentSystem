using Business.Abstract.Generic;
using Entities.Concrete;

namespace Business.Abstract;

public interface INotificationService : IGenericService<Notification>
{
    List<Notification> ListWithAdmin();
}