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
    /// Performs on-demand evaluation of agent traces using a specified evaluator. This synchronous
    /// API accepts traces in OpenTelemetry format and returns immediate scoring results with
    /// detailed explanations.
    /// </summary>
    [Cmdlet("Invoke", "BACEvaluate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCore.Model.EvaluationResultContent")]
    [AWSCmdlet("Calls the Amazon Bedrock AgentCore Data Plane Fronting Layer Evaluate API operation.", Operation = new[] {"Evaluate"}, SelectReturnType = typeof(Amazon.BedrockAgentCore.Model.EvaluateResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCore.Model.EvaluationResultContent or Amazon.BedrockAgentCore.Model.EvaluateResponse",
        "This cmdlet returns a collection of Amazon.BedrockAgentCore.Model.EvaluationResultContent objects.",
        "The service call response (type Amazon.BedrockAgentCore.Model.EvaluateResponse) can be returned by specifying '-Select *'."
    )]
    public partial class InvokeBACEvaluateCmdlet : AmazonBedrockAgentCoreClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EvaluatorId
        /// <summary>
        /// <para>
        /// <para> The unique identifier of the evaluator to use for scoring. Can be a built-in evaluator
        /// (e.g., <c>Builtin.Helpfulness</c>, <c>Builtin.Correctness</c>) or a custom evaluator
        /// ARN created through the control plane API. </para>
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
        public System.String EvaluatorId { get; set; }
        #endregion
        
        #region Parameter EvaluationInput_SessionSpan
        /// <summary>
        /// <para>
        /// <para> The collection of spans representing agent execution traces within a session. Each
        /// span contains detailed information about tool calls, model interactions, and other
        /// agent activities that can be evaluated for quality and performance. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EvaluationInput_SessionSpans")]
        public Amazon.Runtime.Documents.Document[] EvaluationInput_SessionSpan { get; set; }
        #endregion
        
        #region Parameter EvaluationTarget_SpanId
        /// <summary>
        /// <para>
        /// <para> The list of specific span IDs to evaluate within the provided traces. Used to target
        /// evaluation at individual tool calls or specific operations within the agent's execution
        /// flow. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EvaluationTarget_SpanIds")]
        public System.String[] EvaluationTarget_SpanId { get; set; }
        #endregion
        
        #region Parameter EvaluationTarget_TraceId
        /// <summary>
        /// <para>
        /// <para> The list of trace IDs to evaluate, representing complete request-response interactions.
        /// Used to evaluate entire conversation turns or specific agent interactions within a
        /// session. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EvaluationTarget_TraceIds")]
        public System.String[] EvaluationTarget_TraceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EvaluationResults'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCore.Model.EvaluateResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCore.Model.EvaluateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EvaluationResults";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EvaluatorId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-BACEvaluate (Evaluate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCore.Model.EvaluateResponse, InvokeBACEvaluateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.EvaluationInput_SessionSpan != null)
            {
                context.EvaluationInput_SessionSpan = new List<Amazon.Runtime.Documents.Document>(this.EvaluationInput_SessionSpan);
            }
            if (this.EvaluationTarget_SpanId != null)
            {
                context.EvaluationTarget_SpanId = new List<System.String>(this.EvaluationTarget_SpanId);
            }
            if (this.EvaluationTarget_TraceId != null)
            {
                context.EvaluationTarget_TraceId = new List<System.String>(this.EvaluationTarget_TraceId);
            }
            context.EvaluatorId = this.EvaluatorId;
            #if MODULAR
            if (this.EvaluatorId == null && ParameterWasBound(nameof(this.EvaluatorId)))
            {
                WriteWarning("You are passing $null as a value for parameter EvaluatorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BedrockAgentCore.Model.EvaluateRequest();
            
            
             // populate EvaluationInput
            var requestEvaluationInputIsNull = true;
            request.EvaluationInput = new Amazon.BedrockAgentCore.Model.EvaluationInput();
            List<Amazon.Runtime.Documents.Document> requestEvaluationInput_evaluationInput_SessionSpan = null;
            if (cmdletContext.EvaluationInput_SessionSpan != null)
            {
                requestEvaluationInput_evaluationInput_SessionSpan = cmdletContext.EvaluationInput_SessionSpan;
            }
            if (requestEvaluationInput_evaluationInput_SessionSpan != null)
            {
                request.EvaluationInput.SessionSpans = requestEvaluationInput_evaluationInput_SessionSpan;
                requestEvaluationInputIsNull = false;
            }
             // determine if request.EvaluationInput should be set to null
            if (requestEvaluationInputIsNull)
            {
                request.EvaluationInput = null;
            }
            
             // populate EvaluationTarget
            var requestEvaluationTargetIsNull = true;
            request.EvaluationTarget = new Amazon.BedrockAgentCore.Model.EvaluationTarget();
            List<System.String> requestEvaluationTarget_evaluationTarget_SpanId = null;
            if (cmdletContext.EvaluationTarget_SpanId != null)
            {
                requestEvaluationTarget_evaluationTarget_SpanId = cmdletContext.EvaluationTarget_SpanId;
            }
            if (requestEvaluationTarget_evaluationTarget_SpanId != null)
            {
                request.EvaluationTarget.SpanIds = requestEvaluationTarget_evaluationTarget_SpanId;
                requestEvaluationTargetIsNull = false;
            }
            List<System.String> requestEvaluationTarget_evaluationTarget_TraceId = null;
            if (cmdletContext.EvaluationTarget_TraceId != null)
            {
                requestEvaluationTarget_evaluationTarget_TraceId = cmdletContext.EvaluationTarget_TraceId;
            }
            if (requestEvaluationTarget_evaluationTarget_TraceId != null)
            {
                request.EvaluationTarget.TraceIds = requestEvaluationTarget_evaluationTarget_TraceId;
                requestEvaluationTargetIsNull = false;
            }
             // determine if request.EvaluationTarget should be set to null
            if (requestEvaluationTargetIsNull)
            {
                request.EvaluationTarget = null;
            }
            if (cmdletContext.EvaluatorId != null)
            {
                request.EvaluatorId = cmdletContext.EvaluatorId;
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
        
        private Amazon.BedrockAgentCore.Model.EvaluateResponse CallAWSServiceOperation(IAmazonBedrockAgentCore client, Amazon.BedrockAgentCore.Model.EvaluateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock AgentCore Data Plane Fronting Layer", "Evaluate");
            try
            {
                return client.EvaluateAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Runtime.Documents.Document> EvaluationInput_SessionSpan { get; set; }
            public List<System.String> EvaluationTarget_SpanId { get; set; }
            public List<System.String> EvaluationTarget_TraceId { get; set; }
            public System.String EvaluatorId { get; set; }
            public System.Func<Amazon.BedrockAgentCore.Model.EvaluateResponse, InvokeBACEvaluateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EvaluationResults;
        }
        
    }
}
