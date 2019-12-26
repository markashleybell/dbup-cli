using System;
using System.Reflection;
using DbUp;

namespace dbup
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            if (args.Length != 2)
            {
                var currentVersion = Assembly.GetEntryAssembly().GetName().Version;

                Console.WriteLine("dbup-cli " + currentVersion);
                Console.WriteLine("Usage: dbup <scriptsfolder> <connectionstring>");

                return -1;
            }

            var scriptsFolder = args[0];
            var connectionString = args[1];

            var upgrader = DeployChanges.To
                .SqlDatabase(connectionString)
                .WithScriptsFromFileSystem(scriptsFolder)
                .LogToConsole()
                .LogScriptOutput()
                .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();

                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Database upgrade succesful");
            Console.ResetColor();

            return 0;
        }
    }
}
