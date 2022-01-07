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

            var exceptions = new List<Exception>();
            var serviceNounsPrefixes = new HashSet<string>();
            foreach(var filetitle in c2jFilenames)
            {
                try
                {
                    var serviceConfigXML = ServiceConfigLoader(filetitle);
                    xdoc = XDocument.Parse(serviceConfigXML);
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
    }
}
