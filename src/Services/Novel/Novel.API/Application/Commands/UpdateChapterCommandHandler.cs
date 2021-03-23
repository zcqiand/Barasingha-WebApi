namespace UltraNuke.Barasingha.Novel.API.Application.Commands
{
    using AutoMapper;
    using MassTransit;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.Novel.API.Application.DTO;
    using UltraNuke.Barasingha.Novel.Domain.AggregatesModel;
    using UltraNuke.CommonMormon.DDD;

    public class UpdateChapterCommandHandler
        : IRequestHandler<UpdateChapterCommand, ChapterDTO>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public UpdateChapterCommandHandler(IRepository repository, IMapper mapper)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ChapterDTO> Handle(UpdateChapterCommand param, CancellationToken cancellationToken)
        {
            var chapter = await repository.GetAsync<Chapter>(param.Id);
            chapter.Update(param.No, param.Name, param.Content);
            repository.Entry(chapter);
            await repository.SaveAsync();

            var chapterForDTO = mapper.Map<ChapterDTO>(chapter);

            return chapterForDTO;
        }
    }
}
