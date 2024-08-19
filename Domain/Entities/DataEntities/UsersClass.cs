using Domain.Entities.AuthenticationEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.DataEntities
{
    public class UsersClass
    {
        public string StudentId { get; set; } = null!;
        public IStudent Student { get; set; } = null!;
        public Guid CourseId { get; set; } 
        public Course Course { get; set; } = null!;
        public string InstructorId { get; set; } = null!;
        public IInstructor Instructor { get; set; } = null!;
    }
}
