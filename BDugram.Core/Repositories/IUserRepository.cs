using BDugram.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDugram.Core.Repositories
{
    public  interface IUserRepository :IGenericRepository<User>
    {
       
        Task<User?> GetUserByUserNameAsync(string username); 
    }
}
