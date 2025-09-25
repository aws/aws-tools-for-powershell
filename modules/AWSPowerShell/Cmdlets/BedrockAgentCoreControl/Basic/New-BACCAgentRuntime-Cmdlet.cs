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
    /// Creates an Amazon Bedrock AgentCore Runtime.
    /// </summary>
    [Cmdlet("New", "BACCAgentRuntime", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCoreControl.Model.CreateAgentRuntimeResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Core Control Plane Fronting Layer CreateAgentRuntime API operation.", Operation = new[] {"CreateAgentRuntime"}, SelectReturnType = typeof(Amazon.BedrockAgentCoreControl.Model.CreateAgentRuntimeResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCoreControl.Model.CreateAgentRuntimeResponse",
        "This cmdlet returns an Amazon.BedrockAgentCoreControl.Model.CreateAgentRuntimeResponse object containing multiple properties."
    )]
    public partial class NewBACCAgentRuntimeCmdlet : AmazonBedrockAgentCoreControlClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AgentRuntimeName
        /// <summary>
        /// <para>
        /// <para>The name of the AgentCore Runtime.</para>
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
        public System.String AgentRuntimeName { get; set; }
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
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the AgentCore Runtime.</para>
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
        
        #region Parameter EnvironmentVariable
        /// <summary>
        /// <para>
        /// <para>Environment variables to set in the AgentCore Runtime environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnvironmentVariables")]
        public System.Collections.Hashtable EnvironmentVariable { get; set; }
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
        /// <para>The IAM role ARN that provides permissions for the AgentCore Runtime.</para>
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A map of tag keys and values to assign to the agent runtime. Tags enable you to categorize
        /// your resources in different ways, for example, by purpose, owner, or environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCoreControl.Model.CreateAgentRuntimeResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCoreControl.Model.CreateAgentRuntimeResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AgentRuntimeName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BACCAgentRuntime (CreateAgentRuntime)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCoreControl.Model.CreateAgentRuntimeResponse, NewBACCAgentRuntimeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ContainerConfiguration_ContainerUri = this.ContainerConfiguration_ContainerUri;
            context.AgentRuntimeName = this.AgentRuntimeName;
            #if MODULAR
            if (this.AgentRuntimeName == null && ParameterWasBound(nameof(this.AgentRuntimeName)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentRuntimeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.BedrockAgentCoreControl.Model.CreateAgentRuntimeRequest();
            
            
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
             // determine if request.AgentRuntimeArtifact should be set to null
            if (requestAgentRuntimeArtifactIsNull)
            {
                request.AgentRuntimeArtifact = null;
            }
            if (cmdletContext.AgentRuntimeName != null)
            {
                request.AgentRuntimeName = cmdletContext.AgentRuntimeName;
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
        
        private Amazon.BedrockAgentCoreControl.Model.CreateAgentRuntimeResponse CallAWSServiceOperation(IAmazonBedrockAgentCoreControl client, Amazon.BedrockAgentCoreControl.Model.CreateAgentRuntimeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Core Control Plane Fronting Layer", "CreateAgentRuntime");
            try
            {
                #if DESKTOP
                return client.CreateAgentRuntime(request);
                #elif CORECLR
                return client.CreateAgentRuntimeAsync(request).GetAwaiter().GetResult();
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
            public System.String ContainerConfiguration_ContainerUri { get; set; }
            public System.String AgentRuntimeName { get; set; }
            public List<System.String> CustomJWTAuthorizer_AllowedAudience { get; set; }
            public List<System.String> CustomJWTAuthorizer_AllowedClient { get; set; }
            public System.String CustomJWTAuthorizer_DiscoveryUrl { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public Dictionary<System.String, System.String> EnvironmentVariable { get; set; }
            public Amazon.BedrockAgentCoreControl.NetworkMode NetworkConfiguration_NetworkMode { get; set; }
            public List<System.String> NetworkModeConfig_SecurityGroup { get; set; }
            public List<System.String> NetworkModeConfig_Subnet { get; set; }
            public Amazon.BedrockAgentCoreControl.ServerProtocol ProtocolConfiguration_ServerProtocol { get; set; }
            public List<System.String> RequestHeaderConfiguration_RequestHeaderAllowlist { get; set; }
            public System.String RoleArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.BedrockAgentCoreControl.Model.CreateAgentRuntimeResponse, NewBACCAgentRuntimeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
