using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class AlreadyExistException:Exception
    {
        public AlreadyExistException(string entityName) :
   base($"this {entityName} already exist")
        { }

        public AlreadyExistException(string entityName, string messege) :
            base($"this {entityName} already exist, and the Identiy Messege are {messege}")
        {

        }
    }
}
