using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.AuthDtos
{
    public class GoogleAuthDto
    {
        public string? Provider { get; set; }
        public string? IdToken { get; set; }
    }
}
