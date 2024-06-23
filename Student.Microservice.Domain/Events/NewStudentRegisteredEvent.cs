﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Microservice.Domain.Events
{
    public record NewStudentRegisteredEvent
    {
        public Guid Id { get; set; }
        public string ? FullName { get; set; }
        public string ? Email { get; set; }
        public string ? PhoneNumber { get; set; }
        public string ? CourseName { get; set; }
        public string ? AdmissionNumber { get; set; }
    }
}
