/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.DirectConnect;
using Amazon.DirectConnect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DC
{
    /// <summary>
    /// <note><para>
    /// Deprecated. Use <c>DescribeVpnGateways</c> instead. See <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_DescribeVpnGateways.html">DescribeVPNGateways</a>
    /// in the <i>Amazon Elastic Compute Cloud API Reference</i>.
    /// </para></note><para>
    /// Lists the virtual private gateways owned by the Amazon Web Services account.
    /// </para><para>
    /// You can create one or more Direct Connect private virtual interfaces linked to a virtual
    /// private gateway.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "DCVirtualGateway")]
    [OutputType("Amazon.DirectConnect.Model.VirtualGateway")]
    [AWSCmdlet("Calls the AWS Direct Connect DescribeVirtualGateways API operation.", Operation = new[] {"DescribeVirtualGateways"}, SelectReturnType = typeof(Amazon.DirectConnect.Model.DescribeVirtualGatewaysResponse))]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.VirtualGateway or Amazon.DirectConnect.Model.DescribeVirtualGatewaysResponse",
        "This cmdlet returns a collection of Amazon.DirectConnect.Model.VirtualGateway objects.",
        "The service call response (type Amazon.DirectConnect.Model.DescribeVirtualGatewaysResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetDCVirtualGatewayCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VirtualGateways'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectConnect.Model.DescribeVirtualGatewaysResponse).
        /// Specifying the name of a property of type Amazon.DirectConnect.Model.DescribeVirtualGatewaysResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VirtualGateways";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DirectConnect.Model.DescribeVirtualGatewaysResponse, GetDCVirtualGatewayCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
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
            var request = new Amazon.DirectConnect.Model.DescribeVirtualGatewaysRequest();
            
            
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
        
        private Amazon.DirectConnect.Model.DescribeVirtualGatewaysResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.DescribeVirtualGatewaysRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "DescribeVirtualGateways");
            try
            {
                return client.DescribeVirtualGatewaysAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.DirectConnect.Model.DescribeVirtualGatewaysResponse, GetDCVirtualGatewayCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VirtualGateways;
        }
        
    }
}
