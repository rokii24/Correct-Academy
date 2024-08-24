using Contract.AuthDtos;
using Domain.IRepositories.DataRepository;
using Domain.IRepositories.ExternalRepositories;
using Service.Abstraction.IExternalServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ExternalServices
{
    public class AuthService : IAuthService
    {
        private readonly IExternalRepository _repository;
        private readonly IAdminDataRepository _dataRepository;

        public AuthService(IExternalRepository repository, IAdminDataRepository dataRepository)
        {
            _repository = repository;
            _dataRepository = dataRepository;
        }
        public async Task<(string, string, string)> AuthenticationWithGoogle(GoogleAuthDto googleAuth)
        {
            if (googleAuth.IdToken is null || googleAuth.Provider is null)
                throw new Exception("Google");
            var userToken = await _repository.AuthRepository.LoginWithGoogle(googleAuth.IdToken
                , googleAuth.Provider);

            return userToken!;
        }
    }
}
