using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Microservice.Application.DTOs
{
    public record NotificationDto
    {
        public string ? Message { get; set; }
        public string ? SenderPhoneNumber { get; set; }
        public string ? ReceipientPhoneNumber { get; set; }
        public Guid ReceipientId{ get; set; }
    }
}
