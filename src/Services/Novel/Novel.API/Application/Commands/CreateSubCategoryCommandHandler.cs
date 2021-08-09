namespace UltraNuke.Barasingha.Novel.API.Application.Commands
{
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.Novel.Domain.AggregatesModel;
    using UltraNuke.CommonMormon.DDD;

    public class CreateSubCategoryCommandHandler
        : IRequestHandler<CreateSubCategoryCommand, Guid>
    {
        private readonly IRepository repository;

        public CreateSubCategoryCommandHandler(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Guid> Handle(CreateSubCategoryCommand param, CancellationToken cancellationToken)
        {
            var mainCategory = await repository.GetAsync<MainCategory>(param.MainCategoryId);
            var subCategory = SubCategory.Create(param.No, param.Name, mainCategory);
            repository.Entry<SubCategory>(subCategory);
            await repository.SaveAsync();

            return subCategory.Id;
        }
    }
}
