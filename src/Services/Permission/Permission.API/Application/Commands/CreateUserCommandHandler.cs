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

    public class CreateUserCommandHandler
        : IRequestHandler<CreateUserCommand, UserDTO>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public CreateUserCommandHandler(IRepository repository, IMapper mapper)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UserDTO> Handle(CreateUserCommand param, CancellationToken cancellationToken)
        {
            var roles = await repository.Query<Role>(w => param.RoleIds.Contains(w.Id))
                .ToListAsync();
            var user = User.Create(param.No, param.AvatarUrl, param.NickName, param.Gender, param.UserName, param.Password, param.PasswordQuestion, param.PasswordAnswer, roles);

            repository.Entry(user);
            await repository.SaveAsync();

            var userForDTO = mapper.Map<UserDTO>(user);
            return userForDTO;
        }
    }
}
