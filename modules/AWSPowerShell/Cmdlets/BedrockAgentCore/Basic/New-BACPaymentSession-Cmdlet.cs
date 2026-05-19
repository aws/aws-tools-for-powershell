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
    /// Create a new payment session.
    /// </summary>
    [Cmdlet("New", "BACPaymentSession", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCore.Model.PaymentSession")]
    [AWSCmdlet("Calls the Amazon Bedrock AgentCore Data Plane Fronting Layer CreatePaymentSession API operation.", Operation = new[] {"CreatePaymentSession"}, SelectReturnType = typeof(Amazon.BedrockAgentCore.Model.CreatePaymentSessionResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCore.Model.PaymentSession or Amazon.BedrockAgentCore.Model.CreatePaymentSessionResponse",
        "This cmdlet returns an Amazon.BedrockAgentCore.Model.PaymentSession object.",
        "The service call response (type Amazon.BedrockAgentCore.Model.CreatePaymentSessionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewBACPaymentSessionCmdlet : AmazonBedrockAgentCoreClientCmdlet, IExecutor
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
        
        #region Parameter Limits_MaxSpendAmount_Currency
        /// <summary>
        /// <para>
        /// <para>The currency code for the amount.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCore.Currency")]
        public Amazon.BedrockAgentCore.Currency Limits_MaxSpendAmount_Currency { get; set; }
        #endregion
        
        #region Parameter ExpiryTimeInMinute
        /// <summary>
        /// <para>
        /// <para>The session expiry time in minutes. Must be between 15 and 480 minutes.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ExpiryTimeInMinutes")]
        public System.Int32? ExpiryTimeInMinute { get; set; }
        #endregion
        
        #region Parameter PaymentManagerArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the payment manager that owns this session.</para>
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
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>The user ID associated with this payment session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserId { get; set; }
        #endregion
        
        #region Parameter Limits_MaxSpendAmount_Value
        /// <summary>
        /// <para>
        /// <para>The numeric value of the amount.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Limits_MaxSpendAmount_Value { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PaymentSession'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCore.Model.CreatePaymentSessionResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCore.Model.CreatePaymentSessionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PaymentSession";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PaymentManagerArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BACPaymentSession (CreatePaymentSession)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCore.Model.CreatePaymentSessionResponse, NewBACPaymentSessionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AgentName = this.AgentName;
            context.ClientToken = this.ClientToken;
            context.ExpiryTimeInMinute = this.ExpiryTimeInMinute;
            #if MODULAR
            if (this.ExpiryTimeInMinute == null && ParameterWasBound(nameof(this.ExpiryTimeInMinute)))
            {
                WriteWarning("You are passing $null as a value for parameter ExpiryTimeInMinute which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Limits_MaxSpendAmount_Currency = this.Limits_MaxSpendAmount_Currency;
            context.Limits_MaxSpendAmount_Value = this.Limits_MaxSpendAmount_Value;
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
            var request = new Amazon.BedrockAgentCore.Model.CreatePaymentSessionRequest();
            
            if (cmdletContext.AgentName != null)
            {
                request.AgentName = cmdletContext.AgentName;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ExpiryTimeInMinute != null)
            {
                request.ExpiryTimeInMinutes = cmdletContext.ExpiryTimeInMinute.Value;
            }
            
             // populate Limits
            var requestLimitsIsNull = true;
            request.Limits = new Amazon.BedrockAgentCore.Model.SessionLimits();
            Amazon.BedrockAgentCore.Model.Amount requestLimits_limits_MaxSpendAmount = null;
            
             // populate MaxSpendAmount
            var requestLimits_limits_MaxSpendAmountIsNull = true;
            requestLimits_limits_MaxSpendAmount = new Amazon.BedrockAgentCore.Model.Amount();
            Amazon.BedrockAgentCore.Currency requestLimits_limits_MaxSpendAmount_limits_MaxSpendAmount_Currency = null;
            if (cmdletContext.Limits_MaxSpendAmount_Currency != null)
            {
                requestLimits_limits_MaxSpendAmount_limits_MaxSpendAmount_Currency = cmdletContext.Limits_MaxSpendAmount_Currency;
            }
            if (requestLimits_limits_MaxSpendAmount_limits_MaxSpendAmount_Currency != null)
            {
                requestLimits_limits_MaxSpendAmount.Currency = requestLimits_limits_MaxSpendAmount_limits_MaxSpendAmount_Currency;
                requestLimits_limits_MaxSpendAmountIsNull = false;
            }
            System.String requestLimits_limits_MaxSpendAmount_limits_MaxSpendAmount_Value = null;
            if (cmdletContext.Limits_MaxSpendAmount_Value != null)
            {
                requestLimits_limits_MaxSpendAmount_limits_MaxSpendAmount_Value = cmdletContext.Limits_MaxSpendAmount_Value;
            }
            if (requestLimits_limits_MaxSpendAmount_limits_MaxSpendAmount_Value != null)
            {
                requestLimits_limits_MaxSpendAmount.Value = requestLimits_limits_MaxSpendAmount_limits_MaxSpendAmount_Value;
                requestLimits_limits_MaxSpendAmountIsNull = false;
            }
             // determine if requestLimits_limits_MaxSpendAmount should be set to null
            if (requestLimits_limits_MaxSpendAmountIsNull)
            {
                requestLimits_limits_MaxSpendAmount = null;
            }
            if (requestLimits_limits_MaxSpendAmount != null)
            {
                request.Limits.MaxSpendAmount = requestLimits_limits_MaxSpendAmount;
                requestLimitsIsNull = false;
            }
             // determine if request.Limits should be set to null
            if (requestLimitsIsNull)
            {
                request.Limits = null;
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
        
        private Amazon.BedrockAgentCore.Model.CreatePaymentSessionResponse CallAWSServiceOperation(IAmazonBedrockAgentCore client, Amazon.BedrockAgentCore.Model.CreatePaymentSessionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock AgentCore Data Plane Fronting Layer", "CreatePaymentSession");
            try
            {
                return client.CreatePaymentSessionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? ExpiryTimeInMinute { get; set; }
            public Amazon.BedrockAgentCore.Currency Limits_MaxSpendAmount_Currency { get; set; }
            public System.String Limits_MaxSpendAmount_Value { get; set; }
            public System.String PaymentManagerArn { get; set; }
            public System.String UserId { get; set; }
            public System.Func<Amazon.BedrockAgentCore.Model.CreatePaymentSessionResponse, NewBACPaymentSessionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PaymentSession;
        }
        
    }
}
