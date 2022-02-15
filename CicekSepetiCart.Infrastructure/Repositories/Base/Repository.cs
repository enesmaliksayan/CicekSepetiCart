using CicekSepetiCart.Domain.Repositories.Base;
using CicekSepetiCart.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepetiCart.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T:class
    {
        protected readonly CartDbContext _cartDbContext;
        public Repository(CartDbContext cartDbContext)
        {
            _cartDbContext = cartDbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _cartDbContext.Set<T>().AddAsync(entity);
            await _cartDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _cartDbContext.Set<T>().Remove(entity);
            await _cartDbContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _cartDbContext.Set<T>().ToListAsync();
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _cartDbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _cartDbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate)
        {
            return await _cartDbContext.Set<T>().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _cartDbContext.Set<T>().Update(entity);
            await _cartDbContext.SaveChangesAsync();
        }
    }
}
