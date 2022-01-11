using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NServiceBus;
using System.Diagnostics;

static partial class Program
{
    public static void Main(string[] args)
    {
        Host.CreateDefaultBuilder(args)
             .ConfigureAppConfiguration(app =>
             {
                 app.AddJsonFile("appsettings.json");
             })
            .UseConsoleLifetime()
            .ConfigureLogging(logging =>
            {
                logging.AddConsole();
            })
            .UseNServiceBus(ctx =>
            {
                var endpointConfiguration = new EndpointConfiguration("StartEndpoint");
                endpointConfiguration.UseSerialization<NewtonsoftSerializer>();

                var transportExtensions = endpointConfiguration.UseTransport<LearningTransport>();
                transportExtensions.StorageDirectory(ctx.Configuration["LearningTransportStorageDirectory"]);
                endpointConfiguration.UsePersistence<LearningPersistence>();
                endpointConfiguration.EnableInstallers();

                return endpointConfiguration;
            })
            .ConfigureServices(services =>
            {
                services.AddHostedService<Service>();

            })
            .Build()
            .Run();
    }
}