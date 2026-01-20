using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessoApp.DbScripts
{
    public class Program
    {
        public static void Initialize(string connectionString)
        {
            //DatabaseInitializer.CreateTables(connectionString);
            Console.WriteLine("✅ Database Initialized Successfully!");
        }

#if DEBUG
        // This Main is only used when debugging the library
        public static void Main(string[] args)
        {
            string connectionString = args.Length > 0
                ? args[0]
                : "Server=.;Database=MessManagementDB;Trusted_Connection=True;TrustServerCertificate=True;";

            Console.WriteLine("Running Class Library independently...");
            Initialize(connectionString);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
#endif
    }
}
