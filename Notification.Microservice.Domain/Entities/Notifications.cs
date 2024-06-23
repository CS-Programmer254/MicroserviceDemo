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
        public Guid Receipient { get; set; }
        public Notifications(string message, string phoneNumber, Guid receipient)
        {
            Id = Guid.NewGuid();
            Message = message;
            PhoneNumber = phoneNumber;
            Receipient = receipient;

        }
        public Notifications AddNewNotification(string message, string phoneNumber, Guid receipient) 
        {
            
            return new Notifications(message, phoneNumber, receipient);
        }

    }
}
