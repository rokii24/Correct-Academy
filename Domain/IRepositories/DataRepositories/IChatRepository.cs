using Domain.Entities.DataEntities;
using Domain.IReposetories.DataRepository;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories.DataRepositories
{
    public interface IChatRepository : IBaseRepository<Chat>
    {
    }
}
