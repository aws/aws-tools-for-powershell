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
using Amazon.BedrockAgentCore;
using Amazon.BedrockAgentCore.Model;

namespace Amazon.PowerShell.Cmdlets.BAC
{
    /// <summary>
    /// Returns the OAuth 2.0 token of the provided resource.
    /// </summary>
    [Cmdlet("Get", "BACResourceOauth2Token")]
    [OutputType("Amazon.BedrockAgentCore.Model.GetResourceOauth2TokenResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock AgentCore Data Plane Fronting Layer GetResourceOauth2Token API operation.", Operation = new[] {"GetResourceOauth2Token"}, SelectReturnType = typeof(Amazon.BedrockAgentCore.Model.GetResourceOauth2TokenResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCore.Model.GetResourceOauth2TokenResponse",
        "This cmdlet returns an Amazon.BedrockAgentCore.Model.GetResourceOauth2TokenResponse object containing multiple properties."
    )]
    public partial class GetBACResourceOauth2TokenCmdlet : AmazonBedrockAgentCoreClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CustomParameter
        /// <summary>
        /// <para>
        /// <para>A map of custom parameters to include in the authorization request to the resource
        /// credential provider. These parameters are in addition to the standard OAuth 2.0 flow
        /// parameters, and will not override them.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomParameters")]
        public System.Collections.Hashtable CustomParameter { get; set; }
        #endregion
        
        #region Parameter CustomState
        /// <summary>
        /// <para>
        /// <para>An opaque string that will be sent back to the callback URL provided in resourceOauth2ReturnUrl.
        /// This state should be used to protect the callback URL of your application against
        /// CSRF attacks by ensuring the response corresponds to the original request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomState { get; set; }
        #endregion
        
        #region Parameter ForceAuthentication
        /// <summary>
        /// <para>
        /// <para>Indicates whether to always initiate a new three-legged OAuth (3LO) flow, regardless
        /// of any existing session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ForceAuthentication { get; set; }
        #endregion
        
        #region Parameter Oauth2Flow
        /// <summary>
        /// <para>
        /// <para>The type of flow to be performed.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.BedrockAgentCore.Oauth2FlowType")]
        public Amazon.BedrockAgentCore.Oauth2FlowType Oauth2Flow { get; set; }
        #endregion
        
        #region Parameter ResourceCredentialProviderName
        /// <summary>
        /// <para>
        /// <para>The name of the resource's credential provider.</para>
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
        public System.String ResourceCredentialProviderName { get; set; }
        #endregion
        
        #region Parameter ResourceOauth2ReturnUrl
        /// <summary>
        /// <para>
        /// <para>The callback URL to redirect to after the OAuth 2.0 token retrieval is complete. This
        /// URL must be one of the provided URLs configured for the workload identity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceOauth2ReturnUrl { get; set; }
        #endregion
        
        #region Parameter Scope
        /// <summary>
        /// <para>
        /// <para>The OAuth scopes being requested.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Scopes")]
        public System.String[] Scope { get; set; }
        #endregion
        
        #region Parameter SessionUri
        /// <summary>
        /// <para>
        /// <para>Unique identifier for the user's authentication session for retrieving OAuth2 tokens.
        /// This ID tracks the authorization flow state across multiple requests and responses
        /// during the OAuth2 authentication process.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SessionUri { get; set; }
        #endregion
        
        #region Parameter WorkloadIdentityToken
        /// <summary>
        /// <para>
        /// <para>The identity token of the workload from which you want to retrieve the OAuth2 token.</para>
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
        public System.String WorkloadIdentityToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCore.Model.GetResourceOauth2TokenResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCore.Model.GetResourceOauth2TokenResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCore.Model.GetResourceOauth2TokenResponse, GetBACResourceOauth2TokenCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.CustomParameter != null)
            {
                context.CustomParameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.CustomParameter.Keys)
                {
                    context.CustomParameter.Add((String)hashKey, (System.String)(this.CustomParameter[hashKey]));
                }
            }
            context.CustomState = this.CustomState;
            context.ForceAuthentication = this.ForceAuthentication;
            context.Oauth2Flow = this.Oauth2Flow;
            #if MODULAR
            if (this.Oauth2Flow == null && ParameterWasBound(nameof(this.Oauth2Flow)))
            {
                WriteWarning("You are passing $null as a value for parameter Oauth2Flow which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceCredentialProviderName = this.ResourceCredentialProviderName;
            #if MODULAR
            if (this.ResourceCredentialProviderName == null && ParameterWasBound(nameof(this.ResourceCredentialProviderName)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceCredentialProviderName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceOauth2ReturnUrl = this.ResourceOauth2ReturnUrl;
            if (this.Scope != null)
            {
                context.Scope = new List<System.String>(this.Scope);
            }
            #if MODULAR
            if (this.Scope == null && ParameterWasBound(nameof(this.Scope)))
            {
                WriteWarning("You are passing $null as a value for parameter Scope which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SessionUri = this.SessionUri;
            context.WorkloadIdentityToken = this.WorkloadIdentityToken;
            #if MODULAR
            if (this.WorkloadIdentityToken == null && ParameterWasBound(nameof(this.WorkloadIdentityToken)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkloadIdentityToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BedrockAgentCore.Model.GetResourceOauth2TokenRequest();
            
            if (cmdletContext.CustomParameter != null)
            {
                request.CustomParameters = cmdletContext.CustomParameter;
            }
            if (cmdletContext.CustomState != null)
            {
                request.CustomState = cmdletContext.CustomState;
            }
            if (cmdletContext.ForceAuthentication != null)
            {
                request.ForceAuthentication = cmdletContext.ForceAuthentication.Value;
            }
            if (cmdletContext.Oauth2Flow != null)
            {
                request.Oauth2Flow = cmdletContext.Oauth2Flow;
            }
            if (cmdletContext.ResourceCredentialProviderName != null)
            {
                request.ResourceCredentialProviderName = cmdletContext.ResourceCredentialProviderName;
            }
            if (cmdletContext.ResourceOauth2ReturnUrl != null)
            {
                request.ResourceOauth2ReturnUrl = cmdletContext.ResourceOauth2ReturnUrl;
            }
            if (cmdletContext.Scope != null)
            {
                request.Scopes = cmdletContext.Scope;
            }
            if (cmdletContext.SessionUri != null)
            {
                request.SessionUri = cmdletContext.SessionUri;
            }
            if (cmdletContext.WorkloadIdentityToken != null)
            {
                request.WorkloadIdentityToken = cmdletContext.WorkloadIdentityToken;
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
        
        private Amazon.BedrockAgentCore.Model.GetResourceOauth2TokenResponse CallAWSServiceOperation(IAmazonBedrockAgentCore client, Amazon.BedrockAgentCore.Model.GetResourceOauth2TokenRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock AgentCore Data Plane Fronting Layer", "GetResourceOauth2Token");
            try
            {
                #if DESKTOP
                return client.GetResourceOauth2Token(request);
                #elif CORECLR
                return client.GetResourceOauth2TokenAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> CustomParameter { get; set; }
            public System.String CustomState { get; set; }
            public System.Boolean? ForceAuthentication { get; set; }
            public Amazon.BedrockAgentCore.Oauth2FlowType Oauth2Flow { get; set; }
            public System.String ResourceCredentialProviderName { get; set; }
            public System.String ResourceOauth2ReturnUrl { get; set; }
            public List<System.String> Scope { get; set; }
            public System.String SessionUri { get; set; }
            public System.String WorkloadIdentityToken { get; set; }
            public System.Func<Amazon.BedrockAgentCore.Model.GetResourceOauth2TokenResponse, GetBACResourceOauth2TokenCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
