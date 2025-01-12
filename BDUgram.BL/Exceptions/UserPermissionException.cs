using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDUgram.BL.Exceptions
{
    public class UserPermissionException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status403Forbidden

        public string ErrorMessage { get; }
        public UserPermissionException()
        {
            ErrorMessage = "Permission Denied";
        }
        public UserPermissionException( string message )
        {
            ErrorMessage = message; 
        }
    }
}
