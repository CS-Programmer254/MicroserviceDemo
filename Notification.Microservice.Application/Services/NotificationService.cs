using Notification.Microservice.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Microservice.Application.Services
{
    public class NotificationService : INotificationService
    {
        public Task<bool> SendNotificationAsync(SendNotificationCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
