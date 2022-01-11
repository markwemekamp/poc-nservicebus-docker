using Messages;
using Microsoft.Extensions.Logging;
using NServiceBus;
using System.Threading.Tasks;

namespace Sender
{
    public class SaySomethingHandler : IHandleMessages<SaySomething>
    {
        private readonly ILogger<SaySomethingHandler> _logger;

        public SaySomethingHandler(ILogger<SaySomethingHandler> logger)
        {
            _logger = logger;
            logger.LogInformation("Initialized Receiver 1");
        }

        public Task Handle(SaySomething command, IMessageHandlerContext context)
        {
            _logger.LogInformation($"{command.Message} from Receiver 1");
            return Task.CompletedTask;
        }
    }
}
