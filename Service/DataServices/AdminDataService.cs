using Domain.IRepositories.DataRepository;
using Service.Abstraction.IDataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DataServices
{
    public class AdminDataService : IAdminDataService
    {
        private readonly IChatService _chatService;
        private readonly IPostService _postServices;

        public AdminDataService(IAdminDataRepository adminDataRepository)
        {
            _chatService=new ChatService();
            _postServices=new PostService(adminDataRepository);
        }

        public IChatService ChatService => _chatService;

        public IPostService PostService => _postServices;
    }
}
