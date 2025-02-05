using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Employee_Management_System.Infrastructure.Data
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly string _connectionString;
        public SqlDataAccess(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection")!;
        }
        public string ConnectionString => _connectionString;
        public async Task<IEnumerable<T>> GetData<T, P>(string sql, P parameters)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            return await connection.QueryAsync<T>(sql, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task SaveData<T>(string sql, T parameters)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            await connection.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
