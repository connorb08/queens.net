using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Queens.Controllers;
using Queens.Interfaces;
using Queens.Services;

namespace Queens.Extensions;

internal static class HostExtensions
{

    extension(HostApplicationBuilder builder)
    {
        internal HostApplicationBuilder RegisterServices()
        {
            builder.Services
                .AddSingleton<IFactory, Factory>()
                .AddSingleton<IPageController, PageController>()
                .AddSingleton<ISolutionManager, SolutionManager>()
                .AddSingleton<Publisher>()
                .AddHostedService<Solver>();
            return builder;
        }

        internal HostApplicationBuilder LoadAndRegisterConfig()
        {
            builder.Services.AddSingleton<IConfig>(builder.Configuration.Get<Config>());
            return builder;
        }

        internal HostApplicationBuilder AddLogging()
        {
            builder.Services.AddLogging(config =>
            {
                config.ClearProviders();
                config.AddConfiguration(builder.Configuration.GetSection("Logging"));
                config.AddConsole();
            });
            return builder;
        }

    }
}
