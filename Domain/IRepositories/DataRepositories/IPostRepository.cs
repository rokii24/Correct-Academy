using Domain.Entities.DataEntities;
using Domain.IReposetories.DataRepository;


namespace Domain.IRepositories.DataRepositories
{
    public interface IPostRepository : IBaseRepository<Post>
    {

        Task<ICollection<Post>> GetAllByUser(string Id);

    }
}
