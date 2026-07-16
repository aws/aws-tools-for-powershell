using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AWSPowerShellGenerator.Utils
{
    /// <summary>
    /// Log tracing and output for the generators.
    /// Supports dual output: minimal console logging with verbose file logging.
    /// When a log file path is provided, all messages (Log, LogConsole, LogError) are written to the file.
    /// Console output is controlled per method:
    ///   - Log(): console only if Verbose=true (verbose detail)
    ///   - LogConsole(): always written to console (high-level progress)
    ///   - LogError(): always written to console (errors)
    /// </summary>
    internal class BasicLogger : IDisposable
    {
        public class Error
        {
            public string Message { get; set; }
            public Exception Exception { get; set; }
        }

        private readonly object _errorLock = new object();
        List<Error> Errors { get; set; }

        public bool Verbose { get; private set; }

        /// <summary>
        /// Thread-safe file writer. When non-null, all log output is written to the file.
        /// Wrapped with TextWriter.Synchronized for thread safety with Parallel.ForEach.
        /// </summary>
        private TextWriter _fileWriter;

        /// <summary>
        /// Creates a logger with optional file output.
        /// </summary>
        /// <param name="verbose">When true, Log() messages are also written to the console.</param>
        /// <param name="logFilePath">Optional file path. When provided, all messages are written to this file.</param>
        public BasicLogger(bool verbose, string logFilePath = null)
        {
            Errors = new List<Error>();
            Verbose = verbose;

            if (!string.IsNullOrEmpty(logFilePath))
            {
                try
                {
                    var dir = Path.GetDirectoryName(logFilePath);
                    if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                        Directory.CreateDirectory(dir);

                    var fileStream = new FileStream(logFilePath, FileMode.Create, FileAccess.Write, FileShare.Read);
                    _fileWriter = TextWriter.Synchronized(new StreamWriter(fileStream) { AutoFlush = true });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Warning: Could not create log file '{logFilePath}': {ex.Message}. Continuing without file logging.");
                    _fileWriter = null;
                }
            }
        }

        /// <summary>
        /// Verbose detail: always written to file, console only if Verbose=true.
        /// </summary>
        public void Log()
        {
            _fileWriter?.WriteLine();
            if (Verbose)
                Console.WriteLine();
        }

        /// <summary>
        /// Verbose detail: always written to file, console only if Verbose=true.
        /// </summary>
        public void Log(string format, params object[] args)
        {
            var message = string.Format(format, args);
            _fileWriter?.WriteLine(message);
            if (Verbose)
                Console.WriteLine(message);
        }

        /// <summary>
        /// High-level progress: always written to both console and file.
        /// </summary>
        public void LogConsole(string format, params object[] args)
        {
            var message = string.Format(format, args);
            _fileWriter?.WriteLine(message);
            Console.WriteLine(message);
        }

        public void LogError(string message, params object[] args)
        {
            var error = new Error { Message = string.Format(message, args) };
            lock (_errorLock)
            {
                Errors.Add(error);
            }
            var errorMessage = "Error: " + error.Message;
            _fileWriter?.WriteLine(errorMessage);
            // helpful whilst debugging to see this immediately too
            Console.WriteLine(errorMessage);
        }

        public void LogError(Exception e)
        {
            lock (_errorLock)
            {
                Errors.Add(new Error { Exception = e });
            }
            var errorMessage = "Exception: " + e.Message;
            _fileWriter?.WriteLine(errorMessage);
            // helpful whilst debugging to see this immediately too
            Console.WriteLine(errorMessage);
        }

        public void LogError(Exception e, string message, params object[] args)
        {
            var error = new Error { Message = string.Format(message, args), Exception = e };
            lock (_errorLock)
            {
                Errors.Add(error);
            }
            var errorMessage = "Error: " + error.Message;
            _fileWriter?.WriteLine(errorMessage);
            // helpful whilst debugging to see this immediately too
            Console.WriteLine(errorMessage);
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

        public void Dispose()
        {
            if (_fileWriter != null)
            {
                _fileWriter.Flush();
                _fileWriter.Dispose();
                _fileWriter = null;
            }
        }
    }
}
