/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.StepFunctions;
using Amazon.StepFunctions.Model;

namespace Amazon.PowerShell.Cmdlets.SFN
{
    /// <summary>
    /// Restarts unsuccessful executions of Standard workflows that didn't complete successfully
    /// in the last 14 days. These include failed, aborted, or timed out executions. When
    /// you <a href="https://docs.aws.amazon.com/step-functions/latest/dg/redrive-executions.html">redrive</a>
    /// an execution, it continues the failed execution from the unsuccessful step and uses
    /// the same input. Step Functions preserves the results and execution history of the
    /// successful steps, and doesn't rerun these steps when you redrive an execution. Redriven
    /// executions use the same state machine definition and execution ARN as the original
    /// execution attempt.
    /// 
    ///  
    /// <para>
    /// For workflows that include an <a href="https://docs.aws.amazon.com/step-functions/latest/dg/amazon-states-language-map-state.html">Inline
    /// Map</a> or <a href="https://docs.aws.amazon.com/step-functions/latest/dg/amazon-states-language-parallel-state.html">Parallel</a>
    /// state, <c>RedriveExecution</c> API action reschedules and redrives only the iterations
    /// and branches that failed or aborted.
    /// </para><para>
    /// To redrive a workflow that includes a Distributed Map state whose Map Run failed,
    /// you must redrive the <a href="https://docs.aws.amazon.com/step-functions/latest/dg/use-dist-map-orchestrate-large-scale-parallel-workloads.html#dist-map-orchestrate-parallel-workloads-key-terms">parent
    /// workflow</a>. The parent workflow redrives all the unsuccessful states, including
    /// a failed Map Run. If a Map Run was not started in the original execution attempt,
    /// the redriven parent workflow starts the Map Run.
    /// </para><note><para>
    /// This API action is not supported by <c>EXPRESS</c> state machines.
    /// </para><para>
    /// However, you can restart the unsuccessful executions of Express child workflows in
    /// a Distributed Map by redriving its Map Run. When you redrive a Map Run, the Express
    /// child workflows are rerun using the <a>StartExecution</a> API action. For more information,
    /// see <a href="https://docs.aws.amazon.com/step-functions/latest/dg/redrive-map-run.html">Redriving
    /// Map Runs</a>.
    /// </para></note><para>
    /// You can redrive executions if your original execution meets the following conditions:
    /// </para><ul><li><para>
    /// The execution status isn't <c>SUCCEEDED</c>.
    /// </para></li><li><para>
    /// Your workflow execution has not exceeded the redrivable period of 14 days. Redrivable
    /// period refers to the time during which you can redrive a given execution. This period
    /// starts from the day a state machine completes its execution.
    /// </para></li><li><para>
    /// The workflow execution has not exceeded the maximum open time of one year. For more
    /// information about state machine quotas, see <a href="https://docs.aws.amazon.com/step-functions/latest/dg/limits-overview.html#service-limits-state-machine-executions">Quotas
    /// related to state machine executions</a>.
    /// </para></li><li><para>
    /// The execution event history count is less than 24,999. Redriven executions append
    /// their event history to the existing event history. Make sure your workflow execution
    /// contains less than 24,999 events to accommodate the <c>ExecutionRedriven</c> history
    /// event and at least one other history event.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Restart", "SFNExecution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.DateTime")]
    [AWSCmdlet("Calls the AWS Step Functions RedriveExecution API operation.", Operation = new[] {"RedriveExecution"}, SelectReturnType = typeof(Amazon.StepFunctions.Model.RedriveExecutionResponse))]
    [AWSCmdletOutput("System.DateTime or Amazon.StepFunctions.Model.RedriveExecutionResponse",
        "This cmdlet returns a System.DateTime object.",
        "The service call response (type Amazon.StepFunctions.Model.RedriveExecutionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RestartSFNExecutionCmdlet : AmazonStepFunctionsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ExecutionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the execution to be redriven.</para>
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
        public System.String ExecutionArn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If you don’t specify a client token, the Amazon Web Services SDK automatically
        /// generates a client token and uses it for the request to ensure idempotency. The API
        /// will return idempotent responses for the last 10 client tokens used to successfully
        /// redrive the execution. These client tokens are valid for up to 15 minutes after they
        /// are first used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RedriveDate'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StepFunctions.Model.RedriveExecutionResponse).
        /// Specifying the name of a property of type Amazon.StepFunctions.Model.RedriveExecutionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RedriveDate";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ExecutionArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ExecutionArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ExecutionArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ExecutionArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Restart-SFNExecution (RedriveExecution)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.StepFunctions.Model.RedriveExecutionResponse, RestartSFNExecutionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ExecutionArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.ExecutionArn = this.ExecutionArn;
            #if MODULAR
            if (this.ExecutionArn == null && ParameterWasBound(nameof(this.ExecutionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ExecutionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.StepFunctions.Model.RedriveExecutionRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ExecutionArn != null)
            {
                request.ExecutionArn = cmdletContext.ExecutionArn;
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
        
        private Amazon.StepFunctions.Model.RedriveExecutionResponse CallAWSServiceOperation(IAmazonStepFunctions client, Amazon.StepFunctions.Model.RedriveExecutionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Step Functions", "RedriveExecution");
            try
            {
                #if DESKTOP
                return client.RedriveExecution(request);
                #elif CORECLR
                return client.RedriveExecutionAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
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
            public System.String ExecutionArn { get; set; }
            public System.Func<Amazon.StepFunctions.Model.RedriveExecutionResponse, RestartSFNExecutionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RedriveDate;
        }
        
    }
}
