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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Describes the specified Elastic IP addresses or all of your Elastic IP addresses.
    /// 
    ///  
    /// <para>
    /// An Elastic IP address is for use in either the EC2-Classic platform or in a VPC. For
    /// more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/elastic-ip-addresses-eip.html">Elastic
    /// IP Addresses</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para><note><para>
    /// We are retiring EC2-Classic. We recommend that you migrate from EC2-Classic to a VPC.
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/vpc-migrate.html">Migrate
    /// from EC2-Classic to a VPC</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "EC2Address")]
    [OutputType("Amazon.EC2.Model.Address")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeAddresses API operation.", Operation = new[] {"DescribeAddresses"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeAddressesResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.Address or Amazon.EC2.Model.DescribeAddressesResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.Address objects.",
        "The service call response (type Amazon.EC2.Model.DescribeAddressesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEC2AddressCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter AllocationId
        /// <summary>
        /// <para>
        /// <para>[EC2-VPC] Information about the allocation IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("AllocationIds")]
        public System.String[] AllocationId { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters. Filter names and values are case-sensitive.</para><ul><li><para><code>allocation-id</code> - [EC2-VPC] The allocation ID for the address.</para></li><li><para><code>association-id</code> - [EC2-VPC] The association ID for the address.</para></li><li><para><code>domain</code> - Indicates whether the address is for use in EC2-Classic (<code>standard</code>)
        /// or in a VPC (<code>vpc</code>).</para></li><li><para><code>instance-id</code> - The ID of the instance the address is associated with,
        /// if any.</para></li><li><para><code>network-border-group</code> - A unique set of Availability Zones, Local Zones,
        /// or Wavelength Zones from where Amazon Web Services advertises IP addresses. </para></li><li><para><code>network-interface-id</code> - [EC2-VPC] The ID of the network interface that
        /// the address is associated with, if any.</para></li><li><para><code>network-interface-owner-id</code> - The Amazon Web Services account ID of the
        /// owner.</para></li><li><para><code>private-ip-address</code> - [EC2-VPC] The private IP address associated with
        /// the Elastic IP address.</para></li><li><para><code>public-ip</code> - The Elastic IP address, or the carrier IP address.</para></li><li><para><code>tag</code>:&lt;key&gt; - The key/value combination of a tag assigned to the
        /// resource. Use the tag key in the filter name and the tag value as the filter value.
        /// For example, to find all resources that have a tag with the key <code>Owner</code>
        /// and the value <code>TeamA</code>, specify <code>tag:Owner</code> for the filter name
        /// and <code>TeamA</code> for the filter value.</para></li><li><para><code>tag-key</code> - The key of a tag assigned to the resource. Use this filter
        /// to find all resources assigned a tag with a specific key, regardless of the tag value.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter PublicIp
        /// <summary>
        /// <para>
        /// <para>One or more Elastic IP addresses.</para><para>Default: Describes all your Elastic IP addresses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("PublicIps")]
        public System.String[] PublicIp { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Addresses'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribeAddressesResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribeAddressesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Addresses";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PublicIp parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PublicIp' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PublicIp' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeAddressesResponse, GetEC2AddressCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PublicIp;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AllocationId != null)
            {
                context.AllocationId = new List<System.String>(this.AllocationId);
            }
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            if (this.PublicIp != null)
            {
                context.PublicIp = new List<System.String>(this.PublicIp);
            }
            
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
            var request = new Amazon.EC2.Model.DescribeAddressesRequest();
            
            if (cmdletContext.AllocationId != null)
            {
                request.AllocationIds = cmdletContext.AllocationId;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.PublicIp != null)
            {
                request.PublicIps = cmdletContext.PublicIp;
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
        
        private Amazon.EC2.Model.DescribeAddressesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeAddressesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribeAddresses");
            try
            {
                #if DESKTOP
                return client.DescribeAddresses(request);
                #elif CORECLR
                return client.DescribeAddressesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AllocationId { get; set; }
            public List<Amazon.EC2.Model.Filter> Filter { get; set; }
            public List<System.String> PublicIp { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeAddressesResponse, GetEC2AddressCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Addresses;
        }
        
    }
}
