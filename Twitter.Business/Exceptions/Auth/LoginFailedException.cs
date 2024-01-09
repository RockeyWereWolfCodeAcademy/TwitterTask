using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Business.Exceptions.Auth
{
    public class LoginFailedException : Exception
    {
        public LoginFailedException() : base() { }
        public LoginFailedException(string message) : base(message) { }
    }
}
