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
using Amazon.DataSync;
using Amazon.DataSync.Model;

namespace Amazon.PowerShell.Cmdlets.DSYN
{
    /// <summary>
    /// Updates the configuration of a DataSync transfer task.
    /// </summary>
    [Cmdlet("Update", "DSYNTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS DataSync UpdateTask API operation.", Operation = new[] {"UpdateTask"}, SelectReturnType = typeof(Amazon.DataSync.Model.UpdateTaskResponse))]
    [AWSCmdletOutput("None or Amazon.DataSync.Model.UpdateTaskResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.DataSync.Model.UpdateTaskResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateDSYNTaskCmdlet : AmazonDataSyncClientCmdlet, IExecutor
    {
        
        #region Parameter S3_BucketAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>Specifies the Amazon Resource Name (ARN) of the IAM policy that allows DataSync to
        /// upload a task report to your S3 bucket. For more information, see <a href="https://docs.aws.amazon.com/https:/docs.aws.amazon.com/datasync/latest/userguide/creating-task-reports.html">Allowing
        /// DataSync to upload a task report to an Amazon S3 bucket</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaskReportConfig_Destination_S3_BucketAccessRoleArn")]
        public System.String S3_BucketAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogGroupArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the resource name of the Amazon CloudWatch log group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CloudWatchLogGroupArn { get; set; }
        #endregion
        
        #region Parameter Exclude
        /// <summary>
        /// <para>
        /// <para>Specifies a list of filter rules that exclude specific data during your transfer.
        /// For more information and examples, see <a href="https://docs.aws.amazon.com/datasync/latest/userguide/filtering.html">Filtering
        /// data transferred by DataSync</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Excludes")]
        public Amazon.DataSync.Model.FilterRule[] Exclude { get; set; }
        #endregion
        
        #region Parameter Include
        /// <summary>
        /// <para>
        /// <para>Specifies a list of filter rules that include specific data during your transfer.
        /// For more information and examples, see <a href="https://docs.aws.amazon.com/datasync/latest/userguide/filtering.html">Filtering
        /// data transferred by DataSync</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Includes")]
        public Amazon.DataSync.Model.FilterRule[] Include { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the task to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter TaskReportConfig_ObjectVersionId
        /// <summary>
        /// <para>
        /// <para>Specifies whether your task report includes the new version of each object transferred
        /// into an S3 bucket. This only applies if you <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/manage-versioning-examples.html">enable
        /// versioning on your bucket</a>. Keep in mind that setting this to <code>INCLUDE</code>
        /// can increase the duration of your task execution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaskReportConfig_ObjectVersionIds")]
        [AWSConstantClassSource("Amazon.DataSync.ObjectVersionIds")]
        public Amazon.DataSync.ObjectVersionIds TaskReportConfig_ObjectVersionId { get; set; }
        #endregion
        
        #region Parameter Option
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Options")]
        public Amazon.DataSync.Model.Options Option { get; set; }
        #endregion
        
        #region Parameter TaskReportConfig_OutputType
        /// <summary>
        /// <para>
        /// <para>Specifies the type of task report that you want:</para><ul><li><para><code>SUMMARY_ONLY</code>: Provides necessary details about your task, including
        /// the number of files, objects, and directories transferred and transfer duration.</para></li><li><para><code>STANDARD</code>: Provides complete details about your task, including a full
        /// list of files, objects, and directories that were transferred, skipped, verified,
        /// and more.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DataSync.ReportOutputType")]
        public Amazon.DataSync.ReportOutputType TaskReportConfig_OutputType { get; set; }
        #endregion
        
        #region Parameter Deleted_ReportLevel
        /// <summary>
        /// <para>
        /// <para>Specifies whether your task report includes errors only or successes and errors.</para><para>For example, your report might mostly include only what didn't go well in your transfer
        /// (<code>ERRORS_ONLY</code>). At the same time, you want to verify that your <a href="https://docs.aws.amazon.com/datasync/latest/userguide/filtering.html">task
        /// filter</a> is working correctly. In this situation, you can get a list of what files
        /// DataSync successfully skipped and if something transferred that you didn't to transfer
        /// (<code>SUCCESSES_AND_ERRORS</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaskReportConfig_Overrides_Deleted_ReportLevel")]
        [AWSConstantClassSource("Amazon.DataSync.ReportLevel")]
        public Amazon.DataSync.ReportLevel Deleted_ReportLevel { get; set; }
        #endregion
        
        #region Parameter Skipped_ReportLevel
        /// <summary>
        /// <para>
        /// <para>Specifies whether your task report includes errors only or successes and errors.</para><para>For example, your report might mostly include only what didn't go well in your transfer
        /// (<code>ERRORS_ONLY</code>). At the same time, you want to verify that your <a href="https://docs.aws.amazon.com/datasync/latest/userguide/filtering.html">task
        /// filter</a> is working correctly. In this situation, you can get a list of what files
        /// DataSync successfully skipped and if something transferred that you didn't to transfer
        /// (<code>SUCCESSES_AND_ERRORS</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaskReportConfig_Overrides_Skipped_ReportLevel")]
        [AWSConstantClassSource("Amazon.DataSync.ReportLevel")]
        public Amazon.DataSync.ReportLevel Skipped_ReportLevel { get; set; }
        #endregion
        
        #region Parameter Transferred_ReportLevel
        /// <summary>
        /// <para>
        /// <para>Specifies whether your task report includes errors only or successes and errors.</para><para>For example, your report might mostly include only what didn't go well in your transfer
        /// (<code>ERRORS_ONLY</code>). At the same time, you want to verify that your <a href="https://docs.aws.amazon.com/datasync/latest/userguide/filtering.html">task
        /// filter</a> is working correctly. In this situation, you can get a list of what files
        /// DataSync successfully skipped and if something transferred that you didn't to transfer
        /// (<code>SUCCESSES_AND_ERRORS</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaskReportConfig_Overrides_Transferred_ReportLevel")]
        [AWSConstantClassSource("Amazon.DataSync.ReportLevel")]
        public Amazon.DataSync.ReportLevel Transferred_ReportLevel { get; set; }
        #endregion
        
        #region Parameter Verified_ReportLevel
        /// <summary>
        /// <para>
        /// <para>Specifies whether your task report includes errors only or successes and errors.</para><para>For example, your report might mostly include only what didn't go well in your transfer
        /// (<code>ERRORS_ONLY</code>). At the same time, you want to verify that your <a href="https://docs.aws.amazon.com/datasync/latest/userguide/filtering.html">task
        /// filter</a> is working correctly. In this situation, you can get a list of what files
        /// DataSync successfully skipped and if something transferred that you didn't to transfer
        /// (<code>SUCCESSES_AND_ERRORS</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaskReportConfig_Overrides_Verified_ReportLevel")]
        [AWSConstantClassSource("Amazon.DataSync.ReportLevel")]
        public Amazon.DataSync.ReportLevel Verified_ReportLevel { get; set; }
        #endregion
        
        #region Parameter TaskReportConfig_ReportLevel
        /// <summary>
        /// <para>
        /// <para>Specifies whether you want your task report to include only what went wrong with your
        /// transfer or a list of what succeeded and didn't.</para><ul><li><para><code>ERRORS_ONLY</code>: A report shows what DataSync was unable to transfer, skip,
        /// verify, and delete.</para></li><li><para><code>SUCCESSES_AND_ERRORS</code>: A report shows what DataSync was able and unable
        /// to transfer, skip, verify, and delete.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DataSync.ReportLevel")]
        public Amazon.DataSync.ReportLevel TaskReportConfig_ReportLevel { get; set; }
        #endregion
        
        #region Parameter S3_S3BucketArn
        /// <summary>
        /// <para>
        /// <para>Specifies the ARN of the S3 bucket where DataSync uploads your report.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaskReportConfig_Destination_S3_S3BucketArn")]
        public System.String S3_S3BucketArn { get; set; }
        #endregion
        
        #region Parameter Schedule_ScheduleExpression
        /// <summary>
        /// <para>
        /// <para>A cron expression that specifies when DataSync initiates a scheduled transfer from
        /// a source to a destination location. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Schedule_ScheduleExpression { get; set; }
        #endregion
        
        #region Parameter S3_Subdirectory
        /// <summary>
        /// <para>
        /// <para>Specifies a bucket prefix for your report.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaskReportConfig_Destination_S3_Subdirectory")]
        public System.String S3_Subdirectory { get; set; }
        #endregion
        
        #region Parameter TaskArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the resource name of the task to update.</para>
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
        public System.String TaskArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataSync.Model.UpdateTaskResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TaskArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TaskArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TaskArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TaskArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DSYNTask (UpdateTask)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataSync.Model.UpdateTaskResponse, UpdateDSYNTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TaskArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CloudWatchLogGroupArn = this.CloudWatchLogGroupArn;
            if (this.Exclude != null)
            {
                context.Exclude = new List<Amazon.DataSync.Model.FilterRule>(this.Exclude);
            }
            if (this.Include != null)
            {
                context.Include = new List<Amazon.DataSync.Model.FilterRule>(this.Include);
            }
            context.Name = this.Name;
            context.Option = this.Option;
            context.Schedule_ScheduleExpression = this.Schedule_ScheduleExpression;
            context.TaskArn = this.TaskArn;
            #if MODULAR
            if (this.TaskArn == null && ParameterWasBound(nameof(this.TaskArn)))
            {
                WriteWarning("You are passing $null as a value for parameter TaskArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3_BucketAccessRoleArn = this.S3_BucketAccessRoleArn;
            context.S3_S3BucketArn = this.S3_S3BucketArn;
            context.S3_Subdirectory = this.S3_Subdirectory;
            context.TaskReportConfig_ObjectVersionId = this.TaskReportConfig_ObjectVersionId;
            context.TaskReportConfig_OutputType = this.TaskReportConfig_OutputType;
            context.Deleted_ReportLevel = this.Deleted_ReportLevel;
            context.Skipped_ReportLevel = this.Skipped_ReportLevel;
            context.Transferred_ReportLevel = this.Transferred_ReportLevel;
            context.Verified_ReportLevel = this.Verified_ReportLevel;
            context.TaskReportConfig_ReportLevel = this.TaskReportConfig_ReportLevel;
            
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
            var request = new Amazon.DataSync.Model.UpdateTaskRequest();
            
            if (cmdletContext.CloudWatchLogGroupArn != null)
            {
                request.CloudWatchLogGroupArn = cmdletContext.CloudWatchLogGroupArn;
            }
            if (cmdletContext.Exclude != null)
            {
                request.Excludes = cmdletContext.Exclude;
            }
            if (cmdletContext.Include != null)
            {
                request.Includes = cmdletContext.Include;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Option != null)
            {
                request.Options = cmdletContext.Option;
            }
            
             // populate Schedule
            var requestScheduleIsNull = true;
            request.Schedule = new Amazon.DataSync.Model.TaskSchedule();
            System.String requestSchedule_schedule_ScheduleExpression = null;
            if (cmdletContext.Schedule_ScheduleExpression != null)
            {
                requestSchedule_schedule_ScheduleExpression = cmdletContext.Schedule_ScheduleExpression;
            }
            if (requestSchedule_schedule_ScheduleExpression != null)
            {
                request.Schedule.ScheduleExpression = requestSchedule_schedule_ScheduleExpression;
                requestScheduleIsNull = false;
            }
             // determine if request.Schedule should be set to null
            if (requestScheduleIsNull)
            {
                request.Schedule = null;
            }
            if (cmdletContext.TaskArn != null)
            {
                request.TaskArn = cmdletContext.TaskArn;
            }
            
             // populate TaskReportConfig
            var requestTaskReportConfigIsNull = true;
            request.TaskReportConfig = new Amazon.DataSync.Model.TaskReportConfig();
            Amazon.DataSync.ObjectVersionIds requestTaskReportConfig_taskReportConfig_ObjectVersionId = null;
            if (cmdletContext.TaskReportConfig_ObjectVersionId != null)
            {
                requestTaskReportConfig_taskReportConfig_ObjectVersionId = cmdletContext.TaskReportConfig_ObjectVersionId;
            }
            if (requestTaskReportConfig_taskReportConfig_ObjectVersionId != null)
            {
                request.TaskReportConfig.ObjectVersionIds = requestTaskReportConfig_taskReportConfig_ObjectVersionId;
                requestTaskReportConfigIsNull = false;
            }
            Amazon.DataSync.ReportOutputType requestTaskReportConfig_taskReportConfig_OutputType = null;
            if (cmdletContext.TaskReportConfig_OutputType != null)
            {
                requestTaskReportConfig_taskReportConfig_OutputType = cmdletContext.TaskReportConfig_OutputType;
            }
            if (requestTaskReportConfig_taskReportConfig_OutputType != null)
            {
                request.TaskReportConfig.OutputType = requestTaskReportConfig_taskReportConfig_OutputType;
                requestTaskReportConfigIsNull = false;
            }
            Amazon.DataSync.ReportLevel requestTaskReportConfig_taskReportConfig_ReportLevel = null;
            if (cmdletContext.TaskReportConfig_ReportLevel != null)
            {
                requestTaskReportConfig_taskReportConfig_ReportLevel = cmdletContext.TaskReportConfig_ReportLevel;
            }
            if (requestTaskReportConfig_taskReportConfig_ReportLevel != null)
            {
                request.TaskReportConfig.ReportLevel = requestTaskReportConfig_taskReportConfig_ReportLevel;
                requestTaskReportConfigIsNull = false;
            }
            Amazon.DataSync.Model.ReportDestination requestTaskReportConfig_taskReportConfig_Destination = null;
            
             // populate Destination
            var requestTaskReportConfig_taskReportConfig_DestinationIsNull = true;
            requestTaskReportConfig_taskReportConfig_Destination = new Amazon.DataSync.Model.ReportDestination();
            Amazon.DataSync.Model.ReportDestinationS3 requestTaskReportConfig_taskReportConfig_Destination_taskReportConfig_Destination_S3 = null;
            
             // populate S3
            var requestTaskReportConfig_taskReportConfig_Destination_taskReportConfig_Destination_S3IsNull = true;
            requestTaskReportConfig_taskReportConfig_Destination_taskReportConfig_Destination_S3 = new Amazon.DataSync.Model.ReportDestinationS3();
            System.String requestTaskReportConfig_taskReportConfig_Destination_taskReportConfig_Destination_S3_s3_BucketAccessRoleArn = null;
            if (cmdletContext.S3_BucketAccessRoleArn != null)
            {
                requestTaskReportConfig_taskReportConfig_Destination_taskReportConfig_Destination_S3_s3_BucketAccessRoleArn = cmdletContext.S3_BucketAccessRoleArn;
            }
            if (requestTaskReportConfig_taskReportConfig_Destination_taskReportConfig_Destination_S3_s3_BucketAccessRoleArn != null)
            {
                requestTaskReportConfig_taskReportConfig_Destination_taskReportConfig_Destination_S3.BucketAccessRoleArn = requestTaskReportConfig_taskReportConfig_Destination_taskReportConfig_Destination_S3_s3_BucketAccessRoleArn;
                requestTaskReportConfig_taskReportConfig_Destination_taskReportConfig_Destination_S3IsNull = false;
            }
            System.String requestTaskReportConfig_taskReportConfig_Destination_taskReportConfig_Destination_S3_s3_S3BucketArn = null;
            if (cmdletContext.S3_S3BucketArn != null)
            {
                requestTaskReportConfig_taskReportConfig_Destination_taskReportConfig_Destination_S3_s3_S3BucketArn = cmdletContext.S3_S3BucketArn;
            }
            if (requestTaskReportConfig_taskReportConfig_Destination_taskReportConfig_Destination_S3_s3_S3BucketArn != null)
            {
                requestTaskReportConfig_taskReportConfig_Destination_taskReportConfig_Destination_S3.S3BucketArn = requestTaskReportConfig_taskReportConfig_Destination_taskReportConfig_Destination_S3_s3_S3BucketArn;
                requestTaskReportConfig_taskReportConfig_Destination_taskReportConfig_Destination_S3IsNull = false;
            }
            System.String requestTaskReportConfig_taskReportConfig_Destination_taskReportConfig_Destination_S3_s3_Subdirectory = null;
            if (cmdletContext.S3_Subdirectory != null)
            {
                requestTaskReportConfig_taskReportConfig_Destination_taskReportConfig_Destination_S3_s3_Subdirectory = cmdletContext.S3_Subdirectory;
            }
            if (requestTaskReportConfig_taskReportConfig_Destination_taskReportConfig_Destination_S3_s3_Subdirectory != null)
            {
                requestTaskReportConfig_taskReportConfig_Destination_taskReportConfig_Destination_S3.Subdirectory = requestTaskReportConfig_taskReportConfig_Destination_taskReportConfig_Destination_S3_s3_Subdirectory;
                requestTaskReportConfig_taskReportConfig_Destination_taskReportConfig_Destination_S3IsNull = false;
            }
             // determine if requestTaskReportConfig_taskReportConfig_Destination_taskReportConfig_Destination_S3 should be set to null
            if (requestTaskReportConfig_taskReportConfig_Destination_taskReportConfig_Destination_S3IsNull)
            {
                requestTaskReportConfig_taskReportConfig_Destination_taskReportConfig_Destination_S3 = null;
            }
            if (requestTaskReportConfig_taskReportConfig_Destination_taskReportConfig_Destination_S3 != null)
            {
                requestTaskReportConfig_taskReportConfig_Destination.S3 = requestTaskReportConfig_taskReportConfig_Destination_taskReportConfig_Destination_S3;
                requestTaskReportConfig_taskReportConfig_DestinationIsNull = false;
            }
             // determine if requestTaskReportConfig_taskReportConfig_Destination should be set to null
            if (requestTaskReportConfig_taskReportConfig_DestinationIsNull)
            {
                requestTaskReportConfig_taskReportConfig_Destination = null;
            }
            if (requestTaskReportConfig_taskReportConfig_Destination != null)
            {
                request.TaskReportConfig.Destination = requestTaskReportConfig_taskReportConfig_Destination;
                requestTaskReportConfigIsNull = false;
            }
            Amazon.DataSync.Model.ReportOverrides requestTaskReportConfig_taskReportConfig_Overrides = null;
            
             // populate Overrides
            var requestTaskReportConfig_taskReportConfig_OverridesIsNull = true;
            requestTaskReportConfig_taskReportConfig_Overrides = new Amazon.DataSync.Model.ReportOverrides();
            Amazon.DataSync.Model.ReportOverride requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Deleted = null;
            
             // populate Deleted
            var requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_DeletedIsNull = true;
            requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Deleted = new Amazon.DataSync.Model.ReportOverride();
            Amazon.DataSync.ReportLevel requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Deleted_deleted_ReportLevel = null;
            if (cmdletContext.Deleted_ReportLevel != null)
            {
                requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Deleted_deleted_ReportLevel = cmdletContext.Deleted_ReportLevel;
            }
            if (requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Deleted_deleted_ReportLevel != null)
            {
                requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Deleted.ReportLevel = requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Deleted_deleted_ReportLevel;
                requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_DeletedIsNull = false;
            }
             // determine if requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Deleted should be set to null
            if (requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_DeletedIsNull)
            {
                requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Deleted = null;
            }
            if (requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Deleted != null)
            {
                requestTaskReportConfig_taskReportConfig_Overrides.Deleted = requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Deleted;
                requestTaskReportConfig_taskReportConfig_OverridesIsNull = false;
            }
            Amazon.DataSync.Model.ReportOverride requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Skipped = null;
            
             // populate Skipped
            var requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_SkippedIsNull = true;
            requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Skipped = new Amazon.DataSync.Model.ReportOverride();
            Amazon.DataSync.ReportLevel requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Skipped_skipped_ReportLevel = null;
            if (cmdletContext.Skipped_ReportLevel != null)
            {
                requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Skipped_skipped_ReportLevel = cmdletContext.Skipped_ReportLevel;
            }
            if (requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Skipped_skipped_ReportLevel != null)
            {
                requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Skipped.ReportLevel = requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Skipped_skipped_ReportLevel;
                requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_SkippedIsNull = false;
            }
             // determine if requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Skipped should be set to null
            if (requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_SkippedIsNull)
            {
                requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Skipped = null;
            }
            if (requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Skipped != null)
            {
                requestTaskReportConfig_taskReportConfig_Overrides.Skipped = requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Skipped;
                requestTaskReportConfig_taskReportConfig_OverridesIsNull = false;
            }
            Amazon.DataSync.Model.ReportOverride requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Transferred = null;
            
             // populate Transferred
            var requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_TransferredIsNull = true;
            requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Transferred = new Amazon.DataSync.Model.ReportOverride();
            Amazon.DataSync.ReportLevel requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Transferred_transferred_ReportLevel = null;
            if (cmdletContext.Transferred_ReportLevel != null)
            {
                requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Transferred_transferred_ReportLevel = cmdletContext.Transferred_ReportLevel;
            }
            if (requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Transferred_transferred_ReportLevel != null)
            {
                requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Transferred.ReportLevel = requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Transferred_transferred_ReportLevel;
                requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_TransferredIsNull = false;
            }
             // determine if requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Transferred should be set to null
            if (requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_TransferredIsNull)
            {
                requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Transferred = null;
            }
            if (requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Transferred != null)
            {
                requestTaskReportConfig_taskReportConfig_Overrides.Transferred = requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Transferred;
                requestTaskReportConfig_taskReportConfig_OverridesIsNull = false;
            }
            Amazon.DataSync.Model.ReportOverride requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Verified = null;
            
             // populate Verified
            var requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_VerifiedIsNull = true;
            requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Verified = new Amazon.DataSync.Model.ReportOverride();
            Amazon.DataSync.ReportLevel requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Verified_verified_ReportLevel = null;
            if (cmdletContext.Verified_ReportLevel != null)
            {
                requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Verified_verified_ReportLevel = cmdletContext.Verified_ReportLevel;
            }
            if (requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Verified_verified_ReportLevel != null)
            {
                requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Verified.ReportLevel = requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Verified_verified_ReportLevel;
                requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_VerifiedIsNull = false;
            }
             // determine if requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Verified should be set to null
            if (requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_VerifiedIsNull)
            {
                requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Verified = null;
            }
            if (requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Verified != null)
            {
                requestTaskReportConfig_taskReportConfig_Overrides.Verified = requestTaskReportConfig_taskReportConfig_Overrides_taskReportConfig_Overrides_Verified;
                requestTaskReportConfig_taskReportConfig_OverridesIsNull = false;
            }
             // determine if requestTaskReportConfig_taskReportConfig_Overrides should be set to null
            if (requestTaskReportConfig_taskReportConfig_OverridesIsNull)
            {
                requestTaskReportConfig_taskReportConfig_Overrides = null;
            }
            if (requestTaskReportConfig_taskReportConfig_Overrides != null)
            {
                request.TaskReportConfig.Overrides = requestTaskReportConfig_taskReportConfig_Overrides;
                requestTaskReportConfigIsNull = false;
            }
             // determine if request.TaskReportConfig should be set to null
            if (requestTaskReportConfigIsNull)
            {
                request.TaskReportConfig = null;
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
        
        private Amazon.DataSync.Model.UpdateTaskResponse CallAWSServiceOperation(IAmazonDataSync client, Amazon.DataSync.Model.UpdateTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS DataSync", "UpdateTask");
            try
            {
                #if DESKTOP
                return client.UpdateTask(request);
                #elif CORECLR
                return client.UpdateTaskAsync(request).GetAwaiter().GetResult();
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
            public System.String CloudWatchLogGroupArn { get; set; }
            public List<Amazon.DataSync.Model.FilterRule> Exclude { get; set; }
            public List<Amazon.DataSync.Model.FilterRule> Include { get; set; }
            public System.String Name { get; set; }
            public Amazon.DataSync.Model.Options Option { get; set; }
            public System.String Schedule_ScheduleExpression { get; set; }
            public System.String TaskArn { get; set; }
            public System.String S3_BucketAccessRoleArn { get; set; }
            public System.String S3_S3BucketArn { get; set; }
            public System.String S3_Subdirectory { get; set; }
            public Amazon.DataSync.ObjectVersionIds TaskReportConfig_ObjectVersionId { get; set; }
            public Amazon.DataSync.ReportOutputType TaskReportConfig_OutputType { get; set; }
            public Amazon.DataSync.ReportLevel Deleted_ReportLevel { get; set; }
            public Amazon.DataSync.ReportLevel Skipped_ReportLevel { get; set; }
            public Amazon.DataSync.ReportLevel Transferred_ReportLevel { get; set; }
            public Amazon.DataSync.ReportLevel Verified_ReportLevel { get; set; }
            public Amazon.DataSync.ReportLevel TaskReportConfig_ReportLevel { get; set; }
            public System.Func<Amazon.DataSync.Model.UpdateTaskResponse, UpdateDSYNTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
