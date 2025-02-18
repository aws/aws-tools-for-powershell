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
using Amazon.Omics;
using Amazon.Omics.Model;

namespace Amazon.PowerShell.Cmdlets.OMICS
{
    /// <summary>
    /// Retrieves a list of read set export jobs.
    /// </summary>
    [Cmdlet("Get", "OMICSReadSetExportJobList")]
    [OutputType("Amazon.Omics.Model.ExportReadSetJobDetail")]
    [AWSCmdlet("Calls the Amazon Omics ListReadSetExportJobs API operation.", Operation = new[] {"ListReadSetExportJobs"}, SelectReturnType = typeof(Amazon.Omics.Model.ListReadSetExportJobsResponse))]
    [AWSCmdletOutput("Amazon.Omics.Model.ExportReadSetJobDetail or Amazon.Omics.Model.ListReadSetExportJobsResponse",
        "This cmdlet returns a collection of Amazon.Omics.Model.ExportReadSetJobDetail objects.",
        "The service call response (type Amazon.Omics.Model.ListReadSetExportJobsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetOMICSReadSetExportJobListCmdlet : AmazonOmicsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Filter_CreatedAfter
        /// <summary>
        /// <para>
        /// <para>The filter's start date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filter_CreatedAfter { get; set; }
        #endregion
        
        #region Parameter Filter_CreatedBefore
        /// <summary>
        /// <para>
        /// <para>The filter's end date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filter_CreatedBefore { get; set; }
        #endregion
        
        #region Parameter SequenceStoreId
        /// <summary>
        /// <para>
        /// <para>The jobs' sequence store ID.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String SequenceStoreId { get; set; }
        #endregion
        
        #region Parameter Filter_Status
        /// <summary>
        /// <para>
        /// <para>A status to filter on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Omics.ReadSetExportJobStatus")]
        public Amazon.Omics.ReadSetExportJobStatus Filter_Status { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of jobs to return in one page of results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ExportJobs'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Omics.Model.ListReadSetExportJobsResponse).
        /// Specifying the name of a property of type Amazon.Omics.Model.ListReadSetExportJobsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ExportJobs";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Omics.Model.ListReadSetExportJobsResponse, GetOMICSReadSetExportJobListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Filter_CreatedAfter = this.Filter_CreatedAfter;
            context.Filter_CreatedBefore = this.Filter_CreatedBefore;
            context.Filter_Status = this.Filter_Status;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.SequenceStoreId = this.SequenceStoreId;
            #if MODULAR
            if (this.SequenceStoreId == null && ParameterWasBound(nameof(this.SequenceStoreId)))
            {
                WriteWarning("You are passing $null as a value for parameter SequenceStoreId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.Omics.Model.ListReadSetExportJobsRequest();
            
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.Omics.Model.ExportReadSetFilter();
            System.DateTime? requestFilter_filter_CreatedAfter = null;
            if (cmdletContext.Filter_CreatedAfter != null)
            {
                requestFilter_filter_CreatedAfter = cmdletContext.Filter_CreatedAfter.Value;
            }
            if (requestFilter_filter_CreatedAfter != null)
            {
                request.Filter.CreatedAfter = requestFilter_filter_CreatedAfter.Value;
                requestFilterIsNull = false;
            }
            System.DateTime? requestFilter_filter_CreatedBefore = null;
            if (cmdletContext.Filter_CreatedBefore != null)
            {
                requestFilter_filter_CreatedBefore = cmdletContext.Filter_CreatedBefore.Value;
            }
            if (requestFilter_filter_CreatedBefore != null)
            {
                request.Filter.CreatedBefore = requestFilter_filter_CreatedBefore.Value;
                requestFilterIsNull = false;
            }
            Amazon.Omics.ReadSetExportJobStatus requestFilter_filter_Status = null;
            if (cmdletContext.Filter_Status != null)
            {
                requestFilter_filter_Status = cmdletContext.Filter_Status;
            }
            if (requestFilter_filter_Status != null)
            {
                request.Filter.Status = requestFilter_filter_Status;
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
            if (cmdletContext.SequenceStoreId != null)
            {
                request.SequenceStoreId = cmdletContext.SequenceStoreId;
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
        
        private Amazon.Omics.Model.ListReadSetExportJobsResponse CallAWSServiceOperation(IAmazonOmics client, Amazon.Omics.Model.ListReadSetExportJobsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Omics", "ListReadSetExportJobs");
            try
            {
                return client.ListReadSetExportJobsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.DateTime? Filter_CreatedAfter { get; set; }
            public System.DateTime? Filter_CreatedBefore { get; set; }
            public Amazon.Omics.ReadSetExportJobStatus Filter_Status { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String SequenceStoreId { get; set; }
            public System.Func<Amazon.Omics.Model.ListReadSetExportJobsResponse, GetOMICSReadSetExportJobListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ExportJobs;
        }
        
    }
}
