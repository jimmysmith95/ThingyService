using SimpleMigrations;
using SimpleMigrations.DatabaseProvider;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThingyService
{
    class Program
    {
        static void Main(string[] args)
        {
            var migrationsAssembly = typeof(Program).Assembly;
            using (var connection = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Database=Thingy;Integrated Security=SSPI;"))
            {
                var databaseProvider = new MssqlDatabaseProvider(connection);
                var migrator = new SimpleMigrator(migrationsAssembly, databaseProvider);
                migrator.Load();
                migrator.MigrateToLatest();
            }
        }
    }
}
