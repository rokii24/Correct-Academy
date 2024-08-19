using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.HubDtos
{
    public class MessageDto
    {
        [Required]
        public required string UserId { get; set; }
        
        [Required]
        public required string ClassId { get; set; }
        
        [Required]
        public required string Message { get; set; }

    }
}
