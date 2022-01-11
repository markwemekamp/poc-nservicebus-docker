using NServiceBus;

namespace Messages
{
    public class SaySomething : IEvent
    {
        public string Message { get; set; }

        public SaySomething(string message)
        {
            Message = message;
        }
    }
}