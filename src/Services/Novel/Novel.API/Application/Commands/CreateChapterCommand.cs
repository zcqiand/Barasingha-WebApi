using MediatR;
using UltraNuke.Barasingha.Novel.API.Application.DTO;

namespace UltraNuke.Barasingha.Novel.API.Application.Commands
{
    public class CreateChapterCommand : ChapterCommandBase, IRequest<ChapterDTO>
    {
    }

}
