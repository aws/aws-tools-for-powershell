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
using Amazon.ComprehendMedical;
using Amazon.ComprehendMedical.Model;

namespace Amazon.PowerShell.Cmdlets.CMPM
{
    /// <summary>
    /// Gets a list of InferSNOMEDCT jobs a user has submitted.
    /// </summary>
    [Cmdlet("Get", "CMPMSNOMEDCTInferenceJobList")]
    [OutputType("Amazon.ComprehendMedical.Model.ComprehendMedicalAsyncJobProperties")]
    [AWSCmdlet("Calls the AWS Comprehend Medical ListSNOMEDCTInferenceJobs API operation.", Operation = new[] {"ListSNOMEDCTInferenceJobs"}, SelectReturnType = typeof(Amazon.ComprehendMedical.Model.ListSNOMEDCTInferenceJobsResponse))]
    [AWSCmdletOutput("Amazon.ComprehendMedical.Model.ComprehendMedicalAsyncJobProperties or Amazon.ComprehendMedical.Model.ListSNOMEDCTInferenceJobsResponse",
        "This cmdlet returns a collection of Amazon.ComprehendMedical.Model.ComprehendMedicalAsyncJobProperties objects.",
        "The service call response (type Amazon.ComprehendMedical.Model.ListSNOMEDCTInferenceJobsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCMPMSNOMEDCTInferenceJobListCmdlet : AmazonComprehendMedicalClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter_JobName
        /// <summary>
        /// <para>
        /// <para>Filters on the name of the job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filter_JobName { get; set; }
        #endregion
        
        #region Parameter Filter_JobStatus
        /// <summary>
        /// <para>
        /// <para>Filters the list of jobs based on job status. Returns only jobs with the specified
        /// status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ComprehendMedical.JobStatus")]
        public Amazon.ComprehendMedical.JobStatus Filter_JobStatus { get; set; }
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
        /// <para> The maximum number of results to return in each page. The default is 100. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para> Identifies the next page of InferSNOMEDCT results to return. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ComprehendMedicalAsyncJobPropertiesList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ComprehendMedical.Model.ListSNOMEDCTInferenceJobsResponse).
        /// Specifying the name of a property of type Amazon.ComprehendMedical.Model.ListSNOMEDCTInferenceJobsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ComprehendMedicalAsyncJobPropertiesList";
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
                context.Select = CreateSelectDelegate<Amazon.ComprehendMedical.Model.ListSNOMEDCTInferenceJobsResponse, GetCMPMSNOMEDCTInferenceJobListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Filter_JobName = this.Filter_JobName;
            context.Filter_JobStatus = this.Filter_JobStatus;
            context.Filter_SubmitTimeAfter = this.Filter_SubmitTimeAfter;
            context.Filter_SubmitTimeBefore = this.Filter_SubmitTimeBefore;
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
            // create request
            var request = new Amazon.ComprehendMedical.Model.ListSNOMEDCTInferenceJobsRequest();
            
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.ComprehendMedical.Model.ComprehendMedicalAsyncJobFilter();
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
            Amazon.ComprehendMedical.JobStatus requestFilter_filter_JobStatus = null;
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
                request.MaxResults = cmdletContext.MaxResult.Value;
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
        
        private Amazon.ComprehendMedical.Model.ListSNOMEDCTInferenceJobsResponse CallAWSServiceOperation(IAmazonComprehendMedical client, Amazon.ComprehendMedical.Model.ListSNOMEDCTInferenceJobsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Comprehend Medical", "ListSNOMEDCTInferenceJobs");
            try
            {
                #if DESKTOP
                return client.ListSNOMEDCTInferenceJobs(request);
                #elif CORECLR
                return client.ListSNOMEDCTInferenceJobsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.ComprehendMedical.JobStatus Filter_JobStatus { get; set; }
            public System.DateTime? Filter_SubmitTimeAfter { get; set; }
            public System.DateTime? Filter_SubmitTimeBefore { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.ComprehendMedical.Model.ListSNOMEDCTInferenceJobsResponse, GetCMPMSNOMEDCTInferenceJobListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ComprehendMedicalAsyncJobPropertiesList;
        }
        
    }
}
