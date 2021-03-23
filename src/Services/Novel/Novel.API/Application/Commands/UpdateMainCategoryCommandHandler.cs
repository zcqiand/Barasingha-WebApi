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
        : IRequestHandler<UpdateMainCategoryCommand, MainCategoryDTO>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public UpdateMainCategoryCommandHandler(IRepository repository, IMapper mapper)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<MainCategoryDTO> Handle(UpdateMainCategoryCommand param, CancellationToken cancellationToken)
        {
            var mainCategory = await repository.GetAsync<MainCategory>(param.Id);
            mainCategory.Update(param.No, param.Name);
            repository.Entry(mainCategory);
            await repository.SaveAsync();

            var mainCategoryForDTO = mapper.Map<MainCategoryDTO>(mainCategory);

            return mainCategoryForDTO;
        }
    }
}
