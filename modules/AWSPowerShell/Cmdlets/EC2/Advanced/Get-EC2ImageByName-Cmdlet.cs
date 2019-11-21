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
using System.Linq;
using System.Management.Automation;
using Amazon.PowerShell.Common;
using Amazon.EC2.Model;
using Amazon.EC2.Util;
using Amazon.EC2;
using Amazon.Runtime;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// <para>
    /// Outputs a collection of one or more Amazon Machine Images using either a set of supplied service-pack independent 
    /// 'logical' name pattern(s), or a set of custom name patterns. The set of service-pack independent logical names can 
    /// be viewed using the -ShowFilters switch.
    /// </para>
    /// <para>
    /// If more than one name pattern is supplied (built-in or custom) then all available machine images that match the 
    /// pattern are output. If only a single name pattern is supplied and it corresponds to one of the built-in service-pack
    /// independent names, then only the very latest machine image that matches is output. To see all versions of a machine
    /// image that correspond to a built-in name, use the -AllAvailable switch.
    /// </para>
    /// <para>
    /// This cmdlet is deprecated and will be removed in a future version. Use Get-SSMLatestEC2Image instead.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2ImageByName")]
    [OutputType("string", "Amazon.EC2.Model.Image")]
    [AWSCmdlet("Outputs a collection of one or more Amazon Machine Images using either a set of supplied service-pack independent"
                + "'logical' name pattern(s), or a set of custom name patterns. The set of service-pack independent logical names can "
                + "be viewed using the -ShowFilters switch.")]
    [AWSCmdletOutput("Amazon.EC2.Model.Image",
        "This cmdlet returns one or more Amazon Machine Image objects that correspond to a set of one or more name patterns. "
            + "If a single value is supplied for the -Name parameter, and it matches one of the built-in name patterns, only the latest machine image corresponding to the name "
            + "is output. To see all available versions of the image matching the name, use the -AllAvailable switch. "
            + "If more than one value is supplied to the -Name parameter, all images matching the set of name patterns are output (irrespective of "
            + "whether the names are built-in or custom). ",
        "The service calls(s) made by the cmdlet to obtain the Image collection (type Amazon.EC2.Model.DescribeImagesResponse) are added to the cmdlet entry in the $AWSHistory stack."
    )]
    [AWSCmdletOutput("string", "If no parameters are supplied the cmdlet emits the built-in logical names that can be used with the -Name parameter.")]
#if MODULAR
    [Obsolete("This cmdlet is deprecated and will be removed in a future version. Use Get-SSMLatestEC2Image from the AWS.Tools.SimpleSystemsManager module instead.")]
#else
    [Obsolete("This cmdlet is deprecated and will be removed in a future version. Use Get-SSMLatestEC2Image instead.")]
#endif
    public class GetEC2ImageByNameCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
#region Parameter Name
        /// <summary>
        /// <para>
        /// A collection of one or more name patterns to use as filters to select an image. If this parameter is 
        /// not specified, the set of built-in service-pack independent names are output.
        /// </para>
        /// <para>
        /// If the name supplied is recognized as one of the built-in service pack independent 'logical' names, 
        /// it will be replaced internally by the corresponding pattern mapped by the logical name and used to 
        /// query EC2 to find the latest available image corresponding to that name pattern. Using independent names 
        /// means your script will continue to work even after AMIs are deprecated as new service packs are 
        /// released. Names containing service pack/RTM designations can be deprecated as machine images are
        /// periodically refresh and eventually removed from the set of Amazon-published AMIs.
        /// </para>
        /// <para>
        /// If more than one value is supplied for this parameter, all machine images matching the name
        /// pattern are output, irrespective of whether the names supplied are from the built-in service-pack
        /// independent set or are custom name patterns of your own making.
        /// </para>
        /// <para>
        /// If a single value is supplied and it matches one of the built-in service-pack independent 'logical'
        /// names then only the very latest machine image corresponding to that name is output. Use the -AllAvailable
        /// switch to obtain the latest plus prior versions of the AMI.
        /// </para>
        /// </summary>
        [Alias("FilterNames","Names")]
        [Parameter(Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public System.String[] Name { get; set; }
#endregion

#region Parameter ShowFilters
        /// <summary>
        /// If set, the cmdlet emits the actual name pattern used to filter the machine images.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter ShowFilters { get; set; }
#endregion

#region Parameter AllAvailable
        /// <summary>
        /// <para>
        /// Amazon Web Services periodically refreshes machine images and 'deprecates' the prior versions.
        /// For a time it is possible for more than one image to correspond to a given logical filter.
        /// </para>
        /// <para>
        /// If this switch is specified and the name filter(s) supplied to the cmdlet are recognized as 
        /// service pack independent 'logical' filters (i.e. the filter names shown if the -ShowFilters 
        /// switch is supplied) then the cmdlet will emit all of the images corresponding to the
        /// filter. By default, the older images are suppressed and only the very latest image corresponding
        /// to the filter is output.
        /// </para>
        /// <para>
        /// If the supplied name filter(s) are not recognized (i.e. they are custom naming patterns of your
        /// own construction) then this switch is ignored and all matching images are returned.
        /// </para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter AllAvailable { get; set; }
#endregion

        // maintains a redirect map of deprecated names and the current replacement
        static readonly Dictionary<string, string> DeprecatedNameSet = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        static GetEC2ImageByNameCmdlet()
        {
            DeprecatedNameSet.Add("Windows_Server-2012-RTM-English-64Bit-SQL_2012_RTM_Express*", ImageUtilities.WINDOWS_2012_SQL_SERVER_EXPRESS_2012_KEY);
            DeprecatedNameSet.Add("Windows_Server-2012-RTM-English-64Bit-SQL_2012_RTM_Standard*", ImageUtilities.WINDOWS_2012_SQL_SERVER_STANDARD_2012_KEY);
            DeprecatedNameSet.Add("Windows_Server-2012-RTM-English-64Bit-SQL_2012_RTM_Web*", ImageUtilities.WINDOWS_2012_SQL_SERVER_WEB_2012_KEY);

            DeprecatedNameSet.Add("Windows_Server-2008-R2_SP1-English-64Bit-SQL_2012_RTM_Express*", ImageUtilities.WINDOWS_2008R2_SQL_SERVER_EXPRESS_2012_KEY);
            DeprecatedNameSet.Add("Windows_Server-2008-R2_SP1-English-64Bit-SQL_2012_RTM_Standard*", ImageUtilities.WINDOWS_2008R2_SQL_SERVER_STANDARD_2012_KEY);
            DeprecatedNameSet.Add("Windows_Server-2008-R2_SP1-English-64Bit-SQL_2012_RTM_Web*", ImageUtilities.WINDOWS_2008R2_SQL_SERVER_WEB_2012_KEY);

            // these deprecations were added when 2008RTM was added and the existing 2008 image names remapped to 2008R2
            DeprecatedNameSet.Add("WINDOWS_2008_BASE", ImageUtilities.WINDOWS_2008R2_BASE.DefinitionKey);
            DeprecatedNameSet.Add("WINDOWS_2008_SQL_SERVER_EXPRESS_2012", ImageUtilities.WINDOWS_2008R2_SQL_SERVER_EXPRESS_2012_KEY);
            DeprecatedNameSet.Add("WINDOWS_2008_SQL_SERVER_STANDARD_2012", ImageUtilities.WINDOWS_2008R2_SQL_SERVER_STANDARD_2012_KEY);
            DeprecatedNameSet.Add("WINDOWS_2008_SQL_SERVER_WEB_2012", ImageUtilities.WINDOWS_2008R2_SQL_SERVER_WEB_2012_KEY);
            DeprecatedNameSet.Add("WINDOWS_2008_SQL_SERVER_EXPRESS_2008", ImageUtilities.WINDOWS_2008R2_SQL_SERVER_EXPRESS_2008_KEY);
            DeprecatedNameSet.Add("WINDOWS_2008_SQL_SERVER_STANDARD_2008", ImageUtilities.WINDOWS_2008R2_SQL_SERVER_STANDARD_2008_KEY);
            DeprecatedNameSet.Add("WINDOWS_2008_SQL_SERVER_WEB_2008", ImageUtilities.WINDOWS_2008R2_SQL_SERVER_WEB_2008_KEY);
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var context = new CmdletContext
            {
                Names = this.Name,
                ShowFilters = this.ShowFilters.IsPresent,
                OutputAllAvailable = this.AllAvailable.IsPresent
            };

            ProcessOutput(Execute(context) as CmdletOutput);
        }
        
#region IExecutor Members

        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            if (cmdletContext == null)
                throw new InvalidOperationException();

            // Instantiate the client early so that any proxy settings configured via Set-AWSProxy will
            // be picked up and available when the SDK downloads the key->filter metadata content for those 
            // customers that use a mandated and authenticated proxy.
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);

            CmdletOutput output = null;

            if (cmdletContext.Names == null || cmdletContext.Names.Length == 0)
            {
                IEnumerable<string> data;
                if (!cmdletContext.ShowFilters)
                    data = ImageUtilities.ImageKeys;
                else
                {
                    var filters = new List<string>();
                    foreach (var k in ImageUtilities.ImageKeys)
                    {
                        var descriptor = LookupDescriptorByKey(k);
                        filters.Add(descriptor.NamePrefix);
                    }

                    data = filters;
                }

                output = new CmdletOutput
                {
                    PipelineOutput = data
                };
            }
            else
            {
                var customPatternUsed = false;
                var patterns = new List<string>();
                foreach (var name in cmdletContext.Names)
                {
                    // most preferable case - user gives us a service-pack/RTM designation-free 'logical' name,
                    // not affected by image deprecation
                    var imageDescriptor = LookupDescriptorByKey(name);
                    if (imageDescriptor != null)
                    {
                        patterns.Add(imageDescriptor.NamePrefix);
                        continue;
                    }

                    // if not an indepedent name, tell user they might want to update their script for
                    // better longevity
                    imageDescriptor = LookupDescriptorByName(name);
                    if (imageDescriptor != null)
                    {
                        var msg = string.Format("'{0}' may be deprecated at some future time.\r\nUse the version-independent replacement '{1}' to ensure your script always works.", 
                                                name,
                                                imageDescriptor.DefinitionKey);
                        WriteWarning(msg);

                        patterns.Add(imageDescriptor.NamePrefix);
                        continue;
                    }

                    // if the user gave us a known deprecated image, remap it and again inform them
                    // they might want to update their script
                    if (DeprecatedNameSet.ContainsKey(name))
                    {
                        imageDescriptor = LookupDescriptorByKey(DeprecatedNameSet[name]);
                        var msg =
                            string.Format(
                                "'{0}' has been deprecated.\r\nUsing '{1}' instead.\r\nUse the version-independent replacement '{2}' to ensure your script always works.",
                                name,
                                imageDescriptor.NamePrefix,
                                DeprecatedNameSet[name]);
                        WriteWarning(msg);

                        patterns.Add(imageDescriptor.NamePrefix);
                    }
                    else
                    {
                        // final catch-all is to assume the name is for a non-stock ami, so use what we're given without
                        // complaint
                        patterns.Add(name);
                        customPatternUsed = true;
                    }
                }

                // use of multiple names, or any single custom name pattern, means we always output everything
                if (patterns.Count > 1 || customPatternUsed)
                    cmdletContext.OutputAllAvailable = true;

                // Decided to not use the helper inside Amazon.EC2.Util.ImageUtilities to do this, so I can capture
                // the service request/response to the history stack and allow us to pass in multiple filter names.
                var request = new DescribeImagesRequest
                {
                    Owners = new List<string> {"amazon"},
                    Filters = new List<Filter>
                                {
                                    new Filter {Name = "name", Values = patterns}
                                }
                };

                try
                {
                    var response = CallAWSServiceOperation(client, request);
                    output = new CmdletOutput
                    {
                        ServiceResponse = response
                    };

                    // in previous versions of this cmdlet the output was always descending, regardless 
                    // of whether the user gave us a custom or a built-in name pattern; to change
                    // it would potentially be a breaking change...
                    var sortedOutput = response.Images.OrderByDescending(x => x.Name);
                    if (!cmdletContext.OutputAllAvailable)
                        output.PipelineOutput = sortedOutput.First();
                    else
                    {
                        output.PipelineOutput = sortedOutput;
                    }
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
            }

            return output;
        }

        ImageUtilities.ImageDescriptor LookupDescriptorByKey(string key)
        {
#if DESKTOP
            return ImageUtilities.DescriptorFromKey(key, Client);
#elif CORECLR
            return ImageUtilities.DescriptorFromKeyAsync(key, Client).GetAwaiter().GetResult();
#else
#error "Unknown build edition"
#endif
        }

        ImageUtilities.ImageDescriptor LookupDescriptorByName(string name)
        {
            var keys = ImageUtilities.ImageKeys;
            foreach (var k in keys)
            {
                var descriptor = LookupDescriptorByKey(k);
                if (descriptor.NamePrefix.Equals(name, StringComparison.OrdinalIgnoreCase))
                    return descriptor;
            }

            return null;
        }

        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }

#endregion

#region AWS Service Operation Call

        private Amazon.EC2.Model.DescribeImagesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeImagesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2", "DescribeImages");

            try
            {
#if DESKTOP
                return client.DescribeImages(request);
#elif CORECLR
                return client.DescribeImagesAsync(request).GetAwaiter().GetResult();
#else
#error "Unknown build edition"
#endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }

                throw;
            }
        }

#endregion

        internal class CmdletContext : ExecutorContext
        {
            public string[] Names { get; set; }
            public bool ShowFilters { get; set; }
            public bool OutputAllAvailable { get; set; }
        }
    }
}
