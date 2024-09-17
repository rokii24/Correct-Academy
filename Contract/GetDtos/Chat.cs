using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.GetDtos
{
    public record GetChatDto
    {
        public Guid ChatId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? ChatImage { get; set; }
        public ICollection<GetChatMemberDto>? ChatMembers { get; set; }
    }
    public record GetChatMemberDto
    {
        public Guid UserId { get; set; } 
        public string? UserName { get; set; }
        public string? UserImage { get; set; }
    }

    public record GetChatMessagesDto
    {
        public Guid MesaageId { get; set; }
        public string Value { get; set; } = null!;
        public string? UserImage { get; set; }
        public string? UserName { get; set; }
        public DateTime SendingDate { get; set; }
    }

}
