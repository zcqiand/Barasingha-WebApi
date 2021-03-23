namespace UltraNuke.Barasingha.Todoing.API.Application.DomainEventHandlers
{
    using Domain.Events;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class TodoUpdatedDomainEventHandler : INotificationHandler<TodoUpdatedDomainEvent>
    {
        private readonly ILoggerFactory logger;
        public TodoUpdatedDomainEventHandler(ILoggerFactory logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task Handle(TodoUpdatedDomainEvent todoUpdatedDomainEvent, CancellationToken cancellationToken)
        {
            logger.CreateLogger<TodoUpdatedDomainEvent>().LogDebug("Todo with Id: {TodoId} has been successfully updated",
                    todoUpdatedDomainEvent.Todo.Id);
            return Task.CompletedTask;
        }
    }
}