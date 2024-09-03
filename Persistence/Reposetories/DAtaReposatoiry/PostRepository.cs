using Domain.Entities.DataEntities;
using Domain.IRepositories.DataRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Reposetories.DAtaReposatoiry
{
    public class PostRepository : IPostRepository
    {
        public Task Add(Post entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Post entity)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Post>> FilterBy(Func<Post, bool> filter)
        {
            throw new NotImplementedException();
        }

        public Task<Post> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Post>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(Post entity)
        {
            throw new NotImplementedException();
        }
    }
}
