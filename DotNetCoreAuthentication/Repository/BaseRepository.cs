using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreAuthentication.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DotNetCoreAuthenticationContext _context;

        public BaseRepository(DotNetCoreAuthenticationContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public TEntity Get(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return _context.Set<TEntity>().Where(item => !item.IsDeleted).AsQueryable();
        }

        public List<TEntity> Find(Func<TEntity, bool> filter)
        {
            return _context.Set<TEntity>().Where(filter).Where(item => !item.IsDeleted).ToList();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().Where(item => !item.IsDeleted).AsNoTracking();
        }

        public async Task Create(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }

        public async Task Delete(int? id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public void Remove(int id)
        {
            if (id == default) throw new ArgumentNullException(nameof(id));

            var entity = Get(id);
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(string uId)
        {
            return await _context.Set<TEntity>().Where(item => !item.IsDeleted && item.UserId == uId).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().Where(expression).Where(item => !item.IsDeleted).ToListAsync();
        }

        public async Task<TEntity> GetAsync(int? id)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(item => !item.IsDeleted && item.Id == id);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var entity = await GetAsync(id);
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}