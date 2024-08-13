using Domain.Entities.AuthenticationEntities;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class CorrectStudent : IdentityUser, IUser
    {
        public string Id { get; set; }
        public string? Email { get; set; }
        public string Name { get; set; }
        public int age { get; set; }
        public Gender Gender { get; set; }
        public string? UserImage { get; set; }
        public string? Bio { get; set; }
        public string? OTP { get; set; }
        public DateTime? OTPValidTo { get; set; }
        public DateTime RegistrationTime { get; set; }
    }
}
