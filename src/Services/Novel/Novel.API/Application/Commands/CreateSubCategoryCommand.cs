using MediatR;
using UltraNuke.Barasingha.Novel.API.Application.DTO;

namespace UltraNuke.Barasingha.Novel.API.Application.Commands
{
    public class CreateSubCategoryCommand : SubCategoryCommandBase, IRequest<SubCategoryDTO>
    {
    }

}
