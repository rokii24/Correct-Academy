using Domain.Entities.DataEntities;
using Domain.IRepositories.DataRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;


namespace Persistence.Reposetories.DataReposatoiry
{
    public class ChatMessageRepository : IChatMessageRepository
    {
        public readonly CorrectAcademyContext _context;

        public ChatMessageRepository(CorrectAcademyContext context)
        {
            _context=context;
        }
        public async Task Add(ChatMessage entity)
        {
            await _context.ChatMessages.AddAsync(entity);
        }

        public async Task Delete(ChatMessage entity)
        {
            _context.ChatMessages.Remove(entity);
        }

        public Task<ICollection<ChatMessage>> FilterBy(Func<ChatMessage, bool> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<ChatMessage> Get(Guid id)
        {
            var ChatMessage = await _context.ChatMessages.FirstOrDefaultAsync(c => c.Id == id);
            if (ChatMessage == null)
                throw new Exception("ChatMessage Not Found");
            return ChatMessage;
        }

        public async Task<ICollection<ChatMessage>> GetAll()
        {
            var ChatMessage = await _context.ChatMessages.ToListAsync();
            if (ChatMessage == null)
                throw new Exception("ChatMessage Not Found");
            return ChatMessage;
        }

        public async Task Update(ChatMessage entity)
        {
            _context.ChatMessages.Update(entity);
        }
    }
}
