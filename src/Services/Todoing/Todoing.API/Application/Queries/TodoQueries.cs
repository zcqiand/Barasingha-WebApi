namespace UltraNuke.Barasingha.Todoing.API.Application.Queries
{
    using Dapper;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.Todoing.API.Application.DTO;
    using UltraNuke.CommonMormon.Utils.WebApi;

    public class TodoQueries : QueriesBase
    {
        public TodoQueries(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<PaginatedItems<TodoDTO>> Query(string name, int pageIndex, int pageSize)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Name", name);
            param.Add("@PageIndex", pageIndex);
            param.Add("@PageSize", pageSize);
            param.Add("@Total", 0, DbType.Int32, ParameterDirection.Output);

            using (var connection = OpenConnection())
            {
                var result = connection.QueryMultiple("Todo_Query", param, commandType: CommandType.StoredProcedure);
                var list = result.Read<TodoDTO>().ToList();
                var total = param.Get<int>("@Total");
                return new PaginatedItems<TodoDTO>(total, list);
            }
        }

        public async Task<TodoDTO> Get(Guid id)
        {
            using (var connection = OpenConnection())
            {
                const string query = "SELECT * FROM dbo.T_Todo WHERE Id = @Id";
                return connection.Query<TodoDTO>(query, new { Id = id }).SingleOrDefault();
            }
        }
    }
}
