using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDUgram.BL.Exceptions.Common
{
    public class UserIsNotLoggedException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status404NotFound;
        public string ErrorMessage { get; }
        public UserIsNotLoggedException(string message) : base(message)
        {
            ErrorMessage = message;
        }
   
    }
    public class UserIsNotLoggedException<T> : UserIsNotLoggedException
    {
        public UserIsNotLoggedException() : base(typeof(T).Name + "user is not logged")
        {
        }
    }
}
