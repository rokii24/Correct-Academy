using Contract.AuthDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstraction.IExternalServices
{
    public interface IAuthService
    {
        Task<(string, string, string)> AuthenticationWithGoogle(GoogleAuthDto googleAuth);
    }
}
