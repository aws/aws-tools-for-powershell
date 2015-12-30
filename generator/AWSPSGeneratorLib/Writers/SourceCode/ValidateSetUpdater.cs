using AWSPowerShellGenerator.CmdletConfig;
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
    /// Text-based parser that enumerates all lines in a cmdlet source file
    /// looking for parameters that are marked as having ValidateSet attribution. 
    /// The parser then updates the attribution from the latest set values as needed.
    /// </para>
    /// <para>
    /// This parser is used to maintain ValidateSet attribution in hand-maintained
    /// (aka 'advanced') cmdlets, where we do not have the benefit of reflection
    /// to set find and update this information.
    /// </para>
    /// </summary>
    internal class ValidateSetUpdater
    {
        /// <summary>
        /// The source file to parse and potentially update.
        /// </summary>
        public string SourceFile { get; set; }

        /// <summary>
        /// The parent service assembly for the cmdlet to be processed. Used to
        /// load remaining type definitions we may not have already seen when
        /// generating cmdlets.
        /// </summary>
        public Assembly ServiceAssembly { get; set; }


        public BasicLogger Logger { get; set; }

        public ValidateSetUpdater(string sourceFile, Assembly serviceAssembly, BasicLogger logger)
        {
            this.SourceFile = sourceFile;
            this.ServiceAssembly = serviceAssembly;
            this.Logger = logger;
        }

        /// <summary>
        /// <para>
        /// Parses the source file looking for a cmdlet that has parameters
        /// attributed with AWSValidateSetSource. On detection of these parameters
        /// any ValidateSet attribute is updated (or created) using the current
        /// values of the ConstantClass-derived type noted in the marker attribute.
        /// </para>
        /// <para>
        /// The source file is only updated on disk if a change in content is detected.
        /// </para>
        /// </summary>
        public void ParseAndUpdate()
        {
            // strobe -- currently disabled while we investigate other potential approaches
            /*
            var originalSource = File.ReadAllText(SourceFile);

            using (var reader = new StringReader(originalSource))
            {
                using (var writer = new StringWriter())
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.IndexOf(CmdletSourceWriter.ParameterRegionMarker) < 0)
                        {
                            if (line.IndexOf("[Parameter", StringComparison.Ordinal) >= 0)
                            {
                                Logger.LogError("Found Parameter attribute outside of #region enclosure - {0}", SourceFile);
                            }

                            writer.WriteLine(line);
                            continue;
                        }

                        var parameterDefinition = ProcessParameterDefinition(reader, line);
                        foreach (var pd in parameterDefinition)
                        {
                            writer.WriteLine(pd);
                        }
                    }

                    var newContent = writer.GetStringBuilder().ToString();

                    if (!originalSource.Equals(newContent, StringComparison.Ordinal))
                        File.WriteAllText(SourceFile, newContent);
                };
            }*/
        }

        /// <summary>
        /// Extracts all lines making up the parameter definition (between the #region 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="startLine"></param>
        /// <returns></returns>
        private IEnumerable<string> ProcessParameterDefinition(StringReader reader, string startLine)
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

            var setTypeName = FindValidateSetType(parameterDefinition);
            if (string.IsNullOrEmpty(setTypeName))
                return parameterDefinition;

            // build the new ValidateSet, and optional AllowEmptyString, attributions
            // and then reconstruct the parameter definition for return
            var constrainedSets = SimplePropertyInfo.ConstrainedMemberSets;
            IEnumerable<string> setMembers;
            // possible none of the generated cmdlets didn't use this type
            if (!constrainedSets.TryGetValue(setTypeName, out setMembers))
            {
                // load the type and add members back ready for possible future use
                var propertyType = ServiceAssembly.GetType(setTypeName);
                setMembers = SimplePropertyInfo.GetValidateSetMembers(propertyType);
                SimplePropertyInfo.ConstrainedMemberSets.Add(setTypeName, setMembers);
            }

            var validateSetAttribute = CmdletSourceWriter.BuildValidateSetAttribute(setMembers);
            var hasEmptyStringMember = CmdletSourceWriter.RequiresEmptyValueAttribution(setMembers);

            return BuildNewParameterDefinition(parameterDefinition, validateSetAttribute, hasEmptyStringMember);
        }

        private IEnumerable<string> BuildNewParameterDefinition(IEnumerable<string> currentDefinition, string validateSetAttribute, bool hasEmptyStringMember)
        {
            string indent = null;
            var newDefinition = new List<string>();
            foreach (var l in currentDefinition)
            {
                // make sure we match indentation
                if (indent == null)
                {
                    int x = l.TakeWhile(c => char.IsWhiteSpace(c)).Count();
                    indent = new string(' ', x);
                }

                // look for the marker attribute and place our updated or new
                // attributes beneath it, and skip any pre-existing versions in
                // the transfer
                if (l.IndexOf(CmdletSourceWriter.AWSConstantClassSourceAttributeName, StringComparison.Ordinal) < 0)
                {
                    if (l.IndexOf(CmdletSourceWriter.AllowEmptyStringAttributeName, StringComparison.Ordinal) >= 0
                            || l.IndexOf(CmdletSourceWriter.ValidateSetAttributeName, StringComparison.Ordinal) >= 0)
                        continue;

                    newDefinition.Add(l);
                }
                else
                {
                    newDefinition.Add(l);
                    newDefinition.Add(string.Concat(indent, validateSetAttribute));
                    if (hasEmptyStringMember)
                        newDefinition.Add(string.Concat(indent, string.Format("[{0}]", CmdletSourceWriter.AllowEmptyStringAttributeName)));
                }
            }

            return newDefinition;
        }

        /// <summary>
        /// Inspects the definition to see if the marker attribute denoting ValidateSet usage is
        /// present and returns the type name of the ConstantClass-derived parameter type so that
        /// we can create or update the ValidateSet attribute for the parameter.
        /// </summary>
        /// <param name="parameterDefinition"></param>
        /// <returns></returns>
        private string FindValidateSetType(IEnumerable<string> parameterDefinition)
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
