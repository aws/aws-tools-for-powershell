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
using Amazon.SQS;
using Amazon.SQS.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SQS
{
    /// <summary>
    /// Cancels a specified message movement task. A message movement can only be cancelled
    /// when the current status is RUNNING. Cancelling a message movement task does not revert
    /// the messages that have already been moved. It can only stop the messages that have
    /// not been moved yet.
    /// 
    ///  <note><ul><li><para>
    /// This action is currently limited to supporting message redrive from <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-dead-letter-queues.html">dead-letter
    /// queues (DLQs)</a> only. In this context, the source queue is the dead-letter queue
    /// (DLQ), while the destination queue can be the original source queue (from which the
    /// messages were driven to the dead-letter-queue), or a custom destination queue. 
    /// </para></li><li><para>
    /// Only one active message movement task is supported per queue at any given time.
    /// </para></li></ul></note>
    /// </summary>
    [Cmdlet("Stop", "SQSMessageMoveTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Int64")]
    [AWSCmdlet("Calls the Amazon Simple Queue Service (SQS) CancelMessageMoveTask API operation.", Operation = new[] {"CancelMessageMoveTask"}, SelectReturnType = typeof(Amazon.SQS.Model.CancelMessageMoveTaskResponse))]
    [AWSCmdletOutput("System.Int64 or Amazon.SQS.Model.CancelMessageMoveTaskResponse",
        "This cmdlet returns a collection of System.Int64 objects.",
        "The service call response (type Amazon.SQS.Model.CancelMessageMoveTaskResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StopSQSMessageMoveTaskCmdlet : AmazonSQSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter TaskHandle
        /// <summary>
        /// <para>
        /// <para>An identifier associated with a message movement task.</para>
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
        public System.String TaskHandle { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ApproximateNumberOfMessagesMoved'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SQS.Model.CancelMessageMoveTaskResponse).
        /// Specifying the name of a property of type Amazon.SQS.Model.CancelMessageMoveTaskResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ApproximateNumberOfMessagesMoved";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TaskHandle), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Stop-SQSMessageMoveTask (CancelMessageMoveTask)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SQS.Model.CancelMessageMoveTaskResponse, StopSQSMessageMoveTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.TaskHandle = this.TaskHandle;
            #if MODULAR
            if (this.TaskHandle == null && ParameterWasBound(nameof(this.TaskHandle)))
            {
                WriteWarning("You are passing $null as a value for parameter TaskHandle which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SQS.Model.CancelMessageMoveTaskRequest();
            
            if (cmdletContext.TaskHandle != null)
            {
                request.TaskHandle = cmdletContext.TaskHandle;
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
        
        private Amazon.SQS.Model.CancelMessageMoveTaskResponse CallAWSServiceOperation(IAmazonSQS client, Amazon.SQS.Model.CancelMessageMoveTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Queue Service (SQS)", "CancelMessageMoveTask");
            try
            {
                return client.CancelMessageMoveTaskAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String TaskHandle { get; set; }
            public System.Func<Amazon.SQS.Model.CancelMessageMoveTaskResponse, StopSQSMessageMoveTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ApproximateNumberOfMessagesMoved;
        }
        
    }
}
