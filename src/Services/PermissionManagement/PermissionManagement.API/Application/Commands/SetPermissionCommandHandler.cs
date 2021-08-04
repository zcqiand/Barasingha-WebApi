namespace UltraNuke.Barasingha.PermissionManagement.API.Application.Commands
{
    using AutoMapper;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.PermissionManagement.API.Application.DTO;
    using UltraNuke.Barasingha.PermissionManagement.Domain.AggregatesModel;
    using UltraNuke.CommonMormon.DDD;

    public class SetPermissionCommandHandler
        : IRequestHandler<SetPermissionCommand, RoleForGetDTO>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public SetPermissionCommandHandler(IRepository repository, IMapper mapper)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<RoleForGetDTO> Handle(SetPermissionCommand param, CancellationToken cancellationToken)
        {
            var menus = await repository.Query<Menu>(w => param.MenuIds.Contains(w.Id))
                .ToListAsync();

            var includes = new Func<IQueryable<Role>, IQueryable<Role>>(query =>
            {
                return query.Include(b => b.Menus);
            });

            var role = await repository.GetAsync<Role>(param.Id, includes, cancellationToken);
            role.SetPermission(menus);
            repository.Entry(role);
            await repository.SaveAsync();

            var roleForDTO = mapper.Map<RoleForGetDTO>(role);

            return roleForDTO;
        }
    }
}
