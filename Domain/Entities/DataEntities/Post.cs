using Domain.Entities.AuthenticationEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.DataEntities
{
    public class Post : BaseEntity
    {
        public string? Description { get; set; }
        public ICollection<string>? Images { get; set; }
        public string UserId { get; set; } = null!;
        public IUser User { get; set; } = null!;

        public ICollection<Message>? Comments {  get; set; }
    }
}
