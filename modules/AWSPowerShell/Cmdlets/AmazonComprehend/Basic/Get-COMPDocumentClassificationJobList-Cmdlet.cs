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
using Amazon.Comprehend;
using Amazon.Comprehend.Model;

namespace Amazon.PowerShell.Cmdlets.COMP
{
    /// <summary>
    /// Gets a list of the documentation classification jobs that you have submitted.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "COMPDocumentClassificationJobList")]
    [OutputType("Amazon.Comprehend.Model.DocumentClassificationJobProperties")]
    [AWSCmdlet("Calls the Amazon Comprehend ListDocumentClassificationJobs API operation.", Operation = new[] {"ListDocumentClassificationJobs"})]
    [AWSCmdletOutput("Amazon.Comprehend.Model.DocumentClassificationJobProperties",
        "This cmdlet returns a collection of DocumentClassificationJobProperties objects.",
        "The service call response (type Amazon.Comprehend.Model.ListDocumentClassificationJobsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetCOMPDocumentClassificationJobListCmdlet : AmazonComprehendClientCmdlet, IExecutor
    {
        
        #region Parameter Filter_JobName
        /// <summary>
        /// <para>
        /// <para>Filters on the name of the job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Filter_JobName { get; set; }
        #endregion
        
        #region Parameter Filter_JobStatus
        /// <summary>
        /// <para>
        /// <para>Filters the list based on job status. Returns only jobs with the specified status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Comprehend.JobStatus")]
        public Amazon.Comprehend.JobStatus Filter_JobStatus { get; set; }
        #endregion
        
        #region Parameter Filter_SubmitTimeAfter
        /// <summary>
        /// <para>
        /// <para>Filters the list of jobs based on the time that the job was submitted for processing.
        /// Returns only jobs submitted before the specified time. Jobs are returned in descending
        /// order, newest to oldest.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime Filter_SubmitTimeAfter { get; set; }
        #endregion
        
        #region Parameter Filter_SubmitTimeBefore
        /// <summary>
        /// <para>
        /// <para>Filters the list of jobs based on the time that the job was submitted for processing.
        /// Returns only jobs submitted after the specified time. Jobs are returned in ascending
        /// order, oldest to newest.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime Filter_SubmitTimeBefore { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in each page. The default is 100.</para>
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
        /// <para>Identifies the next page of results to return.</para>
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
            
            context.Filter_JobName = this.Filter_JobName;
            context.Filter_JobStatus = this.Filter_JobStatus;
            if (ParameterWasBound("Filter_SubmitTimeAfter"))
                context.Filter_SubmitTimeAfter = this.Filter_SubmitTimeAfter;
            if (ParameterWasBound("Filter_SubmitTimeBefore"))
                context.Filter_SubmitTimeBefore = this.Filter_SubmitTimeBefore;
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
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
            var request = new Amazon.Comprehend.Model.ListDocumentClassificationJobsRequest();
            
             // populate Filter
            bool requestFilterIsNull = true;
            request.Filter = new Amazon.Comprehend.Model.DocumentClassificationJobFilter();
            System.String requestFilter_filter_JobName = null;
            if (cmdletContext.Filter_JobName != null)
            {
                requestFilter_filter_JobName = cmdletContext.Filter_JobName;
            }
            if (requestFilter_filter_JobName != null)
            {
                request.Filter.JobName = requestFilter_filter_JobName;
                requestFilterIsNull = false;
            }
            Amazon.Comprehend.JobStatus requestFilter_filter_JobStatus = null;
            if (cmdletContext.Filter_JobStatus != null)
            {
                requestFilter_filter_JobStatus = cmdletContext.Filter_JobStatus;
            }
            if (requestFilter_filter_JobStatus != null)
            {
                request.Filter.JobStatus = requestFilter_filter_JobStatus;
                requestFilterIsNull = false;
            }
            System.DateTime? requestFilter_filter_SubmitTimeAfter = null;
            if (cmdletContext.Filter_SubmitTimeAfter != null)
            {
                requestFilter_filter_SubmitTimeAfter = cmdletContext.Filter_SubmitTimeAfter.Value;
            }
            if (requestFilter_filter_SubmitTimeAfter != null)
            {
                request.Filter.SubmitTimeAfter = requestFilter_filter_SubmitTimeAfter.Value;
                requestFilterIsNull = false;
            }
            System.DateTime? requestFilter_filter_SubmitTimeBefore = null;
            if (cmdletContext.Filter_SubmitTimeBefore != null)
            {
                requestFilter_filter_SubmitTimeBefore = cmdletContext.Filter_SubmitTimeBefore.Value;
            }
            if (requestFilter_filter_SubmitTimeBefore != null)
            {
                request.Filter.SubmitTimeBefore = requestFilter_filter_SubmitTimeBefore.Value;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            int? _pageSize = 500;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextMarker = cmdletContext.NextToken;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxResults))
            {
                // The service has a maximum page size of 500. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 500 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
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
                    
                    if (AutoIterationHelpers.HasValue(_pageSize))
                    {
                        int correctPageSize;
                        if (AutoIterationHelpers.IsSet(request.MaxResults))
                        {
                            correctPageSize = AutoIterationHelpers.Min(_pageSize.Value, request.MaxResults);
                        }
                        else
                        {
                            correctPageSize = _pageSize.Value;
                        }
                        request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.DocumentClassificationJobPropertiesList;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.DocumentClassificationJobPropertiesList.Count;
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
                    // The service has a maximum page size of 500 and the user has set a retrieval limit.
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
        
        private Amazon.Comprehend.Model.ListDocumentClassificationJobsResponse CallAWSServiceOperation(IAmazonComprehend client, Amazon.Comprehend.Model.ListDocumentClassificationJobsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Comprehend", "ListDocumentClassificationJobs");
            try
            {
                #if DESKTOP
                return client.ListDocumentClassificationJobs(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ListDocumentClassificationJobsAsync(request);
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
            public System.String Filter_JobName { get; set; }
            public Amazon.Comprehend.JobStatus Filter_JobStatus { get; set; }
            public System.DateTime? Filter_SubmitTimeAfter { get; set; }
            public System.DateTime? Filter_SubmitTimeBefore { get; set; }
            public int? MaxResults { get; set; }
            public System.String NextToken { get; set; }
        }
        
    }
}
