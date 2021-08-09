namespace UltraNuke.Barasingha.Novel.API.Application.Queries
{
    using Dapper;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.Novel.API.Application.DTO;
    using UltraNuke.CommonMormon.Utils.WebApi;

    public class ChapterQueries : QueriesBase
    {
        public ChapterQueries(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<PaginatedItems<ChapterForGetDTO>> Query(DateTime startUpdateTime, DateTime endUpdateTime, string name, int pageIndex, int pageSize)
        {
            endUpdateTime = endUpdateTime.AddDays(1);

            DynamicParameters param = new DynamicParameters();
            param.Add("@StartUpdateTime", startUpdateTime);
            param.Add("@EndUpdateTime", endUpdateTime);
            param.Add("@Name", name);
            param.Add("@PageIndex", pageIndex);
            param.Add("@PageSize", pageSize);
            param.Add("@Total", 0, DbType.Int32, ParameterDirection.Output);

            using (var connection = OpenConnection())
            {
                var result = connection.QueryMultiple("Chapter_Query", param, commandType: CommandType.StoredProcedure);
                var list = result.Read<ChapterForGetDTO>().ToList();
                var total = param.Get<int>("@Total");
                return new PaginatedItems<ChapterForGetDTO>(total, list);
            }
        }

        public async Task<ChapterForGetDTO> Get(Guid id)
        {
            using (var connection = OpenConnection())
            {
                const string query = "SELECT * FROM dbo.N_Chapter WHERE Id = @Id";
                return connection.Query<ChapterForGetDTO>(query, new { Id = id }).SingleOrDefault();
            }
        }
    }
}
