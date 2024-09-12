using Domain.IRepositories.DataRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories.DataRepository
{
    public interface IAdminDataRepository
    {
        IPostRepository PostRepository { get; }
        ICommentRepository CommentRepository { get; }
        IChatRepository ChatRepository { get; }
        IChatMessageRepository ChatMessageRepository { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
