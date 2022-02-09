using System.Data;

namespace BrainShark.BrainWare.WebApp.Infrastructure.Database
{
    public interface IDatabase
    {
        IDataReader ExecuteReader(string query);

        int ExecuteNonQuery(string query);
    }
}