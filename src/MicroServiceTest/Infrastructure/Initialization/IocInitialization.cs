using System;
using Microsoft.Extensions.DependencyInjection;
using Mmu.MicroServiceTest.Common.DataAccess.Services;
using Mmu.MicroServiceTest.Common.DataAccess.Services.Handlers;
using StructureMap;

namespace Mmu.MicroServiceTest.Infrastructure.Initialization
{
    public static class IocInitialization
    {
        internal static IServiceProvider InitializeIoc(IServiceCollection services)
        {
            var container = new Container();

            container.Configure(
                config =>
                {
                    config.Scan(
                        _ =>
                        {
                            _.AssembliesFromApplicationBaseDirectory();
                            _.WithDefaultConventions();
                            _.AddAllTypesOf(typeof(IRepository<>));
                            _.AddAllTypesOf(typeof(IMongoDbFilterDefinitionFactory<>));
                        });
                    config.Populate(services);
                });

            var result = container.GetInstance<IServiceProvider>();
            return result;
        }
    }
}