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
    /// Creates a transit gateway.
    /// 
    ///  
    /// <para>
    /// You can use a transit gateway to interconnect your virtual private clouds (VPC) and
    /// on-premises networks. After the transit gateway enters the <c>available</c> state,
    /// you can attach your VPCs and VPN connections to the transit gateway.
    /// </para><para>
    /// To attach your VPCs, use <a>CreateTransitGatewayVpcAttachment</a>.
    /// </para><para>
    /// To attach a VPN connection, use <a>CreateCustomerGateway</a> to create a customer
    /// gateway and specify the ID of the customer gateway and the ID of the transit gateway
    /// in a call to <a>CreateVpnConnection</a>.
    /// </para><para>
    /// When you create a transit gateway, we create a default transit gateway route table
    /// and use it as the default association route table and the default propagation route
    /// table. You can use <a>CreateTransitGatewayRouteTable</a> to create additional transit
    /// gateway route tables. If you disable automatic route propagation, we do not create
    /// a default transit gateway route table. You can use <a>EnableTransitGatewayRouteTablePropagation</a>
    /// to propagate routes from a resource attachment to a transit gateway route table. If
    /// you disable automatic associations, you can use <a>AssociateTransitGatewayRouteTable</a>
    /// to associate a resource attachment with a transit gateway route table.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2TransitGateway", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.TransitGateway")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateTransitGateway API operation.", Operation = new[] {"CreateTransitGateway"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateTransitGatewayResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.TransitGateway or Amazon.EC2.Model.CreateTransitGatewayResponse",
        "This cmdlet returns an Amazon.EC2.Model.TransitGateway object.",
        "The service call response (type Amazon.EC2.Model.CreateTransitGatewayResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2TransitGatewayCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Options_AmazonSideAsn
        /// <summary>
        /// <para>
        /// <para>A private Autonomous System Number (ASN) for the Amazon side of a BGP session. The
        /// range is 64512 to 65534 for 16-bit ASNs and 4200000000 to 4294967294 for 32-bit ASNs.
        /// The default is <c>64512</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? Options_AmazonSideAsn { get; set; }
        #endregion
        
        #region Parameter Options_AutoAcceptSharedAttachment
        /// <summary>
        /// <para>
        /// <para>Enable or disable automatic acceptance of attachment requests. Disabled by default.</para>
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
        /// <para>Enable or disable automatic association with the default association route table.
        /// Enabled by default.</para>
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
        /// table. Enabled by default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.DefaultRouteTablePropagationValue")]
        public Amazon.EC2.DefaultRouteTablePropagationValue Options_DefaultRouteTablePropagation { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the transit gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Options_DnsSupport
        /// <summary>
        /// <para>
        /// <para>Enable or disable DNS support. Enabled by default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.DnsSupportValue")]
        public Amazon.EC2.DnsSupportValue Options_DnsSupport { get; set; }
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
        
        #region Parameter Options_MulticastSupport
        /// <summary>
        /// <para>
        /// <para>Indicates whether multicast is enabled on the transit gateway</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.MulticastSupportValue")]
        public Amazon.EC2.MulticastSupportValue Options_MulticastSupport { get; set; }
        #endregion
        
        #region Parameter Options_SecurityGroupReferencingSupport
        /// <summary>
        /// <para>
        /// <para>Enables you to reference a security group across VPCs attached to a transit gateway
        /// to simplify security group management. </para><para>This option is disabled by default.</para><para>For more information about security group referencing, see <a href="https://docs.aws.amazon.com/vpc/latest/tgw/tgw-vpc-attachments.html#vpc-attachment-security">Security
        /// group referencing</a> in the <i>Amazon Web Services Transit Gateways Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.SecurityGroupReferencingSupportValue")]
        public Amazon.EC2.SecurityGroupReferencingSupportValue Options_SecurityGroupReferencingSupport { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the transit gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter Options_TransitGatewayCidrBlock
        /// <summary>
        /// <para>
        /// <para>One or more IPv4 or IPv6 CIDR blocks for the transit gateway. Must be a size /24 CIDR
        /// block or larger for IPv4, or a size /64 CIDR block or larger for IPv6.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Options_TransitGatewayCidrBlocks")]
        public System.String[] Options_TransitGatewayCidrBlock { get; set; }
        #endregion
        
        #region Parameter Options_VpnEcmpSupport
        /// <summary>
        /// <para>
        /// <para>Enable or disable Equal Cost Multipath Protocol support. Enabled by default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.VpnEcmpSupportValue")]
        public Amazon.EC2.VpnEcmpSupportValue Options_VpnEcmpSupport { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TransitGateway'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateTransitGatewayResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateTransitGatewayResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TransitGateway";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2TransitGateway (CreateTransitGateway)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateTransitGatewayResponse, NewEC2TransitGatewayCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.DryRun = this.DryRun;
            context.Options_AmazonSideAsn = this.Options_AmazonSideAsn;
            context.Options_AutoAcceptSharedAttachment = this.Options_AutoAcceptSharedAttachment;
            context.Options_DefaultRouteTableAssociation = this.Options_DefaultRouteTableAssociation;
            context.Options_DefaultRouteTablePropagation = this.Options_DefaultRouteTablePropagation;
            context.Options_DnsSupport = this.Options_DnsSupport;
            context.Options_MulticastSupport = this.Options_MulticastSupport;
            context.Options_SecurityGroupReferencingSupport = this.Options_SecurityGroupReferencingSupport;
            if (this.Options_TransitGatewayCidrBlock != null)
            {
                context.Options_TransitGatewayCidrBlock = new List<System.String>(this.Options_TransitGatewayCidrBlock);
            }
            context.Options_VpnEcmpSupport = this.Options_VpnEcmpSupport;
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
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
            var request = new Amazon.EC2.Model.CreateTransitGatewayRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            
             // populate Options
            var requestOptionsIsNull = true;
            request.Options = new Amazon.EC2.Model.TransitGatewayRequestOptions();
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
            Amazon.EC2.MulticastSupportValue requestOptions_options_MulticastSupport = null;
            if (cmdletContext.Options_MulticastSupport != null)
            {
                requestOptions_options_MulticastSupport = cmdletContext.Options_MulticastSupport;
            }
            if (requestOptions_options_MulticastSupport != null)
            {
                request.Options.MulticastSupport = requestOptions_options_MulticastSupport;
                requestOptionsIsNull = false;
            }
            Amazon.EC2.SecurityGroupReferencingSupportValue requestOptions_options_SecurityGroupReferencingSupport = null;
            if (cmdletContext.Options_SecurityGroupReferencingSupport != null)
            {
                requestOptions_options_SecurityGroupReferencingSupport = cmdletContext.Options_SecurityGroupReferencingSupport;
            }
            if (requestOptions_options_SecurityGroupReferencingSupport != null)
            {
                request.Options.SecurityGroupReferencingSupport = requestOptions_options_SecurityGroupReferencingSupport;
                requestOptionsIsNull = false;
            }
            List<System.String> requestOptions_options_TransitGatewayCidrBlock = null;
            if (cmdletContext.Options_TransitGatewayCidrBlock != null)
            {
                requestOptions_options_TransitGatewayCidrBlock = cmdletContext.Options_TransitGatewayCidrBlock;
            }
            if (requestOptions_options_TransitGatewayCidrBlock != null)
            {
                request.Options.TransitGatewayCidrBlocks = requestOptions_options_TransitGatewayCidrBlock;
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
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
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
        
        private Amazon.EC2.Model.CreateTransitGatewayResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateTransitGatewayRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateTransitGateway");
            try
            {
                return client.CreateTransitGatewayAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? DryRun { get; set; }
            public System.Int64? Options_AmazonSideAsn { get; set; }
            public Amazon.EC2.AutoAcceptSharedAttachmentsValue Options_AutoAcceptSharedAttachment { get; set; }
            public Amazon.EC2.DefaultRouteTableAssociationValue Options_DefaultRouteTableAssociation { get; set; }
            public Amazon.EC2.DefaultRouteTablePropagationValue Options_DefaultRouteTablePropagation { get; set; }
            public Amazon.EC2.DnsSupportValue Options_DnsSupport { get; set; }
            public Amazon.EC2.MulticastSupportValue Options_MulticastSupport { get; set; }
            public Amazon.EC2.SecurityGroupReferencingSupportValue Options_SecurityGroupReferencingSupport { get; set; }
            public List<System.String> Options_TransitGatewayCidrBlock { get; set; }
            public Amazon.EC2.VpnEcmpSupportValue Options_VpnEcmpSupport { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.Func<Amazon.EC2.Model.CreateTransitGatewayResponse, NewEC2TransitGatewayCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TransitGateway;
        }
        
    }
}
