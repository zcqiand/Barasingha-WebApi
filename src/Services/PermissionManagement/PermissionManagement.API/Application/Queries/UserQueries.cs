namespace UltraNuke.Barasingha.PermissionManagement.API.Application.Queries
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.PermissionManagement.API.Application.DTO;
    using UltraNuke.CommonMormon.Utils.Extensions;
    using UltraNuke.CommonMormon.Utils.WebApi;

    public class UserQueries
    {
        //private readonly PermissionQueriesContext context;
        //public UserQueries(PermissionQueriesContext context)
        //{
        //    this.context = context;
        //}

        //public async Task<PaginatedItems<UserDTO>> Query(string nickName, int pageIndex, int pageSize)
        //{
        //    Expression<Func<UserDTO, bool>> filter = w => true;
        //    if (!string.IsNullOrWhiteSpace(nickName))
        //    {
        //        filter = filter.And(w => w.NickName.Contains(nickName));
        //    }

        //    var total = await context.Users
        //        .AsNoTracking()
        //        .CountAsync();

        //    var users = await context.Users
        //        .AsNoTracking()
        //        .OrderBy(o => o.Id)
        //        .Skip(pageSize * (pageIndex - 1))
        //        .Take(pageSize)
        //        .ToListAsync();

        //    return new PaginatedItems<UserDTO>(total, users);
        //}

        //public async Task<List<UserDTO>> QueryAll()
        //{
        //    var users = await context.Users
        //        .AsNoTracking()
        //        .OrderBy(o => o.Id)
        //        .ToListAsync();

        //    return users;
        //}

        //public async Task<UserDTO> Get(Guid id)
        //{
        //    var user = await context.Users
        //        .AsNoTracking()
        //        .Include(b => b.Roles)
        //        .Where(w => w.Id == id)
        //        .SingleOrDefaultAsync();

        //    return user;
        //}
    }
}
