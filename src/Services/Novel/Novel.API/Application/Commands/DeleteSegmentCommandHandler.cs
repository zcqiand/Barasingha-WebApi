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

    public class DeleteSegmentCommandHandler
        : IRequestHandler<DeleteSegmentCommand, bool>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public DeleteSegmentCommandHandler(IRepository repository, IMapper mapper)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> Handle(DeleteSegmentCommand message, CancellationToken cancellationToken)
        {
            var segment = await repository.GetAsync<Segment>(message.Id);
            //if (segment == null)
            //{
            //    return false;
            //}
            segment.Delete();
            repository.Entry(segment);
            await repository.SaveAsync();
            return true;
        }
    }
}
