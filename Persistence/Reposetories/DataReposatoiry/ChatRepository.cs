using Domain.Entities.DataEntities;
using Domain.IRepositories.DataRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Reposetories.DataReposatoiry
{
    public class ChatRepository : IChatRepository
    {
        public readonly CorrectAcademyContext _context;

        public ChatRepository(CorrectAcademyContext context)
        {
            _context=context;
        }
        public async Task Add(Chat entity)
        {
            await _context.Chats.AddAsync(entity);
        }

        public async Task Delete(Chat entity)
        {
             _context.Chats.Remove(entity);
        }

        public Task<ICollection<Chat>> FilterBy(Func<Chat, bool> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<Chat> Get(Guid id)
        {
            var Chat = await _context.Chats.FirstOrDefaultAsync(c => c.Id == id);
            if (Chat == null)
                throw new Exception("Chat Not Found");
            return Chat;
        }

        public async Task<ICollection<Chat>> GetAll()
        {
            var Chats = await _context.Chats.ToListAsync();
            if (Chats == null)
                throw new Exception("Chats Not Found");
            return Chats;
        }

        public async Task Update(Chat entity)
        {
            _context.Chats.Update(entity);
        }
    }
}
