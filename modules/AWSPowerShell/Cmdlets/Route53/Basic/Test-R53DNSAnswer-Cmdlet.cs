/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// 
    ///  
    /// <para>
    /// This call only supports querying public hosted zones.
    /// </para><note><para>
    /// The <c>TestDnsAnswer </c> returns information similar to what you would expect from
    /// the answer section of the <c>dig</c> command. Therefore, if you query for the name
    /// servers of a subdomain that point to the parent name servers, those will not be returned.
    /// </para></note>
    /// </summary>
    [Cmdlet("Test", "R53DNSAnswer")]
    [OutputType("Amazon.Route53.Model.TestDNSAnswerResponse")]
    [AWSCmdlet("Calls the Amazon Route 53 TestDNSAnswer API operation.", Operation = new[] {"TestDNSAnswer"}, SelectReturnType = typeof(Amazon.Route53.Model.TestDNSAnswerResponse))]
    [AWSCmdletOutput("Amazon.Route53.Model.TestDNSAnswerResponse",
        "This cmdlet returns an Amazon.Route53.Model.TestDNSAnswerResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class TestR53DNSAnswerCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EDNS0ClientSubnetIP
        /// <summary>
        /// <para>
        /// <para>If the resolver that you specified for resolverip supports EDNS0, specify the IPv4
        /// or IPv6 address of a client in the applicable location, for example, <c>192.0.2.44</c>
        /// or <c>2001:db8:85a3::8a2e:370:7334</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EDNS0ClientSubnetIP { get; set; }
        #endregion
        
        #region Parameter EDNS0ClientSubnetMask
        /// <summary>
        /// <para>
        /// <para>If you specify an IP address for <c>edns0clientsubnetip</c>, you can optionally specify
        /// the number of bits of the IP address that you want the checking tool to include in
        /// the DNS query. For example, if you specify <c>192.0.2.44</c> for <c>edns0clientsubnetip</c>
        /// and <c>24</c> for <c>edns0clientsubnetmask</c>, the checking tool will simulate a
        /// request from 192.0.2.0/24. The default value is 24 bits for IPv4 addresses and 64
        /// bits for IPv6 addresses.</para><para>The range of valid values depends on whether <c>edns0clientsubnetip</c> is an IPv4
        /// or an IPv6 address:</para><ul><li><para><b>IPv4</b>: Specify a value between 0 and 32</para></li><li><para><b>IPv6</b>: Specify a value between 0 and 128</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EDNS0ClientSubnetMask { get; set; }
        #endregion
        
        #region Parameter HostedZoneId
        /// <summary>
        /// <para>
        /// <para>The ID of the hosted zone that you want Amazon Route 53 to simulate a query for.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String HostedZoneId { get; set; }
        #endregion
        
        #region Parameter RecordName
        /// <summary>
        /// <para>
        /// <para>The name of the resource record set that you want Amazon Route 53 to simulate a query
        /// for.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String RecordName { get; set; }
        #endregion
        
        #region Parameter RecordType
        /// <summary>
        /// <para>
        /// <para>The type of the resource record set.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Route53.RRType")]
        public Amazon.Route53.RRType RecordType { get; set; }
        #endregion
        
        #region Parameter ResolverIP
        /// <summary>
        /// <para>
        /// <para>If you want to simulate a request from a specific DNS resolver, specify the IP address
        /// for that resolver. If you omit this value, <c>TestDnsAnswer</c> uses the IP address
        /// of a DNS resolver in the Amazon Web Services US East (N. Virginia) Region (<c>us-east-1</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResolverIP { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53.Model.TestDNSAnswerResponse).
        /// Specifying the name of a property of type Amazon.Route53.Model.TestDNSAnswerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53.Model.TestDNSAnswerResponse, TestR53DNSAnswerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.HostedZoneId = this.HostedZoneId;
            #if MODULAR
            if (this.HostedZoneId == null && ParameterWasBound(nameof(this.HostedZoneId)))
            {
                WriteWarning("You are passing $null as a value for parameter HostedZoneId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RecordName = this.RecordName;
            #if MODULAR
            if (this.RecordName == null && ParameterWasBound(nameof(this.RecordName)))
            {
                WriteWarning("You are passing $null as a value for parameter RecordName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RecordType = this.RecordType;
            #if MODULAR
            if (this.RecordType == null && ParameterWasBound(nameof(this.RecordType)))
            {
                WriteWarning("You are passing $null as a value for parameter RecordType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
            public System.Func<Amazon.Route53.Model.TestDNSAnswerResponse, TestR53DNSAnswerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
