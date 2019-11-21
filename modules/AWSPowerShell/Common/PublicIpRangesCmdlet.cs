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
using System.Text;
using System.Management.Automation;

using Amazon.Util;
using Microsoft.PowerShell.Commands;
using System.Net;

namespace Amazon.PowerShell.Common
{
    /// <summary>
    /// <para>
    /// Returns the collection of current public IP address ranges for Amazon Web Services. Each address 
    /// range instance contains the service key, host region and IP address range (in CIDR notation).
    /// </para>
    /// <para>
    /// The cmdlet can optionally emit the set of currently known service keys, perform filtering of 
    /// output by service key or region information or output the publication date and time of the
    /// current information.
    /// </para>
    /// <para>
    /// The information processed by this cmdlet is contained in a publicly accessible JSON-format file at
    /// https://ip-ranges.amazonaws.com/ip-ranges.json. The information in this file is generated from our internal 
    /// system-of-record and is authoritative. You can expect it to change several times per week and should poll 
    /// accordingly
    /// </para>
    /// <para>
    /// For more details on the public IP address range data for Amazon Web Services, 
    /// see http://docs.aws.amazon.com/general/latest/gr/aws-ip-ranges.html.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "AWSPublicIpAddressRange", DefaultParameterSetName = GetAddressRangesParameterSet)]
    [AWSCmdlet("Returns the public IP address range data for Amazon Web Services. "
                + "Each address range instance contains the service key, host region and IP address range (in CIDR notation).")]
    [OutputType(typeof(AWSPublicIpAddressRange), typeof(String[]), typeof(DateTime))]
    [AWSCmdletOutput("AWSPublicIpAddressRange", "A collection of AWSPublicIpAddressRange instances. This is the default output from the cmdlet.")]
    [AWSCmdletOutput("String[]", "A collection of currently-known service keys used in the address data, if the -OutputServiceKeys switch is set.")]
    [AWSCmdletOutput("DateTime", "The publication date and time if the -OutputPublicationDate switch is set.")]
    public class PublicIpRangesCmdlet : PSCmdlet
    {
        private const string GetAddressRangesParameterSet = "GetAddressRanges";
        private const string ServiceKeysOnlyParameterSet = "ListServiceKeysOnly";
        private const string PublicationDateParameterSet = "PublicationDate";

        /// <summary>
        /// If set the cmdlet emits the collection of currently-known service keys
        /// used in the address range data.
        /// </summary>
        [Parameter(ParameterSetName = ServiceKeysOnlyParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public SwitchParameter OutputServiceKeys { get; set; }

        /// <summary>
        /// If set the cmdlet emits the publication date and time of the data.
        /// </summary>
        [Parameter(ParameterSetName = PublicationDateParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public SwitchParameter OutputPublicationDate { get; set; }

        /// <summary>
        /// If set, contains one or more service keys to filter the output to.
        /// This parameter can be used in conjunction with the Region parameter
        /// to filter by region and service key.
        /// </summary>
        [Parameter(ParameterSetName = GetAddressRangesParameterSet, ValueFromPipelineByPropertyName = true)]
        public string[] ServiceKey { get; set; }

        /// <summary>
        /// If set, contains one or more region identifiers (e.g. "us-east-1", "global")
        /// to filter the output to. This parameter can be used in conjunction with the
        /// ServiceKey parameter to filter by region and service key.
        /// </summary>
        [Parameter(ParameterSetName = GetAddressRangesParameterSet, ValueFromPipelineByPropertyName = true)]
        public string[] Region { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var settings = ProxySettings.GetSettings(this);
            var proxy = settings.GetWebProxy();
            var ranges = AWSPublicIpAddressRanges.Load(proxy);

            if (OutputServiceKeys.IsPresent)
                WriteObject(ranges.ServiceKeys, true);
            else if (OutputPublicationDate.IsPresent)
                WriteObject(ranges.CreateDate);
            else
            {
                HashSet<string> serviceKeyHash = null;
                HashSet<string> regionHash = null;

                if ((ServiceKey != null && ServiceKey.Length != 0))
                    serviceKeyHash = new HashSet<string>(ServiceKey, StringComparer.OrdinalIgnoreCase);

                if (Region != null && Region.Length != 0)
                    regionHash = new HashSet<string>(Region, StringComparer.OrdinalIgnoreCase);

                var output = new List<AWSPublicIpAddressRange>();
                foreach (var addressRange in ranges.AllAddressRanges)
                {
                    var addToCollection = true;

                    if (serviceKeyHash != null && !serviceKeyHash.Contains(addressRange.Service))
                        addToCollection = false;

                    if (regionHash != null && !regionHash.Contains(addressRange.Region))
                        addToCollection = false;

                    if (addToCollection)
                        output.Add(addressRange);
                }

                WriteObject(output, true);
            }
        }
    }
}
