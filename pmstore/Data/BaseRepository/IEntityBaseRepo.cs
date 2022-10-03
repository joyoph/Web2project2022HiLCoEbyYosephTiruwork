    using pmstore.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace pmstore.Data.BaseRepository
{
    public interface IEntityBaseRepo<B> where B : class, IEntityBase, new()
    {
        Task<IEnumerable<B>> GetAllAsync();
        Task<IEnumerable<B>> GetAllAsync(params Expression<Func<B, object>>[] includeProperties);
        Task<B> GetByIdAsync(int id);
        Task AddAsync(B Artist);

        Task updateAsync(int id, B entity);

        Task deleteAsync(int id);
    }
}
