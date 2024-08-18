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
        public ICollection<Session> Sessions { get; set; } = null!;
    }
}
