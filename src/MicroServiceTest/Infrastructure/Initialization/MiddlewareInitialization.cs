using Microsoft.AspNetCore.Builder;
using Mmu.MicroServiceTest.Infrastructure.Middlewares;

namespace Mmu.MicroServiceTest.Infrastructure.Initialization
{
    public static class MiddlewareInitialization
    {
        internal static void ConfigureMiddlewares(IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}