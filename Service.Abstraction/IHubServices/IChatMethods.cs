using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstraction.IHubServices
{
    public partial interface IHubMethods
    {
        Task ReceiveMessage( string userId, string message, MessageType type);
        Task ReceiveReplyMessage(Guid messageId, string message);
        Task ReceiveComment(string userId, string message, MessageType type);
        Task ReceiveCommentReply(string messageId, string message, MessageType type);

    }
}
