using Contract.AddDtos;
using Contract.HubDtos;
using Domain.Entities.DataEntities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Service.Extentions
{
    public static class ChatExtention
    {
        public static Chat ToChat(this AddChatDto Dto)
        {
            return new Chat
            {
                ChatImage = Dto.ChatImage,
                Description = Dto.Description,
                Title = Dto.Title,
            };
        }
        public static ChatMessage ToChatMessage(this MessageDto Dto,string type)
        {
            MessageType messageType = MessageType.Text;
            Enum.TryParse<MessageType>(type, true, out messageType);
            return new ChatMessage
            {
                Value=Dto.Message,
                Type= messageType,
               // ChatId=
               UserId= Dto.UserId,
               AddingDate = DateTime.Now,             
            };
        }
    }
}
