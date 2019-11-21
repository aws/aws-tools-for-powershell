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
    /// Creates an AWS Batch job queue. When you create a job queue, you associate one or
    /// more compute environments to the queue and assign an order of preference for the compute
    /// environments.
    /// 
    ///  
    /// <para>
    /// You also set a priority to the job queue that determines the order in which the AWS
    /// Batch scheduler places jobs onto its associated compute environments. For example,
    /// if a compute environment is associated with more than one job queue, the job queue
    /// with a higher priority is given preference for scheduling jobs to that compute environment.
    /// </para>
    /// </summary>
    [Cmdlet("New", "BATJobQueue", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Batch.Model.CreateJobQueueResponse")]
    [AWSCmdlet("Calls the AWS Batch CreateJobQueue API operation.", Operation = new[] {"CreateJobQueue"}, SelectReturnType = typeof(Amazon.Batch.Model.CreateJobQueueResponse))]
    [AWSCmdletOutput("Amazon.Batch.Model.CreateJobQueueResponse",
        "This cmdlet returns an Amazon.Batch.Model.CreateJobQueueResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewBATJobQueueCmdlet : AmazonBatchClientCmdlet, IExecutor
    {
        
        #region Parameter ComputeEnvironmentOrder
        /// <summary>
        /// <para>
        /// <para>The set of compute environments mapped to a job queue and their order relative to
        /// each other. The job scheduler uses this parameter to determine which compute environment
        /// should execute a given job. Compute environments must be in the <code>VALID</code>
        /// state before you can associate them with a job queue. You can associate up to three
        /// compute environments with a job queue.</para>
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
        /// <para>The name of the job queue.</para>
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
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? Priority { get; set; }
        #endregion
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// <para>The state of the job queue. If the job queue state is <code>ENABLED</code>, it is
        /// able to accept jobs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Batch.JQState")]
        public Amazon.Batch.JQState State { get; set; }
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
        
        protected override void ProcessRecord()
        {
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
            context.Priority = this.Priority;
            #if MODULAR
            if (this.Priority == null && ParameterWasBound(nameof(this.Priority)))
            {
                WriteWarning("You are passing $null as a value for parameter Priority which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.Batch.Model.CreateJobQueueRequest();
            
            if (cmdletContext.ComputeEnvironmentOrder != null)
            {
                request.ComputeEnvironmentOrder = cmdletContext.ComputeEnvironmentOrder;
            }
            if (cmdletContext.JobQueueName != null)
            {
                request.JobQueueName = cmdletContext.JobQueueName;
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
        
        private Amazon.Batch.Model.CreateJobQueueResponse CallAWSServiceOperation(IAmazonBatch client, Amazon.Batch.Model.CreateJobQueueRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Batch", "CreateJobQueue");
            try
            {
                #if DESKTOP
                return client.CreateJobQueue(request);
                #elif CORECLR
                return client.CreateJobQueueAsync(request).GetAwaiter().GetResult();
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
            public System.String JobQueueName { get; set; }
            public System.Int32? Priority { get; set; }
            public Amazon.Batch.JQState State { get; set; }
            public System.Func<Amazon.Batch.Model.CreateJobQueueResponse, NewBATJobQueueCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
