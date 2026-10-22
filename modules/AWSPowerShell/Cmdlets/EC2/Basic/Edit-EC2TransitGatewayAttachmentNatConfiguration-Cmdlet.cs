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
    /// Modifies the NAT configuration for the specified transit gateway attachment. Use this
    /// operation to do the following:
    /// 
    ///  <ul><li><para>
    /// Enable or disable NAT gateway support for the attachment.
    /// </para></li><li><para>
    /// Specify whether the transit gateway installs routes for the NAT CIDRs.
    /// </para></li><li><para>
    /// Replace the NAT gateway rules for the attachment.
    /// </para></li></ul><para>
    /// Only the owner of the transit gateway can modify the NAT configuration.
    /// </para><para>
    /// With NAT gateway support enabled, the transit gateway translates addresses in each
    /// rule's <c>MatchSourceCidr</c> range to the corresponding addresses in its <c>NatCidr</c>
    /// range.
    /// </para><para>
    /// The transit gateway applies changes asynchronously. To check the result, use <c>GetTransitGatewayAttachmentNatConfiguration</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "EC2TransitGatewayAttachmentNatConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.ModifyTransitGatewayAttachmentNatConfigurationResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyTransitGatewayAttachmentNatConfiguration API operation.", Operation = new[] {"ModifyTransitGatewayAttachmentNatConfiguration"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyTransitGatewayAttachmentNatConfigurationResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.ModifyTransitGatewayAttachmentNatConfigurationResponse",
        "This cmdlet returns an Amazon.EC2.Model.ModifyTransitGatewayAttachmentNatConfigurationResponse object containing multiple properties."
    )]
    public partial class EditEC2TransitGatewayAttachmentNatConfigurationCmdlet : AmazonEC2ClientCmdlet, IExecutor
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
        
        #region Parameter NatGatewayRule
        /// <summary>
        /// <para>
        /// <para>The NAT gateway rules for the attachment. The rules that you specify replace all existing
        /// NAT gateway rules for the attachment. You can specify up to 50 rules for an attachment.
        /// If you omit this parameter, the existing rules don't change. To remove all rules,
        /// use <c>ResetNatGatewayRules</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NatGatewayRules")]
        public Amazon.EC2.Model.TransitGatewayNatRuleRequest[] NatGatewayRule { get; set; }
        #endregion
        
        #region Parameter NatGatewaySupport
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable or disable NAT gateway support for the attachment. To
        /// enable NAT gateway support, the attachment must have at least one NAT gateway rule.
        /// You can't modify the NAT configuration while NAT gateway support is <c>enabling</c>
        /// or <c>disabling</c>. If you omit this parameter, the current value doesn't change.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.TransitGatewayAttachmentNatGatewaySupportValue")]
        public Amazon.EC2.TransitGatewayAttachmentNatGatewaySupportValue NatGatewaySupport { get; set; }
        #endregion
        
        #region Parameter NatSystemRouteSupport
        /// <summary>
        /// <para>
        /// <para>Specifies whether the transit gateway installs routes for the NAT CIDRs in the route
        /// tables to which the attachment propagates. For VPC attachments, the transit gateway
        /// always installs these routes. You can enable or disable this option only for Amazon
        /// Web Services Direct Connect gateway attachments and Site-to-Site VPN attachments that
        /// use dynamic routing. For these attachments, the default is <c>enable</c>. If you omit
        /// this parameter, the current value doesn't change.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.TransitGatewayAttachmentNatSystemRouteSupportValue")]
        public Amazon.EC2.TransitGatewayAttachmentNatSystemRouteSupportValue NatSystemRouteSupport { get; set; }
        #endregion
        
        #region Parameter ResetNatGatewayRule
        /// <summary>
        /// <para>
        /// <para>Specifies whether to remove all NAT gateway rules from the attachment. If you omit
        /// this parameter, the transit gateway doesn't remove any rules. You can't specify this
        /// parameter together with <c>NatGatewayRules</c>. Because you can't enable NAT gateway
        /// support without rules, also set <c>NatGatewaySupport</c> to <c>disable</c> in the
        /// same request if NAT gateway support is currently enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResetNatGatewayRules")]
        public System.Boolean? ResetNatGatewayRule { get; set; }
        #endregion
        
        #region Parameter TransitGatewayAttachmentId
        /// <summary>
        /// <para>
        /// <para>The ID of the transit gateway attachment.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyTransitGatewayAttachmentNatConfigurationResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyTransitGatewayAttachmentNatConfigurationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2TransitGatewayAttachmentNatConfiguration (ModifyTransitGatewayAttachmentNatConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyTransitGatewayAttachmentNatConfigurationResponse, EditEC2TransitGatewayAttachmentNatConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DryRun = this.DryRun;
            if (this.NatGatewayRule != null)
            {
                context.NatGatewayRule = new List<Amazon.EC2.Model.TransitGatewayNatRuleRequest>(this.NatGatewayRule);
            }
            context.NatGatewaySupport = this.NatGatewaySupport;
            context.NatSystemRouteSupport = this.NatSystemRouteSupport;
            context.ResetNatGatewayRule = this.ResetNatGatewayRule;
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
            var request = new Amazon.EC2.Model.ModifyTransitGatewayAttachmentNatConfigurationRequest();
            
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
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
                request.NatSystemRouteSupport = cmdletContext.NatSystemRouteSupport;
            }
            if (cmdletContext.ResetNatGatewayRule != null)
            {
                request.ResetNatGatewayRules = cmdletContext.ResetNatGatewayRule.Value;
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
        
        private Amazon.EC2.Model.ModifyTransitGatewayAttachmentNatConfigurationResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyTransitGatewayAttachmentNatConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyTransitGatewayAttachmentNatConfiguration");
            try
            {
                return client.ModifyTransitGatewayAttachmentNatConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.EC2.Model.TransitGatewayNatRuleRequest> NatGatewayRule { get; set; }
            public Amazon.EC2.TransitGatewayAttachmentNatGatewaySupportValue NatGatewaySupport { get; set; }
            public Amazon.EC2.TransitGatewayAttachmentNatSystemRouteSupportValue NatSystemRouteSupport { get; set; }
            public System.Boolean? ResetNatGatewayRule { get; set; }
            public System.String TransitGatewayAttachmentId { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyTransitGatewayAttachmentNatConfigurationResponse, EditEC2TransitGatewayAttachmentNatConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
