using MediatR;
using UltraNuke.Barasingha.Permission.API.Application.DTO;

namespace UltraNuke.Barasingha.Permission.API.Application.Commands
{
    public class UpdateMenuCommand : MenuCommandBase, IRequest<MenuDTO>
    {
    }

}
