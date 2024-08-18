using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.DataEntities
{
    public class Course : BaseEntity
    {
        public ICollection<Course> Courses { get; set; } = null!;
    }
}
