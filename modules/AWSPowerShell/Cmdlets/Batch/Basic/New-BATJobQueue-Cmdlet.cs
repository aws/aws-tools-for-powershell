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
using Amazon.Batch;
using Amazon.Batch.Model;

namespace Amazon.PowerShell.Cmdlets.BAT
{
    /// <summary>
    /// Creates an Batch job queue. When you create a job queue, you associate one or more
    /// compute environments to the queue and assign an order of preference for the compute
    /// environments.
    /// 
    ///  
    /// <para>
    /// You also set a priority to the job queue that determines the order that the Batch
    /// scheduler places jobs onto its associated compute environments. For example, if a
    /// compute environment is associated with more than one job queue, the job queue with
    /// a higher priority is given preference for scheduling jobs to that compute environment.
    /// </para>
    /// </summary>
    [Cmdlet("New", "BATJobQueue", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Batch.Model.CreateJobQueueResponse")]
    [AWSCmdlet("Calls the AWS Batch CreateJobQueue API operation.", Operation = new[] {"CreateJobQueue"}, SelectReturnType = typeof(Amazon.Batch.Model.CreateJobQueueResponse))]
    [AWSCmdletOutput("Amazon.Batch.Model.CreateJobQueueResponse",
        "This cmdlet returns an Amazon.Batch.Model.CreateJobQueueResponse object containing multiple properties."
    )]
    public partial class NewBATJobQueueCmdlet : AmazonBatchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ComputeEnvironmentOrder
        /// <summary>
        /// <para>
        /// <para>The set of compute environments mapped to a job queue and their order relative to
        /// each other. The job scheduler uses this parameter to determine which compute environment
        /// runs a specific job. Compute environments must be in the <c>VALID</c> state before
        /// you can associate them with a job queue. You can associate up to three compute environments
        /// with a job queue. All of the compute environments must be either EC2 (<c>EC2</c> or
        /// <c>SPOT</c>) or Fargate (<c>FARGATE</c> or <c>FARGATE_SPOT</c>); EC2 and Fargate compute
        /// environments can't be mixed.</para><note><para>All compute environments that are associated with a job queue must share the same
        /// architecture. Batch doesn't support mixing compute environment architecture types
        /// in a single job queue.</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.Batch.Model.ComputeEnvironmentOrder[] ComputeEnvironmentOrder { get; set; }
        #endregion
        
        #region Parameter JobQueueName
        /// <summary>
        /// <para>
        /// <para>The name of the job queue. It can be up to 128 letters long. It can contain uppercase
        /// and lowercase letters, numbers, hyphens (-), and underscores (_).</para>
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
        public System.String JobQueueName { get; set; }
        #endregion
        
        #region Parameter JobStateTimeLimitAction
        /// <summary>
        /// <para>
        /// <para>The set of actions that Batch performs on jobs that remain at the head of the job
        /// queue in the specified state longer than specified times. Batch will perform each
        /// action after <c>maxTimeSeconds</c> has passed. (<b>Note</b>: The minimum value for
        /// maxTimeSeconds is 600 (10 minutes) and its maximum value is 86,400 (24 hours).)</para>
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
        /// be either EC2 (<c>EC2</c> or <c>SPOT</c>) or Fargate (<c>FARGATE</c> or <c>FARGATE_SPOT</c>);
        /// EC2 and Fargate compute environments can't be mixed.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? Priority { get; set; }
        #endregion
        
        #region Parameter SchedulingPolicyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the fair-share scheduling policy. Job queues that
        /// don't have a fair-share scheduling policy are scheduled in a first-in, first-out (FIFO)
        /// model. After a job queue has a fair-share scheduling policy, it can be replaced but
        /// can't be removed.</para><para>The format is <c>aws:<i>Partition</i>:batch:<i>Region</i>:<i>Account</i>:scheduling-policy/<i>Name</i></c>.</para><para>An example is <c>aws:aws:batch:us-west-2:123456789012:scheduling-policy/MySchedulingPolicy</c>.</para><para>A job queue without a fair-share scheduling policy is scheduled as a FIFO job queue
        /// and can't have a fair-share scheduling policy added. Jobs queues with a fair-share
        /// scheduling policy can have a maximum of 500 active share identifiers. When the limit
        /// has been reached, submissions of any jobs that add a new share identifier fail.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SchedulingPolicyArn { get; set; }
        #endregion
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// <para>The state of the job queue. If the job queue state is <c>ENABLED</c>, it is able to
        /// accept jobs. If the job queue state is <c>DISABLED</c>, new jobs can't be added to
        /// the queue, but jobs already in the queue can finish.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Batch.JQState")]
        public Amazon.Batch.JQState State { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags that you apply to the job queue to help you categorize and organize your
        /// resources. Each tag consists of a key and an optional value. For more information,
        /// see <a href="https://docs.aws.amazon.com/batch/latest/userguide/using-tags.html">Tagging
        /// your Batch resources</a> in <i>Batch User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Batch.Model.CreateJobQueueResponse).
        /// Specifying the name of a property of type Amazon.Batch.Model.CreateJobQueueResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.JobQueueName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BATJobQueue (CreateJobQueue)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Batch.Model.CreateJobQueueResponse, NewBATJobQueueCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ComputeEnvironmentOrder != null)
            {
                context.ComputeEnvironmentOrder = new List<Amazon.Batch.Model.ComputeEnvironmentOrder>(this.ComputeEnvironmentOrder);
            }
            #if MODULAR
            if (this.ComputeEnvironmentOrder == null && ParameterWasBound(nameof(this.ComputeEnvironmentOrder)))
            {
                WriteWarning("You are passing $null as a value for parameter ComputeEnvironmentOrder which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.JobQueueName = this.JobQueueName;
            #if MODULAR
            if (this.JobQueueName == null && ParameterWasBound(nameof(this.JobQueueName)))
            {
                WriteWarning("You are passing $null as a value for parameter JobQueueName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.JobStateTimeLimitAction != null)
            {
                context.JobStateTimeLimitAction = new List<Amazon.Batch.Model.JobStateTimeLimitAction>(this.JobStateTimeLimitAction);
            }
            context.Priority = this.Priority;
            #if MODULAR
            if (this.Priority == null && ParameterWasBound(nameof(this.Priority)))
            {
                WriteWarning("You are passing $null as a value for parameter Priority which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SchedulingPolicyArn = this.SchedulingPolicyArn;
            context.State = this.State;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.Batch.Model.CreateJobQueueRequest();
            
            if (cmdletContext.ComputeEnvironmentOrder != null)
            {
                request.ComputeEnvironmentOrder = cmdletContext.ComputeEnvironmentOrder;
            }
            if (cmdletContext.JobQueueName != null)
            {
                request.JobQueueName = cmdletContext.JobQueueName;
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
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Batch.Model.CreateJobQueueResponse CallAWSServiceOperation(IAmazonBatch client, Amazon.Batch.Model.CreateJobQueueRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Batch", "CreateJobQueue");
            try
            {
                return client.CreateJobQueueAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String JobQueueName { get; set; }
            public List<Amazon.Batch.Model.JobStateTimeLimitAction> JobStateTimeLimitAction { get; set; }
            public System.Int32? Priority { get; set; }
            public System.String SchedulingPolicyArn { get; set; }
            public Amazon.Batch.JQState State { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Batch.Model.CreateJobQueueResponse, NewBATJobQueueCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
