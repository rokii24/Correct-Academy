using Domain.Entities.AuthenticationEntities;
using Domain.Entities.DataEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class CorrectInstructor : CorrectUser, IInstructor
    {
        public float Salary { get; set; }
        public ICollection<Course> Courses { get; set; } = null!;
        public ICollection<UsersClass>? UsersClass { get ; set; }
        public ICollection<Exam>? Exams { get; set; }
        public ICollection<UsersClass>? UsersClasses { get; set; }
        public ICollection<Class>? Classes { get ; set; }
    }
}
