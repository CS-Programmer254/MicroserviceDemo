using MediatR;
using Notification.Microservice.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Microservice.Application.Commands
{
    public class SendNotificationCommand:IRequest<Guid>
    {
        NotificationDto notificationDto { get; set; }
    }
}
