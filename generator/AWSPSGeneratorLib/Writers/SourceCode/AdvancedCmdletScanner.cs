using AWSPowerShellGenerator.ServiceConfig;
using AWSPowerShellGenerator.Generators;
using AWSPowerShellGenerator.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AWSPowerShellGenerator.Writers.SourceCode
{
    /// <summary>
    /// <para>
    /// Text-based parser that scans the source file for an advanced (hand-maintained)
    /// cmdlet looking for 'interesting' items. Currently this just means looking for
    /// marker attributes on parameters that signal the use of ConstantClass-derived
    /// types for which argument completers should be generated.
    /// </summary>
    internal class AdvancedCmdletScanner
    {
        /// <summary>
        /// The source file to parse.
        /// </summary>
        public string SourceFile { get; set; }

        /// <summary>
        /// The parent service assembly for the cmdlet to be processed. Used to
        /// load remaining type definitions we may not have already seen when
        /// generating cmdlets.
        /// </summary>
        public Assembly ServiceAssembly { get; set; }

        /// <summary>
        /// The service model controlling cmdlet generation for the service.
        /// </summary>
        public ConfigModel ServiceModel { get; set; }

        /// <summary>
        /// Generators logger for messaging output.
        /// </summary>
        public BasicLogger Logger { get; set; }

        /// <summary>
        /// The verb-noun formatted name of the cmdlet, recovered from the Cmdlet attribute
        /// on the class.
        /// </summary>
        private string CmdletName { get; set; }

        public AdvancedCmdletScanner(string sourceFile, ConfigModel serviceModel, Assembly serviceAssembly, BasicLogger logger)
        {
            this.SourceFile = sourceFile;
            this.ServiceModel = serviceModel;
            this.ServiceAssembly = serviceAssembly;
            this.Logger = logger;
        }

        /// <summary>
        /// Perform the scan on the source file. If we locate attributes marking use
        /// of ConstantClass-derived types, update the service model so that argument
        /// completers are generated and/or the cmdlet is added to the completer
        /// registration.
        /// </summary>
        public void Scan()
        {
            var originalSource = File.ReadAllText(SourceFile);

            using (var reader = new StringReader(originalSource))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(CmdletName) && line.IndexOf("[Cmdlet(") >= 0)
                    {
                        CmdletName = ExtractCmdletName(line);
                        ServiceModel.AdvancedCmdletNames.Add(CmdletName);
                        continue;
                    } 

                    if (line.IndexOf(CmdletSourceWriter.ParameterRegionMarker) < 0)
                    {
                        if (line.IndexOf("[Parameter", StringComparison.Ordinal) >= 0)
                        {
                            Logger.LogError("Found Parameter attribute outside of #region enclosure - {0}", SourceFile);
                        }
                        continue;
                    }

                    var parameterDefinition = ExtractParameterDefinition(reader, line);
                    var constantClassTypeName = FindConstantClassMarker(parameterDefinition);
                    if (!string.IsNullOrEmpty(constantClassTypeName))
                    {
                        if (!ServiceModel.ArgumentCompleters.IsConstantClassRegistered(constantClassTypeName))
                        {
                            var propertyType = ServiceAssembly.GetType(constantClassTypeName);
                            var members = SimplePropertyInfo.GetConstantClassMembers(propertyType);
                            ServiceModel.ArgumentCompleters.AddConstantClass(constantClassTypeName, members);
                        }

                        var parameterName = ExtractParameterName(parameterDefinition);
                        ServiceModel.ArgumentCompleters.AddConstantClassReference(constantClassTypeName, parameterName, CmdletName);
                    }
                }
            }
        }

        /// <summary>
        /// Extracts all lines making up the parameter definition (between the #region Parameter markers)
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="startLine"></param>
        /// <returns></returns>
        private IEnumerable<string> ExtractParameterDefinition(StringReader reader, string startLine)
        {
            var parameterDefinition = new List<string>
            {
                startLine
            };

            var foundEndRegion = false;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                parameterDefinition.Add(line);
                if (line.IndexOf(CmdletSourceWriter.EndRegionMarker) >= 0)
                {
                    foundEndRegion = true;
                    break;
                }
            }

            if (!foundEndRegion)
                throw new InvalidDataException(string.Format("Encountered EOF before #endregion for parameter starting at {0}", startLine));
            return parameterDefinition;
        }

        private string ExtractParameterName(IEnumerable<string> parameterDefinition)
        {
            // all parameters take the form 'public type name { get; set; }, so a simple
            // split to extract the 3rd value is sufficient once we find the line of interest
            foreach (var line in parameterDefinition)
            {
                var l = line.Trim();
                if (l.StartsWith("public ", StringComparison.Ordinal))
                {
                    var parts = l.Split();
                    if (parts.Length >= 3)
                        return parts[2];
                }
            }

            throw new InvalidOperationException("Unable to extract parameter name for ArgumentCompleter registration");
        }

        /// <summary>
        /// Parses the verb-noun format of the cmdlet name from the Cmdlet attribute
        /// contained in line.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private string ExtractCmdletName(string line)
        {
            var l = line.Trim();
            var start = l.IndexOf("(", StringComparison.Ordinal) + 1;
            var end = l.LastIndexOf(")", StringComparison.Ordinal) - 1;

            var args = l.Substring(start, end - start + 1).Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (args.Length < 2)
                throw new InvalidOperationException(string.Format("Found invalid [Cmdlet] attribute in file {0}: '{1}'", SourceFile, line));

            var verb = args[0].Trim('"');
            var noun = args[1].Trim('"');
            return string.Concat(verb, "-", noun);
        }

        /// <summary>
        /// Inspects the definition to see if the marker attribute denoting usage of a
        /// ConstantClass-derived tupe is present. If so, the type name held inside
        /// the attribute is returned.
        /// </summary>
        /// <param name="parameterDefinition"></param>
        /// <returns></returns>
        private string FindConstantClassMarker(IEnumerable<string> parameterDefinition)
        {
            foreach (var l in parameterDefinition)
            {
                var attrStart = l.IndexOf(CmdletSourceWriter.AWSConstantClassSourceAttributeName, StringComparison.Ordinal);
                if (attrStart >= 0)
                {
                    // jump over the (" after the attribute name
                    var typeNameStart = attrStart + CmdletSourceWriter.AWSConstantClassSourceAttributeName.Length + 2;
                    var typeNameEnd = l.IndexOf("\"", typeNameStart);

                    return l.Substring(typeNameStart, typeNameEnd - typeNameStart);
                }
            }

            return null;
        }
    }
}
