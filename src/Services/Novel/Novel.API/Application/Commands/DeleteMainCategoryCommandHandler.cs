namespace UltraNuke.Barasingha.Novel.API.Application.Commands
{
    using AutoMapper;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.Novel.API.Application.DTO;
    using UltraNuke.Barasingha.Novel.Domain.AggregatesModel;
    using UltraNuke.CommonMormon.DDD;

    public class DeleteMainCategoryCommandHandler
        : IRequestHandler<DeleteMainCategoryCommand, bool>
    {
        private readonly IRepository repository;

        public DeleteMainCategoryCommandHandler(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool> Handle(DeleteMainCategoryCommand message, CancellationToken cancellationToken)
        {
            var mainCategory = await repository.GetAsync<MainCategory>(message.Id);
            if (mainCategory == null)
            {
                return false;
            }
            mainCategory.Delete();
            repository.Entry(mainCategory);
            await repository.SaveAsync();
            return true;
        }
    }
}
