using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.AuthDtos
{
    public class AuthDto
    {
        public string UserID { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Token { get; set; } = null!;
    }
}
