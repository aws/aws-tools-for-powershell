using System;

namespace AWSPowerShellGenerator
{
    /// <summary>
    /// Console driver for the AWS PowerShell tools generator.
    /// </summary>
    class Program
    {
        static int Main(string[] args)
        {
            var returnCode = -1;
            var commandArguments = CommandArguments.Parse(args);
            if (!string.IsNullOrEmpty(commandArguments.Error))
            {
                Console.WriteLine(commandArguments.Error);
                return returnCode;
            }

            try
            {
                var generator = new Generator();
                generator.Execute(commandArguments.ParsedOptions);
                Console.WriteLine("AWSPowerShell generation completed in {0} minute {1} seconds", generator.Duration.Minutes, generator.Duration.Seconds);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                Console.WriteLine(e.StackTrace);
            }

            if (commandArguments.ParsedOptions.WaitOnExit)
            {
                Console.WriteLine("Press a key to exit...");
                Console.ReadKey();
            }

            return returnCode;
        }
    }
}
