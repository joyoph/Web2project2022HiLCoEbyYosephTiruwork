using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using pmstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace pmstore.Data.BaseRepository
{
    public class EntityBaseRepo<B> : IEntityBaseRepo<B> where B : class, IEntityBase, new()
    {
        private readonly AppDbContext _context;
        public EntityBaseRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(B entity)
        {
            await _context.Set<B>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task deleteAsync(int id)
        {
            var entity = await _context.Set<B>().FirstOrDefaultAsync(n => n.Id == id);
            EntityEntry entityEntry = _context.Entry<B>(entity);
            entityEntry.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<B>> GetAllAsync()
            {
            var result = await _context.Set<B>().ToListAsync();
            return result;
        }

        public async Task<IEnumerable<B>> GetAllAsync(params Expression<Func<B, object>>[] includeProperties)
        {
            IQueryable<B> query = _context.Set<B>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync();
        }

        public async Task<B> GetByIdAsync(int id)
        {
            var result = await _context.Set<B>().FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public async Task updateAsync(int id, B entity)
        {
            EntityEntry entityEntry = _context.Entry<B>(entity);
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
