using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace PSReleaseNotesGenerator
{
    /// <summary>
    /// Class for working with overrides XML data.
    /// </summary>
    public class Overrides
    {
        /// <summary>
        /// Parses the overrides XML content for the value for each C2JFilename in
        /// <Service><C2jFilename>VALUE</C2jFilename></Service> then looks up the
        /// ServiceNounPrefix for each service configuration.
        /// </summary>
        /// <param name="overridesXML">A loaded overrides.xml file content</param>
        /// <param name="ServiceConfigLoader">Callback to load the service configuration for the passed C2jFilename.</param>
        /// <returns>A HashSet containing each ServiceNounPrefix for each service in the overrides XML</returns>
        public static HashSet<string> ParseServiceNounPrefixes(string overridesXML, Func<string, string> ServiceConfigLoader)
        {
            if(string.IsNullOrEmpty(overridesXML))
            {
                return new HashSet<string>();
            }

            var xdoc = XDocument.Parse(overridesXML);
            var c2jFilenames = xdoc.Descendants()
                .Where(p => p.Name.LocalName == "C2jFilename")
                .Select(element => element.Value)
                .ToList();

            return ResolveServiceNounPrefixes(c2jFilenames, ServiceConfigLoader);
        }

        /// <summary>
        /// Looks up the ServiceNounPrefix for each supplied C2jFilename by loading its service
        /// configuration. Used for both the C2jFilenames parsed from the overrides file and the
        /// C2jFilenames of the services a build explicitly targets.
        /// </summary>
        /// <param name="c2jFilenames">The C2jFilenames to resolve (e.g. "bedrock-agent-runtime").</param>
        /// <param name="ServiceConfigLoader">Callback to load the service configuration for the passed C2jFilename.</param>
        /// <returns>A HashSet containing the ServiceNounPrefix for each resolved service.</returns>
        public static HashSet<string> ResolveServiceNounPrefixes(IEnumerable<string> c2jFilenames, Func<string, string> ServiceConfigLoader)
        {
            var exceptions = new List<Exception>();
            var serviceNounsPrefixes = new HashSet<string>();
            foreach(var filetitle in c2jFilenames)
            {
                try
                {
                    var serviceConfigXML = ServiceConfigLoader(filetitle);
                    var xdoc = XDocument.Parse(serviceConfigXML);
                    serviceNounsPrefixes.Add(xdoc.Root.Element("ServiceNounPrefix").Value);
                }
                catch(Exception e)
                {
                    exceptions.Add(new Exception($"Error processing '{filetitle}': {e.Message}", e));
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException("Error(s) occurred while processing service configurations.", exceptions);
            }

            return serviceNounsPrefixes;
        }

        /// <summary>
        /// Looks up the ServiceNounPrefix for each supplied service AssemblyName by scanning the service
        /// configuration files and matching on the internal <AssemblyName> element. AssemblyName
        /// is the reliable 1:1 identifier shared by .NET and PowerShell. Matching is case-insensitive so a
        /// casing difference in the supplied AssemblyName does not cause the target service to be missed.
        /// An AssemblyName with no matching service configuration is skipped (with a warning) only when the
        /// service is intentionally skipped from PowerShell (i.e. listed in Configs.xml IncludeLibraries),
        /// since such a service has no cmdlets and therefore no breaking changes to surface. An AssemblyName
        /// that resolves to neither a service configuration nor a skipped service is unexpected and throws,
        /// so a genuine mismatch is surfaced instead of silently hiding a service's breaking changes.
        /// </summary>
        /// <param name="assemblyNames">The service AssemblyNames to resolve (e.g. "PrometheusService").</param>
        /// <param name="serviceConfigDirectory">Directory containing the service configuration XML files.</param>
        /// <param name="skippedServiceAssemblyNames">AssemblyNames intentionally skipped from PowerShell (from Configs.xml IncludeLibraries).</param>
        /// <returns>A HashSet containing the ServiceNounPrefix for each resolved service.</returns>
        public static HashSet<string> ResolveServiceNounPrefixesByAssemblyName(IEnumerable<string> assemblyNames, string serviceConfigDirectory, ISet<string> skippedServiceAssemblyNames)
        {
            var serviceNounsPrefixes = new HashSet<string>();

            var targetAssemblyNames = new HashSet<string>(assemblyNames ?? Enumerable.Empty<string>(), StringComparer.OrdinalIgnoreCase);
            if (targetAssemblyNames.Count == 0)
            {
                return serviceNounsPrefixes;
            }

            if (!Directory.Exists(serviceConfigDirectory))
            {
                Console.WriteLine($"WARNING: Service configuration directory not found: {serviceConfigDirectory}. Target service breaking changes cannot be flagged InOverrides=\"true\".");
                return serviceNounsPrefixes;
            }

            // Build a map of AssemblyName to ServiceNounPrefix by reading the internal <AssemblyName>
            // element of each service configuration (the file name is not the AssemblyName).
            var nounPrefixByAssemblyName = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (var configFile in Directory.GetFiles(serviceConfigDirectory, "*.xml", SearchOption.TopDirectoryOnly))
            {
                try
                {
                    var xdoc = XDocument.Load(configFile);
                    var assemblyName = xdoc.Root?.Element("AssemblyName")?.Value;
                    var serviceNounPrefix = xdoc.Root?.Element("ServiceNounPrefix")?.Value;
                    if (!string.IsNullOrEmpty(assemblyName) && !string.IsNullOrEmpty(serviceNounPrefix))
                    {
                        nounPrefixByAssemblyName[assemblyName] = serviceNounPrefix;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"WARNING: Skipping service configuration '{Path.GetFileName(configFile)}' because it could not be parsed: {e.Message}");
                }
            }

            var unexpectedAssemblyNames = new List<string>();
            foreach (var assemblyName in targetAssemblyNames)
            {
                if (nounPrefixByAssemblyName.TryGetValue(assemblyName, out var serviceNounPrefix))
                {
                    serviceNounsPrefixes.Add(serviceNounPrefix);
                }
                else if (skippedServiceAssemblyNames != null && skippedServiceAssemblyNames.Contains(assemblyName))
                {
                    Console.WriteLine($"WARNING: AssemblyName '{assemblyName}' is intentionally skipped from PowerShell (Configs.xml IncludeLibraries), so it has no cmdlets and no breaking changes to flag InOverrides=\"true\".");
                }
                else
                {
                    unexpectedAssemblyNames.Add(assemblyName);
                }
            }

            if (unexpectedAssemblyNames.Any())
            {
                throw new Exception($"No service configuration or skipped-service entry found for target AssemblyName(s): {string.Join(", ", unexpectedAssemblyNames)}. Their breaking changes cannot be flagged InOverrides=\"true\".");
            }

            return serviceNounsPrefixes;
        }

        /// <summary>
        /// Parses the AssemblyNames of services intentionally skipped from PowerShell generation from the
        /// Configs.xml IncludeLibraries section (Library Name="AWSSDK.{AssemblyName}"). These services have
        /// no service configuration and no cmdlets, so a target service that resolves to one of them is
        /// skipped rather than treated as an unexpected mismatch. Returns an empty set when the input is null
        /// or empty.
        /// </summary>
        /// <param name="configsXML">The loaded Configs.xml file content.</param>
        /// <returns>A case-insensitive set of skipped service AssemblyNames (without the "AWSSDK." prefix).</returns>
        public static HashSet<string> ParseSkippedServiceAssemblyNames(string configsXML)
        {
            var skipped = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            if (string.IsNullOrEmpty(configsXML))
            {
                return skipped;
            }

            var xdoc = XDocument.Parse(configsXML);
            foreach (var library in xdoc.Descendants().Where(p => p.Name.LocalName == "Library"))
            {
                var name = library.Attribute("Name")?.Value;
                if (!string.IsNullOrEmpty(name) && name.StartsWith("AWSSDK.", StringComparison.OrdinalIgnoreCase))
                {
                    skipped.Add(name.Substring("AWSSDK.".Length));
                }
            }

            return skipped;
        }

        /// <summary>
        /// Parses the comma-separated list of target service AssemblyNames (e.g. the value of the
        /// --target-service-assembly-names option). These are the services a build explicitly targets,
        /// so their breaking changes should be flagged InOverrides="true" even when they are absent
        /// from the overrides file (e.g. a parameter change on an existing operation with an empty
        /// buildconfig). Returns an empty enumerable when the input is null or empty so behavior is unchanged.
        /// </summary>
        /// <param name="targetServiceAssemblyNames">Comma-separated AssemblyNames (e.g. "PrometheusService,DynamoDBStreams").</param>
        /// <returns>The trimmed, non-empty AssemblyNames.</returns>
        public static IEnumerable<string> ParseTargetServiceAssemblyNames(string targetServiceAssemblyNames)
        {
            if (string.IsNullOrWhiteSpace(targetServiceAssemblyNames))
            {
                return Enumerable.Empty<string>();
            }

            return targetServiceAssemblyNames
                .Split(',')
                .Select(assemblyName => assemblyName.Trim())
                .Where(assemblyName => !string.IsNullOrEmpty(assemblyName));
        }
    }
}
