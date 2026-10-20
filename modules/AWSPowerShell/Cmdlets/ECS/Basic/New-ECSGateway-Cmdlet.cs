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
using Amazon.ECS;
using Amazon.ECS.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ECS
{
    /// <summary>
    /// Creates a gateway. A gateway defines and dynamically manages ingress paths for your
    /// Amazon ECS services, handling traffic routing and infrastructure across multiple services
    /// while optimizing infrastructure usage. <c>CreateGateway</c> is a synchronous operation
    /// and the gateway is returned with a status of <c>ACTIVE</c>. The load balancers and
    /// other infrastructure that a gateway manages aren't created until a service in an associated
    /// cluster begins using the gateway.
    /// 
    ///  
    /// <para>
    /// To use this operation, you must have the <c>iam:PassRole</c> permission for the infrastructure
    /// role that you specify in <c>infrastructureRoleArn</c>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "ECSGateway", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECS.Model.CreateGatewayResponse")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service CreateGateway API operation.", Operation = new[] {"CreateGateway"}, SelectReturnType = typeof(Amazon.ECS.Model.CreateGatewayResponse))]
    [AWSCmdletOutput("Amazon.ECS.Model.CreateGatewayResponse",
        "This cmdlet returns an Amazon.ECS.Model.CreateGatewayResponse object containing multiple properties."
    )]
    public partial class NewECSGatewayCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Configuration_HostSharedAlb_AccessLogs_Destination_S3_Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 bucket where access logs are delivered.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_HostSharedAlb_AccessLogs_Destination_S3_Bucket { get; set; }
        #endregion
        
        #region Parameter DeletionProtection
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable deletion protection for the gateway. When enabled, the
        /// gateway can't be deleted, and the gateway propagates this setting to the load balancers
        /// it manages. The default is <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeletionProtection { get; set; }
        #endregion
        
        #region Parameter Configuration_HostSharedAlb_HttpDesync
        /// <summary>
        /// <para>
        /// <para>The desync mitigation mode for the load balancers that the gateway manages, which
        /// determines how the load balancers handle requests that might pose a security risk.
        /// The default is <c>defensive</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECS.GatewayAlbDesyncMitigationMode")]
        public Amazon.ECS.GatewayAlbDesyncMitigationMode Configuration_HostSharedAlb_HttpDesync { get; set; }
        #endregion
        
        #region Parameter Configuration_HostSharedAlb_NetworkConfiguration_InboundSecurityGroup
        /// <summary>
        /// <para>
        /// <para>The ID of a security group that you provide to control inbound traffic to the load
        /// balancers that the gateway manages. When you specify a security group, the gateway
        /// doesn't create inbound rules on the security group it manages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_HostSharedAlb_NetworkConfiguration_InboundSecurityGroup { get; set; }
        #endregion
        
        #region Parameter InfrastructureRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that the gateway assumes to create
        /// and manage infrastructure on your behalf.</para>
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
        public System.String InfrastructureRoleArn { get; set; }
        #endregion
        
        #region Parameter Configuration_HostSharedAlb_NetworkConfiguration_IpAddressType
        /// <summary>
        /// <para>
        /// <para>The IP address type for the load balancers that the gateway manages. The default is
        /// <c>dualstack</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECS.GatewayElbIpAddressType")]
        public Amazon.ECS.GatewayElbIpAddressType Configuration_HostSharedAlb_NetworkConfiguration_IpAddressType { get; set; }
        #endregion
        
        #region Parameter Configuration_HostSharedAlb_MaxAlbCount
        /// <summary>
        /// <para>
        /// <para>The maximum number of Application Load Balancers that the gateway manages. The default
        /// is 10.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Configuration_HostSharedAlb_MaxAlbCount { get; set; }
        #endregion
        
        #region Parameter Configuration_HostSharedAlb_TestTrafficRules_Header_Name
        /// <summary>
        /// <para>
        /// <para>The name of the header to match for test traffic routing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_HostSharedAlb_TestTrafficRules_Header_Name { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name for the gateway. The name must be unique within your account and can be up
        /// to 255 characters.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Configuration_HostSharedAlb_Port
        /// <summary>
        /// <para>
        /// <para>The port that the load balancer listener uses is 443. The gateway supports only HTTPS
        /// at port 443.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Configuration_HostSharedAlb_Port { get; set; }
        #endregion
        
        #region Parameter Configuration_HostSharedAlb_AccessLogs_Destination_S3_Prefix
        /// <summary>
        /// <para>
        /// <para>The object key prefix for the access logs in the Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_HostSharedAlb_AccessLogs_Destination_S3_Prefix { get; set; }
        #endregion
        
        #region Parameter PropagateTag
        /// <summary>
        /// <para>
        /// <para>Specifies whether to propagate the tags from the gateway to the infrastructure that
        /// the gateway manages. The default is <c>GATEWAY</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PropagateTags")]
        [AWSConstantClassSource("Amazon.ECS.PropagateGatewayTags")]
        public Amazon.ECS.PropagateGatewayTags PropagateTag { get; set; }
        #endregion
        
        #region Parameter Configuration_HostSharedAlb_Protocol
        /// <summary>
        /// <para>
        /// <para>The protocol for the load balancer listener is <c>HTTPS</c>. No other protocol is
        /// supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECS.GatewayAlbProtocol")]
        public Amazon.ECS.GatewayAlbProtocol Configuration_HostSharedAlb_Protocol { get; set; }
        #endregion
        
        #region Parameter Configuration_HostSharedAlb_Scheme
        /// <summary>
        /// <para>
        /// <para>Specifies whether the load balancers the gateway manages are <c>internet-facing</c>
        /// or <c>internal</c>. The default is <c>internet-facing</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECS.GatewayElbScheme")]
        public Amazon.ECS.GatewayElbScheme Configuration_HostSharedAlb_Scheme { get; set; }
        #endregion
        
        #region Parameter Configuration_HostSharedAlb_NetworkConfiguration_Subnet
        /// <summary>
        /// <para>
        /// <para>The subnets for the load balancers that the gateway manages. The default is the subnets
        /// in the default VPC.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_HostSharedAlb_NetworkConfiguration_Subnets")]
        public System.String[] Configuration_HostSharedAlb_NetworkConfiguration_Subnet { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The metadata that you apply to the gateway to help you categorize and organize it.
        /// Each tag consists of a key and an optional value. Depending on <c>propagateTags</c>,
        /// these tags can be applied to the infrastructure the gateway manages.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ECS.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Configuration_HostSharedAlb_TestTrafficRules_Header_Value
        /// <summary>
        /// <para>
        /// <para>The header values to match for test traffic routing.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_HostSharedAlb_TestTrafficRules_Header_Values")]
        public System.String[] Configuration_HostSharedAlb_TestTrafficRules_Header_Value { get; set; }
        #endregion
        
        #region Parameter Configuration_HostSharedAlb_WebACLArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the WAF web ACL to associate with the load balancers
        /// that the gateway manages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_HostSharedAlb_WebACLArn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure that the operation
        /// completes no more than one time. If this token matches a previous request, the service
        /// ignores the request, but does not return an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECS.Model.CreateGatewayResponse).
        /// Specifying the name of a property of type Amazon.ECS.Model.CreateGatewayResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.Name),
                nameof(this.InfrastructureRoleArn)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ECSGateway (CreateGateway)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECS.Model.CreateGatewayResponse, NewECSGatewayCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Configuration_HostSharedAlb_AccessLogs_Destination_S3_Bucket = this.Configuration_HostSharedAlb_AccessLogs_Destination_S3_Bucket;
            context.Configuration_HostSharedAlb_AccessLogs_Destination_S3_Prefix = this.Configuration_HostSharedAlb_AccessLogs_Destination_S3_Prefix;
            context.Configuration_HostSharedAlb_HttpDesync = this.Configuration_HostSharedAlb_HttpDesync;
            context.Configuration_HostSharedAlb_MaxAlbCount = this.Configuration_HostSharedAlb_MaxAlbCount;
            context.Configuration_HostSharedAlb_NetworkConfiguration_InboundSecurityGroup = this.Configuration_HostSharedAlb_NetworkConfiguration_InboundSecurityGroup;
            context.Configuration_HostSharedAlb_NetworkConfiguration_IpAddressType = this.Configuration_HostSharedAlb_NetworkConfiguration_IpAddressType;
            if (this.Configuration_HostSharedAlb_NetworkConfiguration_Subnet != null)
            {
                context.Configuration_HostSharedAlb_NetworkConfiguration_Subnet = new List<System.String>(this.Configuration_HostSharedAlb_NetworkConfiguration_Subnet);
            }
            context.Configuration_HostSharedAlb_Port = this.Configuration_HostSharedAlb_Port;
            context.Configuration_HostSharedAlb_Protocol = this.Configuration_HostSharedAlb_Protocol;
            context.Configuration_HostSharedAlb_Scheme = this.Configuration_HostSharedAlb_Scheme;
            context.Configuration_HostSharedAlb_TestTrafficRules_Header_Name = this.Configuration_HostSharedAlb_TestTrafficRules_Header_Name;
            if (this.Configuration_HostSharedAlb_TestTrafficRules_Header_Value != null)
            {
                context.Configuration_HostSharedAlb_TestTrafficRules_Header_Value = new List<System.String>(this.Configuration_HostSharedAlb_TestTrafficRules_Header_Value);
            }
            context.Configuration_HostSharedAlb_WebACLArn = this.Configuration_HostSharedAlb_WebACLArn;
            context.DeletionProtection = this.DeletionProtection;
            context.InfrastructureRoleArn = this.InfrastructureRoleArn;
            #if MODULAR
            if (this.InfrastructureRoleArn == null && ParameterWasBound(nameof(this.InfrastructureRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter InfrastructureRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PropagateTag = this.PropagateTag;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ECS.Model.Tag>(this.Tag);
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
            var request = new Amazon.ECS.Model.CreateGatewayRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.ECS.Model.GatewayConfiguration();
            Amazon.ECS.Model.HostSharedAlbConfiguration requestConfiguration_configuration_HostSharedAlb = null;
            
             // populate HostSharedAlb
            var requestConfiguration_configuration_HostSharedAlbIsNull = true;
            requestConfiguration_configuration_HostSharedAlb = new Amazon.ECS.Model.HostSharedAlbConfiguration();
            Amazon.ECS.GatewayAlbDesyncMitigationMode requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_HttpDesync = null;
            if (cmdletContext.Configuration_HostSharedAlb_HttpDesync != null)
            {
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_HttpDesync = cmdletContext.Configuration_HostSharedAlb_HttpDesync;
            }
            if (requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_HttpDesync != null)
            {
                requestConfiguration_configuration_HostSharedAlb.HttpDesync = requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_HttpDesync;
                requestConfiguration_configuration_HostSharedAlbIsNull = false;
            }
            System.Int32? requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_MaxAlbCount = null;
            if (cmdletContext.Configuration_HostSharedAlb_MaxAlbCount != null)
            {
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_MaxAlbCount = cmdletContext.Configuration_HostSharedAlb_MaxAlbCount.Value;
            }
            if (requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_MaxAlbCount != null)
            {
                requestConfiguration_configuration_HostSharedAlb.MaxAlbCount = requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_MaxAlbCount.Value;
                requestConfiguration_configuration_HostSharedAlbIsNull = false;
            }
            System.Int32? requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_Port = null;
            if (cmdletContext.Configuration_HostSharedAlb_Port != null)
            {
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_Port = cmdletContext.Configuration_HostSharedAlb_Port.Value;
            }
            if (requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_Port != null)
            {
                requestConfiguration_configuration_HostSharedAlb.Port = requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_Port.Value;
                requestConfiguration_configuration_HostSharedAlbIsNull = false;
            }
            Amazon.ECS.GatewayAlbProtocol requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_Protocol = null;
            if (cmdletContext.Configuration_HostSharedAlb_Protocol != null)
            {
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_Protocol = cmdletContext.Configuration_HostSharedAlb_Protocol;
            }
            if (requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_Protocol != null)
            {
                requestConfiguration_configuration_HostSharedAlb.Protocol = requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_Protocol;
                requestConfiguration_configuration_HostSharedAlbIsNull = false;
            }
            Amazon.ECS.GatewayElbScheme requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_Scheme = null;
            if (cmdletContext.Configuration_HostSharedAlb_Scheme != null)
            {
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_Scheme = cmdletContext.Configuration_HostSharedAlb_Scheme;
            }
            if (requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_Scheme != null)
            {
                requestConfiguration_configuration_HostSharedAlb.Scheme = requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_Scheme;
                requestConfiguration_configuration_HostSharedAlbIsNull = false;
            }
            System.String requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_WebACLArn = null;
            if (cmdletContext.Configuration_HostSharedAlb_WebACLArn != null)
            {
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_WebACLArn = cmdletContext.Configuration_HostSharedAlb_WebACLArn;
            }
            if (requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_WebACLArn != null)
            {
                requestConfiguration_configuration_HostSharedAlb.WebACLArn = requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_WebACLArn;
                requestConfiguration_configuration_HostSharedAlbIsNull = false;
            }
            Amazon.ECS.Model.GatewayElbAccessLogConfiguration requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogs = null;
            
             // populate AccessLogs
            var requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogsIsNull = true;
            requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogs = new Amazon.ECS.Model.GatewayElbAccessLogConfiguration();
            Amazon.ECS.Model.GatewayElbAccessLogDestination requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogs_configuration_HostSharedAlb_AccessLogs_Destination = null;
            
             // populate Destination
            var requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogs_configuration_HostSharedAlb_AccessLogs_DestinationIsNull = true;
            requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogs_configuration_HostSharedAlb_AccessLogs_Destination = new Amazon.ECS.Model.GatewayElbAccessLogDestination();
            Amazon.ECS.Model.GatewayElbAccessLogS3Destination requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogs_configuration_HostSharedAlb_AccessLogs_Destination_configuration_HostSharedAlb_AccessLogs_Destination_S3 = null;
            
             // populate S3
            var requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogs_configuration_HostSharedAlb_AccessLogs_Destination_configuration_HostSharedAlb_AccessLogs_Destination_S3IsNull = true;
            requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogs_configuration_HostSharedAlb_AccessLogs_Destination_configuration_HostSharedAlb_AccessLogs_Destination_S3 = new Amazon.ECS.Model.GatewayElbAccessLogS3Destination();
            System.String requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogs_configuration_HostSharedAlb_AccessLogs_Destination_configuration_HostSharedAlb_AccessLogs_Destination_S3_configuration_HostSharedAlb_AccessLogs_Destination_S3_Bucket = null;
            if (cmdletContext.Configuration_HostSharedAlb_AccessLogs_Destination_S3_Bucket != null)
            {
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogs_configuration_HostSharedAlb_AccessLogs_Destination_configuration_HostSharedAlb_AccessLogs_Destination_S3_configuration_HostSharedAlb_AccessLogs_Destination_S3_Bucket = cmdletContext.Configuration_HostSharedAlb_AccessLogs_Destination_S3_Bucket;
            }
            if (requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogs_configuration_HostSharedAlb_AccessLogs_Destination_configuration_HostSharedAlb_AccessLogs_Destination_S3_configuration_HostSharedAlb_AccessLogs_Destination_S3_Bucket != null)
            {
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogs_configuration_HostSharedAlb_AccessLogs_Destination_configuration_HostSharedAlb_AccessLogs_Destination_S3.Bucket = requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogs_configuration_HostSharedAlb_AccessLogs_Destination_configuration_HostSharedAlb_AccessLogs_Destination_S3_configuration_HostSharedAlb_AccessLogs_Destination_S3_Bucket;
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogs_configuration_HostSharedAlb_AccessLogs_Destination_configuration_HostSharedAlb_AccessLogs_Destination_S3IsNull = false;
            }
            System.String requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogs_configuration_HostSharedAlb_AccessLogs_Destination_configuration_HostSharedAlb_AccessLogs_Destination_S3_configuration_HostSharedAlb_AccessLogs_Destination_S3_Prefix = null;
            if (cmdletContext.Configuration_HostSharedAlb_AccessLogs_Destination_S3_Prefix != null)
            {
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogs_configuration_HostSharedAlb_AccessLogs_Destination_configuration_HostSharedAlb_AccessLogs_Destination_S3_configuration_HostSharedAlb_AccessLogs_Destination_S3_Prefix = cmdletContext.Configuration_HostSharedAlb_AccessLogs_Destination_S3_Prefix;
            }
            if (requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogs_configuration_HostSharedAlb_AccessLogs_Destination_configuration_HostSharedAlb_AccessLogs_Destination_S3_configuration_HostSharedAlb_AccessLogs_Destination_S3_Prefix != null)
            {
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogs_configuration_HostSharedAlb_AccessLogs_Destination_configuration_HostSharedAlb_AccessLogs_Destination_S3.Prefix = requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogs_configuration_HostSharedAlb_AccessLogs_Destination_configuration_HostSharedAlb_AccessLogs_Destination_S3_configuration_HostSharedAlb_AccessLogs_Destination_S3_Prefix;
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogs_configuration_HostSharedAlb_AccessLogs_Destination_configuration_HostSharedAlb_AccessLogs_Destination_S3IsNull = false;
            }
             // determine if requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogs_configuration_HostSharedAlb_AccessLogs_Destination_configuration_HostSharedAlb_AccessLogs_Destination_S3 should be set to null
            if (requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogs_configuration_HostSharedAlb_AccessLogs_Destination_configuration_HostSharedAlb_AccessLogs_Destination_S3IsNull)
            {
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogs_configuration_HostSharedAlb_AccessLogs_Destination_configuration_HostSharedAlb_AccessLogs_Destination_S3 = null;
            }
            if (requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogs_configuration_HostSharedAlb_AccessLogs_Destination_configuration_HostSharedAlb_AccessLogs_Destination_S3 != null)
            {
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogs_configuration_HostSharedAlb_AccessLogs_Destination.S3 = requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogs_configuration_HostSharedAlb_AccessLogs_Destination_configuration_HostSharedAlb_AccessLogs_Destination_S3;
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogs_configuration_HostSharedAlb_AccessLogs_DestinationIsNull = false;
            }
             // determine if requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogs_configuration_HostSharedAlb_AccessLogs_Destination should be set to null
            if (requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogs_configuration_HostSharedAlb_AccessLogs_DestinationIsNull)
            {
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogs_configuration_HostSharedAlb_AccessLogs_Destination = null;
            }
            if (requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogs_configuration_HostSharedAlb_AccessLogs_Destination != null)
            {
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogs.Destination = requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogs_configuration_HostSharedAlb_AccessLogs_Destination;
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogsIsNull = false;
            }
             // determine if requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogs should be set to null
            if (requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogsIsNull)
            {
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogs = null;
            }
            if (requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogs != null)
            {
                requestConfiguration_configuration_HostSharedAlb.AccessLogs = requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_AccessLogs;
                requestConfiguration_configuration_HostSharedAlbIsNull = false;
            }
            Amazon.ECS.Model.GatewayAlbTestTrafficRules requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_TestTrafficRules = null;
            
             // populate TestTrafficRules
            var requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_TestTrafficRulesIsNull = true;
            requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_TestTrafficRules = new Amazon.ECS.Model.GatewayAlbTestTrafficRules();
            Amazon.ECS.Model.GatewayTestTrafficHeader requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_TestTrafficRules_configuration_HostSharedAlb_TestTrafficRules_Header = null;
            
             // populate Header
            var requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_TestTrafficRules_configuration_HostSharedAlb_TestTrafficRules_HeaderIsNull = true;
            requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_TestTrafficRules_configuration_HostSharedAlb_TestTrafficRules_Header = new Amazon.ECS.Model.GatewayTestTrafficHeader();
            System.String requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_TestTrafficRules_configuration_HostSharedAlb_TestTrafficRules_Header_configuration_HostSharedAlb_TestTrafficRules_Header_Name = null;
            if (cmdletContext.Configuration_HostSharedAlb_TestTrafficRules_Header_Name != null)
            {
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_TestTrafficRules_configuration_HostSharedAlb_TestTrafficRules_Header_configuration_HostSharedAlb_TestTrafficRules_Header_Name = cmdletContext.Configuration_HostSharedAlb_TestTrafficRules_Header_Name;
            }
            if (requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_TestTrafficRules_configuration_HostSharedAlb_TestTrafficRules_Header_configuration_HostSharedAlb_TestTrafficRules_Header_Name != null)
            {
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_TestTrafficRules_configuration_HostSharedAlb_TestTrafficRules_Header.Name = requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_TestTrafficRules_configuration_HostSharedAlb_TestTrafficRules_Header_configuration_HostSharedAlb_TestTrafficRules_Header_Name;
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_TestTrafficRules_configuration_HostSharedAlb_TestTrafficRules_HeaderIsNull = false;
            }
            List<System.String> requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_TestTrafficRules_configuration_HostSharedAlb_TestTrafficRules_Header_configuration_HostSharedAlb_TestTrafficRules_Header_Value = null;
            if (cmdletContext.Configuration_HostSharedAlb_TestTrafficRules_Header_Value != null)
            {
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_TestTrafficRules_configuration_HostSharedAlb_TestTrafficRules_Header_configuration_HostSharedAlb_TestTrafficRules_Header_Value = cmdletContext.Configuration_HostSharedAlb_TestTrafficRules_Header_Value;
            }
            if (requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_TestTrafficRules_configuration_HostSharedAlb_TestTrafficRules_Header_configuration_HostSharedAlb_TestTrafficRules_Header_Value != null)
            {
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_TestTrafficRules_configuration_HostSharedAlb_TestTrafficRules_Header.Values = requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_TestTrafficRules_configuration_HostSharedAlb_TestTrafficRules_Header_configuration_HostSharedAlb_TestTrafficRules_Header_Value;
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_TestTrafficRules_configuration_HostSharedAlb_TestTrafficRules_HeaderIsNull = false;
            }
             // determine if requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_TestTrafficRules_configuration_HostSharedAlb_TestTrafficRules_Header should be set to null
            if (requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_TestTrafficRules_configuration_HostSharedAlb_TestTrafficRules_HeaderIsNull)
            {
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_TestTrafficRules_configuration_HostSharedAlb_TestTrafficRules_Header = null;
            }
            if (requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_TestTrafficRules_configuration_HostSharedAlb_TestTrafficRules_Header != null)
            {
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_TestTrafficRules.Header = requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_TestTrafficRules_configuration_HostSharedAlb_TestTrafficRules_Header;
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_TestTrafficRulesIsNull = false;
            }
             // determine if requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_TestTrafficRules should be set to null
            if (requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_TestTrafficRulesIsNull)
            {
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_TestTrafficRules = null;
            }
            if (requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_TestTrafficRules != null)
            {
                requestConfiguration_configuration_HostSharedAlb.TestTrafficRules = requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_TestTrafficRules;
                requestConfiguration_configuration_HostSharedAlbIsNull = false;
            }
            Amazon.ECS.Model.GatewayElbNetworkConfiguration requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_NetworkConfiguration = null;
            
             // populate NetworkConfiguration
            var requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_NetworkConfigurationIsNull = true;
            requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_NetworkConfiguration = new Amazon.ECS.Model.GatewayElbNetworkConfiguration();
            System.String requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_NetworkConfiguration_configuration_HostSharedAlb_NetworkConfiguration_InboundSecurityGroup = null;
            if (cmdletContext.Configuration_HostSharedAlb_NetworkConfiguration_InboundSecurityGroup != null)
            {
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_NetworkConfiguration_configuration_HostSharedAlb_NetworkConfiguration_InboundSecurityGroup = cmdletContext.Configuration_HostSharedAlb_NetworkConfiguration_InboundSecurityGroup;
            }
            if (requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_NetworkConfiguration_configuration_HostSharedAlb_NetworkConfiguration_InboundSecurityGroup != null)
            {
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_NetworkConfiguration.InboundSecurityGroup = requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_NetworkConfiguration_configuration_HostSharedAlb_NetworkConfiguration_InboundSecurityGroup;
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_NetworkConfigurationIsNull = false;
            }
            Amazon.ECS.GatewayElbIpAddressType requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_NetworkConfiguration_configuration_HostSharedAlb_NetworkConfiguration_IpAddressType = null;
            if (cmdletContext.Configuration_HostSharedAlb_NetworkConfiguration_IpAddressType != null)
            {
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_NetworkConfiguration_configuration_HostSharedAlb_NetworkConfiguration_IpAddressType = cmdletContext.Configuration_HostSharedAlb_NetworkConfiguration_IpAddressType;
            }
            if (requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_NetworkConfiguration_configuration_HostSharedAlb_NetworkConfiguration_IpAddressType != null)
            {
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_NetworkConfiguration.IpAddressType = requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_NetworkConfiguration_configuration_HostSharedAlb_NetworkConfiguration_IpAddressType;
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_NetworkConfigurationIsNull = false;
            }
            List<System.String> requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_NetworkConfiguration_configuration_HostSharedAlb_NetworkConfiguration_Subnet = null;
            if (cmdletContext.Configuration_HostSharedAlb_NetworkConfiguration_Subnet != null)
            {
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_NetworkConfiguration_configuration_HostSharedAlb_NetworkConfiguration_Subnet = cmdletContext.Configuration_HostSharedAlb_NetworkConfiguration_Subnet;
            }
            if (requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_NetworkConfiguration_configuration_HostSharedAlb_NetworkConfiguration_Subnet != null)
            {
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_NetworkConfiguration.Subnets = requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_NetworkConfiguration_configuration_HostSharedAlb_NetworkConfiguration_Subnet;
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_NetworkConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_NetworkConfiguration should be set to null
            if (requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_NetworkConfigurationIsNull)
            {
                requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_NetworkConfiguration = null;
            }
            if (requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_NetworkConfiguration != null)
            {
                requestConfiguration_configuration_HostSharedAlb.NetworkConfiguration = requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_NetworkConfiguration;
                requestConfiguration_configuration_HostSharedAlbIsNull = false;
            }
             // determine if requestConfiguration_configuration_HostSharedAlb should be set to null
            if (requestConfiguration_configuration_HostSharedAlbIsNull)
            {
                requestConfiguration_configuration_HostSharedAlb = null;
            }
            if (requestConfiguration_configuration_HostSharedAlb != null)
            {
                request.Configuration.HostSharedAlb = requestConfiguration_configuration_HostSharedAlb;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.DeletionProtection != null)
            {
                request.DeletionProtection = cmdletContext.DeletionProtection.Value;
            }
            if (cmdletContext.InfrastructureRoleArn != null)
            {
                request.InfrastructureRoleArn = cmdletContext.InfrastructureRoleArn;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PropagateTag != null)
            {
                request.PropagateTags = cmdletContext.PropagateTag;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.ECS.Model.CreateGatewayResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.CreateGatewayRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "CreateGateway");
            try
            {
                return client.CreateGatewayAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Configuration_HostSharedAlb_AccessLogs_Destination_S3_Bucket { get; set; }
            public System.String Configuration_HostSharedAlb_AccessLogs_Destination_S3_Prefix { get; set; }
            public Amazon.ECS.GatewayAlbDesyncMitigationMode Configuration_HostSharedAlb_HttpDesync { get; set; }
            public System.Int32? Configuration_HostSharedAlb_MaxAlbCount { get; set; }
            public System.String Configuration_HostSharedAlb_NetworkConfiguration_InboundSecurityGroup { get; set; }
            public Amazon.ECS.GatewayElbIpAddressType Configuration_HostSharedAlb_NetworkConfiguration_IpAddressType { get; set; }
            public List<System.String> Configuration_HostSharedAlb_NetworkConfiguration_Subnet { get; set; }
            public System.Int32? Configuration_HostSharedAlb_Port { get; set; }
            public Amazon.ECS.GatewayAlbProtocol Configuration_HostSharedAlb_Protocol { get; set; }
            public Amazon.ECS.GatewayElbScheme Configuration_HostSharedAlb_Scheme { get; set; }
            public System.String Configuration_HostSharedAlb_TestTrafficRules_Header_Name { get; set; }
            public List<System.String> Configuration_HostSharedAlb_TestTrafficRules_Header_Value { get; set; }
            public System.String Configuration_HostSharedAlb_WebACLArn { get; set; }
            public System.Boolean? DeletionProtection { get; set; }
            public System.String InfrastructureRoleArn { get; set; }
            public System.String Name { get; set; }
            public Amazon.ECS.PropagateGatewayTags PropagateTag { get; set; }
            public List<Amazon.ECS.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ECS.Model.CreateGatewayResponse, NewECSGatewayCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
