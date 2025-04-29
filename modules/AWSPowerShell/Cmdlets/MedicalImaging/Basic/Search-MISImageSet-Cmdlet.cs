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
using Amazon.MedicalImaging;
using Amazon.MedicalImaging.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.MIS
{
    /// <summary>
    /// Search image sets based on defined input attributes.
    /// 
    ///  <note><para><c>SearchImageSets</c> accepts a single search query parameter and returns a paginated
    /// response of all image sets that have the matching criteria. All date range queries
    /// must be input as <c>(lowerBound, upperBound)</c>.
    /// </para><para>
    /// By default, <c>SearchImageSets</c> uses the <c>updatedAt</c> field for sorting in
    /// descending order from newest to oldest.
    /// </para></note>
    /// </summary>
    [Cmdlet("Search", "MISImageSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MedicalImaging.Model.ImageSetsMetadataSummary")]
    [AWSCmdlet("Calls the Amazon Medical Imaging Service SearchImageSets API operation.", Operation = new[] {"SearchImageSets"}, SelectReturnType = typeof(Amazon.MedicalImaging.Model.SearchImageSetsResponse))]
    [AWSCmdletOutput("Amazon.MedicalImaging.Model.ImageSetsMetadataSummary or Amazon.MedicalImaging.Model.SearchImageSetsResponse",
        "This cmdlet returns a collection of Amazon.MedicalImaging.Model.ImageSetsMetadataSummary objects.",
        "The service call response (type Amazon.MedicalImaging.Model.SearchImageSetsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SearchMISImageSetCmdlet : AmazonMedicalImagingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DatastoreId
        /// <summary>
        /// <para>
        /// <para>The identifier of the data store where the image sets reside.</para>
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
        public System.String DatastoreId { get; set; }
        #endregion
        
        #region Parameter SearchCriteria_Filter
        /// <summary>
        /// <para>
        /// <para>The filters for the search criteria.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchCriteria_Filters")]
        public Amazon.MedicalImaging.Model.SearchFilter[] SearchCriteria_Filter { get; set; }
        #endregion
        
        #region Parameter Sort_SortField
        /// <summary>
        /// <para>
        /// <para>The sort field for search criteria.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchCriteria_Sort_SortField")]
        [AWSConstantClassSource("Amazon.MedicalImaging.SortField")]
        public Amazon.MedicalImaging.SortField Sort_SortField { get; set; }
        #endregion
        
        #region Parameter Sort_SortOrder
        /// <summary>
        /// <para>
        /// <para>The sort order for search criteria.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchCriteria_Sort_SortOrder")]
        [AWSConstantClassSource("Amazon.MedicalImaging.SortOrder")]
        public Amazon.MedicalImaging.SortOrder Sort_SortOrder { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results that can be returned in a search.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token used for pagination of results returned in the response. Use the token returned
        /// from the previous request to continue results where the previous request ended.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ImageSetsMetadataSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MedicalImaging.Model.SearchImageSetsResponse).
        /// Specifying the name of a property of type Amazon.MedicalImaging.Model.SearchImageSetsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ImageSetsMetadataSummaries";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DatastoreId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-MISImageSet (SearchImageSets)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MedicalImaging.Model.SearchImageSetsResponse, SearchMISImageSetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DatastoreId = this.DatastoreId;
            #if MODULAR
            if (this.DatastoreId == null && ParameterWasBound(nameof(this.DatastoreId)))
            {
                WriteWarning("You are passing $null as a value for parameter DatastoreId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.SearchCriteria_Filter != null)
            {
                context.SearchCriteria_Filter = new List<Amazon.MedicalImaging.Model.SearchFilter>(this.SearchCriteria_Filter);
            }
            context.Sort_SortField = this.Sort_SortField;
            context.Sort_SortOrder = this.Sort_SortOrder;
            
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
            var request = new Amazon.MedicalImaging.Model.SearchImageSetsRequest();
            
            if (cmdletContext.DatastoreId != null)
            {
                request.DatastoreId = cmdletContext.DatastoreId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            
             // populate SearchCriteria
            var requestSearchCriteriaIsNull = true;
            request.SearchCriteria = new Amazon.MedicalImaging.Model.SearchCriteria();
            List<Amazon.MedicalImaging.Model.SearchFilter> requestSearchCriteria_searchCriteria_Filter = null;
            if (cmdletContext.SearchCriteria_Filter != null)
            {
                requestSearchCriteria_searchCriteria_Filter = cmdletContext.SearchCriteria_Filter;
            }
            if (requestSearchCriteria_searchCriteria_Filter != null)
            {
                request.SearchCriteria.Filters = requestSearchCriteria_searchCriteria_Filter;
                requestSearchCriteriaIsNull = false;
            }
            Amazon.MedicalImaging.Model.Sort requestSearchCriteria_searchCriteria_Sort = null;
            
             // populate Sort
            var requestSearchCriteria_searchCriteria_SortIsNull = true;
            requestSearchCriteria_searchCriteria_Sort = new Amazon.MedicalImaging.Model.Sort();
            Amazon.MedicalImaging.SortField requestSearchCriteria_searchCriteria_Sort_sort_SortField = null;
            if (cmdletContext.Sort_SortField != null)
            {
                requestSearchCriteria_searchCriteria_Sort_sort_SortField = cmdletContext.Sort_SortField;
            }
            if (requestSearchCriteria_searchCriteria_Sort_sort_SortField != null)
            {
                requestSearchCriteria_searchCriteria_Sort.SortField = requestSearchCriteria_searchCriteria_Sort_sort_SortField;
                requestSearchCriteria_searchCriteria_SortIsNull = false;
            }
            Amazon.MedicalImaging.SortOrder requestSearchCriteria_searchCriteria_Sort_sort_SortOrder = null;
            if (cmdletContext.Sort_SortOrder != null)
            {
                requestSearchCriteria_searchCriteria_Sort_sort_SortOrder = cmdletContext.Sort_SortOrder;
            }
            if (requestSearchCriteria_searchCriteria_Sort_sort_SortOrder != null)
            {
                requestSearchCriteria_searchCriteria_Sort.SortOrder = requestSearchCriteria_searchCriteria_Sort_sort_SortOrder;
                requestSearchCriteria_searchCriteria_SortIsNull = false;
            }
             // determine if requestSearchCriteria_searchCriteria_Sort should be set to null
            if (requestSearchCriteria_searchCriteria_SortIsNull)
            {
                requestSearchCriteria_searchCriteria_Sort = null;
            }
            if (requestSearchCriteria_searchCriteria_Sort != null)
            {
                request.SearchCriteria.Sort = requestSearchCriteria_searchCriteria_Sort;
                requestSearchCriteriaIsNull = false;
            }
             // determine if request.SearchCriteria should be set to null
            if (requestSearchCriteriaIsNull)
            {
                request.SearchCriteria = null;
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
        
        private Amazon.MedicalImaging.Model.SearchImageSetsResponse CallAWSServiceOperation(IAmazonMedicalImaging client, Amazon.MedicalImaging.Model.SearchImageSetsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Medical Imaging Service", "SearchImageSets");
            try
            {
                return client.SearchImageSetsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DatastoreId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<Amazon.MedicalImaging.Model.SearchFilter> SearchCriteria_Filter { get; set; }
            public Amazon.MedicalImaging.SortField Sort_SortField { get; set; }
            public Amazon.MedicalImaging.SortOrder Sort_SortOrder { get; set; }
            public System.Func<Amazon.MedicalImaging.Model.SearchImageSetsResponse, SearchMISImageSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ImageSetsMetadataSummaries;
        }
        
    }
}
