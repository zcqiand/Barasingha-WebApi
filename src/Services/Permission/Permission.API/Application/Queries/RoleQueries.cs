namespace UltraNuke.Barasingha.Permission.API.Application.Queries
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.Permission.API.Application.DTO;
    using UltraNuke.Barasingha.Permission.API.Infrastructure;
    using UltraNuke.CommonMormon.Utils.Extensions;
    using UltraNuke.CommonMormon.Utils.WebApi;

    public class RoleQueries
    {
        private readonly PermissionQueriesContext context;
        public RoleQueries(PermissionQueriesContext context)
        {
            this.context = context;
        }

        public async Task<PaginatedItems<RoleDTO>> Query(string name, int pageIndex, int pageSize)
        {
            Expression<Func<RoleDTO, bool>> filter = w => true;
            if (!string.IsNullOrWhiteSpace(name))
            {
                filter = filter.And(w => w.Name.Contains(name));
            }

            var total = await context.Roles
                .AsNoTracking()
                .Where(filter)
                .CountAsync();

            var roles = await context.Roles
                .AsNoTracking()
                .Where(filter)
                .OrderBy(o => o.Id)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedItems<RoleDTO>(total, roles);
        }

        public async Task<List<RoleDTO>> QueryAll()
        {
            var roles = await context.Roles
                .AsNoTracking()
                .OrderBy(o => o.No)
                .ToListAsync();

            return roles;
        }

        public async Task<RoleDTO> Get(Guid id)
        {
            var role = await context.Roles
                .AsNoTracking()
                .Include(b => b.Menus)
                .Where(w => w.Id == id)
                .SingleOrDefaultAsync();

            return role;
        }
    }
}
