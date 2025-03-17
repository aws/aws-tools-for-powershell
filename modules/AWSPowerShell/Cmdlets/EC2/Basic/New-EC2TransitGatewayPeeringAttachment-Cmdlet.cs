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

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Requests a transit gateway peering attachment between the specified transit gateway
    /// (requester) and a peer transit gateway (accepter). The peer transit gateway can be
    /// in your account or a different Amazon Web Services account.
    /// 
    ///  
    /// <para>
    /// After you create the peering attachment, the owner of the accepter transit gateway
    /// must accept the attachment request.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2TransitGatewayPeeringAttachment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.TransitGatewayPeeringAttachment")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateTransitGatewayPeeringAttachment API operation.", Operation = new[] {"CreateTransitGatewayPeeringAttachment"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateTransitGatewayPeeringAttachmentResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.TransitGatewayPeeringAttachment or Amazon.EC2.Model.CreateTransitGatewayPeeringAttachmentResponse",
        "This cmdlet returns an Amazon.EC2.Model.TransitGatewayPeeringAttachment object.",
        "The service call response (type Amazon.EC2.Model.CreateTransitGatewayPeeringAttachmentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2TransitGatewayPeeringAttachmentCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        
        #region Parameter Options_DynamicRouting
        /// <summary>
        /// <para>
        /// <para>Indicates whether dynamic routing is enabled or disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.DynamicRoutingValue")]
        public Amazon.EC2.DynamicRoutingValue Options_DynamicRouting { get; set; }
        #endregion
        
        #region Parameter PeerAccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account that owns the peer transit gateway.</para>
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
        public System.String PeerAccountId { get; set; }
        #endregion
        
        #region Parameter PeerRegion
        /// <summary>
        /// <para>
        /// <para>The Region where the peer transit gateway is located.</para>
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
        public System.String PeerRegion { get; set; }
        #endregion
        
        #region Parameter PeerTransitGatewayId
        /// <summary>
        /// <para>
        /// <para>The ID of the peer transit gateway with which to create the peering attachment.</para>
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
        public System.String PeerTransitGatewayId { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the transit gateway peering attachment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter TransitGatewayId
        /// <summary>
        /// <para>
        /// <para>The ID of the transit gateway.</para>
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
        public System.String TransitGatewayId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TransitGatewayPeeringAttachment'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateTransitGatewayPeeringAttachmentResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateTransitGatewayPeeringAttachmentResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TransitGatewayId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2TransitGatewayPeeringAttachment (CreateTransitGatewayPeeringAttachment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateTransitGatewayPeeringAttachmentResponse, NewEC2TransitGatewayPeeringAttachmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DryRun = this.DryRun;
            context.Options_DynamicRouting = this.Options_DynamicRouting;
            context.PeerAccountId = this.PeerAccountId;
            #if MODULAR
            if (this.PeerAccountId == null && ParameterWasBound(nameof(this.PeerAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter PeerAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PeerRegion = this.PeerRegion;
            #if MODULAR
            if (this.PeerRegion == null && ParameterWasBound(nameof(this.PeerRegion)))
            {
                WriteWarning("You are passing $null as a value for parameter PeerRegion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PeerTransitGatewayId = this.PeerTransitGatewayId;
            #if MODULAR
            if (this.PeerTransitGatewayId == null && ParameterWasBound(nameof(this.PeerTransitGatewayId)))
            {
                WriteWarning("You are passing $null as a value for parameter PeerTransitGatewayId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
            context.TransitGatewayId = this.TransitGatewayId;
            #if MODULAR
            if (this.TransitGatewayId == null && ParameterWasBound(nameof(this.TransitGatewayId)))
            {
                WriteWarning("You are passing $null as a value for parameter TransitGatewayId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.CreateTransitGatewayPeeringAttachmentRequest();
            
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            
             // populate Options
            var requestOptionsIsNull = true;
            request.Options = new Amazon.EC2.Model.CreateTransitGatewayPeeringAttachmentRequestOptions();
            Amazon.EC2.DynamicRoutingValue requestOptions_options_DynamicRouting = null;
            if (cmdletContext.Options_DynamicRouting != null)
            {
                requestOptions_options_DynamicRouting = cmdletContext.Options_DynamicRouting;
            }
            if (requestOptions_options_DynamicRouting != null)
            {
                request.Options.DynamicRouting = requestOptions_options_DynamicRouting;
                requestOptionsIsNull = false;
            }
             // determine if request.Options should be set to null
            if (requestOptionsIsNull)
            {
                request.Options = null;
            }
            if (cmdletContext.PeerAccountId != null)
            {
                request.PeerAccountId = cmdletContext.PeerAccountId;
            }
            if (cmdletContext.PeerRegion != null)
            {
                request.PeerRegion = cmdletContext.PeerRegion;
            }
            if (cmdletContext.PeerTransitGatewayId != null)
            {
                request.PeerTransitGatewayId = cmdletContext.PeerTransitGatewayId;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
            }
            if (cmdletContext.TransitGatewayId != null)
            {
                request.TransitGatewayId = cmdletContext.TransitGatewayId;
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
        
        private Amazon.EC2.Model.CreateTransitGatewayPeeringAttachmentResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateTransitGatewayPeeringAttachmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateTransitGatewayPeeringAttachment");
            try
            {
                return client.CreateTransitGatewayPeeringAttachmentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.EC2.DynamicRoutingValue Options_DynamicRouting { get; set; }
            public System.String PeerAccountId { get; set; }
            public System.String PeerRegion { get; set; }
            public System.String PeerTransitGatewayId { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.String TransitGatewayId { get; set; }
            public System.Func<Amazon.EC2.Model.CreateTransitGatewayPeeringAttachmentResponse, NewEC2TransitGatewayPeeringAttachmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TransitGatewayPeeringAttachment;
        }
        
    }
}
