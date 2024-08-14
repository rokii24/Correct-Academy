using Domain.Entities.AuthenticationEntities;
using Domain.Entities.DataEntities;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class CorrectStudent : CorrectUser
    {

        public int age { get; set; }
        public Gender Gender { get; set; }
        public string? BackgroundImage { get; set; }
        public ICollection<Certificate>? Certificates { get; set; }

    }
}
