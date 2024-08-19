using Domain.IRepositories.ExternalRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Persistence.Context;
using Persistence.ExternalConfigurations;
using Persistence.Reposetories.ExternalRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Persistence.Reposetories
{
    public class ExternalRepositories : IExternalRepository
    {
        private IAuthRepository _authRepository = null!;
        private readonly IConfiguration _configuration;
        private readonly UserManager<CorrectUser> _userManager;
        private readonly JWTConfiguration _jwt;
        public ExternalRepositories(IAuthRepository authRepository, IConfiguration configuration, UserManager<CorrectUser> userManager, JWTConfiguration jwt)
        {
            _authRepository=authRepository;
            _configuration=configuration;
            _userManager=userManager;
            _jwt=jwt;
        }

        public IEmailRepository EmailRepository => throw new NotImplementedException();

        public IAuthRepository AuthRepository
        {
            get
            {
                if (_authRepository == null)
                {
                   
                    GoogleConfiguration google = new GoogleConfiguration();
                    _configuration.GetRequiredSection("Google").Bind(google);

                    _authRepository = new AuthRepository(
                         googleConfiguration: google,_userManager,_jwt
                     );
                }

                return _authRepository;
            }
        }
    }
}
