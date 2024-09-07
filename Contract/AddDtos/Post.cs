﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.AddDtos
{
    public class AddPostDto
    {
        public string? Description { get; set; }
        public string? Title { get; set; }
        public bool IsPublic { get; set; } = false;
        public DateTime AddingDate { get; set; }
        public ICollection<string>? Images { get; set; }
        [Required]
        public string UserId { get; set; } = null!;
    }
    public class UpdatePostDto
    {
        public string? Description { get; set; }
        public Guid PostId { get; set; }
        public string? Title { get; set; }
        public bool IsPublic { get; set; }
        public ICollection<string>? Images { get; set; }

    }
    public class UpdateComment
    {
        public string Value { get; set; }=null!;
        public Guid CommentId { get; set; }      
    }

}
