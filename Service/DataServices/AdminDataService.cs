using Domain.IRepositories.DataRepository;
using Service.Abstraction.IDataServices;
using Service.Abstraction.IExternalServices;


namespace Service.DataServices
{
    public class AdminDataService : IAdminDataService
    {
        private readonly IChatService _chatService;
        private readonly IPostService _postServices;

        public AdminDataService(IAdminDataRepository adminDataRepository, IExternalService externalRepositorie)
        {
            _chatService=new ChatService(adminDataRepository);
            _postServices=new PostService(adminDataRepository, externalRepositorie);
        }

        public IChatService ChatService => throw new NotImplementedException();

        public IPostService PostService => throw new NotImplementedException();
    }
}
