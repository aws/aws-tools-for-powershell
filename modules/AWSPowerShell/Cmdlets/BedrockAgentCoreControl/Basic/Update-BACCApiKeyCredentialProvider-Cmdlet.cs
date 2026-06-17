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
    /// Updates an existing API key credential provider.
    /// </summary>
    [Cmdlet("Update", "BACCApiKeyCredentialProvider", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCoreControl.Model.UpdateApiKeyCredentialProviderResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Core Control Plane Fronting Layer UpdateApiKeyCredentialProvider API operation.", Operation = new[] {"UpdateApiKeyCredentialProvider"}, SelectReturnType = typeof(Amazon.BedrockAgentCoreControl.Model.UpdateApiKeyCredentialProviderResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCoreControl.Model.UpdateApiKeyCredentialProviderResponse",
        "This cmdlet returns an Amazon.BedrockAgentCoreControl.Model.UpdateApiKeyCredentialProviderResponse object containing multiple properties."
    )]
    public partial class UpdateBACCApiKeyCredentialProviderCmdlet : AmazonBedrockAgentCoreControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApiKey
        /// <summary>
        /// <para>
        /// <para>The new API key to use for authentication. This value replaces the existing API key
        /// and is encrypted and stored securely.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ApiKey { get; set; }
        #endregion
        
        #region Parameter ApiKeySecretSource
        /// <summary>
        /// <para>
        /// <para>The source type of the API key secret. Use <c>MANAGED</c> if the secret is managed
        /// by the service, or <c>EXTERNAL</c> if you manage the secret yourself in Amazon Web
        /// Services Secrets Manager.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.SecretSourceType")]
        public Amazon.BedrockAgentCoreControl.SecretSourceType ApiKeySecretSource { get; set; }
        #endregion
        
        #region Parameter ApiKeySecretConfig_JsonKey
        /// <summary>
        /// <para>
        /// <para>The JSON key used to extract the secret value from the Amazon Web Services Secrets
        /// Manager secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ApiKeySecretConfig_JsonKey { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the API key credential provider to update.</para>
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
        
        #region Parameter ApiKeySecretConfig_SecretId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services Secrets Manager secret that stores the secret value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ApiKeySecretConfig_SecretId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCoreControl.Model.UpdateApiKeyCredentialProviderResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCoreControl.Model.UpdateApiKeyCredentialProviderResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BACCApiKeyCredentialProvider (UpdateApiKeyCredentialProvider)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCoreControl.Model.UpdateApiKeyCredentialProviderResponse, UpdateBACCApiKeyCredentialProviderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApiKey = this.ApiKey;
            context.ApiKeySecretConfig_JsonKey = this.ApiKeySecretConfig_JsonKey;
            context.ApiKeySecretConfig_SecretId = this.ApiKeySecretConfig_SecretId;
            context.ApiKeySecretSource = this.ApiKeySecretSource;
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
            var request = new Amazon.BedrockAgentCoreControl.Model.UpdateApiKeyCredentialProviderRequest();
            
            if (cmdletContext.ApiKey != null)
            {
                request.ApiKey = cmdletContext.ApiKey;
            }
            
             // populate ApiKeySecretConfig
            var requestApiKeySecretConfigIsNull = true;
            request.ApiKeySecretConfig = new Amazon.BedrockAgentCoreControl.Model.SecretReference();
            System.String requestApiKeySecretConfig_apiKeySecretConfig_JsonKey = null;
            if (cmdletContext.ApiKeySecretConfig_JsonKey != null)
            {
                requestApiKeySecretConfig_apiKeySecretConfig_JsonKey = cmdletContext.ApiKeySecretConfig_JsonKey;
            }
            if (requestApiKeySecretConfig_apiKeySecretConfig_JsonKey != null)
            {
                request.ApiKeySecretConfig.JsonKey = requestApiKeySecretConfig_apiKeySecretConfig_JsonKey;
                requestApiKeySecretConfigIsNull = false;
            }
            System.String requestApiKeySecretConfig_apiKeySecretConfig_SecretId = null;
            if (cmdletContext.ApiKeySecretConfig_SecretId != null)
            {
                requestApiKeySecretConfig_apiKeySecretConfig_SecretId = cmdletContext.ApiKeySecretConfig_SecretId;
            }
            if (requestApiKeySecretConfig_apiKeySecretConfig_SecretId != null)
            {
                request.ApiKeySecretConfig.SecretId = requestApiKeySecretConfig_apiKeySecretConfig_SecretId;
                requestApiKeySecretConfigIsNull = false;
            }
             // determine if request.ApiKeySecretConfig should be set to null
            if (requestApiKeySecretConfigIsNull)
            {
                request.ApiKeySecretConfig = null;
            }
            if (cmdletContext.ApiKeySecretSource != null)
            {
                request.ApiKeySecretSource = cmdletContext.ApiKeySecretSource;
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
        
        private Amazon.BedrockAgentCoreControl.Model.UpdateApiKeyCredentialProviderResponse CallAWSServiceOperation(IAmazonBedrockAgentCoreControl client, Amazon.BedrockAgentCoreControl.Model.UpdateApiKeyCredentialProviderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Core Control Plane Fronting Layer", "UpdateApiKeyCredentialProvider");
            try
            {
                return client.UpdateApiKeyCredentialProviderAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ApiKey { get; set; }
            public System.String ApiKeySecretConfig_JsonKey { get; set; }
            public System.String ApiKeySecretConfig_SecretId { get; set; }
            public Amazon.BedrockAgentCoreControl.SecretSourceType ApiKeySecretSource { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.BedrockAgentCoreControl.Model.UpdateApiKeyCredentialProviderResponse, UpdateBACCApiKeyCredentialProviderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
