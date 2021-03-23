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

    public class DeleteTodoCommandHandler
        : IRequestHandler<DeleteTodoCommand, bool>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public DeleteTodoCommandHandler(IRepository repository, IMapper mapper)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> Handle(DeleteTodoCommand message, CancellationToken cancellationToken)
        {
            var todo = await repository.GetAsync<Todo>(message.Id);
            //if (todo == null)
            //{
            //    return false;
            //}
            todo.Delete();
            repository.Entry(todo);
            await repository.SaveAsync();
            return true;
        }
    }
}
