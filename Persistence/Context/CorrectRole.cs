using Domain.Entities.AuthenticationEntities;
using Domain.Entities.AuthonticationEntity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class CorrectRole : IdentityRole, IRole
    {
        public CorrectRole() : base() { }
        public CorrectRole(string roleName) : base(roleName) { }
        public ICollection<IUser>? User { get; set; } 
    }
}
