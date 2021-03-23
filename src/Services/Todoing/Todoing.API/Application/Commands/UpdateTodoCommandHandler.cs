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
        : IRequestHandler<UpdateTodoCommand, TodoDTO>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;
        private readonly IPublishEndpoint eventBus;

        public UpdateTodoCommandHandler(IRepository repository, IMapper mapper, IPublishEndpoint eventBus)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        public async Task<TodoDTO> Handle(UpdateTodoCommand message, CancellationToken cancellationToken)
        {
            var todo = await repository.GetAsync<Todo>(message.Id);
            todo.Update(message.Name);
            repository.Entry(todo);
            await repository.SaveAsync();

            var todoUpdatedEvent = new TodoUpdatedIntegrationEvent(todo.Id, todo.Name);
            await eventBus.Publish(todoUpdatedEvent);

            var todoForDTO = mapper.Map<TodoDTO>(todo);

            return todoForDTO;
        }
    }
}
