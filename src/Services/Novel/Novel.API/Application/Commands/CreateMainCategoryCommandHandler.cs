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

    public class CreateMainCategoryCommandHandler
        : IRequestHandler<CreateMainCategoryCommand, MainCategoryDTO>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public CreateMainCategoryCommandHandler(IRepository repository, IMapper mapper)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<MainCategoryDTO> Handle(CreateMainCategoryCommand param, CancellationToken cancellationToken)
        {
            var mainCategory = MainCategory.Create(param.No, param.Name);
            repository.Entry(mainCategory);
            await repository.SaveAsync();

            var mainCategoryForDTO = mapper.Map<MainCategoryDTO>(mainCategory);
            return mainCategoryForDTO;
        }
    }
}
