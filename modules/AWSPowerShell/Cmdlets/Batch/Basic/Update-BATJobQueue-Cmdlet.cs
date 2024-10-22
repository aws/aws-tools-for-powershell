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
using Amazon.Batch;
using Amazon.Batch.Model;

namespace Amazon.PowerShell.Cmdlets.BAT
{
    /// <summary>
    /// Updates a job queue.
    /// </summary>
    [Cmdlet("Update", "BATJobQueue", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Batch.Model.UpdateJobQueueResponse")]
    [AWSCmdlet("Calls the AWS Batch UpdateJobQueue API operation.", Operation = new[] {"UpdateJobQueue"}, SelectReturnType = typeof(Amazon.Batch.Model.UpdateJobQueueResponse))]
    [AWSCmdletOutput("Amazon.Batch.Model.UpdateJobQueueResponse",
        "This cmdlet returns an Amazon.Batch.Model.UpdateJobQueueResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateBATJobQueueCmdlet : AmazonBatchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ComputeEnvironmentOrder
        /// <summary>
        /// <para>
        /// <para>Details the set of compute environments mapped to a job queue and their order relative
        /// to each other. This is one of the parameters used by the job scheduler to determine
        /// which compute environment runs a given job. Compute environments must be in the <c>VALID</c>
        /// state before you can associate them with a job queue. All of the compute environments
        /// must be either EC2 (<c>EC2</c> or <c>SPOT</c>) or Fargate (<c>FARGATE</c> or <c>FARGATE_SPOT</c>).
        /// EC2 and Fargate compute environments can't be mixed.</para><note><para>All compute environments that are associated with a job queue must share the same
        /// architecture. Batch doesn't support mixing compute environment architecture types
        /// in a single job queue.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Batch.Model.ComputeEnvironmentOrder[] ComputeEnvironmentOrder { get; set; }
        #endregion
        
        #region Parameter JobQueue
        /// <summary>
        /// <para>
        /// <para>The name or the Amazon Resource Name (ARN) of the job queue.</para>
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
        public System.String JobQueue { get; set; }
        #endregion
        
        #region Parameter JobStateTimeLimitAction
        /// <summary>
        /// <para>
        /// <para>The set of actions that Batch perform on jobs that remain at the head of the job queue
        /// in the specified state longer than specified times. Batch will perform each action
        /// after <c>maxTimeSeconds</c> has passed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobStateTimeLimitActions")]
        public Amazon.Batch.Model.JobStateTimeLimitAction[] JobStateTimeLimitAction { get; set; }
        #endregion
        
        #region Parameter Priority
        /// <summary>
        /// <para>
        /// <para>The priority of the job queue. Job queues with a higher priority (or a higher integer
        /// value for the <c>priority</c> parameter) are evaluated first when associated with
        /// the same compute environment. Priority is determined in descending order. For example,
        /// a job queue with a priority value of <c>10</c> is given scheduling preference over
        /// a job queue with a priority value of <c>1</c>. All of the compute environments must
        /// be either EC2 (<c>EC2</c> or <c>SPOT</c>) or Fargate (<c>FARGATE</c> or <c>FARGATE_SPOT</c>).
        /// EC2 and Fargate compute environments can't be mixed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Priority { get; set; }
        #endregion
        
        #region Parameter SchedulingPolicyArn
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of the fair share scheduling policy. Once a job queue is
        /// created, the fair share scheduling policy can be replaced but not removed. The format
        /// is <c>aws:<i>Partition</i>:batch:<i>Region</i>:<i>Account</i>:scheduling-policy/<i>Name</i></c>. For example, <c>aws:aws:batch:us-west-2:123456789012:scheduling-policy/MySchedulingPolicy</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SchedulingPolicyArn { get; set; }
        #endregion
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// <para>Describes the queue's ability to accept new jobs. If the job queue state is <c>ENABLED</c>,
        /// it can accept jobs. If the job queue state is <c>DISABLED</c>, new jobs can't be added
        /// to the queue, but jobs already in the queue can finish.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Batch.JQState")]
        public Amazon.Batch.JQState State { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Batch.Model.UpdateJobQueueResponse).
        /// Specifying the name of a property of type Amazon.Batch.Model.UpdateJobQueueResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.JobQueue), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BATJobQueue (UpdateJobQueue)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Batch.Model.UpdateJobQueueResponse, UpdateBATJobQueueCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ComputeEnvironmentOrder != null)
            {
                context.ComputeEnvironmentOrder = new List<Amazon.Batch.Model.ComputeEnvironmentOrder>(this.ComputeEnvironmentOrder);
            }
            context.JobQueue = this.JobQueue;
            #if MODULAR
            if (this.JobQueue == null && ParameterWasBound(nameof(this.JobQueue)))
            {
                WriteWarning("You are passing $null as a value for parameter JobQueue which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.JobStateTimeLimitAction != null)
            {
                context.JobStateTimeLimitAction = new List<Amazon.Batch.Model.JobStateTimeLimitAction>(this.JobStateTimeLimitAction);
            }
            context.Priority = this.Priority;
            context.SchedulingPolicyArn = this.SchedulingPolicyArn;
            context.State = this.State;
            
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
            var request = new Amazon.Batch.Model.UpdateJobQueueRequest();
            
            if (cmdletContext.ComputeEnvironmentOrder != null)
            {
                request.ComputeEnvironmentOrder = cmdletContext.ComputeEnvironmentOrder;
            }
            if (cmdletContext.JobQueue != null)
            {
                request.JobQueue = cmdletContext.JobQueue;
            }
            if (cmdletContext.JobStateTimeLimitAction != null)
            {
                request.JobStateTimeLimitActions = cmdletContext.JobStateTimeLimitAction;
            }
            if (cmdletContext.Priority != null)
            {
                request.Priority = cmdletContext.Priority.Value;
            }
            if (cmdletContext.SchedulingPolicyArn != null)
            {
                request.SchedulingPolicyArn = cmdletContext.SchedulingPolicyArn;
            }
            if (cmdletContext.State != null)
            {
                request.State = cmdletContext.State;
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
        
        private Amazon.Batch.Model.UpdateJobQueueResponse CallAWSServiceOperation(IAmazonBatch client, Amazon.Batch.Model.UpdateJobQueueRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Batch", "UpdateJobQueue");
            try
            {
                #if DESKTOP
                return client.UpdateJobQueue(request);
                #elif CORECLR
                return client.UpdateJobQueueAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Batch.Model.ComputeEnvironmentOrder> ComputeEnvironmentOrder { get; set; }
            public System.String JobQueue { get; set; }
            public List<Amazon.Batch.Model.JobStateTimeLimitAction> JobStateTimeLimitAction { get; set; }
            public System.Int32? Priority { get; set; }
            public System.String SchedulingPolicyArn { get; set; }
            public Amazon.Batch.JQState State { get; set; }
            public System.Func<Amazon.Batch.Model.UpdateJobQueueResponse, UpdateBATJobQueueCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
