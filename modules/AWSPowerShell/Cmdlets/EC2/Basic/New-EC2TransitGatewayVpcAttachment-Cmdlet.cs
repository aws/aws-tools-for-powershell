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
    /// Attaches the specified VPC to the specified transit gateway.
    /// 
    ///  
    /// <para>
    /// If you attach a VPC with a CIDR range that overlaps the CIDR range of a VPC that is
    /// already attached, the new VPC CIDR range is not propagated to the default propagation
    /// route table.
    /// </para><para>
    /// To send VPC traffic to an attached transit gateway, add a route to the VPC route table
    /// using <a>CreateRoute</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2TransitGatewayVpcAttachment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.TransitGatewayVpcAttachment")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateTransitGatewayVpcAttachment API operation.", Operation = new[] {"CreateTransitGatewayVpcAttachment"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateTransitGatewayVpcAttachmentResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.TransitGatewayVpcAttachment or Amazon.EC2.Model.CreateTransitGatewayVpcAttachmentResponse",
        "This cmdlet returns an Amazon.EC2.Model.TransitGatewayVpcAttachment object.",
        "The service call response (type Amazon.EC2.Model.CreateTransitGatewayVpcAttachmentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2TransitGatewayVpcAttachmentCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Options_ApplianceModeSupport
        /// <summary>
        /// <para>
        /// <para>Enable or disable support for appliance mode. If enabled, a traffic flow between a
        /// source and destination uses the same Availability Zone for the VPC attachment for
        /// the lifetime of that flow. The default is <c>disable</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.ApplianceModeSupportValue")]
        public Amazon.EC2.ApplianceModeSupportValue Options_ApplianceModeSupport { get; set; }
        #endregion
        
        #region Parameter Options_DnsSupport
        /// <summary>
        /// <para>
        /// <para>Enable or disable DNS support. The default is <c>enable</c>.</para>
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
        
        #region Parameter Options_Ipv6Support
        /// <summary>
        /// <para>
        /// <para>Enable or disable IPv6 support. The default is <c>disable</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.Ipv6SupportValue")]
        public Amazon.EC2.Ipv6SupportValue Options_Ipv6Support { get; set; }
        #endregion
        
        #region Parameter Options_SecurityGroupReferencingSupport
        /// <summary>
        /// <para>
        /// <para>Enables you to reference a security group across VPCs attached to a transit gateway
        /// to simplify security group management.</para><para>This option is set to <c>enable</c> by default. However, at the transit gateway level
        /// the default is set to <c>disable</c>.</para><para>For more information about security group referencing, see <a href="https://docs.aws.amazon.com/vpc/latest/tgw/tgw-vpc-attachments.html#vpc-attachment-security">Security
        /// group referencing </a> in the <i>Amazon Web Services Transit Gateways Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.SecurityGroupReferencingSupportValue")]
        public Amazon.EC2.SecurityGroupReferencingSupportValue Options_SecurityGroupReferencingSupport { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>The IDs of one or more subnets. You can specify only one subnet per Availability Zone.
        /// You must specify at least one subnet, but we recommend that you specify two subnets
        /// for better availability. The transit gateway uses one IP address from each specified
        /// subnet.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("SubnetIds")]
        public System.String[] SubnetId { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the VPC attachment.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        
        #region Parameter VpcId
        /// <summary>
        /// <para>
        /// <para>The ID of the VPC.</para>
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
        public System.String VpcId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TransitGatewayVpcAttachment'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateTransitGatewayVpcAttachmentResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateTransitGatewayVpcAttachmentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TransitGatewayVpcAttachment";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TransitGatewayId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2TransitGatewayVpcAttachment (CreateTransitGatewayVpcAttachment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateTransitGatewayVpcAttachmentResponse, NewEC2TransitGatewayVpcAttachmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DryRun = this.DryRun;
            context.Options_ApplianceModeSupport = this.Options_ApplianceModeSupport;
            context.Options_DnsSupport = this.Options_DnsSupport;
            context.Options_Ipv6Support = this.Options_Ipv6Support;
            context.Options_SecurityGroupReferencingSupport = this.Options_SecurityGroupReferencingSupport;
            if (this.SubnetId != null)
            {
                context.SubnetId = new List<System.String>(this.SubnetId);
            }
            #if MODULAR
            if (this.SubnetId == null && ParameterWasBound(nameof(this.SubnetId)))
            {
                WriteWarning("You are passing $null as a value for parameter SubnetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            context.VpcId = this.VpcId;
            #if MODULAR
            if (this.VpcId == null && ParameterWasBound(nameof(this.VpcId)))
            {
                WriteWarning("You are passing $null as a value for parameter VpcId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.CreateTransitGatewayVpcAttachmentRequest();
            
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            
             // populate Options
            var requestOptionsIsNull = true;
            request.Options = new Amazon.EC2.Model.CreateTransitGatewayVpcAttachmentRequestOptions();
            Amazon.EC2.ApplianceModeSupportValue requestOptions_options_ApplianceModeSupport = null;
            if (cmdletContext.Options_ApplianceModeSupport != null)
            {
                requestOptions_options_ApplianceModeSupport = cmdletContext.Options_ApplianceModeSupport;
            }
            if (requestOptions_options_ApplianceModeSupport != null)
            {
                request.Options.ApplianceModeSupport = requestOptions_options_ApplianceModeSupport;
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
            Amazon.EC2.Ipv6SupportValue requestOptions_options_Ipv6Support = null;
            if (cmdletContext.Options_Ipv6Support != null)
            {
                requestOptions_options_Ipv6Support = cmdletContext.Options_Ipv6Support;
            }
            if (requestOptions_options_Ipv6Support != null)
            {
                request.Options.Ipv6Support = requestOptions_options_Ipv6Support;
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
             // determine if request.Options should be set to null
            if (requestOptionsIsNull)
            {
                request.Options = null;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetIds = cmdletContext.SubnetId;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
            }
            if (cmdletContext.TransitGatewayId != null)
            {
                request.TransitGatewayId = cmdletContext.TransitGatewayId;
            }
            if (cmdletContext.VpcId != null)
            {
                request.VpcId = cmdletContext.VpcId;
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
        
        private Amazon.EC2.Model.CreateTransitGatewayVpcAttachmentResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateTransitGatewayVpcAttachmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateTransitGatewayVpcAttachment");
            try
            {
                return client.CreateTransitGatewayVpcAttachmentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.EC2.ApplianceModeSupportValue Options_ApplianceModeSupport { get; set; }
            public Amazon.EC2.DnsSupportValue Options_DnsSupport { get; set; }
            public Amazon.EC2.Ipv6SupportValue Options_Ipv6Support { get; set; }
            public Amazon.EC2.SecurityGroupReferencingSupportValue Options_SecurityGroupReferencingSupport { get; set; }
            public List<System.String> SubnetId { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.String TransitGatewayId { get; set; }
            public System.String VpcId { get; set; }
            public System.Func<Amazon.EC2.Model.CreateTransitGatewayVpcAttachmentResponse, NewEC2TransitGatewayVpcAttachmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TransitGatewayVpcAttachment;
        }
        
    }
}
