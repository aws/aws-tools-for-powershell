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
using Amazon.Lambda;
using Amazon.Lambda.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LM
{
    /// <summary>
    /// Pauses a running <a href="https://docs.aws.amazon.com/lambda/latest/dg/durable-functions.html">durable
    /// execution</a>. While an execution is paused, Lambda doesn't invoke your function,
    /// but pending operations such as waits and callbacks continue to complete.
    /// 
    ///  
    /// <para>
    /// If an invocation is in progress, the execution status changes to <c>PAUSING</c> until
    /// the invocation reaches its next checkpoint, and then changes to <c>PAUSED</c>. This
    /// operation returns a successful response while the execution status is still <c>RUNNING</c>,
    /// and the status changes when Lambda processes the request. For more information about
    /// pausing executions, see <a href="https://docs.aws.amazon.com/lambda/latest/dg/durable-pause-resume.html">Pausing
    /// and resuming durable executions</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Suspend", "LMDurableExecution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Lambda PauseDurableExecution API operation.", Operation = new[] {"PauseDurableExecution"}, SelectReturnType = typeof(Amazon.Lambda.Model.PauseDurableExecutionResponse))]
    [AWSCmdletOutput("None or Amazon.Lambda.Model.PauseDurableExecutionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Lambda.Model.PauseDurableExecutionResponse) be returned by specifying '-Select *'."
    )]
    public partial class SuspendLMDurableExecutionCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DurableExecutionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the durable execution.</para>
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
        public System.String DurableExecutionArn { get; set; }
        #endregion
        
        #region Parameter ExecutionTimeoutPaused
        /// <summary>
        /// <para>
        /// <para>Specifies whether to pause the execution timeout while the execution is paused. If
        /// <c>true</c>, Lambda extends the execution timeout by the time the execution spends
        /// paused. An execution with a paused timeout still times out 366 days after it started.
        /// The default value is <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ExecutionTimeoutPaused { get; set; }
        #endregion
        
        #region Parameter Reason
        /// <summary>
        /// <para>
        /// <para>A description of why you're pausing the execution. Lambda records the reason in the
        /// execution history.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Reason { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide so that the request completes
        /// no more than one time. If you repeat a request with the same client token and parameters
        /// within 15 minutes, Lambda doesn't pause the execution again and returns a successful
        /// response instead of an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lambda.Model.PauseDurableExecutionResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DurableExecutionArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Suspend-LMDurableExecution (PauseDurableExecution)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lambda.Model.PauseDurableExecutionResponse, SuspendLMDurableExecutionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DurableExecutionArn = this.DurableExecutionArn;
            #if MODULAR
            if (this.DurableExecutionArn == null && ParameterWasBound(nameof(this.DurableExecutionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DurableExecutionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExecutionTimeoutPaused = this.ExecutionTimeoutPaused;
            context.Reason = this.Reason;
            
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
            var request = new Amazon.Lambda.Model.PauseDurableExecutionRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DurableExecutionArn != null)
            {
                request.DurableExecutionArn = cmdletContext.DurableExecutionArn;
            }
            if (cmdletContext.ExecutionTimeoutPaused != null)
            {
                request.ExecutionTimeoutPaused = cmdletContext.ExecutionTimeoutPaused.Value;
            }
            if (cmdletContext.Reason != null)
            {
                request.Reason = cmdletContext.Reason;
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
        
        private Amazon.Lambda.Model.PauseDurableExecutionResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.PauseDurableExecutionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda", "PauseDurableExecution");
            try
            {
                return client.PauseDurableExecutionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DurableExecutionArn { get; set; }
            public System.Boolean? ExecutionTimeoutPaused { get; set; }
            public System.String Reason { get; set; }
            public System.Func<Amazon.Lambda.Model.PauseDurableExecutionResponse, SuspendLMDurableExecutionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
