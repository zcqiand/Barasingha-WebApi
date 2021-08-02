namespace UltraNuke.Barasingha.PermissionManagement.API.Application.Commands
{
    using AutoMapper;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.PermissionManagement.API.Application.DTO;
    using UltraNuke.Barasingha.PermissionManagement.API;
    using UltraNuke.Barasingha.PermissionManagement.Domain.AggregatesModel;
    using UltraNuke.CommonMormon.DDD;
    using UltraNuke.CommonMormon.Utils.Exceptions;

    public class LoginCommandHandler
        : IRequestHandler<LoginCommand, TokenDTO>
    {
        private readonly IRepository repository;
        private readonly AppSettings settings;

        public LoginCommandHandler(IRepository repository, IOptionsSnapshot<AppSettings> settings)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.settings = settings.Value ?? throw new ArgumentNullException(nameof(settings));
        }

        public async Task<TokenDTO> Handle(LoginCommand param, CancellationToken cancellationToken)
        {
            var user = await repository.Query<User>()
                .AsNoTracking()
                .Where(w => w.UserName == param.UserName && w.Password == param.Password && !w.Disabled)
                .FirstOrDefaultAsync();

            if (user == null)
                throw new UserOperationException("用户名或密码输入错误！");

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.TokenSecret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtAccessToken = new JwtSecurityToken(settings.TokenIssuer, settings.TokenAudience, claims, expires: DateTime.UtcNow.AddMinutes(settings.AccessTokenExpiresIn), signingCredentials: credentials);

            var tokenDTO = new TokenDTO()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtAccessToken),
                ExpiresIn = settings.AccessTokenExpiresIn,
                UserId = user.Id,
            };
            return tokenDTO;
        }
    }
}
