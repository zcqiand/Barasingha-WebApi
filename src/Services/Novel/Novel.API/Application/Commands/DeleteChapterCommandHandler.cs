namespace UltraNuke.Barasingha.Novel.API.Application.Commands
{
    using AutoMapper;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.Novel.Domain.AggregatesModel;
    using UltraNuke.CommonMormon.DDD;

    public class DeleteChapterCommandHandler
        : IRequestHandler<DeleteChapterCommand, bool>
    {
        private readonly IRepository repository;

        public DeleteChapterCommandHandler(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool> Handle(DeleteChapterCommand message, CancellationToken cancellationToken)
        {
            var chapter = await repository.GetAsync<Chapter>(message.Id);
            if (chapter == null)
            {
                return false;
            }
            chapter.Delete();
            repository.Entry(chapter);
            await repository.SaveAsync();
            return true;
        }
    }
}
