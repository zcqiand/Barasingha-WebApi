namespace UltraNuke.Barasingha.PermissionManagement.API.Application.Commands
{
    using AutoMapper;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.PermissionManagement.Domain.AggregatesModel;
    using UltraNuke.CommonMormon.DDD;

    public class UpdateRoleCommandHandler
        : IRequestHandler<UpdateRoleCommand, bool>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public UpdateRoleCommandHandler(IRepository repository, IMapper mapper)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> Handle(UpdateRoleCommand param, CancellationToken cancellationToken)
        {
            var role = await repository.GetAsync<Role>(param.Id);
            role.Update(param.No, param.Name);
            repository.Entry(role);
            await repository.SaveAsync();

            return true;
        }
    }
}
