using BDugram.Core.Entities;
using BDugram.Core.Repositories;
using BDUgram.DAL.Context;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDUgram.DAL.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(BdugramDbContext _context, IHttpContextAccessor _http) : base(_context, _http)
        {
        }
    }
}
