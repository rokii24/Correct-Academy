using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.DataEntities;
using Domain.IRepositories.DataRepositories;
 
namespace Persistence.Reposetories.DAtaReposatoiry
{
    public class CoomentRepository : ICommentRepository
    {
        public Task Add(Comment entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Comment entity)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Comment>> FilterBy(Func<Comment, bool> filter)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Comment>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(Comment entity)
        {
            throw new NotImplementedException();
        }
    }
}
