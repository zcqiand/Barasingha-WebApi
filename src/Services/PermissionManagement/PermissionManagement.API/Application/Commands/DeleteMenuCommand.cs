using MediatR;

namespace UltraNuke.Barasingha.PermissionManagement.API.Application.Commands
{
    public class DeleteMenuCommand : MenuCommandBase, IRequest<bool>
    {
    }

}
