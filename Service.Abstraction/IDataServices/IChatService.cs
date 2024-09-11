using Contract.HubDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstraction.IDataServices
{
    public interface IChatService
    {
        public Guid AddChatMessage(MessageDto Dto,string Type);
        public Guid AddChat(MessageDto Dto);
        public Guid GetChatMessages(MessageDto Dto);
    }
}
