using Domain.Entities.DataEntities;
using Domain.IRepositories.DataRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Reposetories.DAtaReposatoiry
{
    public class CoomentRepository : ICommentRepository
    {
        public readonly CorrectAcademyContext _context;

        public CoomentRepository(CorrectAcademyContext context)
        {
            _context=context;
        }
        public async Task Add(Comment entity)
        {
            await _context.Comments.AddAsync(entity);
        }

        public async Task Delete(Comment entity)
        {
            _context.Comments.Remove(entity);
        }

        public Task<ICollection<Comment>> FilterBy(Func<Comment, bool> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<Comment> Get(Guid id)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
            if (comment == null)
                throw new Exception("comment Not Found");
            return comment;
        }

        public async Task<ICollection<Comment>> GetAll()
        {
            var comments = await _context.Comments.ToListAsync();
            if (comments == null)
                throw new Exception("comment Not Found");
            return comments;
        }

        public async Task Update(Comment entity)
        {
            _context.Comments.Update(entity);
        }
    }
}
