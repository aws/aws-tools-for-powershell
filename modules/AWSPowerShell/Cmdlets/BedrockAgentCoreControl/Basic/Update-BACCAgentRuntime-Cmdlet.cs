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
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AgentRuntimeId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the agent runtime to update.</para>
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
        /// validation process.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        /// process.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        /// <para>The updated description of the agent runtime.</para>
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
        /// <para>Updated environment variables to set in the agent runtime environment.</para><para />
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
        
        #region Parameter NetworkConfiguration_NetworkMode
        /// <summary>
        /// <para>
        /// <para>The network mode for the agent runtime.</para>
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
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The updated IAM role ARN that provides permissions for the agent runtime.</para>
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
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
            context.ProtocolConfiguration_ServerProtocol = this.ProtocolConfiguration_ServerProtocol;
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
            request.AgentRuntimeArtifact = new Amazon.BedrockAgentCoreControl.Model.AgentArtifact();
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
                return client.UpdateAgentRuntimeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AgentRuntimeId { get; set; }
            public List<System.String> CustomJWTAuthorizer_AllowedAudience { get; set; }
            public List<System.String> CustomJWTAuthorizer_AllowedClient { get; set; }
            public System.String CustomJWTAuthorizer_DiscoveryUrl { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public Dictionary<System.String, System.String> EnvironmentVariable { get; set; }
            public Amazon.BedrockAgentCoreControl.NetworkMode NetworkConfiguration_NetworkMode { get; set; }
            public Amazon.BedrockAgentCoreControl.ServerProtocol ProtocolConfiguration_ServerProtocol { get; set; }
            public System.String RoleArn { get; set; }
            public System.Func<Amazon.BedrockAgentCoreControl.Model.UpdateAgentRuntimeResponse, UpdateBACCAgentRuntimeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
