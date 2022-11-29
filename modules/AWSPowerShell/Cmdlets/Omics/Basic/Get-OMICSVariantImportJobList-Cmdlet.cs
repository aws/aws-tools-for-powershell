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
using Amazon.Omics;
using Amazon.Omics.Model;

namespace Amazon.PowerShell.Cmdlets.OMICS
{
    /// <summary>
    /// Retrieves a list of variant import jobs.
    /// </summary>
    [Cmdlet("Get", "OMICSVariantImportJobList")]
    [OutputType("Amazon.Omics.Model.VariantImportJobItem")]
    [AWSCmdlet("Calls the Amazon Omics ListVariantImportJobs API operation.", Operation = new[] {"ListVariantImportJobs"}, SelectReturnType = typeof(Amazon.Omics.Model.ListVariantImportJobsResponse))]
    [AWSCmdletOutput("Amazon.Omics.Model.VariantImportJobItem or Amazon.Omics.Model.ListVariantImportJobsResponse",
        "This cmdlet returns a collection of Amazon.Omics.Model.VariantImportJobItem objects.",
        "The service call response (type Amazon.Omics.Model.ListVariantImportJobsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetOMICSVariantImportJobListCmdlet : AmazonOmicsClientCmdlet, IExecutor
    {
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>A list of job IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Ids")]
        public System.String[] Id { get; set; }
        #endregion
        
        #region Parameter Filter_Status
        /// <summary>
        /// <para>
        /// <para>A status to filter on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Omics.JobStatus")]
        public Amazon.Omics.JobStatus Filter_Status { get; set; }
        #endregion
        
        #region Parameter Filter_StoreName
        /// <summary>
        /// <para>
        /// <para>A store name to filter on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filter_StoreName { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of import jobs to return in one page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Specify the pagination token from a previous request to retrieve the next page of
        /// results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VariantImportJobs'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Omics.Model.ListVariantImportJobsResponse).
        /// Specifying the name of a property of type Amazon.Omics.Model.ListVariantImportJobsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VariantImportJobs";
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Omics.Model.ListVariantImportJobsResponse, GetOMICSVariantImportJobListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Filter_Status = this.Filter_Status;
            context.Filter_StoreName = this.Filter_StoreName;
            if (this.Id != null)
            {
                context.Id = new List<System.String>(this.Id);
            }
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
            var request = new Amazon.Omics.Model.ListVariantImportJobsRequest();
            
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.Omics.Model.ListVariantImportJobsFilter();
            Amazon.Omics.JobStatus requestFilter_filter_Status = null;
            if (cmdletContext.Filter_Status != null)
            {
                requestFilter_filter_Status = cmdletContext.Filter_Status;
            }
            if (requestFilter_filter_Status != null)
            {
                request.Filter.Status = requestFilter_filter_Status;
                requestFilterIsNull = false;
            }
            System.String requestFilter_filter_StoreName = null;
            if (cmdletContext.Filter_StoreName != null)
            {
                requestFilter_filter_StoreName = cmdletContext.Filter_StoreName;
            }
            if (requestFilter_filter_StoreName != null)
            {
                request.Filter.StoreName = requestFilter_filter_StoreName;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
            }
            if (cmdletContext.Id != null)
            {
                request.Ids = cmdletContext.Id;
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
        
        private Amazon.Omics.Model.ListVariantImportJobsResponse CallAWSServiceOperation(IAmazonOmics client, Amazon.Omics.Model.ListVariantImportJobsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Omics", "ListVariantImportJobs");
            try
            {
                #if DESKTOP
                return client.ListVariantImportJobs(request);
                #elif CORECLR
                return client.ListVariantImportJobsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Omics.JobStatus Filter_Status { get; set; }
            public System.String Filter_StoreName { get; set; }
            public List<System.String> Id { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Omics.Model.ListVariantImportJobsResponse, GetOMICSVariantImportJobListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VariantImportJobs;
        }
        
    }
}
