namespace UltraNuke.Barasingha.Todoing.API.Application.IntegrationEvents.EventHandling
{
    using MassTransit;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.Todoing.API.Application.IntegrationEvents.Events;

    public class TodoUpdatedIntegrationEventHandler :
        IConsumer<TodoUpdatedIntegrationEvent>
    {
        private readonly ILogger<TodoUpdatedIntegrationEventHandler> logger;
        public TodoUpdatedIntegrationEventHandler(
            ILogger<TodoUpdatedIntegrationEventHandler> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task Consume(ConsumeContext<TodoUpdatedIntegrationEvent> context)
        {
            return Handle(context.Message);
        }

        public Task Handle(TodoUpdatedIntegrationEvent @event)
        {
            logger.LogInformation("----- Handling integration event: {IntegrationEventId} at {AppName} - ({@IntegrationEvent})", @event.TodoId, Program.AppName, @event);
            return Task.CompletedTask;
        }
    }
}