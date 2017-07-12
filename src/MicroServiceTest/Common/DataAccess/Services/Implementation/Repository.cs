using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Mmu.MicroServiceTest.Common.DataAccess.Services.Handlers;
using Mmu.MicroServiceTest.Common.Models;
using MongoDB.Driver;

namespace Mmu.MicroServiceTest.Common.DataAccess.Services.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : EntityBase, new()
    {
        private readonly IMongoDbFilterDefinitionFactory<TEntity> _filterFactory;
        private readonly IMongoDbAccess _mongoDbAccess;

        public Repository(IMongoDbAccess mongoDbAccess, IMongoDbFilterDefinitionFactory<TEntity> filterFactory)
        {
            _mongoDbAccess = mongoDbAccess;
            _filterFactory = filterFactory;
        }

        public Task DeleteAsync(string id)
        {
            var collection = _mongoDbAccess.GetDatabaseCollection<TEntity>();
            return collection.DeleteOneAsync(x => x.Id == id);
        }

        public Task<IReadOnlyCollection<TEntity>> LoadAllAsync()
        {
            var result = LoadAsync(x => true);
            return result;
        }

        public async Task<IReadOnlyCollection<TEntity>> LoadAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var collection = _mongoDbAccess.GetDatabaseCollection<TEntity>();
            var filter = _filterFactory.CreateFilterDefinition(predicate);
            var result = await collection.Find(filter).ToListAsync();
            return result;
        }

        public async Task<TEntity> LoadByIdAsync(string id)
        {
            var entries = await LoadAsync(x => x.Id == id);
            var result = entries.SingleOrDefault();
            return result;
        }

        public async Task<TEntity> SaveAsync(TEntity entity)
        {
            var collection = _mongoDbAccess.GetDatabaseCollection<TEntity>();
            if (string.IsNullOrWhiteSpace(entity.Id))
            {
                await collection.InsertOneAsync(entity);
                return entity;
            }

            var filter = _filterFactory.CreateFilterDefinition(x => x.Id == entity.Id);
            var updateOptions = new FindOneAndReplaceOptions<TEntity> { IsUpsert = false, ReturnDocument = ReturnDocument.After };
            var result = await collection.FindOneAndReplaceAsync(filter, entity, updateOptions);
            return result;
        }
    }
}