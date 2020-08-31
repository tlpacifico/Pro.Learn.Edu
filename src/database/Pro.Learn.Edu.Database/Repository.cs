using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Pro.Learn.Edu.Database
{
    public class Repository<T> : IRepository<T> where T : class, IHaveId<long>
    {
        private readonly DatabaseContext _ctx;
        private readonly DbSet<T> _set;

        public Repository(DatabaseContext ctx)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
            _set = ctx.Set<T>();
        }

        public IEnumerator<T> GetEnumerator() => ((IQueryable<T>)_set).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public Type ElementType => ((IQueryable<T>)_set).ElementType;

        public Expression Expression => ((IQueryable<T>)_set).Expression;

        public IQueryProvider Provider => ((IQueryable<T>)_set).Provider;

        public Task<T> GetByIdAsync(long id, CancellationToken ct) => _set.SingleOrDefaultAsync(e => e.Id == id, ct);

        public async Task<T> AddAsync(T entity, CancellationToken ct)
        {
            var entry = await _set.AddAsync(entity, ct).ConfigureAwait(false);
            await _ctx.SaveChangesAsync(ct).ConfigureAwait(false);
            return entry.Entity;
        }

        public async Task<T[]> AddAsync(CancellationToken ct, params T[] entities)
        {
            await _set.AddRangeAsync(entities, ct).ConfigureAwait(false);
            await _ctx.SaveChangesAsync(ct).ConfigureAwait(false);
            return entities;
        }

        public async Task<IEnumerable<T>> AddAsync(IEnumerable<T> entities, CancellationToken ct) =>
            await AddAsync(ct, entities as T[] ?? entities.ToArray()).ConfigureAwait(false);

        public async Task<T> UpdateAsync(T entity, CancellationToken ct)
        {
            var entry = _set.Update(entity);
            await _ctx.SaveChangesAsync(ct).ConfigureAwait(false);
            return entry.Entity;
        }

        public async Task<T[]> UpdateAsync(CancellationToken ct, params T[] entities)
        {
            _set.UpdateRange(entities);
            await _ctx.SaveChangesAsync(ct).ConfigureAwait(false);
            return entities;
        }

        public async Task<IEnumerable<T>> UpdateAsync(IEnumerable<T> entities, CancellationToken ct) =>
            await UpdateAsync(ct, entities as T[] ?? entities.ToArray()).ConfigureAwait(false);

        public async Task<T> DeleteAsync(T entity, CancellationToken ct)
        {
            var entry = _set.Remove(entity);
            await _ctx.SaveChangesAsync(ct).ConfigureAwait(false);
            return entry.Entity;
        }

        public async Task<T[]> DeleteAsync(CancellationToken ct, params T[] entities)
        {
            _set.RemoveRange(entities);
            await _ctx.SaveChangesAsync(ct).ConfigureAwait(false);
            return entities;
        }

        public async Task<IEnumerable<T>> DeleteAsync(IEnumerable<T> entities, CancellationToken ct) =>
            await DeleteAsync(ct, entities as T[] ?? entities.ToArray()).ConfigureAwait(false);

        public Task<bool> ExistsByIdAsync(long id, CancellationToken ct) => _set.AnyAsync(e => e.Id == id, ct);
    }
}
