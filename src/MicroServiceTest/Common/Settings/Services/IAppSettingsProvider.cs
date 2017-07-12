using Mmu.MicroServiceTest.Common.Settings.Models;

namespace Mmu.MicroServiceTest.Common.Settings.Services
{
    public interface IAppSettingsProvider
    {
        AppSettings GetAppSettings();
    }
}