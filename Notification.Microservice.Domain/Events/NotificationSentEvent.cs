using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Microservice.Domain.Events
{
    public record NotificationSentEvent
    {
        public string ? Message { get; set; }
        public string ? PhoneNumber { get; set; }
        public Guid Receipient { get; set; }
    }
}
