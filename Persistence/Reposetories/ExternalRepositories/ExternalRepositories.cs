using Domain.IRepositories.ExternalRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Persistence.Context;
using Persistence.ExternalConfigurations;
using Persistence.Reposetories.ExternalRepository;

namespace Persistence.Reposetories.ExternalRepositories
{
    public class ExternalRepositories : IExternalRepository
    {
        private IAuthRepository _authRepository = null!;
        private readonly IConfiguration _configuration;
        private readonly UserManager<CorrectUser> _userManager;
        private readonly JWTConfiguration _jwt;

        public ExternalRepositories(IConfiguration configuration, UserManager<CorrectUser> userManager, JWTConfiguration jwt)
        {
            //_authRepository=authRepository;
            _configuration = configuration;
            _userManager = userManager;
            _jwt = jwt;
        }

        public IEmailRepository EmailRepository => throw new NotImplementedException();

        public IAuthRepository AuthRepository
        {
            get
            {
                if (_authRepository == null)
                {
                    JWTConfiguration jWT = new JWTConfiguration();
                    _configuration.GetRequiredSection("Jwt").Bind(jWT);
                    GoogleConfiguration google = new GoogleConfiguration();
                    _configuration.GetRequiredSection("Google").Bind(google);

                    _authRepository = new AuthRepository(
                        userManager: _userManager,
                        googleConfiguration: google,
                        jwt: jWT);
                }

                return _authRepository;
            }
        }
    }

}
