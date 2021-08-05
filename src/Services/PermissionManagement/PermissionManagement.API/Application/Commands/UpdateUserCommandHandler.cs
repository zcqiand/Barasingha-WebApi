namespace UltraNuke.Barasingha.PermissionManagement.API.Application.Commands
{
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.PermissionManagement.Domain.AggregatesModel;
    using UltraNuke.CommonMormon.DDD;

    public class UpdateUserCommandHandler
        : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IRepository repository;

        public UpdateUserCommandHandler(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool> Handle(UpdateUserCommand param, CancellationToken cancellationToken)
        {
            var roles = await repository.Query<Role>(w => param.RoleIds.Contains(w.Id))
                .ToListAsync();

            var includes = new Func<IQueryable<User>, IQueryable<User>>(query =>
            {
                return query.Include(b => b.Roles);
            });
            var user = await repository.GetAsync(param.Id, includes);

            user.Update(param.No,param.NickName, param.Gender, param.AvatarUrl, param.Disabled, roles);
            repository.Entry(user);
            await repository.SaveAsync();

            return true;
        }
    }
}
