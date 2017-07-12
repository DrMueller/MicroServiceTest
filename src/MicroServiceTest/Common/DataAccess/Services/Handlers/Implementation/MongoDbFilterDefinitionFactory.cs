using System;
using System.Linq.Expressions;
using Mmu.MicroServiceTest.Common.Models;
using MongoDB.Driver;

namespace Mmu.MicroServiceTest.Common.DataAccess.Services.Handlers.Implementation
{
    public class MongoDbFilterDefinitionFactory<TEntity> : IMongoDbFilterDefinitionFactory<TEntity>
        where TEntity : EntityBase
    {
        public FilterDefinition<TEntity> CreateFilterDefinition(Expression<Func<TEntity, bool>> predicate)
        {
            var entityTypeFilter = CreateEntityTypeFilterDefinition();
            var predicateFilter = new ExpressionFilterDefinition<TEntity>(predicate);
            return new FilterDefinitionBuilder<TEntity>().And(entityTypeFilter, predicateFilter);
        }

        private static FilterDefinition<TEntity> CreateEntityTypeFilterDefinition()
        {
            var entityTypeFilter = new ExpressionFilterDefinition<TEntity>(x => x.EntityTypeName == typeof(TEntity).FullName);
            return entityTypeFilter;
        }
    }
}