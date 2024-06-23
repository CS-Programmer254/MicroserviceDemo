using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Microservice.Application.Commands
{
    public class NotificationSentCommandHandler : IRequestHandler<SendNotificationCommand, Guid>
    {
        public Task<Guid> Handle(SendNotificationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
