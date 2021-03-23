using MediatR;

namespace UltraNuke.Barasingha.Novel.API.Application.Commands
{
    public class DeleteChapterCommand : ChapterCommandBase, IRequest<bool>
    {
    }

}
