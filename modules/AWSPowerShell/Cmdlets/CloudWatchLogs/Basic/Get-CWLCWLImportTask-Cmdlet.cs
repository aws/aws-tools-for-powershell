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
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;

namespace Amazon.PowerShell.Cmdlets.CWL
{
    /// <summary>
    /// Lists and describes import tasks, with optional filtering by import status and source
    /// ARN.
    /// </summary>
    [Cmdlet("Get", "CWLCWLImportTask")]
    [OutputType("Amazon.CloudWatchLogs.Model.Import")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs DescribeImportTasks API operation.", Operation = new[] {"DescribeImportTasks"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.DescribeImportTasksResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchLogs.Model.Import or Amazon.CloudWatchLogs.Model.DescribeImportTasksResponse",
        "This cmdlet returns a collection of Amazon.CloudWatchLogs.Model.Import objects.",
        "The service call response (type Amazon.CloudWatchLogs.Model.DescribeImportTasksResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCWLCWLImportTaskCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ImportId
        /// <summary>
        /// <para>
        /// <para>Optional filter to describe a specific import task by its ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ImportId { get; set; }
        #endregion
        
        #region Parameter ImportSourceArn
        /// <summary>
        /// <para>
        /// <para>Optional filter to list imports from a specific source</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ImportSourceArn { get; set; }
        #endregion
        
        #region Parameter ImportStatus
        /// <summary>
        /// <para>
        /// <para>Optional filter to list imports by their status. Valid values are IN_PROGRESS, CANCELLED,
        /// COMPLETED and FAILED.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudWatchLogs.ImportStatus")]
        public Amazon.CloudWatchLogs.ImportStatus ImportStatus { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of import tasks to return in the response. Default: 50</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Limit { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token for the next set of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Imports'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.DescribeImportTasksResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchLogs.Model.DescribeImportTasksResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Imports";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.DescribeImportTasksResponse, GetCWLCWLImportTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ImportId = this.ImportId;
            context.ImportSourceArn = this.ImportSourceArn;
            context.ImportStatus = this.ImportStatus;
            context.Limit = this.Limit;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.CloudWatchLogs.Model.DescribeImportTasksRequest();
            
            if (cmdletContext.ImportId != null)
            {
                request.ImportId = cmdletContext.ImportId;
            }
            if (cmdletContext.ImportSourceArn != null)
            {
                request.ImportSourceArn = cmdletContext.ImportSourceArn;
            }
            if (cmdletContext.ImportStatus != null)
            {
                request.ImportStatus = cmdletContext.ImportStatus;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.CloudWatchLogs.Model.DescribeImportTasksResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.DescribeImportTasksRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "DescribeImportTasks");
            try
            {
                #if DESKTOP
                return client.DescribeImportTasks(request);
                #elif CORECLR
                return client.DescribeImportTasksAsync(request).GetAwaiter().GetResult();
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
            public System.String ImportId { get; set; }
            public System.String ImportSourceArn { get; set; }
            public Amazon.CloudWatchLogs.ImportStatus ImportStatus { get; set; }
            public System.Int32? Limit { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.CloudWatchLogs.Model.DescribeImportTasksResponse, GetCWLCWLImportTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Imports;
        }
        
    }
}
