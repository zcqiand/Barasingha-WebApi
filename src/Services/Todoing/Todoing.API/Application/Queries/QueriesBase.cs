using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;

namespace UltraNuke.Barasingha.Todoing.API.Application.Queries
{
    public class QueriesBase
    {
        protected string connectionString = string.Empty;

        public QueriesBase(IConfiguration configuration)
        {
            var constr = configuration.GetConnectionString("TodoingContext");
            connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
