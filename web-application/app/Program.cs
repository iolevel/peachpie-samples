using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace peachserver
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("http://*:5004/")
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }

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
            //// sample usage of URL rewrite:
            //var options = new RewriteOptions()
            //    .AddRewrite(@"^rule/(\w+)", "index.php?word=$1", skipRemainingRules: true);

            //app.UseRewriter(options);

            // enable session:
            app.UseSession();

            // enable .php files from compiled assembly:
            app.UsePhp( new PhpRequestOptions() { ScriptAssembliesName = new[] { "website" } } );

            //
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}
