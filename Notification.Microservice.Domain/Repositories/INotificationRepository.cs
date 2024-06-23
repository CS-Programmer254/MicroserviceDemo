using Notification.Microservice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Microservice.Domain.Repositories
{
     public interface INotificationRepository
    {
        Task<bool> SaveNotificationAsync(Notifications notification);

    }
}
