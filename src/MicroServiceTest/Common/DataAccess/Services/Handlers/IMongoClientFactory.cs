using MongoDB.Driver;

namespace Mmu.MicroServiceTest.Common.DataAccess.Services.Handlers
{
    public interface IMongoClientFactory
    {
        MongoClient Create();
    }
}