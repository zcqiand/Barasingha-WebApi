using MediatR;

namespace UltraNuke.Barasingha.Permission.API.Application.Commands
{
    public class DeleteMenuCommand : MenuCommandBase, IRequest<bool>
    {
    }

}
