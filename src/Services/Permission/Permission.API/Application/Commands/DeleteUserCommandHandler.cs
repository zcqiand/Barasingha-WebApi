namespace UltraNuke.Barasingha.Permission.API.Application.Commands
{
    using AutoMapper;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.Permission.Domain.AggregatesModel;
    using UltraNuke.CommonMormon.DDD;

    public class DeleteUserCommandHandler
        : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IRepository repository;

        public DeleteUserCommandHandler(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool> Handle(DeleteUserCommand param, CancellationToken cancellationToken)
        {
            var user = await repository.GetAsync<User>(param.Id);
            if (user == null)
            {
                return false;
            }
            user.Delete();
            repository.Entry(user);
            await repository.SaveAsync();
            return true;
        }
    }
}
