

using System.Text.Json;

// using Amazon.Lambda.APIGatewayEvents;
// using Amazon.Lambda.Core;

using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Hosting;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
// [assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]


namespace Queens;


internal class Program
{
    static async Task Main(string[] args)
    {
        string environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? Environments.Development;
        await BuildHost(args, environment)
            .LoadAndRegisterConfig()
            .AddLogging()
            .RegisterServices()
            .Build()
            .RunAsync();
    }

    public static HostApplicationBuilder BuildHost(string[] args, string environment) => Host.CreateEmptyApplicationBuilder(new()
    {
        ApplicationName = "Queens.Net",
        EnvironmentName = environment,
        Args = args,
        Configuration = new()
        {
            Sources = {
                new JsonConfigurationSource
                {
                    Path = "appsettings.json",
                    Optional = false,
                    ReloadOnChange = true,
                },
                new JsonConfigurationSource
                {
                    Path = $"appsettings.{environment}.json",
                    Optional = true,
                    ReloadOnChange = true,
                },
                new JsonConfigurationSource
                {
                    Path = $"secrets.json",
                    Optional = true,
                    ReloadOnChange = true,
                },
                new EnvironmentVariablesConfigurationSource(),
            }
        }
    });
}

// public class Function
// {

//     public static async Task<APIGatewayProxyResponse> FunctionHandler(
//         APIGatewayProxyRequest request,
//         ILambdaContext context)
//     {
//         try
//         {
//             await Program.BuildHost([], Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? Environments.Development)
//             .LoadAndRegisterConfig()
//             .AddLogging()
//             .RegisterServices()
//             .Build()
//             .RunAsync();

//             return new APIGatewayProxyResponse
//             {
//                 StatusCode = 200,
//                 Body = JsonSerializer.Serialize(new { message = "Success" }),
//                 Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } }
//             };
//         }
//         catch (Exception ex)
//         {
//             context.Logger.LogLine($"Error: {ex.Message}\n{ex.StackTrace}");
//             return new APIGatewayProxyResponse
//             {
//                 StatusCode = 500,
//                 Body = JsonSerializer.Serialize(new { error = ex.Message }),
//                 Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } }
//             };
//         }
//     }
// }
