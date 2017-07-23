using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mmu.MicroServiceTest.Common.Settings.Models;

namespace Mmu.MicroServiceTest.Infrastructure.Initialization
{
    public static class ServiceInitialization
    {
        public static IServiceProvider InitializeServices(IConfigurationRoot configRoot, IServiceCollection services)
        {
            AddCors(services);
            AddConfigurationSettings(configRoot, services);
            var serviceProvider = IocInitialization.InitializeIoc(services);

            return serviceProvider;
        }

        private static void AddConfigurationSettings(IConfigurationRoot configRoot, IServiceCollection services)
        {
            services.Configure<AppSettings>(configRoot.GetSection(AppSettings.SECTION_NAME));
            services.AddSingleton(configRoot);
        }

        private static void AddCors(IServiceCollection services)
        {
            services.AddCors(
                options =>
                {
                    options.AddPolicy("All", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
                });
        }
    }
}