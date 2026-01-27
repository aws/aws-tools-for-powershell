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
using Amazon.Deadline;
using Amazon.Deadline.Model;

namespace Amazon.PowerShell.Cmdlets.ADC
{
    /// <summary>
    /// Updates a job. 
    /// 
    ///  
    /// <para>
    /// When you change the status of the job to <c>ARCHIVED</c>, the job can't be scheduled
    /// or archived.
    /// </para><important><para>
    /// An archived jobs and its steps and tasks are deleted after 120 days. The job can't
    /// be recovered.
    /// </para></important>
    /// </summary>
    [Cmdlet("Update", "ADCJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWSDeadlineCloud UpdateJob API operation.", Operation = new[] {"UpdateJob"}, SelectReturnType = typeof(Amazon.Deadline.Model.UpdateJobResponse))]
    [AWSCmdletOutput("None or Amazon.Deadline.Model.UpdateJobResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Deadline.Model.UpdateJobResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateADCJobCmdlet : AmazonDeadlineClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The updated job description.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter FarmId
        /// <summary>
        /// <para>
        /// <para>The farm ID of the job to update.</para>
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
        public System.String FarmId { get; set; }
        #endregion
        
        #region Parameter JobId
        /// <summary>
        /// <para>
        /// <para>The job ID to update.</para>
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
        public System.String JobId { get; set; }
        #endregion
        
        #region Parameter LifecycleStatus
        /// <summary>
        /// <para>
        /// <para>The status of a job in its lifecycle. When you change the status of the job to <c>ARCHIVED</c>,
        /// the job can't be scheduled or archived.</para><important><para>An archived jobs and its steps and tasks are deleted after 120 days. The job can't
        /// be recovered.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Deadline.UpdateJobLifecycleStatus")]
        public Amazon.Deadline.UpdateJobLifecycleStatus LifecycleStatus { get; set; }
        #endregion
        
        #region Parameter MaxFailedTasksCount
        /// <summary>
        /// <para>
        /// <para>The number of task failures before the job stops running and is marked as <c>FAILED</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxFailedTasksCount { get; set; }
        #endregion
        
        #region Parameter MaxRetriesPerTask
        /// <summary>
        /// <para>
        /// <para>The maximum number of retries for a job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxRetriesPerTask { get; set; }
        #endregion
        
        #region Parameter MaxWorkerCount
        /// <summary>
        /// <para>
        /// <para>The maximum number of worker hosts that can concurrently process a job. When the <c>maxWorkerCount</c>
        /// is reached, no more workers will be assigned to process the job, even if the fleets
        /// assigned to the job's queue has available workers.</para><para>You can't set the <c>maxWorkerCount</c> to 0. If you set it to -1, there is no maximum
        /// number of workers.</para><para>If you don't specify the <c>maxWorkerCount</c>, the default is -1.</para><para>The maximum number of workers that can process tasks in the job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxWorkerCount { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The updated job name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Priority
        /// <summary>
        /// <para>
        /// <para>The updated job priority.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Priority { get; set; }
        #endregion
        
        #region Parameter QueueId
        /// <summary>
        /// <para>
        /// <para>The queue ID of the job to update.</para>
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
        public System.String QueueId { get; set; }
        #endregion
        
        #region Parameter TargetTaskRunStatus
        /// <summary>
        /// <para>
        /// <para>The task status to update the job's tasks to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Deadline.JobTargetTaskRunStatus")]
        public Amazon.Deadline.JobTargetTaskRunStatus TargetTaskRunStatus { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The unique token which the server uses to recognize retries of the same request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Deadline.Model.UpdateJobResponse).
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ADCJob (UpdateJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Deadline.Model.UpdateJobResponse, UpdateADCJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.FarmId = this.FarmId;
            #if MODULAR
            if (this.FarmId == null && ParameterWasBound(nameof(this.FarmId)))
            {
                WriteWarning("You are passing $null as a value for parameter FarmId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.JobId = this.JobId;
            #if MODULAR
            if (this.JobId == null && ParameterWasBound(nameof(this.JobId)))
            {
                WriteWarning("You are passing $null as a value for parameter JobId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LifecycleStatus = this.LifecycleStatus;
            context.MaxFailedTasksCount = this.MaxFailedTasksCount;
            context.MaxRetriesPerTask = this.MaxRetriesPerTask;
            context.MaxWorkerCount = this.MaxWorkerCount;
            context.Name = this.Name;
            context.Priority = this.Priority;
            context.QueueId = this.QueueId;
            #if MODULAR
            if (this.QueueId == null && ParameterWasBound(nameof(this.QueueId)))
            {
                WriteWarning("You are passing $null as a value for parameter QueueId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetTaskRunStatus = this.TargetTaskRunStatus;
            
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
            var request = new Amazon.Deadline.Model.UpdateJobRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.FarmId != null)
            {
                request.FarmId = cmdletContext.FarmId;
            }
            if (cmdletContext.JobId != null)
            {
                request.JobId = cmdletContext.JobId;
            }
            if (cmdletContext.LifecycleStatus != null)
            {
                request.LifecycleStatus = cmdletContext.LifecycleStatus;
            }
            if (cmdletContext.MaxFailedTasksCount != null)
            {
                request.MaxFailedTasksCount = cmdletContext.MaxFailedTasksCount.Value;
            }
            if (cmdletContext.MaxRetriesPerTask != null)
            {
                request.MaxRetriesPerTask = cmdletContext.MaxRetriesPerTask.Value;
            }
            if (cmdletContext.MaxWorkerCount != null)
            {
                request.MaxWorkerCount = cmdletContext.MaxWorkerCount.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Priority != null)
            {
                request.Priority = cmdletContext.Priority.Value;
            }
            if (cmdletContext.QueueId != null)
            {
                request.QueueId = cmdletContext.QueueId;
            }
            if (cmdletContext.TargetTaskRunStatus != null)
            {
                request.TargetTaskRunStatus = cmdletContext.TargetTaskRunStatus;
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
        
        private Amazon.Deadline.Model.UpdateJobResponse CallAWSServiceOperation(IAmazonDeadline client, Amazon.Deadline.Model.UpdateJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWSDeadlineCloud", "UpdateJob");
            try
            {
                #if DESKTOP
                return client.UpdateJob(request);
                #elif CORECLR
                return client.UpdateJobAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String FarmId { get; set; }
            public System.String JobId { get; set; }
            public Amazon.Deadline.UpdateJobLifecycleStatus LifecycleStatus { get; set; }
            public System.Int32? MaxFailedTasksCount { get; set; }
            public System.Int32? MaxRetriesPerTask { get; set; }
            public System.Int32? MaxWorkerCount { get; set; }
            public System.String Name { get; set; }
            public System.Int32? Priority { get; set; }
            public System.String QueueId { get; set; }
            public Amazon.Deadline.JobTargetTaskRunStatus TargetTaskRunStatus { get; set; }
            public System.Func<Amazon.Deadline.Model.UpdateJobResponse, UpdateADCJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
