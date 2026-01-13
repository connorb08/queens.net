using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Queens.Controllers;
using Queens.Core;
using Queens.Core.Variables;
using Queens.Enums;
using Queens.Interfaces;
using Queens.Interfaces.Core;
using Queens.Interfaces.Core.Variables;
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
                .AddHostedService<SolutionController>();
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
