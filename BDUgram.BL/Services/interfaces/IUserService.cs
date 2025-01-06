using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDUgram.BL.Services.interfaces
{
    public interface IUserService
    {
        Task<string> CreateAsync();
        Task DeleteAsync(string username);
    }
}
