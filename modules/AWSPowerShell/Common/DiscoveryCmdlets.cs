/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Amazon.PowerShell.Common
{
    /// <summary>
    /// <para>
    /// Returns the name of the AWS services supported by the current version of AWS Tools for PowerShell, optionally restricting
    /// the scope of the search to a specific service which can be identified using one or more words from the service name or the
    /// prefix applied to the nouns of cmdlets belonging to the service.
    /// </para>
    /// <para>
    /// If no match is made, no data is output.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "AWSService")]
    [AWSCmdlet("Returns the name of the AWS services supported by the current version of AWS Tools for PowerShell, optionally restricting"
                + " the scope of the search to a specific service which can be identified using one or more words from the service name or the"
                + " prefix applied to the nouns of cmdlets belonging to the service."
        )]
    [OutputType(typeof(PSObject))]
    [AWSCmdletOutput("PSObject", "A collection of zero or more objects listing AWS services supported by the current version of AWS Tools for PowerShell.")]
    public class GetAWSServiceCmdlet : BaseCmdlet
    {
        /// <summary>
        /// <para>
        /// Matches the full or partial term supplied to the parameter value, which can be the service prefix
        /// (for example 'EC2') or one or more terms from the service name (for example 'compute' or 'compute
        /// cloud').
        /// </para>
        /// <para>
        /// When partial names are used (as opposed to a prefix code) all services 
        /// for which a match can be found are used to assist in the cmdlet results. A 
        /// regular expression can always be supplied for the parameter value.
        /// </para>
        /// </summary>
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public string Service { get; set; }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var services = GetFilteredServices(Service)
                .Select(service => ConvertToPSObject(service));

            if (services.Any())
                WriteObject(services, true);
            else
                WriteVerbose("The specified parameters did not match any service.");
        }

        internal class ServiceInfo
        {
            public string Name;
            public string Description;
            public string CmdletNounPrefix;
            public string ModuleName;
            public string SDKAssemblyName;
            public string SDKAssemblyVersion;
            public XElement XmlElement;
        }

        internal static IEnumerable<ServiceInfo> GetServices()
        {
            using (var compressedStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Amazon.PowerShell.CmdletsList.dat"))
            using (var stream = new GZipStream(compressedStream, CompressionMode.Decompress))
            using (var reader = new System.IO.StreamReader(stream))
            {
                var doc = XElement.Load(reader);
                foreach (var service in doc.Elements("Service"))
                {
                    var serviceName = service.Attribute("Name");
                    yield return new ServiceInfo
                    {
                        Name = service.Attribute("Name").Value,
                        Description = service.Attribute("Description").Value,
                        CmdletNounPrefix = service.Attribute("CmdletNounPrefix").Value,
                        ModuleName = service.Attribute("ModuleName").Value,
                        SDKAssemblyName = service.Attribute("SDKAssemblyName").Value,
                        SDKAssemblyVersion = service.Attribute("SDKAssemblyVersion").Value,
                        XmlElement = service
                    };

                    foreach (var cmdlet in service.Elements("Cmdlet"))
                    {
                        var cmdletName = cmdlet.Attribute("Name");
                    }
                }
            }
        }

        internal static IEnumerable<ServiceInfo> GetFilteredServices(string serviceName)
        {
            var services = GetServices();

            if (serviceName != null)
            {
                services = FilterByServicePrefixOrName(services, serviceName);
            }

            return services.OrderBy(service => service.ModuleName);
        }

        private static IEnumerable<ServiceInfo> FilterByServicePrefixOrName(IEnumerable<ServiceInfo> services, string nameFilter)
        {
            var matchingServices = services.Where(service => service.CmdletNounPrefix.Equals(nameFilter, StringComparison.OrdinalIgnoreCase)).ToArray();
            if (matchingServices.Length == 0)
            {
                var regex = new Regex(nameFilter, RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);
                matchingServices = services.Where(service => regex.IsMatch(service.Name) || regex.IsMatch(service.Description)).ToArray();
            }

            return matchingServices;
        }

        private static PSObject ConvertToPSObject(ServiceInfo service)
        {
            var result = new PSObject();
            result.Properties.Add(new PSNoteProperty("Service", service.Name));
            result.Properties.Add(new PSNoteProperty("CmdletNounPrefix", service.CmdletNounPrefix));
#if MODULAR
            result.Properties.Add(new PSNoteProperty("ModuleName", service.ModuleName));
#endif
            result.Properties.Add(new PSNoteProperty("SDKAssemblyVersion", service.SDKAssemblyVersion));
            result.Properties.Add(new PSNoteProperty("ServiceName", service.Description));
            return result;
        }
    }

    /// <summary>
    /// <para>
    /// Returns the name of the cmdlet that invokes a named Amazon Web Services service operation, optionally restricting the
    /// scope of the search to a specific service which can be identified using one or more words from the service name or the
    /// prefix applied to the nouns of cmdlets belonging to the service.
    /// </para>
    /// <para>
    /// Returns the names and corresponding service operations for a specific Amazon Web Services service which can be identified
    /// using one or more words from the service name or the  prefix applied to the nouns of cmdlets belonging to the service.
    /// </para>
    /// <para>
    /// If no match is made, no data is output.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "AWSCmdletName", DefaultParameterSetName = ByApiOperationOrServiceParameterSet)]
    [AWSCmdlet("Searches for cmdlets that invoke a Amazon Web Services service operation, map to an AWS CLI command, or lists all cmdlets"
                + " that belong to a service identified by one or more words in its name or its cmdlet noun prefix. If no service name or pattern is given all service cmdlets are output."
        )]
    [OutputType(typeof(PSObject))]
    [AWSCmdletOutput("PSObject",
                     "A collection of zero or more objects listing cmdlets that implement the specified operation, map to the AWS CLI command"
                     + " or belong to the specified service.")]
    public class GetCmdletNameCmdlet : BaseCmdlet
    {
        public const string ByApiOperationOrServiceParameterSet = "QueryApiOperationOrService";
        public const string ByAwsCliCommandParameterSet = "FromAwsCliCommand";

        /// <summary>
        /// <para>
        /// The name of the service operation (api) to search for. If not further restricted by
        /// service prefix or service name, all cmdlets across all services are
        /// inspected for a matching operation.
        /// </para>
        /// <para>
        /// By default the value supplied for this parameter is treated as a simple whole-word pattern 
        /// to match. If the -MatchWithRegex switch is set the value is used as a regular expression.
        /// In both cases the search is case-insensitive/invariant culture.
        /// </para>
        /// </summary>
        [Parameter(ParameterSetName = ByApiOperationOrServiceParameterSet, Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public string ApiOperation { get; set; }

        /// <summary>
        /// <para>
        /// The name of the cmdlet to search for. If not further restricted by
        /// service prefix or service name, all cmdlets across all services are
        /// inspected.
        /// </para>
        /// <para>
        /// By default the value supplied for this parameter is treated as a simple whole-word pattern 
        /// to match. If the -MatchWithRegex switch is set the value is used as a regular expression.
        /// In both cases the search is case-insensitive/invariant culture.
        /// </para>
        /// </summary>
        [Parameter(ParameterSetName = ByApiOperationOrServiceParameterSet, Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public string CmdletName { get; set; }

        /// <summary>
        /// If set, the value supplied for the ApiOperation or CmdletName parameter is assumed to be a
        /// regular expression. By default, the value supplied for ApiOperation or CmdletName are treated
        /// as a simple case-insensitive whole-word pattern to match (the cmdlet will surround the value
        /// with ^ and $ tokens automatically). If the switch is set no modification of the supplied value
        /// is performed.
        /// </summary>
        [Parameter(ParameterSetName = ByApiOperationOrServiceParameterSet, ValueFromPipelineByPropertyName = true)]
        public SwitchParameter MatchWithRegex { get; set; }

        /// <summary>
        /// <para>
        /// Restricts the search to the cmdlets belonging to services that match the full or 
        /// partial term supplied to the parameter value, which can be the service prefix
        /// (for example 'EC2') or one or more terms from the service name (for example
        /// 'compute' or 'compute cloud').
        /// </para>
        /// <para>
        /// When partial names are used (as opposed to a prefix code) all services 
        /// for which a match can be found are used to assist in the cmdlet results. A 
        /// regular expression can always be supplied for the parameter value.
        /// </para>
        /// <para>
        /// If this is the only parameter supplied to the cmdlet, the output will list all
        /// of the cmdlets belonging to the services matching the search term, together 
        /// with the corresponding service operation names. Note that for services with 'helper'
        /// cmdlets that do not invoke a particular service operation the ServiceOperation member
        /// for the cmdlet in the resulting output is left blank.
        /// </para>
        /// </summary>
        [Parameter(ParameterSetName = ByApiOperationOrServiceParameterSet, ValueFromPipelineByPropertyName = true)]
        public string Service { get; set; }

        /// <summary>
        /// <para>
        /// The AWS CLI command to match. For example 'aws ec2 describe-instances'. 
        /// </para>
        /// The cmdlet will make a best-effort to identify the owning service and the operation 
        /// name by parsing the command using known conventions for the AWS CLI command format.
        /// The 'aws' prefix may be omitted and any AWS CLI options (identified by the prefix
        /// characters --) are skipped when parsing the value to identify the service code and
        /// operation name elements.
        /// </summary>
        [Parameter(ParameterSetName = ByAwsCliCommandParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Obsolete("This parameter is deprecated and will be removed in a future version. Use Service and ApiOperation instead.")]
        public string AwsCliCommand { get; set; }

        private class CmdletInfo
        {
            public string Name;
            public string[] Operations;
        }

        private static IEnumerable<CmdletInfo> GetCmdlets(GetAWSServiceCmdlet.ServiceInfo service)
        {
            foreach (var cmdlet in service.XmlElement.Elements("Cmdlet"))
            {
                var cmdletName = cmdlet.Attribute("Name");
                yield return new CmdletInfo
                {
                    Name = cmdlet.Attribute("Name").Value,
                    Operations = cmdlet.Attribute("Operations").Value.Split(',')
                };
            }
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

#pragma warning disable CS0618 //A class member was marked with the Obsolete attribute
            string awsCliServiceName = null;
            string awsCliOperationName = null;
            if (AwsCliCommand != null)
            {
                ParseAwsCliCommand(AwsCliCommand, out awsCliServiceName, out awsCliOperationName);
                if (string.IsNullOrEmpty(awsCliServiceName) || string.IsNullOrEmpty(awsCliOperationName))
                {
                    ThrowArgumentError("Unable to extract service and/or operation name from command. Expected text format of 'aws [options] <command> <subcommand>'.", this.AwsCliCommand);
                }
                WriteVerbose($"Searching for {awsCliOperationName} in service {awsCliServiceName}");
            }
#pragma warning restore CS0618

            var services = GetAWSServiceCmdlet.GetFilteredServices(awsCliServiceName ?? Service);

            var results = new List<PSObject>();

            Regex operationNameRegex = null;
            if (awsCliOperationName != null)
            {
                operationNameRegex = new Regex($"^{awsCliOperationName}$",
                    RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);
            }
            if (ApiOperation != null)
            {
                operationNameRegex = new Regex(MatchWithRegex.IsPresent ? ApiOperation : $"^{ApiOperation}$",
                    RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);
            }

            Regex cmdletNameRegex = null;
            if (CmdletName != null)
            {
                cmdletNameRegex = new Regex(MatchWithRegex.IsPresent ? CmdletName : $"^{CmdletName}$",
                    RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);
            }

            foreach (var service in services)
            {
                var cmdlets = GetCmdlets(service);
                if (cmdletNameRegex != null)
                {
                    cmdlets = cmdlets.Where(cmdlet => cmdletNameRegex.IsMatch(cmdlet.Name));
                }
                if (operationNameRegex != null)
                {
                    cmdlets = cmdlets.Where(cmdlet => cmdlet.Operations.Any(operation => operationNameRegex.IsMatch(operation)));
                }

                results.AddRange(cmdlets
                    .OrderBy(cmdlet => cmdlet.Name)
                    .Select(cmdlet => ConvertToPSObject(service, cmdlet)));
            }

            if (results.Any())
                WriteObject(results, true);
            else
                WriteVerbose("The specified parameters did not match any service.");
        }

        private static PSObject ConvertToPSObject(GetAWSServiceCmdlet.ServiceInfo service, CmdletInfo cmdlet)
        {
            var result = new PSObject();
            result.Properties.Add(new PSNoteProperty("CmdletName", cmdlet.Name));
            result.Properties.Add(new PSNoteProperty("ServiceOperation", string.Join(";", cmdlet.Operations)));
            result.Properties.Add(new PSNoteProperty("ServiceName", service.Description));
#if MODULAR
            result.Properties.Add(new PSNoteProperty("ModuleName", service.ModuleName));
#endif
            return result;
        }

        /// <summary>
        /// Parses a typical aws cli command to extract the service name and operation. Some flexibility is
        /// allowed, to make it easy for users who are transcoding a cli sample to PowerShell.
        /// </summary>
        /// <param name="command">
        /// Cli command to parse; as this was a parameter value that triggered a parameter set, we know it is not null.
        /// </param>
        /// <param name="serviceName"></param>
        /// <param name="operationName"></param>
        static void ParseAwsCliCommand(string command, out string serviceName, out string operationName)
        {
            serviceName = null;
            operationName = null;

            // Usual format: aws [options] <command> <subcommand>
            // Also allow for 'aws' to be dropped. Options are expected to conform to -- prefix format.
            var cmdParts = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var i = 0;
            if (cmdParts.Length == 0)
                return;

            if (cmdParts[0].Equals("aws", StringComparison.OrdinalIgnoreCase))
                i = 1;

            while (i < cmdParts.Length && operationName == null)
            {
                if (!cmdParts[i].StartsWith("--"))
                {
                    if (serviceName == null)
                        serviceName = cmdParts[i];
                    else
                        operationName = cmdParts[i].Trim().Replace("-", "");
                }

                i++;
            }
        }
    }
}
