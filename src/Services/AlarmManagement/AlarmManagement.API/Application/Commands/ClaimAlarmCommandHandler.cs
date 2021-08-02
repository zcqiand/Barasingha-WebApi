namespace UltraNuke.Barasingha.AlarmManagement.API.Application.Commands
{
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.AlarmManagement.Domain.AggregatesModel;
    using UltraNuke.CommonMormon.DDD;

    public class ClaimAlarmCommandHandler
        : IRequestHandler<ClaimAlarmCommand, bool>
    {
        private readonly IRepository repository;

        public ClaimAlarmCommandHandler(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool> Handle(ClaimAlarmCommand message, CancellationToken cancellationToken)
        {
            var alarm = await repository.GetAsync<Alarm>(message.Id);
            alarm.Claim(message.ClaimMethod, message.ClaimUserId, message.ClaimUserName);
            repository.Entry(alarm);
            await repository.SaveAsync();
            return true;
        }
    }
}
