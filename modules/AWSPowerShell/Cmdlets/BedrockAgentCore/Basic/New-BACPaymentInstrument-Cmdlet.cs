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
    /// Create a new payment instrument for a connector.
    /// </summary>
    [Cmdlet("New", "BACPaymentInstrument", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCore.Model.PaymentInstrument")]
    [AWSCmdlet("Calls the Amazon Bedrock AgentCore Data Plane Fronting Layer CreatePaymentInstrument API operation.", Operation = new[] {"CreatePaymentInstrument"}, SelectReturnType = typeof(Amazon.BedrockAgentCore.Model.CreatePaymentInstrumentResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCore.Model.PaymentInstrument or Amazon.BedrockAgentCore.Model.CreatePaymentInstrumentResponse",
        "This cmdlet returns an Amazon.BedrockAgentCore.Model.PaymentInstrument object.",
        "The service call response (type Amazon.BedrockAgentCore.Model.CreatePaymentInstrumentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewBACPaymentInstrumentCmdlet : AmazonBedrockAgentCoreClientCmdlet, IExecutor
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
        
        #region Parameter PaymentInstrumentDetails_EmbeddedCryptoWallet_LinkedAccount
        /// <summary>
        /// <para>
        /// <para>List of linked accounts linked to this wallet. Each represents a way the end user
        /// can authenticate to this wallet.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PaymentInstrumentDetails_EmbeddedCryptoWallet_LinkedAccounts")]
        public Amazon.BedrockAgentCore.Model.LinkedAccount[] PaymentInstrumentDetails_EmbeddedCryptoWallet_LinkedAccount { get; set; }
        #endregion
        
        #region Parameter PaymentInstrumentDetails_EmbeddedCryptoWallet_Network
        /// <summary>
        /// <para>
        /// <para>The blockchain network for this embedded crypto wallet. Supported networks: ETHEREUM,
        /// SOLANA.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCore.CryptoWalletNetwork")]
        public Amazon.BedrockAgentCore.CryptoWalletNetwork PaymentInstrumentDetails_EmbeddedCryptoWallet_Network { get; set; }
        #endregion
        
        #region Parameter PaymentConnectorId
        /// <summary>
        /// <para>
        /// <para>The ID of the payment connector to use for this instrument.</para>
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
        
        #region Parameter PaymentInstrumentType
        /// <summary>
        /// <para>
        /// <para>The type of payment instrument being created.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.BedrockAgentCore.PaymentInstrumentType")]
        public Amazon.BedrockAgentCore.PaymentInstrumentType PaymentInstrumentType { get; set; }
        #endregion
        
        #region Parameter PaymentManagerArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the payment manager that owns this payment instrument.</para>
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
        
        #region Parameter PaymentInstrumentDetails_EmbeddedCryptoWallet_RedirectUrl
        /// <summary>
        /// <para>
        /// <para>URL for the end user to complete a provider-specific action such as wallet linking
        /// or onboarding.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PaymentInstrumentDetails_EmbeddedCryptoWallet_RedirectUrl { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>The user ID associated with this payment instrument.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserId { get; set; }
        #endregion
        
        #region Parameter PaymentInstrumentDetails_EmbeddedCryptoWallet_WalletAddress
        /// <summary>
        /// <para>
        /// <para>The wallet address on the specified blockchain network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PaymentInstrumentDetails_EmbeddedCryptoWallet_WalletAddress { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PaymentInstrument'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCore.Model.CreatePaymentInstrumentResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCore.Model.CreatePaymentInstrumentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PaymentInstrument";
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
                nameof(this.PaymentManagerArn)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BACPaymentInstrument (CreatePaymentInstrument)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCore.Model.CreatePaymentInstrumentResponse, NewBACPaymentInstrumentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AgentName = this.AgentName;
            context.ClientToken = this.ClientToken;
            context.PaymentConnectorId = this.PaymentConnectorId;
            #if MODULAR
            if (this.PaymentConnectorId == null && ParameterWasBound(nameof(this.PaymentConnectorId)))
            {
                WriteWarning("You are passing $null as a value for parameter PaymentConnectorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PaymentInstrumentDetails_EmbeddedCryptoWallet_LinkedAccount != null)
            {
                context.PaymentInstrumentDetails_EmbeddedCryptoWallet_LinkedAccount = new List<Amazon.BedrockAgentCore.Model.LinkedAccount>(this.PaymentInstrumentDetails_EmbeddedCryptoWallet_LinkedAccount);
            }
            context.PaymentInstrumentDetails_EmbeddedCryptoWallet_Network = this.PaymentInstrumentDetails_EmbeddedCryptoWallet_Network;
            context.PaymentInstrumentDetails_EmbeddedCryptoWallet_RedirectUrl = this.PaymentInstrumentDetails_EmbeddedCryptoWallet_RedirectUrl;
            context.PaymentInstrumentDetails_EmbeddedCryptoWallet_WalletAddress = this.PaymentInstrumentDetails_EmbeddedCryptoWallet_WalletAddress;
            context.PaymentInstrumentType = this.PaymentInstrumentType;
            #if MODULAR
            if (this.PaymentInstrumentType == null && ParameterWasBound(nameof(this.PaymentInstrumentType)))
            {
                WriteWarning("You are passing $null as a value for parameter PaymentInstrumentType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PaymentManagerArn = this.PaymentManagerArn;
            #if MODULAR
            if (this.PaymentManagerArn == null && ParameterWasBound(nameof(this.PaymentManagerArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PaymentManagerArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BedrockAgentCore.Model.CreatePaymentInstrumentRequest();
            
            if (cmdletContext.AgentName != null)
            {
                request.AgentName = cmdletContext.AgentName;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.PaymentConnectorId != null)
            {
                request.PaymentConnectorId = cmdletContext.PaymentConnectorId;
            }
            
             // populate PaymentInstrumentDetails
            var requestPaymentInstrumentDetailsIsNull = true;
            request.PaymentInstrumentDetails = new Amazon.BedrockAgentCore.Model.PaymentInstrumentDetails();
            Amazon.BedrockAgentCore.Model.EmbeddedCryptoWallet requestPaymentInstrumentDetails_paymentInstrumentDetails_EmbeddedCryptoWallet = null;
            
             // populate EmbeddedCryptoWallet
            var requestPaymentInstrumentDetails_paymentInstrumentDetails_EmbeddedCryptoWalletIsNull = true;
            requestPaymentInstrumentDetails_paymentInstrumentDetails_EmbeddedCryptoWallet = new Amazon.BedrockAgentCore.Model.EmbeddedCryptoWallet();
            List<Amazon.BedrockAgentCore.Model.LinkedAccount> requestPaymentInstrumentDetails_paymentInstrumentDetails_EmbeddedCryptoWallet_paymentInstrumentDetails_EmbeddedCryptoWallet_LinkedAccount = null;
            if (cmdletContext.PaymentInstrumentDetails_EmbeddedCryptoWallet_LinkedAccount != null)
            {
                requestPaymentInstrumentDetails_paymentInstrumentDetails_EmbeddedCryptoWallet_paymentInstrumentDetails_EmbeddedCryptoWallet_LinkedAccount = cmdletContext.PaymentInstrumentDetails_EmbeddedCryptoWallet_LinkedAccount;
            }
            if (requestPaymentInstrumentDetails_paymentInstrumentDetails_EmbeddedCryptoWallet_paymentInstrumentDetails_EmbeddedCryptoWallet_LinkedAccount != null)
            {
                requestPaymentInstrumentDetails_paymentInstrumentDetails_EmbeddedCryptoWallet.LinkedAccounts = requestPaymentInstrumentDetails_paymentInstrumentDetails_EmbeddedCryptoWallet_paymentInstrumentDetails_EmbeddedCryptoWallet_LinkedAccount;
                requestPaymentInstrumentDetails_paymentInstrumentDetails_EmbeddedCryptoWalletIsNull = false;
            }
            Amazon.BedrockAgentCore.CryptoWalletNetwork requestPaymentInstrumentDetails_paymentInstrumentDetails_EmbeddedCryptoWallet_paymentInstrumentDetails_EmbeddedCryptoWallet_Network = null;
            if (cmdletContext.PaymentInstrumentDetails_EmbeddedCryptoWallet_Network != null)
            {
                requestPaymentInstrumentDetails_paymentInstrumentDetails_EmbeddedCryptoWallet_paymentInstrumentDetails_EmbeddedCryptoWallet_Network = cmdletContext.PaymentInstrumentDetails_EmbeddedCryptoWallet_Network;
            }
            if (requestPaymentInstrumentDetails_paymentInstrumentDetails_EmbeddedCryptoWallet_paymentInstrumentDetails_EmbeddedCryptoWallet_Network != null)
            {
                requestPaymentInstrumentDetails_paymentInstrumentDetails_EmbeddedCryptoWallet.Network = requestPaymentInstrumentDetails_paymentInstrumentDetails_EmbeddedCryptoWallet_paymentInstrumentDetails_EmbeddedCryptoWallet_Network;
                requestPaymentInstrumentDetails_paymentInstrumentDetails_EmbeddedCryptoWalletIsNull = false;
            }
            System.String requestPaymentInstrumentDetails_paymentInstrumentDetails_EmbeddedCryptoWallet_paymentInstrumentDetails_EmbeddedCryptoWallet_RedirectUrl = null;
            if (cmdletContext.PaymentInstrumentDetails_EmbeddedCryptoWallet_RedirectUrl != null)
            {
                requestPaymentInstrumentDetails_paymentInstrumentDetails_EmbeddedCryptoWallet_paymentInstrumentDetails_EmbeddedCryptoWallet_RedirectUrl = cmdletContext.PaymentInstrumentDetails_EmbeddedCryptoWallet_RedirectUrl;
            }
            if (requestPaymentInstrumentDetails_paymentInstrumentDetails_EmbeddedCryptoWallet_paymentInstrumentDetails_EmbeddedCryptoWallet_RedirectUrl != null)
            {
                requestPaymentInstrumentDetails_paymentInstrumentDetails_EmbeddedCryptoWallet.RedirectUrl = requestPaymentInstrumentDetails_paymentInstrumentDetails_EmbeddedCryptoWallet_paymentInstrumentDetails_EmbeddedCryptoWallet_RedirectUrl;
                requestPaymentInstrumentDetails_paymentInstrumentDetails_EmbeddedCryptoWalletIsNull = false;
            }
            System.String requestPaymentInstrumentDetails_paymentInstrumentDetails_EmbeddedCryptoWallet_paymentInstrumentDetails_EmbeddedCryptoWallet_WalletAddress = null;
            if (cmdletContext.PaymentInstrumentDetails_EmbeddedCryptoWallet_WalletAddress != null)
            {
                requestPaymentInstrumentDetails_paymentInstrumentDetails_EmbeddedCryptoWallet_paymentInstrumentDetails_EmbeddedCryptoWallet_WalletAddress = cmdletContext.PaymentInstrumentDetails_EmbeddedCryptoWallet_WalletAddress;
            }
            if (requestPaymentInstrumentDetails_paymentInstrumentDetails_EmbeddedCryptoWallet_paymentInstrumentDetails_EmbeddedCryptoWallet_WalletAddress != null)
            {
                requestPaymentInstrumentDetails_paymentInstrumentDetails_EmbeddedCryptoWallet.WalletAddress = requestPaymentInstrumentDetails_paymentInstrumentDetails_EmbeddedCryptoWallet_paymentInstrumentDetails_EmbeddedCryptoWallet_WalletAddress;
                requestPaymentInstrumentDetails_paymentInstrumentDetails_EmbeddedCryptoWalletIsNull = false;
            }
             // determine if requestPaymentInstrumentDetails_paymentInstrumentDetails_EmbeddedCryptoWallet should be set to null
            if (requestPaymentInstrumentDetails_paymentInstrumentDetails_EmbeddedCryptoWalletIsNull)
            {
                requestPaymentInstrumentDetails_paymentInstrumentDetails_EmbeddedCryptoWallet = null;
            }
            if (requestPaymentInstrumentDetails_paymentInstrumentDetails_EmbeddedCryptoWallet != null)
            {
                request.PaymentInstrumentDetails.EmbeddedCryptoWallet = requestPaymentInstrumentDetails_paymentInstrumentDetails_EmbeddedCryptoWallet;
                requestPaymentInstrumentDetailsIsNull = false;
            }
             // determine if request.PaymentInstrumentDetails should be set to null
            if (requestPaymentInstrumentDetailsIsNull)
            {
                request.PaymentInstrumentDetails = null;
            }
            if (cmdletContext.PaymentInstrumentType != null)
            {
                request.PaymentInstrumentType = cmdletContext.PaymentInstrumentType;
            }
            if (cmdletContext.PaymentManagerArn != null)
            {
                request.PaymentManagerArn = cmdletContext.PaymentManagerArn;
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
        
        private Amazon.BedrockAgentCore.Model.CreatePaymentInstrumentResponse CallAWSServiceOperation(IAmazonBedrockAgentCore client, Amazon.BedrockAgentCore.Model.CreatePaymentInstrumentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock AgentCore Data Plane Fronting Layer", "CreatePaymentInstrument");
            try
            {
                return client.CreatePaymentInstrumentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String PaymentConnectorId { get; set; }
            public List<Amazon.BedrockAgentCore.Model.LinkedAccount> PaymentInstrumentDetails_EmbeddedCryptoWallet_LinkedAccount { get; set; }
            public Amazon.BedrockAgentCore.CryptoWalletNetwork PaymentInstrumentDetails_EmbeddedCryptoWallet_Network { get; set; }
            public System.String PaymentInstrumentDetails_EmbeddedCryptoWallet_RedirectUrl { get; set; }
            public System.String PaymentInstrumentDetails_EmbeddedCryptoWallet_WalletAddress { get; set; }
            public Amazon.BedrockAgentCore.PaymentInstrumentType PaymentInstrumentType { get; set; }
            public System.String PaymentManagerArn { get; set; }
            public System.String UserId { get; set; }
            public System.Func<Amazon.BedrockAgentCore.Model.CreatePaymentInstrumentResponse, NewBACPaymentInstrumentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PaymentInstrument;
        }
        
    }
}
