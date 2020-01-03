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
using Amazon.Translate;
using Amazon.Translate.Model;

namespace Amazon.PowerShell.Cmdlets.TRN
{
    /// <summary>
    /// Gets a list of the batch translation jobs that you have submitted.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "TRNTextTranslationJobList")]
    [OutputType("Amazon.Translate.Model.TextTranslationJobProperties")]
    [AWSCmdlet("Calls the Amazon Translate ListTextTranslationJobs API operation.", Operation = new[] {"ListTextTranslationJobs"}, SelectReturnType = typeof(Amazon.Translate.Model.ListTextTranslationJobsResponse))]
    [AWSCmdletOutput("Amazon.Translate.Model.TextTranslationJobProperties or Amazon.Translate.Model.ListTextTranslationJobsResponse",
        "This cmdlet returns a collection of Amazon.Translate.Model.TextTranslationJobProperties objects.",
        "The service call response (type Amazon.Translate.Model.ListTextTranslationJobsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetTRNTextTranslationJobListCmdlet : AmazonTranslateClientCmdlet, IExecutor
    {
        
        #region Parameter Filter_JobName
        /// <summary>
        /// <para>
        /// <para>Filters the list of jobs by name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Filter_JobName { get; set; }
        #endregion
        
        #region Parameter Filter_JobStatus
        /// <summary>
        /// <para>
        /// <para>Filters the list of jobs based by job status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Translate.JobStatus")]
        public Amazon.Translate.JobStatus Filter_JobStatus { get; set; }
        #endregion
        
        #region Parameter Filter_SubmittedAfterTime
        /// <summary>
        /// <para>
        /// <para>Filters the list of jobs based on the time that the job was submitted for processing
        /// and returns only the jobs submitted after the specified time. Jobs are returned in
        /// descending order, newest to oldest.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filter_SubmittedAfterTime { get; set; }
        #endregion
        
        #region Parameter Filter_SubmittedBeforeTime
        /// <summary>
        /// <para>
        /// <para>Filters the list of jobs based on the time that the job was submitted for processing
        /// and returns only the jobs submitted before the specified time. Jobs are returned in
        /// ascending order, oldest to newest.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filter_SubmittedBeforeTime { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in each page. The default value is 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token to request the next page of results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TextTranslationJobPropertiesList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Translate.Model.ListTextTranslationJobsResponse).
        /// Specifying the name of a property of type Amazon.Translate.Model.ListTextTranslationJobsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TextTranslationJobPropertiesList";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Filter_JobName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Filter_JobName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Filter_JobName' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Translate.Model.ListTextTranslationJobsResponse, GetTRNTextTranslationJobListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Filter_JobName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Filter_JobName = this.Filter_JobName;
            context.Filter_JobStatus = this.Filter_JobStatus;
            context.Filter_SubmittedAfterTime = this.Filter_SubmittedAfterTime;
            context.Filter_SubmittedBeforeTime = this.Filter_SubmittedBeforeTime;
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
            var request = new Amazon.Translate.Model.ListTextTranslationJobsRequest();
            
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.Translate.Model.TextTranslationJobFilter();
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
            Amazon.Translate.JobStatus requestFilter_filter_JobStatus = null;
            if (cmdletContext.Filter_JobStatus != null)
            {
                requestFilter_filter_JobStatus = cmdletContext.Filter_JobStatus;
            }
            if (requestFilter_filter_JobStatus != null)
            {
                request.Filter.JobStatus = requestFilter_filter_JobStatus;
                requestFilterIsNull = false;
            }
            System.DateTime? requestFilter_filter_SubmittedAfterTime = null;
            if (cmdletContext.Filter_SubmittedAfterTime != null)
            {
                requestFilter_filter_SubmittedAfterTime = cmdletContext.Filter_SubmittedAfterTime.Value;
            }
            if (requestFilter_filter_SubmittedAfterTime != null)
            {
                request.Filter.SubmittedAfterTime = requestFilter_filter_SubmittedAfterTime.Value;
                requestFilterIsNull = false;
            }
            System.DateTime? requestFilter_filter_SubmittedBeforeTime = null;
            if (cmdletContext.Filter_SubmittedBeforeTime != null)
            {
                requestFilter_filter_SubmittedBeforeTime = cmdletContext.Filter_SubmittedBeforeTime.Value;
            }
            if (requestFilter_filter_SubmittedBeforeTime != null)
            {
                request.Filter.SubmittedBeforeTime = requestFilter_filter_SubmittedBeforeTime.Value;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
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
        
        private Amazon.Translate.Model.ListTextTranslationJobsResponse CallAWSServiceOperation(IAmazonTranslate client, Amazon.Translate.Model.ListTextTranslationJobsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Translate", "ListTextTranslationJobs");
            try
            {
                #if DESKTOP
                return client.ListTextTranslationJobs(request);
                #elif CORECLR
                return client.ListTextTranslationJobsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Translate.JobStatus Filter_JobStatus { get; set; }
            public System.DateTime? Filter_SubmittedAfterTime { get; set; }
            public System.DateTime? Filter_SubmittedBeforeTime { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Translate.Model.ListTextTranslationJobsResponse, GetTRNTextTranslationJobListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TextTranslationJobPropertiesList;
        }
        
    }
}
