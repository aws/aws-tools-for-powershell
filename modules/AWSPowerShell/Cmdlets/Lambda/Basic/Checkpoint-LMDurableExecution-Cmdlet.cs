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
    /// Saves the progress of a <a href="https://docs.aws.amazon.com/lambda/latest/dg/durable-functions.html">durable
    /// function</a> execution during runtime. This API is used by the Lambda durable functions
    /// SDK to checkpoint completed steps and schedule asynchronous operations. You typically
    /// don't need to call this API directly as the SDK handles checkpointing automatically.
    /// 
    ///  
    /// <para>
    /// Each checkpoint operation consumes the current checkpoint token and returns a new
    /// one for the next checkpoint. This ensures that checkpoints are applied in the correct
    /// order and prevents duplicate or out-of-order state updates.
    /// </para>
    /// </summary>
    [Cmdlet("Checkpoint", "LMDurableExecution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lambda.Model.CheckpointDurableExecutionResponse")]
    [AWSCmdlet("Calls the AWS Lambda CheckpointDurableExecution API operation.", Operation = new[] {"CheckpointDurableExecution"}, SelectReturnType = typeof(Amazon.Lambda.Model.CheckpointDurableExecutionResponse))]
    [AWSCmdletOutput("Amazon.Lambda.Model.CheckpointDurableExecutionResponse",
        "This cmdlet returns an Amazon.Lambda.Model.CheckpointDurableExecutionResponse object containing multiple properties."
    )]
    public partial class CheckpointLMDurableExecutionCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CheckpointToken
        /// <summary>
        /// <para>
        /// <para>A unique token that identifies the current checkpoint state. This token is provided
        /// by the Lambda runtime and must be used to ensure checkpoints are applied in the correct
        /// order. Each checkpoint operation consumes this token and returns a new one.</para>
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
        public System.String CheckpointToken { get; set; }
        #endregion
        
        #region Parameter DurableExecutionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the durable execution.</para>
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
        public System.String DurableExecutionArn { get; set; }
        #endregion
        
        #region Parameter Update
        /// <summary>
        /// <para>
        /// <para>An array of state updates to apply during this checkpoint. Each update represents
        /// a change to the execution state, such as completing a step, starting a callback, or
        /// scheduling a timer. Updates are applied atomically as part of the checkpoint operation.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Updates")]
        public Amazon.Lambda.Model.OperationUpdate[] Update { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>An optional idempotency token to ensure that duplicate checkpoint requests are handled
        /// correctly. If provided, Lambda uses this token to detect and handle duplicate requests
        /// within a 15-minute window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lambda.Model.CheckpointDurableExecutionResponse).
        /// Specifying the name of a property of type Amazon.Lambda.Model.CheckpointDurableExecutionResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Checkpoint-LMDurableExecution (CheckpointDurableExecution)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lambda.Model.CheckpointDurableExecutionResponse, CheckpointLMDurableExecutionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CheckpointToken = this.CheckpointToken;
            #if MODULAR
            if (this.CheckpointToken == null && ParameterWasBound(nameof(this.CheckpointToken)))
            {
                WriteWarning("You are passing $null as a value for parameter CheckpointToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.DurableExecutionArn = this.DurableExecutionArn;
            #if MODULAR
            if (this.DurableExecutionArn == null && ParameterWasBound(nameof(this.DurableExecutionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DurableExecutionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Update != null)
            {
                context.Update = new List<Amazon.Lambda.Model.OperationUpdate>(this.Update);
            }
            
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
            var request = new Amazon.Lambda.Model.CheckpointDurableExecutionRequest();
            
            if (cmdletContext.CheckpointToken != null)
            {
                request.CheckpointToken = cmdletContext.CheckpointToken;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DurableExecutionArn != null)
            {
                request.DurableExecutionArn = cmdletContext.DurableExecutionArn;
            }
            if (cmdletContext.Update != null)
            {
                request.Updates = cmdletContext.Update;
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
        
        private Amazon.Lambda.Model.CheckpointDurableExecutionResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.CheckpointDurableExecutionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda", "CheckpointDurableExecution");
            try
            {
                return client.CheckpointDurableExecutionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CheckpointToken { get; set; }
            public System.String ClientToken { get; set; }
            public System.String DurableExecutionArn { get; set; }
            public List<Amazon.Lambda.Model.OperationUpdate> Update { get; set; }
            public System.Func<Amazon.Lambda.Model.CheckpointDurableExecutionResponse, CheckpointLMDurableExecutionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
