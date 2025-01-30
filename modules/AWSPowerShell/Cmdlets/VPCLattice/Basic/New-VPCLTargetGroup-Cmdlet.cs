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
using Amazon.VPCLattice;
using Amazon.VPCLattice.Model;

namespace Amazon.PowerShell.Cmdlets.VPCL
{
    /// <summary>
    /// Creates a target group. A target group is a collection of targets, or compute resources,
    /// that run your application or service. A target group can only be used by a single
    /// service.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/vpc-lattice/latest/ug/target-groups.html">Target
    /// groups</a> in the <i>Amazon VPC Lattice User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "VPCLTargetGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.VPCLattice.Model.CreateTargetGroupResponse")]
    [AWSCmdlet("Calls the VPC Lattice CreateTargetGroup API operation.", Operation = new[] {"CreateTargetGroup"}, SelectReturnType = typeof(Amazon.VPCLattice.Model.CreateTargetGroupResponse))]
    [AWSCmdletOutput("Amazon.VPCLattice.Model.CreateTargetGroupResponse",
        "This cmdlet returns an Amazon.VPCLattice.Model.CreateTargetGroupResponse object containing multiple properties."
    )]
    public partial class NewVPCLTargetGroupCmdlet : AmazonVPCLatticeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter HealthCheck_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether health checking is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Config_HealthCheck_Enabled")]
        public System.Boolean? HealthCheck_Enabled { get; set; }
        #endregion
        
        #region Parameter HealthCheck_HealthCheckIntervalSecond
        /// <summary>
        /// <para>
        /// <para>The approximate amount of time, in seconds, between health checks of an individual
        /// target. The range is 5–300 seconds. The default is 30 seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Config_HealthCheck_HealthCheckIntervalSeconds")]
        public System.Int32? HealthCheck_HealthCheckIntervalSecond { get; set; }
        #endregion
        
        #region Parameter HealthCheck_HealthCheckTimeoutSecond
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, to wait before reporting a target as unhealthy. The
        /// range is 1–120 seconds. The default is 5 seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Config_HealthCheck_HealthCheckTimeoutSeconds")]
        public System.Int32? HealthCheck_HealthCheckTimeoutSecond { get; set; }
        #endregion
        
        #region Parameter HealthCheck_HealthyThresholdCount
        /// <summary>
        /// <para>
        /// <para>The number of consecutive successful health checks required before considering an
        /// unhealthy target healthy. The range is 2–10. The default is 5.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Config_HealthCheck_HealthyThresholdCount")]
        public System.Int32? HealthCheck_HealthyThresholdCount { get; set; }
        #endregion
        
        #region Parameter Matcher_HttpCode
        /// <summary>
        /// <para>
        /// <para>The HTTP code to use when checking for a successful response from a target.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Config_HealthCheck_Matcher_HttpCode")]
        public System.String Matcher_HttpCode { get; set; }
        #endregion
        
        #region Parameter Config_IpAddressType
        /// <summary>
        /// <para>
        /// <para>The type of IP address used for the target group. Supported only if the target group
        /// type is <c>IP</c>. The default is <c>IPV4</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.VPCLattice.IpAddressType")]
        public Amazon.VPCLattice.IpAddressType Config_IpAddressType { get; set; }
        #endregion
        
        #region Parameter Config_LambdaEventStructureVersion
        /// <summary>
        /// <para>
        /// <para>The version of the event structure that your Lambda function receives. Supported only
        /// if the target group type is <c>LAMBDA</c>. The default is <c>V1</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.VPCLattice.LambdaEventStructureVersion")]
        public Amazon.VPCLattice.LambdaEventStructureVersion Config_LambdaEventStructureVersion { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the target group. The name must be unique within the account. The valid
        /// characters are a-z, 0-9, and hyphens (-). You can't use a hyphen as the first or last
        /// character, or immediately after another hyphen.</para>
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
        
        #region Parameter HealthCheck_Path
        /// <summary>
        /// <para>
        /// <para>The destination for health checks on the targets. If the protocol version is <c>HTTP/1.1</c>
        /// or <c>HTTP/2</c>, specify a valid URI (for example, <c>/path?query</c>). The default
        /// path is <c>/</c>. Health checks are not supported if the protocol version is <c>gRPC</c>,
        /// however, you can choose <c>HTTP/1.1</c> or <c>HTTP/2</c> and specify a valid URI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Config_HealthCheck_Path")]
        public System.String HealthCheck_Path { get; set; }
        #endregion
        
        #region Parameter HealthCheck_Port
        /// <summary>
        /// <para>
        /// <para>The port used when performing health checks on targets. The default setting is the
        /// port that a target receives traffic on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Config_HealthCheck_Port")]
        public System.Int32? HealthCheck_Port { get; set; }
        #endregion
        
        #region Parameter Config_Port
        /// <summary>
        /// <para>
        /// <para>The port on which the targets are listening. For HTTP, the default is 80. For HTTPS,
        /// the default is 443. Not supported if the target group type is <c>LAMBDA</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Config_Port { get; set; }
        #endregion
        
        #region Parameter HealthCheck_Protocol
        /// <summary>
        /// <para>
        /// <para>The protocol used when performing health checks on targets. The possible protocols
        /// are <c>HTTP</c> and <c>HTTPS</c>. The default is <c>HTTP</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Config_HealthCheck_Protocol")]
        [AWSConstantClassSource("Amazon.VPCLattice.TargetGroupProtocol")]
        public Amazon.VPCLattice.TargetGroupProtocol HealthCheck_Protocol { get; set; }
        #endregion
        
        #region Parameter Config_Protocol
        /// <summary>
        /// <para>
        /// <para>The protocol to use for routing traffic to the targets. The default is the protocol
        /// of the target group. Not supported if the target group type is <c>LAMBDA</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.VPCLattice.TargetGroupProtocol")]
        public Amazon.VPCLattice.TargetGroupProtocol Config_Protocol { get; set; }
        #endregion
        
        #region Parameter HealthCheck_ProtocolVersion
        /// <summary>
        /// <para>
        /// <para>The protocol version used when performing health checks on targets. The possible protocol
        /// versions are <c>HTTP1</c> and <c>HTTP2</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Config_HealthCheck_ProtocolVersion")]
        [AWSConstantClassSource("Amazon.VPCLattice.HealthCheckProtocolVersion")]
        public Amazon.VPCLattice.HealthCheckProtocolVersion HealthCheck_ProtocolVersion { get; set; }
        #endregion
        
        #region Parameter Config_ProtocolVersion
        /// <summary>
        /// <para>
        /// <para>The protocol version. The default is <c>HTTP1</c>. Not supported if the target group
        /// type is <c>LAMBDA</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.VPCLattice.TargetGroupProtocolVersion")]
        public Amazon.VPCLattice.TargetGroupProtocolVersion Config_ProtocolVersion { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags for the target group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of target group.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.VPCLattice.TargetGroupType")]
        public Amazon.VPCLattice.TargetGroupType Type { get; set; }
        #endregion
        
        #region Parameter HealthCheck_UnhealthyThresholdCount
        /// <summary>
        /// <para>
        /// <para>The number of consecutive failed health checks required before considering a target
        /// unhealthy. The range is 2–10. The default is 2.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Config_HealthCheck_UnhealthyThresholdCount")]
        public System.Int32? HealthCheck_UnhealthyThresholdCount { get; set; }
        #endregion
        
        #region Parameter Config_VpcIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the VPC. Not supported if the target group type is <c>LAMBDA</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Config_VpcIdentifier { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If you retry a request that completed successfully using the same client
        /// token and parameters, the retry succeeds without performing any actions. If the parameters
        /// aren't identical, the retry fails.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.VPCLattice.Model.CreateTargetGroupResponse).
        /// Specifying the name of a property of type Amazon.VPCLattice.Model.CreateTargetGroupResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-VPCLTargetGroup (CreateTargetGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.VPCLattice.Model.CreateTargetGroupResponse, NewVPCLTargetGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.HealthCheck_Enabled = this.HealthCheck_Enabled;
            context.HealthCheck_HealthCheckIntervalSecond = this.HealthCheck_HealthCheckIntervalSecond;
            context.HealthCheck_HealthCheckTimeoutSecond = this.HealthCheck_HealthCheckTimeoutSecond;
            context.HealthCheck_HealthyThresholdCount = this.HealthCheck_HealthyThresholdCount;
            context.Matcher_HttpCode = this.Matcher_HttpCode;
            context.HealthCheck_Path = this.HealthCheck_Path;
            context.HealthCheck_Port = this.HealthCheck_Port;
            context.HealthCheck_Protocol = this.HealthCheck_Protocol;
            context.HealthCheck_ProtocolVersion = this.HealthCheck_ProtocolVersion;
            context.HealthCheck_UnhealthyThresholdCount = this.HealthCheck_UnhealthyThresholdCount;
            context.Config_IpAddressType = this.Config_IpAddressType;
            context.Config_LambdaEventStructureVersion = this.Config_LambdaEventStructureVersion;
            context.Config_Port = this.Config_Port;
            context.Config_Protocol = this.Config_Protocol;
            context.Config_ProtocolVersion = this.Config_ProtocolVersion;
            context.Config_VpcIdentifier = this.Config_VpcIdentifier;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.VPCLattice.Model.CreateTargetGroupRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate Config
            var requestConfigIsNull = true;
            request.Config = new Amazon.VPCLattice.Model.TargetGroupConfig();
            Amazon.VPCLattice.IpAddressType requestConfig_config_IpAddressType = null;
            if (cmdletContext.Config_IpAddressType != null)
            {
                requestConfig_config_IpAddressType = cmdletContext.Config_IpAddressType;
            }
            if (requestConfig_config_IpAddressType != null)
            {
                request.Config.IpAddressType = requestConfig_config_IpAddressType;
                requestConfigIsNull = false;
            }
            Amazon.VPCLattice.LambdaEventStructureVersion requestConfig_config_LambdaEventStructureVersion = null;
            if (cmdletContext.Config_LambdaEventStructureVersion != null)
            {
                requestConfig_config_LambdaEventStructureVersion = cmdletContext.Config_LambdaEventStructureVersion;
            }
            if (requestConfig_config_LambdaEventStructureVersion != null)
            {
                request.Config.LambdaEventStructureVersion = requestConfig_config_LambdaEventStructureVersion;
                requestConfigIsNull = false;
            }
            System.Int32? requestConfig_config_Port = null;
            if (cmdletContext.Config_Port != null)
            {
                requestConfig_config_Port = cmdletContext.Config_Port.Value;
            }
            if (requestConfig_config_Port != null)
            {
                request.Config.Port = requestConfig_config_Port.Value;
                requestConfigIsNull = false;
            }
            Amazon.VPCLattice.TargetGroupProtocol requestConfig_config_Protocol = null;
            if (cmdletContext.Config_Protocol != null)
            {
                requestConfig_config_Protocol = cmdletContext.Config_Protocol;
            }
            if (requestConfig_config_Protocol != null)
            {
                request.Config.Protocol = requestConfig_config_Protocol;
                requestConfigIsNull = false;
            }
            Amazon.VPCLattice.TargetGroupProtocolVersion requestConfig_config_ProtocolVersion = null;
            if (cmdletContext.Config_ProtocolVersion != null)
            {
                requestConfig_config_ProtocolVersion = cmdletContext.Config_ProtocolVersion;
            }
            if (requestConfig_config_ProtocolVersion != null)
            {
                request.Config.ProtocolVersion = requestConfig_config_ProtocolVersion;
                requestConfigIsNull = false;
            }
            System.String requestConfig_config_VpcIdentifier = null;
            if (cmdletContext.Config_VpcIdentifier != null)
            {
                requestConfig_config_VpcIdentifier = cmdletContext.Config_VpcIdentifier;
            }
            if (requestConfig_config_VpcIdentifier != null)
            {
                request.Config.VpcIdentifier = requestConfig_config_VpcIdentifier;
                requestConfigIsNull = false;
            }
            Amazon.VPCLattice.Model.HealthCheckConfig requestConfig_config_HealthCheck = null;
            
             // populate HealthCheck
            var requestConfig_config_HealthCheckIsNull = true;
            requestConfig_config_HealthCheck = new Amazon.VPCLattice.Model.HealthCheckConfig();
            System.Boolean? requestConfig_config_HealthCheck_healthCheck_Enabled = null;
            if (cmdletContext.HealthCheck_Enabled != null)
            {
                requestConfig_config_HealthCheck_healthCheck_Enabled = cmdletContext.HealthCheck_Enabled.Value;
            }
            if (requestConfig_config_HealthCheck_healthCheck_Enabled != null)
            {
                requestConfig_config_HealthCheck.Enabled = requestConfig_config_HealthCheck_healthCheck_Enabled.Value;
                requestConfig_config_HealthCheckIsNull = false;
            }
            System.Int32? requestConfig_config_HealthCheck_healthCheck_HealthCheckIntervalSecond = null;
            if (cmdletContext.HealthCheck_HealthCheckIntervalSecond != null)
            {
                requestConfig_config_HealthCheck_healthCheck_HealthCheckIntervalSecond = cmdletContext.HealthCheck_HealthCheckIntervalSecond.Value;
            }
            if (requestConfig_config_HealthCheck_healthCheck_HealthCheckIntervalSecond != null)
            {
                requestConfig_config_HealthCheck.HealthCheckIntervalSeconds = requestConfig_config_HealthCheck_healthCheck_HealthCheckIntervalSecond.Value;
                requestConfig_config_HealthCheckIsNull = false;
            }
            System.Int32? requestConfig_config_HealthCheck_healthCheck_HealthCheckTimeoutSecond = null;
            if (cmdletContext.HealthCheck_HealthCheckTimeoutSecond != null)
            {
                requestConfig_config_HealthCheck_healthCheck_HealthCheckTimeoutSecond = cmdletContext.HealthCheck_HealthCheckTimeoutSecond.Value;
            }
            if (requestConfig_config_HealthCheck_healthCheck_HealthCheckTimeoutSecond != null)
            {
                requestConfig_config_HealthCheck.HealthCheckTimeoutSeconds = requestConfig_config_HealthCheck_healthCheck_HealthCheckTimeoutSecond.Value;
                requestConfig_config_HealthCheckIsNull = false;
            }
            System.Int32? requestConfig_config_HealthCheck_healthCheck_HealthyThresholdCount = null;
            if (cmdletContext.HealthCheck_HealthyThresholdCount != null)
            {
                requestConfig_config_HealthCheck_healthCheck_HealthyThresholdCount = cmdletContext.HealthCheck_HealthyThresholdCount.Value;
            }
            if (requestConfig_config_HealthCheck_healthCheck_HealthyThresholdCount != null)
            {
                requestConfig_config_HealthCheck.HealthyThresholdCount = requestConfig_config_HealthCheck_healthCheck_HealthyThresholdCount.Value;
                requestConfig_config_HealthCheckIsNull = false;
            }
            System.String requestConfig_config_HealthCheck_healthCheck_Path = null;
            if (cmdletContext.HealthCheck_Path != null)
            {
                requestConfig_config_HealthCheck_healthCheck_Path = cmdletContext.HealthCheck_Path;
            }
            if (requestConfig_config_HealthCheck_healthCheck_Path != null)
            {
                requestConfig_config_HealthCheck.Path = requestConfig_config_HealthCheck_healthCheck_Path;
                requestConfig_config_HealthCheckIsNull = false;
            }
            System.Int32? requestConfig_config_HealthCheck_healthCheck_Port = null;
            if (cmdletContext.HealthCheck_Port != null)
            {
                requestConfig_config_HealthCheck_healthCheck_Port = cmdletContext.HealthCheck_Port.Value;
            }
            if (requestConfig_config_HealthCheck_healthCheck_Port != null)
            {
                requestConfig_config_HealthCheck.Port = requestConfig_config_HealthCheck_healthCheck_Port.Value;
                requestConfig_config_HealthCheckIsNull = false;
            }
            Amazon.VPCLattice.TargetGroupProtocol requestConfig_config_HealthCheck_healthCheck_Protocol = null;
            if (cmdletContext.HealthCheck_Protocol != null)
            {
                requestConfig_config_HealthCheck_healthCheck_Protocol = cmdletContext.HealthCheck_Protocol;
            }
            if (requestConfig_config_HealthCheck_healthCheck_Protocol != null)
            {
                requestConfig_config_HealthCheck.Protocol = requestConfig_config_HealthCheck_healthCheck_Protocol;
                requestConfig_config_HealthCheckIsNull = false;
            }
            Amazon.VPCLattice.HealthCheckProtocolVersion requestConfig_config_HealthCheck_healthCheck_ProtocolVersion = null;
            if (cmdletContext.HealthCheck_ProtocolVersion != null)
            {
                requestConfig_config_HealthCheck_healthCheck_ProtocolVersion = cmdletContext.HealthCheck_ProtocolVersion;
            }
            if (requestConfig_config_HealthCheck_healthCheck_ProtocolVersion != null)
            {
                requestConfig_config_HealthCheck.ProtocolVersion = requestConfig_config_HealthCheck_healthCheck_ProtocolVersion;
                requestConfig_config_HealthCheckIsNull = false;
            }
            System.Int32? requestConfig_config_HealthCheck_healthCheck_UnhealthyThresholdCount = null;
            if (cmdletContext.HealthCheck_UnhealthyThresholdCount != null)
            {
                requestConfig_config_HealthCheck_healthCheck_UnhealthyThresholdCount = cmdletContext.HealthCheck_UnhealthyThresholdCount.Value;
            }
            if (requestConfig_config_HealthCheck_healthCheck_UnhealthyThresholdCount != null)
            {
                requestConfig_config_HealthCheck.UnhealthyThresholdCount = requestConfig_config_HealthCheck_healthCheck_UnhealthyThresholdCount.Value;
                requestConfig_config_HealthCheckIsNull = false;
            }
            Amazon.VPCLattice.Model.Matcher requestConfig_config_HealthCheck_config_HealthCheck_Matcher = null;
            
             // populate Matcher
            var requestConfig_config_HealthCheck_config_HealthCheck_MatcherIsNull = true;
            requestConfig_config_HealthCheck_config_HealthCheck_Matcher = new Amazon.VPCLattice.Model.Matcher();
            System.String requestConfig_config_HealthCheck_config_HealthCheck_Matcher_matcher_HttpCode = null;
            if (cmdletContext.Matcher_HttpCode != null)
            {
                requestConfig_config_HealthCheck_config_HealthCheck_Matcher_matcher_HttpCode = cmdletContext.Matcher_HttpCode;
            }
            if (requestConfig_config_HealthCheck_config_HealthCheck_Matcher_matcher_HttpCode != null)
            {
                requestConfig_config_HealthCheck_config_HealthCheck_Matcher.HttpCode = requestConfig_config_HealthCheck_config_HealthCheck_Matcher_matcher_HttpCode;
                requestConfig_config_HealthCheck_config_HealthCheck_MatcherIsNull = false;
            }
             // determine if requestConfig_config_HealthCheck_config_HealthCheck_Matcher should be set to null
            if (requestConfig_config_HealthCheck_config_HealthCheck_MatcherIsNull)
            {
                requestConfig_config_HealthCheck_config_HealthCheck_Matcher = null;
            }
            if (requestConfig_config_HealthCheck_config_HealthCheck_Matcher != null)
            {
                requestConfig_config_HealthCheck.Matcher = requestConfig_config_HealthCheck_config_HealthCheck_Matcher;
                requestConfig_config_HealthCheckIsNull = false;
            }
             // determine if requestConfig_config_HealthCheck should be set to null
            if (requestConfig_config_HealthCheckIsNull)
            {
                requestConfig_config_HealthCheck = null;
            }
            if (requestConfig_config_HealthCheck != null)
            {
                request.Config.HealthCheck = requestConfig_config_HealthCheck;
                requestConfigIsNull = false;
            }
             // determine if request.Config should be set to null
            if (requestConfigIsNull)
            {
                request.Config = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.VPCLattice.Model.CreateTargetGroupResponse CallAWSServiceOperation(IAmazonVPCLattice client, Amazon.VPCLattice.Model.CreateTargetGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "VPC Lattice", "CreateTargetGroup");
            try
            {
                #if DESKTOP
                return client.CreateTargetGroup(request);
                #elif CORECLR
                return client.CreateTargetGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.Boolean? HealthCheck_Enabled { get; set; }
            public System.Int32? HealthCheck_HealthCheckIntervalSecond { get; set; }
            public System.Int32? HealthCheck_HealthCheckTimeoutSecond { get; set; }
            public System.Int32? HealthCheck_HealthyThresholdCount { get; set; }
            public System.String Matcher_HttpCode { get; set; }
            public System.String HealthCheck_Path { get; set; }
            public System.Int32? HealthCheck_Port { get; set; }
            public Amazon.VPCLattice.TargetGroupProtocol HealthCheck_Protocol { get; set; }
            public Amazon.VPCLattice.HealthCheckProtocolVersion HealthCheck_ProtocolVersion { get; set; }
            public System.Int32? HealthCheck_UnhealthyThresholdCount { get; set; }
            public Amazon.VPCLattice.IpAddressType Config_IpAddressType { get; set; }
            public Amazon.VPCLattice.LambdaEventStructureVersion Config_LambdaEventStructureVersion { get; set; }
            public System.Int32? Config_Port { get; set; }
            public Amazon.VPCLattice.TargetGroupProtocol Config_Protocol { get; set; }
            public Amazon.VPCLattice.TargetGroupProtocolVersion Config_ProtocolVersion { get; set; }
            public System.String Config_VpcIdentifier { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public Amazon.VPCLattice.TargetGroupType Type { get; set; }
            public System.Func<Amazon.VPCLattice.Model.CreateTargetGroupResponse, NewVPCLTargetGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
