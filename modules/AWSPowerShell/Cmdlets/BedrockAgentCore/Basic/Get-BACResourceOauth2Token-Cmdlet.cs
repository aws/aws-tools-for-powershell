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
using Amazon.BedrockAgentCore;
using Amazon.BedrockAgentCore.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BAC
{
    /// <summary>
    /// Reaturns the Oauth2Token of the provided resource
    /// </summary>
    [Cmdlet("Get", "BACResourceOauth2Token")]
    [OutputType("Amazon.BedrockAgentCore.Model.GetResourceOauth2TokenResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock AgentCore Data Plane Fronting Layer GetResourceOauth2Token API operation.", Operation = new[] {"GetResourceOauth2Token"}, SelectReturnType = typeof(Amazon.BedrockAgentCore.Model.GetResourceOauth2TokenResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCore.Model.GetResourceOauth2TokenResponse",
        "This cmdlet returns an Amazon.BedrockAgentCore.Model.GetResourceOauth2TokenResponse object containing multiple properties."
    )]
    public partial class GetBACResourceOauth2TokenCmdlet : AmazonBedrockAgentCoreClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CustomParameter
        /// <summary>
        /// <para>
        /// <para>Gives the ability to send extra/custom parameters to the resource credentials provider
        /// during the authorization process. Standard OAuth2 flow parameters will not be overriden.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomParameters")]
        public System.Collections.Hashtable CustomParameter { get; set; }
        #endregion
        
        #region Parameter ForceAuthentication
        /// <summary>
        /// <para>
        /// <para>If true, always initiate a new 3LO flow</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ForceAuthentication { get; set; }
        #endregion
        
        #region Parameter Oauth2Flow
        /// <summary>
        /// <para>
        /// <para>The type of flow to be performed</para>
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
        /// <para>Reference to the credential provider</para>
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
        /// <para>Callback url to redirect after token retrieval completes. Should be one of the provideded
        /// urls during WorkloadIdentity creation</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceOauth2ReturnUrl { get; set; }
        #endregion
        
        #region Parameter Scope
        /// <summary>
        /// <para>
        /// <para>The OAuth scopes requested</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>The user ID of the user you're retrieving the token on behalf of.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserId { get; set; }
        #endregion
        
        #region Parameter WorkloadIdentityToken
        /// <summary>
        /// <para>
        /// <para>The identity token of the workload you want to retrive the Oauth2 Token of.</para>
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
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
            context.UserId = this.UserId;
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
            if (cmdletContext.UserId != null)
            {
                request.UserId = cmdletContext.UserId;
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
                return client.GetResourceOauth2TokenAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? ForceAuthentication { get; set; }
            public Amazon.BedrockAgentCore.Oauth2FlowType Oauth2Flow { get; set; }
            public System.String ResourceCredentialProviderName { get; set; }
            public System.String ResourceOauth2ReturnUrl { get; set; }
            public List<System.String> Scope { get; set; }
            public System.String UserId { get; set; }
            public System.String WorkloadIdentityToken { get; set; }
            public System.Func<Amazon.BedrockAgentCore.Model.GetResourceOauth2TokenResponse, GetBACResourceOauth2TokenCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
