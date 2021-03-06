using Microsoft.Data.SqlClient;
using System;

namespace UltraNuke.Barasingha.PermissionManagement.API.Application.Queries
{
    public class QueriesBase
    {
        protected string connectionString = string.Empty;

        public QueriesBase(string constr)
        {
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
