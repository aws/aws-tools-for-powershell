/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;

namespace Amazon.PowerShell.Cmdlets.CWL
{
    /// <summary>
    /// Creates an <code>ExportTask</code> which allows you to efficiently export data from
    /// a Log Group to your Amazon S3 bucket.
    /// 
    ///  
    /// <para>
    /// This is an asynchronous call. If all the required information is provided, this API
    /// will initiate an export task and respond with the task Id. Once started, <code>DescribeExportTasks</code>
    /// can be used to get the status of an export task. You can only have one active (<code>RUNNING</code>
    /// or <code>PENDING</code>) export task at a time, per account.
    /// </para><para>
    /// You can export logs from multiple log groups or multiple time ranges to the same Amazon
    /// S3 bucket. To separate out log data for each export task, you can specify a prefix
    /// that will be used as the Amazon S3 key prefix for all exported objects.
    /// </para>
    /// </summary>
    [Cmdlet("New", "CWLExportTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the CreateExportTask operation against Amazon CloudWatch Logs.", Operation = new[] {"CreateExportTask"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.CloudWatchLogs.Model.CreateExportTaskResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewCWLExportTaskCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        #region Parameter Destination
        /// <summary>
        /// <para>
        /// <para>Name of Amazon S3 bucket to which the log data will be exported.</para><para><b>Note:</b> Only buckets in the same AWS region are supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Destination { get; set; }
        #endregion
        
        #region Parameter DestinationPrefix
        /// <summary>
        /// <para>
        /// <para>Prefix that will be used as the start of Amazon S3 key for every object exported.
        /// If not specified, this defaults to 'exportedlogs'.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DestinationPrefix { get; set; }
        #endregion
        
        #region Parameter From
        /// <summary>
        /// <para>
        /// <para>A point in time expressed as the number of milliseconds since Jan 1, 1970 00:00:00
        /// UTC. It indicates the start time of the range for the request. Events with a timestamp
        /// prior to this time will not be exported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 From { get; set; }
        #endregion
        
        #region Parameter LogGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the log group to export.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String LogGroupName { get; set; }
        #endregion
        
        #region Parameter LogStreamNamePrefix
        /// <summary>
        /// <para>
        /// <para>Will only export log streams that match the provided logStreamNamePrefix. If you don't
        /// specify a value, no prefix filter is applied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LogStreamNamePrefix { get; set; }
        #endregion
        
        #region Parameter TaskName
        /// <summary>
        /// <para>
        /// <para>The name of the export task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TaskName { get; set; }
        #endregion
        
        #region Parameter To
        /// <summary>
        /// <para>
        /// <para>A point in time expressed as the number of milliseconds since Jan 1, 1970 00:00:00
        /// UTC. It indicates the end time of the range for the request. Events with a timestamp
        /// later than this time will not be exported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 To { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("LogGroupName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CWLExportTask (CreateExportTask)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Destination = this.Destination;
            context.DestinationPrefix = this.DestinationPrefix;
            if (ParameterWasBound("From"))
                context.From = this.From;
            context.LogGroupName = this.LogGroupName;
            context.LogStreamNamePrefix = this.LogStreamNamePrefix;
            context.TaskName = this.TaskName;
            if (ParameterWasBound("To"))
                context.To = this.To;
            
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.TaskId;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private static Amazon.CloudWatchLogs.Model.CreateExportTaskResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.CreateExportTaskRequest request)
        {
            return client.CreateExportTask(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String Destination { get; set; }
            public System.String DestinationPrefix { get; set; }
            public System.Int64? From { get; set; }
            public System.String LogGroupName { get; set; }
            public System.String LogStreamNamePrefix { get; set; }
            public System.String TaskName { get; set; }
            public System.Int64? To { get; set; }
        }
        
    }
}
