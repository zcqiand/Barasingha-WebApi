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
        : IRequestHandler<CreateTodoCommand, TodoDTO>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public CreateTodoCommandHandler(IRepository repository, IMapper mapper)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<TodoDTO> Handle(CreateTodoCommand message, CancellationToken cancellationToken)
        {
            var todo = Todo.Create(message.Name);
            repository.Entry(todo);
            await repository.SaveAsync();

            var todoForDTO = mapper.Map<TodoDTO>(todo);
            return todoForDTO;
        }
    }
}
