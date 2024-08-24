﻿using Domain.IRepositories.DataRepository;
using Domain.IRepositories.ExternalRepositories;
using Service.Abstraction.IExternalServices;

namespace Service.ExternalServices
{
    public class ExternalService : IExternalService
    {
        private readonly IAuthService _authService;

        public ExternalService(IExternalRepository repository, IAdminDataRepository dataRepository)
        {
            _authService=new AuthService(repository, dataRepository);
        }

        public IAuthService AuthService => _authService;
    }
}
