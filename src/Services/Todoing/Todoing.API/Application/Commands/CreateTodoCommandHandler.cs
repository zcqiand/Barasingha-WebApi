namespace UltraNuke.Barasingha.Todoing.API.Application.Commands
{
    using AutoMapper;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.Todoing.API.Application.DTO;
    using UltraNuke.Barasingha.Todoing.Domain.AggregatesModel;
    using UltraNuke.CommonMormon.DDD;

    public class CreateTodoCommandHandler
        : IRequestHandler<CreateTodoCommand, Guid>
    {
        private readonly IRepository repository;

        public CreateTodoCommandHandler(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Guid> Handle(CreateTodoCommand message, CancellationToken cancellationToken)
        {
            var todo = Todo.Create(message.Name);
            repository.Entry(todo);
            await repository.SaveAsync();

            return todo.Id;
        }
    }
}
