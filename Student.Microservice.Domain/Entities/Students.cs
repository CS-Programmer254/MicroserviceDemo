using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Microservice.Domain.Entities
{
    public class Students
    {
        public Guid Id { get; set; }
        public string  FirstName { get; set; }
        public string  LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CourseName { get; set; }
        public string  AdmissionNumber { get; set; }
        public DateTime AdmissionDate { get; set; }
        public Students(string firstName, string lastName, string email, string phoneNumber, string courseName, string admissionNumber,DateTime admissionDate)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            CourseName= courseName;
            AdmissionNumber = admissionNumber;
            AdmissionDate = admissionDate;
        }
        public static Students AddNewStudent(string firstName, string lastName, string email,string phoneNumber, string courseName,string admissionNumber, DateTime admissionDate)
        {
            return new Students(firstName, lastName, email, phoneNumber,courseName,admissionNumber,admissionDate);
        }
    }
   
}
