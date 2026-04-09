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
    /// Creates a new registry in your Amazon Web Services account. A registry serves as a
    /// centralized catalog for organizing and managing registry records, including MCP servers,
    /// A2A agents, agent skills, and custom resource types.
    /// 
    ///  
    /// <para>
    /// If you specify <c>CUSTOM_JWT</c> as the <c>authorizerType</c>, you must provide an
    /// <c>authorizerConfiguration</c>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "BACCRegistry", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Core Control Plane Fronting Layer CreateRegistry API operation.", Operation = new[] {"CreateRegistry"}, SelectReturnType = typeof(Amazon.BedrockAgentCoreControl.Model.CreateRegistryResponse))]
    [AWSCmdletOutput("System.String or Amazon.BedrockAgentCoreControl.Model.CreateRegistryResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.BedrockAgentCoreControl.Model.CreateRegistryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewBACCRegistryCmdlet : AmazonBedrockAgentCoreControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AuthorizerConfiguration_CustomJWTAuthorizer_AllowedAudience
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
        public System.String[] AuthorizerConfiguration_CustomJWTAuthorizer_AllowedAudience { get; set; }
        #endregion
        
        #region Parameter AuthorizerConfiguration_CustomJWTAuthorizer_AllowedClient
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
        public System.String[] AuthorizerConfiguration_CustomJWTAuthorizer_AllowedClient { get; set; }
        #endregion
        
        #region Parameter AuthorizerConfiguration_CustomJWTAuthorizer_AllowedScope
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
        [Alias("AuthorizerConfiguration_CustomJWTAuthorizer_AllowedScopes")]
        public System.String[] AuthorizerConfiguration_CustomJWTAuthorizer_AllowedScope { get; set; }
        #endregion
        
        #region Parameter AuthorizerType
        /// <summary>
        /// <para>
        /// <para>The type of authorizer to use for the registry. This controls the authorization method
        /// for the Search and Invoke APIs used by consumers, and does not affect the standard
        /// CRUDL APIs for registry and registry record management used by administrators.</para><ul><li><para><c>CUSTOM_JWT</c> - Authorize with a bearer token.</para></li><li><para><c>AWS_IAM</c> - Authorize with your Amazon Web Services IAM credentials.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.RegistryAuthorizerType")]
        public Amazon.BedrockAgentCoreControl.RegistryAuthorizerType AuthorizerType { get; set; }
        #endregion
        
        #region Parameter ApprovalConfiguration_AutoApproval
        /// <summary>
        /// <para>
        /// <para>Whether registry records are auto-approved. When set to <c>true</c>, records are automatically
        /// approved upon creation. When set to <c>false</c> (the default), records require explicit
        /// approval for security purposes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ApprovalConfiguration_AutoApproval { get; set; }
        #endregion
        
        #region Parameter AuthorizerConfiguration_CustomJWTAuthorizer_CustomClaim
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
        [Alias("AuthorizerConfiguration_CustomJWTAuthorizer_CustomClaims")]
        public Amazon.BedrockAgentCoreControl.Model.CustomClaimValidationType[] AuthorizerConfiguration_CustomJWTAuthorizer_CustomClaim { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the registry.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter AuthorizerConfiguration_CustomJWTAuthorizer_DiscoveryUrl
        /// <summary>
        /// <para>
        /// <para>This URL is used to fetch OpenID Connect configuration or authorization server metadata
        /// for validating incoming tokens.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuthorizerConfiguration_CustomJWTAuthorizer_DiscoveryUrl { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the registry. The name must be unique within your account and can contain
        /// alphanumeric characters and underscores.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the API request completes no more
        /// than one time. If you don't specify this field, a value is randomly generated for
        /// you. If this token matches a previous request, the service ignores the request, but
        /// doesn't return an error. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RegistryArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCoreControl.Model.CreateRegistryResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCoreControl.Model.CreateRegistryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RegistryArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BACCRegistry (CreateRegistry)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCoreControl.Model.CreateRegistryResponse, NewBACCRegistryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApprovalConfiguration_AutoApproval = this.ApprovalConfiguration_AutoApproval;
            if (this.AuthorizerConfiguration_CustomJWTAuthorizer_AllowedAudience != null)
            {
                context.AuthorizerConfiguration_CustomJWTAuthorizer_AllowedAudience = new List<System.String>(this.AuthorizerConfiguration_CustomJWTAuthorizer_AllowedAudience);
            }
            if (this.AuthorizerConfiguration_CustomJWTAuthorizer_AllowedClient != null)
            {
                context.AuthorizerConfiguration_CustomJWTAuthorizer_AllowedClient = new List<System.String>(this.AuthorizerConfiguration_CustomJWTAuthorizer_AllowedClient);
            }
            if (this.AuthorizerConfiguration_CustomJWTAuthorizer_AllowedScope != null)
            {
                context.AuthorizerConfiguration_CustomJWTAuthorizer_AllowedScope = new List<System.String>(this.AuthorizerConfiguration_CustomJWTAuthorizer_AllowedScope);
            }
            if (this.AuthorizerConfiguration_CustomJWTAuthorizer_CustomClaim != null)
            {
                context.AuthorizerConfiguration_CustomJWTAuthorizer_CustomClaim = new List<Amazon.BedrockAgentCoreControl.Model.CustomClaimValidationType>(this.AuthorizerConfiguration_CustomJWTAuthorizer_CustomClaim);
            }
            context.AuthorizerConfiguration_CustomJWTAuthorizer_DiscoveryUrl = this.AuthorizerConfiguration_CustomJWTAuthorizer_DiscoveryUrl;
            context.AuthorizerType = this.AuthorizerType;
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BedrockAgentCoreControl.Model.CreateRegistryRequest();
            
            
             // populate ApprovalConfiguration
            var requestApprovalConfigurationIsNull = true;
            request.ApprovalConfiguration = new Amazon.BedrockAgentCoreControl.Model.ApprovalConfiguration();
            System.Boolean? requestApprovalConfiguration_approvalConfiguration_AutoApproval = null;
            if (cmdletContext.ApprovalConfiguration_AutoApproval != null)
            {
                requestApprovalConfiguration_approvalConfiguration_AutoApproval = cmdletContext.ApprovalConfiguration_AutoApproval.Value;
            }
            if (requestApprovalConfiguration_approvalConfiguration_AutoApproval != null)
            {
                request.ApprovalConfiguration.AutoApproval = requestApprovalConfiguration_approvalConfiguration_AutoApproval.Value;
                requestApprovalConfigurationIsNull = false;
            }
             // determine if request.ApprovalConfiguration should be set to null
            if (requestApprovalConfigurationIsNull)
            {
                request.ApprovalConfiguration = null;
            }
            
             // populate AuthorizerConfiguration
            var requestAuthorizerConfigurationIsNull = true;
            request.AuthorizerConfiguration = new Amazon.BedrockAgentCoreControl.Model.AuthorizerConfiguration();
            Amazon.BedrockAgentCoreControl.Model.CustomJWTAuthorizerConfiguration requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer = null;
            
             // populate CustomJWTAuthorizer
            var requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizerIsNull = true;
            requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer = new Amazon.BedrockAgentCoreControl.Model.CustomJWTAuthorizerConfiguration();
            List<System.String> requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_authorizerConfiguration_CustomJWTAuthorizer_AllowedAudience = null;
            if (cmdletContext.AuthorizerConfiguration_CustomJWTAuthorizer_AllowedAudience != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_authorizerConfiguration_CustomJWTAuthorizer_AllowedAudience = cmdletContext.AuthorizerConfiguration_CustomJWTAuthorizer_AllowedAudience;
            }
            if (requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_authorizerConfiguration_CustomJWTAuthorizer_AllowedAudience != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer.AllowedAudience = requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_authorizerConfiguration_CustomJWTAuthorizer_AllowedAudience;
                requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizerIsNull = false;
            }
            List<System.String> requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_authorizerConfiguration_CustomJWTAuthorizer_AllowedClient = null;
            if (cmdletContext.AuthorizerConfiguration_CustomJWTAuthorizer_AllowedClient != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_authorizerConfiguration_CustomJWTAuthorizer_AllowedClient = cmdletContext.AuthorizerConfiguration_CustomJWTAuthorizer_AllowedClient;
            }
            if (requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_authorizerConfiguration_CustomJWTAuthorizer_AllowedClient != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer.AllowedClients = requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_authorizerConfiguration_CustomJWTAuthorizer_AllowedClient;
                requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizerIsNull = false;
            }
            List<System.String> requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_authorizerConfiguration_CustomJWTAuthorizer_AllowedScope = null;
            if (cmdletContext.AuthorizerConfiguration_CustomJWTAuthorizer_AllowedScope != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_authorizerConfiguration_CustomJWTAuthorizer_AllowedScope = cmdletContext.AuthorizerConfiguration_CustomJWTAuthorizer_AllowedScope;
            }
            if (requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_authorizerConfiguration_CustomJWTAuthorizer_AllowedScope != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer.AllowedScopes = requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_authorizerConfiguration_CustomJWTAuthorizer_AllowedScope;
                requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizerIsNull = false;
            }
            List<Amazon.BedrockAgentCoreControl.Model.CustomClaimValidationType> requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_authorizerConfiguration_CustomJWTAuthorizer_CustomClaim = null;
            if (cmdletContext.AuthorizerConfiguration_CustomJWTAuthorizer_CustomClaim != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_authorizerConfiguration_CustomJWTAuthorizer_CustomClaim = cmdletContext.AuthorizerConfiguration_CustomJWTAuthorizer_CustomClaim;
            }
            if (requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_authorizerConfiguration_CustomJWTAuthorizer_CustomClaim != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer.CustomClaims = requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_authorizerConfiguration_CustomJWTAuthorizer_CustomClaim;
                requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizerIsNull = false;
            }
            System.String requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_authorizerConfiguration_CustomJWTAuthorizer_DiscoveryUrl = null;
            if (cmdletContext.AuthorizerConfiguration_CustomJWTAuthorizer_DiscoveryUrl != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_authorizerConfiguration_CustomJWTAuthorizer_DiscoveryUrl = cmdletContext.AuthorizerConfiguration_CustomJWTAuthorizer_DiscoveryUrl;
            }
            if (requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_authorizerConfiguration_CustomJWTAuthorizer_DiscoveryUrl != null)
            {
                requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer.DiscoveryUrl = requestAuthorizerConfiguration_authorizerConfiguration_CustomJWTAuthorizer_authorizerConfiguration_CustomJWTAuthorizer_DiscoveryUrl;
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
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.BedrockAgentCoreControl.Model.CreateRegistryResponse CallAWSServiceOperation(IAmazonBedrockAgentCoreControl client, Amazon.BedrockAgentCoreControl.Model.CreateRegistryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Core Control Plane Fronting Layer", "CreateRegistry");
            try
            {
                return client.CreateRegistryAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? ApprovalConfiguration_AutoApproval { get; set; }
            public List<System.String> AuthorizerConfiguration_CustomJWTAuthorizer_AllowedAudience { get; set; }
            public List<System.String> AuthorizerConfiguration_CustomJWTAuthorizer_AllowedClient { get; set; }
            public List<System.String> AuthorizerConfiguration_CustomJWTAuthorizer_AllowedScope { get; set; }
            public List<Amazon.BedrockAgentCoreControl.Model.CustomClaimValidationType> AuthorizerConfiguration_CustomJWTAuthorizer_CustomClaim { get; set; }
            public System.String AuthorizerConfiguration_CustomJWTAuthorizer_DiscoveryUrl { get; set; }
            public Amazon.BedrockAgentCoreControl.RegistryAuthorizerType AuthorizerType { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.BedrockAgentCoreControl.Model.CreateRegistryResponse, NewBACCRegistryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RegistryArn;
        }
        
    }
}
