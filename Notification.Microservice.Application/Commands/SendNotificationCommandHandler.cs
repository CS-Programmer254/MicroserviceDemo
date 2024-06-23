using EasyNetQ;
using MediatR;
using Notification.Microservice.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Microservice.Application.Commands
{
    public class NotificationSentCommandHandler : IRequestHandler<SendNotificationCommand,bool>
    {
        private readonly INotificationService _notificationService;
        public NotificationSentCommandHandler(INotificationService notificationService)
        {
            _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
        }
        public async Task<bool> Handle(SendNotificationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _notificationService.SendNotificationAsync(request.notificationDto.ReceipientPhoneNumber, request.notificationDto.SenderPhoneNumber, request.notificationDto.Message);
            }
            catch (Exception)
            {

                throw;
            }
        
        }
    }
}
