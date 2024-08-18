using Domain.Entities.AuthenticationEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.AuthonticationEntity
{
    public interface IRole
    {
        string Id { get; set; }
        string? Name { get; set; }
        public ICollection<IUser>? User { get; set; }
    }
}
