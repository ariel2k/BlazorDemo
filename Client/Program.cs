using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BlazorDemo.Client.Services;
using BlazorDemo.Client.Repositories;
using Blazor.FileReader;
using BlazorDemo.Client.Helpers;

namespace BlazorDemo.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            ConfigureServices(builder.Services);

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions(); // Auth
            services.AddSingleton<SingletonService>();
            services.AddTransient<TransientService>();
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IShowMessages, ShowMessages>();
            services.AddFileReaderService(options => options.InitializeOnFirstCall = true);
        }
    }
}
