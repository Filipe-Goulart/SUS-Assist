using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FilaSUS.WebAPI.Data;
using FilaSUS.WebAPI.Extensions;
using FilaSUS.WebAPI.POCO;
using Microsoft.EntityFrameworkCore;

namespace FilaSUS.WebAPI.Repositories
{
    public class BaseRepository<T> where T : Registry
    {
        private readonly SUSContext _db;

        public BaseRepository(SUSContext db)
        {
            _db = db;
        }

        public IQueryable<T> GetWithFilter(Expression<Func<T, bool>> filter)
        {
            return _db.Set<T>().AsNoTracking().Where(filter);
        }

        public T Insert(T entity)
        {
            entity.SetReferencesNull();
            _db.Set<T>().Add(entity);
            _db.SaveChanges();
            return entity;
        }
        
        public async Task<T> InsertAsync(T entity)
        {
            entity.SetReferencesNull();
            await _db.Set<T>().AddAsync(entity).ConfigureAwait(false);
            await _db.SaveChangesAsync().ConfigureAwait(false);
            return entity;
        }

        public T Update(T entity)
        {
            entity.SetReferencesNull();
            _db.Set<T>().Update(entity);
            _db.SaveChanges();
            return entity;
        }
        
        public async Task<T> UpdateAsync(T entity)
        {
            entity.SetReferencesNull();
            _db.Set<T>().Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}