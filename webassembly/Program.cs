using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Pchp.Core;
using webassembly;
using webassembly.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
    .AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })
    .AddScoped(sp => Context.CreateEmpty()) // PHP request context - Lifecycle of a PHP request. // NOTE: can be created as Singleton() to remember all the globals and includes across all requests!
    .AddScoped<PhpInterop>() // helper service utilizing PeachPie API
    ;

// get php.dll assembly, and load its scripts into the application memory
Context.AddScriptReference(typeof(Dummy).Assembly);

// run server
await builder.Build().RunAsync();
