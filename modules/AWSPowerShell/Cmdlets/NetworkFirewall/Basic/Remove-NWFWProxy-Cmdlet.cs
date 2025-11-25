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
using Amazon.NetworkFirewall;
using Amazon.NetworkFirewall.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.NWFW
{
    /// <summary>
    /// Deletes the specified <a>Proxy</a>. 
    /// 
    ///  
    /// <para>
    /// Detaches a Proxy configuration from a NAT Gateway. 
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "NWFWProxy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.NetworkFirewall.Model.DeleteProxyResponse")]
    [AWSCmdlet("Calls the AWS Network Firewall DeleteProxy API operation.", Operation = new[] {"DeleteProxy"}, SelectReturnType = typeof(Amazon.NetworkFirewall.Model.DeleteProxyResponse))]
    [AWSCmdletOutput("Amazon.NetworkFirewall.Model.DeleteProxyResponse",
        "This cmdlet returns an Amazon.NetworkFirewall.Model.DeleteProxyResponse object containing multiple properties."
    )]
    public partial class RemoveNWFWProxyCmdlet : AmazonNetworkFirewallClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter NatGatewayId
        /// <summary>
        /// <para>
        /// <para>The NAT Gateway the proxy is attached to. </para>
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
        public System.String NatGatewayId { get; set; }
        #endregion
        
        #region Parameter ProxyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a proxy.</para><para>You must specify the ARN or the name, and you can specify both. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProxyArn { get; set; }
        #endregion
        
        #region Parameter ProxyName
        /// <summary>
        /// <para>
        /// <para>The descriptive name of the proxy. You can't change the name of a proxy after you
        /// create it.</para><para>You must specify the ARN or the name, and you can specify both. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProxyName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFirewall.Model.DeleteProxyResponse).
        /// Specifying the name of a property of type Amazon.NetworkFirewall.Model.DeleteProxyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NatGatewayId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-NWFWProxy (DeleteProxy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkFirewall.Model.DeleteProxyResponse, RemoveNWFWProxyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.NatGatewayId = this.NatGatewayId;
            #if MODULAR
            if (this.NatGatewayId == null && ParameterWasBound(nameof(this.NatGatewayId)))
            {
                WriteWarning("You are passing $null as a value for parameter NatGatewayId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProxyArn = this.ProxyArn;
            context.ProxyName = this.ProxyName;
            
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
            var request = new Amazon.NetworkFirewall.Model.DeleteProxyRequest();
            
            if (cmdletContext.NatGatewayId != null)
            {
                request.NatGatewayId = cmdletContext.NatGatewayId;
            }
            if (cmdletContext.ProxyArn != null)
            {
                request.ProxyArn = cmdletContext.ProxyArn;
            }
            if (cmdletContext.ProxyName != null)
            {
                request.ProxyName = cmdletContext.ProxyName;
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
        
        private Amazon.NetworkFirewall.Model.DeleteProxyResponse CallAWSServiceOperation(IAmazonNetworkFirewall client, Amazon.NetworkFirewall.Model.DeleteProxyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Firewall", "DeleteProxy");
            try
            {
                return client.DeleteProxyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String NatGatewayId { get; set; }
            public System.String ProxyArn { get; set; }
            public System.String ProxyName { get; set; }
            public System.Func<Amazon.NetworkFirewall.Model.DeleteProxyResponse, RemoveNWFWProxyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
