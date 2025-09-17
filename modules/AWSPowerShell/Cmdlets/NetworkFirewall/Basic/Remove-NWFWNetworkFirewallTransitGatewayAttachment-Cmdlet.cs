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
    /// Deletes a transit gateway attachment from a Network Firewall. Either the firewall
    /// owner or the transit gateway owner can delete the attachment.
    /// 
    ///  <important><para>
    /// After you delete a transit gateway attachment, traffic will no longer flow through
    /// the firewall endpoints.
    /// </para></important><para>
    /// After you initiate the delete operation, use <a>DescribeFirewall</a> to monitor the
    /// deletion status.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "NWFWNetworkFirewallTransitGatewayAttachment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.NetworkFirewall.Model.DeleteNetworkFirewallTransitGatewayAttachmentResponse")]
    [AWSCmdlet("Calls the AWS Network Firewall DeleteNetworkFirewallTransitGatewayAttachment API operation.", Operation = new[] {"DeleteNetworkFirewallTransitGatewayAttachment"}, SelectReturnType = typeof(Amazon.NetworkFirewall.Model.DeleteNetworkFirewallTransitGatewayAttachmentResponse))]
    [AWSCmdletOutput("Amazon.NetworkFirewall.Model.DeleteNetworkFirewallTransitGatewayAttachmentResponse",
        "This cmdlet returns an Amazon.NetworkFirewall.Model.DeleteNetworkFirewallTransitGatewayAttachmentResponse object containing multiple properties."
    )]
    public partial class RemoveNWFWNetworkFirewallTransitGatewayAttachmentCmdlet : AmazonNetworkFirewallClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter TransitGatewayAttachmentId
        /// <summary>
        /// <para>
        /// <para>Required. The unique identifier of the transit gateway attachment to delete.</para>
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
        public System.String TransitGatewayAttachmentId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFirewall.Model.DeleteNetworkFirewallTransitGatewayAttachmentResponse).
        /// Specifying the name of a property of type Amazon.NetworkFirewall.Model.DeleteNetworkFirewallTransitGatewayAttachmentResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TransitGatewayAttachmentId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-NWFWNetworkFirewallTransitGatewayAttachment (DeleteNetworkFirewallTransitGatewayAttachment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkFirewall.Model.DeleteNetworkFirewallTransitGatewayAttachmentResponse, RemoveNWFWNetworkFirewallTransitGatewayAttachmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.TransitGatewayAttachmentId = this.TransitGatewayAttachmentId;
            #if MODULAR
            if (this.TransitGatewayAttachmentId == null && ParameterWasBound(nameof(this.TransitGatewayAttachmentId)))
            {
                WriteWarning("You are passing $null as a value for parameter TransitGatewayAttachmentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.NetworkFirewall.Model.DeleteNetworkFirewallTransitGatewayAttachmentRequest();
            
            if (cmdletContext.TransitGatewayAttachmentId != null)
            {
                request.TransitGatewayAttachmentId = cmdletContext.TransitGatewayAttachmentId;
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
        
        private Amazon.NetworkFirewall.Model.DeleteNetworkFirewallTransitGatewayAttachmentResponse CallAWSServiceOperation(IAmazonNetworkFirewall client, Amazon.NetworkFirewall.Model.DeleteNetworkFirewallTransitGatewayAttachmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Firewall", "DeleteNetworkFirewallTransitGatewayAttachment");
            try
            {
                return client.DeleteNetworkFirewallTransitGatewayAttachmentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String TransitGatewayAttachmentId { get; set; }
            public System.Func<Amazon.NetworkFirewall.Model.DeleteNetworkFirewallTransitGatewayAttachmentResponse, RemoveNWFWNetworkFirewallTransitGatewayAttachmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
