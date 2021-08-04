namespace UltraNuke.Barasingha.PermissionManagement.API.Application.Commands
{
    using AutoMapper;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.PermissionManagement.Domain.AggregatesModel;
    using UltraNuke.CommonMormon.DDD;

    public class CreateRoleCommandHandler
        : IRequestHandler<CreateRoleCommand, Guid>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public CreateRoleCommandHandler(IRepository repository, IMapper mapper)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Guid> Handle(CreateRoleCommand param, CancellationToken cancellationToken)
        {
            var role = Role.Create(param.No, param.Name);
            repository.Entry(role);
            await repository.SaveAsync();

            return role.Id;
        }
    }
}
