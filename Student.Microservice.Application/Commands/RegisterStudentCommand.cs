using MediatR;
using Student.Microservice.Application.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Microservice.Application.Commands
{
    public class RegisterStudentCommand:IRequest<Guid>
    {
        public StudentDto ? studentDto { get; set; }
    }
}
