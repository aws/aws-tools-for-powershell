using System;
using System.Collections.Generic;
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
        /// Parses the comma-separated list of target service C2jFilenames (e.g. the value of the
        /// --target-service-c2j-filenames option). These are the services a build explicitly targets,
        /// so their breaking changes should be flagged InOverrides="true" even when they are absent
        /// from the overrides file (e.g. a parameter change on an existing operation with an empty
        /// buildconfig). Returns an empty enumerable when the input is null or empty so behavior is unchanged.
        /// </summary>
        /// <param name="targetServiceC2jFilenames">Comma-separated C2jFilenames (e.g. "bedrock-agent-runtime,ec2").</param>
        /// <returns>The trimmed, non-empty C2jFilenames.</returns>
        public static IEnumerable<string> ParseTargetServiceC2jFilenames(string targetServiceC2jFilenames)
        {
            if (string.IsNullOrWhiteSpace(targetServiceC2jFilenames))
            {
                return Enumerable.Empty<string>();
            }

            return targetServiceC2jFilenames
                .Split(',')
                .Select(filename => filename.Trim())
                .Where(filename => !string.IsNullOrEmpty(filename));
        }
    }
}
