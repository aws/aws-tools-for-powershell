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
    /// Modifies the configuration of a gateway. You can change only the properties that can
    /// be applied without interrupting traffic, and the configuration variant that you provide
    /// must match the gateway's type. <c>UpdateGateway</c> is an asynchronous operation:
    /// the changes are applied to each load balancer the gateway manages, and the gateway
    /// reports a status of <c>UPDATE_IN_PROGRESS</c> until the update completes. If Amazon
    /// ECS can't update one or more resources, it makes a best effort to update the rest
    /// and the gateway status changes to <c>UPDATE_FAILED</c>. Use <c>DescribeGateway</c>
    /// to inspect the gateway's <c>statusReason</c> and failures list, which gives the ARN
    /// of each load balancer that was not updated and the operation, error code, and message
    /// for each failure.
    /// 
    ///  
    /// <para>
    /// If you specify <c>infrastructureRoleArn</c>, you must have the <c>iam:PassRole</c>
    /// permission for that role.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "ECSGateway", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECS.Model.UpdateGatewayResponse")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service UpdateGateway API operation.", Operation = new[] {"UpdateGateway"}, SelectReturnType = typeof(Amazon.ECS.Model.UpdateGatewayResponse))]
    [AWSCmdletOutput("Amazon.ECS.Model.UpdateGatewayResponse",
        "This cmdlet returns an Amazon.ECS.Model.UpdateGatewayResponse object containing multiple properties."
    )]
    public partial class UpdateECSGatewayCmdlet : AmazonECSClientCmdlet, IExecutor
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
        /// gateway can't be deleted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeletionProtection { get; set; }
        #endregion
        
        #region Parameter Gateway
        /// <summary>
        /// <para>
        /// <para>The name or Amazon Resource Name (ARN) of the gateway to update.</para>
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
        public System.String Gateway { get; set; }
        #endregion
        
        #region Parameter Configuration_HostSharedAlb_HttpDesync
        /// <summary>
        /// <para>
        /// <para>The desync mitigation mode for the load balancers that the gateway manages.</para>
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
        /// <para>The Amazon Resource Name (ARN) of the IAM role that the gateway assumes to manage
        /// infrastructure on your behalf.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InfrastructureRoleArn { get; set; }
        #endregion
        
        #region Parameter Configuration_HostSharedAlb_MaxAlbCount
        /// <summary>
        /// <para>
        /// <para>The maximum number of Application Load Balancers that the gateway manages.</para>
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
        /// the gateway manages. If you don't specify a value, the gateway's existing setting
        /// is unchanged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PropagateTags")]
        [AWSConstantClassSource("Amazon.ECS.PropagateGatewayTags")]
        public Amazon.ECS.PropagateGatewayTags PropagateTag { get; set; }
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECS.Model.UpdateGatewayResponse).
        /// Specifying the name of a property of type Amazon.ECS.Model.UpdateGatewayResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Gateway), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ECSGateway (UpdateGateway)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECS.Model.UpdateGatewayResponse, UpdateECSGatewayCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Configuration_HostSharedAlb_AccessLogs_Destination_S3_Bucket = this.Configuration_HostSharedAlb_AccessLogs_Destination_S3_Bucket;
            context.Configuration_HostSharedAlb_AccessLogs_Destination_S3_Prefix = this.Configuration_HostSharedAlb_AccessLogs_Destination_S3_Prefix;
            context.Configuration_HostSharedAlb_HttpDesync = this.Configuration_HostSharedAlb_HttpDesync;
            context.Configuration_HostSharedAlb_MaxAlbCount = this.Configuration_HostSharedAlb_MaxAlbCount;
            context.Configuration_HostSharedAlb_NetworkConfiguration_InboundSecurityGroup = this.Configuration_HostSharedAlb_NetworkConfiguration_InboundSecurityGroup;
            context.Configuration_HostSharedAlb_TestTrafficRules_Header_Name = this.Configuration_HostSharedAlb_TestTrafficRules_Header_Name;
            if (this.Configuration_HostSharedAlb_TestTrafficRules_Header_Value != null)
            {
                context.Configuration_HostSharedAlb_TestTrafficRules_Header_Value = new List<System.String>(this.Configuration_HostSharedAlb_TestTrafficRules_Header_Value);
            }
            context.Configuration_HostSharedAlb_WebACLArn = this.Configuration_HostSharedAlb_WebACLArn;
            context.DeletionProtection = this.DeletionProtection;
            context.Gateway = this.Gateway;
            #if MODULAR
            if (this.Gateway == null && ParameterWasBound(nameof(this.Gateway)))
            {
                WriteWarning("You are passing $null as a value for parameter Gateway which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InfrastructureRoleArn = this.InfrastructureRoleArn;
            context.PropagateTag = this.PropagateTag;
            
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
            var request = new Amazon.ECS.Model.UpdateGatewayRequest();
            
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.ECS.Model.UpdateGatewayConfiguration();
            Amazon.ECS.Model.UpdateGatewayAlbConfiguration requestConfiguration_configuration_HostSharedAlb = null;
            
             // populate HostSharedAlb
            var requestConfiguration_configuration_HostSharedAlbIsNull = true;
            requestConfiguration_configuration_HostSharedAlb = new Amazon.ECS.Model.UpdateGatewayAlbConfiguration();
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
            Amazon.ECS.Model.UpdateGatewayNetworkConfiguration requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_NetworkConfiguration = null;
            
             // populate NetworkConfiguration
            var requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_NetworkConfigurationIsNull = true;
            requestConfiguration_configuration_HostSharedAlb_configuration_HostSharedAlb_NetworkConfiguration = new Amazon.ECS.Model.UpdateGatewayNetworkConfiguration();
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
            if (cmdletContext.Gateway != null)
            {
                request.Gateway = cmdletContext.Gateway;
            }
            if (cmdletContext.InfrastructureRoleArn != null)
            {
                request.InfrastructureRoleArn = cmdletContext.InfrastructureRoleArn;
            }
            if (cmdletContext.PropagateTag != null)
            {
                request.PropagateTags = cmdletContext.PropagateTag;
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
        
        private Amazon.ECS.Model.UpdateGatewayResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.UpdateGatewayRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "UpdateGateway");
            try
            {
                return client.UpdateGatewayAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Configuration_HostSharedAlb_AccessLogs_Destination_S3_Bucket { get; set; }
            public System.String Configuration_HostSharedAlb_AccessLogs_Destination_S3_Prefix { get; set; }
            public Amazon.ECS.GatewayAlbDesyncMitigationMode Configuration_HostSharedAlb_HttpDesync { get; set; }
            public System.Int32? Configuration_HostSharedAlb_MaxAlbCount { get; set; }
            public System.String Configuration_HostSharedAlb_NetworkConfiguration_InboundSecurityGroup { get; set; }
            public System.String Configuration_HostSharedAlb_TestTrafficRules_Header_Name { get; set; }
            public List<System.String> Configuration_HostSharedAlb_TestTrafficRules_Header_Value { get; set; }
            public System.String Configuration_HostSharedAlb_WebACLArn { get; set; }
            public System.Boolean? DeletionProtection { get; set; }
            public System.String Gateway { get; set; }
            public System.String InfrastructureRoleArn { get; set; }
            public Amazon.ECS.PropagateGatewayTags PropagateTag { get; set; }
            public System.Func<Amazon.ECS.Model.UpdateGatewayResponse, UpdateECSGatewayCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
