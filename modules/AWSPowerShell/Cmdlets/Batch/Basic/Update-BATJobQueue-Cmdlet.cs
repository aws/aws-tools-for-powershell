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
        
        #region Parameter ComputeEnvironmentOrder
        /// <summary>
        /// <para>
        /// <para>Details the set of compute environments mapped to a job queue and their order relative
        /// to each other. This is one of the parameters used by the job scheduler to determine
        /// which compute environment should execute a given job.</para>
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
        
        #region Parameter Priority
        /// <summary>
        /// <para>
        /// <para>The priority of the job queue. Job queues with a higher priority (or a higher integer
        /// value for the <code>priority</code> parameter) are evaluated first when associated
        /// with the same compute environment. Priority is determined in descending order, for
        /// example, a job queue with a priority value of <code>10</code> is given scheduling
        /// preference over a job queue with a priority value of <code>1</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Priority { get; set; }
        #endregion
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// <para>Describes the queue's ability to accept new jobs. If the job queue state is <code>ENABLED</code>,
        /// it is able to accept jobs. If the job queue state is <code>DISABLED</code>, new jobs
        /// cannot be added to the queue, but jobs already in the queue can finish.</para>
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the JobQueue parameter.
        /// The -PassThru parameter is deprecated, use -Select '^JobQueue' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^JobQueue' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.JobQueue), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BATJobQueue (UpdateJobQueue)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Batch.Model.UpdateJobQueueResponse, UpdateBATJobQueueCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.JobQueue;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            context.Priority = this.Priority;
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
            if (cmdletContext.Priority != null)
            {
                request.Priority = cmdletContext.Priority.Value;
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
            public System.Int32? Priority { get; set; }
            public Amazon.Batch.JQState State { get; set; }
            public System.Func<Amazon.Batch.Model.UpdateJobQueueResponse, UpdateBATJobQueueCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
