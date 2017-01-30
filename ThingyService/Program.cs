using SimpleMigrations;
using SimpleMigrations.DatabaseProvider;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using ThingyService.GrpcImpl;
using ThingyService.Repositories;

namespace ThingyService
{
    class Program
    {
        const int Port = 50051;
        const string ConnectionString = "Data Source=localhost\\SQLEXPRESS;Database=Thingy;Integrated Security=SSPI;";

        static void Main(string[] args)
        {
            Migrate();

            ThingyRepository repository = new ThingyRepository(ConnectionString);
            Server server = new Server
            {
                Services = { Thingy.ThingyService.BindService(new ThingyServiceImpl(repository)) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("Server listening on port " + Port);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }

        static void Migrate()
        {
            var migrationsAssembly = typeof(Program).Assembly;
            using (var connection = new SqlConnection(ConnectionString))
            {
                var databaseProvider = new MssqlDatabaseProvider(connection);
                var migrator = new SimpleMigrator(migrationsAssembly, databaseProvider);
                migrator.Load();
                migrator.MigrateToLatest();
            }
        }
    }
}
