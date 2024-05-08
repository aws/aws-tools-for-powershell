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
using Amazon.SQS;
using Amazon.SQS.Model;

namespace Amazon.PowerShell.Cmdlets.SQS
{
    /// <summary>
    /// Starts an asynchronous task to move messages from a specified source queue to a specified
    /// destination queue.
    /// 
    ///  <note><ul><li><para>
    /// This action is currently limited to supporting message redrive from queues that are
    /// configured as <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-dead-letter-queues.html">dead-letter
    /// queues (DLQs)</a> of other Amazon SQS queues only. Non-SQS queue sources of dead-letter
    /// queues, such as Lambda or Amazon SNS topics, are currently not supported.
    /// </para></li><li><para>
    /// In dead-letter queues redrive context, the <c>StartMessageMoveTask</c> the source
    /// queue is the DLQ, while the destination queue can be the original source queue (from
    /// which the messages were driven to the dead-letter-queue), or a custom destination
    /// queue.
    /// </para></li><li><para>
    /// Only one active message movement task is supported per queue at any given time.
    /// </para></li></ul></note>
    /// </summary>
    [Cmdlet("Start", "SQSMessageMoveTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Simple Queue Service (SQS) StartMessageMoveTask API operation.", Operation = new[] {"StartMessageMoveTask"}, SelectReturnType = typeof(Amazon.SQS.Model.StartMessageMoveTaskResponse))]
    [AWSCmdletOutput("System.String or Amazon.SQS.Model.StartMessageMoveTaskResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SQS.Model.StartMessageMoveTaskResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartSQSMessageMoveTaskCmdlet : AmazonSQSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DestinationArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the queue that receives the moved messages. You can use this field to specify
        /// the destination queue where you would like to redrive messages. If this field is left
        /// blank, the messages will be redriven back to their respective original source queues.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationArn { get; set; }
        #endregion
        
        #region Parameter MaxNumberOfMessagesPerSecond
        /// <summary>
        /// <para>
        /// <para>The number of messages to be moved per second (the message movement rate). You can
        /// use this field to define a fixed message movement rate. The maximum value for messages
        /// per second is 500. If this field is left blank, the system will optimize the rate
        /// based on the queue message backlog size, which may vary throughout the duration of
        /// the message movement task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxNumberOfMessagesPerSecond { get; set; }
        #endregion
        
        #region Parameter SourceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the queue that contains the messages to be moved to another queue. Currently,
        /// only ARNs of dead-letter queues (DLQs) whose sources are other Amazon SQS queues are
        /// accepted. DLQs whose sources are non-SQS queues, such as Lambda or Amazon SNS topics,
        /// are not currently supported.</para>
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
        public System.String SourceArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TaskHandle'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SQS.Model.StartMessageMoveTaskResponse).
        /// Specifying the name of a property of type Amazon.SQS.Model.StartMessageMoveTaskResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TaskHandle";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SourceArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SourceArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SourceArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SourceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-SQSMessageMoveTask (StartMessageMoveTask)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SQS.Model.StartMessageMoveTaskResponse, StartSQSMessageMoveTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SourceArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DestinationArn = this.DestinationArn;
            context.MaxNumberOfMessagesPerSecond = this.MaxNumberOfMessagesPerSecond;
            context.SourceArn = this.SourceArn;
            #if MODULAR
            if (this.SourceArn == null && ParameterWasBound(nameof(this.SourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SQS.Model.StartMessageMoveTaskRequest();
            
            if (cmdletContext.DestinationArn != null)
            {
                request.DestinationArn = cmdletContext.DestinationArn;
            }
            if (cmdletContext.MaxNumberOfMessagesPerSecond != null)
            {
                request.MaxNumberOfMessagesPerSecond = cmdletContext.MaxNumberOfMessagesPerSecond.Value;
            }
            if (cmdletContext.SourceArn != null)
            {
                request.SourceArn = cmdletContext.SourceArn;
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
        
        private Amazon.SQS.Model.StartMessageMoveTaskResponse CallAWSServiceOperation(IAmazonSQS client, Amazon.SQS.Model.StartMessageMoveTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Queue Service (SQS)", "StartMessageMoveTask");
            try
            {
                #if DESKTOP
                return client.StartMessageMoveTask(request);
                #elif CORECLR
                return client.StartMessageMoveTaskAsync(request).GetAwaiter().GetResult();
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
            public System.String DestinationArn { get; set; }
            public System.Int32? MaxNumberOfMessagesPerSecond { get; set; }
            public System.String SourceArn { get; set; }
            public System.Func<Amazon.SQS.Model.StartMessageMoveTaskResponse, StartSQSMessageMoveTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TaskHandle;
        }
        
    }
}
