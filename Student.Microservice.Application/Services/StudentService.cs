using EasyNetQ;
using Student.Microservice.Application.Commands;
using Student.Microservice.Domain.Entities;
using Student.Microservice.Domain.Events;
using Student.Microservice.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Microservice.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IBus _bus;
        public StudentService(IStudentRepository studentRepository, IBus bus)
        {
            _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
            _bus = bus;
        }

        public async Task<Guid> RegisterStudentAsync(RegisterStudentCommand studentCommand)
        {
            try
            {
                var newStudent = Students
                    .AddNewStudent(

                    firstName: studentCommand.studentDto.FirstName,
                    lastName: studentCommand.studentDto.LastName,
                    email: studentCommand.studentDto.Email,
                    phoneNumber: studentCommand.studentDto.PhoneNumber,
                    courseName: studentCommand.studentDto.CourseName,
                    admissionNumber: studentCommand.studentDto.AdmissionNumber,
                    admissionDate: DateTime.Now
                    );
   
                await _studentRepository.SaveStudentAsync(newStudent);

                await _bus.PubSub.PublishAsync(new StudentRegisteredEvent
                {
                    FullNames = $"{newStudent.FirstName} {studentCommand.studentDto.LastName}",
                    Email =newStudent.Email,
                    PhoneNumber=newStudent.PhoneNumber,
                    CourseName=newStudent.CourseName,
                    AdmissionNumber=newStudent.AdmissionNumber,

                });

                return newStudent.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
