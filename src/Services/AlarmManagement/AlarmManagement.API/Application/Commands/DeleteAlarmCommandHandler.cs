namespace UltraNuke.Barasingha.AlarmManagement.API.Application.Commands
{
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.AlarmManagement.Domain.AggregatesModel;
    using UltraNuke.CommonMormon.DDD;

    public class DeleteAlarmCommandHandler
        : IRequestHandler<DeleteAlarmCommand, bool>
    {
        private readonly IRepository repository;

        public DeleteAlarmCommandHandler(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool> Handle(DeleteAlarmCommand message, CancellationToken cancellationToken)
        {
            var alarm = await repository.GetAsync<Alarm>(message.Id);
            alarm.Delete();
            repository.Entry(alarm);
            await repository.SaveAsync();
            return true;
        }
    }
}
