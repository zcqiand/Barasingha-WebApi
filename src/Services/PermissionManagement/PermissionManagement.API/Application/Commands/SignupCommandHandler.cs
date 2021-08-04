namespace UltraNuke.Barasingha.PermissionManagement.API.Application.Commands
{
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.PermissionManagement.Domain.AggregatesModel;
    using UltraNuke.CommonMormon.DDD;

    public class SignupCommandHandler
        : IRequestHandler<SignupCommand, Guid>
    {
        private readonly IRepository repository;

        public SignupCommandHandler(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Guid> Handle(SignupCommand param, CancellationToken cancellationToken)
        {
            var user = User.Create(param.NickName, param.UserName, param.Password);

            repository.Entry(user);
            await repository.SaveAsync();

            return user.Id;
        }
    }
}
