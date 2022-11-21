using Dapper;
using Microsoft.Data.SqlClient;

namespace Inlämning1.Services

{
        public class SqlHandler<T> where T : class
        {

            private readonly string connectionString = "Server=tcp:sql-api2.database.windows.net,1433;Initial Catalog=Todo-db;Persist Security Info=False;User ID=SqlAdmin;Password=admin0608!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            public async Task CreateAsync(string query, T entity)
            {
                using var conn = new SqlConnection(connectionString);
                await conn.ExecuteAsync(query, entity);
            }

            // Get from db
            public async Task<IEnumerable<object>> GetAsync(string query)
            {
                using var conn = new SqlConnection(connectionString);
                return await conn.QueryAsync<object>(query);
            }

        }
    }