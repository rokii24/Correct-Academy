using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.DataEntities
{
    public class Chat : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        public Class Class { get; set; } = null!;
        public ICollection<Message>? Messages { get; set;}
    }
    public class Message : BaseEntity
    {
        public MessageType Type { get; set; }
        public string Value { get; set; } = null!;

        public Guid ChatId { get; set; }
        public Chat Chat { get; set; } = null!;


        public ICollection<Message>? Replies { get; set; }
    }
}
