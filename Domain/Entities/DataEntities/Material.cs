using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.DataEntities
{
    public class Material : BaseEntity
    {
        /// <summary>
        /// Path of Material 
        /// </summary>
        public new string Id { get; set; } = null!;
        public MaterialType Type {  get; set; }

        public Guid SessionId { get; set; }
        public Session Session { get; set; } = null!;

    }
}
