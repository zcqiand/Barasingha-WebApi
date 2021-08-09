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
        : IRequestHandler<UpdateSegmentCommand, bool>
    {
        private readonly IRepository repository;

        public UpdateSegmentCommandHandler(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool> Handle(UpdateSegmentCommand param, CancellationToken cancellationToken)
        {
            var segment = await repository.GetAsync<Segment>(param.Id);
            segment.Update(param.No, param.Name);
            repository.Entry(segment);
            await repository.SaveAsync();

            return true;
        }
    }
}
