using Messages;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NServiceBus;
using Sender;

static partial class Program
{
    public class Service : IHostedService
    {
        private readonly IMessageSession _endpointInstance;
        private readonly ILogger<SaySomethingHandler> _logger;

        public Service(IMessageSession endpointInstance, ILogger<SaySomethingHandler> logger)
        {
            _endpointInstance = endpointInstance;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting");
            _logger.LogInformation("Speaking");
            while (true)
            {
                await _endpointInstance.Publish(new SaySomething("Woof"));
                Thread.Sleep(5000);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping");
            return Task.CompletedTask;
        }
    }
}