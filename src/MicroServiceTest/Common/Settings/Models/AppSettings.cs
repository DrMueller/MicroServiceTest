using Mmu.MicroServiceTest.Common.DataAccess.Models;

namespace Mmu.MicroServiceTest.Common.Settings.Models
{
    public class AppSettings
    {
        public const string SECTION_NAME = "AppSettings";

        public MongoDbSettings MongoDbSettings { get; set; }
    }
}