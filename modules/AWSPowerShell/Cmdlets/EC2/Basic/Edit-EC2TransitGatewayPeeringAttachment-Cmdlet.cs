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
using Amazon.EC2;
using Amazon.EC2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Modifies the options for a transit gateway peering attachment. The peering attachment
    /// must be in the <c>available</c> state.
    /// 
    ///  
    /// <para>
    /// You can allow multipath resilience for your side of an inter-Region transit gateway
    /// peering attachment between supported Regions. Multipath resilience isn't supported
    /// for transit gateway peering attachments in the same Region. It takes effect only when
    /// both the requester and the accepter allow it. To modify the requester side, send the
    /// request in the Region of the requester transit gateway. To modify the accepter side,
    /// send the request in the Region of the accepter transit gateway. To check whether multipath
    /// resilience is in effect, use <a>DescribeTransitGatewayPeeringAttachments</a> and check
    /// <c>multipathResilienceStatus</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "EC2TransitGatewayPeeringAttachment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.TransitGatewayPeeringAttachment")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud ModifyTransitGatewayPeeringAttachment API operation.", Operation = new[] {"ModifyTransitGatewayPeeringAttachment"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyTransitGatewayPeeringAttachmentResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.TransitGatewayPeeringAttachment or Amazon.EC2.Model.ModifyTransitGatewayPeeringAttachmentResponse",
        "This cmdlet returns an Amazon.EC2.Model.TransitGatewayPeeringAttachment object.",
        "The service call response (type Amazon.EC2.Model.ModifyTransitGatewayPeeringAttachmentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditEC2TransitGatewayPeeringAttachmentCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Options_AllowMultipathResilience
        /// <summary>
        /// <para>
        /// <para>Specifies whether you allow multipath resilience for your side of the transit gateway
        /// peering attachment. Multipath resilience is supported only for inter-Region transit
        /// gateway peering attachments between supported Regions. It takes effect only when both
        /// the requester and the accepter allow it. If you don't specify this parameter, the
        /// current setting doesn't change.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Options_AllowMultipathResilience { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Checks whether you have the required permissions for the action, without actually
        /// making the request, and provides an error response. If you have the required permissions,
        /// the error response is <c>DryRunOperation</c>. Otherwise, it is <c>UnauthorizedOperation</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter Options_MultipathResilienceMode
        /// <summary>
        /// <para>
        /// <para>The multipath resilience mode. You can specify this parameter only if <c>AllowMultipathResilience</c>
        /// is <c>true</c>.</para><para>The following value is valid:</para><ul><li><para><c>always-on</c> – Replicates traffic across multiple network paths while multipath
        /// resilience is in effect.</para></li></ul><para>If <c>AllowMultipathResilience</c> is <c>true</c> and you don't specify a mode, the
        /// default is <c>always-on</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.TransitGatewayPeeringAttachmentMultipathResilienceMode")]
        public Amazon.EC2.TransitGatewayPeeringAttachmentMultipathResilienceMode Options_MultipathResilienceMode { get; set; }
        #endregion
        
        #region Parameter TransitGatewayAttachmentId
        /// <summary>
        /// <para>
        /// <para>The ID of the transit gateway peering attachment.</para>
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
        public System.String TransitGatewayAttachmentId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TransitGatewayPeeringAttachment'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyTransitGatewayPeeringAttachmentResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyTransitGatewayPeeringAttachmentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TransitGatewayPeeringAttachment";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2TransitGatewayPeeringAttachment (ModifyTransitGatewayPeeringAttachment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyTransitGatewayPeeringAttachmentResponse, EditEC2TransitGatewayPeeringAttachmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DryRun = this.DryRun;
            context.Options_AllowMultipathResilience = this.Options_AllowMultipathResilience;
            context.Options_MultipathResilienceMode = this.Options_MultipathResilienceMode;
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
            var request = new Amazon.EC2.Model.ModifyTransitGatewayPeeringAttachmentRequest();
            
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            
             // populate Options
            var requestOptionsIsNull = true;
            request.Options = new Amazon.EC2.Model.ModifyTransitGatewayPeeringAttachmentRequestOptions();
            System.Boolean? requestOptions_options_AllowMultipathResilience = null;
            if (cmdletContext.Options_AllowMultipathResilience != null)
            {
                requestOptions_options_AllowMultipathResilience = cmdletContext.Options_AllowMultipathResilience.Value;
            }
            if (requestOptions_options_AllowMultipathResilience != null)
            {
                request.Options.AllowMultipathResilience = requestOptions_options_AllowMultipathResilience.Value;
                requestOptionsIsNull = false;
            }
            Amazon.EC2.TransitGatewayPeeringAttachmentMultipathResilienceMode requestOptions_options_MultipathResilienceMode = null;
            if (cmdletContext.Options_MultipathResilienceMode != null)
            {
                requestOptions_options_MultipathResilienceMode = cmdletContext.Options_MultipathResilienceMode;
            }
            if (requestOptions_options_MultipathResilienceMode != null)
            {
                request.Options.MultipathResilienceMode = requestOptions_options_MultipathResilienceMode;
                requestOptionsIsNull = false;
            }
             // determine if request.Options should be set to null
            if (requestOptionsIsNull)
            {
                request.Options = null;
            }
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
        
        private Amazon.EC2.Model.ModifyTransitGatewayPeeringAttachmentResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyTransitGatewayPeeringAttachmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "ModifyTransitGatewayPeeringAttachment");
            try
            {
                return client.ModifyTransitGatewayPeeringAttachmentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? DryRun { get; set; }
            public System.Boolean? Options_AllowMultipathResilience { get; set; }
            public Amazon.EC2.TransitGatewayPeeringAttachmentMultipathResilienceMode Options_MultipathResilienceMode { get; set; }
            public System.String TransitGatewayAttachmentId { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyTransitGatewayPeeringAttachmentResponse, EditEC2TransitGatewayPeeringAttachmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TransitGatewayPeeringAttachment;
        }
        
    }
}
