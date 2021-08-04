namespace UltraNuke.Barasingha.PermissionManagement.API.Application.Queries
{
    using AutoMapper;
    using Dapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.PermissionManagement.API.Application.DTO;

    public class MenuQueries : QueriesBase
    {
        private readonly IMapper mapper;
        public MenuQueries(string constr, IMapper mapper) : base(constr)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<MenuForGetDTO> Get(Guid id)
        {
            using (var connection = OpenConnection())
            {
                const string query = "SELECT * FROM dbo.PM_Menu WHERE Id = @Id";
                return connection.Query<MenuForGetDTO>(query, new { Id = id }).SingleOrDefault();
            }
        }

        public async Task<List<MenuForGetTreeTableDTO>> GetTreeTable()
        {
            var menus = GetTree();
            menus = menus.Where(w => w.Level == 1).OrderBy(o => o.FullSortNo).ToList();

            var menusForDTO = mapper.Map<List<MenuForGetTreeTableDTO>>(menus);
            return menusForDTO;
        }

        public async Task<List<MenuForGetTreeSelectDTO>> GetTreeSelect()
        {
            var menus = GetTree();
            menus = menus.Where(w => w.IsRootNode).OrderBy(o => o.FullSortNo).ToList();

            var menusForDTO = mapper.Map<List<MenuForGetTreeSelectDTO>>(menus);
            return menusForDTO;
        }

        private List<MenuForGetDTO> GetTree()
        {
            List<MenuForGetDTO> menus;
            using (var connection = OpenConnection())
            {
                const string query = "SELECT * FROM dbo.PM_Menu";
                menus = connection.Query<MenuForGetDTO>(query).ToList();
                menus = Traverse(menus, menus);
            }

            return menus;
        }

        private List<MenuForGetDTO> Traverse(List<MenuForGetDTO> allNodes, List<MenuForGetDTO> nodes)
        {
            foreach (var node in nodes)
            {
                var childNodes = allNodes.Where(x => x.ParentNodeId == node.Id).ToList();
                node.ChildNodes = childNodes;
                node.ChildNodes = Traverse(allNodes, node.ChildNodes);
            }
            return nodes;
        }
    }
}
