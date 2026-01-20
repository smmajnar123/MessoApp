using MessoApp.DbScript;
using System;
using System.Data.SqlClient;
using System.IO;

class Program
{
    static void Main()
    {
        string connectionString = @"Server=GJSHD-0520\SQLEXPRESS;Database=TestMessDb;Trusted_Connection=True;TrustServerCertificate=True;";
        string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        string scriptsFolder = Path.Combine(baseDir, @"..\..\..\Scripts\");
        scriptsFolder = Path.GetFullPath(scriptsFolder);
        ScriptExecute.ExecuteSqlScriptsFromFolder(connectionString, scriptsFolder);
    }
}
