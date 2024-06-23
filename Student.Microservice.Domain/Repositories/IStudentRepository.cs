using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.Microservice.Domain.Entities;

namespace Student.Microservice.Domain.Repositories
{
    public interface IStudentRepository
    {
        Task<bool> SaveStudentAsync(Students student);
    }

}
