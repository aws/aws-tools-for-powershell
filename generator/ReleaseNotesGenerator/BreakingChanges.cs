using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace PSReleaseNotesGenerator
{
    /// <summary>
    /// Class for storing breaking changes by C2jFilename and generating the 
    /// BreakingChangesLookup XML file needed to determine if there are breaking
    /// changes for a service that is being overridden.
    /// </summary>
    public class BreakingChanges
    {
        public const string SharedSourceCodeKey = "AWS_CORE_PS_SOURCECODE";
        private Dictionary<string, List<string>> lookup = new Dictionary<string, List<string>>();

        /// <summary>
        /// Adds a breaking change to the breaking changes lookup.
        /// </summary>
        /// <param name="serviceKey">The C2jFilename for the service.</param>
        /// <param name="text">The breaking change text</param>
        public void Add(string serviceKey, string text)
        {
            if (!lookup.ContainsKey(serviceKey))
            {
                lookup.Add(serviceKey, new List<string>());
            }

            lookup[serviceKey].Add(text);
        }

        /// <summary>
        /// Creates a breaking changes lookup XML file based off of the added breaking
        /// changes and the services parsed from the overrides XML file. In the event the
        /// breaking change is not related to a service and is instead shared core PowerShell
        /// logic, the breaking changes will be reported the SharedSourceCodeKey constant value.
        /// 
        /// Example created XML file having a core breaking change and one service breaking 
        /// change which is also in the overrides.xml file.
        /// <![CDATA[
        /// <?xml version="1.0" encoding="utf-8"?>
        /// <Services>
        ///   <AWS_CORE_PS_SOURCECODE InOverrides="false">
        ///     <Reason>[Breaking Change] the reason for the core breaking change.</Reason>
        ///   </AWS_CORE_PS_SOURCECODE>
        ///   <ES InOverrides="true">
        ///     <Reason>[Breaking Change] the reason for the breaking change.</Reason>
        ///     <Reason>[Breaking Change] the 2nd reason for the breaking change.</Reason>
        ///   </ES>
        /// </Services>
        /// ]]>
        /// </summary>
        /// <param name="overridesServiceKeys">A HashSet of ServiceNounPrefix values loaded
        /// from the overrides XML file and looked up in the service configs.</param>
        /// <returns>Breaking changes lookup XML content.</returns>
        public string CreateLookupXML(HashSet<string> overridesServiceKeys)
        {
            XDocument xdoc = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement("Services"));

            //If there are any breaking changes loop through them writing out each service
            //and breaking change. Flag the services that are also withing the overrides.xml
            //file if one exists.
            if (lookup.Any())
            {
                foreach (var breakingChange in lookup)
                {
                    var serviceNounPrefix = string.IsNullOrEmpty(breakingChange.Key) ? SharedSourceCodeKey : breakingChange.Key;
                    var element = new XElement(serviceNounPrefix);
                    element.Add(new XAttribute("InOverrides", overridesServiceKeys.Contains(serviceNounPrefix)));
                    xdoc.Root.Add(element);

                    foreach (var error in breakingChange.Value)
                    {
                        element.Add(new XElement("Reason", error));
                    }
                }
            }

            //Use a StreamWriter so the XML declaration is written out.
            using (var ms = new MemoryStream())
            using (var sw = new StreamWriter(ms))
            {   
                xdoc.Save(sw);
                return Encoding.UTF8.GetString(ms.ToArray());             
            }
        }
    }
}
