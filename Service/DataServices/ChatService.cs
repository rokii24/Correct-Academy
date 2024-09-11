using Contract.AddDtos;
using Contract.GetDtos;
using Contract.HubDtos;
using Service.Abstraction.IDataServices;

namespace Service.DataServices
{
    public class ChatService : IChatService
    {
        public Guid AddChat(AddChatDto Dto)
        {
            throw new NotImplementedException();
        }

        public Guid AddChatMessage(MessageDto Dto, string Type)
        {
            throw new NotImplementedException();
        }

        public ICollection<GetChatDto> GetChatInfo(Guid Id)
        {
            throw new NotImplementedException();
        }

        public ICollection<GetChatMessagesDto> GetChatMessagesDto(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
