namespace UltraNuke.Barasingha.Novel.API.Application.Queries
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.Novel.API.Application.DTO;
    using UltraNuke.Barasingha.Novel.API.Infrastructure;
    using UltraNuke.CommonMormon.Utils.WebApi;

    public class SubCategoryQueries
    {
        private readonly NovelQueriesContext context;
        public SubCategoryQueries(NovelQueriesContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PaginatedItems<SubCategoryDTO>> Query(int pageIndex, int pageSize)
        {
            var total = await context.SubCategories
                .AsNoTracking()
                .CountAsync();

            var subCategorys = await context.SubCategories
                .AsNoTracking()
                .OrderBy(o => o.Id)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedItems<SubCategoryDTO>(total, subCategorys);
        }

        public async Task<List<SubCategoryDTO>> QueryAll()
        {
            var subCategorys = await context.SubCategories
                .AsNoTracking()
                .Include(b => b.MainCategory)
                .OrderBy(o => o.Id)
                .ToListAsync();

            return subCategorys;
        }

        public async Task<SubCategoryDTO> Get(Guid id)
        {
            var subCategory = await context.SubCategories.FindAsync(id);
            return subCategory;
        }
    }
}
