using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDUgram.BL.Exceptions.AuthExceptions
{
    public class CodeIsInvalidException : Exception, IBaseException
    {
        public int StatusCode = StatusCodes.Status400BadRequest;

        public string ErrorMessage { get; }

        int IBaseException.StatusCode => throw new NotImplementedException();

        public CodeIsInvalidException()
        {
            ErrorMessage = "Daxil etdiyiniz kod yalnisdir";
        }
        public CodeIsInvalidException(string message)
        {
            ErrorMessage = message; 
        }
    }
}
