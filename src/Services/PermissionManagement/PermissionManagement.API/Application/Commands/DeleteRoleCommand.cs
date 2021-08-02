using MediatR;

namespace UltraNuke.Barasingha.PermissionManagement.API.Application.Commands
{
    public class DeleteRoleCommand : RoleCommandBase, IRequest<bool>
    {
    }

}
