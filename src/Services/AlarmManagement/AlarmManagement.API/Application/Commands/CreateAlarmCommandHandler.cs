namespace UltraNuke.Barasingha.AlarmManagement.API.Application.Commands
{
    using AutoMapper;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.AlarmManagement.Domain.AggregatesModel;
    using UltraNuke.CommonMormon.DDD;

    public class CreateAlarmCommandHandler
        : IRequestHandler<CreateAlarmCommand, Guid>
    {
        private readonly IRepository repository;

        public CreateAlarmCommandHandler(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Guid> Handle(CreateAlarmCommand message, CancellationToken cancellationToken)
        {
            var category = await repository.GetAsync<Category>(message.CategoryId);
            var level = await repository.GetAsync<Level>(message.LevelId);
            var alarm = Alarm.Create(message.OccurrenceTime, category, level, message.Name, message.Content, message.Details, message.EventId);
            repository.Entry(alarm);
            await repository.SaveAsync();
            return alarm.Id;
        }
    }
}
