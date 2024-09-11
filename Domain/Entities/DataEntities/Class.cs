using Domain.Entities.AuthenticationEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.DataEntities
{
    public class Class : BaseEntity
    {
        public string Name { get; set; } = null!;
        public Guid ChatId { get; set; }
        public Chat Chat { get; set; } = null!;
        public Guid CourseId { get; set; }
        public Course Course { get; set; } = null!;
        public string InstructorId { get; set; } = null!;
        public IInstructor Instructor { get; set; } = null!;
        public ICollection<IStudent> Students { get; set; } = null!;
        public ICollection<Session> Sessions { get; set; } = null!;
    }
}
