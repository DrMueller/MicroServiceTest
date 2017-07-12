using Mmu.MicroServiceTest.Common.Models;
using MongoDB.Driver;

namespace Mmu.MicroServiceTest.Common.DataAccess.Services.Handlers
{
    public interface IMongoDbAccess
    {
        IMongoCollection<TEntity> GetDatabaseCollection<TEntity>()
            where TEntity : EntityBase;
    }
}