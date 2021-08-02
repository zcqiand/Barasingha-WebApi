namespace UltraNuke.Barasingha.AlarmManagement.API.Application.Queries
{
    using Dapper;
    using Microsoft.Data.SqlClient;
    using System;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.AlarmManagement.API.Application.DTO;
    using UltraNuke.CommonMormon.Utils.WebApi;

    public class AlarmQueries
    {
        private string connectionString = string.Empty;

        public AlarmQueries(string constr)
        {
            connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public async Task<PaginatedItems<AlarmForQueryDTO>> Query(Guid? levelId, Guid? categoryId, string name, int pageIndex, int pageSize)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@LevelId", levelId);
            param.Add("@CategoryId", categoryId);
            param.Add("@Name", name);
            param.Add("@PageIndex", pageIndex);
            param.Add("@PageSize", pageSize);
            param.Add("@Total", 0, DbType.Int32, ParameterDirection.Output);

            using (var connection = OpenConnection())
            {
                var result = connection.QueryMultiple("Alarm_Query", param, commandType: CommandType.StoredProcedure);
                var list = result.Read<AlarmForQueryDTO>().ToList();
                var total = param.Get<int>("@Total");
                return new PaginatedItems<AlarmForQueryDTO>(total, list);
            }
        }

        public async Task<AlarmForGetDTO> Get(Guid id)
        {
            using (var connection = OpenConnection())
            {
                const string query = "SELECT * FROM AM_Alarm WHERE Id = @Id";
                return connection.Query<AlarmForGetDTO>(query, new { Id = id }).SingleOrDefault();
            }
        }
    }
}
