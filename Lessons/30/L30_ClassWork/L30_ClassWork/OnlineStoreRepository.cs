using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace L30_ClassWork
{
    public partial class OnlineStoreRepository
    {
        private readonly string _connectionString;

        public OnlineStoreRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetOpenedSqlConnection()
        {
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            return sqlConnection;
        }
    }
}
