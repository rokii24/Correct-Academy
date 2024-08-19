using Domain.Entities.AuthenticationEntities;
using Domain.Entities.DataEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class CorrectAcademyContext : IdentityDbContext<CorrectUser>
    {
        public  CorrectAcademyContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<CorrectStudent> Students { get; set; }
        public DbSet<Academy> Academies { get; set; }
        public DbSet<CorrectInstructor> Instructors { get; set; }
        public DbSet<Certificate> Certificates { get; set; }

    }
}
