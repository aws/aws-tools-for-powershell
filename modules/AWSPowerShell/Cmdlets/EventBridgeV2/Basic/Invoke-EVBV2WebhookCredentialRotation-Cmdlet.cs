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
using Amazon.EventBridgeV2;
using Amazon.EventBridgeV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EVBV2
{
    /// <summary>
    /// Sets a new credential on a webhook EventSource. If you supply Credential, EventBridge
    /// uses that value. Otherwise, EventBridge generates one. For HTTP Basic authentication,
    /// only the password changes. The username does not change. EventBridge never returns
    /// the credential. To read a generated value, call secretsmanager:GetSecretValue on the
    /// secret that SecretArn identifies.
    /// 
    ///  
    /// <para>
    /// You can rotate the credential of an EventSource in the ACTIVE, UPDATING, or UPDATE_FAILED
    /// state. For a revoked EventSource or an EventSource in any other state, EventBridge
    /// returns InvalidStateException. EventBridge also returns InvalidStateException if the
    /// secret of the EventSource is scheduled for deletion or has been deleted.
    /// </para><para>
    /// If you rotate the credential of one EventSource too many times in 24 hours, EventBridge
    /// returns LimitExceededException. Retry later. The limit becomes available again automatically.
    /// </para><para>
    /// If AWS Secrets Manager throttles the call, EventBridge returns ThrottlingException.
    /// Retry later.
    /// </para><para>
    /// To use this operation, you must have the following permissions in your IAM policy:
    /// </para><ul><li><para>
    /// secretsmanager:PutSecretValue on the secret of the EventSource
    /// </para></li><li><para>
    /// secretsmanager:GetSecretValue on the secret of the EventSource, for HTTP Basic authentication
    /// only
    /// </para></li><li><para>
    /// kms:GenerateDataKey and kms:Decrypt on the AWS KMS key that encrypts the secret
    /// </para></li></ul><para>
    /// The resource policy of the secret must not deny the secretsmanager actions.
    /// </para><para>
    /// EventBridge accepts the new credential when this call returns. In rare cases, the
    /// new credential takes up to 2 minutes to reach every EventBridge endpoint.
    /// </para><para>
    /// EventBridge also accepts the previous credential for 15 minutes after the rotation.
    /// The window ends at the CreatedDate of the AWSCURRENT secret version plus 15 minutes.
    /// Only the credential that the most recent rotation replaced stays valid. If you rotate
    /// again within 15 minutes, the older credential stops working immediately.
    /// </para><para>
    /// A retry with the same ClientToken within 8 hours returns the same result and does
    /// not rotate again. A retry of a rotation that supplied a value can arrive after a later
    /// rotation completed. In that case, the retried value becomes the current credential,
    /// and the credential it replaces does not stay valid.
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "EVBV2WebhookCredentialRotation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon EventBridgeV2 RotateWebhookCredentials API operation.", Operation = new[] {"RotateWebhookCredentials"}, SelectReturnType = typeof(Amazon.EventBridgeV2.Model.RotateWebhookCredentialsResponse))]
    [AWSCmdletOutput("System.String or Amazon.EventBridgeV2.Model.RotateWebhookCredentialsResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.EventBridgeV2.Model.RotateWebhookCredentialsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class InvokeEVBV2WebhookCredentialRotationCmdlet : AmazonEventBridgeV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Credential_BasicHttpPassword
        /// <summary>
        /// <para>
        /// <para>The new password for HTTP Basic authentication. The username does not change.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Credential_BasicHttpPassword { get; set; }
        #endregion
        
        #region Parameter EventSourceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the webhook EventSource.</para>
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
        public System.String EventSourceArn { get; set; }
        #endregion
        
        #region Parameter Credential_HmacSecretValue
        /// <summary>
        /// <para>
        /// <para>The new HMAC secret, in the SecretEncoding of the EventSource. With BASE64, EventBridge
        /// removes a leading "whsec_". The key must be 16 to 512 bytes; with BASE64 SecretEncoding,
        /// this is measured after decoding.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Credential_HmacSecretValue { get; set; }
        #endregion
        
        #region Parameter Credential_StaticTokenSecretValue
        /// <summary>
        /// <para>
        /// <para>The new token for static token authentication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Credential_StaticTokenSecretValue { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that ensures the idempotency of the request. The
        /// SDK generates one automatically when the field is omitted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SecretArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EventBridgeV2.Model.RotateWebhookCredentialsResponse).
        /// Specifying the name of a property of type Amazon.EventBridgeV2.Model.RotateWebhookCredentialsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SecretArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EventSourceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-EVBV2WebhookCredentialRotation (RotateWebhookCredentials)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EventBridgeV2.Model.RotateWebhookCredentialsResponse, InvokeEVBV2WebhookCredentialRotationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Credential_BasicHttpPassword = this.Credential_BasicHttpPassword;
            context.Credential_HmacSecretValue = this.Credential_HmacSecretValue;
            context.Credential_StaticTokenSecretValue = this.Credential_StaticTokenSecretValue;
            context.EventSourceArn = this.EventSourceArn;
            #if MODULAR
            if (this.EventSourceArn == null && ParameterWasBound(nameof(this.EventSourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter EventSourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EventBridgeV2.Model.RotateWebhookCredentialsRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate Credential
            var requestCredentialIsNull = true;
            request.Credential = new Amazon.EventBridgeV2.Model.WebhookCredential();
            System.String requestCredential_credential_BasicHttpPassword = null;
            if (cmdletContext.Credential_BasicHttpPassword != null)
            {
                requestCredential_credential_BasicHttpPassword = cmdletContext.Credential_BasicHttpPassword;
            }
            if (requestCredential_credential_BasicHttpPassword != null)
            {
                request.Credential.BasicHttpPassword = requestCredential_credential_BasicHttpPassword;
                requestCredentialIsNull = false;
            }
            System.String requestCredential_credential_HmacSecretValue = null;
            if (cmdletContext.Credential_HmacSecretValue != null)
            {
                requestCredential_credential_HmacSecretValue = cmdletContext.Credential_HmacSecretValue;
            }
            if (requestCredential_credential_HmacSecretValue != null)
            {
                request.Credential.HmacSecretValue = requestCredential_credential_HmacSecretValue;
                requestCredentialIsNull = false;
            }
            System.String requestCredential_credential_StaticTokenSecretValue = null;
            if (cmdletContext.Credential_StaticTokenSecretValue != null)
            {
                requestCredential_credential_StaticTokenSecretValue = cmdletContext.Credential_StaticTokenSecretValue;
            }
            if (requestCredential_credential_StaticTokenSecretValue != null)
            {
                request.Credential.StaticTokenSecretValue = requestCredential_credential_StaticTokenSecretValue;
                requestCredentialIsNull = false;
            }
             // determine if request.Credential should be set to null
            if (requestCredentialIsNull)
            {
                request.Credential = null;
            }
            if (cmdletContext.EventSourceArn != null)
            {
                request.EventSourceArn = cmdletContext.EventSourceArn;
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
        
        private Amazon.EventBridgeV2.Model.RotateWebhookCredentialsResponse CallAWSServiceOperation(IAmazonEventBridgeV2 client, Amazon.EventBridgeV2.Model.RotateWebhookCredentialsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EventBridgeV2", "RotateWebhookCredentials");
            try
            {
                return client.RotateWebhookCredentialsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Credential_BasicHttpPassword { get; set; }
            public System.String Credential_HmacSecretValue { get; set; }
            public System.String Credential_StaticTokenSecretValue { get; set; }
            public System.String EventSourceArn { get; set; }
            public System.Func<Amazon.EventBridgeV2.Model.RotateWebhookCredentialsResponse, InvokeEVBV2WebhookCredentialRotationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SecretArn;
        }
        
    }
}
