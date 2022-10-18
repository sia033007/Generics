using Generics.Data;
using Microsoft.EntityFrameworkCore;

namespace Generics.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDb _appDb;

        public Repository(AppDb appDb)
        {
            _appDb = appDb;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _appDb.Set<T>().AddAsync(entity);
            await _appDb.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _appDb.Set<T>().FindAsync(id);
            if(entity == null)
                return;
            _appDb.Set<T>().Remove(entity);
            await _appDb.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _appDb.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            var entity = await _appDb.Set<T>().FindAsync(id);
            if (entity == null)
                return null;
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _appDb.Entry(entity).State = EntityState.Modified;
            await _appDb.SaveChangesAsync();
            return entity;
        }
    }
}
