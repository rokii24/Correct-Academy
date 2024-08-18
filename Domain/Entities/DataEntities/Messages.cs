using Domain.Entities.AuthenticationEntities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.DataEntities
{
    public class Message : BaseEntity
    {
        public MessageType Type { get; set; }
        public string Value { get; set; } = null!;

        public string UserId { get; set; } = null!;
        public IUser User { get; set; } = null!;

        public ICollection<Message>? Replies { get; set; }
    }

    public class ChatMessage : Message
    {
        public Guid ChatId { get; set; }
        public Chat Chat { get; set; } = null!;
    }
    public class Comment : Message
    {
        public Guid PostId { get; set; }
        public Post Post { get; set; } = null!;
    }
}
