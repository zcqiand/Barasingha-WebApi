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

    public class UpdateBookCommandHandler
        : IRequestHandler<UpdateBookCommand, BookDTO>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public UpdateBookCommandHandler(IRepository repository, IMapper mapper)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BookDTO> Handle(UpdateBookCommand param, CancellationToken cancellationToken)
        {
            var subCategory = await repository.GetAsync<SubCategory>(param.SubCategoryId);
            var book = await repository.GetAsync<Book>(param.Id);

            book.Update(subCategory, param.No, param.Logo, param.Name, param.AuthorId, param.Introduction, param.MessageToReader);
            repository.Entry(book);
            await repository.SaveAsync();

            var bookForDTO = mapper.Map<BookDTO>(book);
            return bookForDTO;
        }
    }
}
