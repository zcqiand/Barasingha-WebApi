namespace UltraNuke.Barasingha.Novel.API.Application.Queries
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.Novel.API.Application.DTO;
    using UltraNuke.Barasingha.Novel.API.Infrastructure;
    using UltraNuke.CommonMormon.Utils.Extensions;
    using UltraNuke.CommonMormon.Utils.WebApi;

    public class MainCategoryQueries
    {
        private readonly NovelQueriesContext context;
        private readonly IMapper mapper;
        public MainCategoryQueries(NovelQueriesContext context, IMapper mapper)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PaginatedItems<MainCategoryDTO>> Query(string name, int pageIndex, int pageSize)
        {
            Expression<Func<MainCategoryDTO, bool>> filter = w => true;
            if (!string.IsNullOrWhiteSpace(name))
            {
                filter = filter.And(w => w.Name.Contains(name));
            }

            var total = await context.MainCategories
                .AsNoTracking()
                .Where(filter)
                .CountAsync();

            var mainCategorys = await context.MainCategories
                .AsNoTracking()
                .Where(filter)
                .OrderBy(o => o.Id)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedItems<MainCategoryDTO>(total, mainCategorys);
        }

        public async Task<List<MainCategoryForGetSelectDTO>> QuerySelect()
        {
            var mainCategories = await context.MainCategories
                .AsNoTracking()
                .Include(b => b.SubCategories)
                .OrderBy(o => o.No)
                .ToListAsync();

            var mainCategoriesForDTO = mapper.Map<List<MainCategoryForGetSelectDTO>>(mainCategories);
            return mainCategoriesForDTO;
        }

        public async Task<List<MainCategoryDTO>> QueryAll()
        {
            var mainCategories = await context.MainCategories
                .AsNoTracking()
                .OrderBy(o => o.No)
                .ToListAsync();

            return mainCategories;
        }

        public async Task<MainCategoryDTO> Get(Guid id)
        {
            var mainCategory = await context.MainCategories.FindAsync(id);
            return mainCategory;
        }
    }
}
