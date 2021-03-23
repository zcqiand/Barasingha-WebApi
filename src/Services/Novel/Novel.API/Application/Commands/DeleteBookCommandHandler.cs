namespace UltraNuke.Barasingha.Novel.API.Application.Commands
{
    using AutoMapper;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.Novel.Domain.AggregatesModel;
    using UltraNuke.CommonMormon.DDD;

    public class DeleteBookCommandHandler
        : IRequestHandler<DeleteBookCommand, bool>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public DeleteBookCommandHandler(IRepository repository, IMapper mapper)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> Handle(DeleteBookCommand message, CancellationToken cancellationToken)
        {
            var book = await repository.GetAsync<Book>(message.Id);
            if (book == null)
            {
                return false;
            }
            book.Delete();
            repository.Entry(book);
            await repository.SaveAsync();
            return true;
        }
    }
}
