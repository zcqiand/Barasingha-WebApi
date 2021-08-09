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

    public class SegmentQueries : QueriesBase
    {
        public SegmentQueries(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<PaginatedItems<SegmentForGetDTO>> Query(int pageIndex, int pageSize)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@PageIndex", pageIndex);
            param.Add("@PageSize", pageSize);
            param.Add("@Total", 0, DbType.Int32, ParameterDirection.Output);

            using (var connection = OpenConnection())
            {
                var result = connection.QueryMultiple("Segment_Query", param, commandType: CommandType.StoredProcedure);
                var list = result.Read<SegmentForGetDTO>().ToList();
                var total = param.Get<int>("@Total");
                return new PaginatedItems<SegmentForGetDTO>(total, list);
            }
        }

        public async Task<SegmentForGetDTO> Get(Guid id)
        {
            using (var connection = OpenConnection())
            {
                const string query = "SELECT * FROM dbo.N_Segment WHERE Id = @Id";
                return connection.Query<SegmentForGetDTO>(query, new { Id = id }).SingleOrDefault();
            }
        }
    }
}
