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
    /// Describes one or more of your VPN customer gateways.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/vpn/latest/s2svpn/VPC_VPN.html">AWS
    /// Site-to-Site VPN</a> in the <i>AWS Site-to-Site VPN User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2CustomerGateway")]
    [OutputType("Amazon.EC2.Model.CustomerGateway")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeCustomerGateways API operation.", Operation = new[] {"DescribeCustomerGateways"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeCustomerGatewaysResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.CustomerGateway or Amazon.EC2.Model.DescribeCustomerGatewaysResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.CustomerGateway objects.",
        "The service call response (type Amazon.EC2.Model.DescribeCustomerGatewaysResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEC2CustomerGatewayCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter CustomerGatewayId
        /// <summary>
        /// <para>
        /// <para>One or more customer gateway IDs.</para><para>Default: Describes all your customer gateways.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("CustomerGatewayIds")]
        public System.String[] CustomerGatewayId { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters.</para><ul><li><para><code>bgp-asn</code> - The customer gateway's Border Gateway Protocol (BGP) Autonomous
        /// System Number (ASN).</para></li><li><para><code>customer-gateway-id</code> - The ID of the customer gateway.</para></li><li><para><code>ip-address</code> - The IP address of the customer gateway's Internet-routable
        /// external interface.</para></li><li><para><code>state</code> - The state of the customer gateway (<code>pending</code> | <code>available</code>
        /// | <code>deleting</code> | <code>deleted</code>).</para></li><li><para><code>type</code> - The type of customer gateway. Currently, the only supported type
        /// is <code>ipsec.1</code>.</para></li><li><para><code>tag</code>:&lt;key&gt; - The key/value combination of a tag assigned to the
        /// resource. Use the tag key in the filter name and the tag value as the filter value.
        /// For example, to find all resources that have a tag with the key <code>Owner</code>
        /// and the value <code>TeamA</code>, specify <code>tag:Owner</code> for the filter name
        /// and <code>TeamA</code> for the filter value.</para></li><li><para><code>tag-key</code> - The key of a tag assigned to the resource. Use this filter
        /// to find all resources assigned a tag with a specific key, regardless of the tag value.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CustomerGateways'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribeCustomerGatewaysResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribeCustomerGatewaysResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CustomerGateways";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CustomerGatewayId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CustomerGatewayId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CustomerGatewayId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeCustomerGatewaysResponse, GetEC2CustomerGatewayCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CustomerGatewayId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.CustomerGatewayId != null)
            {
                context.CustomerGatewayId = new List<System.String>(this.CustomerGatewayId);
            }
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.EC2.Model.Filter>(this.Filter);
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
            var request = new Amazon.EC2.Model.DescribeCustomerGatewaysRequest();
            
            if (cmdletContext.CustomerGatewayId != null)
            {
                request.CustomerGatewayIds = cmdletContext.CustomerGatewayId;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
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
        
        private Amazon.EC2.Model.DescribeCustomerGatewaysResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeCustomerGatewaysRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribeCustomerGateways");
            try
            {
                #if DESKTOP
                return client.DescribeCustomerGateways(request);
                #elif CORECLR
                return client.DescribeCustomerGatewaysAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> CustomerGatewayId { get; set; }
            public List<Amazon.EC2.Model.Filter> Filter { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeCustomerGatewaysResponse, GetEC2CustomerGatewayCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CustomerGateways;
        }
        
    }
}
