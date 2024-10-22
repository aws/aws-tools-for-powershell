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
using Amazon.Comprehend;
using Amazon.Comprehend.Model;

namespace Amazon.PowerShell.Cmdlets.COMP
{
    /// <summary>
    /// Gets a list of the documentation classification jobs that you have submitted.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "COMPDocumentClassificationJobList")]
    [OutputType("Amazon.Comprehend.Model.DocumentClassificationJobProperties")]
    [AWSCmdlet("Calls the Amazon Comprehend ListDocumentClassificationJobs API operation.", Operation = new[] {"ListDocumentClassificationJobs"}, SelectReturnType = typeof(Amazon.Comprehend.Model.ListDocumentClassificationJobsResponse))]
    [AWSCmdletOutput("Amazon.Comprehend.Model.DocumentClassificationJobProperties or Amazon.Comprehend.Model.ListDocumentClassificationJobsResponse",
        "This cmdlet returns a collection of Amazon.Comprehend.Model.DocumentClassificationJobProperties objects.",
        "The service call response (type Amazon.Comprehend.Model.ListDocumentClassificationJobsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCOMPDocumentClassificationJobListCmdlet : AmazonComprehendClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter_JobName
        /// <summary>
        /// <para>
        /// <para>Filters on the name of the job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Filter_JobName { get; set; }
        #endregion
        
        #region Parameter Filter_JobStatus
        /// <summary>
        /// <para>
        /// <para>Filters the list based on job status. Returns only jobs with the specified status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Comprehend.JobStatus")]
        public Amazon.Comprehend.JobStatus Filter_JobStatus { get; set; }
        #endregion
        
        #region Parameter Filter_SubmitTimeAfter
        /// <summary>
        /// <para>
        /// <para>Filters the list of jobs based on the time that the job was submitted for processing.
        /// Returns only jobs submitted after the specified time. Jobs are returned in descending
        /// order, newest to oldest.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filter_SubmitTimeAfter { get; set; }
        #endregion
        
        #region Parameter Filter_SubmitTimeBefore
        /// <summary>
        /// <para>
        /// <para>Filters the list of jobs based on the time that the job was submitted for processing.
        /// Returns only jobs submitted before the specified time. Jobs are returned in ascending
        /// order, oldest to newest.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filter_SubmitTimeBefore { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in each page. The default is 100.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// <para>If a value for this parameter is not specified the cmdlet will use a default value of '<b>500</b>'.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Identifies the next page of results to return.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DocumentClassificationJobPropertiesList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Comprehend.Model.ListDocumentClassificationJobsResponse).
        /// Specifying the name of a property of type Amazon.Comprehend.Model.ListDocumentClassificationJobsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DocumentClassificationJobPropertiesList";
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
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Comprehend.Model.ListDocumentClassificationJobsResponse, GetCOMPDocumentClassificationJobListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Filter_JobName = this.Filter_JobName;
            context.Filter_JobStatus = this.Filter_JobStatus;
            context.Filter_SubmitTimeAfter = this.Filter_SubmitTimeAfter;
            context.Filter_SubmitTimeBefore = this.Filter_SubmitTimeBefore;
            context.MaxResult = this.MaxResult;
            #if MODULAR
            if (!ParameterWasBound(nameof(this.MaxResult)))
            {
                WriteVerbose("MaxResult parameter unset, using default value of '500'");
                context.MaxResult = 500;
            }
            #endif
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
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
            var request = new Amazon.Comprehend.Model.ListDocumentClassificationJobsRequest();
            
            
             // populate Filter
            var requestFilterIsNull = true;
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
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
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
            var request = new Amazon.Comprehend.Model.ListDocumentClassificationJobsRequest();
            
             // populate Filter
            var requestFilterIsNull = true;
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
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.MaxResult.HasValue)
            {
                // The service has a maximum page size of 500. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 500 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxResult;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    int correctPageSize = Math.Min(500, _emitLimit.Value);
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                }
                else if (!ParameterWasBound(nameof(this.MaxResult)))
                {
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(500);
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
                    int _receivedThisCall = response.DocumentClassificationJobPropertiesList?.Count ?? 0;
                    
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
        
        private Amazon.Comprehend.Model.ListDocumentClassificationJobsResponse CallAWSServiceOperation(IAmazonComprehend client, Amazon.Comprehend.Model.ListDocumentClassificationJobsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Comprehend", "ListDocumentClassificationJobs");
            try
            {
                #if DESKTOP
                return client.ListDocumentClassificationJobs(request);
                #elif CORECLR
                return client.ListDocumentClassificationJobsAsync(request).GetAwaiter().GetResult();
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
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Comprehend.Model.ListDocumentClassificationJobsResponse, GetCOMPDocumentClassificationJobListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DocumentClassificationJobPropertiesList;
        }
        
    }
}
