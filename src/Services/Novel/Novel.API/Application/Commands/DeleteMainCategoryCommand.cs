using MediatR;
using UltraNuke.Barasingha.Novel.API.Application.Commands;

namespace UltraNuke.Barasingha.Novel.API.Application.Commands
{
    public class DeleteMainCategoryCommand : MainCategoryCommandBase, IRequest<bool>
    {
    }

}
