using Student.Microservice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Microservice.Infrastructure.Persistence
{
    internal class StudentRepository
    {
        private readonly StudentDbContext _studentDbContext;
        public StudentRepository(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext ?? throw new ArgumentNullException(nameof(studentDbContext));
        }
        public async Task<bool> SaveCustomerAsync(Students student)
        {
            try
            {
                await _studentDbContext.Students.AddAsync(student);
                await _studentDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}


