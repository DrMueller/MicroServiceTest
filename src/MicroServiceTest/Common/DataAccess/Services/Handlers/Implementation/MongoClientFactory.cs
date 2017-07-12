using System.Collections.Generic;
using System.Security.Authentication;
using Mmu.MicroServiceTest.Common.DataAccess.Models;
using MongoDB.Driver;

namespace Mmu.MicroServiceTest.Common.DataAccess.Services.Handlers.Implementation
{
    public class MongoClientFactory : IMongoClientFactory
    {
        private readonly MongoDbSettings _mongoDbSettings;

        public MongoClientFactory(IMongoDbSettingsProvider mongoDbSettingsProvider)
        {
            _mongoDbSettings = mongoDbSettingsProvider.GetSettings();
        }

        public MongoClient Create()
        {
            var clientSettings = new MongoClientSettings
            {
                Server = new MongoServerAddress(_mongoDbSettings.Host, _mongoDbSettings.Port),
                UseSsl = _mongoDbSettings.UseSsl
            };

            if (clientSettings.UseSsl)
            {
                clientSettings.SslSettings = new SslSettings
                {
                    EnabledSslProtocols = SslProtocols.Tls12
                };
            }

            var identity = new MongoInternalIdentity(_mongoDbSettings.DatabaseName, _mongoDbSettings.UserName);
            var evidence = new PasswordEvidence(_mongoDbSettings.Password);
            clientSettings.Credentials = new List<MongoCredential>
            {
                new MongoCredential("SCRAM-SHA-1", identity, evidence)
            };

            var mongoClient = new MongoClient(clientSettings);
            return mongoClient;
        }
    }
}