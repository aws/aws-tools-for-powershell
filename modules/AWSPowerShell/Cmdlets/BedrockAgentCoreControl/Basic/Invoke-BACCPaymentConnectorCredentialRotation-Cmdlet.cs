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
    /// Replaces the service-managed credentials of a payment connector with newly issued
    /// credentials.
    /// 
    ///  
    /// <para>
    /// Use this operation only for payment connectors with a <c>provisionMode</c> of <c>QUICK_CREATE</c>.
    /// For payment connectors with a <c>provisionMode</c> of <c>MANUAL</c>, call <c>UpdatePaymentCredentialProvider</c>
    /// instead after rotating credentials with the payment provider directly.
    /// </para><para>
    /// The rotation finishes before the response is returned, and only one rotation runs
    /// at a time for a given payment connector. When it succeeds, the new credential is in
    /// effect and the payment connector stays in the <c>READY</c> state. When it fails, an
    /// error is returned, the payment connector and its existing credential are left unchanged,
    /// and you can retry the request.
    /// </para><para>
    /// Rotation replaces the credential on the connector's credential provider, so every
    /// payment connector that uses that provider is affected. Replace any copy of the previous
    /// credential that you use outside AgentCore.
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "BACCPaymentConnectorCredentialRotation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCoreControl.Model.RotatePaymentConnectorCredentialsResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Core Control Plane Fronting Layer RotatePaymentConnectorCredentials API operation.", Operation = new[] {"RotatePaymentConnectorCredentials"}, SelectReturnType = typeof(Amazon.BedrockAgentCoreControl.Model.RotatePaymentConnectorCredentialsResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCoreControl.Model.RotatePaymentConnectorCredentialsResponse",
        "This cmdlet returns an Amazon.BedrockAgentCoreControl.Model.RotatePaymentConnectorCredentialsResponse object containing multiple properties."
    )]
    public partial class InvokeBACCPaymentConnectorCredentialRotationCmdlet : AmazonBedrockAgentCoreControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter PaymentConnectorId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the payment connector whose credentials you want to rotate.</para>
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
        public System.String PaymentConnectorId { get; set; }
        #endregion
        
        #region Parameter PaymentManagerId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the parent payment manager.</para>
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
        public System.String PaymentManagerId { get; set; }
        #endregion
        
        #region Parameter CredentialsToRotate_CoinbaseCDP_Secret
        /// <summary>
        /// <para>
        /// <para>The secrets to rotate. Specify at least one value. Each secret that you specify is
        /// rotated independently.</para><ul><li><para><c>API_KEY</c> - The API key that the payment connector uses to call Coinbase CDP.
        /// Rotate it as routine maintenance, or if you suspect that it is compromised.</para></li><li><para><c>WALLET_SECRET</c> - The wallet secret that signs transactions. Rotate it only
        /// if it is lost or compromised. Coinbase CDP allows one wallet secret per project, so
        /// it is replaced in place and signing can be briefly interrupted.</para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CredentialsToRotate_CoinbaseCDP_Secrets")]
        public System.String[] CredentialsToRotate_CoinbaseCDP_Secret { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCoreControl.Model.RotatePaymentConnectorCredentialsResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCoreControl.Model.RotatePaymentConnectorCredentialsResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.PaymentConnectorId),
                nameof(this.PaymentManagerId)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-BACCPaymentConnectorCredentialRotation (RotatePaymentConnectorCredentials)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCoreControl.Model.RotatePaymentConnectorCredentialsResponse, InvokeBACCPaymentConnectorCredentialRotationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            if (this.CredentialsToRotate_CoinbaseCDP_Secret != null)
            {
                context.CredentialsToRotate_CoinbaseCDP_Secret = new List<System.String>(this.CredentialsToRotate_CoinbaseCDP_Secret);
            }
            context.PaymentConnectorId = this.PaymentConnectorId;
            #if MODULAR
            if (this.PaymentConnectorId == null && ParameterWasBound(nameof(this.PaymentConnectorId)))
            {
                WriteWarning("You are passing $null as a value for parameter PaymentConnectorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PaymentManagerId = this.PaymentManagerId;
            #if MODULAR
            if (this.PaymentManagerId == null && ParameterWasBound(nameof(this.PaymentManagerId)))
            {
                WriteWarning("You are passing $null as a value for parameter PaymentManagerId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BedrockAgentCoreControl.Model.RotatePaymentConnectorCredentialsRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate CredentialsToRotate
            var requestCredentialsToRotateIsNull = true;
            request.CredentialsToRotate = new Amazon.BedrockAgentCoreControl.Model.CredentialRotationConfig();
            Amazon.BedrockAgentCoreControl.Model.CoinbaseCdpRotationTargets requestCredentialsToRotate_credentialsToRotate_CoinbaseCDP = null;
            
             // populate CoinbaseCDP
            var requestCredentialsToRotate_credentialsToRotate_CoinbaseCDPIsNull = true;
            requestCredentialsToRotate_credentialsToRotate_CoinbaseCDP = new Amazon.BedrockAgentCoreControl.Model.CoinbaseCdpRotationTargets();
            List<System.String> requestCredentialsToRotate_credentialsToRotate_CoinbaseCDP_credentialsToRotate_CoinbaseCDP_Secret = null;
            if (cmdletContext.CredentialsToRotate_CoinbaseCDP_Secret != null)
            {
                requestCredentialsToRotate_credentialsToRotate_CoinbaseCDP_credentialsToRotate_CoinbaseCDP_Secret = cmdletContext.CredentialsToRotate_CoinbaseCDP_Secret;
            }
            if (requestCredentialsToRotate_credentialsToRotate_CoinbaseCDP_credentialsToRotate_CoinbaseCDP_Secret != null)
            {
                requestCredentialsToRotate_credentialsToRotate_CoinbaseCDP.Secrets = requestCredentialsToRotate_credentialsToRotate_CoinbaseCDP_credentialsToRotate_CoinbaseCDP_Secret;
                requestCredentialsToRotate_credentialsToRotate_CoinbaseCDPIsNull = false;
            }
             // determine if requestCredentialsToRotate_credentialsToRotate_CoinbaseCDP should be set to null
            if (requestCredentialsToRotate_credentialsToRotate_CoinbaseCDPIsNull)
            {
                requestCredentialsToRotate_credentialsToRotate_CoinbaseCDP = null;
            }
            if (requestCredentialsToRotate_credentialsToRotate_CoinbaseCDP != null)
            {
                request.CredentialsToRotate.CoinbaseCDP = requestCredentialsToRotate_credentialsToRotate_CoinbaseCDP;
                requestCredentialsToRotateIsNull = false;
            }
             // determine if request.CredentialsToRotate should be set to null
            if (requestCredentialsToRotateIsNull)
            {
                request.CredentialsToRotate = null;
            }
            if (cmdletContext.PaymentConnectorId != null)
            {
                request.PaymentConnectorId = cmdletContext.PaymentConnectorId;
            }
            if (cmdletContext.PaymentManagerId != null)
            {
                request.PaymentManagerId = cmdletContext.PaymentManagerId;
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
        
        private Amazon.BedrockAgentCoreControl.Model.RotatePaymentConnectorCredentialsResponse CallAWSServiceOperation(IAmazonBedrockAgentCoreControl client, Amazon.BedrockAgentCoreControl.Model.RotatePaymentConnectorCredentialsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Core Control Plane Fronting Layer", "RotatePaymentConnectorCredentials");
            try
            {
                return client.RotatePaymentConnectorCredentialsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> CredentialsToRotate_CoinbaseCDP_Secret { get; set; }
            public System.String PaymentConnectorId { get; set; }
            public System.String PaymentManagerId { get; set; }
            public System.Func<Amazon.BedrockAgentCoreControl.Model.RotatePaymentConnectorCredentialsResponse, InvokeBACCPaymentConnectorCredentialRotationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
