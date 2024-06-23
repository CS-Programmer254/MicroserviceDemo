using EasyNetQ.AutoSubscribe;
using MediatR;
using Notification.Microservice.Application.Commands;
using Notification.Microservice.Application.DTOs;
using Notification.Microservice.Application.Services;
using Student.Microservice.Domain.Events;

namespace Notification.Microservice.API.Consumer
{

    public class NewStudentRegisteredEventConsumer : IConsumeAsync<NewStudentRegisteredEvent>
    {
        private readonly IMediator _mediator;
        private readonly INotificationService _notificationService;
        public NewStudentRegisteredEventConsumer(IMediator mediator, INotificationService notificationService)
        {
            _mediator = mediator;
            _notificationService = notificationService;
        }

        public async Task ConsumeAsync(NewStudentRegisteredEvent message, CancellationToken cancellationToken = default)
        {
           var smsBody= "Dear {message.FullName}, we are happy to welcome you to Maseno University.Your Registration Number is {message.AdmissionNumber}.You will receive your portal login credentials via email,shortly!.Thank you";
          
            var newNotification = new SendNotificationCommand
            {
                notificationDto =new  NotificationDto
                {
                    Message=smsBody,
                    SenderPhoneNumber="0769860886",
                    ReceipientPhoneNumber=message.PhoneNumber,
                    ReceipientId=message.Id,
                }
            };
            await _mediator.Send(newNotification);
        }
    }
}
