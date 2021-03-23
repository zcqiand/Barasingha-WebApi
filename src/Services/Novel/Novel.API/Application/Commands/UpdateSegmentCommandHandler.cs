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

    public class UpdateSegmentCommandHandler
        : IRequestHandler<UpdateSegmentCommand, SegmentDTO>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public UpdateSegmentCommandHandler(IRepository repository, IMapper mapper)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<SegmentDTO> Handle(UpdateSegmentCommand param, CancellationToken cancellationToken)
        {
            var segment = await repository.GetAsync<Segment>(param.Id);
            segment.Update(param.No, param.Name);
            repository.Entry(segment);
            await repository.SaveAsync();

            var segmentForDTO = mapper.Map<SegmentDTO>(segment);

            return segmentForDTO;
        }
    }
}
