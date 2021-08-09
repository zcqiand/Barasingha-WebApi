namespace UltraNuke.Barasingha.Novel.API.Application.Queries
{
    using Dapper;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.Novel.API.Application.DTO;
    using UltraNuke.CommonMormon.Utils.WebApi;

    public class MainCategoryQueries : QueriesBase
    {
        public MainCategoryQueries(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<PaginatedItems<MainCategoryDTO>> Query(string name, int pageIndex, int pageSize)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Name", name);
            param.Add("@PageIndex", pageIndex);
            param.Add("@PageSize", pageSize);
            param.Add("@Total", 0, DbType.Int32, ParameterDirection.Output);

            using (var connection = OpenConnection())
            {
                var result = connection.QueryMultiple("MainCategory_Query", param, commandType: CommandType.StoredProcedure);
                var list = result.Read<MainCategoryDTO>().ToList();
                var total = param.Get<int>("@Total");
                return new PaginatedItems<MainCategoryDTO>(total, list);
            }
        }

        public async Task<List<MainCategoryForGetSelectDTO>> QuerySelect()
        {
            using (var connection = OpenConnection())
            {
                var result = connection.QueryMultiple("MainCategory_QuerySelect", null, commandType: CommandType.StoredProcedure);
                var list = result.Read<MainCategoryForGetSelectDTO>().ToList();
                return list;
            }
        }

        public async Task<List<MainCategoryDTO>> QueryAll()
        {
            using (var connection = OpenConnection())
            {
                var result = connection.QueryMultiple("MainCategory_QueryAll", null, commandType: CommandType.StoredProcedure);
                var list = result.Read<MainCategoryDTO>().ToList();
                return list;
            }
        }

        public async Task<MainCategoryDTO> Get(Guid id)
        {
            using (var connection = OpenConnection())
            {
                const string query = "SELECT * FROM dbo.N_MainCategory WHERE Id = @Id";
                return connection.Query<MainCategoryDTO>(query, new { Id = id }).SingleOrDefault();
            }
        }
    }
}
