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
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CWL
{
    /// <summary>
    /// Creates an export task so that you can efficiently export data from a log group to
    /// an Amazon S3 bucket. When you perform a <c>CreateExportTask</c> operation, you must
    /// use credentials that have permission to write to the S3 bucket that you specify as
    /// the destination.
    /// 
    ///  
    /// <para>
    /// Exporting log data to S3 buckets that are encrypted by KMS is supported. Exporting
    /// log data to Amazon S3 buckets that have S3 Object Lock enabled with a retention period
    /// is also supported.
    /// </para><para>
    /// Exporting to S3 buckets that are encrypted with AES-256 is supported. 
    /// </para><para>
    /// This is an asynchronous call. If all the required information is provided, this operation
    /// initiates an export task and responds with the ID of the task. After the task has
    /// started, you can use <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_DescribeExportTasks.html">DescribeExportTasks</a>
    /// to get the status of the export task. Each account can only have one active (<c>RUNNING</c>
    /// or <c>PENDING</c>) export task at a time. To cancel an export task, use <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_CancelExportTask.html">CancelExportTask</a>.
    /// </para><para>
    /// You can export logs from multiple log groups or multiple time ranges to the same S3
    /// bucket. To separate log data for each export task, specify a prefix to be used as
    /// the Amazon S3 key prefix for all exported objects.
    /// </para><note><para>
    /// We recommend that you don't regularly export to Amazon S3 as a way to continuously
    /// archive your logs. For that use case, we instaed recommend that you use subscriptions.
    /// For more information about subscriptions, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/Subscriptions.html">Real-time
    /// processing of log data with subscriptions</a>.
    /// </para></note><note><para>
    /// Time-based sorting on chunks of log data inside an exported file is not guaranteed.
    /// You can sort the exported log field data by using Linux utilities.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "CWLExportTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs CreateExportTask API operation.", Operation = new[] {"CreateExportTask"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.CreateExportTaskResponse))]
    [AWSCmdletOutput("System.String or Amazon.CloudWatchLogs.Model.CreateExportTaskResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CloudWatchLogs.Model.CreateExportTaskResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCWLExportTaskCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Destination
        /// <summary>
        /// <para>
        /// <para>The name of S3 bucket for the exported log data. The bucket must be in the same Amazon
        /// Web Services Region.</para>
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
        public System.String Destination { get; set; }
        #endregion
        
        #region Parameter DestinationPrefix
        /// <summary>
        /// <para>
        /// <para>The prefix used as the start of the key for every object exported. If you don't specify
        /// a value, the default is <c>exportedlogs</c>.</para><para>The length of this parameter must comply with the S3 object key name length limits.
        /// The object key name is a sequence of Unicode characters with UTF-8 encoding, and can
        /// be up to 1,024 bytes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationPrefix { get; set; }
        #endregion
        
        #region Parameter From
        /// <summary>
        /// <para>
        /// <para>The start time of the range for the request, expressed as the number of milliseconds
        /// after <c>Jan 1, 1970 00:00:00 UTC</c>. Events with a timestamp earlier than this time
        /// are not exported.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int64? From { get; set; }
        #endregion
        
        #region Parameter LogGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the log group.</para>
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
        public System.String LogGroupName { get; set; }
        #endregion
        
        #region Parameter LogStreamNamePrefix
        /// <summary>
        /// <para>
        /// <para>Export only log streams that match the provided prefix. If you don't specify a value,
        /// no prefix filter is applied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LogStreamNamePrefix { get; set; }
        #endregion
        
        #region Parameter TaskName
        /// <summary>
        /// <para>
        /// <para>The name of the export task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TaskName { get; set; }
        #endregion
        
        #region Parameter To
        /// <summary>
        /// <para>
        /// <para>The end time of the range for the request, expressed as the number of milliseconds
        /// after <c>Jan 1, 1970 00:00:00 UTC</c>. Events with a timestamp later than this time
        /// are not exported.</para><para>You must specify a time that is not earlier than when this log group was created.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int64? To { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TaskId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.CreateExportTaskResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchLogs.Model.CreateExportTaskResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TaskId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LogGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CWLExportTask (CreateExportTask)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.CreateExportTaskResponse, NewCWLExportTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Destination = this.Destination;
            #if MODULAR
            if (this.Destination == null && ParameterWasBound(nameof(this.Destination)))
            {
                WriteWarning("You are passing $null as a value for parameter Destination which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DestinationPrefix = this.DestinationPrefix;
            context.From = this.From;
            #if MODULAR
            if (this.From == null && ParameterWasBound(nameof(this.From)))
            {
                WriteWarning("You are passing $null as a value for parameter From which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LogGroupName = this.LogGroupName;
            #if MODULAR
            if (this.LogGroupName == null && ParameterWasBound(nameof(this.LogGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter LogGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LogStreamNamePrefix = this.LogStreamNamePrefix;
            context.TaskName = this.TaskName;
            context.To = this.To;
            #if MODULAR
            if (this.To == null && ParameterWasBound(nameof(this.To)))
            {
                WriteWarning("You are passing $null as a value for parameter To which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudWatchLogs.Model.CreateExportTaskRequest();
            
            if (cmdletContext.Destination != null)
            {
                request.Destination = cmdletContext.Destination;
            }
            if (cmdletContext.DestinationPrefix != null)
            {
                request.DestinationPrefix = cmdletContext.DestinationPrefix;
            }
            if (cmdletContext.From != null)
            {
                request.From = cmdletContext.From.Value;
            }
            if (cmdletContext.LogGroupName != null)
            {
                request.LogGroupName = cmdletContext.LogGroupName;
            }
            if (cmdletContext.LogStreamNamePrefix != null)
            {
                request.LogStreamNamePrefix = cmdletContext.LogStreamNamePrefix;
            }
            if (cmdletContext.TaskName != null)
            {
                request.TaskName = cmdletContext.TaskName;
            }
            if (cmdletContext.To != null)
            {
                request.To = cmdletContext.To.Value;
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
        
        private Amazon.CloudWatchLogs.Model.CreateExportTaskResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.CreateExportTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "CreateExportTask");
            try
            {
                return client.CreateExportTaskAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Destination { get; set; }
            public System.String DestinationPrefix { get; set; }
            public System.Int64? From { get; set; }
            public System.String LogGroupName { get; set; }
            public System.String LogStreamNamePrefix { get; set; }
            public System.String TaskName { get; set; }
            public System.Int64? To { get; set; }
            public System.Func<Amazon.CloudWatchLogs.Model.CreateExportTaskResponse, NewCWLExportTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TaskId;
        }
        
    }
}
