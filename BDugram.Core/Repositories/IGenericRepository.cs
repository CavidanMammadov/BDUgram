using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BDugram.Core.Repositories
{
    public interface  IGenericRepository<T> where T :BaseEntity ,new()
    {
        IQueryable<T> GetAll();
        Task<T>  GetByIdAsync(int id);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> expression);
        Task<bool> IsExistAsync(int id);
        Task AddAsync  (T entity);
        void Remove (T entity);
        Task<bool> RemoveAsync(int id);
        Task<int> SaveAsync();



       
    }
}
