using BDugram.Core.Entities;
using BDugram.Core.Repositories;
using BDUgram.DAL.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDUgram.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        readonly HttpContext _httpContext;
       readonly BdugramDbContext _context;
        public UserRepository(BdugramDbContext context ,IHttpContextAccessor http) : base(context ,http)
        {
            _context = context;
            _httpContext = http.HttpContext;
        }
        public async Task<User?> GetUserByUserNameAsync(string username)
        {
            return await _context.Users.Where(x => x.UserName == username).FirstOrDefaultAsync();
        }

        


    }
}
