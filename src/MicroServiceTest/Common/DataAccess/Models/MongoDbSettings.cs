namespace Mmu.MicroServiceTest.Common.DataAccess.Models
{
    public class MongoDbSettings
    {
        public string DatabaseName { get; set; }

        public string Host { get; set; }

        public string Password { get; set; }

        public int Port { get; set; }

        public string UserName { get; set; }

        public bool UseSsl { get; set; }
    }
}