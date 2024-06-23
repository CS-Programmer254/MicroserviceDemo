using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Student.Microservice.Domain.Entities
{
     public  class StudentDbContext:DbContext
    {
        public DbSet<Students> Students { get; set; }
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
         
        }
    }
}
