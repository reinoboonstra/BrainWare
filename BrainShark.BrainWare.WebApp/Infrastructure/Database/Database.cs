using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace BrainShark.BrainWare.WebApp.Infrastructure.Database
{
    public class Database : IDatabase
    {
        private readonly SqlConnection _connection;

        public Database()
        {
            _connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["BrainWareConnectionString"].ConnectionString);
            _connection.Open();
        }

        public IDataReader ExecuteReader(string query)
        {
            var sqlQuery = new SqlCommand(query, _connection);

            return sqlQuery.ExecuteReader();
        }

        public int ExecuteNonQuery(string query)
        {
            var sqlQuery = new SqlCommand(query, _connection);

            return sqlQuery.ExecuteNonQuery();
        }
    }
}