using Mmu.MicroServiceTest.Common.DataAccess.Models;

namespace Mmu.MicroServiceTest.Common.DataAccess.Services.Handlers
{
    public interface IMongoDbSettingsProvider
    {
        MongoDbSettings GetSettings();
    }
}