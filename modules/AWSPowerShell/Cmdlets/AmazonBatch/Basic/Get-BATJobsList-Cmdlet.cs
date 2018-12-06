/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Returns a list of AWS Batch jobs.
    /// 
    ///  
    /// <para>
    /// You must specify only one of the following:
    /// </para><ul><li><para>
    /// a job queue ID to return a list of jobs in that job queue
    /// </para></li><li><para>
    /// a multi-node parallel job ID to return a list of that job's nodes
    /// </para></li><li><para>
    /// an array job ID to return a list of that job's children
    /// </para></li></ul><para>
    /// You can filter the results by job status with the <code>jobStatus</code> parameter.
    /// If you do not specify a status, only <code>RUNNING</code> jobs are returned.
    /// </para><br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "BATJobsList")]
    [OutputType("Amazon.Batch.Model.JobSummary")]
    [AWSCmdlet("Calls the AWS Batch ListJobs API operation.", Operation = new[] {"ListJobs"})]
    [AWSCmdletOutput("Amazon.Batch.Model.JobSummary",
        "This cmdlet returns a collection of JobSummary objects.",
        "The service call response (type Amazon.Batch.Model.ListJobsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetBATJobsListCmdlet : AmazonBatchClientCmdlet, IExecutor
    {
        
        #region Parameter ArrayJobId
        /// <summary>
        /// <para>
        /// <para>The job ID for an array job. Specifying an array job ID with this parameter lists
        /// all child jobs from within the specified array.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ArrayJobId { get; set; }
        #endregion
        
        #region Parameter JobQueue
        /// <summary>
        /// <para>
        /// <para>The name or full Amazon Resource Name (ARN) of the job queue with which to list jobs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String JobQueue { get; set; }
        #endregion
        
        #region Parameter JobStatus
        /// <summary>
        /// <para>
        /// <para>The job status with which to filter jobs in the specified queue. If you do not specify
        /// a status, only <code>RUNNING</code> jobs are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Batch.JobStatus")]
        public Amazon.Batch.JobStatus JobStatus { get; set; }
        #endregion
        
        #region Parameter MultiNodeJobId
        /// <summary>
        /// <para>
        /// <para>The job ID for a multi-node parallel job. Specifying a multi-node parallel job ID
        /// with this parameter lists all nodes that are associated with the specified job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MultiNodeJobId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results returned by <code>ListJobs</code> in paginated output.
        /// When this parameter is used, <code>ListJobs</code> only returns <code>maxResults</code>
        /// results in a single page along with a <code>nextToken</code> response element. The
        /// remaining results of the initial request can be seen by sending another <code>ListJobs</code>
        /// request with the returned <code>nextToken</code> value. This value can be between
        /// 1 and 100. If this parameter is not used, then <code>ListJobs</code> returns up to
        /// 100 results and a <code>nextToken</code> value if applicable.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public int MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The <code>nextToken</code> value returned from a previous paginated <code>ListJobs</code>
        /// request where <code>maxResults</code> was used and the results exceeded the value
        /// of that parameter. Pagination continues from the end of the previous results that
        /// returned the <code>nextToken</code> value. This value is <code>null</code> when there
        /// are no more results to return.</para><note><para>This token should be treated as an opaque identifier that is only used to retrieve
        /// the next items in a list and not for other programmatic purposes.</para></note>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ArrayJobId = this.ArrayJobId;
            context.JobQueue = this.JobQueue;
            context.JobStatus = this.JobStatus;
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.MultiNodeJobId = this.MultiNodeJobId;
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
            
            // create request and set iteration invariants
            var request = new Amazon.Batch.Model.ListJobsRequest();
            if (cmdletContext.ArrayJobId != null)
            {
                request.ArrayJobId = cmdletContext.ArrayJobId;
            }
            if (cmdletContext.JobQueue != null)
            {
                request.JobQueue = cmdletContext.JobQueue;
            }
            if (cmdletContext.JobStatus != null)
            {
                request.JobStatus = cmdletContext.JobStatus;
            }
            if (cmdletContext.MultiNodeJobId != null)
            {
                request.MultiNodeJobId = cmdletContext.MultiNodeJobId;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextMarker = cmdletContext.NextToken;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxResults))
            {
                _emitLimit = cmdletContext.MaxResults;
            }
            bool _userControllingPaging = AutoIterationHelpers.HasValue(cmdletContext.NextToken) || AutoIterationHelpers.HasValue(cmdletContext.MaxResults);
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.JobSummaryList;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.JobSummaryList.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.NextToken));
                        }
                        
                        _nextMarker = response.NextToken;
                        
                        _retrievedSoFar += _receivedThisCall;
                        if (AutoIterationHelpers.HasValue(_emitLimit) && (_retrievedSoFar == 0 || _retrievedSoFar >= _emitLimit.Value))
                        {
                            _continueIteration = false;
                        }
                    }
                    catch (Exception e)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    
                    ProcessOutput(output);
                } while (_continueIteration && AutoIterationHelpers.HasValue(_nextMarker));
                
            }
            finally
            {
                if (_userControllingPaging)
                {
                    WriteProgressCompleteRecord("Retrieving", "Retrieved records");
                }
            }
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Batch.Model.ListJobsResponse CallAWSServiceOperation(IAmazonBatch client, Amazon.Batch.Model.ListJobsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Batch", "ListJobs");
            try
            {
                #if DESKTOP
                return client.ListJobs(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ListJobsAsync(request);
                return task.Result;
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
            public System.String ArrayJobId { get; set; }
            public System.String JobQueue { get; set; }
            public Amazon.Batch.JobStatus JobStatus { get; set; }
            public int? MaxResults { get; set; }
            public System.String MultiNodeJobId { get; set; }
            public System.String NextToken { get; set; }
        }
        
    }
}
