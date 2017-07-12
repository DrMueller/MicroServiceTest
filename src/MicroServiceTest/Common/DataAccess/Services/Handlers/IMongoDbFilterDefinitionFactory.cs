using System;
using System.Linq.Expressions;
using Mmu.MicroServiceTest.Common.Models;
using MongoDB.Driver;

namespace Mmu.MicroServiceTest.Common.DataAccess.Services.Handlers
{
    public interface IMongoDbFilterDefinitionFactory<TEntity>
        where TEntity : EntityBase
    {
        FilterDefinition<TEntity> CreateFilterDefinition(Expression<Func<TEntity, bool>> predicate);
    }
}