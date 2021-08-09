namespace UltraNuke.Barasingha.Novel.API.Application.Commands
{
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.Novel.Domain.AggregatesModel;
    using UltraNuke.CommonMormon.DDD;

    public class CreateMainCategoryCommandHandler
        : IRequestHandler<CreateMainCategoryCommand, Guid>
    {
        private readonly IRepository repository;

        public CreateMainCategoryCommandHandler(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Guid> Handle(CreateMainCategoryCommand param, CancellationToken cancellationToken)
        {
            var mainCategory = MainCategory.Create(param.No, param.Name);
            repository.Entry(mainCategory);
            await repository.SaveAsync();

            return mainCategory.Id;
        }
    }
}
