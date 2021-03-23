namespace UltraNuke.Barasingha.Novel.API.Application.Commands
{
    using AutoMapper;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.Novel.API.Application.DTO;
    using UltraNuke.Barasingha.Novel.Domain.AggregatesModel;
    using UltraNuke.CommonMormon.DDD;

    public class CreateChapterCommandHandler
        : IRequestHandler<CreateChapterCommand, ChapterDTO>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public CreateChapterCommandHandler(IRepository repository, IMapper mapper)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ChapterDTO> Handle(CreateChapterCommand param, CancellationToken cancellationToken)
        {
            var segment = await repository.GetAsync<Segment>(param.SegmentId);
            var chapter = Chapter.Create(segment, param.No, param.Name, param.Content);
            repository.Entry(chapter);
            await repository.SaveAsync();

            var chapterForDTO = mapper.Map<ChapterDTO>(chapter);
            return chapterForDTO;
        }
    }
}
