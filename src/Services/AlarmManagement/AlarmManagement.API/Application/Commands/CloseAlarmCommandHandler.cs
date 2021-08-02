namespace UltraNuke.Barasingha.AlarmManagement.API.Application.Commands
{
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.AlarmManagement.Domain.AggregatesModel;
    using UltraNuke.CommonMormon.DDD;

    public class CloseAlarmCommandHandler
        : IRequestHandler<CloseAlarmCommand, bool>
    {
        private readonly IRepository repository;

        public CloseAlarmCommandHandler(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool> Handle(CloseAlarmCommand message, CancellationToken cancellationToken)
        {
            var alarm = await repository.GetAsync<Alarm>(message.Id);
            alarm.Close(message.CloseMethod, message.CloseUserId, message.CloseUserName, message.Reason, message.Handling);
            repository.Entry(alarm);
            await repository.SaveAsync();
            return true;
        }
    }
}
