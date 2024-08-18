using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstraction.IHubServices
{
    public partial interface IHubMethods
    {
        Task UserConnected(string userId);
        Task UserDisConnected(string userId);
    }
}
