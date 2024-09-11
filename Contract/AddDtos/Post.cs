using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.AddDtos
{
    public record AddPostDto
    {
        public string? Description { get; set; }
        public string AcademyId { get; set; } = null!;
        public string? Title { get; set; }
        public bool IsPublic { get; set; } = false;
        public DateTime AddingDate { get; set; }
        public ICollection<string>? Images { get; set; }
        [Required]
        public string UserId { get; set; } = null!;
    }
    public record UpdatePostDto
    {
        public string? Description { get; set; }
        public Guid PostId { get; set; }
        public string? Title { get; set; }
        public bool IsPublic { get; set; }
    }
    public record UpdatePostImagesDto
    {
        public Guid PostId { get; set; }     
        public ICollection<string>? Images { get; set; }

    }
    public record UpdateComment
    {
        public string Value { get; set; }=null!;
        public Guid CommentId { get; set; }      
    }

}
