using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AWSPowerShellGenerator.Utils
{
    /// <summary>
    /// Log tracing and output for the generators
    /// </summary>
    internal class BasicLogger
    {
        public class Error
        {
            public string Message { get; set; }
            public Exception Exception { get; set; }
        }

        List<Error> Errors { get; set; }

        public bool Verbose { get; private set; }

        public BasicLogger(bool verbose)
        {
            Errors = new List<Error>();
            Verbose = verbose;
        }

        public void Log()
        {
            if (Verbose)
                Console.WriteLine();
        }

        public void Log(string format, params object[] args)
        {
            if (Verbose)
                Console.WriteLine(string.Format(format, args));
        }

        public void LogError(string message, params object[] args)
        {
            var error = new Error { Message = string.Format(message, args) };
            Errors.Add(error);
            // helpful whilst debugging to see this immediately too
            Console.WriteLine("AWSPowerShell Generation Error: " + error.Message);
        }

        public void LogError(Exception e)
        {
            Errors.Add(new Error { Exception = e });
            // helpful whilst debugging to see this immediately too
            Console.WriteLine("AWSPowerShell Generation Exception: " + e.Message);
        }

        public void LogError(Exception e, string message, params object[] args)
        {
            var error = new Error { Message = string.Format(message, args), Exception = e };
            Errors.Add(error);
            // helpful whilst debugging to see this immediately too
            Console.WriteLine("AWSPowerShell Generation Error: " + error.Message);
        }

        public int ErrorCount
        {
            get { return Errors.Count; }
        }

        public bool HasErrors
        {
            get { return Errors.Count > 0; }
        }

        public void Output(StringWriter sw)
        {
            sw.WriteLine("Encountered {0} errors during generation.", ErrorCount);
            for (var i = 0; i < Errors.Count; i++)
            {
                var error = Errors[i];
                sw.WriteLine("Error {0} of {1}{2}", i + 1, Errors.Count, !string.IsNullOrEmpty(error.Message) ? " Message " + error.Message : "");
                if (error.Exception != null)
                    sw.WriteLine("Exception: " + error.Exception);
            }
        }
    }
}
