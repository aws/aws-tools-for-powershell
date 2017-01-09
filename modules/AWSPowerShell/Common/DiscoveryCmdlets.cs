/*******************************************************************************
 *  Copyright 2012-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Text.RegularExpressions;

using Amazon.Util.Internal;

namespace Amazon.PowerShell.Common
{
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
    /// Returns the name of the cmdlet that is the equivalent to an AWS CLI command. In this mode a best-effort is made
    /// to extract the service and operation name data from the CLI command using known naming conventions and position rules
    /// used by the AWS CLI.
    /// </para>
    /// <para>
    /// If no match is made, no data is output. If the service cannot be identified, an error is displayed.
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
        public const string ByApiOperationOrServiceParameterSet = "ByApiOperationOrService";
        public const string ByAwsCliCommandParameterSet = "ByAwsCliCommand";

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
        [Parameter(ParameterSetName = ByApiOperationOrServiceParameterSet, Position = 0, ValueFromPipeline = true)]
        public string ApiOperation { get; set; }

        /// <summary>
        /// If set, the value supplied for the ApiOperation parameter is assumed to be a
        /// regular expression. By default, the value supplied for ApiOperation is treated as
        /// a simple case-insensitive whole-word pattern to match (the cmdlet will surround
        /// the ApiOperation value with ^ and $ tokens automatically). If the switch is set
        /// no modification of the supplied value is performed.
        /// </summary>
        [Parameter(ParameterSetName = ByApiOperationOrServiceParameterSet)]
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
        /// with the corresponding service operation names.
        /// </para>
        /// </summary>
        [Parameter(ParameterSetName = ByApiOperationOrServiceParameterSet)]
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
        [Parameter(ParameterSetName = ByAwsCliCommandParameterSet, Mandatory = true)]
        public string AwsCliCommand { get; set; }

        private Assembly AwsPowerShellAssembly { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            AwsPowerShellAssembly = TypeFactory.GetTypeInfo(typeof(BaseCmdlet)).Assembly;

            IEnumerable<PSObject> foundCmdlets = null;

            var listAllForService = false;

            if (ParameterSetName.Equals(ByApiOperationOrServiceParameterSet))
                listAllForService = string.IsNullOrEmpty(ApiOperation);

            if (listAllForService)
                foundCmdlets = FindCmdletsByService();
            else
                foundCmdlets = FindCmdletsByOperationOrCommand();

            if (foundCmdlets != null && foundCmdlets.Any())
                WriteObject(foundCmdlets, true);
            else
                WriteVerbose("The specified parameters did not match any service.");
        }

        IEnumerable<PSObject> FindCmdletsByOperationOrCommand()
        {
            var foundCmdlets = new List<PSObject>();

            IEnumerable<string> servicePrefixes = null;
            string operationName;

            // Reduce the search critera to operation name and optional service identification
            if (ParameterSetName.Equals(ByApiOperationOrServiceParameterSet))
            {
                if (!string.IsNullOrEmpty(Service))
                    servicePrefixes = MatchPrefixesOrNames(Service);
                operationName = ApiOperation;
            }
            else
            {
                string awsCliServiceName;
                ParseAwsCliCommand(AwsCliCommand, out awsCliServiceName, out operationName);
                if (string.IsNullOrEmpty(awsCliServiceName) || string.IsNullOrEmpty(operationName))
                    ThrowArgumentError("Unable to extract service and/or operation name from command. Expected text format of 'aws [options] <command> <subcommand>'.", this.AwsCliCommand);

                // this should only yield one match; if none we've already errored out
                servicePrefixes = MatchCliPrefixesOrNames(awsCliServiceName);
                if (servicePrefixes.Count() > 1)
                    ThrowExecutionError("The supplied command unexpectedly matched multiple services.", this);
            }

            // If we are in 'simple' mode, then apply anchors to the operation value
            // to force a match as a whole word.
            if (!MatchWithRegex.IsPresent)
                operationName = string.Format("^{0}$", operationName);

            WriteDebug("Operation name search pattern: " + operationName);

            const RegexOptions options = RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Singleline;
            var regex = new Regex(operationName, options);

            // Now find all the cmdlets that call an operation with the specified name and
            // that optionally belong to the specified service(s).
            var cmdletsToSearch = new List<Type>();
            if (servicePrefixes == null || !servicePrefixes.Any())
            {
                cmdletsToSearch.AddRange(AllServiceCmdletTypes);
            }
            else
            {
                foreach (var servicePrefix in servicePrefixes)
                {
                    cmdletsToSearch.AddRange(DiscoverServiceCmdlets(servicePrefix));
                }
            }

            foreach (var c in cmdletsToSearch)
            {
                var awsCmdletAttribute = AWSCmdletAttribute.GetAttributeInstanceOnType(c, false);
                if (awsCmdletAttribute == null || awsCmdletAttribute.Operation == null)
                    continue;

                // some cmdlets can implement more than one operation (eg Stop-EC2Instance)
                var cmdletOperations = awsCmdletAttribute.Operation;
                foreach (var op in cmdletOperations)
                {
                    if (!regex.IsMatch(op))
                        continue;

                    var cmdletAttribute = GetCmdletAttributeInstanceOnType(c, false);
                    var awsClientCmdletAttribute = AWSClientCmdletAttribute.GetAttributeInstanceOnType(TypeFactory.GetTypeInfo(c).BaseType, false);

                    if (cmdletAttribute == null || awsClientCmdletAttribute == null)
                        continue;

                    var cmdletInfo = new PSObject();
                    cmdletInfo.Properties.Add(new PSNoteProperty("CmdletName", 
                                                                 string.Format("{0}-{1}", 
                                                                               cmdletAttribute.VerbName, 
                                                                               cmdletAttribute.NounName)));
                    cmdletInfo.Properties.Add(new PSNoteProperty("ServiceOperation", op));
                    cmdletInfo.Properties.Add(new PSNoteProperty("ServiceName", awsClientCmdletAttribute.ServiceName));
                    cmdletInfo.Properties.Add(new PSNoteProperty("CmdletNounPrefix", awsClientCmdletAttribute.ServicePrefix));
                    foundCmdlets.Add(cmdletInfo);
                }
            }

            return foundCmdlets;
        }

        /// <summary>
        /// Obtains the names of all cmdlets belonging to the service(s) that match
        /// the search term supplied to the Service parameter.
        /// </summary>
        /// <returns>Collection of found cmdlets.</returns>
        IEnumerable<PSObject> FindCmdletsByService()
        {
            var foundCmdlets = new List<PSObject>();
            var servicePrefixes = MatchPrefixesOrNames(Service);

            foreach (var servicePrefix in servicePrefixes)
            {
                var serviceCmdletTypes = DiscoverServiceCmdlets(servicePrefix);
                var serviceName = string.Empty;
                foreach (var cmdletType in serviceCmdletTypes)
                {
                    var cmdletAttribute = GetCmdletAttributeInstanceOnType(cmdletType, false);
                    var awsCmdletAttribute = AWSCmdletAttribute.GetAttributeInstanceOnType(cmdletType, false);
                    if (awsCmdletAttribute == null || awsCmdletAttribute.Operation == null)
                        continue;

                    var cmdletInfo = new PSObject();
                    cmdletInfo.Properties.Add(new PSNoteProperty("CmdletName", 
                                              string.Format("{0}-{1}", 
                                              cmdletAttribute.VerbName, 
                                              cmdletAttribute.NounName)));

                    // some cmdlets can implement more than one operation (eg Stop-EC2Instance)
                    cmdletInfo.Properties.Add(new PSNoteProperty("ServiceOperation", string.Join(";", awsCmdletAttribute.Operation)));

                    if (string.IsNullOrEmpty(serviceName))
                    {
                        var awsClientCmdletAttribute = AWSClientCmdletAttribute.GetAttributeInstanceOnType(TypeFactory.GetTypeInfo(cmdletType).BaseType, false);
                        serviceName = awsClientCmdletAttribute.ServiceName;
                    }

                    cmdletInfo.Properties.Add(new PSNoteProperty("ServiceName", serviceName));

                    foundCmdlets.Add(cmdletInfo);
                }
            }

            return foundCmdlets;
        }

        /// <summary>
        /// Searches the set of base service client classes to find a matching PowerShell prefix
        /// or service name.
        /// </summary>
        /// <param name="searchText">The search text to match against</param>
        /// <returns>Collection of prefixes that matched the search</returns>
        /// <remarks>
        /// When matching for non-AWS CLI commands, we attempt to match simultaneously
        /// on the prefix or words in the service name.
        /// </remarks>
        IEnumerable<string> MatchPrefixesOrNames(string searchText)
        {
            var servicePrefixes = new HashSet<string>();

            var serviceClientTypes = AwsPowerShellAssembly.GetTypes()
                            .Where(t => TypeFactory.GetTypeInfo(t).IsAbstract && typeof(ServiceCmdlet).IsAssignableFrom(t))
                            .OrderBy(t => t.FullName)
                            .ToList();

            const RegexOptions options = RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Singleline;
            Regex regex = null;
            if (!string.IsNullOrEmpty(searchText))
            {
                regex = new Regex(searchText, options);
                WriteVerbose("...attempting to match cmdlet prefixes or service names against search pattern: " + searchText);
            }
            else
            {
                WriteVerbose("...no service name or name pattern given, yielding all available service cmdlets for output");
            }

            foreach (var sct in serviceClientTypes)
            {
                var awsClientCmdletAttribute = AWSClientCmdletAttribute.GetAttributeInstanceOnType(sct, true);
                if (awsClientCmdletAttribute == null)
                    continue;

                if (regex == null)
                {
                    servicePrefixes.Add(awsClientCmdletAttribute.ServicePrefix);
                    continue;
                }

                if (awsClientCmdletAttribute.ServicePrefix.Equals(searchText, StringComparison.OrdinalIgnoreCase)
                        || regex.IsMatch(awsClientCmdletAttribute.ServiceName))
                {
                    servicePrefixes.Add(awsClientCmdletAttribute.ServicePrefix);
                }
            }

            if (servicePrefixes.Count == 0)
                ThrowArgumentError("Unable to determine possible service(s) based on the supplied parameters.", this);

            return servicePrefixes;
        }

        /// <summary>
        /// Searches the set of base service client classes to discover the PowerShell prefix
        /// code for a service parsed as part of an AWS CLI command.
        /// </summary>
        /// <param name="searchText">The search text to match against</param>
        /// <returns>Collection of prefixes that matched the search</returns>
        /// <remarks>
        /// When matching for a CLI command priority is given to matching on prefix code only.
        /// Service names will only be inspected if we could not match prefixes (as AWS CLI
        /// prefixes do not always match our prefixes).
        /// </remarks>
        IEnumerable<string> MatchCliPrefixesOrNames(string searchText)
        {
            var servicePrefixes = new HashSet<string>();

            var serviceClientTypes = AwsPowerShellAssembly.GetTypes()
                            .Where(t => TypeFactory.GetTypeInfo(t).IsAbstract && typeof(ServiceCmdlet).IsAssignableFrom(t))
                            .OrderBy(t => t.FullName)
                            .ToList();

            WriteVerbose("...attempting to match cmdlet prefixes against search pattern: " + searchText);
            foreach (var serviceClientType in serviceClientTypes)
            {
                var awsClientCmdletAttribute = AWSClientCmdletAttribute.GetAttributeInstanceOnType(serviceClientType, true);
                if (awsClientCmdletAttribute == null)
                    continue;

                if (awsClientCmdletAttribute.ServicePrefix.Equals(searchText, StringComparison.OrdinalIgnoreCase))
                    servicePrefixes.Add(awsClientCmdletAttribute.ServicePrefix);
            }

            if (servicePrefixes.Count == 0)
            {
                WriteVerbose("...no prefix match, attempting to match service names against search pattern: " + searchText);

                const RegexOptions options = RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Singleline;
                var regex = new Regex(searchText, options);

                foreach (var serviceClientType in serviceClientTypes)
                {
                    var awsClientCmdletAttribute = AWSClientCmdletAttribute.GetAttributeInstanceOnType(serviceClientType, true);
                    if (awsClientCmdletAttribute == null)
                        continue;

                    if (regex.IsMatch(awsClientCmdletAttribute.ServiceName))
                        servicePrefixes.Add(awsClientCmdletAttribute.ServicePrefix);
                }
            }

            if (servicePrefixes.Count == 0)
                ThrowArgumentError("Unable to determine possible service based on the supplied AWS CLI command string.", this.AwsCliCommand);

            return servicePrefixes;
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

        /// <summary>
        /// Returns all of the cmdlets in the toolset that make some form of service call.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Type> AllServiceCmdletTypes
        {
            get
            {
                return AwsPowerShellAssembly.GetTypes()
                            .Where(t => !(TypeFactory.GetTypeInfo(t).IsAbstract) && typeof(ServiceCmdlet).IsAssignableFrom(t))
                            .OrderBy(t => t.FullName)
                            .ToList();
            }
        }
            
        /// <summary>
        /// Returns the subset of cmdlets belonging to a service by service prefix matching.
        /// </summary>
        /// <param name="servicePrefix"></param>
        /// <returns></returns>
        IEnumerable<Type> DiscoverServiceCmdlets(string servicePrefix)
        {
            var cmdletsForService = new List<Type>();

            // this can all be expressed in Linq but its fairly dense, so opting to retain
            // foreach loop for readability
            foreach (var cmdletType in AllServiceCmdletTypes)
            {
                var awsCmdletAttribute = AWSCmdletAttribute.GetAttributeInstanceOnType(cmdletType, false);
                if (awsCmdletAttribute == null) // not a cmdlet of interest here
                    continue;

                var awsClientCmdletAttribute = AWSClientCmdletAttribute.GetAttributeInstanceOnType(TypeFactory.GetTypeInfo(cmdletType).BaseType, true);

                if (awsClientCmdletAttribute != null && servicePrefix.Equals(awsClientCmdletAttribute.ServicePrefix, StringComparison.OrdinalIgnoreCase))
                    cmdletsForService.Add(cmdletType);
            }

            if (!cmdletsForService.Any())
                ThrowArgumentError("Unable to find cmdlet(s) for the specified service prefix.", servicePrefix);

            return cmdletsForService;
        }

        private static CmdletAttribute GetCmdletAttributeInstanceOnType(Type t, bool inherit)
        {
            var attributeTypeInfo = TypeFactory.GetTypeInfo(typeof(CmdletAttribute));

            var customAttributes = TypeFactory.GetTypeInfo(t).GetCustomAttributes(attributeTypeInfo, inherit);
            if (customAttributes.Length != 1)
                return null;

#if CORECLR
            // later versions of PowerShell 6 fixed the reflection-only context issue and we can cast directly
            // as the attribute type (attempting to cast to CustomAttributeData fails with a null exception in 
            // those later versions)
            var cmdletAttributeInstance = customAttributes[0] as CmdletAttribute;
            if (cmdletAttributeInstance != null)
                return cmdletAttributeInstance;

            var cad = customAttributes[0] as CustomAttributeData;
            var ctorArgs = cad.ConstructorArguments;

            var verb = ctorArgs[0].Value.ToString();
            var noun = ctorArgs[1].Value.ToString();

            return new CmdletAttribute(verb, noun);
#else
            return customAttributes[0] as CmdletAttribute;
#endif
    }
}
}
