using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using AWSPowerShellGenerator.ServiceConfig;
using AWSPowerShellGenerator.Generators;

namespace AWSPowerShellGenerator.Writers.SourceCode
{
    public abstract class BaseSourceCodeWriter
    {
        public GeneratorOptions Options { get; protected set; }

        /// <summary>
        /// The set of namespaces we include in generated code; this collection
        /// is further extended with the service namespace, service model's namespace
        /// and additional namespaces declared in the service config.
        /// </summary>
        public static readonly string[] DefaultNamespaces =
        {
            "System",
            "System.Collections.Generic",
            "System.Linq",
            "System.Management.Automation",
            "System.Text",
            "Amazon.PowerShell.Common",
            "Amazon.Runtime"
        };

        public static void WriteSourceLicenseHeader(TextWriter writer)
        {
            var fileVersionInfo = FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);

            writer.WriteLine("/*******************************************************************************");
            writer.WriteLine(" *  {0}", fileVersionInfo.LegalCopyright);
            writer.WriteLine(" *  Licensed under the Apache License, Version 2.0 (the \"License\"). You may not use");
            writer.WriteLine(" *  this file except in compliance with the License. A copy of the License is located at");
            writer.WriteLine(" *");
            writer.WriteLine(" *  http://aws.amazon.com/apache2.0");
            writer.WriteLine(" *");
            writer.WriteLine(" *  or in the \"license\" file accompanying this file.");
            writer.WriteLine(" *  This file is distributed on an \"AS IS\" BASIS, WITHOUT WARRANTIES OR");
            writer.WriteLine(" *  CONDITIONS OF ANY KIND, either express or implied. See the License for the");
            writer.WriteLine(" *  specific language governing permissions and limitations under the License.");
            writer.WriteLine(" * *****************************************************************************");
            writer.WriteLine(" *");
            writer.WriteLine(" *  AWS Tools for Windows (TM) PowerShell (TM)");
            writer.WriteLine(" *");
            writer.WriteLine(" */");
            writer.WriteLine();
        }

        protected static void WriteNamespaces(IndentedTextWriter writer, string clientNamespace, IEnumerable<string> additionalNamespaces)
        {
            foreach (var ns in DefaultNamespaces)
            {
                writer.WriteLine("using {0};", ns);
            }

            if (additionalNamespaces != null)
            {
                foreach (var ns in additionalNamespaces)
                {
                    writer.WriteLine("using {0};", ns);
                }
            }

            writer.WriteLine("using {0};", clientNamespace);
            writer.WriteLine("using {0}.Model;", clientNamespace);
        }
    }
}
