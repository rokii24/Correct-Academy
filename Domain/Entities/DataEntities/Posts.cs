using Domain.Entities.AuthenticationEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.DataEntities
{
    public class Posts:BaseEntity
    {
        public string Description { get; set; }=null!;
        public ICollection<string> Image { get; set; }
        public string UserId { get; set; }
        public IUser User { get; set; } = null!;

       



    }
}
