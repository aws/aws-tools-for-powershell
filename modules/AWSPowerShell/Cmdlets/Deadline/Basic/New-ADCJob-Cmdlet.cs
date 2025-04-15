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
using Amazon.Deadline;
using Amazon.Deadline.Model;

namespace Amazon.PowerShell.Cmdlets.ADC
{
    /// <summary>
    /// Creates a job. A job is a set of instructions that Deadline Cloud uses to schedule
    /// and run work on available workers. For more information, see <a href="https://docs.aws.amazon.com/deadline-cloud/latest/userguide/deadline-cloud-jobs.html">Deadline
    /// Cloud jobs</a>.
    /// </summary>
    [Cmdlet("New", "ADCJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWSDeadlineCloud CreateJob API operation.", Operation = new[] {"CreateJob"}, SelectReturnType = typeof(Amazon.Deadline.Model.CreateJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.Deadline.Model.CreateJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Deadline.Model.CreateJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewADCJobCmdlet : AmazonDeadlineClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter FarmId
        /// <summary>
        /// <para>
        /// <para>The farm ID of the farm to connect to the job.</para>
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
        
        #region Parameter Attachments_FileSystem
        /// <summary>
        /// <para>
        /// <para>The file system.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Deadline.JobAttachmentsFileSystem")]
        public Amazon.Deadline.JobAttachmentsFileSystem Attachments_FileSystem { get; set; }
        #endregion
        
        #region Parameter Attachments_Manifest
        /// <summary>
        /// <para>
        /// <para>A list of manifests which describe job attachment configurations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attachments_Manifests")]
        public Amazon.Deadline.Model.ManifestProperties[] Attachments_Manifest { get; set; }
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
        /// <para>The maximum number of retries for each task.</para>
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
        /// number of workers.</para><para>If you don't specify the <c>maxWorkerCount</c>, Deadline Cloud won't throttle the
        /// number of workers used to process the job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxWorkerCount { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>The parameters for the job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters")]
        public System.Collections.Hashtable Parameter { get; set; }
        #endregion
        
        #region Parameter Priority
        /// <summary>
        /// <para>
        /// <para>The priority of the job. The highest priority (first scheduled) is 100. When two jobs
        /// have the same priority, the oldest job is scheduled first.</para>
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
        
        #region Parameter QueueId
        /// <summary>
        /// <para>
        /// <para>The ID of the queue that the job is submitted to.</para>
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
        
        #region Parameter SourceJobId
        /// <summary>
        /// <para>
        /// <para>The job ID for the source job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceJobId { get; set; }
        #endregion
        
        #region Parameter StorageProfileId
        /// <summary>
        /// <para>
        /// <para>The storage profile ID for the storage profile to connect to the job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageProfileId { get; set; }
        #endregion
        
        #region Parameter TargetTaskRunStatus
        /// <summary>
        /// <para>
        /// <para>The initial job status when it is created. Jobs that are created with a <c>SUSPENDED</c>
        /// status will not run until manually requeued.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Deadline.CreateJobTargetTaskRunStatus")]
        public Amazon.Deadline.CreateJobTargetTaskRunStatus TargetTaskRunStatus { get; set; }
        #endregion
        
        #region Parameter Template
        /// <summary>
        /// <para>
        /// <para>The job template to use for this job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Template { get; set; }
        #endregion
        
        #region Parameter TemplateType
        /// <summary>
        /// <para>
        /// <para>The file type for the job template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Deadline.JobTemplateType")]
        public Amazon.Deadline.JobTemplateType TemplateType { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Deadline.Model.CreateJobResponse).
        /// Specifying the name of a property of type Amazon.Deadline.Model.CreateJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobId";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ADCJob (CreateJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Deadline.Model.CreateJobResponse, NewADCJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Attachments_FileSystem = this.Attachments_FileSystem;
            if (this.Attachments_Manifest != null)
            {
                context.Attachments_Manifest = new List<Amazon.Deadline.Model.ManifestProperties>(this.Attachments_Manifest);
            }
            context.ClientToken = this.ClientToken;
            context.FarmId = this.FarmId;
            #if MODULAR
            if (this.FarmId == null && ParameterWasBound(nameof(this.FarmId)))
            {
                WriteWarning("You are passing $null as a value for parameter FarmId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxFailedTasksCount = this.MaxFailedTasksCount;
            context.MaxRetriesPerTask = this.MaxRetriesPerTask;
            context.MaxWorkerCount = this.MaxWorkerCount;
            if (this.Parameter != null)
            {
                context.Parameter = new Dictionary<System.String, Amazon.Deadline.Model.JobParameter>(StringComparer.Ordinal);
                foreach (var hashKey in this.Parameter.Keys)
                {
                    context.Parameter.Add((String)hashKey, (Amazon.Deadline.Model.JobParameter)(this.Parameter[hashKey]));
                }
            }
            context.Priority = this.Priority;
            #if MODULAR
            if (this.Priority == null && ParameterWasBound(nameof(this.Priority)))
            {
                WriteWarning("You are passing $null as a value for parameter Priority which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.QueueId = this.QueueId;
            #if MODULAR
            if (this.QueueId == null && ParameterWasBound(nameof(this.QueueId)))
            {
                WriteWarning("You are passing $null as a value for parameter QueueId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceJobId = this.SourceJobId;
            context.StorageProfileId = this.StorageProfileId;
            context.TargetTaskRunStatus = this.TargetTaskRunStatus;
            context.Template = this.Template;
            context.TemplateType = this.TemplateType;
            
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
            var request = new Amazon.Deadline.Model.CreateJobRequest();
            
            
             // populate Attachments
            var requestAttachmentsIsNull = true;
            request.Attachments = new Amazon.Deadline.Model.Attachments();
            Amazon.Deadline.JobAttachmentsFileSystem requestAttachments_attachments_FileSystem = null;
            if (cmdletContext.Attachments_FileSystem != null)
            {
                requestAttachments_attachments_FileSystem = cmdletContext.Attachments_FileSystem;
            }
            if (requestAttachments_attachments_FileSystem != null)
            {
                request.Attachments.FileSystem = requestAttachments_attachments_FileSystem;
                requestAttachmentsIsNull = false;
            }
            List<Amazon.Deadline.Model.ManifestProperties> requestAttachments_attachments_Manifest = null;
            if (cmdletContext.Attachments_Manifest != null)
            {
                requestAttachments_attachments_Manifest = cmdletContext.Attachments_Manifest;
            }
            if (requestAttachments_attachments_Manifest != null)
            {
                request.Attachments.Manifests = requestAttachments_attachments_Manifest;
                requestAttachmentsIsNull = false;
            }
             // determine if request.Attachments should be set to null
            if (requestAttachmentsIsNull)
            {
                request.Attachments = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.FarmId != null)
            {
                request.FarmId = cmdletContext.FarmId;
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
            if (cmdletContext.Parameter != null)
            {
                request.Parameters = cmdletContext.Parameter;
            }
            if (cmdletContext.Priority != null)
            {
                request.Priority = cmdletContext.Priority.Value;
            }
            if (cmdletContext.QueueId != null)
            {
                request.QueueId = cmdletContext.QueueId;
            }
            if (cmdletContext.SourceJobId != null)
            {
                request.SourceJobId = cmdletContext.SourceJobId;
            }
            if (cmdletContext.StorageProfileId != null)
            {
                request.StorageProfileId = cmdletContext.StorageProfileId;
            }
            if (cmdletContext.TargetTaskRunStatus != null)
            {
                request.TargetTaskRunStatus = cmdletContext.TargetTaskRunStatus;
            }
            if (cmdletContext.Template != null)
            {
                request.Template = cmdletContext.Template;
            }
            if (cmdletContext.TemplateType != null)
            {
                request.TemplateType = cmdletContext.TemplateType;
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
        
        private Amazon.Deadline.Model.CreateJobResponse CallAWSServiceOperation(IAmazonDeadline client, Amazon.Deadline.Model.CreateJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWSDeadlineCloud", "CreateJob");
            try
            {
                return client.CreateJobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Deadline.JobAttachmentsFileSystem Attachments_FileSystem { get; set; }
            public List<Amazon.Deadline.Model.ManifestProperties> Attachments_Manifest { get; set; }
            public System.String ClientToken { get; set; }
            public System.String FarmId { get; set; }
            public System.Int32? MaxFailedTasksCount { get; set; }
            public System.Int32? MaxRetriesPerTask { get; set; }
            public System.Int32? MaxWorkerCount { get; set; }
            public Dictionary<System.String, Amazon.Deadline.Model.JobParameter> Parameter { get; set; }
            public System.Int32? Priority { get; set; }
            public System.String QueueId { get; set; }
            public System.String SourceJobId { get; set; }
            public System.String StorageProfileId { get; set; }
            public Amazon.Deadline.CreateJobTargetTaskRunStatus TargetTaskRunStatus { get; set; }
            public System.String Template { get; set; }
            public Amazon.Deadline.JobTemplateType TemplateType { get; set; }
            public System.Func<Amazon.Deadline.Model.CreateJobResponse, NewADCJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobId;
        }
        
    }
}
