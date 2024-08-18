using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.DataEntities
{
    public class Session : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public string Name { get; set; } = null!;

        public Guid ClassId { get; set; }
        public Class Class { get; set; } = null!;

        public ICollection<Material> Materials { get; set; } = null!;
    }
}
