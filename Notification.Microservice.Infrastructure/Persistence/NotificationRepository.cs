using Notification.Microservice.Domain.Entities;
using Notification.Microservice.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Microservice.Infrastructure.Persistence
{
    public class NotificationRepository : INotificationRepository
    {
        public Task<bool> SaveNotificationAsync(Notifications notification)
        {
            throw new NotImplementedException();
        }
    }
}
