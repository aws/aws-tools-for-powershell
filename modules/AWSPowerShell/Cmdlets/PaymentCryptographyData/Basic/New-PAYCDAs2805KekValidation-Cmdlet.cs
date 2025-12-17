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
using Amazon.PaymentCryptographyData;
using Amazon.PaymentCryptographyData.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PAYCD
{
    /// <summary>
    /// Establishes node-to-node initialization between payment processing nodes such as an
    /// acquirer, issuer or payment network using Australian Standard 2805 (AS2805).
    /// 
    ///  
    /// <para>
    /// During node-to-node initialization, both communicating nodes must validate that they
    /// possess the correct Key Encrypting Keys (KEKs) before proceeding with session key
    /// exchange. In AS2805, the sending KEK (KEKs) of one node corresponds to the receiving
    /// KEK (KEKr) of its partner node. Each node uses its KEK to encrypt and decrypt session
    /// keys exchanged between the nodes. A KEK can be created or imported into Amazon Web
    /// Services Payment Cryptography using either the <a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_CreateKey.html">CreateKey</a>
    /// or <a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_ImportKey.html">ImportKey</a>
    /// operations.
    /// </para><para>
    /// The node initiating communication can use <c>GenerateAS2805KekValidation</c> to generate
    /// a combined KEK validation request and KEK validation response to send to the partnering
    /// node for validation. When invoked, the API internally generates a random sending key
    /// encrypted under KEKs and provides a receiving key encrypted under KEKr as response.
    /// The initiating node sends the response returned by this API to its partner for validation.
    /// </para><para>
    /// For information about valid keys for this operation, see <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/keys-validattributes.html">Understanding
    /// key attributes</a> and <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/crypto-ops-validkeys-ops.html">Key
    /// types for specific data operations</a> in the <i>Amazon Web Services Payment Cryptography
    /// User Guide</i>. 
    /// </para><para><b>Cross-account use</b>: This operation can't be used across different Amazon Web
    /// Services accounts.
    /// </para>
    /// </summary>
    [Cmdlet("New", "PAYCDAs2805KekValidation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PaymentCryptographyData.Model.GenerateAs2805KekValidationResponse")]
    [AWSCmdlet("Calls the Payment Cryptography Data GenerateAs2805KekValidation API operation.", Operation = new[] {"GenerateAs2805KekValidation"}, SelectReturnType = typeof(Amazon.PaymentCryptographyData.Model.GenerateAs2805KekValidationResponse))]
    [AWSCmdletOutput("Amazon.PaymentCryptographyData.Model.GenerateAs2805KekValidationResponse",
        "This cmdlet returns an Amazon.PaymentCryptographyData.Model.GenerateAs2805KekValidationResponse object containing multiple properties."
    )]
    public partial class NewPAYCDAs2805KekValidationCmdlet : AmazonPaymentCryptographyDataClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter KekValidationType_KekValidationRequest_DeriveKeyAlgorithm
        /// <summary>
        /// <para>
        /// <para>The key derivation algorithm to use for generating a KEK validation request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.SymmetricKeyAlgorithm")]
        public Amazon.PaymentCryptographyData.SymmetricKeyAlgorithm KekValidationType_KekValidationRequest_DeriveKeyAlgorithm { get; set; }
        #endregion
        
        #region Parameter KeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>keyARN</c> of sending KEK that Amazon Web Services Payment Cryptography uses
        /// for node-to-node initialization</para>
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
        public System.String KeyIdentifier { get; set; }
        #endregion
        
        #region Parameter KekValidationType_KekValidationResponse_RandomKeySend
        /// <summary>
        /// <para>
        /// <para>The random key for generating a KEK validation response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KekValidationType_KekValidationResponse_RandomKeySend { get; set; }
        #endregion
        
        #region Parameter RandomKeySendVariantMask
        /// <summary>
        /// <para>
        /// <para>The key variant to use for generating a random key for KEK validation during node-to-node
        /// initialization.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.RandomKeySendVariantMask")]
        public Amazon.PaymentCryptographyData.RandomKeySendVariantMask RandomKeySendVariantMask { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PaymentCryptographyData.Model.GenerateAs2805KekValidationResponse).
        /// Specifying the name of a property of type Amazon.PaymentCryptographyData.Model.GenerateAs2805KekValidationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.KeyIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PAYCDAs2805KekValidation (GenerateAs2805KekValidation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PaymentCryptographyData.Model.GenerateAs2805KekValidationResponse, NewPAYCDAs2805KekValidationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.KekValidationType_KekValidationRequest_DeriveKeyAlgorithm = this.KekValidationType_KekValidationRequest_DeriveKeyAlgorithm;
            context.KekValidationType_KekValidationResponse_RandomKeySend = this.KekValidationType_KekValidationResponse_RandomKeySend;
            context.KeyIdentifier = this.KeyIdentifier;
            #if MODULAR
            if (this.KeyIdentifier == null && ParameterWasBound(nameof(this.KeyIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RandomKeySendVariantMask = this.RandomKeySendVariantMask;
            #if MODULAR
            if (this.RandomKeySendVariantMask == null && ParameterWasBound(nameof(this.RandomKeySendVariantMask)))
            {
                WriteWarning("You are passing $null as a value for parameter RandomKeySendVariantMask which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PaymentCryptographyData.Model.GenerateAs2805KekValidationRequest();
            
            
             // populate KekValidationType
            var requestKekValidationTypeIsNull = true;
            request.KekValidationType = new Amazon.PaymentCryptographyData.Model.As2805KekValidationType();
            Amazon.PaymentCryptographyData.Model.KekValidationRequest requestKekValidationType_kekValidationType_KekValidationRequest = null;
            
             // populate KekValidationRequest
            var requestKekValidationType_kekValidationType_KekValidationRequestIsNull = true;
            requestKekValidationType_kekValidationType_KekValidationRequest = new Amazon.PaymentCryptographyData.Model.KekValidationRequest();
            Amazon.PaymentCryptographyData.SymmetricKeyAlgorithm requestKekValidationType_kekValidationType_KekValidationRequest_kekValidationType_KekValidationRequest_DeriveKeyAlgorithm = null;
            if (cmdletContext.KekValidationType_KekValidationRequest_DeriveKeyAlgorithm != null)
            {
                requestKekValidationType_kekValidationType_KekValidationRequest_kekValidationType_KekValidationRequest_DeriveKeyAlgorithm = cmdletContext.KekValidationType_KekValidationRequest_DeriveKeyAlgorithm;
            }
            if (requestKekValidationType_kekValidationType_KekValidationRequest_kekValidationType_KekValidationRequest_DeriveKeyAlgorithm != null)
            {
                requestKekValidationType_kekValidationType_KekValidationRequest.DeriveKeyAlgorithm = requestKekValidationType_kekValidationType_KekValidationRequest_kekValidationType_KekValidationRequest_DeriveKeyAlgorithm;
                requestKekValidationType_kekValidationType_KekValidationRequestIsNull = false;
            }
             // determine if requestKekValidationType_kekValidationType_KekValidationRequest should be set to null
            if (requestKekValidationType_kekValidationType_KekValidationRequestIsNull)
            {
                requestKekValidationType_kekValidationType_KekValidationRequest = null;
            }
            if (requestKekValidationType_kekValidationType_KekValidationRequest != null)
            {
                request.KekValidationType.KekValidationRequest = requestKekValidationType_kekValidationType_KekValidationRequest;
                requestKekValidationTypeIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.KekValidationResponse requestKekValidationType_kekValidationType_KekValidationResponse = null;
            
             // populate KekValidationResponse
            var requestKekValidationType_kekValidationType_KekValidationResponseIsNull = true;
            requestKekValidationType_kekValidationType_KekValidationResponse = new Amazon.PaymentCryptographyData.Model.KekValidationResponse();
            System.String requestKekValidationType_kekValidationType_KekValidationResponse_kekValidationType_KekValidationResponse_RandomKeySend = null;
            if (cmdletContext.KekValidationType_KekValidationResponse_RandomKeySend != null)
            {
                requestKekValidationType_kekValidationType_KekValidationResponse_kekValidationType_KekValidationResponse_RandomKeySend = cmdletContext.KekValidationType_KekValidationResponse_RandomKeySend;
            }
            if (requestKekValidationType_kekValidationType_KekValidationResponse_kekValidationType_KekValidationResponse_RandomKeySend != null)
            {
                requestKekValidationType_kekValidationType_KekValidationResponse.RandomKeySend = requestKekValidationType_kekValidationType_KekValidationResponse_kekValidationType_KekValidationResponse_RandomKeySend;
                requestKekValidationType_kekValidationType_KekValidationResponseIsNull = false;
            }
             // determine if requestKekValidationType_kekValidationType_KekValidationResponse should be set to null
            if (requestKekValidationType_kekValidationType_KekValidationResponseIsNull)
            {
                requestKekValidationType_kekValidationType_KekValidationResponse = null;
            }
            if (requestKekValidationType_kekValidationType_KekValidationResponse != null)
            {
                request.KekValidationType.KekValidationResponse = requestKekValidationType_kekValidationType_KekValidationResponse;
                requestKekValidationTypeIsNull = false;
            }
             // determine if request.KekValidationType should be set to null
            if (requestKekValidationTypeIsNull)
            {
                request.KekValidationType = null;
            }
            if (cmdletContext.KeyIdentifier != null)
            {
                request.KeyIdentifier = cmdletContext.KeyIdentifier;
            }
            if (cmdletContext.RandomKeySendVariantMask != null)
            {
                request.RandomKeySendVariantMask = cmdletContext.RandomKeySendVariantMask;
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
        
        private Amazon.PaymentCryptographyData.Model.GenerateAs2805KekValidationResponse CallAWSServiceOperation(IAmazonPaymentCryptographyData client, Amazon.PaymentCryptographyData.Model.GenerateAs2805KekValidationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Payment Cryptography Data", "GenerateAs2805KekValidation");
            try
            {
                return client.GenerateAs2805KekValidationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.PaymentCryptographyData.SymmetricKeyAlgorithm KekValidationType_KekValidationRequest_DeriveKeyAlgorithm { get; set; }
            public System.String KekValidationType_KekValidationResponse_RandomKeySend { get; set; }
            public System.String KeyIdentifier { get; set; }
            public Amazon.PaymentCryptographyData.RandomKeySendVariantMask RandomKeySendVariantMask { get; set; }
            public System.Func<Amazon.PaymentCryptographyData.Model.GenerateAs2805KekValidationResponse, NewPAYCDAs2805KekValidationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
