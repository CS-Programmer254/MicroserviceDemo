using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Microservice.Application.DTOs
{
    public record StudentDto
    {
        public string ? FirstName { get; set; }
        public string ? LastName { get; set; }
        public string ? Email { get; set; }
        public string ? PhoneNumber { get; set; }
        public string ? CourseName { get; set; }
        public string ? AdmissionNumber { get; set; }
        public DateTime AdmissionDate { get; set; }
    }
}
