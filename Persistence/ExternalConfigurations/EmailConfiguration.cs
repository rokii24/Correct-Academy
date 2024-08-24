using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.ExternalConfigurations
{
  public   class EmailConfiguration
    {
        public string Server { get; set; } = null!;
        public int Port { get; set; } = -1;
        public string Key { get; set; } = null!;
        public string SenderEmail { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmationPath { get; set; } = null!;
        public string RestPasswordPath { get; set; } = null!;
        public string InvitationPath { get; set; } = null!;
    }
}
