using MediatR;
using Student.Microservice.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Microservice.Application.Commands
{
    public class RegisterStudentCommandHandler : IRequestHandler<RegisterStudentCommand, Guid>
    {
        private readonly IStudentService _studentService;
        public RegisterStudentCommandHandler(IStudentService studentService)
        {
            _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
        }
        public Task<Guid> Handle(RegisterStudentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return _studentService.RegisterStudentAsync(request);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

