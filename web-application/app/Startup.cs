using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Peachpie.Web;

namespace peachserver
{
    class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Adds a default in-memory implementation of IDistributedCache.
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseSession();

            app.UsePhp( new PhpRequestOptions() { ScriptAssembliesName = new[] { "website" } } );
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}
