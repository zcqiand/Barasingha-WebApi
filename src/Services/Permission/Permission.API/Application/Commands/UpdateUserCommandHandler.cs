namespace UltraNuke.Barasingha.Permission.API.Application.Commands
{
    using AutoMapper;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.Permission.API.Application.DTO;
    using UltraNuke.Barasingha.Permission.Domain.AggregatesModel;
    using UltraNuke.CommonMormon.DDD;

    public class UpdateUserCommandHandler
        : IRequestHandler<UpdateUserCommand, UserDTO>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public UpdateUserCommandHandler(IRepository repository, IMapper mapper)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UserDTO> Handle(UpdateUserCommand param, CancellationToken cancellationToken)
        {
            var roles = await repository.Query<Role>(w => param.RoleIds.Contains(w.Id))
                .ToListAsync();

            var includes = new Func<IQueryable<User>, IQueryable<User>>(query =>
            {
                return query.Include(b => b.Roles);
            });
            var user = await repository.GetAsync(param.Id, includes);

            user.Update(param.No, param.AvatarUrl, param.NickName, param.Gender, param.UserName, param.PasswordQuestion, param.PasswordAnswer, param.Disabled, roles);
            repository.Entry(user);
            await repository.SaveAsync();

            var userForDTO = mapper.Map<UserDTO>(user);
            return userForDTO;
        }
    }
}
