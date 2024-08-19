using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories.ExternalRepositories
{
    public interface IAuthRepository
    {
        Task<(string, string, string)> LoginWithGoogle(string token, string provider);
    }
}
