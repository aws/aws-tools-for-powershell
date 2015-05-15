using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AWSPowerShellGenerator.Utils
{
    /// <summary>
    /// Collector class for various project file fragments that we want to inject into
    /// the final AWSPowerShell project file ahead of build.
    /// </summary>
    internal class ProjectFileFragmentStore
    {
        /// <summary>
        /// Collects the various .cs file fragments for compilation, organised by service (for
        /// easier debugging/inspection)
        /// </summary>
        Dictionary<string, StringWriter> _csfileFragments = new Dictionary<string, StringWriter>();

        ProjectFileFragmentStore() { }

        static ProjectFileFragmentStore _this;
        public static ProjectFileFragmentStore Instance
        {
            get
            {
                if (_this == null)
                    _this = new ProjectFileFragmentStore();
                return _this;
            }
        }

        /// <summary>
        /// Add one or more C# files to the relevant item group for the named service, creating the group
        /// if necessary
        /// </summary>
        /// <param name="serviceItemGroup">Service namespace, eg 'AmazonEC2'</param>
        /// <param name="csFilename">Full or relative name to the generated C# source file</param>
        public void AddCSFileForCompilation(string serviceItemGroup, params string[] csFiles)
        {
            StringWriter itemGroupFragment;
            if (_csfileFragments.ContainsKey(serviceItemGroup))
                itemGroupFragment = _csfileFragments[serviceItemGroup];
            else
            {
                itemGroupFragment = new StringWriter();
                _csfileFragments.Add(serviceItemGroup, itemGroupFragment);
            }

            foreach (string csFile in csFiles)
            {
                itemGroupFragment.WriteLine(@"<Compile Include=""{0}"" />", csFile);
            }
        }

        /// <summary>
        /// Returns the full collection of C# file item groups as one string,
        /// </summary>
        public string Serialize()
        {
            StringWriter sw = new StringWriter();

            sw.WriteLine("<ItemGroup>");
            foreach (string key in _csfileFragments.Keys)
            {
                sw.WriteLine(_csfileFragments[key].ToString());
            }
            sw.WriteLine("</ItemGroup>");

            return sw.ToString();
        }

        /// <summary>
        /// Returns the C# item group for a specific service as one string
        /// </summary>
        /// <param name="serviceItemGroup">Service namespace, eg 'AmazonEC2'</param>
        /// <returns></returns>
        public string Serialize(string serviceItemGroup)
        {
            if (_csfileFragments.ContainsKey(serviceItemGroup))
            {
                return _csfileFragments[serviceItemGroup].ToString();
            }

            // warn?

            return string.Empty;
        }
    }
}
