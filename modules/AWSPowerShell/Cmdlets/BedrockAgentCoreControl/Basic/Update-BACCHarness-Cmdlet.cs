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
using Amazon.BedrockAgentCoreControl;
using Amazon.BedrockAgentCoreControl.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BACC
{
    /// <summary>
    /// Operation to update a Harness.
    /// </summary>
    [Cmdlet("Update", "BACCHarness", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCoreControl.Model.Harness")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Core Control Plane Fronting Layer UpdateHarness API operation.", Operation = new[] {"UpdateHarness"}, SelectReturnType = typeof(Amazon.BedrockAgentCoreControl.Model.UpdateHarnessResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCoreControl.Model.Harness or Amazon.BedrockAgentCoreControl.Model.UpdateHarnessResponse",
        "This cmdlet returns an Amazon.BedrockAgentCoreControl.Model.Harness object.",
        "The service call response (type Amazon.BedrockAgentCoreControl.Model.UpdateHarnessResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateBACCHarnessCmdlet : AmazonBedrockAgentCoreControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Memory_OptionalValue_AgentCoreMemoryConfiguration_ActorId
        /// <summary>
        /// <para>
        /// <para>The actor ID for memory operations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Memory_OptionalValue_AgentCoreMemoryConfiguration_ActorId { get; set; }
        #endregion
        
        #region Parameter AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedAudience
        /// <summary>
        /// <para>
        /// <para>Represents individual audience values that are validated in the incoming JWT token
        /// validation process.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedAudience { get; set; }
        #endregion
        
        #region Parameter AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedClient
        /// <summary>
        /// <para>
        /// <para>Represents individual client IDs that are validated in the incoming JWT token validation
        /// process.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedClients")]
        public System.String[] AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedClient { get; set; }
        #endregion
        
        #region Parameter AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedScope
        /// <summary>
        /// <para>
        /// <para>An array of scopes that are allowed to access the token.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedScopes")]
        public System.String[] AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedScope { get; set; }
        #endregion
        
        #region Parameter AllowedTool
        /// <summary>
        /// <para>
        /// <para>The tools that the agent is allowed to use. If specified, this replaces all existing
        /// allowed tools. If not specified, the existing value is retained.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AllowedTools")]
        public System.String[] AllowedTool { get; set; }
        #endregion
        
        #region Parameter Model_GeminiModelConfig_ApiKeyArn
        /// <summary>
        /// <para>
        /// <para>The ARN of your Gemini API key on AgentCore Identity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Model_GeminiModelConfig_ApiKeyArn { get; set; }
        #endregion
        
        #region Parameter Model_OpenAiModelConfig_ApiKeyArn
        /// <summary>
        /// <para>
        /// <para>The ARN of your OpenAI API key on AgentCore Identity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Model_OpenAiModelConfig_ApiKeyArn { get; set; }
        #endregion
        
        #region Parameter Memory_OptionalValue_AgentCoreMemoryConfiguration_Arn
        /// <summary>
        /// <para>
        /// <para>The ARN of the AgentCore Memory resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Memory_OptionalValue_AgentCoreMemoryConfiguration_Arn { get; set; }
        #endregion
        
        #region Parameter EnvironmentArtifact_OptionalValue_ContainerConfiguration_ContainerUri
        /// <summary>
        /// <para>
        /// <para>The ECR URI of the container.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EnvironmentArtifact_OptionalValue_ContainerConfiguration_ContainerUri { get; set; }
        #endregion
        
        #region Parameter AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_CustomClaim
        /// <summary>
        /// <para>
        /// <para>An array of objects that define a custom claim validation name, value, and operation
        /// </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_CustomClaims")]
        public Amazon.BedrockAgentCoreControl.Model.CustomClaimValidationType[] AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_CustomClaim { get; set; }
        #endregion
        
        #region Parameter AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_DiscoveryUrl
        /// <summary>
        /// <para>
        /// <para>This URL is used to fetch OpenID Connect configuration or authorization server metadata
        /// for validating incoming tokens.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_DiscoveryUrl { get; set; }
        #endregion
        
        #region Parameter AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType
        /// <summary>
        /// <para>
        /// <para>The IP address type for the resource configuration endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.EndpointIpAddressType")]
        public Amazon.BedrockAgentCoreControl.EndpointIpAddressType AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType { get; set; }
        #endregion
        
        #region Parameter EnvironmentVariable
        /// <summary>
        /// <para>
        /// <para>Environment variables to set in the harness runtime environment. If specified, this
        /// replaces all existing environment variables. If not specified, the existing value
        /// is retained.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnvironmentVariables")]
        public System.Collections.Hashtable EnvironmentVariable { get; set; }
        #endregion
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that the harness assumes when running. If not specified, the
        /// existing value is retained.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter Environment_AgentCoreRuntimeEnvironment_FilesystemConfiguration
        /// <summary>
        /// <para>
        /// <para>The filesystem configurations for the runtime environment.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Environment_AgentCoreRuntimeEnvironment_FilesystemConfigurations")]
        public Amazon.BedrockAgentCoreControl.Model.FilesystemConfiguration[] Environment_AgentCoreRuntimeEnvironment_FilesystemConfiguration { get; set; }
        #endregion
        
        #region Parameter HarnessId
        /// <summary>
        /// <para>
        /// <para>The ID of the harness to update.</para>
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
        public System.String HarnessId { get; set; }
        #endregion
        
        #region Parameter Environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration_IdleRuntimeSessionTimeout
        /// <summary>
        /// <para>
        /// <para>Timeout in seconds for idle runtime sessions. When a session remains idle for this
        /// duration, it will be automatically terminated. Default: 900 seconds (15 minutes).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration_IdleRuntimeSessionTimeout { get; set; }
        #endregion
        
        #region Parameter MaxIteration
        /// <summary>
        /// <para>
        /// <para>The maximum number of iterations the agent loop can execute per invocation. If not
        /// specified, the existing value is retained.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxIterations")]
        public System.Int32? MaxIteration { get; set; }
        #endregion
        
        #region Parameter Environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration_MaxLifetime
        /// <summary>
        /// <para>
        /// <para>Maximum lifetime for the instance in seconds. Once reached, instances will be automatically
        /// terminated and replaced. Default: 28800 seconds (8 hours).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration_MaxLifetime { get; set; }
        #endregion
        
        #region Parameter MaxToken
        /// <summary>
        /// <para>
        /// <para>The maximum total number of output tokens the agent can generate across all model
        /// calls within a single invocation. If not specified, the existing value is retained.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxTokens")]
        public System.Int32? MaxToken { get; set; }
        #endregion
        
        #region Parameter Model_BedrockModelConfig_MaxToken
        /// <summary>
        /// <para>
        /// <para>The maximum number of tokens to allow in the generated response per model call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Model_BedrockModelConfig_MaxTokens")]
        public System.Int32? Model_BedrockModelConfig_MaxToken { get; set; }
        #endregion
        
        #region Parameter Model_GeminiModelConfig_MaxToken
        /// <summary>
        /// <para>
        /// <para>The maximum number of tokens to allow in the generated response per model call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Model_GeminiModelConfig_MaxTokens")]
        public System.Int32? Model_GeminiModelConfig_MaxToken { get; set; }
        #endregion
        
        #region Parameter Model_OpenAiModelConfig_MaxToken
        /// <summary>
        /// <para>
        /// <para>The maximum number of tokens to allow in the generated response per model call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Model_OpenAiModelConfig_MaxTokens")]
        public System.Int32? Model_OpenAiModelConfig_MaxToken { get; set; }
        #endregion
        
        #region Parameter Memory_OptionalValue_AgentCoreMemoryConfiguration_MessagesCount
        /// <summary>
        /// <para>
        /// <para>The number of messages to retrieve from memory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Memory_OptionalValue_AgentCoreMemoryConfiguration_MessagesCount { get; set; }
        #endregion
        
        #region Parameter Truncation_Config_SlidingWindow_MessagesCount
        /// <summary>
        /// <para>
        /// <para>The number of recent messages to retain in the context window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Truncation_Config_SlidingWindow_MessagesCount { get; set; }
        #endregion
        
        #region Parameter Model_BedrockModelConfig_ModelId
        /// <summary>
        /// <para>
        /// <para>The Bedrock model ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Model_BedrockModelConfig_ModelId { get; set; }
        #endregion
        
        #region Parameter Model_GeminiModelConfig_ModelId
        /// <summary>
        /// <para>
        /// <para>The Gemini model ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Model_GeminiModelConfig_ModelId { get; set; }
        #endregion
        
        #region Parameter Model_OpenAiModelConfig_ModelId
        /// <summary>
        /// <para>
        /// <para>The OpenAI model ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Model_OpenAiModelConfig_ModelId { get; set; }
        #endregion
        
        #region Parameter Environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkMode
        /// <summary>
        /// <para>
        /// <para>The network mode for the AgentCore Runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.NetworkMode")]
        public Amazon.BedrockAgentCoreControl.NetworkMode Environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkMode { get; set; }
        #endregion
        
        #region Parameter Truncation_Config_Summarization_PreserveRecentMessage
        /// <summary>
        /// <para>
        /// <para>The number of recent messages to preserve without summarization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Truncation_Config_Summarization_PreserveRecentMessages")]
        public System.Int32? Truncation_Config_Summarization_PreserveRecentMessage { get; set; }
        #endregion
        
        #region Parameter AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpointOverride
        /// <summary>
        /// <para>
        /// <para>The private endpoint overrides for the custom JWT authorizer configuration.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpointOverrides")]
        public Amazon.BedrockAgentCoreControl.Model.PrivateEndpointOverride[] AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpointOverride { get; set; }
        #endregion
        
        #region Parameter Environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_RequireServiceS3Endpoint
        /// <summary>
        /// <para>
        /// <para><note><para>This field applies only to Agent Runtimes. It is not applicable to Browsers or Code
        /// Interpreters.</para></note><para>Controls whether a service-managed Amazon S3 gateway endpoint is provisioned in the
        /// VPC network topology for the agent runtime. This gateway is used by Amazon Bedrock
        /// AgentCore Runtime to download code and container images during agent startup.</para><para>Starting May 5, 2026, Amazon Bedrock AgentCore Runtime is gradually rolling out a
        /// change to how network isolation is configured for VPC mode agents. Agent runtimes
        /// created on or after this rollout will no longer include the service-managed Amazon
        /// S3 gateway. Instead, all network access, including to Amazon S3, is governed exclusively
        /// by your VPC configuration. This field cannot be set on agent runtimes created after
        /// the rollout. Passing this field in an <c>UpdateAgentRuntime</c> request for these
        /// agent runtimes returns a <c>ValidationException</c>.</para><para>Agent runtimes created before the rollout are not affected and continue to operate
        /// with the service-managed Amazon S3 gateway. To enforce full VPC network isolation
        /// on these existing agent runtimes, set this field to <c>false</c> via the <c>UpdateAgentRuntime</c>
        /// API. Before opting out, ensure your VPC provides the Amazon S3 access required for
        /// agent startup. If this field is not specified or is set to <c>true</c>, the service-managed
        /// Amazon S3 gateway remains provisioned.</para><para>This field is only supported in the <c>UpdateAgentRuntime</c> API for pre-rollout
        /// agent runtimes. Passing this field in a <c>CreateAgentRuntime</c> request returns
        /// a <c>ValidationException</c>.</para></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_RequireServiceS3Endpoint { get; set; }
        #endregion
        
        #region Parameter AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource_ResourceConfigurationIdentifier
        /// <summary>
        /// <para>
        /// <para>The ARN or ID of the VPC Lattice resource configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource_ResourceConfigurationIdentifier { get; set; }
        #endregion
        
        #region Parameter Memory_OptionalValue_AgentCoreMemoryConfiguration_RetrievalConfig
        /// <summary>
        /// <para>
        /// <para>The retrieval configuration for long-term memory, mapping namespace path templates
        /// to retrieval settings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable Memory_OptionalValue_AgentCoreMemoryConfiguration_RetrievalConfig { get; set; }
        #endregion
        
        #region Parameter AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_RoutingDomain
        /// <summary>
        /// <para>
        /// <para>An intermediate domain to use as the resource configuration endpoint instead of the
        /// actual target domain. Use this when you want to route traffic through an intermediate
        /// component such as a VPC endpoint or internal load balancer. For more information,
        /// see xref:lattice-vpc-egress-routing-domain[Route traffic through an intermediate domain].</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_RoutingDomain { get; set; }
        #endregion
        
        #region Parameter AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The security group IDs to associate with the VPC Lattice resource gateway. If not
        /// specified, the default security group for the VPC is used.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SecurityGroupIds")]
        public System.String[] AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter Environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_SecurityGroup
        /// <summary>
        /// <para>
        /// <para>The security groups associated with the VPC configuration.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_SecurityGroups")]
        public System.String[] Environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_SecurityGroup { get; set; }
        #endregion
        
        #region Parameter Skill
        /// <summary>
        /// <para>
        /// <para>The skills available to the agent. If specified, this replaces all existing skills.
        /// If not specified, the existing value is retained.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Skills")]
        public Amazon.BedrockAgentCoreControl.Model.HarnessSkill[] Skill { get; set; }
        #endregion
        
        #region Parameter Truncation_Strategy
        /// <summary>
        /// <para>
        /// <para>The truncation strategy to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.HarnessTruncationStrategy")]
        public Amazon.BedrockAgentCoreControl.HarnessTruncationStrategy Truncation_Strategy { get; set; }
        #endregion
        
        #region Parameter AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SubnetId
        /// <summary>
        /// <para>
        /// <para>The subnet IDs within the VPC where the VPC Lattice resource gateway is placed.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SubnetIds")]
        public System.String[] AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SubnetId { get; set; }
        #endregion
        
        #region Parameter Environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_Subnet
        /// <summary>
        /// <para>
        /// <para>The subnets associated with the VPC configuration.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_Subnets")]
        public System.String[] Environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_Subnet { get; set; }
        #endregion
        
        #region Parameter Truncation_Config_Summarization_SummarizationSystemPrompt
        /// <summary>
        /// <para>
        /// <para>The system prompt used for generating summaries.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Truncation_Config_Summarization_SummarizationSystemPrompt { get; set; }
        #endregion
        
        #region Parameter Truncation_Config_Summarization_SummaryRatio
        /// <summary>
        /// <para>
        /// <para>The ratio of content to summarize.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? Truncation_Config_Summarization_SummaryRatio { get; set; }
        #endregion
        
        #region Parameter SystemPrompt
        /// <summary>
        /// <para>
        /// <para>The system prompt that defines the agent's behavior. If not specified, the existing
        /// value is retained.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.BedrockAgentCoreControl.Model.HarnessSystemContentBlock[] SystemPrompt { get; set; }
        #endregion
        
        #region Parameter AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_Tag
        /// <summary>
        /// <para>
        /// <para>Tags to apply to the managed VPC Lattice resource gateway.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_Tags")]
        public System.Collections.Hashtable AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_Tag { get; set; }
        #endregion
        
        #region Parameter Model_BedrockModelConfig_Temperature
        /// <summary>
        /// <para>
        /// <para>The temperature to set when calling the model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? Model_BedrockModelConfig_Temperature { get; set; }
        #endregion
        
        #region Parameter Model_GeminiModelConfig_Temperature
        /// <summary>
        /// <para>
        /// <para>The temperature to set when calling the model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? Model_GeminiModelConfig_Temperature { get; set; }
        #endregion
        
        #region Parameter Model_OpenAiModelConfig_Temperature
        /// <summary>
        /// <para>
        /// <para>The temperature to set when calling the model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? Model_OpenAiModelConfig_Temperature { get; set; }
        #endregion
        
        #region Parameter TimeoutSecond
        /// <summary>
        /// <para>
        /// <para>The maximum duration in seconds for the agent loop execution per invocation. If not
        /// specified, the existing value is retained.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TimeoutSeconds")]
        public System.Int32? TimeoutSecond { get; set; }
        #endregion
        
        #region Parameter Tool
        /// <summary>
        /// <para>
        /// <para>The tools available to the agent. If specified, this replaces all existing tools.
        /// If not specified, the existing value is retained.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tools")]
        public Amazon.BedrockAgentCoreControl.Model.HarnessTool[] Tool { get; set; }
        #endregion
        
        #region Parameter Model_GeminiModelConfig_TopK
        /// <summary>
        /// <para>
        /// <para>The topK set when calling the model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Model_GeminiModelConfig_TopK { get; set; }
        #endregion
        
        #region Parameter Model_BedrockModelConfig_TopP
        /// <summary>
        /// <para>
        /// <para>The topP set when calling the model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? Model_BedrockModelConfig_TopP { get; set; }
        #endregion
        
        #region Parameter Model_GeminiModelConfig_TopP
        /// <summary>
        /// <para>
        /// <para>The topP set when calling the model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? Model_GeminiModelConfig_TopP { get; set; }
        #endregion
        
        #region Parameter Model_OpenAiModelConfig_TopP
        /// <summary>
        /// <para>
        /// <para>The topP set when calling the model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? Model_OpenAiModelConfig_TopP { get; set; }
        #endregion
        
        #region Parameter AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_VpcIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the VPC that contains your private resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_VpcIdentifier { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Harness'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCoreControl.Model.UpdateHarnessResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCoreControl.Model.UpdateHarnessResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Harness";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.HarnessId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BACCHarness (UpdateHarness)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCoreControl.Model.UpdateHarnessResponse, UpdateBACCHarnessCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AllowedTool != null)
            {
                context.AllowedTool = new List<System.String>(this.AllowedTool);
            }
            if (this.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedAudience != null)
            {
                context.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedAudience = new List<System.String>(this.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedAudience);
            }
            if (this.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedClient != null)
            {
                context.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedClient = new List<System.String>(this.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedClient);
            }
            if (this.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedScope != null)
            {
                context.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedScope = new List<System.String>(this.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedScope);
            }
            if (this.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_CustomClaim != null)
            {
                context.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_CustomClaim = new List<Amazon.BedrockAgentCoreControl.Model.CustomClaimValidationType>(this.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_CustomClaim);
            }
            context.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_DiscoveryUrl = this.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_DiscoveryUrl;
            context.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType = this.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType;
            context.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_RoutingDomain = this.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_RoutingDomain;
            if (this.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SecurityGroupId != null)
            {
                context.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SecurityGroupId = new List<System.String>(this.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SecurityGroupId);
            }
            if (this.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SubnetId != null)
            {
                context.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SubnetId = new List<System.String>(this.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SubnetId);
            }
            if (this.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_Tag != null)
            {
                context.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_Tag.Keys)
                {
                    context.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_Tag.Add((String)hashKey, (System.String)(this.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_Tag[hashKey]));
                }
            }
            context.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_VpcIdentifier = this.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_VpcIdentifier;
            context.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource_ResourceConfigurationIdentifier = this.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource_ResourceConfigurationIdentifier;
            if (this.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpointOverride != null)
            {
                context.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpointOverride = new List<Amazon.BedrockAgentCoreControl.Model.PrivateEndpointOverride>(this.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpointOverride);
            }
            context.ClientToken = this.ClientToken;
            if (this.Environment_AgentCoreRuntimeEnvironment_FilesystemConfiguration != null)
            {
                context.Environment_AgentCoreRuntimeEnvironment_FilesystemConfiguration = new List<Amazon.BedrockAgentCoreControl.Model.FilesystemConfiguration>(this.Environment_AgentCoreRuntimeEnvironment_FilesystemConfiguration);
            }
            context.Environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration_IdleRuntimeSessionTimeout = this.Environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration_IdleRuntimeSessionTimeout;
            context.Environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration_MaxLifetime = this.Environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration_MaxLifetime;
            context.Environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkMode = this.Environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkMode;
            context.Environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_RequireServiceS3Endpoint = this.Environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_RequireServiceS3Endpoint;
            if (this.Environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_SecurityGroup != null)
            {
                context.Environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_SecurityGroup = new List<System.String>(this.Environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_SecurityGroup);
            }
            if (this.Environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_Subnet != null)
            {
                context.Environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_Subnet = new List<System.String>(this.Environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_Subnet);
            }
            context.EnvironmentArtifact_OptionalValue_ContainerConfiguration_ContainerUri = this.EnvironmentArtifact_OptionalValue_ContainerConfiguration_ContainerUri;
            if (this.EnvironmentVariable != null)
            {
                context.EnvironmentVariable = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.EnvironmentVariable.Keys)
                {
                    context.EnvironmentVariable.Add((String)hashKey, (System.String)(this.EnvironmentVariable[hashKey]));
                }
            }
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            context.HarnessId = this.HarnessId;
            #if MODULAR
            if (this.HarnessId == null && ParameterWasBound(nameof(this.HarnessId)))
            {
                WriteWarning("You are passing $null as a value for parameter HarnessId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxIteration = this.MaxIteration;
            context.MaxToken = this.MaxToken;
            context.Memory_OptionalValue_AgentCoreMemoryConfiguration_ActorId = this.Memory_OptionalValue_AgentCoreMemoryConfiguration_ActorId;
            context.Memory_OptionalValue_AgentCoreMemoryConfiguration_Arn = this.Memory_OptionalValue_AgentCoreMemoryConfiguration_Arn;
            context.Memory_OptionalValue_AgentCoreMemoryConfiguration_MessagesCount = this.Memory_OptionalValue_AgentCoreMemoryConfiguration_MessagesCount;
            if (this.Memory_OptionalValue_AgentCoreMemoryConfiguration_RetrievalConfig != null)
            {
                context.Memory_OptionalValue_AgentCoreMemoryConfiguration_RetrievalConfig = new Dictionary<System.String, Amazon.BedrockAgentCoreControl.Model.HarnessAgentCoreMemoryRetrievalConfig>(StringComparer.Ordinal);
                foreach (var hashKey in this.Memory_OptionalValue_AgentCoreMemoryConfiguration_RetrievalConfig.Keys)
                {
                    context.Memory_OptionalValue_AgentCoreMemoryConfiguration_RetrievalConfig.Add((String)hashKey, (Amazon.BedrockAgentCoreControl.Model.HarnessAgentCoreMemoryRetrievalConfig)(this.Memory_OptionalValue_AgentCoreMemoryConfiguration_RetrievalConfig[hashKey]));
                }
            }
            context.Model_BedrockModelConfig_MaxToken = this.Model_BedrockModelConfig_MaxToken;
            context.Model_BedrockModelConfig_ModelId = this.Model_BedrockModelConfig_ModelId;
            context.Model_BedrockModelConfig_Temperature = this.Model_BedrockModelConfig_Temperature;
            context.Model_BedrockModelConfig_TopP = this.Model_BedrockModelConfig_TopP;
            context.Model_GeminiModelConfig_ApiKeyArn = this.Model_GeminiModelConfig_ApiKeyArn;
            context.Model_GeminiModelConfig_MaxToken = this.Model_GeminiModelConfig_MaxToken;
            context.Model_GeminiModelConfig_ModelId = this.Model_GeminiModelConfig_ModelId;
            context.Model_GeminiModelConfig_Temperature = this.Model_GeminiModelConfig_Temperature;
            context.Model_GeminiModelConfig_TopK = this.Model_GeminiModelConfig_TopK;
            context.Model_GeminiModelConfig_TopP = this.Model_GeminiModelConfig_TopP;
            context.Model_OpenAiModelConfig_ApiKeyArn = this.Model_OpenAiModelConfig_ApiKeyArn;
            context.Model_OpenAiModelConfig_MaxToken = this.Model_OpenAiModelConfig_MaxToken;
            context.Model_OpenAiModelConfig_ModelId = this.Model_OpenAiModelConfig_ModelId;
            context.Model_OpenAiModelConfig_Temperature = this.Model_OpenAiModelConfig_Temperature;
            context.Model_OpenAiModelConfig_TopP = this.Model_OpenAiModelConfig_TopP;
            if (this.Skill != null)
            {
                context.Skill = new List<Amazon.BedrockAgentCoreControl.Model.HarnessSkill>(this.Skill);
            }
            if (this.SystemPrompt != null)
            {
                context.SystemPrompt = new List<Amazon.BedrockAgentCoreControl.Model.HarnessSystemContentBlock>(this.SystemPrompt);
            }
            context.TimeoutSecond = this.TimeoutSecond;
            if (this.Tool != null)
            {
                context.Tool = new List<Amazon.BedrockAgentCoreControl.Model.HarnessTool>(this.Tool);
            }
            context.Truncation_Config_SlidingWindow_MessagesCount = this.Truncation_Config_SlidingWindow_MessagesCount;
            context.Truncation_Config_Summarization_PreserveRecentMessage = this.Truncation_Config_Summarization_PreserveRecentMessage;
            context.Truncation_Config_Summarization_SummarizationSystemPrompt = this.Truncation_Config_Summarization_SummarizationSystemPrompt;
            context.Truncation_Config_Summarization_SummaryRatio = this.Truncation_Config_Summarization_SummaryRatio;
            context.Truncation_Strategy = this.Truncation_Strategy;
            
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
            var request = new Amazon.BedrockAgentCoreControl.Model.UpdateHarnessRequest();
            
            if (cmdletContext.AllowedTool != null)
            {
                request.AllowedTools = cmdletContext.AllowedTool;
            }
            
             // populate AuthorizerConfiguration
            var requestAuthorizerConfigurationIsNull = true;
            request.AuthorizerConfiguration = new Amazon.BedrockAgentCoreControl.Model.UpdatedAuthorizerConfiguration();
            Amazon.BedrockAgentCoreControl.Model.AuthorizerConfiguration requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue = null;
            
             // populate OptionalValue
            var requestAuthorizerConfiguration_authorizerConfiguration_OptionalValueIsNull = true;
            requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue = new Amazon.BedrockAgentCoreControl.Model.AuthorizerConfiguration();
            Amazon.BedrockAgentCoreControl.Model.CustomJWTAuthorizerConfiguration requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer = null;
            
             // populate CustomJWTAuthorizer
            var requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizerIsNull = true;
            requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer = new Amazon.BedrockAgentCoreControl.Model.CustomJWTAuthorizerConfiguration();
            List<System.String> requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedAudience = null;
            if (cmdletContext.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedAudience != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedAudience = cmdletContext.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedAudience;
            }
            if (requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedAudience != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer.AllowedAudience = requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedAudience;
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizerIsNull = false;
            }
            List<System.String> requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedClient = null;
            if (cmdletContext.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedClient != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedClient = cmdletContext.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedClient;
            }
            if (requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedClient != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer.AllowedClients = requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedClient;
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizerIsNull = false;
            }
            List<System.String> requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedScope = null;
            if (cmdletContext.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedScope != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedScope = cmdletContext.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedScope;
            }
            if (requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedScope != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer.AllowedScopes = requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedScope;
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizerIsNull = false;
            }
            List<Amazon.BedrockAgentCoreControl.Model.CustomClaimValidationType> requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_CustomClaim = null;
            if (cmdletContext.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_CustomClaim != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_CustomClaim = cmdletContext.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_CustomClaim;
            }
            if (requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_CustomClaim != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer.CustomClaims = requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_CustomClaim;
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizerIsNull = false;
            }
            System.String requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_DiscoveryUrl = null;
            if (cmdletContext.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_DiscoveryUrl != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_DiscoveryUrl = cmdletContext.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_DiscoveryUrl;
            }
            if (requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_DiscoveryUrl != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer.DiscoveryUrl = requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_DiscoveryUrl;
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizerIsNull = false;
            }
            List<Amazon.BedrockAgentCoreControl.Model.PrivateEndpointOverride> requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpointOverride = null;
            if (cmdletContext.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpointOverride != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpointOverride = cmdletContext.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpointOverride;
            }
            if (requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpointOverride != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer.PrivateEndpointOverrides = requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpointOverride;
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizerIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.PrivateEndpoint requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint = null;
            
             // populate PrivateEndpoint
            var requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpointIsNull = true;
            requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint = new Amazon.BedrockAgentCoreControl.Model.PrivateEndpoint();
            Amazon.BedrockAgentCoreControl.Model.SelfManagedLatticeResource requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource = null;
            
             // populate SelfManagedLatticeResource
            var requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResourceIsNull = true;
            requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource = new Amazon.BedrockAgentCoreControl.Model.SelfManagedLatticeResource();
            System.String requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource_ResourceConfigurationIdentifier = null;
            if (cmdletContext.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource_ResourceConfigurationIdentifier != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource_ResourceConfigurationIdentifier = cmdletContext.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource_ResourceConfigurationIdentifier;
            }
            if (requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource_ResourceConfigurationIdentifier != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource.ResourceConfigurationIdentifier = requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource_ResourceConfigurationIdentifier;
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResourceIsNull = false;
            }
             // determine if requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource should be set to null
            if (requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResourceIsNull)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource = null;
            }
            if (requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint.SelfManagedLatticeResource = requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource;
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpointIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.ManagedVpcResource requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource = null;
            
             // populate ManagedVpcResource
            var requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResourceIsNull = true;
            requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource = new Amazon.BedrockAgentCoreControl.Model.ManagedVpcResource();
            Amazon.BedrockAgentCoreControl.EndpointIpAddressType requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType = null;
            if (cmdletContext.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType = cmdletContext.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType;
            }
            if (requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource.EndpointIpAddressType = requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType;
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResourceIsNull = false;
            }
            System.String requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_RoutingDomain = null;
            if (cmdletContext.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_RoutingDomain != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_RoutingDomain = cmdletContext.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_RoutingDomain;
            }
            if (requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_RoutingDomain != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource.RoutingDomain = requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_RoutingDomain;
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResourceIsNull = false;
            }
            List<System.String> requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SecurityGroupId = null;
            if (cmdletContext.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SecurityGroupId != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SecurityGroupId = cmdletContext.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SecurityGroupId;
            }
            if (requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SecurityGroupId != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource.SecurityGroupIds = requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SecurityGroupId;
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResourceIsNull = false;
            }
            List<System.String> requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SubnetId = null;
            if (cmdletContext.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SubnetId != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SubnetId = cmdletContext.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SubnetId;
            }
            if (requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SubnetId != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource.SubnetIds = requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SubnetId;
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResourceIsNull = false;
            }
            Dictionary<System.String, System.String> requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_Tag = null;
            if (cmdletContext.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_Tag != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_Tag = cmdletContext.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_Tag;
            }
            if (requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_Tag != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource.Tags = requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_Tag;
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResourceIsNull = false;
            }
            System.String requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_VpcIdentifier = null;
            if (cmdletContext.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_VpcIdentifier != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_VpcIdentifier = cmdletContext.AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_VpcIdentifier;
            }
            if (requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_VpcIdentifier != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource.VpcIdentifier = requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_VpcIdentifier;
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResourceIsNull = false;
            }
             // determine if requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource should be set to null
            if (requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResourceIsNull)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource = null;
            }
            if (requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint.ManagedVpcResource = requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource;
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpointIsNull = false;
            }
             // determine if requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint should be set to null
            if (requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpointIsNull)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint = null;
            }
            if (requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer.PrivateEndpoint = requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint;
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizerIsNull = false;
            }
             // determine if requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer should be set to null
            if (requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizerIsNull)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer = null;
            }
            if (requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue.CustomJWTAuthorizer = requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue_authorizerConfiguration_OptionalValue_CustomJWTAuthorizer;
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValueIsNull = false;
            }
             // determine if requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue should be set to null
            if (requestAuthorizerConfiguration_authorizerConfiguration_OptionalValueIsNull)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue = null;
            }
            if (requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue != null)
            {
                request.AuthorizerConfiguration.OptionalValue = requestAuthorizerConfiguration_authorizerConfiguration_OptionalValue;
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
            
             // populate Environment
            var requestEnvironmentIsNull = true;
            request.Environment = new Amazon.BedrockAgentCoreControl.Model.HarnessEnvironmentProviderRequest();
            Amazon.BedrockAgentCoreControl.Model.HarnessAgentCoreRuntimeEnvironmentRequest requestEnvironment_environment_AgentCoreRuntimeEnvironment = null;
            
             // populate AgentCoreRuntimeEnvironment
            var requestEnvironment_environment_AgentCoreRuntimeEnvironmentIsNull = true;
            requestEnvironment_environment_AgentCoreRuntimeEnvironment = new Amazon.BedrockAgentCoreControl.Model.HarnessAgentCoreRuntimeEnvironmentRequest();
            List<Amazon.BedrockAgentCoreControl.Model.FilesystemConfiguration> requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_FilesystemConfiguration = null;
            if (cmdletContext.Environment_AgentCoreRuntimeEnvironment_FilesystemConfiguration != null)
            {
                requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_FilesystemConfiguration = cmdletContext.Environment_AgentCoreRuntimeEnvironment_FilesystemConfiguration;
            }
            if (requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_FilesystemConfiguration != null)
            {
                requestEnvironment_environment_AgentCoreRuntimeEnvironment.FilesystemConfigurations = requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_FilesystemConfiguration;
                requestEnvironment_environment_AgentCoreRuntimeEnvironmentIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.LifecycleConfiguration requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration = null;
            
             // populate LifecycleConfiguration
            var requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_LifecycleConfigurationIsNull = true;
            requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration = new Amazon.BedrockAgentCoreControl.Model.LifecycleConfiguration();
            System.Int32? requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration_environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration_IdleRuntimeSessionTimeout = null;
            if (cmdletContext.Environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration_IdleRuntimeSessionTimeout != null)
            {
                requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration_environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration_IdleRuntimeSessionTimeout = cmdletContext.Environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration_IdleRuntimeSessionTimeout.Value;
            }
            if (requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration_environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration_IdleRuntimeSessionTimeout != null)
            {
                requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration.IdleRuntimeSessionTimeout = requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration_environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration_IdleRuntimeSessionTimeout.Value;
                requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_LifecycleConfigurationIsNull = false;
            }
            System.Int32? requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration_environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration_MaxLifetime = null;
            if (cmdletContext.Environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration_MaxLifetime != null)
            {
                requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration_environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration_MaxLifetime = cmdletContext.Environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration_MaxLifetime.Value;
            }
            if (requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration_environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration_MaxLifetime != null)
            {
                requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration.MaxLifetime = requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration_environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration_MaxLifetime.Value;
                requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_LifecycleConfigurationIsNull = false;
            }
             // determine if requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration should be set to null
            if (requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_LifecycleConfigurationIsNull)
            {
                requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration = null;
            }
            if (requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration != null)
            {
                requestEnvironment_environment_AgentCoreRuntimeEnvironment.LifecycleConfiguration = requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration;
                requestEnvironment_environment_AgentCoreRuntimeEnvironmentIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.NetworkConfiguration requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration = null;
            
             // populate NetworkConfiguration
            var requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfigurationIsNull = true;
            requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration = new Amazon.BedrockAgentCoreControl.Model.NetworkConfiguration();
            Amazon.BedrockAgentCoreControl.NetworkMode requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkMode = null;
            if (cmdletContext.Environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkMode != null)
            {
                requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkMode = cmdletContext.Environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkMode;
            }
            if (requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkMode != null)
            {
                requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration.NetworkMode = requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkMode;
                requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfigurationIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.VpcConfig requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig = null;
            
             // populate NetworkModeConfig
            var requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfigIsNull = true;
            requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig = new Amazon.BedrockAgentCoreControl.Model.VpcConfig();
            System.Boolean? requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_RequireServiceS3Endpoint = null;
            if (cmdletContext.Environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_RequireServiceS3Endpoint != null)
            {
                requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_RequireServiceS3Endpoint = cmdletContext.Environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_RequireServiceS3Endpoint.Value;
            }
            if (requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_RequireServiceS3Endpoint != null)
            {
                requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig.RequireServiceS3Endpoint = requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_RequireServiceS3Endpoint.Value;
                requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfigIsNull = false;
            }
            List<System.String> requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_SecurityGroup = null;
            if (cmdletContext.Environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_SecurityGroup != null)
            {
                requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_SecurityGroup = cmdletContext.Environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_SecurityGroup;
            }
            if (requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_SecurityGroup != null)
            {
                requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig.SecurityGroups = requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_SecurityGroup;
                requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfigIsNull = false;
            }
            List<System.String> requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_Subnet = null;
            if (cmdletContext.Environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_Subnet != null)
            {
                requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_Subnet = cmdletContext.Environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_Subnet;
            }
            if (requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_Subnet != null)
            {
                requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig.Subnets = requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_Subnet;
                requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfigIsNull = false;
            }
             // determine if requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig should be set to null
            if (requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfigIsNull)
            {
                requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig = null;
            }
            if (requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig != null)
            {
                requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration.NetworkModeConfig = requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig;
                requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfigurationIsNull = false;
            }
             // determine if requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration should be set to null
            if (requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfigurationIsNull)
            {
                requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration = null;
            }
            if (requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration != null)
            {
                requestEnvironment_environment_AgentCoreRuntimeEnvironment.NetworkConfiguration = requestEnvironment_environment_AgentCoreRuntimeEnvironment_environment_AgentCoreRuntimeEnvironment_NetworkConfiguration;
                requestEnvironment_environment_AgentCoreRuntimeEnvironmentIsNull = false;
            }
             // determine if requestEnvironment_environment_AgentCoreRuntimeEnvironment should be set to null
            if (requestEnvironment_environment_AgentCoreRuntimeEnvironmentIsNull)
            {
                requestEnvironment_environment_AgentCoreRuntimeEnvironment = null;
            }
            if (requestEnvironment_environment_AgentCoreRuntimeEnvironment != null)
            {
                request.Environment.AgentCoreRuntimeEnvironment = requestEnvironment_environment_AgentCoreRuntimeEnvironment;
                requestEnvironmentIsNull = false;
            }
             // determine if request.Environment should be set to null
            if (requestEnvironmentIsNull)
            {
                request.Environment = null;
            }
            
             // populate EnvironmentArtifact
            var requestEnvironmentArtifactIsNull = true;
            request.EnvironmentArtifact = new Amazon.BedrockAgentCoreControl.Model.UpdatedHarnessEnvironmentArtifact();
            Amazon.BedrockAgentCoreControl.Model.HarnessEnvironmentArtifact requestEnvironmentArtifact_environmentArtifact_OptionalValue = null;
            
             // populate OptionalValue
            var requestEnvironmentArtifact_environmentArtifact_OptionalValueIsNull = true;
            requestEnvironmentArtifact_environmentArtifact_OptionalValue = new Amazon.BedrockAgentCoreControl.Model.HarnessEnvironmentArtifact();
            Amazon.BedrockAgentCoreControl.Model.ContainerConfiguration requestEnvironmentArtifact_environmentArtifact_OptionalValue_environmentArtifact_OptionalValue_ContainerConfiguration = null;
            
             // populate ContainerConfiguration
            var requestEnvironmentArtifact_environmentArtifact_OptionalValue_environmentArtifact_OptionalValue_ContainerConfigurationIsNull = true;
            requestEnvironmentArtifact_environmentArtifact_OptionalValue_environmentArtifact_OptionalValue_ContainerConfiguration = new Amazon.BedrockAgentCoreControl.Model.ContainerConfiguration();
            System.String requestEnvironmentArtifact_environmentArtifact_OptionalValue_environmentArtifact_OptionalValue_ContainerConfiguration_environmentArtifact_OptionalValue_ContainerConfiguration_ContainerUri = null;
            if (cmdletContext.EnvironmentArtifact_OptionalValue_ContainerConfiguration_ContainerUri != null)
            {
                requestEnvironmentArtifact_environmentArtifact_OptionalValue_environmentArtifact_OptionalValue_ContainerConfiguration_environmentArtifact_OptionalValue_ContainerConfiguration_ContainerUri = cmdletContext.EnvironmentArtifact_OptionalValue_ContainerConfiguration_ContainerUri;
            }
            if (requestEnvironmentArtifact_environmentArtifact_OptionalValue_environmentArtifact_OptionalValue_ContainerConfiguration_environmentArtifact_OptionalValue_ContainerConfiguration_ContainerUri != null)
            {
                requestEnvironmentArtifact_environmentArtifact_OptionalValue_environmentArtifact_OptionalValue_ContainerConfiguration.ContainerUri = requestEnvironmentArtifact_environmentArtifact_OptionalValue_environmentArtifact_OptionalValue_ContainerConfiguration_environmentArtifact_OptionalValue_ContainerConfiguration_ContainerUri;
                requestEnvironmentArtifact_environmentArtifact_OptionalValue_environmentArtifact_OptionalValue_ContainerConfigurationIsNull = false;
            }
             // determine if requestEnvironmentArtifact_environmentArtifact_OptionalValue_environmentArtifact_OptionalValue_ContainerConfiguration should be set to null
            if (requestEnvironmentArtifact_environmentArtifact_OptionalValue_environmentArtifact_OptionalValue_ContainerConfigurationIsNull)
            {
                requestEnvironmentArtifact_environmentArtifact_OptionalValue_environmentArtifact_OptionalValue_ContainerConfiguration = null;
            }
            if (requestEnvironmentArtifact_environmentArtifact_OptionalValue_environmentArtifact_OptionalValue_ContainerConfiguration != null)
            {
                requestEnvironmentArtifact_environmentArtifact_OptionalValue.ContainerConfiguration = requestEnvironmentArtifact_environmentArtifact_OptionalValue_environmentArtifact_OptionalValue_ContainerConfiguration;
                requestEnvironmentArtifact_environmentArtifact_OptionalValueIsNull = false;
            }
             // determine if requestEnvironmentArtifact_environmentArtifact_OptionalValue should be set to null
            if (requestEnvironmentArtifact_environmentArtifact_OptionalValueIsNull)
            {
                requestEnvironmentArtifact_environmentArtifact_OptionalValue = null;
            }
            if (requestEnvironmentArtifact_environmentArtifact_OptionalValue != null)
            {
                request.EnvironmentArtifact.OptionalValue = requestEnvironmentArtifact_environmentArtifact_OptionalValue;
                requestEnvironmentArtifactIsNull = false;
            }
             // determine if request.EnvironmentArtifact should be set to null
            if (requestEnvironmentArtifactIsNull)
            {
                request.EnvironmentArtifact = null;
            }
            if (cmdletContext.EnvironmentVariable != null)
            {
                request.EnvironmentVariables = cmdletContext.EnvironmentVariable;
            }
            if (cmdletContext.ExecutionRoleArn != null)
            {
                request.ExecutionRoleArn = cmdletContext.ExecutionRoleArn;
            }
            if (cmdletContext.HarnessId != null)
            {
                request.HarnessId = cmdletContext.HarnessId;
            }
            if (cmdletContext.MaxIteration != null)
            {
                request.MaxIterations = cmdletContext.MaxIteration.Value;
            }
            if (cmdletContext.MaxToken != null)
            {
                request.MaxTokens = cmdletContext.MaxToken.Value;
            }
            
             // populate Memory
            var requestMemoryIsNull = true;
            request.Memory = new Amazon.BedrockAgentCoreControl.Model.UpdatedHarnessMemoryConfiguration();
            Amazon.BedrockAgentCoreControl.Model.HarnessMemoryConfiguration requestMemory_memory_OptionalValue = null;
            
             // populate OptionalValue
            var requestMemory_memory_OptionalValueIsNull = true;
            requestMemory_memory_OptionalValue = new Amazon.BedrockAgentCoreControl.Model.HarnessMemoryConfiguration();
            Amazon.BedrockAgentCoreControl.Model.HarnessAgentCoreMemoryConfiguration requestMemory_memory_OptionalValue_memory_OptionalValue_AgentCoreMemoryConfiguration = null;
            
             // populate AgentCoreMemoryConfiguration
            var requestMemory_memory_OptionalValue_memory_OptionalValue_AgentCoreMemoryConfigurationIsNull = true;
            requestMemory_memory_OptionalValue_memory_OptionalValue_AgentCoreMemoryConfiguration = new Amazon.BedrockAgentCoreControl.Model.HarnessAgentCoreMemoryConfiguration();
            System.String requestMemory_memory_OptionalValue_memory_OptionalValue_AgentCoreMemoryConfiguration_memory_OptionalValue_AgentCoreMemoryConfiguration_ActorId = null;
            if (cmdletContext.Memory_OptionalValue_AgentCoreMemoryConfiguration_ActorId != null)
            {
                requestMemory_memory_OptionalValue_memory_OptionalValue_AgentCoreMemoryConfiguration_memory_OptionalValue_AgentCoreMemoryConfiguration_ActorId = cmdletContext.Memory_OptionalValue_AgentCoreMemoryConfiguration_ActorId;
            }
            if (requestMemory_memory_OptionalValue_memory_OptionalValue_AgentCoreMemoryConfiguration_memory_OptionalValue_AgentCoreMemoryConfiguration_ActorId != null)
            {
                requestMemory_memory_OptionalValue_memory_OptionalValue_AgentCoreMemoryConfiguration.ActorId = requestMemory_memory_OptionalValue_memory_OptionalValue_AgentCoreMemoryConfiguration_memory_OptionalValue_AgentCoreMemoryConfiguration_ActorId;
                requestMemory_memory_OptionalValue_memory_OptionalValue_AgentCoreMemoryConfigurationIsNull = false;
            }
            System.String requestMemory_memory_OptionalValue_memory_OptionalValue_AgentCoreMemoryConfiguration_memory_OptionalValue_AgentCoreMemoryConfiguration_Arn = null;
            if (cmdletContext.Memory_OptionalValue_AgentCoreMemoryConfiguration_Arn != null)
            {
                requestMemory_memory_OptionalValue_memory_OptionalValue_AgentCoreMemoryConfiguration_memory_OptionalValue_AgentCoreMemoryConfiguration_Arn = cmdletContext.Memory_OptionalValue_AgentCoreMemoryConfiguration_Arn;
            }
            if (requestMemory_memory_OptionalValue_memory_OptionalValue_AgentCoreMemoryConfiguration_memory_OptionalValue_AgentCoreMemoryConfiguration_Arn != null)
            {
                requestMemory_memory_OptionalValue_memory_OptionalValue_AgentCoreMemoryConfiguration.Arn = requestMemory_memory_OptionalValue_memory_OptionalValue_AgentCoreMemoryConfiguration_memory_OptionalValue_AgentCoreMemoryConfiguration_Arn;
                requestMemory_memory_OptionalValue_memory_OptionalValue_AgentCoreMemoryConfigurationIsNull = false;
            }
            System.Int32? requestMemory_memory_OptionalValue_memory_OptionalValue_AgentCoreMemoryConfiguration_memory_OptionalValue_AgentCoreMemoryConfiguration_MessagesCount = null;
            if (cmdletContext.Memory_OptionalValue_AgentCoreMemoryConfiguration_MessagesCount != null)
            {
                requestMemory_memory_OptionalValue_memory_OptionalValue_AgentCoreMemoryConfiguration_memory_OptionalValue_AgentCoreMemoryConfiguration_MessagesCount = cmdletContext.Memory_OptionalValue_AgentCoreMemoryConfiguration_MessagesCount.Value;
            }
            if (requestMemory_memory_OptionalValue_memory_OptionalValue_AgentCoreMemoryConfiguration_memory_OptionalValue_AgentCoreMemoryConfiguration_MessagesCount != null)
            {
                requestMemory_memory_OptionalValue_memory_OptionalValue_AgentCoreMemoryConfiguration.MessagesCount = requestMemory_memory_OptionalValue_memory_OptionalValue_AgentCoreMemoryConfiguration_memory_OptionalValue_AgentCoreMemoryConfiguration_MessagesCount.Value;
                requestMemory_memory_OptionalValue_memory_OptionalValue_AgentCoreMemoryConfigurationIsNull = false;
            }
            Dictionary<System.String, Amazon.BedrockAgentCoreControl.Model.HarnessAgentCoreMemoryRetrievalConfig> requestMemory_memory_OptionalValue_memory_OptionalValue_AgentCoreMemoryConfiguration_memory_OptionalValue_AgentCoreMemoryConfiguration_RetrievalConfig = null;
            if (cmdletContext.Memory_OptionalValue_AgentCoreMemoryConfiguration_RetrievalConfig != null)
            {
                requestMemory_memory_OptionalValue_memory_OptionalValue_AgentCoreMemoryConfiguration_memory_OptionalValue_AgentCoreMemoryConfiguration_RetrievalConfig = cmdletContext.Memory_OptionalValue_AgentCoreMemoryConfiguration_RetrievalConfig;
            }
            if (requestMemory_memory_OptionalValue_memory_OptionalValue_AgentCoreMemoryConfiguration_memory_OptionalValue_AgentCoreMemoryConfiguration_RetrievalConfig != null)
            {
                requestMemory_memory_OptionalValue_memory_OptionalValue_AgentCoreMemoryConfiguration.RetrievalConfig = requestMemory_memory_OptionalValue_memory_OptionalValue_AgentCoreMemoryConfiguration_memory_OptionalValue_AgentCoreMemoryConfiguration_RetrievalConfig;
                requestMemory_memory_OptionalValue_memory_OptionalValue_AgentCoreMemoryConfigurationIsNull = false;
            }
             // determine if requestMemory_memory_OptionalValue_memory_OptionalValue_AgentCoreMemoryConfiguration should be set to null
            if (requestMemory_memory_OptionalValue_memory_OptionalValue_AgentCoreMemoryConfigurationIsNull)
            {
                requestMemory_memory_OptionalValue_memory_OptionalValue_AgentCoreMemoryConfiguration = null;
            }
            if (requestMemory_memory_OptionalValue_memory_OptionalValue_AgentCoreMemoryConfiguration != null)
            {
                requestMemory_memory_OptionalValue.AgentCoreMemoryConfiguration = requestMemory_memory_OptionalValue_memory_OptionalValue_AgentCoreMemoryConfiguration;
                requestMemory_memory_OptionalValueIsNull = false;
            }
             // determine if requestMemory_memory_OptionalValue should be set to null
            if (requestMemory_memory_OptionalValueIsNull)
            {
                requestMemory_memory_OptionalValue = null;
            }
            if (requestMemory_memory_OptionalValue != null)
            {
                request.Memory.OptionalValue = requestMemory_memory_OptionalValue;
                requestMemoryIsNull = false;
            }
             // determine if request.Memory should be set to null
            if (requestMemoryIsNull)
            {
                request.Memory = null;
            }
            
             // populate Model
            var requestModelIsNull = true;
            request.Model = new Amazon.BedrockAgentCoreControl.Model.HarnessModelConfiguration();
            Amazon.BedrockAgentCoreControl.Model.HarnessBedrockModelConfig requestModel_model_BedrockModelConfig = null;
            
             // populate BedrockModelConfig
            var requestModel_model_BedrockModelConfigIsNull = true;
            requestModel_model_BedrockModelConfig = new Amazon.BedrockAgentCoreControl.Model.HarnessBedrockModelConfig();
            System.Int32? requestModel_model_BedrockModelConfig_model_BedrockModelConfig_MaxToken = null;
            if (cmdletContext.Model_BedrockModelConfig_MaxToken != null)
            {
                requestModel_model_BedrockModelConfig_model_BedrockModelConfig_MaxToken = cmdletContext.Model_BedrockModelConfig_MaxToken.Value;
            }
            if (requestModel_model_BedrockModelConfig_model_BedrockModelConfig_MaxToken != null)
            {
                requestModel_model_BedrockModelConfig.MaxTokens = requestModel_model_BedrockModelConfig_model_BedrockModelConfig_MaxToken.Value;
                requestModel_model_BedrockModelConfigIsNull = false;
            }
            System.String requestModel_model_BedrockModelConfig_model_BedrockModelConfig_ModelId = null;
            if (cmdletContext.Model_BedrockModelConfig_ModelId != null)
            {
                requestModel_model_BedrockModelConfig_model_BedrockModelConfig_ModelId = cmdletContext.Model_BedrockModelConfig_ModelId;
            }
            if (requestModel_model_BedrockModelConfig_model_BedrockModelConfig_ModelId != null)
            {
                requestModel_model_BedrockModelConfig.ModelId = requestModel_model_BedrockModelConfig_model_BedrockModelConfig_ModelId;
                requestModel_model_BedrockModelConfigIsNull = false;
            }
            System.Single? requestModel_model_BedrockModelConfig_model_BedrockModelConfig_Temperature = null;
            if (cmdletContext.Model_BedrockModelConfig_Temperature != null)
            {
                requestModel_model_BedrockModelConfig_model_BedrockModelConfig_Temperature = cmdletContext.Model_BedrockModelConfig_Temperature.Value;
            }
            if (requestModel_model_BedrockModelConfig_model_BedrockModelConfig_Temperature != null)
            {
                requestModel_model_BedrockModelConfig.Temperature = requestModel_model_BedrockModelConfig_model_BedrockModelConfig_Temperature.Value;
                requestModel_model_BedrockModelConfigIsNull = false;
            }
            System.Single? requestModel_model_BedrockModelConfig_model_BedrockModelConfig_TopP = null;
            if (cmdletContext.Model_BedrockModelConfig_TopP != null)
            {
                requestModel_model_BedrockModelConfig_model_BedrockModelConfig_TopP = cmdletContext.Model_BedrockModelConfig_TopP.Value;
            }
            if (requestModel_model_BedrockModelConfig_model_BedrockModelConfig_TopP != null)
            {
                requestModel_model_BedrockModelConfig.TopP = requestModel_model_BedrockModelConfig_model_BedrockModelConfig_TopP.Value;
                requestModel_model_BedrockModelConfigIsNull = false;
            }
             // determine if requestModel_model_BedrockModelConfig should be set to null
            if (requestModel_model_BedrockModelConfigIsNull)
            {
                requestModel_model_BedrockModelConfig = null;
            }
            if (requestModel_model_BedrockModelConfig != null)
            {
                request.Model.BedrockModelConfig = requestModel_model_BedrockModelConfig;
                requestModelIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.HarnessOpenAiModelConfig requestModel_model_OpenAiModelConfig = null;
            
             // populate OpenAiModelConfig
            var requestModel_model_OpenAiModelConfigIsNull = true;
            requestModel_model_OpenAiModelConfig = new Amazon.BedrockAgentCoreControl.Model.HarnessOpenAiModelConfig();
            System.String requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_ApiKeyArn = null;
            if (cmdletContext.Model_OpenAiModelConfig_ApiKeyArn != null)
            {
                requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_ApiKeyArn = cmdletContext.Model_OpenAiModelConfig_ApiKeyArn;
            }
            if (requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_ApiKeyArn != null)
            {
                requestModel_model_OpenAiModelConfig.ApiKeyArn = requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_ApiKeyArn;
                requestModel_model_OpenAiModelConfigIsNull = false;
            }
            System.Int32? requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_MaxToken = null;
            if (cmdletContext.Model_OpenAiModelConfig_MaxToken != null)
            {
                requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_MaxToken = cmdletContext.Model_OpenAiModelConfig_MaxToken.Value;
            }
            if (requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_MaxToken != null)
            {
                requestModel_model_OpenAiModelConfig.MaxTokens = requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_MaxToken.Value;
                requestModel_model_OpenAiModelConfigIsNull = false;
            }
            System.String requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_ModelId = null;
            if (cmdletContext.Model_OpenAiModelConfig_ModelId != null)
            {
                requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_ModelId = cmdletContext.Model_OpenAiModelConfig_ModelId;
            }
            if (requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_ModelId != null)
            {
                requestModel_model_OpenAiModelConfig.ModelId = requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_ModelId;
                requestModel_model_OpenAiModelConfigIsNull = false;
            }
            System.Single? requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_Temperature = null;
            if (cmdletContext.Model_OpenAiModelConfig_Temperature != null)
            {
                requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_Temperature = cmdletContext.Model_OpenAiModelConfig_Temperature.Value;
            }
            if (requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_Temperature != null)
            {
                requestModel_model_OpenAiModelConfig.Temperature = requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_Temperature.Value;
                requestModel_model_OpenAiModelConfigIsNull = false;
            }
            System.Single? requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_TopP = null;
            if (cmdletContext.Model_OpenAiModelConfig_TopP != null)
            {
                requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_TopP = cmdletContext.Model_OpenAiModelConfig_TopP.Value;
            }
            if (requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_TopP != null)
            {
                requestModel_model_OpenAiModelConfig.TopP = requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_TopP.Value;
                requestModel_model_OpenAiModelConfigIsNull = false;
            }
             // determine if requestModel_model_OpenAiModelConfig should be set to null
            if (requestModel_model_OpenAiModelConfigIsNull)
            {
                requestModel_model_OpenAiModelConfig = null;
            }
            if (requestModel_model_OpenAiModelConfig != null)
            {
                request.Model.OpenAiModelConfig = requestModel_model_OpenAiModelConfig;
                requestModelIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.HarnessGeminiModelConfig requestModel_model_GeminiModelConfig = null;
            
             // populate GeminiModelConfig
            var requestModel_model_GeminiModelConfigIsNull = true;
            requestModel_model_GeminiModelConfig = new Amazon.BedrockAgentCoreControl.Model.HarnessGeminiModelConfig();
            System.String requestModel_model_GeminiModelConfig_model_GeminiModelConfig_ApiKeyArn = null;
            if (cmdletContext.Model_GeminiModelConfig_ApiKeyArn != null)
            {
                requestModel_model_GeminiModelConfig_model_GeminiModelConfig_ApiKeyArn = cmdletContext.Model_GeminiModelConfig_ApiKeyArn;
            }
            if (requestModel_model_GeminiModelConfig_model_GeminiModelConfig_ApiKeyArn != null)
            {
                requestModel_model_GeminiModelConfig.ApiKeyArn = requestModel_model_GeminiModelConfig_model_GeminiModelConfig_ApiKeyArn;
                requestModel_model_GeminiModelConfigIsNull = false;
            }
            System.Int32? requestModel_model_GeminiModelConfig_model_GeminiModelConfig_MaxToken = null;
            if (cmdletContext.Model_GeminiModelConfig_MaxToken != null)
            {
                requestModel_model_GeminiModelConfig_model_GeminiModelConfig_MaxToken = cmdletContext.Model_GeminiModelConfig_MaxToken.Value;
            }
            if (requestModel_model_GeminiModelConfig_model_GeminiModelConfig_MaxToken != null)
            {
                requestModel_model_GeminiModelConfig.MaxTokens = requestModel_model_GeminiModelConfig_model_GeminiModelConfig_MaxToken.Value;
                requestModel_model_GeminiModelConfigIsNull = false;
            }
            System.String requestModel_model_GeminiModelConfig_model_GeminiModelConfig_ModelId = null;
            if (cmdletContext.Model_GeminiModelConfig_ModelId != null)
            {
                requestModel_model_GeminiModelConfig_model_GeminiModelConfig_ModelId = cmdletContext.Model_GeminiModelConfig_ModelId;
            }
            if (requestModel_model_GeminiModelConfig_model_GeminiModelConfig_ModelId != null)
            {
                requestModel_model_GeminiModelConfig.ModelId = requestModel_model_GeminiModelConfig_model_GeminiModelConfig_ModelId;
                requestModel_model_GeminiModelConfigIsNull = false;
            }
            System.Single? requestModel_model_GeminiModelConfig_model_GeminiModelConfig_Temperature = null;
            if (cmdletContext.Model_GeminiModelConfig_Temperature != null)
            {
                requestModel_model_GeminiModelConfig_model_GeminiModelConfig_Temperature = cmdletContext.Model_GeminiModelConfig_Temperature.Value;
            }
            if (requestModel_model_GeminiModelConfig_model_GeminiModelConfig_Temperature != null)
            {
                requestModel_model_GeminiModelConfig.Temperature = requestModel_model_GeminiModelConfig_model_GeminiModelConfig_Temperature.Value;
                requestModel_model_GeminiModelConfigIsNull = false;
            }
            System.Int32? requestModel_model_GeminiModelConfig_model_GeminiModelConfig_TopK = null;
            if (cmdletContext.Model_GeminiModelConfig_TopK != null)
            {
                requestModel_model_GeminiModelConfig_model_GeminiModelConfig_TopK = cmdletContext.Model_GeminiModelConfig_TopK.Value;
            }
            if (requestModel_model_GeminiModelConfig_model_GeminiModelConfig_TopK != null)
            {
                requestModel_model_GeminiModelConfig.TopK = requestModel_model_GeminiModelConfig_model_GeminiModelConfig_TopK.Value;
                requestModel_model_GeminiModelConfigIsNull = false;
            }
            System.Single? requestModel_model_GeminiModelConfig_model_GeminiModelConfig_TopP = null;
            if (cmdletContext.Model_GeminiModelConfig_TopP != null)
            {
                requestModel_model_GeminiModelConfig_model_GeminiModelConfig_TopP = cmdletContext.Model_GeminiModelConfig_TopP.Value;
            }
            if (requestModel_model_GeminiModelConfig_model_GeminiModelConfig_TopP != null)
            {
                requestModel_model_GeminiModelConfig.TopP = requestModel_model_GeminiModelConfig_model_GeminiModelConfig_TopP.Value;
                requestModel_model_GeminiModelConfigIsNull = false;
            }
             // determine if requestModel_model_GeminiModelConfig should be set to null
            if (requestModel_model_GeminiModelConfigIsNull)
            {
                requestModel_model_GeminiModelConfig = null;
            }
            if (requestModel_model_GeminiModelConfig != null)
            {
                request.Model.GeminiModelConfig = requestModel_model_GeminiModelConfig;
                requestModelIsNull = false;
            }
             // determine if request.Model should be set to null
            if (requestModelIsNull)
            {
                request.Model = null;
            }
            if (cmdletContext.Skill != null)
            {
                request.Skills = cmdletContext.Skill;
            }
            if (cmdletContext.SystemPrompt != null)
            {
                request.SystemPrompt = cmdletContext.SystemPrompt;
            }
            if (cmdletContext.TimeoutSecond != null)
            {
                request.TimeoutSeconds = cmdletContext.TimeoutSecond.Value;
            }
            if (cmdletContext.Tool != null)
            {
                request.Tools = cmdletContext.Tool;
            }
            
             // populate Truncation
            var requestTruncationIsNull = true;
            request.Truncation = new Amazon.BedrockAgentCoreControl.Model.HarnessTruncationConfiguration();
            Amazon.BedrockAgentCoreControl.HarnessTruncationStrategy requestTruncation_truncation_Strategy = null;
            if (cmdletContext.Truncation_Strategy != null)
            {
                requestTruncation_truncation_Strategy = cmdletContext.Truncation_Strategy;
            }
            if (requestTruncation_truncation_Strategy != null)
            {
                request.Truncation.Strategy = requestTruncation_truncation_Strategy;
                requestTruncationIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.HarnessTruncationStrategyConfiguration requestTruncation_truncation_Config = null;
            
             // populate Config
            var requestTruncation_truncation_ConfigIsNull = true;
            requestTruncation_truncation_Config = new Amazon.BedrockAgentCoreControl.Model.HarnessTruncationStrategyConfiguration();
            Amazon.BedrockAgentCoreControl.Model.HarnessSlidingWindowConfiguration requestTruncation_truncation_Config_truncation_Config_SlidingWindow = null;
            
             // populate SlidingWindow
            var requestTruncation_truncation_Config_truncation_Config_SlidingWindowIsNull = true;
            requestTruncation_truncation_Config_truncation_Config_SlidingWindow = new Amazon.BedrockAgentCoreControl.Model.HarnessSlidingWindowConfiguration();
            System.Int32? requestTruncation_truncation_Config_truncation_Config_SlidingWindow_truncation_Config_SlidingWindow_MessagesCount = null;
            if (cmdletContext.Truncation_Config_SlidingWindow_MessagesCount != null)
            {
                requestTruncation_truncation_Config_truncation_Config_SlidingWindow_truncation_Config_SlidingWindow_MessagesCount = cmdletContext.Truncation_Config_SlidingWindow_MessagesCount.Value;
            }
            if (requestTruncation_truncation_Config_truncation_Config_SlidingWindow_truncation_Config_SlidingWindow_MessagesCount != null)
            {
                requestTruncation_truncation_Config_truncation_Config_SlidingWindow.MessagesCount = requestTruncation_truncation_Config_truncation_Config_SlidingWindow_truncation_Config_SlidingWindow_MessagesCount.Value;
                requestTruncation_truncation_Config_truncation_Config_SlidingWindowIsNull = false;
            }
             // determine if requestTruncation_truncation_Config_truncation_Config_SlidingWindow should be set to null
            if (requestTruncation_truncation_Config_truncation_Config_SlidingWindowIsNull)
            {
                requestTruncation_truncation_Config_truncation_Config_SlidingWindow = null;
            }
            if (requestTruncation_truncation_Config_truncation_Config_SlidingWindow != null)
            {
                requestTruncation_truncation_Config.SlidingWindow = requestTruncation_truncation_Config_truncation_Config_SlidingWindow;
                requestTruncation_truncation_ConfigIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.HarnessSummarizationConfiguration requestTruncation_truncation_Config_truncation_Config_Summarization = null;
            
             // populate Summarization
            var requestTruncation_truncation_Config_truncation_Config_SummarizationIsNull = true;
            requestTruncation_truncation_Config_truncation_Config_Summarization = new Amazon.BedrockAgentCoreControl.Model.HarnessSummarizationConfiguration();
            System.Int32? requestTruncation_truncation_Config_truncation_Config_Summarization_truncation_Config_Summarization_PreserveRecentMessage = null;
            if (cmdletContext.Truncation_Config_Summarization_PreserveRecentMessage != null)
            {
                requestTruncation_truncation_Config_truncation_Config_Summarization_truncation_Config_Summarization_PreserveRecentMessage = cmdletContext.Truncation_Config_Summarization_PreserveRecentMessage.Value;
            }
            if (requestTruncation_truncation_Config_truncation_Config_Summarization_truncation_Config_Summarization_PreserveRecentMessage != null)
            {
                requestTruncation_truncation_Config_truncation_Config_Summarization.PreserveRecentMessages = requestTruncation_truncation_Config_truncation_Config_Summarization_truncation_Config_Summarization_PreserveRecentMessage.Value;
                requestTruncation_truncation_Config_truncation_Config_SummarizationIsNull = false;
            }
            System.String requestTruncation_truncation_Config_truncation_Config_Summarization_truncation_Config_Summarization_SummarizationSystemPrompt = null;
            if (cmdletContext.Truncation_Config_Summarization_SummarizationSystemPrompt != null)
            {
                requestTruncation_truncation_Config_truncation_Config_Summarization_truncation_Config_Summarization_SummarizationSystemPrompt = cmdletContext.Truncation_Config_Summarization_SummarizationSystemPrompt;
            }
            if (requestTruncation_truncation_Config_truncation_Config_Summarization_truncation_Config_Summarization_SummarizationSystemPrompt != null)
            {
                requestTruncation_truncation_Config_truncation_Config_Summarization.SummarizationSystemPrompt = requestTruncation_truncation_Config_truncation_Config_Summarization_truncation_Config_Summarization_SummarizationSystemPrompt;
                requestTruncation_truncation_Config_truncation_Config_SummarizationIsNull = false;
            }
            System.Single? requestTruncation_truncation_Config_truncation_Config_Summarization_truncation_Config_Summarization_SummaryRatio = null;
            if (cmdletContext.Truncation_Config_Summarization_SummaryRatio != null)
            {
                requestTruncation_truncation_Config_truncation_Config_Summarization_truncation_Config_Summarization_SummaryRatio = cmdletContext.Truncation_Config_Summarization_SummaryRatio.Value;
            }
            if (requestTruncation_truncation_Config_truncation_Config_Summarization_truncation_Config_Summarization_SummaryRatio != null)
            {
                requestTruncation_truncation_Config_truncation_Config_Summarization.SummaryRatio = requestTruncation_truncation_Config_truncation_Config_Summarization_truncation_Config_Summarization_SummaryRatio.Value;
                requestTruncation_truncation_Config_truncation_Config_SummarizationIsNull = false;
            }
             // determine if requestTruncation_truncation_Config_truncation_Config_Summarization should be set to null
            if (requestTruncation_truncation_Config_truncation_Config_SummarizationIsNull)
            {
                requestTruncation_truncation_Config_truncation_Config_Summarization = null;
            }
            if (requestTruncation_truncation_Config_truncation_Config_Summarization != null)
            {
                requestTruncation_truncation_Config.Summarization = requestTruncation_truncation_Config_truncation_Config_Summarization;
                requestTruncation_truncation_ConfigIsNull = false;
            }
             // determine if requestTruncation_truncation_Config should be set to null
            if (requestTruncation_truncation_ConfigIsNull)
            {
                requestTruncation_truncation_Config = null;
            }
            if (requestTruncation_truncation_Config != null)
            {
                request.Truncation.Config = requestTruncation_truncation_Config;
                requestTruncationIsNull = false;
            }
             // determine if request.Truncation should be set to null
            if (requestTruncationIsNull)
            {
                request.Truncation = null;
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
        
        private Amazon.BedrockAgentCoreControl.Model.UpdateHarnessResponse CallAWSServiceOperation(IAmazonBedrockAgentCoreControl client, Amazon.BedrockAgentCoreControl.Model.UpdateHarnessRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Core Control Plane Fronting Layer", "UpdateHarness");
            try
            {
                return client.UpdateHarnessAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> AllowedTool { get; set; }
            public List<System.String> AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedAudience { get; set; }
            public List<System.String> AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedClient { get; set; }
            public List<System.String> AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedScope { get; set; }
            public List<Amazon.BedrockAgentCoreControl.Model.CustomClaimValidationType> AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_CustomClaim { get; set; }
            public System.String AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_DiscoveryUrl { get; set; }
            public Amazon.BedrockAgentCoreControl.EndpointIpAddressType AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType { get; set; }
            public System.String AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_RoutingDomain { get; set; }
            public List<System.String> AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SecurityGroupId { get; set; }
            public List<System.String> AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SubnetId { get; set; }
            public Dictionary<System.String, System.String> AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_Tag { get; set; }
            public System.String AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_VpcIdentifier { get; set; }
            public System.String AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource_ResourceConfigurationIdentifier { get; set; }
            public List<Amazon.BedrockAgentCoreControl.Model.PrivateEndpointOverride> AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpointOverride { get; set; }
            public System.String ClientToken { get; set; }
            public List<Amazon.BedrockAgentCoreControl.Model.FilesystemConfiguration> Environment_AgentCoreRuntimeEnvironment_FilesystemConfiguration { get; set; }
            public System.Int32? Environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration_IdleRuntimeSessionTimeout { get; set; }
            public System.Int32? Environment_AgentCoreRuntimeEnvironment_LifecycleConfiguration_MaxLifetime { get; set; }
            public Amazon.BedrockAgentCoreControl.NetworkMode Environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkMode { get; set; }
            public System.Boolean? Environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_RequireServiceS3Endpoint { get; set; }
            public List<System.String> Environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_SecurityGroup { get; set; }
            public List<System.String> Environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkModeConfig_Subnet { get; set; }
            public System.String EnvironmentArtifact_OptionalValue_ContainerConfiguration_ContainerUri { get; set; }
            public Dictionary<System.String, System.String> EnvironmentVariable { get; set; }
            public System.String ExecutionRoleArn { get; set; }
            public System.String HarnessId { get; set; }
            public System.Int32? MaxIteration { get; set; }
            public System.Int32? MaxToken { get; set; }
            public System.String Memory_OptionalValue_AgentCoreMemoryConfiguration_ActorId { get; set; }
            public System.String Memory_OptionalValue_AgentCoreMemoryConfiguration_Arn { get; set; }
            public System.Int32? Memory_OptionalValue_AgentCoreMemoryConfiguration_MessagesCount { get; set; }
            public Dictionary<System.String, Amazon.BedrockAgentCoreControl.Model.HarnessAgentCoreMemoryRetrievalConfig> Memory_OptionalValue_AgentCoreMemoryConfiguration_RetrievalConfig { get; set; }
            public System.Int32? Model_BedrockModelConfig_MaxToken { get; set; }
            public System.String Model_BedrockModelConfig_ModelId { get; set; }
            public System.Single? Model_BedrockModelConfig_Temperature { get; set; }
            public System.Single? Model_BedrockModelConfig_TopP { get; set; }
            public System.String Model_GeminiModelConfig_ApiKeyArn { get; set; }
            public System.Int32? Model_GeminiModelConfig_MaxToken { get; set; }
            public System.String Model_GeminiModelConfig_ModelId { get; set; }
            public System.Single? Model_GeminiModelConfig_Temperature { get; set; }
            public System.Int32? Model_GeminiModelConfig_TopK { get; set; }
            public System.Single? Model_GeminiModelConfig_TopP { get; set; }
            public System.String Model_OpenAiModelConfig_ApiKeyArn { get; set; }
            public System.Int32? Model_OpenAiModelConfig_MaxToken { get; set; }
            public System.String Model_OpenAiModelConfig_ModelId { get; set; }
            public System.Single? Model_OpenAiModelConfig_Temperature { get; set; }
            public System.Single? Model_OpenAiModelConfig_TopP { get; set; }
            public List<Amazon.BedrockAgentCoreControl.Model.HarnessSkill> Skill { get; set; }
            public List<Amazon.BedrockAgentCoreControl.Model.HarnessSystemContentBlock> SystemPrompt { get; set; }
            public System.Int32? TimeoutSecond { get; set; }
            public List<Amazon.BedrockAgentCoreControl.Model.HarnessTool> Tool { get; set; }
            public System.Int32? Truncation_Config_SlidingWindow_MessagesCount { get; set; }
            public System.Int32? Truncation_Config_Summarization_PreserveRecentMessage { get; set; }
            public System.String Truncation_Config_Summarization_SummarizationSystemPrompt { get; set; }
            public System.Single? Truncation_Config_Summarization_SummaryRatio { get; set; }
            public Amazon.BedrockAgentCoreControl.HarnessTruncationStrategy Truncation_Strategy { get; set; }
            public System.Func<Amazon.BedrockAgentCoreControl.Model.UpdateHarnessResponse, UpdateBACCHarnessCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Harness;
        }
        
    }
}
