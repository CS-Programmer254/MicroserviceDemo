using Student.Microservice.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Microservice.Application.Services
{
    public interface IStudentService
    {
        Task<Guid> RegisterStudentAsync(RegisterStudentCommand studentCommand);
       
    }
}
