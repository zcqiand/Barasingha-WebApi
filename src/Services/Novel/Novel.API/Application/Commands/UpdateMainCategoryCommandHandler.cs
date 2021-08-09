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

    public class UpdateMainCategoryCommandHandler
        : IRequestHandler<UpdateMainCategoryCommand, bool>
    {
        private readonly IRepository repository;

        public UpdateMainCategoryCommandHandler(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool> Handle(UpdateMainCategoryCommand param, CancellationToken cancellationToken)
        {
            var mainCategory = await repository.GetAsync<MainCategory>(param.Id);
            mainCategory.Update(param.No, param.Name);
            repository.Entry(mainCategory);
            await repository.SaveAsync();

            return true;
        }
    }
}
