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
using Amazon.Glacier;
using Amazon.Glacier.Model;

namespace Amazon.PowerShell.Cmdlets.GLC
{
    /// <summary>
    /// This operation lists jobs for a vault, including jobs that are in-progress and jobs
    /// that have recently finished. The List Job operation returns a list of these jobs sorted
    /// by job initiation time.
    /// 
    ///  <note><para>
    /// Amazon Glacier retains recently completed jobs for a period before deleting them;
    /// however, it eventually removes completed jobs. The output of completed jobs can be
    /// retrieved. Retaining completed jobs for a period of time after they have completed
    /// enables you to get a job output in the event you miss the job completion notification
    /// or your first attempt to download it fails. For example, suppose you start an archive
    /// retrieval job to download an archive. After the job completes, you start to download
    /// the archive but encounter a network error. In this scenario, you can retry and download
    /// the archive while the job exists.
    /// </para></note><para>
    /// The List Jobs operation supports pagination. You should always check the response
    /// <code>Marker</code> field. If there are no more jobs to list, the <code>Marker</code>
    /// field is set to <code>null</code>. If there are more jobs to list, the <code>Marker</code>
    /// field is set to a non-null value, which you can use to continue the pagination of
    /// the list. To return a list of jobs that begins at a specific job, set the marker request
    /// parameter to the <code>Marker</code> value for that job that you obtained from a previous
    /// List Jobs request.
    /// </para><para>
    /// You can set a maximum limit for the number of jobs returned in the response by specifying
    /// the <code>limit</code> parameter in the request. The default limit is 50. The number
    /// of jobs returned might be fewer than the limit, but the number of returned jobs never
    /// exceeds the limit.
    /// </para><para>
    /// Additionally, you can filter the jobs list returned by specifying the optional <code>statuscode</code>
    /// parameter or <code>completed</code> parameter, or both. Using the <code>statuscode</code>
    /// parameter, you can specify to return only jobs that match either the <code>InProgress</code>,
    /// <code>Succeeded</code>, or <code>Failed</code> status. Using the <code>completed</code>
    /// parameter, you can specify to return only jobs that were completed (<code>true</code>)
    /// or jobs that were not completed (<code>false</code>).
    /// </para><para>
    /// For more information about using this operation, see the documentation for the underlying
    /// REST API <a href="http://docs.aws.amazon.com/amazonglacier/latest/dev/api-jobs-get.html">List
    /// Jobs</a>. 
    /// </para><br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "GLCJobList")]
    [OutputType("Amazon.Glacier.Model.GlacierJobDescription")]
    [AWSCmdlet("Calls the Amazon Glacier ListJobs API operation.", Operation = new[] {"ListJobs"})]
    [AWSCmdletOutput("Amazon.Glacier.Model.GlacierJobDescription",
        "This cmdlet returns a collection of GlacierJobDescription objects.",
        "The service call response (type Amazon.Glacier.Model.ListJobsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: Marker (type System.String)"
    )]
    public partial class GetGLCJobListCmdlet : AmazonGlacierClientCmdlet, IExecutor
    {
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The <code>AccountId</code> value is the AWS account ID of the account that owns the
        /// vault. You can either specify an AWS account ID or optionally a single '<code>-</code>'
        /// (hyphen), in which case Amazon Glacier uses the AWS account ID associated with the
        /// credentials used to sign the request. If you use an account ID, do not include any
        /// hyphens ('-') in the ID. </para>
        /// </para>
        /// <para>If a value for this parameter is not specified the cmdlet will use a default value of '<b>-</b>'.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter Completed
        /// <summary>
        /// <para>
        /// <para>The state of the jobs to return. You can specify <code>true</code> or <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Completed { get; set; }
        #endregion
        
        #region Parameter Statuscode
        /// <summary>
        /// <para>
        /// <para>The type of job status to return. You can specify the following values: <code>InProgress</code>,
        /// <code>Succeeded</code>, or <code>Failed</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Statuscode { get; set; }
        #endregion
        
        #region Parameter VaultName
        /// <summary>
        /// <para>
        /// <para>The name of the vault.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String VaultName { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of jobs to be returned. The default limit is 50. The number of
        /// jobs returned might be fewer than the specified limit, but the number of returned
        /// jobs never exceeds the limit.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public int Limit { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>An opaque string used for pagination. This value specifies the job at which the listing
        /// of jobs should begin. Get the marker value from a previous List Jobs response. You
        /// only need to include the marker if you are continuing the pagination of results started
        /// in a previous List Jobs request.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, assign $null, for the first call, and the value of $AWSHistory.LastServiceResponse.Marker, for subsequent calls, to this parameter.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
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
            
            if (this.ParameterWasBound("AccountId"))
            {
                context.AccountId = this.AccountId;
            }
            else
            {
                WriteVerbose("AccountId parameter unset, using default value of '-'");
                context.AccountId = "-";
            }
            if (ParameterWasBound("Completed"))
                context.Completed = this.Completed;
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            context.Marker = this.Marker;
            context.Statuscode = this.Statuscode;
            context.VaultName = this.VaultName;
            
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
            var request = new Amazon.Glacier.Model.ListJobsRequest();
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.Completed != null)
            {
                request.Completed = cmdletContext.Completed.Value;
            }
            if (cmdletContext.Statuscode != null)
            {
                request.Statuscode = cmdletContext.Statuscode;
            }
            if (cmdletContext.VaultName != null)
            {
                request.VaultName = cmdletContext.VaultName;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            int? _pageSize = 50;
            if (AutoIterationHelpers.HasValue(cmdletContext.Marker))
            {
                _nextMarker = cmdletContext.Marker;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.Limit))
            {
                // The service has a maximum page size of 50. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 50 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.Limit;
            }
            bool _userControllingPaging = ParameterWasBound("Marker") || ParameterWasBound("Limit");
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.Marker = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.Limit = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    if (AutoIterationHelpers.HasValue(_pageSize))
                    {
                        int correctPageSize;
                        if (AutoIterationHelpers.IsSet(request.Limit))
                        {
                            correctPageSize = AutoIterationHelpers.Min(_pageSize.Value, request.Limit);
                        }
                        else
                        {
                            correctPageSize = _pageSize.Value;
                        }
                        request.Limit = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.JobList;
                        notes = new Dictionary<string, object>();
                        notes["Marker"] = response.Marker;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.JobList.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.Marker));
                        }
                        
                        _nextMarker = response.Marker;
                        
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
                    // The service has a maximum page size of 50 and the user has set a retrieval limit.
                    // Deduce what's left to fetch and if less than one page update _emitLimit to fetch just
                    // what's left to match the user's request.
                    
                    var _remainingItems = _emitLimit - _retrievedSoFar;
                    if (_remainingItems < _pageSize)
                    {
                        _emitLimit = _remainingItems;
                    }
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
        
        private Amazon.Glacier.Model.ListJobsResponse CallAWSServiceOperation(IAmazonGlacier client, Amazon.Glacier.Model.ListJobsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Glacier", "ListJobs");
            try
            {
                #if DESKTOP
                return client.ListJobs(request);
                #elif CORECLR
                return client.ListJobsAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public System.Boolean? Completed { get; set; }
            public int? Limit { get; set; }
            public System.String Marker { get; set; }
            public System.String Statuscode { get; set; }
            public System.String VaultName { get; set; }
        }
        
    }
}
