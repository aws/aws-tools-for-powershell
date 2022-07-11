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
    /// Modifies the specified transit gateway. When you modify a transit gateway, the modified
    /// options are applied to new transit gateway attachments only. Your existing transit
    /// gateway attachments are not modified.
    /// </summary>
    [Cmdlet("Edit", "EC2TransitGateway", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.TransitGateway")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyTransitGateway API operation.", Operation = new[] {"ModifyTransitGateway"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyTransitGatewayResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.TransitGateway or Amazon.EC2.Model.ModifyTransitGatewayResponse",
        "This cmdlet returns an Amazon.EC2.Model.TransitGateway object.",
        "The service call response (type Amazon.EC2.Model.ModifyTransitGatewayResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditEC2TransitGatewayCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Options_AddTransitGatewayCidrBlock
        /// <summary>
        /// <para>
        /// <para>Adds IPv4 or IPv6 CIDR blocks for the transit gateway. Must be a size /24 CIDR block
        /// or larger for IPv4, or a size /64 CIDR block or larger for IPv6.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Options_AddTransitGatewayCidrBlocks")]
        public System.String[] Options_AddTransitGatewayCidrBlock { get; set; }
        #endregion
        
        #region Parameter Options_AmazonSideAsn
        /// <summary>
        /// <para>
        /// <para>A private Autonomous System Number (ASN) for the Amazon side of a BGP session. The
        /// range is 64512 to 65534 for 16-bit ASNs and 4200000000 to 4294967294 for 32-bit ASNs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? Options_AmazonSideAsn { get; set; }
        #endregion
        
        #region Parameter Options_AssociationDefaultRouteTableId
        /// <summary>
        /// <para>
        /// <para>The ID of the default association route table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Options_AssociationDefaultRouteTableId { get; set; }
        #endregion
        
        #region Parameter Options_AutoAcceptSharedAttachment
        /// <summary>
        /// <para>
        /// <para>Enable or disable automatic acceptance of attachment requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Options_AutoAcceptSharedAttachments")]
        [AWSConstantClassSource("Amazon.EC2.AutoAcceptSharedAttachmentsValue")]
        public Amazon.EC2.AutoAcceptSharedAttachmentsValue Options_AutoAcceptSharedAttachment { get; set; }
        #endregion
        
        #region Parameter Options_DefaultRouteTableAssociation
        /// <summary>
        /// <para>
        /// <para>Enable or disable automatic association with the default association route table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.DefaultRouteTableAssociationValue")]
        public Amazon.EC2.DefaultRouteTableAssociationValue Options_DefaultRouteTableAssociation { get; set; }
        #endregion
        
        #region Parameter Options_DefaultRouteTablePropagation
        /// <summary>
        /// <para>
        /// <para>Enable or disable automatic propagation of routes to the default propagation route
        /// table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.DefaultRouteTablePropagationValue")]
        public Amazon.EC2.DefaultRouteTablePropagationValue Options_DefaultRouteTablePropagation { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description for the transit gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Options_DnsSupport
        /// <summary>
        /// <para>
        /// <para>Enable or disable DNS support.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.DnsSupportValue")]
        public Amazon.EC2.DnsSupportValue Options_DnsSupport { get; set; }
        #endregion
        
        #region Parameter Options_PropagationDefaultRouteTableId
        /// <summary>
        /// <para>
        /// <para>The ID of the default propagation route table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Options_PropagationDefaultRouteTableId { get; set; }
        #endregion
        
        #region Parameter Options_RemoveTransitGatewayCidrBlock
        /// <summary>
        /// <para>
        /// <para>Removes CIDR blocks for the transit gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Options_RemoveTransitGatewayCidrBlocks")]
        public System.String[] Options_RemoveTransitGatewayCidrBlock { get; set; }
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
        
        #region Parameter Options_VpnEcmpSupport
        /// <summary>
        /// <para>
        /// <para>Enable or disable Equal Cost Multipath Protocol support.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.VpnEcmpSupportValue")]
        public Amazon.EC2.VpnEcmpSupportValue Options_VpnEcmpSupport { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TransitGateway'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyTransitGatewayResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyTransitGatewayResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TransitGateway";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TransitGatewayId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TransitGatewayId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TransitGatewayId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TransitGatewayId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2TransitGateway (ModifyTransitGateway)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyTransitGatewayResponse, EditEC2TransitGatewayCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TransitGatewayId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            if (this.Options_AddTransitGatewayCidrBlock != null)
            {
                context.Options_AddTransitGatewayCidrBlock = new List<System.String>(this.Options_AddTransitGatewayCidrBlock);
            }
            context.Options_AmazonSideAsn = this.Options_AmazonSideAsn;
            context.Options_AssociationDefaultRouteTableId = this.Options_AssociationDefaultRouteTableId;
            context.Options_AutoAcceptSharedAttachment = this.Options_AutoAcceptSharedAttachment;
            context.Options_DefaultRouteTableAssociation = this.Options_DefaultRouteTableAssociation;
            context.Options_DefaultRouteTablePropagation = this.Options_DefaultRouteTablePropagation;
            context.Options_DnsSupport = this.Options_DnsSupport;
            context.Options_PropagationDefaultRouteTableId = this.Options_PropagationDefaultRouteTableId;
            if (this.Options_RemoveTransitGatewayCidrBlock != null)
            {
                context.Options_RemoveTransitGatewayCidrBlock = new List<System.String>(this.Options_RemoveTransitGatewayCidrBlock);
            }
            context.Options_VpnEcmpSupport = this.Options_VpnEcmpSupport;
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
            var request = new Amazon.EC2.Model.ModifyTransitGatewayRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate Options
            var requestOptionsIsNull = true;
            request.Options = new Amazon.EC2.Model.ModifyTransitGatewayOptions();
            List<System.String> requestOptions_options_AddTransitGatewayCidrBlock = null;
            if (cmdletContext.Options_AddTransitGatewayCidrBlock != null)
            {
                requestOptions_options_AddTransitGatewayCidrBlock = cmdletContext.Options_AddTransitGatewayCidrBlock;
            }
            if (requestOptions_options_AddTransitGatewayCidrBlock != null)
            {
                request.Options.AddTransitGatewayCidrBlocks = requestOptions_options_AddTransitGatewayCidrBlock;
                requestOptionsIsNull = false;
            }
            System.Int64? requestOptions_options_AmazonSideAsn = null;
            if (cmdletContext.Options_AmazonSideAsn != null)
            {
                requestOptions_options_AmazonSideAsn = cmdletContext.Options_AmazonSideAsn.Value;
            }
            if (requestOptions_options_AmazonSideAsn != null)
            {
                request.Options.AmazonSideAsn = requestOptions_options_AmazonSideAsn.Value;
                requestOptionsIsNull = false;
            }
            System.String requestOptions_options_AssociationDefaultRouteTableId = null;
            if (cmdletContext.Options_AssociationDefaultRouteTableId != null)
            {
                requestOptions_options_AssociationDefaultRouteTableId = cmdletContext.Options_AssociationDefaultRouteTableId;
            }
            if (requestOptions_options_AssociationDefaultRouteTableId != null)
            {
                request.Options.AssociationDefaultRouteTableId = requestOptions_options_AssociationDefaultRouteTableId;
                requestOptionsIsNull = false;
            }
            Amazon.EC2.AutoAcceptSharedAttachmentsValue requestOptions_options_AutoAcceptSharedAttachment = null;
            if (cmdletContext.Options_AutoAcceptSharedAttachment != null)
            {
                requestOptions_options_AutoAcceptSharedAttachment = cmdletContext.Options_AutoAcceptSharedAttachment;
            }
            if (requestOptions_options_AutoAcceptSharedAttachment != null)
            {
                request.Options.AutoAcceptSharedAttachments = requestOptions_options_AutoAcceptSharedAttachment;
                requestOptionsIsNull = false;
            }
            Amazon.EC2.DefaultRouteTableAssociationValue requestOptions_options_DefaultRouteTableAssociation = null;
            if (cmdletContext.Options_DefaultRouteTableAssociation != null)
            {
                requestOptions_options_DefaultRouteTableAssociation = cmdletContext.Options_DefaultRouteTableAssociation;
            }
            if (requestOptions_options_DefaultRouteTableAssociation != null)
            {
                request.Options.DefaultRouteTableAssociation = requestOptions_options_DefaultRouteTableAssociation;
                requestOptionsIsNull = false;
            }
            Amazon.EC2.DefaultRouteTablePropagationValue requestOptions_options_DefaultRouteTablePropagation = null;
            if (cmdletContext.Options_DefaultRouteTablePropagation != null)
            {
                requestOptions_options_DefaultRouteTablePropagation = cmdletContext.Options_DefaultRouteTablePropagation;
            }
            if (requestOptions_options_DefaultRouteTablePropagation != null)
            {
                request.Options.DefaultRouteTablePropagation = requestOptions_options_DefaultRouteTablePropagation;
                requestOptionsIsNull = false;
            }
            Amazon.EC2.DnsSupportValue requestOptions_options_DnsSupport = null;
            if (cmdletContext.Options_DnsSupport != null)
            {
                requestOptions_options_DnsSupport = cmdletContext.Options_DnsSupport;
            }
            if (requestOptions_options_DnsSupport != null)
            {
                request.Options.DnsSupport = requestOptions_options_DnsSupport;
                requestOptionsIsNull = false;
            }
            System.String requestOptions_options_PropagationDefaultRouteTableId = null;
            if (cmdletContext.Options_PropagationDefaultRouteTableId != null)
            {
                requestOptions_options_PropagationDefaultRouteTableId = cmdletContext.Options_PropagationDefaultRouteTableId;
            }
            if (requestOptions_options_PropagationDefaultRouteTableId != null)
            {
                request.Options.PropagationDefaultRouteTableId = requestOptions_options_PropagationDefaultRouteTableId;
                requestOptionsIsNull = false;
            }
            List<System.String> requestOptions_options_RemoveTransitGatewayCidrBlock = null;
            if (cmdletContext.Options_RemoveTransitGatewayCidrBlock != null)
            {
                requestOptions_options_RemoveTransitGatewayCidrBlock = cmdletContext.Options_RemoveTransitGatewayCidrBlock;
            }
            if (requestOptions_options_RemoveTransitGatewayCidrBlock != null)
            {
                request.Options.RemoveTransitGatewayCidrBlocks = requestOptions_options_RemoveTransitGatewayCidrBlock;
                requestOptionsIsNull = false;
            }
            Amazon.EC2.VpnEcmpSupportValue requestOptions_options_VpnEcmpSupport = null;
            if (cmdletContext.Options_VpnEcmpSupport != null)
            {
                requestOptions_options_VpnEcmpSupport = cmdletContext.Options_VpnEcmpSupport;
            }
            if (requestOptions_options_VpnEcmpSupport != null)
            {
                request.Options.VpnEcmpSupport = requestOptions_options_VpnEcmpSupport;
                requestOptionsIsNull = false;
            }
             // determine if request.Options should be set to null
            if (requestOptionsIsNull)
            {
                request.Options = null;
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
        
        private Amazon.EC2.Model.ModifyTransitGatewayResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyTransitGatewayRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyTransitGateway");
            try
            {
                #if DESKTOP
                return client.ModifyTransitGateway(request);
                #elif CORECLR
                return client.ModifyTransitGatewayAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public List<System.String> Options_AddTransitGatewayCidrBlock { get; set; }
            public System.Int64? Options_AmazonSideAsn { get; set; }
            public System.String Options_AssociationDefaultRouteTableId { get; set; }
            public Amazon.EC2.AutoAcceptSharedAttachmentsValue Options_AutoAcceptSharedAttachment { get; set; }
            public Amazon.EC2.DefaultRouteTableAssociationValue Options_DefaultRouteTableAssociation { get; set; }
            public Amazon.EC2.DefaultRouteTablePropagationValue Options_DefaultRouteTablePropagation { get; set; }
            public Amazon.EC2.DnsSupportValue Options_DnsSupport { get; set; }
            public System.String Options_PropagationDefaultRouteTableId { get; set; }
            public List<System.String> Options_RemoveTransitGatewayCidrBlock { get; set; }
            public Amazon.EC2.VpnEcmpSupportValue Options_VpnEcmpSupport { get; set; }
            public System.String TransitGatewayId { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyTransitGatewayResponse, EditEC2TransitGatewayCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TransitGateway;
        }
        
    }
}
