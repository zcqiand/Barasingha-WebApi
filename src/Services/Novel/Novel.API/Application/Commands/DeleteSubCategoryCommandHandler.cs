namespace UltraNuke.Barasingha.Novel.API.Application.Commands
{
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.Novel.Domain.AggregatesModel;
    using UltraNuke.CommonMormon.DDD;

    public class DeleteSubCategoryCommandHandler
        : IRequestHandler<DeleteSubCategoryCommand, bool>
    {
        private readonly IRepository repository;

        public DeleteSubCategoryCommandHandler(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool> Handle(DeleteSubCategoryCommand message, CancellationToken cancellationToken)
        {
            var subCategory = await repository.GetAsync<SubCategory>(message.Id);
            if (subCategory == null)
            {
                return false;
            }
            subCategory.Delete();
            repository.Entry(subCategory);
            await repository.SaveAsync();
            return true;
        }
    }
}
