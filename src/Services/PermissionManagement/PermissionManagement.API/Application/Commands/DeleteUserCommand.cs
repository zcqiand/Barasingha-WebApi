using MediatR;

namespace UltraNuke.Barasingha.PermissionManagement.API.Application.Commands
{
    public class DeleteUserCommand : UserCommandBase, IRequest<bool>
    {
    }

}
