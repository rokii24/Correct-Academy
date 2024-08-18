using Domain.Entities.AuthenticationEntities;
using Domain.Entities.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.AuthenticationEntities
{
    public interface IInstructor
    {
        public float Salary { get; set; }

        public ICollection<Course> Courses { get; set; }
        public ICollection<UsersClass> UsersClass { get; set; }
        public ICollection<Exam> Exams { get; set; }
    }
}
