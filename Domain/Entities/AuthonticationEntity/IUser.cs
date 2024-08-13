using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.AuthenticationEntities
{
    public interface IUser 
    {
        public string Id { get; set; }
        public string? Email { get; set; }
        public string Name { get; set; }
        public string? OTP { get; set; }
        public string? UserImage { get; set; }
        public string? Bio { get; set; }
        public DateTime? OTPValidTo { get; set; }
        DateTime RegistrationTime { get; set; }
    }
}
