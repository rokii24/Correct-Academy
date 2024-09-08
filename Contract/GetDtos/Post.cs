using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.GetDtos
{
    public class GetPostDto
    {
        public string? Description { get; set; }
        public Guid PostId { get; set; }
        public string? Title { get; set; }
        public bool IsPublic { get; set; }
        public DateTime AddingDate { get; set; }
        public ICollection<string>? Images { get; set; }
        [Required]
        public string UserId { get; set; } = null!;
        public string? UserName { get; set; }
        public string? UserImage { get; set; }
    }
}
