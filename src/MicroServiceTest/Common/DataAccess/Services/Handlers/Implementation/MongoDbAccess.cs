using Mmu.MicroServiceTest.Common.DataAccess.Models;
using Mmu.MicroServiceTest.Common.Models;
using MongoDB.Driver;

namespace Mmu.MicroServiceTest.Common.DataAccess.Services.Handlers.Implementation
{
    public class MongoDbAccess : IMongoDbAccess
    {
        private readonly IMongoClientFactory _mongoClientFactory;
        private readonly MongoDbSettings _mongoDbSettings;

        public MongoDbAccess(IMongoClientFactory mongoClientFactory, IMongoDbSettingsProvider mongoDbSettingsProvider)
        {
            _mongoClientFactory = mongoClientFactory;
            _mongoDbSettings = mongoDbSettingsProvider.GetSettings();
        }

        public IMongoCollection<TEntity> GetDatabaseCollection<TEntity>()
            where TEntity : EntityBase
        {
            var collectionName = typeof(TEntity).Name;
            var db = GetDatabase();
            var result = db.GetCollection<TEntity>(collectionName);

            return result;
        }

        private IMongoDatabase GetDatabase()
        {
            var mongoClient = _mongoClientFactory.Create();
            var database = mongoClient.GetDatabase(_mongoDbSettings.DatabaseName);
            return database;
        }
    }
}
