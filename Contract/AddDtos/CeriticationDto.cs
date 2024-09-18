using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.AddDtos
{
    public record CeriticationDto
    {
        public string Description { get; set; } = null!;
        public string? Image { get; set; }
        public string StudentId { get; set; } = null!;
    }
}
