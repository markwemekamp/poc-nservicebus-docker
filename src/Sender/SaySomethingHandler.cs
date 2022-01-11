using Messages;
using Microsoft.Extensions.Logging;
using NServiceBus;

namespace Sender
{
    public class SaySomethingHandler : IHandleMessages<SaySomething>
    {
        private readonly ILogger<SaySomethingHandler> _logger;

        public SaySomethingHandler(ILogger<SaySomethingHandler> logger)
        {
            _logger = logger;
            logger.LogInformation("Initialized");
        }

        public Task Handle(SaySomething command, IMessageHandlerContext context)
        {
            _logger.LogInformation($"{command.Message} from Sender");
            return Task.CompletedTask;
        }
    }
}
