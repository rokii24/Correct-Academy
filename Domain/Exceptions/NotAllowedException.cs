using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class NotAllowedException :Exception
    {
        public NotAllowedException(string mess) :
      base(mess)
        { }
        public NotAllowedException(string entityName, string messege) :
        base($"this {entityName} already exist, and the Identiy Messege are {messege}")
        { }
    }
}
