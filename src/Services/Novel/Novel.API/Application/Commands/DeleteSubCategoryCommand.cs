using MediatR;

namespace UltraNuke.Barasingha.Novel.API.Application.Commands
{
    public class DeleteSubCategoryCommand : SubCategoryCommandBase, IRequest<bool>
    {
    }

}
