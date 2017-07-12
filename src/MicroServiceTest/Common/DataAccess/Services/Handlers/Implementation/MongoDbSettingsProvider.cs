using Mmu.MicroServiceTest.Common.DataAccess.Models;
using Mmu.MicroServiceTest.Common.Settings.Services;

namespace Mmu.MicroServiceTest.Common.DataAccess.Services.Handlers.Implementation
{
    public class MongoDbSettingsProvider : IMongoDbSettingsProvider
    {
        private readonly MongoDbSettings _mongoDbSettings;

        public MongoDbSettingsProvider(IAppSettingsProvider appSettingsProvider)
        {
            _mongoDbSettings = appSettingsProvider.GetAppSettings().MongoDbSettings;
        }

        public MongoDbSettings GetSettings()
        {
            return _mongoDbSettings;
        }
    }
}