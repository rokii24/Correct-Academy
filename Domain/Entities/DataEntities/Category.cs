using Domain.Entities.AuthenticationEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.DataEntities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public ICollection<Course>? Courses { get; set; }
    }
}
