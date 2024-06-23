using Notification.Microservice.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Microservice.Application.Services
{
    public interface INotificationService
    {
        Task<bool> SendNotificationAsync(SendNotificationCommand notificationSentCommand);
    }
}
