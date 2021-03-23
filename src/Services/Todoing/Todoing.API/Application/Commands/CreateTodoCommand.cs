using MediatR;
using UltraNuke.Barasingha.Todoing.API.Application.DTO;

namespace UltraNuke.Barasingha.Todoing.API.Application.Commands
{
    public class CreateTodoCommand : TodoCommandBase, IRequest<TodoDTO>
    {
    }

}
