namespace UltraNuke.Barasingha.Novel.API.Application.Commands
{
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.Novel.Domain.AggregatesModel;
    using UltraNuke.CommonMormon.DDD;

    public class CreateChapterCommandHandler
        : IRequestHandler<CreateChapterCommand, Guid>
    {
        private readonly IRepository repository;

        public CreateChapterCommandHandler(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Guid> Handle(CreateChapterCommand param, CancellationToken cancellationToken)
        {
            var segment = await repository.GetAsync<Segment>(param.SegmentId);
            var chapter = Chapter.Create(segment, param.No, param.Name, param.Content);
            repository.Entry(chapter);
            await repository.SaveAsync();

            return chapter.Id;
        }
    }
}
