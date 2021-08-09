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

    public class SubCategoryQueries : QueriesBase
    {
        public SubCategoryQueries(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<PaginatedItems<SubCategoryForGetDTO>> Query(int pageIndex, int pageSize)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@PageIndex", pageIndex);
            param.Add("@PageSize", pageSize);
            param.Add("@Total", 0, DbType.Int32, ParameterDirection.Output);

            using (var connection = OpenConnection())
            {
                var result = connection.QueryMultiple("SubCategory_Query", param, commandType: CommandType.StoredProcedure);
                var list = result.Read<SubCategoryForGetDTO>().ToList();
                var total = param.Get<int>("@Total");
                return new PaginatedItems<SubCategoryForGetDTO>(total, list);
            }
        }

        public async Task<List<SubCategoryForGetDTO>> QueryAll()
        {
            using (var connection = OpenConnection())
            {
                var result = connection.QueryMultiple("SubCategory_QueryAll", null, commandType: CommandType.StoredProcedure);
                var list = result.Read<SubCategoryForGetDTO>().ToList();
                return list;
            }
        }

        public async Task<SubCategoryForGetDTO> Get(Guid id)
        {
            using (var connection = OpenConnection())
            {
                const string query = "SELECT * FROM dbo.N_SubCategory WHERE Id = @Id";
                return connection.Query<SubCategoryForGetDTO>(query, new { Id = id }).SingleOrDefault();
            }
        }
    }
}
