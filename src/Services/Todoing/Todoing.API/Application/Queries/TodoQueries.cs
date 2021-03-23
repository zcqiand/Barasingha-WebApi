namespace UltraNuke.Barasingha.Todoing.API.Application.Queries
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.Todoing.API.Application.DTO;
    using UltraNuke.Barasingha.Todoing.API.Infrastructure;
    using UltraNuke.CommonMormon.Utils.WebApi;

    public class TodoQueries
    {
        private readonly TodoingQueriesContext context;
        public TodoQueries(TodoingQueriesContext context)
        {
            this.context = context;
        }

        public async Task<PaginatedItems<TodoDTO>> Query(int pageIndex, int pageSize)
        {
            var total = await context.Todos
                .AsNoTracking()
                .CountAsync();

            var todos = await context.Todos
                .AsNoTracking()
                .OrderBy(o => o.Id)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedItems<TodoDTO>(total, todos);
        }

        public async Task<TodoDTO> Get(Guid id)
        {
            var todo = await context.Todos.FindAsync(id);
            return todo;
        }
    }
}
