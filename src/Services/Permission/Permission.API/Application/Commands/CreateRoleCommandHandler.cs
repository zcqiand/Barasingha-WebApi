namespace UltraNuke.Barasingha.Roleing.API.Application.Commands
{
    using AutoMapper;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.Permission.API.Application.Commands;
    using UltraNuke.Barasingha.Permission.API.Application.DTO;
    using UltraNuke.Barasingha.Permission.Domain.AggregatesModel;
    using UltraNuke.CommonMormon.DDD;

    public class CreateRoleCommandHandler
        : IRequestHandler<CreateRoleCommand, RoleDTO>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public CreateRoleCommandHandler(IRepository repository, IMapper mapper)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<RoleDTO> Handle(CreateRoleCommand param, CancellationToken cancellationToken)
        {
            var role = Role.Create(param.No, param.Name);
            repository.Entry(role);
            await repository.SaveAsync();

            var roleForDTO = mapper.Map<RoleDTO>(role);
            return roleForDTO;
        }
    }
}
