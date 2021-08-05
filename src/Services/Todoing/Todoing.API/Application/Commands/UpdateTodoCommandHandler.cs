namespace UltraNuke.Barasingha.Todoing.API.Application.Commands
{
    using AutoMapper;
    using MassTransit;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.Todoing.API.Application.DTO;
    using UltraNuke.Barasingha.Todoing.API.Application.IntegrationEvents.Events;
    using UltraNuke.Barasingha.Todoing.Domain.AggregatesModel;
    using UltraNuke.CommonMormon.DDD;

    public class UpdateTodoCommandHandler
        : IRequestHandler<UpdateTodoCommand, bool>
    {
        private readonly IRepository repository;
        private readonly IPublishEndpoint eventBus;

        public UpdateTodoCommandHandler(IRepository repository, IPublishEndpoint eventBus)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        public async Task<bool> Handle(UpdateTodoCommand message, CancellationToken cancellationToken)
        {
            var todo = await repository.GetAsync<Todo>(message.Id);
            todo.Update(message.Name);
            repository.Entry(todo);
            await repository.SaveAsync();

            var todoUpdatedEvent = new TodoUpdatedIntegrationEvent(todo.Id, todo.Name);
            await eventBus.Publish(todoUpdatedEvent);

            return true;
        }
    }
}
