using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Business.Exceptions.Roles
{
    public class RoleAssignFailedException : Exception
    {
        public RoleAssignFailedException() : base() { }
        public RoleAssignFailedException(string message) : base(message) { }
    }
}
