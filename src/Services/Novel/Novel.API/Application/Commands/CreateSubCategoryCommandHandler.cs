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

    public class CreateSubCategoryCommandHandler
        : IRequestHandler<CreateSubCategoryCommand, SubCategoryDTO>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public CreateSubCategoryCommandHandler(IRepository repository, IMapper mapper)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<SubCategoryDTO> Handle(CreateSubCategoryCommand param, CancellationToken cancellationToken)
        {
            var mainCategory = await repository.GetAsync<MainCategory>(param.MainCategoryId);
            var subCategory = SubCategory.Create(param.No, param.Name, mainCategory);
            repository.Entry<SubCategory>(subCategory);
            await repository.SaveAsync();

            var subCategoryForDTO = mapper.Map<SubCategoryDTO>(subCategory);
            return subCategoryForDTO;
        }
    }
}
