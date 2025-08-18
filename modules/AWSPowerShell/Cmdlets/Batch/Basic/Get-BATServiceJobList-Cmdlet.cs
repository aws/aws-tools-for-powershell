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
using Amazon.Batch;
using Amazon.Batch.Model;

namespace Amazon.PowerShell.Cmdlets.BAT
{
    /// <summary>
    /// Returns a list of service jobs for a specified job queue.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "BATServiceJobList")]
    [OutputType("Amazon.Batch.Model.ServiceJobSummary")]
    [AWSCmdlet("Calls the AWS Batch ListServiceJobs API operation.", Operation = new[] {"ListServiceJobs"}, SelectReturnType = typeof(Amazon.Batch.Model.ListServiceJobsResponse))]
    [AWSCmdletOutput("Amazon.Batch.Model.ServiceJobSummary or Amazon.Batch.Model.ListServiceJobsResponse",
        "This cmdlet returns a collection of Amazon.Batch.Model.ServiceJobSummary objects.",
        "The service call response (type Amazon.Batch.Model.ListServiceJobsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetBATServiceJobListCmdlet : AmazonBatchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>The filter to apply to the query. Only one filter can be used at a time. When the
        /// filter is used, <c>jobStatus</c> is ignored. The results are sorted by the <c>createdAt</c>
        /// field, with the most recent jobs being first.</para><dl><dt>JOB_NAME</dt><dd><para>The value of the filter is a case-insensitive match for the job name. If the value
        /// ends with an asterisk (*), the filter matches any job name that begins with the string
        /// before the '*'. This corresponds to the <c>jobName</c> value. For example, <c>test1</c>
        /// matches both <c>Test1</c> and <c>test1</c>, and <c>test1*</c> matches both <c>test1</c>
        /// and <c>Test10</c>. When the <c>JOB_NAME</c> filter is used, the results are grouped
        /// by the job name and version.</para></dd><dt>BEFORE_CREATED_AT</dt><dd><para>The value for the filter is the time that's before the job was created. This corresponds
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
        /// <para>The name or ARN of the job queue with which to list service jobs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String JobQueue { get; set; }
        #endregion
        
        #region Parameter JobStatus
        /// <summary>
        /// <para>
        /// <para>The job status with which to filter service jobs. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Batch.ServiceJobStatus")]
        public Amazon.Batch.ServiceJobStatus JobStatus { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results returned by <c>ListServiceJobs</c> in paginated output.
        /// When this parameter is used, <c>ListServiceJobs</c> only returns <c>maxResults</c>
        /// results in a single page and a <c>nextToken</c> response element. The remaining results
        /// of the initial request can be seen by sending another <c>ListServiceJobs</c> request
        /// with the returned <c>nextToken</c> value. This value can be between 1 and 100. If
        /// this parameter isn't used, then <c>ListServiceJobs</c> returns up to 100 results and
        /// a <c>nextToken</c> value if applicable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The <c>nextToken</c> value returned from a previous paginated <c>ListServiceJobs</c>
        /// request where <c>maxResults</c> was used and the results exceeded the value of that
        /// parameter. Pagination continues from the end of the previous results that returned
        /// the <c>nextToken</c> value. This value is <c>null</c> when there are no more results
        /// to return.</para><note><para>Treat this token as an opaque identifier that's only used to retrieve the next items
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Batch.Model.ListServiceJobsResponse).
        /// Specifying the name of a property of type Amazon.Batch.Model.ListServiceJobsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobSummaryList";
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
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Batch.Model.ListServiceJobsResponse, GetBATServiceJobListCmdlet>(Select) ??
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
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.Batch.Model.KeyValuesPair>(this.Filter);
            }
            context.JobQueue = this.JobQueue;
            context.JobStatus = this.JobStatus;
            context.MaxResult = this.MaxResult;
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.Batch.Model.ListServiceJobsRequest();
            
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
                request.MaxResults = cmdletContext.MaxResult.Value;
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
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Batch.Model.ListServiceJobsResponse CallAWSServiceOperation(IAmazonBatch client, Amazon.Batch.Model.ListServiceJobsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Batch", "ListServiceJobs");
            try
            {
                #if DESKTOP
                return client.ListServiceJobs(request);
                #elif CORECLR
                return client.ListServiceJobsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Batch.Model.KeyValuesPair> Filter { get; set; }
            public System.String JobQueue { get; set; }
            public Amazon.Batch.ServiceJobStatus JobStatus { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Batch.Model.ListServiceJobsResponse, GetBATServiceJobListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobSummaryList;
        }
        
    }
}
