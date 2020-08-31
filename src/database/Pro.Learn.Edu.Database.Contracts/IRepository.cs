using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pro.Learn.Edu.Database
{
    public interface IRepository<T> : IQueryable<T>
       where T : IHaveId<long>
    {
        Task<T> GetByIdAsync(long id, CancellationToken ct);

        Task<T> AddAsync(T entity, CancellationToken ct);

        Task<T[]> AddAsync(CancellationToken ct, params T[] entities);

        Task<IEnumerable<T>> AddAsync(IEnumerable<T> entities, CancellationToken ct);

        Task<T> UpdateAsync(T entity, CancellationToken ct);

        Task<T[]> UpdateAsync(CancellationToken ct, params T[] entities);

        Task<IEnumerable<T>> UpdateAsync(IEnumerable<T> entities, CancellationToken ct);

        Task<T> DeleteAsync(T entity, CancellationToken ct);

        Task<T[]> DeleteAsync(CancellationToken ct, params T[] entities);

        Task<IEnumerable<T>> DeleteAsync(IEnumerable<T> entities, CancellationToken ct);

        Task<bool> ExistsByIdAsync(long id, CancellationToken ct);
    }
}
