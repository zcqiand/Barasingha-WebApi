using MediatR;
using UltraNuke.Barasingha.Permission.API.Application.DTO;

namespace UltraNuke.Barasingha.Permission.API.Application.Commands
{
    public class CreateRoleCommand : RoleCommandBase, IRequest<RoleDTO>
    {
    }

}
