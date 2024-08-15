using Domain.Entities.AuthenticationEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.DataEntities
{
    public class Certificate : BaseEntity 
    {
        public string Description { get; set; } = null!;
        public string? Image { get; set; }
        public string StudentId { get; set; } = null!;
        public IStudent Student { get; set; } = null!;
    }
}
