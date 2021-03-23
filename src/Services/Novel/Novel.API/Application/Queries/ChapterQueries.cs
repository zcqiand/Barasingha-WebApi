namespace UltraNuke.Barasingha.Novel.API.Application.Queries
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.Novel.API.Application.DTO;
    using UltraNuke.Barasingha.Novel.API.Infrastructure;
    using UltraNuke.CommonMormon.Utils.Extensions;
    using UltraNuke.CommonMormon.Utils.WebApi;

    public class ChapterQueries
    {
        private readonly NovelQueriesContext context;
        public ChapterQueries(NovelQueriesContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PaginatedItems<ChapterDTO>> Query(DateTime startUpdateTime, DateTime endUpdateTime, string name, int pageIndex, int pageSize)
        {
            endUpdateTime = endUpdateTime.AddDays(1);
            Expression<Func<ChapterDTO, bool>> filter = w => w.UpdateTime >= startUpdateTime && w.UpdateTime < endUpdateTime;
            if (!string.IsNullOrWhiteSpace(name))
            {
                filter = filter.And(w => w.Name.Contains(name));
            }

            var total = await context.Chapters
                .AsNoTracking()
                .Where(filter)
                .CountAsync();

            var chapters = await context.Chapters
                .AsNoTracking()
                .Include(b => b.Segment)
                .Where(filter)
                .OrderBy(o => o.Id)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedItems<ChapterDTO>(total, chapters);
        }

        public async Task<ChapterDTO> Get(Guid id)
        {
            var chapter = await context.Chapters.FindAsync(id);
            return chapter;
        }
    }
}
