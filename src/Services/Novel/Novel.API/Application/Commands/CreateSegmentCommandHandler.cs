namespace UltraNuke.Barasingha.Novel.API.Application.Commands
{
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.Novel.Domain.AggregatesModel;
    using UltraNuke.CommonMormon.DDD;

    public class CreateSegmentCommandHandler
        : IRequestHandler<CreateSegmentCommand, Guid>
    {
        private readonly IRepository repository;

        public CreateSegmentCommandHandler(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Guid> Handle(CreateSegmentCommand param, CancellationToken cancellationToken)
        {
            var book = await repository.GetAsync<Book>(param.BookId);
            var segment = Segment.Create(book, param.No, param.Name);
            repository.Entry(segment);
            await repository.SaveAsync();

            return segment.Id;
        }
    }
}
