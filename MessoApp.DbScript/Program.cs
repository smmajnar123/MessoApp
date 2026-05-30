using MessoApp.DbScript;
using MessoApp.Shared.Common;
using System;
using System.Data.SqlClient;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string scriptsFolder = Path.Combine(baseDir, @"..\..\..\Scripts\");
            scriptsFolder = Path.GetFullPath(scriptsFolder);
            ScriptExecute.ExecuteSqlScriptsFromFolder(AppSettings.ConnectionString, scriptsFolder);
        }catch(Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
