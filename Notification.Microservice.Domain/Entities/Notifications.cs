using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Microservice.Domain.Entities
{
     public class Notifications
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string PhoneNumber { get; set; }
        public Guid ReceipientId { get; set; }
        public Notifications(string message, string phoneNumber, Guid receipientId)
        {
            Id = Guid.NewGuid();
            Message = message;
            PhoneNumber = phoneNumber;
            ReceipientId = receipientId;

        }
        public Notifications AddNewNotification(string message, string phoneNumber, Guid receipientId) 
        {
            
            return new Notifications(message, phoneNumber, receipientId);
        }

    }
}
