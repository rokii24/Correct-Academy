using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.AuthDtos
{
    public class Regestreation
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
    }

    public record ChangePasswordDto(string UserId, string OldPassword, string NewPassword)
    {
    }
    public record ForgetPasswordDto(string Token, string OTP, string UserId, string NewPassword)
    {
    }
}

