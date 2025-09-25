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
    /// Creates a gateway for Amazon Bedrock Agent. A gateway serves as an integration point
    /// between your agent and external services.
    /// 
    ///  
    /// <para>
    /// To create a gateway, you must specify a name, protocol type, and IAM role. The role
    /// grants the gateway permission to access Amazon Web Services services and resources.
    /// </para>
    /// </summary>
    [Cmdlet("New", "BACCGateway", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCoreControl.Model.CreateGatewayResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Core Control Plane Fronting Layer CreateGateway API operation.", Operation = new[] {"CreateGateway"}, SelectReturnType = typeof(Amazon.BedrockAgentCoreControl.Model.CreateGatewayResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCoreControl.Model.CreateGatewayResponse",
        "This cmdlet returns an Amazon.BedrockAgentCoreControl.Model.CreateGatewayResponse object containing multiple properties."
    )]
    public partial class NewBACCGatewayCmdlet : AmazonBedrockAgentCoreControlClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        
        #region Parameter AuthorizerType
        /// <summary>
        /// <para>
        /// <para>The type of authorizer to use for the gateway.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.AuthorizerType")]
        public Amazon.BedrockAgentCoreControl.AuthorizerType AuthorizerType { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the gateway.</para>
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
        
        #region Parameter ExceptionLevel
        /// <summary>
        /// <para>
        /// <para>The level of detail in error messages returned when invoking the gateway.</para><ul><li><para>If the value is <c>DEBUG</c>, granular exception messages are returned to help a user
        /// debug the gateway.</para></li><li><para>If the value is omitted, a generic error message is returned to the end user.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.ExceptionLevel")]
        public Amazon.BedrockAgentCoreControl.ExceptionLevel ExceptionLevel { get; set; }
        #endregion
        
        #region Parameter Mcp_Instruction
        /// <summary>
        /// <para>
        /// <para>The instructions for using the Model Context Protocol gateway. These instructions
        /// provide guidance on how to interact with the gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProtocolConfiguration_Mcp_Instructions")]
        public System.String Mcp_Instruction { get; set; }
        #endregion
        
        #region Parameter KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the KMS key used to encrypt data associated with
        /// the gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the gateway. The name must be unique within your account.</para>
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
        
        #region Parameter ProtocolType
        /// <summary>
        /// <para>
        /// <para>The protocol type for the gateway.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.GatewayProtocolType")]
        public Amazon.BedrockAgentCoreControl.GatewayProtocolType ProtocolType { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that provides permissions for the gateway
        /// to access Amazon Web Services services.</para>
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
        
        #region Parameter Mcp_SearchType
        /// <summary>
        /// <para>
        /// <para>The search type for the Model Context Protocol gateway. This field specifies how the
        /// gateway handles search operations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProtocolConfiguration_Mcp_SearchType")]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.SearchType")]
        public Amazon.BedrockAgentCoreControl.SearchType Mcp_SearchType { get; set; }
        #endregion
        
        #region Parameter Mcp_SupportedVersion
        /// <summary>
        /// <para>
        /// <para>The supported versions of the Model Context Protocol. This field specifies which versions
        /// of the protocol the gateway can use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProtocolConfiguration_Mcp_SupportedVersions")]
        public System.String[] Mcp_SupportedVersion { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the API request completes no more
        /// than one time. If this token matches a previous request, the service ignores the request,
        /// but does not return an error. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCoreControl.Model.CreateGatewayResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCoreControl.Model.CreateGatewayResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BACCGateway (CreateGateway)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCoreControl.Model.CreateGatewayResponse, NewBACCGatewayCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.CustomJWTAuthorizer_AllowedAudience != null)
            {
                context.CustomJWTAuthorizer_AllowedAudience = new List<System.String>(this.CustomJWTAuthorizer_AllowedAudience);
            }
            if (this.CustomJWTAuthorizer_AllowedClient != null)
            {
                context.CustomJWTAuthorizer_AllowedClient = new List<System.String>(this.CustomJWTAuthorizer_AllowedClient);
            }
            context.CustomJWTAuthorizer_DiscoveryUrl = this.CustomJWTAuthorizer_DiscoveryUrl;
            context.AuthorizerType = this.AuthorizerType;
            #if MODULAR
            if (this.AuthorizerType == null && ParameterWasBound(nameof(this.AuthorizerType)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthorizerType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.ExceptionLevel = this.ExceptionLevel;
            context.KmsKeyArn = this.KmsKeyArn;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Mcp_Instruction = this.Mcp_Instruction;
            context.Mcp_SearchType = this.Mcp_SearchType;
            if (this.Mcp_SupportedVersion != null)
            {
                context.Mcp_SupportedVersion = new List<System.String>(this.Mcp_SupportedVersion);
            }
            context.ProtocolType = this.ProtocolType;
            #if MODULAR
            if (this.ProtocolType == null && ParameterWasBound(nameof(this.ProtocolType)))
            {
                WriteWarning("You are passing $null as a value for parameter ProtocolType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.BedrockAgentCoreControl.Model.CreateGatewayRequest();
            
            
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
            if (cmdletContext.AuthorizerType != null)
            {
                request.AuthorizerType = cmdletContext.AuthorizerType;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.ExceptionLevel != null)
            {
                request.ExceptionLevel = cmdletContext.ExceptionLevel;
            }
            if (cmdletContext.KmsKeyArn != null)
            {
                request.KmsKeyArn = cmdletContext.KmsKeyArn;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate ProtocolConfiguration
            var requestProtocolConfigurationIsNull = true;
            request.ProtocolConfiguration = new Amazon.BedrockAgentCoreControl.Model.GatewayProtocolConfiguration();
            Amazon.BedrockAgentCoreControl.Model.MCPGatewayConfiguration requestProtocolConfiguration_protocolConfiguration_Mcp = null;
            
             // populate Mcp
            var requestProtocolConfiguration_protocolConfiguration_McpIsNull = true;
            requestProtocolConfiguration_protocolConfiguration_Mcp = new Amazon.BedrockAgentCoreControl.Model.MCPGatewayConfiguration();
            System.String requestProtocolConfiguration_protocolConfiguration_Mcp_mcp_Instruction = null;
            if (cmdletContext.Mcp_Instruction != null)
            {
                requestProtocolConfiguration_protocolConfiguration_Mcp_mcp_Instruction = cmdletContext.Mcp_Instruction;
            }
            if (requestProtocolConfiguration_protocolConfiguration_Mcp_mcp_Instruction != null)
            {
                requestProtocolConfiguration_protocolConfiguration_Mcp.Instructions = requestProtocolConfiguration_protocolConfiguration_Mcp_mcp_Instruction;
                requestProtocolConfiguration_protocolConfiguration_McpIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.SearchType requestProtocolConfiguration_protocolConfiguration_Mcp_mcp_SearchType = null;
            if (cmdletContext.Mcp_SearchType != null)
            {
                requestProtocolConfiguration_protocolConfiguration_Mcp_mcp_SearchType = cmdletContext.Mcp_SearchType;
            }
            if (requestProtocolConfiguration_protocolConfiguration_Mcp_mcp_SearchType != null)
            {
                requestProtocolConfiguration_protocolConfiguration_Mcp.SearchType = requestProtocolConfiguration_protocolConfiguration_Mcp_mcp_SearchType;
                requestProtocolConfiguration_protocolConfiguration_McpIsNull = false;
            }
            List<System.String> requestProtocolConfiguration_protocolConfiguration_Mcp_mcp_SupportedVersion = null;
            if (cmdletContext.Mcp_SupportedVersion != null)
            {
                requestProtocolConfiguration_protocolConfiguration_Mcp_mcp_SupportedVersion = cmdletContext.Mcp_SupportedVersion;
            }
            if (requestProtocolConfiguration_protocolConfiguration_Mcp_mcp_SupportedVersion != null)
            {
                requestProtocolConfiguration_protocolConfiguration_Mcp.SupportedVersions = requestProtocolConfiguration_protocolConfiguration_Mcp_mcp_SupportedVersion;
                requestProtocolConfiguration_protocolConfiguration_McpIsNull = false;
            }
             // determine if requestProtocolConfiguration_protocolConfiguration_Mcp should be set to null
            if (requestProtocolConfiguration_protocolConfiguration_McpIsNull)
            {
                requestProtocolConfiguration_protocolConfiguration_Mcp = null;
            }
            if (requestProtocolConfiguration_protocolConfiguration_Mcp != null)
            {
                request.ProtocolConfiguration.Mcp = requestProtocolConfiguration_protocolConfiguration_Mcp;
                requestProtocolConfigurationIsNull = false;
            }
             // determine if request.ProtocolConfiguration should be set to null
            if (requestProtocolConfigurationIsNull)
            {
                request.ProtocolConfiguration = null;
            }
            if (cmdletContext.ProtocolType != null)
            {
                request.ProtocolType = cmdletContext.ProtocolType;
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
        
        private Amazon.BedrockAgentCoreControl.Model.CreateGatewayResponse CallAWSServiceOperation(IAmazonBedrockAgentCoreControl client, Amazon.BedrockAgentCoreControl.Model.CreateGatewayRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Core Control Plane Fronting Layer", "CreateGateway");
            try
            {
                #if DESKTOP
                return client.CreateGateway(request);
                #elif CORECLR
                return client.CreateGatewayAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> CustomJWTAuthorizer_AllowedAudience { get; set; }
            public List<System.String> CustomJWTAuthorizer_AllowedClient { get; set; }
            public System.String CustomJWTAuthorizer_DiscoveryUrl { get; set; }
            public Amazon.BedrockAgentCoreControl.AuthorizerType AuthorizerType { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public Amazon.BedrockAgentCoreControl.ExceptionLevel ExceptionLevel { get; set; }
            public System.String KmsKeyArn { get; set; }
            public System.String Name { get; set; }
            public System.String Mcp_Instruction { get; set; }
            public Amazon.BedrockAgentCoreControl.SearchType Mcp_SearchType { get; set; }
            public List<System.String> Mcp_SupportedVersion { get; set; }
            public Amazon.BedrockAgentCoreControl.GatewayProtocolType ProtocolType { get; set; }
            public System.String RoleArn { get; set; }
            public System.Func<Amazon.BedrockAgentCoreControl.Model.CreateGatewayResponse, NewBACCGatewayCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
