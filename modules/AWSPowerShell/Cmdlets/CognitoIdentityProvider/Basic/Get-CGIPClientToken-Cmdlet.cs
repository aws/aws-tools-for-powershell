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
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CGIP
{
    /// <summary>
    /// Issues an access token for machine-to-machine (M2M) authorization. Your app client
    /// provides its client ID and secret, and receives an access token that authorizes requests
    /// to your resource servers. <c>GetClientToken</c> provides the same functionality as
    /// the OAuth2 client-credentials grant; both authorize an application rather than a user.
    /// 
    ///  
    /// <para>
    /// To use this operation, you must configure the app client with a client secret and
    /// enable the <c>ALLOW_CLIENT_TOKEN_AUTH</c> authentication flow. The <c>ALLOW_CLIENT_TOKEN_AUTH</c>
    /// flow is mutually exclusive with user authentication flows. It must be the only authentication
    /// flow that you configure for the app client. For more information, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-pools-define-resource-servers.html">Scopes,
    /// M2M, and resource servers</a>.
    /// </para><note><para>
    /// Amazon Cognito doesn't evaluate Identity and Access Management (IAM) policies in requests
    /// for this API operation. For this operation, you can't use IAM credentials to authorize
    /// requests, and you can't grant IAM permissions in policies. For more information about
    /// authorization models in Amazon Cognito, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/user-pools-API-operations.html">Using
    /// the Amazon Cognito user pools API and user pool endpoints</a>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "CGIPClientToken")]
    [OutputType("Amazon.CognitoIdentityProvider.Model.ClientAuthenticationResultType")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider GetClientToken API operation.", Operation = new[] {"GetClientToken"}, SelectReturnType = typeof(Amazon.CognitoIdentityProvider.Model.GetClientTokenResponse))]
    [AWSCmdletOutput("Amazon.CognitoIdentityProvider.Model.ClientAuthenticationResultType or Amazon.CognitoIdentityProvider.Model.GetClientTokenResponse",
        "This cmdlet returns an Amazon.CognitoIdentityProvider.Model.ClientAuthenticationResultType object.",
        "The service call response (type Amazon.CognitoIdentityProvider.Model.GetClientTokenResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCGIPClientTokenCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ClientId
        /// <summary>
        /// <para>
        /// <para>The ID of the app client that requests the access token. The app client must have
        /// a client secret and the <c>ALLOW_CLIENT_TOKEN_AUTH</c> authentication flow.</para>
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
        public System.String ClientId { get; set; }
        #endregion
        
        #region Parameter ClientMetadata
        /// <summary>
        /// <para>
        /// <para>A map of custom key-value pairs that you can provide as input for any custom workflows
        /// that this action triggers. You create custom workflows by assigning Lambda functions
        /// to user pool triggers.</para><para>When Amazon Cognito invokes any of these functions, it passes a JSON payload, which
        /// the function receives as input. This payload contains a <c>clientMetadata</c> attribute
        /// that provides the data that you assigned to the ClientMetadata parameter in your request.
        /// In your function code, you can process the <c>clientMetadata</c> value to enhance
        /// your workflow for your specific needs.</para><para>To review the Lambda trigger types that Amazon Cognito invokes at runtime with API
        /// requests, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-pools-working-with-lambda-triggers.html#lambda-triggers-by-event">
        /// Connecting API actions to Lambda triggers</a> in the <i>Amazon Cognito Developer Guide</i>.</para><note><para>When you use the <c>ClientMetadata</c> parameter, note that Amazon Cognito won't do
        /// the following:</para><ul><li><para>Store the <c>ClientMetadata</c> value. This data is available only to Lambda triggers
        /// that are assigned to a user pool to support custom workflows. If your user pool configuration
        /// doesn't include triggers, the <c>ClientMetadata</c> parameter serves no purpose.</para></li><li><para>Validate the <c>ClientMetadata</c> value.</para></li><li><para>Encrypt the <c>ClientMetadata</c> value. Don't send sensitive information in this
        /// parameter.</para></li></ul></note><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ClientMetadata { get; set; }
        #endregion
        
        #region Parameter Scope
        /// <summary>
        /// <para>
        /// <para>The custom scopes to authorize in the access token, in the format <c>resource-server-identifier/scope-name</c>.
        /// Each scope must belong to a resource server in your user pool. If you don't specify
        /// any scopes, Amazon Cognito authorizes the scopes that are configured for the app client.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Scopes")]
        public System.String[] Scope { get; set; }
        #endregion
        
        #region Parameter Secret
        /// <summary>
        /// <para>
        /// <para>An active secret for the app client.</para>
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
        public System.String Secret { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ClientAuthenticationResult'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentityProvider.Model.GetClientTokenResponse).
        /// Specifying the name of a property of type Amazon.CognitoIdentityProvider.Model.GetClientTokenResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ClientAuthenticationResult";
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
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentityProvider.Model.GetClientTokenResponse, GetCGIPClientTokenCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientId = this.ClientId;
            #if MODULAR
            if (this.ClientId == null && ParameterWasBound(nameof(this.ClientId)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ClientMetadata != null)
            {
                context.ClientMetadata = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ClientMetadata.Keys)
                {
                    context.ClientMetadata.Add((String)hashKey, (System.String)(this.ClientMetadata[hashKey]));
                }
            }
            if (this.Scope != null)
            {
                context.Scope = new List<System.String>(this.Scope);
            }
            context.Secret = this.Secret;
            #if MODULAR
            if (this.Secret == null && ParameterWasBound(nameof(this.Secret)))
            {
                WriteWarning("You are passing $null as a value for parameter Secret which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CognitoIdentityProvider.Model.GetClientTokenRequest();
            
            if (cmdletContext.ClientId != null)
            {
                request.ClientId = cmdletContext.ClientId;
            }
            if (cmdletContext.ClientMetadata != null)
            {
                request.ClientMetadata = cmdletContext.ClientMetadata;
            }
            if (cmdletContext.Scope != null)
            {
                request.Scopes = cmdletContext.Scope;
            }
            if (cmdletContext.Secret != null)
            {
                request.Secret = cmdletContext.Secret;
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
        
        private Amazon.CognitoIdentityProvider.Model.GetClientTokenResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.GetClientTokenRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "GetClientToken");
            try
            {
                return client.GetClientTokenAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientId { get; set; }
            public Dictionary<System.String, System.String> ClientMetadata { get; set; }
            public List<System.String> Scope { get; set; }
            public System.String Secret { get; set; }
            public System.Func<Amazon.CognitoIdentityProvider.Model.GetClientTokenResponse, GetCGIPClientTokenCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ClientAuthenticationResult;
        }
        
    }
}
