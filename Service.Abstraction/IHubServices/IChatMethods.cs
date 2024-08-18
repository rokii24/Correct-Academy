using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstraction.IHubServices
{
    public partial interface IHubMethods
    {
        Task SendTextMessage(string classId, string message);
        Task SendVoiceMessage(string classId, string message);
        Task SendImageMessage(string classId, string message);
        Task SendReplyMessage(string classId, Guid messageId, string message);

        Task ReceiveTextMessage( string userId, string message);
        Task ReceiveVoiceMessage(string userId, string message);
        Task ReceiveImageMessage(string userId, string message);
        Task ReceiveReplyMessage(Guid messageId, string message);

    }
}
