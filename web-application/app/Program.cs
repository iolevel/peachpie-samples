using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace peachserver
{
    class Program
    {
        static void Main(string[] args)
        {
            WebHost
                .CreateDefaultBuilder<Startup>(args)
                .UseUrls("http://*:5004/")
                .Build()
                .Run();
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

            services.AddPhp(options =>
            {
                //
            });
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            //// sample usage of URL rewrite:
            //var options = new RewriteOptions()
            //    .AddRewrite(@"^rule/(\w+)", "index.php?word=$1", skipRemainingRules: true);

            //app.UseRewriter(options);

            // enable session:
            app.UseSession();

            // enable .php files from compiled assembly:
            var contentPath = ResolveContentPath();

            app.UsePhp("/", rootPath: contentPath);
            app.UseStaticFiles(new StaticFileOptions { FileProvider = new PhysicalFileProvider(contentPath) });

            //
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }

        /// <summary>
        /// Gets location of website project content.
        /// In development, we use the original website project location.
        /// Otherwise, content files are published to the current working directory.
        /// </summary>
        /// <returns></returns>
        static string ResolveContentPath()
        {
            var devcontent = Path.GetFullPath("../website");
            if (Directory.Exists(devcontent))
            {
                return devcontent;
            }

            return Directory.GetCurrentDirectory();
        }
    }
}
