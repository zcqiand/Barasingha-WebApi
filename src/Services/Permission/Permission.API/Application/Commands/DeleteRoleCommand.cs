using MediatR;

namespace UltraNuke.Barasingha.Permission.API.Application.Commands
{
    public class DeleteRoleCommand : RoleCommandBase, IRequest<bool>
    {
    }

}
