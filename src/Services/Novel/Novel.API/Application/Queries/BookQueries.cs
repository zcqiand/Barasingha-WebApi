namespace UltraNuke.Barasingha.Novel.API.Application.Queries
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.Novel.API.Application.DTO;
    using UltraNuke.Barasingha.Novel.API.Infrastructure;
    using UltraNuke.CommonMormon.Utils.WebApi;

    public class BookQueries
    {
        private readonly NovelQueriesContext context;
        public BookQueries(NovelQueriesContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PaginatedItems<BookDTO>> Query(int pageIndex, int pageSize)
        {
            var total = await context.Books
                .AsNoTracking()
                .CountAsync();

            var books = await context.Books
                .AsNoTracking()
                .OrderBy(o => o.Id)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedItems<BookDTO>(total, books);
        }

        public async Task<BookDTO> Get(Guid id)
        {
            var book = await context.Books.FindAsync(id);
            return book;
        }
    }
}
