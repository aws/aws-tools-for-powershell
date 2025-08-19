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
using Amazon.BedrockAgentRuntime;
using Amazon.BedrockAgentRuntime.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BAR
{
    /// <summary>
    /// Optimizes a prompt for the task that you specify. For more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/prompt-management-optimize.html">Optimize
    /// a prompt</a> in the <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/what-is-service.html">Amazon
    /// Bedrock User Guide</a>.
    /// </summary>
    [Cmdlet("Get", "BAROptimizePrompt")]
    [OutputType("Amazon.BedrockAgentRuntime.Model.OptimizedPromptStream")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Runtime OptimizePrompt API operation.", Operation = new[] {"OptimizePrompt"}, SelectReturnType = typeof(Amazon.BedrockAgentRuntime.Model.OptimizePromptResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentRuntime.Model.OptimizedPromptStream or Amazon.BedrockAgentRuntime.Model.OptimizePromptResponse",
        "This cmdlet returns an Amazon.BedrockAgentRuntime.Model.OptimizedPromptStream object.",
        "The service call response (type Amazon.BedrockAgentRuntime.Model.OptimizePromptResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetBAROptimizePromptCmdlet : AmazonBedrockAgentRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter TargetModelId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the model that you want to optimize the prompt for.</para>
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
        public System.String TargetModelId { get; set; }
        #endregion
        
        #region Parameter TextPrompt_Text
        /// <summary>
        /// <para>
        /// <para>The text in the text prompt to optimize.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_TextPrompt_Text")]
        public System.String TextPrompt_Text { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OptimizedPrompt'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentRuntime.Model.OptimizePromptResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentRuntime.Model.OptimizePromptResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OptimizedPrompt";
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
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentRuntime.Model.OptimizePromptResponse, GetBAROptimizePromptCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.TextPrompt_Text = this.TextPrompt_Text;
            context.TargetModelId = this.TargetModelId;
            #if MODULAR
            if (this.TargetModelId == null && ParameterWasBound(nameof(this.TargetModelId)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetModelId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BedrockAgentRuntime.Model.OptimizePromptRequest();
            
            
             // populate Input
            request.Input = new Amazon.BedrockAgentRuntime.Model.InputPrompt();
            Amazon.BedrockAgentRuntime.Model.TextPrompt requestInput_input_TextPrompt = null;
            
             // populate TextPrompt
            var requestInput_input_TextPromptIsNull = true;
            requestInput_input_TextPrompt = new Amazon.BedrockAgentRuntime.Model.TextPrompt();
            System.String requestInput_input_TextPrompt_textPrompt_Text = null;
            if (cmdletContext.TextPrompt_Text != null)
            {
                requestInput_input_TextPrompt_textPrompt_Text = cmdletContext.TextPrompt_Text;
            }
            if (requestInput_input_TextPrompt_textPrompt_Text != null)
            {
                requestInput_input_TextPrompt.Text = requestInput_input_TextPrompt_textPrompt_Text;
                requestInput_input_TextPromptIsNull = false;
            }
             // determine if requestInput_input_TextPrompt should be set to null
            if (requestInput_input_TextPromptIsNull)
            {
                requestInput_input_TextPrompt = null;
            }
            if (requestInput_input_TextPrompt != null)
            {
                request.Input.TextPrompt = requestInput_input_TextPrompt;
            }
            if (cmdletContext.TargetModelId != null)
            {
                request.TargetModelId = cmdletContext.TargetModelId;
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
        
        private Amazon.BedrockAgentRuntime.Model.OptimizePromptResponse CallAWSServiceOperation(IAmazonBedrockAgentRuntime client, Amazon.BedrockAgentRuntime.Model.OptimizePromptRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Runtime", "OptimizePrompt");
            try
            {
                return client.OptimizePromptAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String TextPrompt_Text { get; set; }
            public System.String TargetModelId { get; set; }
            public System.Func<Amazon.BedrockAgentRuntime.Model.OptimizePromptResponse, GetBAROptimizePromptCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OptimizedPrompt;
        }
        
    }
}
