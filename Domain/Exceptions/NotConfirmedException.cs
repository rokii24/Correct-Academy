using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class NotConfirmedException:Exception
    {
        public NotConfirmedException(string email) :
   base($"this {email} not confirmed yet")
        { }

        public NotConfirmedException(string email, string messege) :
            base($"this {email} not confirmed yet, and the Identiy Messege are {messege}")
        {

        }
    }
}
