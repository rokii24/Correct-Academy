using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.AuthDtos
{
    public class OtpTokenDto
    {
        public string Otp { get; set; } = null!;
        public string Token { get; set; } = null!;
    }
}
