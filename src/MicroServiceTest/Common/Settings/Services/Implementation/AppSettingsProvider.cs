using Microsoft.Extensions.Options;
using Mmu.MicroServiceTest.Common.Settings.Models;

namespace Mmu.MicroServiceTest.Common.Settings.Services.Implementation
{
    public class AppSettingsProvider : IAppSettingsProvider
    {
        private readonly IOptions<AppSettings> _appSettingsOptions;

        public AppSettingsProvider(IOptions<AppSettings> appSettingsOptions)
        {
            _appSettingsOptions = appSettingsOptions;
        }

        public AppSettings GetAppSettings()
        {
            return _appSettingsOptions.Value;
        }
    }
}