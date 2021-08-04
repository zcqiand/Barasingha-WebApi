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

    public class UserQueries : QueriesBase
    {
        public UserQueries(string constr) : base(constr)
        {
        }

        public async Task<PaginatedItems<UserForQueryDTO>> Query(string nickName, int pageIndex, int pageSize)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@NickName", nickName);
            param.Add("@PageIndex", pageIndex);
            param.Add("@PageSize", pageSize);
            param.Add("@Total", 0, DbType.Int32, ParameterDirection.Output);

            using (var connection = OpenConnection())
            {
                var result = connection.QueryMultiple("User_Query", param, commandType: CommandType.StoredProcedure);
                var list = result.Read<UserForQueryDTO>().ToList();
                var total = param.Get<int>("@Total");
                return new PaginatedItems<UserForQueryDTO>(total, list);
            }
        }

        public async Task<List<UserForQueryDTO>> QueryAll()
        {
            using (var connection = OpenConnection())
            {
                var list = connection.Query<UserForQueryDTO>("User_QueryAll", commandType: CommandType.StoredProcedure).ToList();
                return list;
            }
        }

        public async Task<UserForGetDTO> Get(Guid id)
        {
            using (var connection = OpenConnection())
            {
                const string query = "SELECT * FROM dbo.PM_User WHERE Id = @Id";
                return connection.Query<UserForGetDTO>(query, new { Id = id }).SingleOrDefault();
            }
        }
    }
}
