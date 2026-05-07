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
    /// Generates authentication tokens for payment providers that use vendor-specific authentication
    /// mechanisms.
    /// </summary>
    [Cmdlet("Get", "BACResourcePaymentToken")]
    [OutputType("Amazon.BedrockAgentCore.Model.PaymentTokenResponseOutput")]
    [AWSCmdlet("Calls the Amazon Bedrock AgentCore Data Plane Fronting Layer GetResourcePaymentToken API operation.", Operation = new[] {"GetResourcePaymentToken"}, SelectReturnType = typeof(Amazon.BedrockAgentCore.Model.GetResourcePaymentTokenResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCore.Model.PaymentTokenResponseOutput or Amazon.BedrockAgentCore.Model.GetResourcePaymentTokenResponse",
        "This cmdlet returns an Amazon.BedrockAgentCore.Model.PaymentTokenResponseOutput object.",
        "The service call response (type Amazon.BedrockAgentCore.Model.GetResourcePaymentTokenResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetBACResourcePaymentTokenCmdlet : AmazonBedrockAgentCoreClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter PaymentTokenRequest_StripePrivyTokenRequest_IncludeAuthorizationSignature
        /// <summary>
        /// <para>
        /// <para>Set to true to generate privy-authorization-signature</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PaymentTokenRequest_StripePrivyTokenRequest_IncludeAuthorizationSignature { get; set; }
        #endregion
        
        #region Parameter PaymentTokenRequest_CoinbaseCdpTokenRequest_IncludeWalletAuthToken
        /// <summary>
        /// <para>
        /// <para>Set to true for wallet write operations (requires walletSecret configured)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PaymentTokenRequest_CoinbaseCdpTokenRequest_IncludeWalletAuthToken { get; set; }
        #endregion
        
        #region Parameter PaymentTokenRequest_CoinbaseCdpTokenRequest_RequestBody
        /// <summary>
        /// <para>
        /// <para>Request body JSON - used to generate wallet auth JWT</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PaymentTokenRequest_CoinbaseCdpTokenRequest_RequestBody { get; set; }
        #endregion
        
        #region Parameter PaymentTokenRequest_StripePrivyTokenRequest_RequestBody
        /// <summary>
        /// <para>
        /// <para>Request body JSON for the Privy API call</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PaymentTokenRequest_StripePrivyTokenRequest_RequestBody { get; set; }
        #endregion
        
        #region Parameter PaymentTokenRequest_CoinbaseCdpTokenRequest_RequestHost
        /// <summary>
        /// <para>
        /// <para>Optional - defaults to "api.cdp.coinbase.com"</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PaymentTokenRequest_CoinbaseCdpTokenRequest_RequestHost { get; set; }
        #endregion
        
        #region Parameter PaymentTokenRequest_StripePrivyTokenRequest_RequestHost
        /// <summary>
        /// <para>
        /// <para>Optional - defaults to "api.privy.io"</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PaymentTokenRequest_StripePrivyTokenRequest_RequestHost { get; set; }
        #endregion
        
        #region Parameter PaymentTokenRequest_CoinbaseCdpTokenRequest_RequestMethod
        /// <summary>
        /// <para>
        /// <para>The HTTP method for the payment API request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCore.PaymentHttpMethodType")]
        public Amazon.BedrockAgentCore.PaymentHttpMethodType PaymentTokenRequest_CoinbaseCdpTokenRequest_RequestMethod { get; set; }
        #endregion
        
        #region Parameter PaymentTokenRequest_CoinbaseCdpTokenRequest_RequestPath
        /// <summary>
        /// <para>
        /// <para>The path of the payment API request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PaymentTokenRequest_CoinbaseCdpTokenRequest_RequestPath { get; set; }
        #endregion
        
        #region Parameter PaymentTokenRequest_StripePrivyTokenRequest_RequestPath
        /// <summary>
        /// <para>
        /// <para>The path of the Stripe Privy API request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PaymentTokenRequest_StripePrivyTokenRequest_RequestPath { get; set; }
        #endregion
        
        #region Parameter ResourceCredentialProviderName
        /// <summary>
        /// <para>
        /// <para>Name of the payment credential provider to use</para>
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
        
        #region Parameter WorkloadIdentityToken
        /// <summary>
        /// <para>
        /// <para>Workload access token for authorization. Named workloadIdentityToken for consistency
        /// with APIKey and OAuth2CredentialProvider.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PaymentTokenResponse'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCore.Model.GetResourcePaymentTokenResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCore.Model.GetResourcePaymentTokenResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PaymentTokenResponse";
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
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCore.Model.GetResourcePaymentTokenResponse, GetBACResourcePaymentTokenCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.PaymentTokenRequest_CoinbaseCdpTokenRequest_IncludeWalletAuthToken = this.PaymentTokenRequest_CoinbaseCdpTokenRequest_IncludeWalletAuthToken;
            context.PaymentTokenRequest_CoinbaseCdpTokenRequest_RequestBody = this.PaymentTokenRequest_CoinbaseCdpTokenRequest_RequestBody;
            context.PaymentTokenRequest_CoinbaseCdpTokenRequest_RequestHost = this.PaymentTokenRequest_CoinbaseCdpTokenRequest_RequestHost;
            context.PaymentTokenRequest_CoinbaseCdpTokenRequest_RequestMethod = this.PaymentTokenRequest_CoinbaseCdpTokenRequest_RequestMethod;
            context.PaymentTokenRequest_CoinbaseCdpTokenRequest_RequestPath = this.PaymentTokenRequest_CoinbaseCdpTokenRequest_RequestPath;
            context.PaymentTokenRequest_StripePrivyTokenRequest_IncludeAuthorizationSignature = this.PaymentTokenRequest_StripePrivyTokenRequest_IncludeAuthorizationSignature;
            context.PaymentTokenRequest_StripePrivyTokenRequest_RequestBody = this.PaymentTokenRequest_StripePrivyTokenRequest_RequestBody;
            context.PaymentTokenRequest_StripePrivyTokenRequest_RequestHost = this.PaymentTokenRequest_StripePrivyTokenRequest_RequestHost;
            context.PaymentTokenRequest_StripePrivyTokenRequest_RequestPath = this.PaymentTokenRequest_StripePrivyTokenRequest_RequestPath;
            context.ResourceCredentialProviderName = this.ResourceCredentialProviderName;
            #if MODULAR
            if (this.ResourceCredentialProviderName == null && ParameterWasBound(nameof(this.ResourceCredentialProviderName)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceCredentialProviderName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.BedrockAgentCore.Model.GetResourcePaymentTokenRequest();
            
            
             // populate PaymentTokenRequest
            var requestPaymentTokenRequestIsNull = true;
            request.PaymentTokenRequest = new Amazon.BedrockAgentCore.Model.PaymentTokenRequestInput();
            Amazon.BedrockAgentCore.Model.StripePrivyTokenRequestInput requestPaymentTokenRequest_paymentTokenRequest_StripePrivyTokenRequest = null;
            
             // populate StripePrivyTokenRequest
            var requestPaymentTokenRequest_paymentTokenRequest_StripePrivyTokenRequestIsNull = true;
            requestPaymentTokenRequest_paymentTokenRequest_StripePrivyTokenRequest = new Amazon.BedrockAgentCore.Model.StripePrivyTokenRequestInput();
            System.Boolean? requestPaymentTokenRequest_paymentTokenRequest_StripePrivyTokenRequest_paymentTokenRequest_StripePrivyTokenRequest_IncludeAuthorizationSignature = null;
            if (cmdletContext.PaymentTokenRequest_StripePrivyTokenRequest_IncludeAuthorizationSignature != null)
            {
                requestPaymentTokenRequest_paymentTokenRequest_StripePrivyTokenRequest_paymentTokenRequest_StripePrivyTokenRequest_IncludeAuthorizationSignature = cmdletContext.PaymentTokenRequest_StripePrivyTokenRequest_IncludeAuthorizationSignature.Value;
            }
            if (requestPaymentTokenRequest_paymentTokenRequest_StripePrivyTokenRequest_paymentTokenRequest_StripePrivyTokenRequest_IncludeAuthorizationSignature != null)
            {
                requestPaymentTokenRequest_paymentTokenRequest_StripePrivyTokenRequest.IncludeAuthorizationSignature = requestPaymentTokenRequest_paymentTokenRequest_StripePrivyTokenRequest_paymentTokenRequest_StripePrivyTokenRequest_IncludeAuthorizationSignature.Value;
                requestPaymentTokenRequest_paymentTokenRequest_StripePrivyTokenRequestIsNull = false;
            }
            System.String requestPaymentTokenRequest_paymentTokenRequest_StripePrivyTokenRequest_paymentTokenRequest_StripePrivyTokenRequest_RequestBody = null;
            if (cmdletContext.PaymentTokenRequest_StripePrivyTokenRequest_RequestBody != null)
            {
                requestPaymentTokenRequest_paymentTokenRequest_StripePrivyTokenRequest_paymentTokenRequest_StripePrivyTokenRequest_RequestBody = cmdletContext.PaymentTokenRequest_StripePrivyTokenRequest_RequestBody;
            }
            if (requestPaymentTokenRequest_paymentTokenRequest_StripePrivyTokenRequest_paymentTokenRequest_StripePrivyTokenRequest_RequestBody != null)
            {
                requestPaymentTokenRequest_paymentTokenRequest_StripePrivyTokenRequest.RequestBody = requestPaymentTokenRequest_paymentTokenRequest_StripePrivyTokenRequest_paymentTokenRequest_StripePrivyTokenRequest_RequestBody;
                requestPaymentTokenRequest_paymentTokenRequest_StripePrivyTokenRequestIsNull = false;
            }
            System.String requestPaymentTokenRequest_paymentTokenRequest_StripePrivyTokenRequest_paymentTokenRequest_StripePrivyTokenRequest_RequestHost = null;
            if (cmdletContext.PaymentTokenRequest_StripePrivyTokenRequest_RequestHost != null)
            {
                requestPaymentTokenRequest_paymentTokenRequest_StripePrivyTokenRequest_paymentTokenRequest_StripePrivyTokenRequest_RequestHost = cmdletContext.PaymentTokenRequest_StripePrivyTokenRequest_RequestHost;
            }
            if (requestPaymentTokenRequest_paymentTokenRequest_StripePrivyTokenRequest_paymentTokenRequest_StripePrivyTokenRequest_RequestHost != null)
            {
                requestPaymentTokenRequest_paymentTokenRequest_StripePrivyTokenRequest.RequestHost = requestPaymentTokenRequest_paymentTokenRequest_StripePrivyTokenRequest_paymentTokenRequest_StripePrivyTokenRequest_RequestHost;
                requestPaymentTokenRequest_paymentTokenRequest_StripePrivyTokenRequestIsNull = false;
            }
            System.String requestPaymentTokenRequest_paymentTokenRequest_StripePrivyTokenRequest_paymentTokenRequest_StripePrivyTokenRequest_RequestPath = null;
            if (cmdletContext.PaymentTokenRequest_StripePrivyTokenRequest_RequestPath != null)
            {
                requestPaymentTokenRequest_paymentTokenRequest_StripePrivyTokenRequest_paymentTokenRequest_StripePrivyTokenRequest_RequestPath = cmdletContext.PaymentTokenRequest_StripePrivyTokenRequest_RequestPath;
            }
            if (requestPaymentTokenRequest_paymentTokenRequest_StripePrivyTokenRequest_paymentTokenRequest_StripePrivyTokenRequest_RequestPath != null)
            {
                requestPaymentTokenRequest_paymentTokenRequest_StripePrivyTokenRequest.RequestPath = requestPaymentTokenRequest_paymentTokenRequest_StripePrivyTokenRequest_paymentTokenRequest_StripePrivyTokenRequest_RequestPath;
                requestPaymentTokenRequest_paymentTokenRequest_StripePrivyTokenRequestIsNull = false;
            }
             // determine if requestPaymentTokenRequest_paymentTokenRequest_StripePrivyTokenRequest should be set to null
            if (requestPaymentTokenRequest_paymentTokenRequest_StripePrivyTokenRequestIsNull)
            {
                requestPaymentTokenRequest_paymentTokenRequest_StripePrivyTokenRequest = null;
            }
            if (requestPaymentTokenRequest_paymentTokenRequest_StripePrivyTokenRequest != null)
            {
                request.PaymentTokenRequest.StripePrivyTokenRequest = requestPaymentTokenRequest_paymentTokenRequest_StripePrivyTokenRequest;
                requestPaymentTokenRequestIsNull = false;
            }
            Amazon.BedrockAgentCore.Model.CoinbaseCdpTokenRequestInput requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest = null;
            
             // populate CoinbaseCdpTokenRequest
            var requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequestIsNull = true;
            requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest = new Amazon.BedrockAgentCore.Model.CoinbaseCdpTokenRequestInput();
            System.Boolean? requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_IncludeWalletAuthToken = null;
            if (cmdletContext.PaymentTokenRequest_CoinbaseCdpTokenRequest_IncludeWalletAuthToken != null)
            {
                requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_IncludeWalletAuthToken = cmdletContext.PaymentTokenRequest_CoinbaseCdpTokenRequest_IncludeWalletAuthToken.Value;
            }
            if (requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_IncludeWalletAuthToken != null)
            {
                requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest.IncludeWalletAuthToken = requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_IncludeWalletAuthToken.Value;
                requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequestIsNull = false;
            }
            System.String requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_RequestBody = null;
            if (cmdletContext.PaymentTokenRequest_CoinbaseCdpTokenRequest_RequestBody != null)
            {
                requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_RequestBody = cmdletContext.PaymentTokenRequest_CoinbaseCdpTokenRequest_RequestBody;
            }
            if (requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_RequestBody != null)
            {
                requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest.RequestBody = requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_RequestBody;
                requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequestIsNull = false;
            }
            System.String requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_RequestHost = null;
            if (cmdletContext.PaymentTokenRequest_CoinbaseCdpTokenRequest_RequestHost != null)
            {
                requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_RequestHost = cmdletContext.PaymentTokenRequest_CoinbaseCdpTokenRequest_RequestHost;
            }
            if (requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_RequestHost != null)
            {
                requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest.RequestHost = requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_RequestHost;
                requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequestIsNull = false;
            }
            Amazon.BedrockAgentCore.PaymentHttpMethodType requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_RequestMethod = null;
            if (cmdletContext.PaymentTokenRequest_CoinbaseCdpTokenRequest_RequestMethod != null)
            {
                requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_RequestMethod = cmdletContext.PaymentTokenRequest_CoinbaseCdpTokenRequest_RequestMethod;
            }
            if (requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_RequestMethod != null)
            {
                requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest.RequestMethod = requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_RequestMethod;
                requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequestIsNull = false;
            }
            System.String requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_RequestPath = null;
            if (cmdletContext.PaymentTokenRequest_CoinbaseCdpTokenRequest_RequestPath != null)
            {
                requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_RequestPath = cmdletContext.PaymentTokenRequest_CoinbaseCdpTokenRequest_RequestPath;
            }
            if (requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_RequestPath != null)
            {
                requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest.RequestPath = requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest_RequestPath;
                requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequestIsNull = false;
            }
             // determine if requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest should be set to null
            if (requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequestIsNull)
            {
                requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest = null;
            }
            if (requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest != null)
            {
                request.PaymentTokenRequest.CoinbaseCdpTokenRequest = requestPaymentTokenRequest_paymentTokenRequest_CoinbaseCdpTokenRequest;
                requestPaymentTokenRequestIsNull = false;
            }
             // determine if request.PaymentTokenRequest should be set to null
            if (requestPaymentTokenRequestIsNull)
            {
                request.PaymentTokenRequest = null;
            }
            if (cmdletContext.ResourceCredentialProviderName != null)
            {
                request.ResourceCredentialProviderName = cmdletContext.ResourceCredentialProviderName;
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
        
        private Amazon.BedrockAgentCore.Model.GetResourcePaymentTokenResponse CallAWSServiceOperation(IAmazonBedrockAgentCore client, Amazon.BedrockAgentCore.Model.GetResourcePaymentTokenRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock AgentCore Data Plane Fronting Layer", "GetResourcePaymentToken");
            try
            {
                return client.GetResourcePaymentTokenAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? PaymentTokenRequest_CoinbaseCdpTokenRequest_IncludeWalletAuthToken { get; set; }
            public System.String PaymentTokenRequest_CoinbaseCdpTokenRequest_RequestBody { get; set; }
            public System.String PaymentTokenRequest_CoinbaseCdpTokenRequest_RequestHost { get; set; }
            public Amazon.BedrockAgentCore.PaymentHttpMethodType PaymentTokenRequest_CoinbaseCdpTokenRequest_RequestMethod { get; set; }
            public System.String PaymentTokenRequest_CoinbaseCdpTokenRequest_RequestPath { get; set; }
            public System.Boolean? PaymentTokenRequest_StripePrivyTokenRequest_IncludeAuthorizationSignature { get; set; }
            public System.String PaymentTokenRequest_StripePrivyTokenRequest_RequestBody { get; set; }
            public System.String PaymentTokenRequest_StripePrivyTokenRequest_RequestHost { get; set; }
            public System.String PaymentTokenRequest_StripePrivyTokenRequest_RequestPath { get; set; }
            public System.String ResourceCredentialProviderName { get; set; }
            public System.String WorkloadIdentityToken { get; set; }
            public System.Func<Amazon.BedrockAgentCore.Model.GetResourcePaymentTokenResponse, GetBACResourcePaymentTokenCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PaymentTokenResponse;
        }
        
    }
}
