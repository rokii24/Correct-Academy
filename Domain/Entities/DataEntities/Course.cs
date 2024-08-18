using Domain.Entities.AuthenticationEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.DataEntities
{
    public class Course : BaseEntity
    {
        public ICollection<UsersClass> UsersClasses { get; set; } = null!;
        public ICollection<IInstructor> Instructor { get; set; } = null!;
        public ICollection<Exam>? Exams { get; set; }
    }
}
