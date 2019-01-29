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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Describes one or more of your VPN customer gateways.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="http://docs.aws.amazon.com/vpn/latest/s2svpn/VPC_VPN.html">AWS
    /// Site-to-Site VPN</a> in the <i>AWS Site-to-Site VPN User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2CustomerGateway")]
    [OutputType("Amazon.EC2.Model.CustomerGateway")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud DescribeCustomerGateways API operation.", Operation = new[] {"DescribeCustomerGateways"})]
    [AWSCmdletOutput("Amazon.EC2.Model.CustomerGateway",
        "This cmdlet returns a collection of CustomerGateway objects.",
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
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
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
            
            if (this.CustomerGatewayId != null)
            {
                context.CustomerGatewayIds = new List<System.String>(this.CustomerGatewayId);
            }
            if (this.Filter != null)
            {
                context.Filters = new List<Amazon.EC2.Model.Filter>(this.Filter);
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
            
            if (cmdletContext.CustomerGatewayIds != null)
            {
                request.CustomerGatewayIds = cmdletContext.CustomerGatewayIds;
            }
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.CustomerGateways;
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
        
        private Amazon.EC2.Model.DescribeCustomerGatewaysResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeCustomerGatewaysRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "DescribeCustomerGateways");
            try
            {
                #if DESKTOP
                return client.DescribeCustomerGateways(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeCustomerGatewaysAsync(request);
                return task.Result;
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
            public List<System.String> CustomerGatewayIds { get; set; }
            public List<Amazon.EC2.Model.Filter> Filters { get; set; }
        }
        
    }
}
