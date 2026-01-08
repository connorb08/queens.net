using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Queens.Controllers;
using Queens.Core;
using Queens.Interfaces;
using Queens.Services;
using Queens.Variables;

namespace Queens.Extensions;

internal static class HostExtensions
{

    extension(HostApplicationBuilder builder)
    {
        internal HostApplicationBuilder RegisterServices()
        {
            builder.Services
                .AddSingleton<IFactory, Factory>()
                .AddSingleton<IGraph, Graph>()
                .AddTransient<Row>()
                .AddTransient<Column>()
                .AddTransient<Color>()
                .AddTransient<ICell, Cell>()
                .AddSingleton<IPageController, PageController>()
                .AddHostedService<SolutionController>();
            return builder;
        }
    }
}
