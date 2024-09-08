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
    public class PostRepository : IPostRepository
    {
        public readonly CorrectAcademyContext _context;

        public PostRepository(CorrectAcademyContext context)
        {
            _context=context;
        }

        public async Task Add(Post entity)
        {
            await _context.Posts.AddAsync(entity);
        }

        public async Task Delete(Post entity)
        {
             _context.Posts.Remove(entity);

        }

        public Task<ICollection<Post>> FilterBy(Func<Post, bool> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<Post> Get(Guid id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
            if (post == null)
                throw new Exception("Post Not Found");
            return post;    
        }

        public async Task<ICollection<Post>> GetAll()
        {
            var posts = await _context.Posts.ToListAsync();
            if (posts == null)
                throw new Exception("Post Not Found");
            return posts;
        }

        public async Task<ICollection<Post>> GetAllByUser(string Id)
        {
            var posts = await _context.Posts.Where(p=>p.UserId == Id).ToListAsync();
            if (posts == null)
                throw new Exception("Post Not Found");
            return posts;
        }

        public async Task Update(Post entity)
        {
             _context.Posts.Update(entity);
        }
    }
}
