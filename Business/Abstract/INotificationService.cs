using Business.Abstract.Generic;
using DataAccess.Abstract.Repositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface INotificationService : IGenericService<Notification>
    {
        List<Notification> ListWithAdmin();

    }
}
