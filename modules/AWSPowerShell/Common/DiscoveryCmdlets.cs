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

namespace Amazon.PowerShell.Common
{
    /// <summary>
    /// <para>
    /// Returns the name of the cmdlet that invokes a named Amazon Web Services service operation, optionally restricting the
    /// scope of the search to a specific service. identified using one or more words from the service name or the prefix
    /// applied to the nouns of cmdlets belonging to the service. 
    /// </para>
    /// <para>
    /// The cmdlet can also parse simple AWS CLI commands and return the equivalent cmdlet. In this mode a best-effort is made
    /// to extract the service and operation name data from the CLI command using known naming conventions and position rules
    /// used by the AWS CLI.
    /// </para>
    /// <para>
    /// If no match is made, no data is output.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "AWSCmdletName", DefaultParameterSetName = ByApiOperationParameterSet)]
    [AWSCmdlet("Returns the name of the cmdlet that invokes a named Amazon Web Services service operation, optionally restricting the "
                + "scope of the search to a specific service."
                )]
    [OutputType(typeof(string))]
    [AWSCmdletOutput("String", "The name of the cmdlet that invokes the specified service operation.")]
    public class GetCmdletNameCmdlet : BaseCmdlet
    {
        public const string ByApiOperationParameterSet      = "ByApiOperation";
        public const string ByAwsCliCommandParameterSet     = "ByAwsCliCommand";

        /// <summary>
        /// <para>
        /// The name of the service api to search for. If not further restricted by
        /// service prefix or service name, all cmdlets across all services are
        /// inspected for a matching operation.
        /// </para>
        /// <para>
        /// By default the value supplied for this parameter is treated as a simple whole-word pattern 
        /// to match. If the -MatchWithRegex switch is set the value is used as a regular expression.
        /// In both cases the search is case-insensitive/invariant culture.
        /// </para>
        /// </summary>
        [Parameter(ParameterSetName = ByApiOperationParameterSet, Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public string ApiOperation { get; set; }

        /// <summary>
        /// If set, the value supplied for the ApiOperation parameter is assumed to be a
        /// regular expression. By default, the value supplied for ApiOperation is treated as
        /// a simple case-insensitive whole-word pattern to match (the cmdlet will surround
        /// the ApiOperation value with ^ and $ tokens automatically). If the switch is set
        /// no modification of the supplied value is performed.
        /// </summary>
        [Parameter(ParameterSetName = ByApiOperationParameterSet)]
        public SwitchParameter MatchWithRegex { get; set; }

        /// <summary>
        /// <para>
        /// Restricts the search to the cmdlets belonging to the specified service. The value 
        /// supplied will be used to match against one or more words of the fuller descriptive 
        /// name of a service or the prefix code applied to the nouns of cmdlets belonging to 
        /// a service. 
        /// </para>
        /// <para>
        /// A regular expression can be supplied for this value, irrespective of the setting
        /// of the -MatchWithRegex switch.
        /// </para>
        /// </summary>
        [Parameter(ParameterSetName = ByApiOperationParameterSet)]
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

            AwsPowerShellAssembly = Assembly.GetExecutingAssembly();

            // Reduce the search critera to operation name and optional service identification
            string operationName;
            string servicePrefix = null;

            if (ParameterSetName.Equals(ByApiOperationParameterSet))
            {
                if (!string.IsNullOrEmpty(Service))
                    servicePrefix = DiscoverServicePrefix(Service);
                operationName = ApiOperation;
            }
            else
            {
                string awsCliServiceName;
                ParseAwsCliCommand(AwsCliCommand, out awsCliServiceName, out operationName);
                if (string.IsNullOrEmpty(awsCliServiceName) || string.IsNullOrEmpty(operationName))
                    ThrowExecutionError("Unable to extract service and/or operation name from command. Expected text format of 'aws [options] <command> <subcommand>'.", this.AwsCliCommand);

                servicePrefix = DiscoverServicePrefix(awsCliServiceName);
            }

            // If we are in 'simple' mode, then apply anchors to the operation value
            // to force a match as a whole word.
            if (!MatchWithRegex.IsPresent)
                operationName = string.Format("^{0}$", operationName);

            WriteDebug("Operation name search pattern: " + operationName);

            const RegexOptions options = RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Singleline;
            var regex = new Regex(operationName, options);

            // Now find all the cmdlets that call an operation with the specified name and
            // that optionally belong to the specified service.
            var cmdletsToSearch = !string.IsNullOrEmpty(servicePrefix) 
                ? DiscoverServiceCmdlets(servicePrefix)
                : AllServiceCmdlets;

            var foundCmdlets = new List<PSObject>();
            foreach (var c in cmdletsToSearch)
            {
                var awsCmdletAttribute = c.GetCustomAttributes(typeof (AWSCmdletAttribute), false).FirstOrDefault() as AWSCmdletAttribute;
                if (awsCmdletAttribute == null || awsCmdletAttribute.Operation == null)
                    continue;

                // some cmdlets can implement more than one operation (eg Stop-EC2Instance)
                var cmdletOperations = awsCmdletAttribute.Operation;
                foreach (var op in cmdletOperations)
                {
                    if (!regex.IsMatch(op))
                        continue;

                    var cmdletAttribute = c.GetCustomAttributes(typeof(CmdletAttribute), false).FirstOrDefault() as CmdletAttribute;
                    var awsClientCmdletAttribute = c.BaseType.GetCustomAttributes(typeof(AWSClientCmdletAttribute), false).FirstOrDefault() as AWSClientCmdletAttribute;

                    var cmdletInfo = new PSObject();
                    cmdletInfo.Properties.Add(new PSNoteProperty("CmdletName", string.Format("{0}-{1}", cmdletAttribute.VerbName, cmdletAttribute.NounName)));
                    cmdletInfo.Properties.Add(new PSNoteProperty("ServiceOperation", op));
                    cmdletInfo.Properties.Add(new PSNoteProperty("ServiceName", awsClientCmdletAttribute.ServiceName));
                    cmdletInfo.Properties.Add(new PSNoteProperty("CmdletNounPrefix", awsClientCmdletAttribute.ServicePrefix));
                    foundCmdlets.Add(cmdletInfo);
                }
            }

            WriteObject(foundCmdlets, true);
        }

        /// <summary>
        /// Searches the set of base service client classes using either service name or 
        /// deconstructed aws cli command to discover the prefix code for the service.
        /// </summary>
        /// <paramref name="serviceName"/>
        /// <returns></returns>
        string DiscoverServicePrefix(string serviceName)
        {
            string servicePrefix = null;
            var serviceClientTypes = AwsPowerShellAssembly.GetTypes()
                            .Where(t => t.IsAbstract && typeof(ServiceCmdlet).IsAssignableFrom(t))
                            .OrderBy(t => t.FullName)
                            .ToList();

            const RegexOptions options = RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Singleline;
            var regex = new Regex(serviceName, options);

            WriteDebug("Service name/prefix search pattern: " + serviceName);

            foreach (var scb in serviceClientTypes)
            {
                var awsClientCmdletAttribute = scb.GetCustomAttributes(typeof(AWSClientCmdletAttribute), true).FirstOrDefault() as AWSClientCmdletAttribute;
                if (awsClientCmdletAttribute == null)
                    continue;

                // if we're attempting to match an aws cli command, some of its service names are actually our prefixes so
                // either field may match
                if (regex.IsMatch(awsClientCmdletAttribute.ServiceName)
                        || awsClientCmdletAttribute.ServicePrefix.Equals(serviceName, StringComparison.OrdinalIgnoreCase))
                {
                    servicePrefix = awsClientCmdletAttribute.ServicePrefix;
                    break;
                }
            }

            if (string.IsNullOrEmpty(servicePrefix))
                ThrowExecutionError("Unable to determine correct service prefix based on the supplied name or AWS CLI command.", this);

            return servicePrefix;
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
        IEnumerable<Type> AllServiceCmdlets
        {
            get
            {
                return AwsPowerShellAssembly.GetTypes()
                            .Where(t => !t.IsAbstract && typeof(ServiceCmdlet).IsAssignableFrom(t))
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
            foreach (var c in AllServiceCmdlets)
            {
                var awsCmdletAttribute = c.GetCustomAttributes(typeof (AWSCmdletAttribute), false).FirstOrDefault() as AWSCmdletAttribute;
                if (awsCmdletAttribute == null) // not a cmdlet of interest here
                    continue;

                var awsClientCmdletAttribute = c.BaseType.GetCustomAttributes(typeof (AWSClientCmdletAttribute), true).FirstOrDefault() as AWSClientCmdletAttribute;
                if (awsClientCmdletAttribute != null && servicePrefix.Equals(awsClientCmdletAttribute.ServicePrefix, StringComparison.OrdinalIgnoreCase))
                    cmdletsForService.Add(c);
            }

            if (!cmdletsForService.Any())
                ThrowExecutionError("Unable to find cmdlet(s) for the specified service prefix.", servicePrefix);

            return cmdletsForService;
        }
    }
}
