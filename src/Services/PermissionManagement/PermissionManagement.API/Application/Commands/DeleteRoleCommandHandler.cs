namespace UltraNuke.Barasingha.PermissionManagement.API.Application.Commands
{
    using AutoMapper;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.PermissionManagement.Domain.AggregatesModel;
    using UltraNuke.CommonMormon.DDD;

    public class DeleteRoleCommandHandler
        : IRequestHandler<DeleteRoleCommand, bool>
    {
        private readonly IRepository repository;

        public DeleteRoleCommandHandler(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool> Handle(DeleteRoleCommand param, CancellationToken cancellationToken)
        {
            var role = await repository.GetAsync<Role>(param.Id);
            if (role == null)
            {
                return false;
            }
            role.Delete();
            repository.Entry(role);
            await repository.SaveAsync();
            return true;
        }
    }
}
