using Contract.AddDtos;
using Contract.GetDtos;
using Contract.HubDtos;
using Domain.Entities.DataEntities;
using Domain.Exceptions;
using Domain.IRepositories.DataRepository;
using Service.Abstraction.IDataServices;
using Service.Abstraction.IExternalServices;
using Service.Extentions;

namespace Service.DataServices
{
    public class ChatService : IChatService
    {
        public readonly IAdminDataRepository _adminDataRepository;
        public readonly IExternalService _externalService;
        public ChatService(IAdminDataRepository adminDataRepository, IExternalService externalService)
        {
            _adminDataRepository=adminDataRepository;
            _externalService = externalService;
        }

        public async Task<Guid> AddChat(AddChatDto Dto)
        {
            var Chat = Dto.ToChat();
            await _adminDataRepository.ChatRepository.Add(Chat);    
            await _adminDataRepository.SaveChangesAsync();
            return Chat.Id;
        }

        public async Task<Guid> AddChatMessage(MessageDto Dto, string Type)
        {
            //var classs = _adminDataRepository. 
            var ChatMessage = Dto.ToChatMessage(Type);
            await _adminDataRepository.ChatMessageRepository.Add(ChatMessage);
            await _adminDataRepository.SaveChangesAsync();
            return ChatMessage.Id;
        }

        public async Task DeleteChat(Guid Id)
        {
            var chat = await _adminDataRepository.ChatRepository.Get(Id);
            if (chat == null)
                throw new NotFoundException("Chat Not found");

            await _adminDataRepository.ChatRepository.Delete(chat);
            await _adminDataRepository.SaveChangesAsync();  
        }

        // not Implemented
        public async Task DeleteMemberFromChat(Guid ChatId, string MemberId)
        {
            await _externalService.AuthService.DeleteUserAsync(MemberId);
            var chat = await _adminDataRepository.ChatRepository.Get(ChatId);
            if (chat == null)
                throw new NotFoundException("Chat Not found");  
        }

        public async Task DeleteMessage(Guid Id)
        {
            var chat = await _adminDataRepository.ChatMessageRepository.Get(Id);
            if (chat == null)
                throw new NotFoundException("ChatMessage Not found");

            await _adminDataRepository.ChatMessageRepository.Delete(chat);
            await _adminDataRepository.SaveChangesAsync();
        }

        public async Task<GetChatDto> GetChatInfo(Guid Id)
        {
            var chat = await _adminDataRepository.ChatRepository.Get(Id);
            if (chat == null)
                throw new NotFoundException("Chat Not found");
            var Dto = chat.ToGetChatDto();
            throw new NotImplementedException();

        }

        public Task<ICollection<GetChatMessagesDto>> GetChatMessagesDto(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateChat(UpdateChatDto Dto)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMessage(UpdateMessagesDto Dto)
        {
            throw new NotImplementedException();
        }

    }
}
