using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessoApp.DbScript
{
    internal class ScriptExecute
    {
        public static void ExecuteSqlScriptsFromFolder(string connectionString, string scriptsFolder)
        {
            if (!Directory.Exists(scriptsFolder))
            {
                Console.WriteLine($"Scripts folder not found: {scriptsFolder}");
                return;
            }

            // Get all SQL files in the folder
            string[] sqlFiles = Directory.GetFiles(scriptsFolder, "*.sql");

            if (sqlFiles.Length == 0)
            {
                Console.WriteLine($"No SQL files found in folder: {scriptsFolder}");
                return;
            }

            try
            {
                using SqlConnection connection = new(connectionString);
                connection.Open();

                foreach (string file in sqlFiles)
                {
                    Console.WriteLine($"Executing script: {Path.GetFileName(file)}");
                    string script = File.ReadAllText(file);

                    // Split script by GO statements
                    string[] commands = script.Split(new[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string commandText in commands)
                    {
                        if (string.IsNullOrWhiteSpace(commandText)) continue;

                        using SqlCommand command = new SqlCommand(commandText, connection);
                        command.ExecuteNonQuery();
                    }
                    Console.WriteLine($"Finished: {Path.GetFileName(file)}");
                }
                Console.WriteLine("All scripts executed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error executing scripts: " + ex.Message);
            }
        }
    }
}