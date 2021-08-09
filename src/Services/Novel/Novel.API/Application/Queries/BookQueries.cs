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

    public class BookQueries : QueriesBase
    {
        public BookQueries(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<PaginatedItems<BookForQueryDTO>> Query(int pageIndex, int pageSize)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@PageIndex", pageIndex);
            param.Add("@PageSize", pageSize);
            param.Add("@Total", 0, DbType.Int32, ParameterDirection.Output);

            using (var connection = OpenConnection())
            {
                var result = connection.QueryMultiple("Book_Query", param, commandType: CommandType.StoredProcedure);
                var list = result.Read<BookForQueryDTO>().ToList();
                var total = param.Get<int>("@Total");
                return new PaginatedItems<BookForQueryDTO>(total, list);
            }
        }

        public async Task<BookForGetDTO> Get(Guid id)
        {
            using (var connection = OpenConnection())
            {
                const string query = "SELECT * FROM dbo.N_Book WHERE Id = @Id";
                return connection.Query<BookForGetDTO>(query, new { Id = id }).SingleOrDefault();
            }
        }
    }
}
