using Contract.AddDtos;
using Contract.GetDtos;
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
        public Guid AddChat(AddChatDto Dto);
        public ICollection<GetChatDto> GetChatInfo(Guid Id);
        public ICollection<GetChatMessagesDto> GetChatMessagesDto(Guid Id);
    }
}
