using Domain.Entities.DataEntities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.AuthenticationEntities
{
    public interface IStudent
    {
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string? BackgroundImage { get; set; }
        
        public ICollection<Certificate>? Certificates { get; set; }
        public ICollection<Course> Courses { get; set; }

    }
}
