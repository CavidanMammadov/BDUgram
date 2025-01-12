using BDugram.Core.Entities;
using BDugram.Core.Entities.Common;
using BDugram.Core.Repositories;
using BDUgram.DAL.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BDUgram.DAL.Repositories
{
    public class GenericRepository<T>(BdugramDbContext _context , IHttpContextAccessor _http) : IGenericRepository<T> where T : BaseEntity, new()
    {
        protected DbSet<T> Table => _context.Set<T>(); 
        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public IQueryable<T> GetAll( params string[] includes)
        {
            var query = Table.AsQueryable();
            foreach (var incld in includes)
            query = query.Include(incld);
            
            return query;
        }
        

        public async  Task<T?> GetByIdAsync(int id) 
            => await Table.FindAsync();

        public Task<User?> GetCurrentUserAsync()
        {
            string userName = GetCurrentUserName();
            if (string.IsNullOrWhiteSpace(userName))
            return null;
           return _context.Users.Where(x => x.UserName == userName).FirstOrDefaultAsync();  
        }

        public string GetCurrentUserName()
        {
           return _http.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression)
       => Table.Where(expression).AsQueryable();

        public async Task<bool> IsExistAsync(int id)
       => await  Table.AnyAsync(t => t.Id == id);

        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> expression)
            => await Table.AnyAsync(expression);
        

        public void Remove(T entity)
        {
            Table.Remove(entity);
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var result = await Table.Where(x=> x.Id == id).ExecuteDeleteAsync();
            return result > 0;
        }

        public async Task<int> SaveAsync()
        => await _context.SaveChangesAsync();
    }
}
