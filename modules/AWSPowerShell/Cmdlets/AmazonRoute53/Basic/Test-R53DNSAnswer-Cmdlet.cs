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
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.Route53;
using Amazon.Route53.Model;

namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Gets the value that Amazon Route 53 returns in response to a DNS request for a specified
    /// record name and type. You can optionally specify the IP address of a DNS resolver,
    /// an EDNS0 client subnet IP address, and a subnet mask.
    /// </summary>
    [Cmdlet("Test", "R53DNSAnswer")]
    [OutputType("Amazon.Route53.Model.TestDNSAnswerResponse")]
    [AWSCmdlet("Calls the Amazon Route 53 TestDNSAnswer API operation.", Operation = new[] {"TestDNSAnswer"})]
    [AWSCmdletOutput("Amazon.Route53.Model.TestDNSAnswerResponse",
        "This cmdlet returns a Amazon.Route53.Model.TestDNSAnswerResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class TestR53DNSAnswerCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        #region Parameter EDNS0ClientSubnetIP
        /// <summary>
        /// <para>
        /// <para>If the resolver that you specified for resolverip supports EDNS0, specify the IPv4
        /// or IPv6 address of a client in the applicable location, for example, <code>192.0.2.44</code>
        /// or <code>2001:db8:85a3::8a2e:370:7334</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EDNS0ClientSubnetIP { get; set; }
        #endregion
        
        #region Parameter EDNS0ClientSubnetMask
        /// <summary>
        /// <para>
        /// <para>If you specify an IP address for <code>edns0clientsubnetip</code>, you can optionally
        /// specify the number of bits of the IP address that you want the checking tool to include
        /// in the DNS query. For example, if you specify <code>192.0.2.44</code> for <code>edns0clientsubnetip</code>
        /// and <code>24</code> for <code>edns0clientsubnetmask</code>, the checking tool will
        /// simulate a request from 192.0.2.0/24. The default value is 24 bits for IPv4 addresses
        /// and 64 bits for IPv6 addresses.</para><para>The range of valid values depends on whether <code>edns0clientsubnetip</code> is an
        /// IPv4 or an IPv6 address:</para><ul><li><para><b>IPv4</b>: Specify a value between 0 and 32</para></li><li><para><b>IPv6</b>: Specify a value between 0 and 128</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EDNS0ClientSubnetMask { get; set; }
        #endregion
        
        #region Parameter HostedZoneId
        /// <summary>
        /// <para>
        /// <para>The ID of the hosted zone that you want Amazon Route 53 to simulate a query for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String HostedZoneId { get; set; }
        #endregion
        
        #region Parameter RecordName
        /// <summary>
        /// <para>
        /// <para>The name of the resource record set that you want Amazon Route 53 to simulate a query
        /// for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RecordName { get; set; }
        #endregion
        
        #region Parameter RecordType
        /// <summary>
        /// <para>
        /// <para>The type of the resource record set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Route53.RRType")]
        public Amazon.Route53.RRType RecordType { get; set; }
        #endregion
        
        #region Parameter ResolverIP
        /// <summary>
        /// <para>
        /// <para>If you want to simulate a request from a specific DNS resolver, specify the IP address
        /// for that resolver. If you omit this value, <code>TestDnsAnswer</code> uses the IP
        /// address of a DNS resolver in the AWS US East (N. Virginia) Region (<code>us-east-1</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResolverIP { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.HostedZoneId = this.HostedZoneId;
            context.RecordName = this.RecordName;
            context.RecordType = this.RecordType;
            context.ResolverIP = this.ResolverIP;
            context.EDNS0ClientSubnetIP = this.EDNS0ClientSubnetIP;
            context.EDNS0ClientSubnetMask = this.EDNS0ClientSubnetMask;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Route53.Model.TestDNSAnswerRequest();
            
            if (cmdletContext.HostedZoneId != null)
            {
                request.HostedZoneId = cmdletContext.HostedZoneId;
            }
            if (cmdletContext.RecordName != null)
            {
                request.RecordName = cmdletContext.RecordName;
            }
            if (cmdletContext.RecordType != null)
            {
                request.RecordType = cmdletContext.RecordType;
            }
            if (cmdletContext.ResolverIP != null)
            {
                request.ResolverIP = cmdletContext.ResolverIP;
            }
            if (cmdletContext.EDNS0ClientSubnetIP != null)
            {
                request.EDNS0ClientSubnetIP = cmdletContext.EDNS0ClientSubnetIP;
            }
            if (cmdletContext.EDNS0ClientSubnetMask != null)
            {
                request.EDNS0ClientSubnetMask = cmdletContext.EDNS0ClientSubnetMask;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Route53.Model.TestDNSAnswerResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.TestDNSAnswerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "TestDNSAnswer");
            try
            {
                #if DESKTOP
                return client.TestDNSAnswer(request);
                #elif CORECLR
                return client.TestDNSAnswerAsync(request).GetAwaiter().GetResult();
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
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String HostedZoneId { get; set; }
            public System.String RecordName { get; set; }
            public Amazon.Route53.RRType RecordType { get; set; }
            public System.String ResolverIP { get; set; }
            public System.String EDNS0ClientSubnetIP { get; set; }
            public System.String EDNS0ClientSubnetMask { get; set; }
        }
        
    }
}
