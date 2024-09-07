
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstraction.IDataServices
{
    public interface IAdminDataService
    {
        IChatService ChatService { get; }
        IPostService PostService { get; }
        
    }
}
