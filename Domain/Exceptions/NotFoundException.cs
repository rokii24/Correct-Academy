using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class NotFoundException:Exception
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string entityName) :
            base($"this {entityName} not found")
        { }
        public NotFoundException(string baseEntity, string childEntity) :
                    base($"this {baseEntity} doesn't have any {childEntity}")
        { }
        public NotFoundException(string entityName, string messege, bool any = true) :
            base($"this {entityName} already exist, and the Identiy Messege are {messege}")
        {

        }
    }
}
