using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Mmu.MicroServiceTest.Common.Models;

namespace Mmu.MicroServiceTest.Common.DataAccess.Services
{
    public interface IRepository<TEntity>
        where TEntity : EntityBase, new()
    {
        Task DeleteAsync(string id);

        Task<IReadOnlyCollection<TEntity>> LoadAllAsync();

        Task<IReadOnlyCollection<TEntity>> LoadAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> LoadByIdAsync(string id);

        Task<TEntity> SaveAsync(TEntity entity);
    }
}