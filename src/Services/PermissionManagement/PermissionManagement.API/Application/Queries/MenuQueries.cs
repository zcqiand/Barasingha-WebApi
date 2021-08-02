namespace UltraNuke.Barasingha.PermissionManagement.API.Application.Queries
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.PermissionManagement.API.Application.DTO;
    using UltraNuke.CommonMormon.Utils.WebApi;

    public class MenuQueries
    {
        //private readonly PermissionQueriesContext context;
        //private readonly IMapper mapper;
        //public MenuQueries(PermissionQueriesContext context, IMapper mapper)
        //{
        //    this.context = context ?? throw new ArgumentNullException(nameof(context));
        //    this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        //}

        //public async Task<PaginatedItems<MenuDTO>> Query(int pageIndex, int pageSize)
        //{
        //    Expression<Func<MenuDTO, bool>> filter = w => w.IsLeafNode == false && w.IsRootNode == false;

        //    var total = await context.Menus
        //        .AsNoTracking()
        //        .Where(filter)
        //        .CountAsync();

        //    var menus = await context.Menus
        //        .Include(b=>b.ChildNodes)
        //        .AsNoTracking()
        //        .Where(filter)
        //        .OrderBy(o => o.Id)
        //        .Skip(pageSize * (pageIndex - 1))
        //        .Take(pageSize)
        //        .ToListAsync();

        //    return new PaginatedItems<MenuDTO>(total, menus);
        //}

        //public async Task<List<MenuForGetTreeDTO>> GetTree()
        //{
        //    IList<MenuDTO> menus = await context.Menus.ToListAsync();
        //    menus = Traverse(menus, menus);
        //    menus = menus.Where(w => w.Level == 1).OrderBy(o => o.FullSortNo).ToList();

        //    var menusForDTO = mapper.Map<List<MenuForGetTreeDTO>>(menus);

        //    return menusForDTO;
        //}

        //public async Task<List<MenuForGetSelectDTO>> GetSelect()
        //{
        //    IList<MenuDTO> menus = await context.Menus.ToListAsync();
        //    menus = Traverse(menus, menus);
        //    menus = menus.Where(w => w.IsRootNode).OrderBy(o => o.FullSortNo).ToList();

        //    var menusForDTO = mapper.Map<List<MenuForGetSelectDTO>>(menus);

        //    return menusForDTO;
        //}

        //public async Task<MenuDTO> Get(Guid id)
        //{
        //    var menu = await context.Menus.FindAsync(id);
        //    return menu;
        //}

        //private IList<MenuDTO> Traverse(IList<MenuDTO> allNodes, IList<MenuDTO> nodes)
        //{
        //    foreach (var node in nodes)
        //    {
        //        var childNodes = allNodes.Where(x => x.ParentNodeId == node.Id).ToList();
        //        node.ChildNodes = childNodes;
        //        node.ChildNodes = Traverse(allNodes, node.ChildNodes);
        //    }
        //    return nodes;
        //}
    }
}
