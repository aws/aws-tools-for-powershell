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
using Amazon.BedrockAgentCoreControl;
using Amazon.BedrockAgentCoreControl.Model;

namespace Amazon.PowerShell.Cmdlets.BACC
{
    /// <summary>
    /// Updates an existing Amazon Secure Agent.
    /// </summary>
    [Cmdlet("Update", "BACCAgentRuntime", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCoreControl.Model.UpdateAgentRuntimeResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Core Control Plane Fronting Layer UpdateAgentRuntime API operation.", Operation = new[] {"UpdateAgentRuntime"}, SelectReturnType = typeof(Amazon.BedrockAgentCoreControl.Model.UpdateAgentRuntimeResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCoreControl.Model.UpdateAgentRuntimeResponse",
        "This cmdlet returns an Amazon.BedrockAgentCoreControl.Model.UpdateAgentRuntimeResponse object containing multiple properties."
    )]
    public partial class UpdateBACCAgentRuntimeCmdlet : AmazonBedrockAgentCoreControlClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AgentRuntimeId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the AgentCore Runtime to update.</para>
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
        public System.String AgentRuntimeId { get; set; }
        #endregion
        
        #region Parameter CustomJWTAuthorizer_AllowedAudience
        /// <summary>
        /// <para>
        /// <para>Represents individual audience values that are validated in the incoming JWT token
        /// validation process.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthorizerConfiguration_CustomJWTAuthorizer_AllowedAudience")]
        public System.String[] CustomJWTAuthorizer_AllowedAudience { get; set; }
        #endregion
        
        #region Parameter CustomJWTAuthorizer_AllowedClient
        /// <summary>
        /// <para>
        /// <para>Represents individual client IDs that are validated in the incoming JWT token validation
        /// process.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthorizerConfiguration_CustomJWTAuthorizer_AllowedClients")]
        public System.String[] CustomJWTAuthorizer_AllowedClient { get; set; }
        #endregion
        
        #region Parameter CustomJWTAuthorizer_AllowedScope
        /// <summary>
        /// <para>
        /// <para>An array of scopes that are allowed to access the token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthorizerConfiguration_CustomJWTAuthorizer_AllowedScopes")]
        public System.String[] CustomJWTAuthorizer_AllowedScope { get; set; }
        #endregion
        
        #region Parameter S3_Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 bucket. This bucket contains the stored data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AgentRuntimeArtifact_CodeConfiguration_Code_S3_Bucket")]
        public System.String S3_Bucket { get; set; }
        #endregion
        
        #region Parameter ContainerConfiguration_ContainerUri
        /// <summary>
        /// <para>
        /// <para>The ECR URI of the container.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AgentRuntimeArtifact_ContainerConfiguration_ContainerUri")]
        public System.String ContainerConfiguration_ContainerUri { get; set; }
        #endregion
        
        #region Parameter CustomJWTAuthorizer_CustomClaim
        /// <summary>
        /// <para>
        /// <para>An array of objects that define a custom claim validation name, value, and operation
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthorizerConfiguration_CustomJWTAuthorizer_CustomClaims")]
        public Amazon.BedrockAgentCoreControl.Model.CustomClaimValidationType[] CustomJWTAuthorizer_CustomClaim { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The updated description of the AgentCore Runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter CustomJWTAuthorizer_DiscoveryUrl
        /// <summary>
        /// <para>
        /// <para>This URL is used to fetch OpenID Connect configuration or authorization server metadata
        /// for validating incoming tokens.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthorizerConfiguration_CustomJWTAuthorizer_DiscoveryUrl")]
        public System.String CustomJWTAuthorizer_DiscoveryUrl { get; set; }
        #endregion
        
        #region Parameter CodeConfiguration_EntryPoint
        /// <summary>
        /// <para>
        /// <para>The entry point for the code execution, specifying the function or method that should
        /// be invoked when the code runs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AgentRuntimeArtifact_CodeConfiguration_EntryPoint")]
        public System.String[] CodeConfiguration_EntryPoint { get; set; }
        #endregion
        
        #region Parameter EnvironmentVariable
        /// <summary>
        /// <para>
        /// <para>Updated environment variables to set in the AgentCore Runtime environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnvironmentVariables")]
        public System.Collections.Hashtable EnvironmentVariable { get; set; }
        #endregion
        
        #region Parameter LifecycleConfiguration_IdleRuntimeSessionTimeout
        /// <summary>
        /// <para>
        /// <para>Timeout in seconds for idle runtime sessions. When a session remains idle for this
        /// duration, it will be automatically terminated. Default: 900 seconds (15 minutes).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? LifecycleConfiguration_IdleRuntimeSessionTimeout { get; set; }
        #endregion
        
        #region Parameter LifecycleConfiguration_MaxLifetime
        /// <summary>
        /// <para>
        /// <para>Maximum lifetime for the instance in seconds. Once reached, instances will be automatically
        /// terminated and replaced. Default: 28800 seconds (8 hours).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? LifecycleConfiguration_MaxLifetime { get; set; }
        #endregion
        
        #region Parameter NetworkConfiguration_NetworkMode
        /// <summary>
        /// <para>
        /// <para>The network mode for the AgentCore Runtime.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.NetworkMode")]
        public Amazon.BedrockAgentCoreControl.NetworkMode NetworkConfiguration_NetworkMode { get; set; }
        #endregion
        
        #region Parameter S3_Prefix
        /// <summary>
        /// <para>
        /// <para>The prefix for objects in the Amazon S3 bucket. This prefix is added to the object
        /// keys to organize the data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AgentRuntimeArtifact_CodeConfiguration_Code_S3_Prefix")]
        public System.String S3_Prefix { get; set; }
        #endregion
        
        #region Parameter RequestHeaderConfiguration_RequestHeaderAllowlist
        /// <summary>
        /// <para>
        /// <para>A list of HTTP request headers that are allowed to be passed through to the runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] RequestHeaderConfiguration_RequestHeaderAllowlist { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The updated IAM role ARN that provides permissions for the AgentCore Runtime.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter CodeConfiguration_Runtime
        /// <summary>
        /// <para>
        /// <para>The runtime environment for executing the code (for example, Python 3.9 or Node.js
        /// 18).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AgentRuntimeArtifact_CodeConfiguration_Runtime")]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.AgentManagedRuntimeType")]
        public Amazon.BedrockAgentCoreControl.AgentManagedRuntimeType CodeConfiguration_Runtime { get; set; }
        #endregion
        
        #region Parameter NetworkModeConfig_SecurityGroup
        /// <summary>
        /// <para>
        /// <para>The security groups associated with the VPC configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfiguration_NetworkModeConfig_SecurityGroups")]
        public System.String[] NetworkModeConfig_SecurityGroup { get; set; }
        #endregion
        
        #region Parameter ProtocolConfiguration_ServerProtocol
        /// <summary>
        /// <para>
        /// <para>The server protocol for the agent runtime. This field specifies which protocol the
        /// agent runtime uses to communicate with clients.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.ServerProtocol")]
        public Amazon.BedrockAgentCoreControl.ServerProtocol ProtocolConfiguration_ServerProtocol { get; set; }
        #endregion
        
        #region Parameter NetworkModeConfig_Subnet
        /// <summary>
        /// <para>
        /// <para>The subnets associated with the VPC configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfiguration_NetworkModeConfig_Subnets")]
        public System.String[] NetworkModeConfig_Subnet { get; set; }
        #endregion
        
        #region Parameter S3_VersionId
        /// <summary>
        /// <para>
        /// <para>The version ID of the Amazon Amazon S3 object. If not specified, the latest version
        /// of the object is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AgentRuntimeArtifact_CodeConfiguration_Code_S3_VersionId")]
        public System.String S3_VersionId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure idempotency of the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCoreControl.Model.UpdateAgentRuntimeResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCoreControl.Model.UpdateAgentRuntimeResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AgentRuntimeId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BACCAgentRuntime (UpdateAgentRuntime)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCoreControl.Model.UpdateAgentRuntimeResponse, UpdateBACCAgentRuntimeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.S3_Bucket = this.S3_Bucket;
            context.S3_Prefix = this.S3_Prefix;
            context.S3_VersionId = this.S3_VersionId;
            if (this.CodeConfiguration_EntryPoint != null)
            {
                context.CodeConfiguration_EntryPoint = new List<System.String>(this.CodeConfiguration_EntryPoint);
            }
            context.CodeConfiguration_Runtime = this.CodeConfiguration_Runtime;
            context.ContainerConfiguration_ContainerUri = this.ContainerConfiguration_ContainerUri;
            context.AgentRuntimeId = this.AgentRuntimeId;
            #if MODULAR
            if (this.AgentRuntimeId == null && ParameterWasBound(nameof(this.AgentRuntimeId)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentRuntimeId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.CustomJWTAuthorizer_AllowedAudience != null)
            {
                context.CustomJWTAuthorizer_AllowedAudience = new List<System.String>(this.CustomJWTAuthorizer_AllowedAudience);
            }
            if (this.CustomJWTAuthorizer_AllowedClient != null)
            {
                context.CustomJWTAuthorizer_AllowedClient = new List<System.String>(this.CustomJWTAuthorizer_AllowedClient);
            }
            if (this.CustomJWTAuthorizer_AllowedScope != null)
            {
                context.CustomJWTAuthorizer_AllowedScope = new List<System.String>(this.CustomJWTAuthorizer_AllowedScope);
            }
            if (this.CustomJWTAuthorizer_CustomClaim != null)
            {
                context.CustomJWTAuthorizer_CustomClaim = new List<Amazon.BedrockAgentCoreControl.Model.CustomClaimValidationType>(this.CustomJWTAuthorizer_CustomClaim);
            }
            context.CustomJWTAuthorizer_DiscoveryUrl = this.CustomJWTAuthorizer_DiscoveryUrl;
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            if (this.EnvironmentVariable != null)
            {
                context.EnvironmentVariable = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.EnvironmentVariable.Keys)
                {
                    context.EnvironmentVariable.Add((String)hashKey, (System.String)(this.EnvironmentVariable[hashKey]));
                }
            }
            context.LifecycleConfiguration_IdleRuntimeSessionTimeout = this.LifecycleConfiguration_IdleRuntimeSessionTimeout;
            context.LifecycleConfiguration_MaxLifetime = this.LifecycleConfiguration_MaxLifetime;
            context.NetworkConfiguration_NetworkMode = this.NetworkConfiguration_NetworkMode;
            #if MODULAR
            if (this.NetworkConfiguration_NetworkMode == null && ParameterWasBound(nameof(this.NetworkConfiguration_NetworkMode)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkConfiguration_NetworkMode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.NetworkModeConfig_SecurityGroup != null)
            {
                context.NetworkModeConfig_SecurityGroup = new List<System.String>(this.NetworkModeConfig_SecurityGroup);
            }
            if (this.NetworkModeConfig_Subnet != null)
            {
                context.NetworkModeConfig_Subnet = new List<System.String>(this.NetworkModeConfig_Subnet);
            }
            context.ProtocolConfiguration_ServerProtocol = this.ProtocolConfiguration_ServerProtocol;
            if (this.RequestHeaderConfiguration_RequestHeaderAllowlist != null)
            {
                context.RequestHeaderConfiguration_RequestHeaderAllowlist = new List<System.String>(this.RequestHeaderConfiguration_RequestHeaderAllowlist);
            }
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BedrockAgentCoreControl.Model.UpdateAgentRuntimeRequest();
            
            
             // populate AgentRuntimeArtifact
            var requestAgentRuntimeArtifactIsNull = true;
            request.AgentRuntimeArtifact = new Amazon.BedrockAgentCoreControl.Model.AgentRuntimeArtifact();
            Amazon.BedrockAgentCoreControl.Model.ContainerConfiguration requestAgentRuntimeArtifact_agentRuntimeArtifact_ContainerConfiguration = null;
            
             // populate ContainerConfiguration
            var requestAgentRuntimeArtifact_agentRuntimeArtifact_ContainerConfigurationIsNull = true;
            requestAgentRuntimeArtifact_agentRuntimeArtifact_ContainerConfiguration = new Amazon.BedrockAgentCoreControl.Model.ContainerConfiguration();
            System.String requestAgentRuntimeArtifact_agentRuntimeArtifact_ContainerConfiguration_containerConfiguration_ContainerUri = null;
            if (cmdletContext.ContainerConfiguration_ContainerUri != null)
            {
                requestAgentRuntimeArtifact_agentRuntimeArtifact_ContainerConfiguration_containerConfiguration_ContainerUri = cmdletContext.ContainerConfiguration_ContainerUri;
            }
            if (requestAgentRuntimeArtifact_agentRuntimeArtifact_ContainerConfiguration_containerConfiguration_ContainerUri != null)
            {
                requestAgentRuntimeArtifact_agentRuntimeArtifact_ContainerConfiguration.ContainerUri = requestAgentRuntimeArtifact_agentRuntimeArtifact_ContainerConfiguration_containerConfiguration_ContainerUri;
                requestAgentRuntimeArtifact_agentRuntimeArtifact_ContainerConfigurationIsNull = false;
            }
             // determine if requestAgentRuntimeArtifact_agentRuntimeArtifact_ContainerConfiguration should be set to null
            if (requestAgentRuntimeArtifact_agentRuntimeArtifact_ContainerConfigurationIsNull)
            {
                requestAgentRuntimeArtifact_agentRuntimeArtifact_ContainerConfiguration = null;
            }
            if (requestAgentRuntimeArtifact_agentRuntimeArtifact_ContainerConfiguration != null)
            {
                request.AgentRuntimeArtifact.ContainerConfiguration = requestAgentRuntimeArtifact_agentRuntimeArtifact_ContainerConfiguration;
                requestAgentRuntimeArtifactIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.CodeConfiguration requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration = null;
            
             // populate CodeConfiguration
            var requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfigurationIsNull = true;
            requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration = new Amazon.BedrockAgentCoreControl.Model.CodeConfiguration();
            List<System.String> requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_codeConfiguration_EntryPoint = null;
            if (cmdletContext.CodeConfiguration_EntryPoint != null)
            {
                requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_codeConfiguration_EntryPoint = cmdletContext.CodeConfiguration_EntryPoint;
            }
            if (requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_codeConfiguration_EntryPoint != null)
            {
                requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration.EntryPoint = requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_codeConfiguration_EntryPoint;
                requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfigurationIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.AgentManagedRuntimeType requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_codeConfiguration_Runtime = null;
            if (cmdletContext.CodeConfiguration_Runtime != null)
            {
                requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_codeConfiguration_Runtime = cmdletContext.CodeConfiguration_Runtime;
            }
            if (requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_codeConfiguration_Runtime != null)
            {
                requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration.Runtime = requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_codeConfiguration_Runtime;
                requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfigurationIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.Code requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_agentRuntimeArtifact_CodeConfiguration_Code = null;
            
             // populate Code
            var requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_agentRuntimeArtifact_CodeConfiguration_CodeIsNull = true;
            requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_agentRuntimeArtifact_CodeConfiguration_Code = new Amazon.BedrockAgentCoreControl.Model.Code();
            Amazon.BedrockAgentCoreControl.Model.S3Location requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_agentRuntimeArtifact_CodeConfiguration_Code_agentRuntimeArtifact_CodeConfiguration_Code_S3 = null;
            
             // populate S3
            var requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_agentRuntimeArtifact_CodeConfiguration_Code_agentRuntimeArtifact_CodeConfiguration_Code_S3IsNull = true;
            requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_agentRuntimeArtifact_CodeConfiguration_Code_agentRuntimeArtifact_CodeConfiguration_Code_S3 = new Amazon.BedrockAgentCoreControl.Model.S3Location();
            System.String requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_agentRuntimeArtifact_CodeConfiguration_Code_agentRuntimeArtifact_CodeConfiguration_Code_S3_s3_Bucket = null;
            if (cmdletContext.S3_Bucket != null)
            {
                requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_agentRuntimeArtifact_CodeConfiguration_Code_agentRuntimeArtifact_CodeConfiguration_Code_S3_s3_Bucket = cmdletContext.S3_Bucket;
            }
            if (requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_agentRuntimeArtifact_CodeConfiguration_Code_agentRuntimeArtifact_CodeConfiguration_Code_S3_s3_Bucket != null)
            {
                requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_agentRuntimeArtifact_CodeConfiguration_Code_agentRuntimeArtifact_CodeConfiguration_Code_S3.Bucket = requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_agentRuntimeArtifact_CodeConfiguration_Code_agentRuntimeArtifact_CodeConfiguration_Code_S3_s3_Bucket;
                requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_agentRuntimeArtifact_CodeConfiguration_Code_agentRuntimeArtifact_CodeConfiguration_Code_S3IsNull = false;
            }
            System.String requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_agentRuntimeArtifact_CodeConfiguration_Code_agentRuntimeArtifact_CodeConfiguration_Code_S3_s3_Prefix = null;
            if (cmdletContext.S3_Prefix != null)
            {
                requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_agentRuntimeArtifact_CodeConfiguration_Code_agentRuntimeArtifact_CodeConfiguration_Code_S3_s3_Prefix = cmdletContext.S3_Prefix;
            }
            if (requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_agentRuntimeArtifact_CodeConfiguration_Code_agentRuntimeArtifact_CodeConfiguration_Code_S3_s3_Prefix != null)
            {
                requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_agentRuntimeArtifact_CodeConfiguration_Code_agentRuntimeArtifact_CodeConfiguration_Code_S3.Prefix = requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_agentRuntimeArtifact_CodeConfiguration_Code_agentRuntimeArtifact_CodeConfiguration_Code_S3_s3_Prefix;
                requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_agentRuntimeArtifact_CodeConfiguration_Code_agentRuntimeArtifact_CodeConfiguration_Code_S3IsNull = false;
            }
            System.String requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_agentRuntimeArtifact_CodeConfiguration_Code_agentRuntimeArtifact_CodeConfiguration_Code_S3_s3_VersionId = null;
            if (cmdletContext.S3_VersionId != null)
            {
                requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_agentRuntimeArtifact_CodeConfiguration_Code_agentRuntimeArtifact_CodeConfiguration_Code_S3_s3_VersionId = cmdletContext.S3_VersionId;
            }
            if (requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_agentRuntimeArtifact_CodeConfiguration_Code_agentRuntimeArtifact_CodeConfiguration_Code_S3_s3_VersionId != null)
            {
                requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_agentRuntimeArtifact_CodeConfiguration_Code_agentRuntimeArtifact_CodeConfiguration_Code_S3.VersionId = requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_agentRuntimeArtifact_CodeConfiguration_Code_agentRuntimeArtifact_CodeConfiguration_Code_S3_s3_VersionId;
                requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_agentRuntimeArtifact_CodeConfiguration_Code_agentRuntimeArtifact_CodeConfiguration_Code_S3IsNull = false;
            }
             // determine if requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_agentRuntimeArtifact_CodeConfiguration_Code_agentRuntimeArtifact_CodeConfiguration_Code_S3 should be set to null
            if (requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_agentRuntimeArtifact_CodeConfiguration_Code_agentRuntimeArtifact_CodeConfiguration_Code_S3IsNull)
            {
                requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_agentRuntimeArtifact_CodeConfiguration_Code_agentRuntimeArtifact_CodeConfiguration_Code_S3 = null;
            }
            if (requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_agentRuntimeArtifact_CodeConfiguration_Code_agentRuntimeArtifact_CodeConfiguration_Code_S3 != null)
            {
                requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_agentRuntimeArtifact_CodeConfiguration_Code.S3 = requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_agentRuntimeArtifact_CodeConfiguration_Code_agentRuntimeArtifact_CodeConfiguration_Code_S3;
                requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_agentRuntimeArtifact_CodeConfiguration_CodeIsNull = false;
            }
             // determine if requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_agentRuntimeArtifact_CodeConfiguration_Code should be set to null
            if (requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_agentRuntimeArtifact_CodeConfiguration_CodeIsNull)
            {
                requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_agentRuntimeArtifact_CodeConfiguration_Code = null;
            }
            if (requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_agentRuntimeArtifact_CodeConfiguration_Code != null)
            {
                requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration.Code = requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration_agentRuntimeArtifact_CodeConfiguration_Code;
                requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfigurationIsNull = false;
            }
             // determine if requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration should be set to null
            if (requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfigurationIsNull)
            {
                requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration = null;
            }
            if (requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration != null)
            {
                request.AgentRuntimeArtifact.CodeConfiguration = requestAgentRuntimeArtifact_agentRuntimeArtifact_CodeConfiguration;
                requestAgentRuntimeArtifactIsNull = false;
            }
             // determine if request.AgentRuntimeArtifact should be set to null
            if (requestAgentRuntimeArtifactIsNull)
            {
                request.AgentRuntimeArtifact = null;
            }
            if (cmdletContext.AgentRuntimeId != null)
            {
                request.AgentRuntimeId = cmdletContext.AgentRuntimeId;
            }
            
             // populate AuthorizerConfiguration
            var requestAuthorizerConfigurationIsNull = true;
            request.AuthorizerConfiguration = new Amazon.BedrockAgentCoreControl.Model.AuthorizerConfiguration();
            Amazon.BedrockAgentCoreControl.Model.CustomJWTAuthorizerConfiguration requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer = null;
            
             // populate CustomJWTAuthorizer
            var requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizerIsNull = true;
            requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer = new Amazon.BedrockAgentCoreControl.Model.CustomJWTAuthorizerConfiguration();
            List<System.String> requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_customJWTAuthorizer_AllowedAudience = null;
            if (cmdletContext.CustomJWTAuthorizer_AllowedAudience != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_customJWTAuthorizer_AllowedAudience = cmdletContext.CustomJWTAuthorizer_AllowedAudience;
            }
            if (requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_customJWTAuthorizer_AllowedAudience != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer.AllowedAudience = requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_customJWTAuthorizer_AllowedAudience;
                requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizerIsNull = false;
            }
            List<System.String> requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_customJWTAuthorizer_AllowedClient = null;
            if (cmdletContext.CustomJWTAuthorizer_AllowedClient != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_customJWTAuthorizer_AllowedClient = cmdletContext.CustomJWTAuthorizer_AllowedClient;
            }
            if (requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_customJWTAuthorizer_AllowedClient != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer.AllowedClients = requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_customJWTAuthorizer_AllowedClient;
                requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizerIsNull = false;
            }
            List<System.String> requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_customJWTAuthorizer_AllowedScope = null;
            if (cmdletContext.CustomJWTAuthorizer_AllowedScope != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_customJWTAuthorizer_AllowedScope = cmdletContext.CustomJWTAuthorizer_AllowedScope;
            }
            if (requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_customJWTAuthorizer_AllowedScope != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer.AllowedScopes = requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_customJWTAuthorizer_AllowedScope;
                requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizerIsNull = false;
            }
            List<Amazon.BedrockAgentCoreControl.Model.CustomClaimValidationType> requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_customJWTAuthorizer_CustomClaim = null;
            if (cmdletContext.CustomJWTAuthorizer_CustomClaim != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_customJWTAuthorizer_CustomClaim = cmdletContext.CustomJWTAuthorizer_CustomClaim;
            }
            if (requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_customJWTAuthorizer_CustomClaim != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer.CustomClaims = requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_customJWTAuthorizer_CustomClaim;
                requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizerIsNull = false;
            }
            System.String requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_customJWTAuthorizer_DiscoveryUrl = null;
            if (cmdletContext.CustomJWTAuthorizer_DiscoveryUrl != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_customJWTAuthorizer_DiscoveryUrl = cmdletContext.CustomJWTAuthorizer_DiscoveryUrl;
            }
            if (requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_customJWTAuthorizer_DiscoveryUrl != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer.DiscoveryUrl = requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_customJWTAuthorizer_DiscoveryUrl;
                requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizerIsNull = false;
            }
             // determine if requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer should be set to null
            if (requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizerIsNull)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer = null;
            }
            if (requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer != null)
            {
                request.AuthorizerConfiguration.CustomJWTAuthorizer = requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer;
                requestAuthorizerConfigurationIsNull = false;
            }
             // determine if request.AuthorizerConfiguration should be set to null
            if (requestAuthorizerConfigurationIsNull)
            {
                request.AuthorizerConfiguration = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EnvironmentVariable != null)
            {
                request.EnvironmentVariables = cmdletContext.EnvironmentVariable;
            }
            
             // populate LifecycleConfiguration
            var requestLifecycleConfigurationIsNull = true;
            request.LifecycleConfiguration = new Amazon.BedrockAgentCoreControl.Model.LifecycleConfiguration();
            System.Int32? requestLifecycleConfiguration_lifecycleConfiguration_IdleRuntimeSessionTimeout = null;
            if (cmdletContext.LifecycleConfiguration_IdleRuntimeSessionTimeout != null)
            {
                requestLifecycleConfiguration_lifecycleConfiguration_IdleRuntimeSessionTimeout = cmdletContext.LifecycleConfiguration_IdleRuntimeSessionTimeout.Value;
            }
            if (requestLifecycleConfiguration_lifecycleConfiguration_IdleRuntimeSessionTimeout != null)
            {
                request.LifecycleConfiguration.IdleRuntimeSessionTimeout = requestLifecycleConfiguration_lifecycleConfiguration_IdleRuntimeSessionTimeout.Value;
                requestLifecycleConfigurationIsNull = false;
            }
            System.Int32? requestLifecycleConfiguration_lifecycleConfiguration_MaxLifetime = null;
            if (cmdletContext.LifecycleConfiguration_MaxLifetime != null)
            {
                requestLifecycleConfiguration_lifecycleConfiguration_MaxLifetime = cmdletContext.LifecycleConfiguration_MaxLifetime.Value;
            }
            if (requestLifecycleConfiguration_lifecycleConfiguration_MaxLifetime != null)
            {
                request.LifecycleConfiguration.MaxLifetime = requestLifecycleConfiguration_lifecycleConfiguration_MaxLifetime.Value;
                requestLifecycleConfigurationIsNull = false;
            }
             // determine if request.LifecycleConfiguration should be set to null
            if (requestLifecycleConfigurationIsNull)
            {
                request.LifecycleConfiguration = null;
            }
            
             // populate NetworkConfiguration
            var requestNetworkConfigurationIsNull = true;
            request.NetworkConfiguration = new Amazon.BedrockAgentCoreControl.Model.NetworkConfiguration();
            Amazon.BedrockAgentCoreControl.NetworkMode requestNetworkConfiguration_networkConfiguration_NetworkMode = null;
            if (cmdletContext.NetworkConfiguration_NetworkMode != null)
            {
                requestNetworkConfiguration_networkConfiguration_NetworkMode = cmdletContext.NetworkConfiguration_NetworkMode;
            }
            if (requestNetworkConfiguration_networkConfiguration_NetworkMode != null)
            {
                request.NetworkConfiguration.NetworkMode = requestNetworkConfiguration_networkConfiguration_NetworkMode;
                requestNetworkConfigurationIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.VpcConfig requestNetworkConfiguration_networkConfiguration_NetworkModeConfig = null;
            
             // populate NetworkModeConfig
            var requestNetworkConfiguration_networkConfiguration_NetworkModeConfigIsNull = true;
            requestNetworkConfiguration_networkConfiguration_NetworkModeConfig = new Amazon.BedrockAgentCoreControl.Model.VpcConfig();
            List<System.String> requestNetworkConfiguration_networkConfiguration_NetworkModeConfig_networkModeConfig_SecurityGroup = null;
            if (cmdletContext.NetworkModeConfig_SecurityGroup != null)
            {
                requestNetworkConfiguration_networkConfiguration_NetworkModeConfig_networkModeConfig_SecurityGroup = cmdletContext.NetworkModeConfig_SecurityGroup;
            }
            if (requestNetworkConfiguration_networkConfiguration_NetworkModeConfig_networkModeConfig_SecurityGroup != null)
            {
                requestNetworkConfiguration_networkConfiguration_NetworkModeConfig.SecurityGroups = requestNetworkConfiguration_networkConfiguration_NetworkModeConfig_networkModeConfig_SecurityGroup;
                requestNetworkConfiguration_networkConfiguration_NetworkModeConfigIsNull = false;
            }
            List<System.String> requestNetworkConfiguration_networkConfiguration_NetworkModeConfig_networkModeConfig_Subnet = null;
            if (cmdletContext.NetworkModeConfig_Subnet != null)
            {
                requestNetworkConfiguration_networkConfiguration_NetworkModeConfig_networkModeConfig_Subnet = cmdletContext.NetworkModeConfig_Subnet;
            }
            if (requestNetworkConfiguration_networkConfiguration_NetworkModeConfig_networkModeConfig_Subnet != null)
            {
                requestNetworkConfiguration_networkConfiguration_NetworkModeConfig.Subnets = requestNetworkConfiguration_networkConfiguration_NetworkModeConfig_networkModeConfig_Subnet;
                requestNetworkConfiguration_networkConfiguration_NetworkModeConfigIsNull = false;
            }
             // determine if requestNetworkConfiguration_networkConfiguration_NetworkModeConfig should be set to null
            if (requestNetworkConfiguration_networkConfiguration_NetworkModeConfigIsNull)
            {
                requestNetworkConfiguration_networkConfiguration_NetworkModeConfig = null;
            }
            if (requestNetworkConfiguration_networkConfiguration_NetworkModeConfig != null)
            {
                request.NetworkConfiguration.NetworkModeConfig = requestNetworkConfiguration_networkConfiguration_NetworkModeConfig;
                requestNetworkConfigurationIsNull = false;
            }
             // determine if request.NetworkConfiguration should be set to null
            if (requestNetworkConfigurationIsNull)
            {
                request.NetworkConfiguration = null;
            }
            
             // populate ProtocolConfiguration
            var requestProtocolConfigurationIsNull = true;
            request.ProtocolConfiguration = new Amazon.BedrockAgentCoreControl.Model.ProtocolConfiguration();
            Amazon.BedrockAgentCoreControl.ServerProtocol requestProtocolConfiguration_protocolConfiguration_ServerProtocol = null;
            if (cmdletContext.ProtocolConfiguration_ServerProtocol != null)
            {
                requestProtocolConfiguration_protocolConfiguration_ServerProtocol = cmdletContext.ProtocolConfiguration_ServerProtocol;
            }
            if (requestProtocolConfiguration_protocolConfiguration_ServerProtocol != null)
            {
                request.ProtocolConfiguration.ServerProtocol = requestProtocolConfiguration_protocolConfiguration_ServerProtocol;
                requestProtocolConfigurationIsNull = false;
            }
             // determine if request.ProtocolConfiguration should be set to null
            if (requestProtocolConfigurationIsNull)
            {
                request.ProtocolConfiguration = null;
            }
            
             // populate RequestHeaderConfiguration
            var requestRequestHeaderConfigurationIsNull = true;
            request.RequestHeaderConfiguration = new Amazon.BedrockAgentCoreControl.Model.RequestHeaderConfiguration();
            List<System.String> requestRequestHeaderConfiguration_requestHeaderConfiguration_RequestHeaderAllowlist = null;
            if (cmdletContext.RequestHeaderConfiguration_RequestHeaderAllowlist != null)
            {
                requestRequestHeaderConfiguration_requestHeaderConfiguration_RequestHeaderAllowlist = cmdletContext.RequestHeaderConfiguration_RequestHeaderAllowlist;
            }
            if (requestRequestHeaderConfiguration_requestHeaderConfiguration_RequestHeaderAllowlist != null)
            {
                request.RequestHeaderConfiguration.RequestHeaderAllowlist = requestRequestHeaderConfiguration_requestHeaderConfiguration_RequestHeaderAllowlist;
                requestRequestHeaderConfigurationIsNull = false;
            }
             // determine if request.RequestHeaderConfiguration should be set to null
            if (requestRequestHeaderConfigurationIsNull)
            {
                request.RequestHeaderConfiguration = null;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
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
        
        private Amazon.BedrockAgentCoreControl.Model.UpdateAgentRuntimeResponse CallAWSServiceOperation(IAmazonBedrockAgentCoreControl client, Amazon.BedrockAgentCoreControl.Model.UpdateAgentRuntimeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Core Control Plane Fronting Layer", "UpdateAgentRuntime");
            try
            {
                #if DESKTOP
                return client.UpdateAgentRuntime(request);
                #elif CORECLR
                return client.UpdateAgentRuntimeAsync(request).GetAwaiter().GetResult();
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
            public System.String S3_Bucket { get; set; }
            public System.String S3_Prefix { get; set; }
            public System.String S3_VersionId { get; set; }
            public List<System.String> CodeConfiguration_EntryPoint { get; set; }
            public Amazon.BedrockAgentCoreControl.AgentManagedRuntimeType CodeConfiguration_Runtime { get; set; }
            public System.String ContainerConfiguration_ContainerUri { get; set; }
            public System.String AgentRuntimeId { get; set; }
            public List<System.String> CustomJWTAuthorizer_AllowedAudience { get; set; }
            public List<System.String> CustomJWTAuthorizer_AllowedClient { get; set; }
            public List<System.String> CustomJWTAuthorizer_AllowedScope { get; set; }
            public List<Amazon.BedrockAgentCoreControl.Model.CustomClaimValidationType> CustomJWTAuthorizer_CustomClaim { get; set; }
            public System.String CustomJWTAuthorizer_DiscoveryUrl { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public Dictionary<System.String, System.String> EnvironmentVariable { get; set; }
            public System.Int32? LifecycleConfiguration_IdleRuntimeSessionTimeout { get; set; }
            public System.Int32? LifecycleConfiguration_MaxLifetime { get; set; }
            public Amazon.BedrockAgentCoreControl.NetworkMode NetworkConfiguration_NetworkMode { get; set; }
            public List<System.String> NetworkModeConfig_SecurityGroup { get; set; }
            public List<System.String> NetworkModeConfig_Subnet { get; set; }
            public Amazon.BedrockAgentCoreControl.ServerProtocol ProtocolConfiguration_ServerProtocol { get; set; }
            public List<System.String> RequestHeaderConfiguration_RequestHeaderAllowlist { get; set; }
            public System.String RoleArn { get; set; }
            public System.Func<Amazon.BedrockAgentCoreControl.Model.UpdateAgentRuntimeResponse, UpdateBACCAgentRuntimeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
