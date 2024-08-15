using Domain.Entities.AuthenticationEntities;
using Domain.Entities.DataEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class CorrectUser : IdentityUser, IUser
    {
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public string? OTP { get; set; }
        public string? UserImage { get; set; }
        public string? Bio { get; set; }
        public DateTime? OTPValidTo { get; set; }
        public DateTime RegistrationTime { get; set; }
    }
}
