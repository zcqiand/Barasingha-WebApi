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

    public class CreateSegmentCommandHandler
        : IRequestHandler<CreateSegmentCommand, SegmentDTO>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public CreateSegmentCommandHandler(IRepository repository, IMapper mapper)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<SegmentDTO> Handle(CreateSegmentCommand param, CancellationToken cancellationToken)
        {
            var book = await repository.GetAsync<Book>(param.BookId);
            var segment = Segment.Create(book, param.No, param.Name);
            repository.Entry(segment);
            await repository.SaveAsync();

            var segmentForDTO = mapper.Map<SegmentDTO>(segment);
            return segmentForDTO;
        }
    }
}
