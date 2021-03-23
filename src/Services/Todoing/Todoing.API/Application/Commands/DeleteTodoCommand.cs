using MediatR;

namespace UltraNuke.Barasingha.Todoing.API.Application.Commands
{
    public class DeleteTodoCommand : TodoCommandBase, IRequest<bool>
    {
    }

}
