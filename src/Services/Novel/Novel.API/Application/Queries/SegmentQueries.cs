namespace UltraNuke.Barasingha.Novel.API.Application.Queries
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.Novel.API.Application.DTO;
    using UltraNuke.Barasingha.Novel.API.Infrastructure;
    using UltraNuke.CommonMormon.Utils.WebApi;

    public class SegmentQueries
    {
        private readonly NovelQueriesContext context;
        public SegmentQueries(NovelQueriesContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PaginatedItems<SegmentDTO>> Query(int pageIndex, int pageSize)
        {
            var total = await context.Segments
                .AsNoTracking()
                .CountAsync();

            var segments = await context.Segments
                .AsNoTracking()
                .OrderBy(o => o.Id)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedItems<SegmentDTO>(total, segments);
        }

        public async Task<SegmentDTO> Get(Guid id)
        {
            var segment = await context.Segments.FindAsync(id);
            return segment;
        }
    }
}
