using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance.Helpers
{
    public class FileHelper
    {
        private static readonly string PerformanceRootDirectory = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + @"../../../../../../../");

        public static string GetPowerShellScriptPath(string fileName)
        {
            return Path.Combine(PerformanceRootDirectory, "PowerShell", fileName);
        }

        public static string GetDataFilePath(string fileName)
        {
            return Path.Combine(PerformanceRootDirectory, "Data", fileName);
        }

        public static void GenerateFile(string fullFilePath, long sizeInBytes)
        {
            byte[] testData = new byte[sizeInBytes];
            Random random = new();
            random.NextBytes(testData);
            File.WriteAllBytes(fullFilePath, testData);
        }
    }

    public static class Constants
    {
        public static readonly long KB = (int)Math.Pow(2, 10), MB = (int)Math.Pow(2, 20);
    }
}
