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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BAT
{
    /// <summary>
    /// Returns a list of Batch jobs.
    /// 
    ///  
    /// <para>
    /// You must specify only one of the following items:
    /// </para><ul><li><para>
    /// A job queue ID to return a list of jobs in that job queue
    /// </para></li><li><para>
    /// A multi-node parallel job ID to return a list of nodes for that job
    /// </para></li><li><para>
    /// An array job ID to return a list of the children for that job
    /// </para></li></ul><para>
    /// You can filter the results by job status with the <c>jobStatus</c> parameter. If you
    /// don't specify a status, only <c>RUNNING</c> jobs are returned.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "BATJobList")]
    [OutputType("Amazon.Batch.Model.JobSummary")]
    [AWSCmdlet("Calls the AWS Batch ListJobs API operation.", Operation = new[] {"ListJobs"}, SelectReturnType = typeof(Amazon.Batch.Model.ListJobsResponse))]
    [AWSCmdletOutput("Amazon.Batch.Model.JobSummary or Amazon.Batch.Model.ListJobsResponse",
        "This cmdlet returns a collection of Amazon.Batch.Model.JobSummary objects.",
        "The service call response (type Amazon.Batch.Model.ListJobsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetBATJobListCmdlet : AmazonBatchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ArrayJobId
        /// <summary>
        /// <para>
        /// <para>The job ID for an array job. Specifying an array job ID with this parameter lists
        /// all child jobs from within the specified array.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ArrayJobId { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>The filter to apply to the query. Only one filter can be used at a time. When the
        /// filter is used, <c>jobStatus</c> is ignored. The filter doesn't apply to child jobs
        /// in an array or multi-node parallel (MNP) jobs. The results are sorted by the <c>createdAt</c>
        /// field, with the most recent jobs being first.</para><dl><dt>JOB_NAME</dt><dd><para>The value of the filter is a case-insensitive match for the job name. If the value
        /// ends with an asterisk (*), the filter matches any job name that begins with the string
        /// before the '*'. This corresponds to the <c>jobName</c> value. For example, <c>test1</c>
        /// matches both <c>Test1</c> and <c>test1</c>, and <c>test1*</c> matches both <c>test1</c>
        /// and <c>Test10</c>. When the <c>JOB_NAME</c> filter is used, the results are grouped
        /// by the job name and version.</para></dd><dt>JOB_DEFINITION</dt><dd><para>The value for the filter is the name or Amazon Resource Name (ARN) of the job definition.
        /// This corresponds to the <c>jobDefinition</c> value. The value is case sensitive. When
        /// the value for the filter is the job definition name, the results include all the jobs
        /// that used any revision of that job definition name. If the value ends with an asterisk
        /// (*), the filter matches any job definition name that begins with the string before
        /// the '*'. For example, <c>jd1</c> matches only <c>jd1</c>, and <c>jd1*</c> matches
        /// both <c>jd1</c> and <c>jd1A</c>. The version of the job definition that's used doesn't
        /// affect the sort order. When the <c>JOB_DEFINITION</c> filter is used and the ARN is
        /// used (which is in the form <c>arn:${Partition}:batch:${Region}:${Account}:job-definition/${JobDefinitionName}:${Revision}</c>),
        /// the results include jobs that used the specified revision of the job definition. Asterisk
        /// (*) isn't supported when the ARN is used.</para></dd><dt>BEFORE_CREATED_AT</dt><dd><para>The value for the filter is the time that's before the job was created. This corresponds
        /// to the <c>createdAt</c> value. The value is a string representation of the number
        /// of milliseconds since 00:00:00 UTC (midnight) on January 1, 1970.</para></dd><dt>AFTER_CREATED_AT</dt><dd><para>The value for the filter is the time that's after the job was created. This corresponds
        /// to the <c>createdAt</c> value. The value is a string representation of the number
        /// of milliseconds since 00:00:00 UTC (midnight) on January 1, 1970.</para></dd></dl>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.Batch.Model.KeyValuesPair[] Filter { get; set; }
        #endregion
        
        #region Parameter JobQueue
        /// <summary>
        /// <para>
        /// <para>The name or full Amazon Resource Name (ARN) of the job queue used to list jobs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String JobQueue { get; set; }
        #endregion
        
        #region Parameter JobStatus
        /// <summary>
        /// <para>
        /// <para>The job status used to filter jobs in the specified queue. If the <c>filters</c> parameter
        /// is specified, the <c>jobStatus</c> parameter is ignored and jobs with any status are
        /// returned. If you don't specify a status, only <c>RUNNING</c> jobs are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MultiNodeJobId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results returned by <c>ListJobs</c> in a paginated output. When
        /// this parameter is used, <c>ListJobs</c> returns up to <c>maxResults</c> results in
        /// a single page and a <c>nextToken</c> response element, if applicable. The remaining
        /// results of the initial request can be seen by sending another <c>ListJobs</c> request
        /// with the returned <c>nextToken</c> value.</para><para>The following outlines key parameters and limitations:</para><ul><li><para>The minimum value is 1. </para></li><li><para>When <c>--job-status</c> is used, Batch returns up to 1000 values. </para></li><li><para>When <c>--filters</c> is used, Batch returns up to 100 values.</para></li><li><para>If neither parameter is used, then <c>ListJobs</c> returns up to 1000 results (jobs
        /// that are in the <c>RUNNING</c> status) and a <c>nextToken</c> value, if applicable.</para></li></ul>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The <c>nextToken</c> value returned from a previous paginated <c>ListJobs</c> request
        /// where <c>maxResults</c> was used and the results exceeded the value of that parameter.
        /// Pagination continues from the end of the previous results that returned the <c>nextToken</c>
        /// value. This value is <c>null</c> when there are no more results to return.</para><note><para>Treat this token as an opaque identifier that's only used to retrieve the next items
        /// in a list and not for other programmatic purposes.</para></note>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobSummaryList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Batch.Model.ListJobsResponse).
        /// Specifying the name of a property of type Amazon.Batch.Model.ListJobsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobSummaryList";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Batch.Model.ListJobsResponse, GetBATJobListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ArrayJobId = this.ArrayJobId;
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.Batch.Model.KeyValuesPair>(this.Filter);
            }
            context.JobQueue = this.JobQueue;
            context.JobStatus = this.JobStatus;
            context.MaxResult = this.MaxResult;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.MultiNodeJobId = this.MultiNodeJobId;
            context.NextToken = this.NextToken;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.Batch.Model.ListJobsRequest();
            
            if (cmdletContext.ArrayJobId != null)
            {
                request.ArrayJobId = cmdletContext.ArrayJobId;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.JobQueue != null)
            {
                request.JobQueue = cmdletContext.JobQueue;
            }
            if (cmdletContext.JobStatus != null)
            {
                request.JobStatus = cmdletContext.JobStatus;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.MultiNodeJobId != null)
            {
                request.MultiNodeJobId = cmdletContext.MultiNodeJobId;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.Batch.Model.ListJobsRequest();
            if (cmdletContext.ArrayJobId != null)
            {
                request.ArrayJobId = cmdletContext.ArrayJobId;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
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
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.MaxResult.HasValue)
            {
                _emitLimit = cmdletContext.MaxResult;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                }
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    int _receivedThisCall = response.JobSummaryList?.Count ?? 0;
                    
                    _nextToken = response.NextToken;
                    _retrievedSoFar += _receivedThisCall;
                    if (_emitLimit.HasValue)
                    {
                        _emitLimit -= _receivedThisCall;
                    }
                }
                catch (Exception e)
                {
                    if (_retrievedSoFar == 0 || !_emitLimit.HasValue)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    else
                    {
                        break;
                    }
                }
                
                ProcessOutput(output);
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
            
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #endif
        
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
                return client.ListJobsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Batch.Model.KeyValuesPair> Filter { get; set; }
            public System.String JobQueue { get; set; }
            public Amazon.Batch.JobStatus JobStatus { get; set; }
            public int? MaxResult { get; set; }
            public System.String MultiNodeJobId { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Batch.Model.ListJobsResponse, GetBATJobListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobSummaryList;
        }
        
    }
}
