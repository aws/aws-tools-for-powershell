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
    /// Process a payment transaction
    /// </summary>
    [Cmdlet("Invoke", "BACPayment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCore.Model.ProcessPaymentResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock AgentCore Data Plane Fronting Layer ProcessPayment API operation.", Operation = new[] {"ProcessPayment"}, SelectReturnType = typeof(Amazon.BedrockAgentCore.Model.ProcessPaymentResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCore.Model.ProcessPaymentResponse",
        "This cmdlet returns an Amazon.BedrockAgentCore.Model.ProcessPaymentResponse object containing multiple properties."
    )]
    public partial class InvokeBACPaymentCmdlet : AmazonBedrockAgentCoreClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AgentName
        /// <summary>
        /// <para>
        /// <para>The agent name associated with this request, used for observability.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AgentName { get; set; }
        #endregion
        
        #region Parameter PaymentInput_CryptoX402_Payload
        /// <summary>
        /// <para>
        /// <para>This can hold any JSON-like object</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Management.Automation.PSObject PaymentInput_CryptoX402_Payload { get; set; }
        #endregion
        
        #region Parameter PaymentInstrumentId
        /// <summary>
        /// <para>
        /// <para>The ID of the payment instrument to use for this transaction.</para>
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
        public System.String PaymentInstrumentId { get; set; }
        #endregion
        
        #region Parameter PaymentManagerArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the payment manager handling this payment.</para>
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
        public System.String PaymentManagerArn { get; set; }
        #endregion
        
        #region Parameter PaymentSessionId
        /// <summary>
        /// <para>
        /// <para>The ID of the payment session for this transaction.</para>
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
        public System.String PaymentSessionId { get; set; }
        #endregion
        
        #region Parameter PaymentType
        /// <summary>
        /// <para>
        /// <para>The type of payment being processed.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.BedrockAgentCore.PaymentType")]
        public Amazon.BedrockAgentCore.PaymentType PaymentType { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>The user ID associated with this payment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserId { get; set; }
        #endregion
        
        #region Parameter PaymentInput_CryptoX402_Version
        /// <summary>
        /// <para>
        /// <para>The X402 protocol version (e.g., "v1", "v2")</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PaymentInput_CryptoX402_Version { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Idempotency token to ensure request uniqueness.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCore.Model.ProcessPaymentResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCore.Model.ProcessPaymentResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PaymentInstrumentId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-BACPayment (ProcessPayment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCore.Model.ProcessPaymentResponse, InvokeBACPaymentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AgentName = this.AgentName;
            context.ClientToken = this.ClientToken;
            context.PaymentInput_CryptoX402_Payload = this.PaymentInput_CryptoX402_Payload;
            context.PaymentInput_CryptoX402_Version = this.PaymentInput_CryptoX402_Version;
            context.PaymentInstrumentId = this.PaymentInstrumentId;
            #if MODULAR
            if (this.PaymentInstrumentId == null && ParameterWasBound(nameof(this.PaymentInstrumentId)))
            {
                WriteWarning("You are passing $null as a value for parameter PaymentInstrumentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PaymentManagerArn = this.PaymentManagerArn;
            #if MODULAR
            if (this.PaymentManagerArn == null && ParameterWasBound(nameof(this.PaymentManagerArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PaymentManagerArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PaymentSessionId = this.PaymentSessionId;
            #if MODULAR
            if (this.PaymentSessionId == null && ParameterWasBound(nameof(this.PaymentSessionId)))
            {
                WriteWarning("You are passing $null as a value for parameter PaymentSessionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PaymentType = this.PaymentType;
            #if MODULAR
            if (this.PaymentType == null && ParameterWasBound(nameof(this.PaymentType)))
            {
                WriteWarning("You are passing $null as a value for parameter PaymentType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UserId = this.UserId;
            
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
            var request = new Amazon.BedrockAgentCore.Model.ProcessPaymentRequest();
            
            if (cmdletContext.AgentName != null)
            {
                request.AgentName = cmdletContext.AgentName;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate PaymentInput
            var requestPaymentInputIsNull = true;
            request.PaymentInput = new Amazon.BedrockAgentCore.Model.PaymentInput();
            Amazon.BedrockAgentCore.Model.CryptoX402PaymentInput requestPaymentInput_paymentInput_CryptoX402 = null;
            
             // populate CryptoX402
            var requestPaymentInput_paymentInput_CryptoX402IsNull = true;
            requestPaymentInput_paymentInput_CryptoX402 = new Amazon.BedrockAgentCore.Model.CryptoX402PaymentInput();
            Amazon.Runtime.Documents.Document? requestPaymentInput_paymentInput_CryptoX402_paymentInput_CryptoX402_Payload = null;
            if (cmdletContext.PaymentInput_CryptoX402_Payload != null)
            {
                requestPaymentInput_paymentInput_CryptoX402_paymentInput_CryptoX402_Payload = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.PaymentInput_CryptoX402_Payload);
            }
            if (requestPaymentInput_paymentInput_CryptoX402_paymentInput_CryptoX402_Payload != null)
            {
                requestPaymentInput_paymentInput_CryptoX402.Payload = requestPaymentInput_paymentInput_CryptoX402_paymentInput_CryptoX402_Payload.Value;
                requestPaymentInput_paymentInput_CryptoX402IsNull = false;
            }
            System.String requestPaymentInput_paymentInput_CryptoX402_paymentInput_CryptoX402_Version = null;
            if (cmdletContext.PaymentInput_CryptoX402_Version != null)
            {
                requestPaymentInput_paymentInput_CryptoX402_paymentInput_CryptoX402_Version = cmdletContext.PaymentInput_CryptoX402_Version;
            }
            if (requestPaymentInput_paymentInput_CryptoX402_paymentInput_CryptoX402_Version != null)
            {
                requestPaymentInput_paymentInput_CryptoX402.Version = requestPaymentInput_paymentInput_CryptoX402_paymentInput_CryptoX402_Version;
                requestPaymentInput_paymentInput_CryptoX402IsNull = false;
            }
             // determine if requestPaymentInput_paymentInput_CryptoX402 should be set to null
            if (requestPaymentInput_paymentInput_CryptoX402IsNull)
            {
                requestPaymentInput_paymentInput_CryptoX402 = null;
            }
            if (requestPaymentInput_paymentInput_CryptoX402 != null)
            {
                request.PaymentInput.CryptoX402 = requestPaymentInput_paymentInput_CryptoX402;
                requestPaymentInputIsNull = false;
            }
             // determine if request.PaymentInput should be set to null
            if (requestPaymentInputIsNull)
            {
                request.PaymentInput = null;
            }
            if (cmdletContext.PaymentInstrumentId != null)
            {
                request.PaymentInstrumentId = cmdletContext.PaymentInstrumentId;
            }
            if (cmdletContext.PaymentManagerArn != null)
            {
                request.PaymentManagerArn = cmdletContext.PaymentManagerArn;
            }
            if (cmdletContext.PaymentSessionId != null)
            {
                request.PaymentSessionId = cmdletContext.PaymentSessionId;
            }
            if (cmdletContext.PaymentType != null)
            {
                request.PaymentType = cmdletContext.PaymentType;
            }
            if (cmdletContext.UserId != null)
            {
                request.UserId = cmdletContext.UserId;
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
        
        private Amazon.BedrockAgentCore.Model.ProcessPaymentResponse CallAWSServiceOperation(IAmazonBedrockAgentCore client, Amazon.BedrockAgentCore.Model.ProcessPaymentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock AgentCore Data Plane Fronting Layer", "ProcessPayment");
            try
            {
                return client.ProcessPaymentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AgentName { get; set; }
            public System.String ClientToken { get; set; }
            public System.Management.Automation.PSObject PaymentInput_CryptoX402_Payload { get; set; }
            public System.String PaymentInput_CryptoX402_Version { get; set; }
            public System.String PaymentInstrumentId { get; set; }
            public System.String PaymentManagerArn { get; set; }
            public System.String PaymentSessionId { get; set; }
            public Amazon.BedrockAgentCore.PaymentType PaymentType { get; set; }
            public System.String UserId { get; set; }
            public System.Func<Amazon.BedrockAgentCore.Model.ProcessPaymentResponse, InvokeBACPaymentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
