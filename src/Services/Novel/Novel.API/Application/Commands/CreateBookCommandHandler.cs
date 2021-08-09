namespace UltraNuke.Barasingha.Novel.API.Application.Commands
{
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.Novel.Domain.AggregatesModel;
    using UltraNuke.CommonMormon.DDD;

    public class CreateBookCommandHandler
        : IRequestHandler<CreateBookCommand, Guid>
    {
        private readonly IRepository repository;

        public CreateBookCommandHandler(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Guid> Handle(CreateBookCommand param, CancellationToken cancellationToken)
        {
            var subCategory = await repository.GetAsync<SubCategory>(param.SubCategoryId);
            var book = Book.Create(subCategory, param.No, param.Logo, param.Name, param.AuthorId, param.Introduction, param.MessageToReader);
            repository.Entry(book);
            await repository.SaveAsync();

            return book.Id;
        }
    }
}
