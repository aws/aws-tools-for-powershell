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
using Amazon.NetworkManager;
using Amazon.NetworkManager.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.NMGR
{
    /// <summary>
    /// Updates the NAT configuration of a core network attachment. You can enable or disable
    /// NAT gateway support, specify whether the core network installs system routes for the
    /// NAT CIDR blocks, and replace the NAT rules of the attachment. Specify at least one
    /// of <c>NatGatewaySupport</c>, <c>NatSystemRouteSupport</c>, or <c>NatGatewayRules</c>.
    /// 
    ///  
    /// <para>
    /// Only the core network owner can update the NAT configuration of an attachment. The
    /// attachment must be in the <c>AVAILABLE</c>, <c>PENDING_ATTACHMENT_ACCEPTANCE</c>,
    /// or <c>PENDING_TAG_ACCEPTANCE</c> state. Changes are applied asynchronously, and the
    /// attachment is in the <c>UPDATING</c> state while they are applied. If the attachment
    /// is pending acceptance, the NAT configuration is stored and is applied after the attachment
    /// is accepted.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "NMGRAttachmentNatConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkManager.Model.UpdateAttachmentNatConfigurationResponse")]
    [AWSCmdlet("Calls the AWS Network Manager UpdateAttachmentNatConfiguration API operation.", Operation = new[] {"UpdateAttachmentNatConfiguration"}, SelectReturnType = typeof(Amazon.NetworkManager.Model.UpdateAttachmentNatConfigurationResponse))]
    [AWSCmdletOutput("Amazon.NetworkManager.Model.UpdateAttachmentNatConfigurationResponse",
        "This cmdlet returns an Amazon.NetworkManager.Model.UpdateAttachmentNatConfigurationResponse object containing multiple properties."
    )]
    public partial class UpdateNMGRAttachmentNatConfigurationCmdlet : AmazonNetworkManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AttachmentId
        /// <summary>
        /// <para>
        /// <para>The ID of the attachment to update the NAT configuration for.</para>
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
        public System.String AttachmentId { get; set; }
        #endregion
        
        #region Parameter NatGatewayRule
        /// <summary>
        /// <para>
        /// <para>The complete set of NAT rules for the attachment, up to 50 rules. The rules that you
        /// specify replace the existing rules of the attachment, matched by rule number. Existing
        /// rules that aren't included in the request are deleted. To delete all NAT rules, specify
        /// an empty list. You can delete all NAT rules only when NAT gateway support is disabled,
        /// or when you disable it in the same request. If you omit this parameter, the existing
        /// rules are unchanged.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NatGatewayRules")]
        public Amazon.NetworkManager.Model.NatRuleRequest[] NatGatewayRule { get; set; }
        #endregion
        
        #region Parameter NatGatewaySupport
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable or disable NAT gateway support on the attachment. When
        /// you disable NAT gateway support, the attachment keeps its NAT rules but doesn't apply
        /// them. To enable NAT gateway support, the attachment must have at least one NAT rule,
        /// either specified in this request or already configured on the attachment. If you omit
        /// this parameter, NAT gateway support is unchanged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.NetworkManager.NatGatewaySupportValue")]
        public Amazon.NetworkManager.NatGatewaySupportValue NatGatewaySupport { get; set; }
        #endregion
        
        #region Parameter NatSystemRouteSupport
        /// <summary>
        /// <para>
        /// <para>Specifies whether the core network installs system routes for the NAT CIDR blocks
        /// of the attachment's NAT rules. System routes have a route type of <c>SYSTEM</c>. NAT
        /// is applied to traffic whether or not this option is enabled. If you omit this parameter,
        /// the current value is unchanged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? NatSystemRouteSupport { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The client token associated with the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkManager.Model.UpdateAttachmentNatConfigurationResponse).
        /// Specifying the name of a property of type Amazon.NetworkManager.Model.UpdateAttachmentNatConfigurationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AttachmentId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-NMGRAttachmentNatConfiguration (UpdateAttachmentNatConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkManager.Model.UpdateAttachmentNatConfigurationResponse, UpdateNMGRAttachmentNatConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AttachmentId = this.AttachmentId;
            #if MODULAR
            if (this.AttachmentId == null && ParameterWasBound(nameof(this.AttachmentId)))
            {
                WriteWarning("You are passing $null as a value for parameter AttachmentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            if (this.NatGatewayRule != null)
            {
                context.NatGatewayRule = new List<Amazon.NetworkManager.Model.NatRuleRequest>(this.NatGatewayRule);
            }
            context.NatGatewaySupport = this.NatGatewaySupport;
            context.NatSystemRouteSupport = this.NatSystemRouteSupport;
            
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
            var request = new Amazon.NetworkManager.Model.UpdateAttachmentNatConfigurationRequest();
            
            if (cmdletContext.AttachmentId != null)
            {
                request.AttachmentId = cmdletContext.AttachmentId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.NatGatewayRule != null)
            {
                request.NatGatewayRules = cmdletContext.NatGatewayRule;
            }
            if (cmdletContext.NatGatewaySupport != null)
            {
                request.NatGatewaySupport = cmdletContext.NatGatewaySupport;
            }
            if (cmdletContext.NatSystemRouteSupport != null)
            {
                request.NatSystemRouteSupport = cmdletContext.NatSystemRouteSupport.Value;
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
        
        private Amazon.NetworkManager.Model.UpdateAttachmentNatConfigurationResponse CallAWSServiceOperation(IAmazonNetworkManager client, Amazon.NetworkManager.Model.UpdateAttachmentNatConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Manager", "UpdateAttachmentNatConfiguration");
            try
            {
                return client.UpdateAttachmentNatConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AttachmentId { get; set; }
            public System.String ClientToken { get; set; }
            public List<Amazon.NetworkManager.Model.NatRuleRequest> NatGatewayRule { get; set; }
            public Amazon.NetworkManager.NatGatewaySupportValue NatGatewaySupport { get; set; }
            public System.Boolean? NatSystemRouteSupport { get; set; }
            public System.Func<Amazon.NetworkManager.Model.UpdateAttachmentNatConfigurationResponse, UpdateNMGRAttachmentNatConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
