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
        public Task<Guid> AddChatMessage(MessageDto Dto,string Type);
        public Task<Guid> AddChat(AddChatDto Dto);
        public Task<GetChatDto> GetChatInfo(Guid Id);
        public Task<ICollection<GetChatMessagesDto>> GetChatMessagesDto(Guid Id);
        public Task UpdateMessage(UpdateMessagesDto Dto);
        public Task UpdateChat(UpdateChatDto Dto);
        public Task DeleteMessage(Guid Id);
        public Task DeleteChat(Guid Id);
        public Task DeleteMemberFromChat(Guid ChatId, Guid MemberId);
    }
}
