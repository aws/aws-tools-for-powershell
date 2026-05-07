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
    /// Get a payment session
    /// </summary>
    [Cmdlet("Get", "BACPaymentSession")]
    [OutputType("Amazon.BedrockAgentCore.Model.PaymentSession")]
    [AWSCmdlet("Calls the Amazon Bedrock AgentCore Data Plane Fronting Layer GetPaymentSession API operation.", Operation = new[] {"GetPaymentSession"}, SelectReturnType = typeof(Amazon.BedrockAgentCore.Model.GetPaymentSessionResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCore.Model.PaymentSession or Amazon.BedrockAgentCore.Model.GetPaymentSessionResponse",
        "This cmdlet returns an Amazon.BedrockAgentCore.Model.PaymentSession object.",
        "The service call response (type Amazon.BedrockAgentCore.Model.GetPaymentSessionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetBACPaymentSessionCmdlet : AmazonBedrockAgentCoreClientCmdlet, IExecutor
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
        
        #region Parameter PaymentSessionId
        /// <summary>
        /// <para>
        /// <para>The ID of the payment session to retrieve.</para>
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
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>The user ID associated with this payment session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PaymentSession'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCore.Model.GetPaymentSessionResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCore.Model.GetPaymentSessionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PaymentSession";
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
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCore.Model.GetPaymentSessionResponse, GetBACPaymentSessionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AgentName = this.AgentName;
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
            var request = new Amazon.BedrockAgentCore.Model.GetPaymentSessionRequest();
            
            if (cmdletContext.AgentName != null)
            {
                request.AgentName = cmdletContext.AgentName;
            }
            if (cmdletContext.PaymentManagerArn != null)
            {
                request.PaymentManagerArn = cmdletContext.PaymentManagerArn;
            }
            if (cmdletContext.PaymentSessionId != null)
            {
                request.PaymentSessionId = cmdletContext.PaymentSessionId;
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
        
        private Amazon.BedrockAgentCore.Model.GetPaymentSessionResponse CallAWSServiceOperation(IAmazonBedrockAgentCore client, Amazon.BedrockAgentCore.Model.GetPaymentSessionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock AgentCore Data Plane Fronting Layer", "GetPaymentSession");
            try
            {
                return client.GetPaymentSessionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String PaymentManagerArn { get; set; }
            public System.String PaymentSessionId { get; set; }
            public System.String UserId { get; set; }
            public System.Func<Amazon.BedrockAgentCore.Model.GetPaymentSessionResponse, GetBACPaymentSessionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PaymentSession;
        }
        
    }
}
