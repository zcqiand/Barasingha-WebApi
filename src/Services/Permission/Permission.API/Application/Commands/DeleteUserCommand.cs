using MediatR;

namespace UltraNuke.Barasingha.Permission.API.Application.Commands
{
    public class DeleteUserCommand : UserCommandBase, IRequest<bool>
    {
    }

}
