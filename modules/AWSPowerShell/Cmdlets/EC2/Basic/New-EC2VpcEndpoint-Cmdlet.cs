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
    /// Creates a VPC endpoint. A VPC endpoint provides a private connection between the specified
    /// VPC and the specified endpoint service. You can use an endpoint service provided by
    /// Amazon Web Services, an Amazon Web Services Marketplace Partner, or another Amazon
    /// Web Services account. For more information, see the <a href="https://docs.aws.amazon.com/vpc/latest/privatelink/">Amazon
    /// Web Services PrivateLink User Guide</a>.
    /// </summary>
    [Cmdlet("New", "EC2VpcEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.CreateVpcEndpointResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateVpcEndpoint API operation.", Operation = new[] {"CreateVpcEndpoint"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateVpcEndpointResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.CreateVpcEndpointResponse",
        "This cmdlet returns an Amazon.EC2.Model.CreateVpcEndpointResponse object containing multiple properties."
    )]
    public partial class NewEC2VpcEndpointCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DnsOptions_DnsRecordIpType
        /// <summary>
        /// <para>
        /// <para>The DNS records created for the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.DnsRecordIpType")]
        public Amazon.EC2.DnsRecordIpType DnsOptions_DnsRecordIpType { get; set; }
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
        
        #region Parameter IpAddressType
        /// <summary>
        /// <para>
        /// <para>The IP address type for the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.IpAddressType")]
        public Amazon.EC2.IpAddressType IpAddressType { get; set; }
        #endregion
        
        #region Parameter PolicyDocument
        /// <summary>
        /// <para>
        /// <para>(Interface and gateway endpoints) A policy to attach to the endpoint that controls
        /// access to the service. The policy must be in valid JSON format. If this parameter
        /// is not specified, we attach a default policy that allows full access to the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PolicyDocument { get; set; }
        #endregion
        
        #region Parameter PrivateDnsEnabled
        /// <summary>
        /// <para>
        /// <para>(Interface endpoint) Indicates whether to associate a private hosted zone with the
        /// specified VPC. The private hosted zone contains a record set for the default public
        /// DNS name for the service for the Region (for example, <c>kinesis.us-east-1.amazonaws.com</c>),
        /// which resolves to the private IP addresses of the endpoint network interfaces in the
        /// VPC. This enables you to make requests to the default public DNS name for the service
        /// instead of the public DNS names that are automatically generated by the VPC endpoint
        /// service.</para><para>To use a private hosted zone, you must set the following VPC attributes to <c>true</c>:
        /// <c>enableDnsHostnames</c> and <c>enableDnsSupport</c>. Use <a>ModifyVpcAttribute</a>
        /// to set the VPC attributes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PrivateDnsEnabled { get; set; }
        #endregion
        
        #region Parameter DnsOptions_PrivateDnsOnlyForInboundResolverEndpoint
        /// <summary>
        /// <para>
        /// <para>Indicates whether to enable private DNS only for inbound endpoints. This option is
        /// available only for services that support both gateway and interface endpoints. It
        /// routes traffic that originates from the VPC to the gateway endpoint and traffic that
        /// originates from on-premises to the interface endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DnsOptions_PrivateDnsOnlyForInboundResolverEndpoint { get; set; }
        #endregion
        
        #region Parameter ResourceConfigurationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a resource configuration that will be associated
        /// with the VPC endpoint of type resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceConfigurationArn { get; set; }
        #endregion
        
        #region Parameter RouteTableId
        /// <summary>
        /// <para>
        /// <para>(Gateway endpoint) The route table IDs.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RouteTableIds")]
        public System.String[] RouteTableId { get; set; }
        #endregion
        
        #region Parameter SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>(Interface endpoint) The IDs of the security groups to associate with the endpoint
        /// network interfaces. If this parameter is not specified, we use the default security
        /// group for the VPC.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupIds")]
        public System.String[] SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter ServiceName
        /// <summary>
        /// <para>
        /// <para>The name of the endpoint service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceName { get; set; }
        #endregion
        
        #region Parameter ServiceNetworkArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a service network that will be associated with the
        /// VPC endpoint of type service-network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceNetworkArn { get; set; }
        #endregion
        
        #region Parameter ServiceRegion
        /// <summary>
        /// <para>
        /// <para>The Region where the service is hosted. The default is the current Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceRegion { get; set; }
        #endregion
        
        #region Parameter SubnetConfiguration
        /// <summary>
        /// <para>
        /// <para>The subnet configurations for the endpoint.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SubnetConfigurations")]
        public Amazon.EC2.Model.SubnetConfiguration[] SubnetConfiguration { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>(Interface and Gateway Load Balancer endpoints) The IDs of the subnets in which to
        /// create endpoint network interfaces. For a Gateway Load Balancer endpoint, you can
        /// specify only one subnet.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SubnetIds")]
        public System.String[] SubnetId { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to associate with the endpoint.</para><para />
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
        
        #region Parameter VpcEndpointType
        /// <summary>
        /// <para>
        /// <para>The type of endpoint.</para><para>Default: Gateway</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.VpcEndpointType")]
        public Amazon.EC2.VpcEndpointType VpcEndpointType { get; set; }
        #endregion
        
        #region Parameter VpcId
        /// <summary>
        /// <para>
        /// <para>The ID of the VPC.</para>
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
        public System.String VpcId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. For more information, see <a href="https://docs.aws.amazon.com/ec2/latest/devguide/ec2-api-idempotency.html">How
        /// to ensure idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateVpcEndpointResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateVpcEndpointResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VpcId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2VpcEndpoint (CreateVpcEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateVpcEndpointResponse, NewEC2VpcEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DnsOptions_DnsRecordIpType = this.DnsOptions_DnsRecordIpType;
            context.DnsOptions_PrivateDnsOnlyForInboundResolverEndpoint = this.DnsOptions_PrivateDnsOnlyForInboundResolverEndpoint;
            context.DryRun = this.DryRun;
            context.IpAddressType = this.IpAddressType;
            context.PolicyDocument = this.PolicyDocument;
            context.PrivateDnsEnabled = this.PrivateDnsEnabled;
            context.ResourceConfigurationArn = this.ResourceConfigurationArn;
            if (this.RouteTableId != null)
            {
                context.RouteTableId = new List<System.String>(this.RouteTableId);
            }
            if (this.SecurityGroupId != null)
            {
                context.SecurityGroupId = new List<System.String>(this.SecurityGroupId);
            }
            context.ServiceName = this.ServiceName;
            context.ServiceNetworkArn = this.ServiceNetworkArn;
            context.ServiceRegion = this.ServiceRegion;
            if (this.SubnetConfiguration != null)
            {
                context.SubnetConfiguration = new List<Amazon.EC2.Model.SubnetConfiguration>(this.SubnetConfiguration);
            }
            if (this.SubnetId != null)
            {
                context.SubnetId = new List<System.String>(this.SubnetId);
            }
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
            context.VpcEndpointType = this.VpcEndpointType;
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
            var request = new Amazon.EC2.Model.CreateVpcEndpointRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate DnsOptions
            var requestDnsOptionsIsNull = true;
            request.DnsOptions = new Amazon.EC2.Model.DnsOptionsSpecification();
            Amazon.EC2.DnsRecordIpType requestDnsOptions_dnsOptions_DnsRecordIpType = null;
            if (cmdletContext.DnsOptions_DnsRecordIpType != null)
            {
                requestDnsOptions_dnsOptions_DnsRecordIpType = cmdletContext.DnsOptions_DnsRecordIpType;
            }
            if (requestDnsOptions_dnsOptions_DnsRecordIpType != null)
            {
                request.DnsOptions.DnsRecordIpType = requestDnsOptions_dnsOptions_DnsRecordIpType;
                requestDnsOptionsIsNull = false;
            }
            System.Boolean? requestDnsOptions_dnsOptions_PrivateDnsOnlyForInboundResolverEndpoint = null;
            if (cmdletContext.DnsOptions_PrivateDnsOnlyForInboundResolverEndpoint != null)
            {
                requestDnsOptions_dnsOptions_PrivateDnsOnlyForInboundResolverEndpoint = cmdletContext.DnsOptions_PrivateDnsOnlyForInboundResolverEndpoint.Value;
            }
            if (requestDnsOptions_dnsOptions_PrivateDnsOnlyForInboundResolverEndpoint != null)
            {
                request.DnsOptions.PrivateDnsOnlyForInboundResolverEndpoint = requestDnsOptions_dnsOptions_PrivateDnsOnlyForInboundResolverEndpoint.Value;
                requestDnsOptionsIsNull = false;
            }
             // determine if request.DnsOptions should be set to null
            if (requestDnsOptionsIsNull)
            {
                request.DnsOptions = null;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.IpAddressType != null)
            {
                request.IpAddressType = cmdletContext.IpAddressType;
            }
            if (cmdletContext.PolicyDocument != null)
            {
                request.PolicyDocument = cmdletContext.PolicyDocument;
            }
            if (cmdletContext.PrivateDnsEnabled != null)
            {
                request.PrivateDnsEnabled = cmdletContext.PrivateDnsEnabled.Value;
            }
            if (cmdletContext.ResourceConfigurationArn != null)
            {
                request.ResourceConfigurationArn = cmdletContext.ResourceConfigurationArn;
            }
            if (cmdletContext.RouteTableId != null)
            {
                request.RouteTableIds = cmdletContext.RouteTableId;
            }
            if (cmdletContext.SecurityGroupId != null)
            {
                request.SecurityGroupIds = cmdletContext.SecurityGroupId;
            }
            if (cmdletContext.ServiceName != null)
            {
                request.ServiceName = cmdletContext.ServiceName;
            }
            if (cmdletContext.ServiceNetworkArn != null)
            {
                request.ServiceNetworkArn = cmdletContext.ServiceNetworkArn;
            }
            if (cmdletContext.ServiceRegion != null)
            {
                request.ServiceRegion = cmdletContext.ServiceRegion;
            }
            if (cmdletContext.SubnetConfiguration != null)
            {
                request.SubnetConfigurations = cmdletContext.SubnetConfiguration;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetIds = cmdletContext.SubnetId;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
            }
            if (cmdletContext.VpcEndpointType != null)
            {
                request.VpcEndpointType = cmdletContext.VpcEndpointType;
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
        
        private Amazon.EC2.Model.CreateVpcEndpointResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateVpcEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateVpcEndpoint");
            try
            {
                return client.CreateVpcEndpointAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public Amazon.EC2.DnsRecordIpType DnsOptions_DnsRecordIpType { get; set; }
            public System.Boolean? DnsOptions_PrivateDnsOnlyForInboundResolverEndpoint { get; set; }
            public System.Boolean? DryRun { get; set; }
            public Amazon.EC2.IpAddressType IpAddressType { get; set; }
            public System.String PolicyDocument { get; set; }
            public System.Boolean? PrivateDnsEnabled { get; set; }
            public System.String ResourceConfigurationArn { get; set; }
            public List<System.String> RouteTableId { get; set; }
            public List<System.String> SecurityGroupId { get; set; }
            public System.String ServiceName { get; set; }
            public System.String ServiceNetworkArn { get; set; }
            public System.String ServiceRegion { get; set; }
            public List<Amazon.EC2.Model.SubnetConfiguration> SubnetConfiguration { get; set; }
            public List<System.String> SubnetId { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public Amazon.EC2.VpcEndpointType VpcEndpointType { get; set; }
            public System.String VpcId { get; set; }
            public System.Func<Amazon.EC2.Model.CreateVpcEndpointResponse, NewEC2VpcEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
