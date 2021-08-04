namespace UltraNuke.Barasingha.PermissionManagement.API.Application.Queries
{
    using Dapper;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.PermissionManagement.API.Application.DTO;
    using UltraNuke.CommonMormon.Utils.WebApi;

    public class RoleQueries : QueriesBase
    {
        public RoleQueries(string constr) : base(constr)
        {
        }

        public async Task<PaginatedItems<RoleForQueryDTO>> Query(string name, int pageIndex, int pageSize)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Name", name);
            param.Add("@PageIndex", pageIndex);
            param.Add("@PageSize", pageSize);
            param.Add("@Total", 0, DbType.Int32, ParameterDirection.Output);

            using (var connection = OpenConnection())
            {
                var result = connection.QueryMultiple("Role_Query", param, commandType: CommandType.StoredProcedure);
                var list = result.Read<RoleForQueryDTO>().ToList();
                var total = param.Get<int>("@Total");
                return new PaginatedItems<RoleForQueryDTO>(total, list);
            }
        }

        public async Task<List<RoleForQueryDTO>> QueryAll()
        {
            using (var connection = OpenConnection())
            {
                var list = connection.Query<RoleForQueryDTO>("Role_QueryAll", commandType: CommandType.StoredProcedure).ToList();
                return list;
            }
        }

        public async Task<RoleForGetDTO> Get(Guid id)
        {
            using (var connection = OpenConnection())
            {
                const string query = "SELECT * FROM dbo.PM_Role WHERE Id = @Id";
                return connection.Query<RoleForGetDTO>(query, new { Id = id }).SingleOrDefault();
            }
        }
    }
}
