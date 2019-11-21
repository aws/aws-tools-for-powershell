using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace DesktopManifestPatcher
{
    class Program
    {
        private const string CmdletsToExportTag = "CmdletsToExport = ";
        private const string CmdletsToExportSourceString = CmdletsToExportTag + "'*-*'";

        static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Patches the ExportedCmdlets member of the netcore edition .psd1 manifest ");
                Console.WriteLine("file contained in the specified module folder to enumerate all exported cmdlets.");
                Console.WriteLine("The manifest filename to update, and the name of the assembly containing the");
                Console.WriteLine("cmdlets, is inferred from the module folder name.");
                Console.WriteLine();
                Console.WriteLine("Usage: NetCoreManifestPatcher.exe module_folder");
                return 0;
            }

            var moduleFolder = args[0].TrimEnd('\\');

            if (!Directory.Exists(moduleFolder))
            {
                Console.WriteLine("Error: specified module folder does not exist!");
                return -1;
            }

            try
            {
                var manifestRootname = Path.GetFileName(moduleFolder);
                var manifestFilename = Path.Combine(moduleFolder, manifestRootname + ".psd1");
                // could actually get this from within the manifest
                var moduleAssemblyFilename = Path.Combine(moduleFolder, manifestRootname + ".dll");

                var moduleAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(moduleAssemblyFilename);

                // we seem to need to force load all the sdk assemblies too (desktop edition loads them automatically)
                var sdkAssemblies = Directory.GetFiles(moduleFolder, "AWSSDK.*.dll");
                foreach (var sdkAssembly in sdkAssemblies)
                {
                    AssemblyLoadContext.Default.LoadFromAssemblyPath(sdkAssembly);
                }

                // walking the chain avoids the need to take a dependency on the ps automation dll. Perform
                // a walk in case we ever inject another class between PSCmdlet and our BaseCmdlet type.
                var amznBaseCmdletType = moduleAssembly.GetType("Amazon.PowerShell.Common.BaseCmdlet");
                TypeInfo pscmdletType = amznBaseCmdletType.GetTypeInfo().BaseType.GetTypeInfo();
                while (!pscmdletType.FullName.Equals("System.Management.Automation.Cmdlet", StringComparison.Ordinal))
                {
                    pscmdletType = pscmdletType.BaseType.GetTypeInfo();
                }

                var exportedCmdlets = new List<TypeInfo>();
                foreach (var exportedType in moduleAssembly.GetTypes())
                {
                    var typeInfo = exportedType.GetTypeInfo();
                    if (typeInfo.IsPublic && !typeInfo.IsAbstract && pscmdletType.IsAssignableFrom(typeInfo))
                    {
                        exportedCmdlets.Add(typeInfo);
                    }
                }

                // extract the cmdlet names, then sort into order prior to building the manifest content
                var cmdletNames = new List<string>();
                foreach (var cmdletType in exportedCmdlets)
                {
                    var cmdletAttribute = cmdletType.GetCustomAttributes(typeof(CmdletAttribute), true).FirstOrDefault() as CmdletAttribute;
                    if (cmdletAttribute != null)
                    {
                        cmdletNames.Add(string.Format("{0}-{1}", cmdletAttribute.VerbName, cmdletAttribute.NounName));
                    }
                }

                cmdletNames.Sort();

                var formattedCmdletNames = new StringBuilder();
                foreach (var cmdletName in cmdletNames)
                {
                    if (formattedCmdletNames.Length > 0)
                    {
                        formattedCmdletNames.AppendLine(",");
                    }
                    formattedCmdletNames.AppendFormat("    \"{0}\"", cmdletName);
                }

                // form the replacement exports statement
                var sb = new StringBuilder(CmdletsToExportTag + "@(");
                sb.AppendLine();
                sb.Append(formattedCmdletNames);
                sb.AppendLine();
                sb.Append(")");

                var manifestContent = File.ReadAllText(manifestFilename);
                var newManifestContent = manifestContent.Replace(CmdletsToExportSourceString, sb.ToString());
                File.WriteAllText(manifestFilename, newManifestContent);
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                return -1;
            }
        }
    }
}
