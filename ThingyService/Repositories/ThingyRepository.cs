using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ThingyService.Repositories
{
    class ThingyRepository
    {
        private string connectionString;

        public ThingyRepository(String connectionString)
        {
            this.connectionString = connectionString;
        }
        public async Task<Models.Thingy> Find(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<Models.Thingy> results = (List<Models.Thingy>) await connection.QueryAsync<Models.Thingy>("SELECT * FROM Thingy WHERE Id = @Id", new { Id = id });
                if (!results.Any())
                {
                    return null;
                }
                return results.First();
            }
        }
    }
}
