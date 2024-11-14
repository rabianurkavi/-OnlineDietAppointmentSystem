using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class NotificationManager : INotificationService
{
    private readonly INotificationDal _notificationDal;

    public NotificationManager(INotificationDal notificationDal)
    {
        _notificationDal = notificationDal;
    }

    public List<Notification> GetAll()
    {
        return _notificationDal.GetAll();
    }

    public Notification GetById(int id)
    {
        return _notificationDal.Get(x => x.NotificationID == id);
    }

    public List<Notification> ListWithAdmin()
    {
        return _notificationDal.ListWithAdmin();
    }

    public void TAdd(Notification t)
    {
        _notificationDal.Insert(t);
    }

    public void TDelete(Notification t)
    {
        _notificationDal.Delete(t);
    }

    public void TUpdate(Notification t)
    {
        _notificationDal.Update(t);
    }
}