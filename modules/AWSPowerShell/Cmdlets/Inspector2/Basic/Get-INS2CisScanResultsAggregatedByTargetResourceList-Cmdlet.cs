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
using Amazon.Inspector2;
using Amazon.Inspector2.Model;

namespace Amazon.PowerShell.Cmdlets.INS2
{
    /// <summary>
    /// Lists scan results aggregated by a target resource.
    /// </summary>
    [Cmdlet("Get", "INS2CisScanResultsAggregatedByTargetResourceList")]
    [OutputType("Amazon.Inspector2.Model.CisTargetResourceAggregation")]
    [AWSCmdlet("Calls the Inspector2 ListCisScanResultsAggregatedByTargetResource API operation.", Operation = new[] {"ListCisScanResultsAggregatedByTargetResource"}, SelectReturnType = typeof(Amazon.Inspector2.Model.ListCisScanResultsAggregatedByTargetResourceResponse))]
    [AWSCmdletOutput("Amazon.Inspector2.Model.CisTargetResourceAggregation or Amazon.Inspector2.Model.ListCisScanResultsAggregatedByTargetResourceResponse",
        "This cmdlet returns a collection of Amazon.Inspector2.Model.CisTargetResourceAggregation objects.",
        "The service call response (type Amazon.Inspector2.Model.ListCisScanResultsAggregatedByTargetResourceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetINS2CisScanResultsAggregatedByTargetResourceListCmdlet : AmazonInspector2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FilterCriteria_AccountIdFilter
        /// <summary>
        /// <para>
        /// <para>The criteria's account ID filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_AccountIdFilters")]
        public Amazon.Inspector2.Model.CisStringFilter[] FilterCriteria_AccountIdFilter { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_CheckIdFilter
        /// <summary>
        /// <para>
        /// <para>The criteria's check ID filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_CheckIdFilters")]
        public Amazon.Inspector2.Model.CisStringFilter[] FilterCriteria_CheckIdFilter { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_FailedChecksFilter
        /// <summary>
        /// <para>
        /// <para>The criteria's failed checks filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_FailedChecksFilters")]
        public Amazon.Inspector2.Model.CisNumberFilter[] FilterCriteria_FailedChecksFilter { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_PlatformFilter
        /// <summary>
        /// <para>
        /// <para>The criteria's platform filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_PlatformFilters")]
        public Amazon.Inspector2.Model.CisStringFilter[] FilterCriteria_PlatformFilter { get; set; }
        #endregion
        
        #region Parameter ScanArn
        /// <summary>
        /// <para>
        /// <para>The scan ARN.</para>
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
        public System.String ScanArn { get; set; }
        #endregion
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>The sort by order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Inspector2.CisScanResultsAggregatedByTargetResourceSortBy")]
        public Amazon.Inspector2.CisScanResultsAggregatedByTargetResourceSortBy SortBy { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para>The sort order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Inspector2.CisSortOrder")]
        public Amazon.Inspector2.CisSortOrder SortOrder { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_StatusFilter
        /// <summary>
        /// <para>
        /// <para>The criteria's status filter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_StatusFilters")]
        public Amazon.Inspector2.Model.CisResultStatusFilter[] FilterCriteria_StatusFilter { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_TargetResourceIdFilter
        /// <summary>
        /// <para>
        /// <para>The criteria's target resource ID filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_TargetResourceIdFilters")]
        public Amazon.Inspector2.Model.CisStringFilter[] FilterCriteria_TargetResourceIdFilter { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_TargetResourceTagFilter
        /// <summary>
        /// <para>
        /// <para>The criteria's target resource tag filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_TargetResourceTagFilters")]
        public Amazon.Inspector2.Model.TagFilter[] FilterCriteria_TargetResourceTagFilter { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_TargetStatusFilter
        /// <summary>
        /// <para>
        /// <para>The criteria's target status filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_TargetStatusFilters")]
        public Amazon.Inspector2.Model.CisTargetStatusFilter[] FilterCriteria_TargetStatusFilter { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_TargetStatusReasonFilter
        /// <summary>
        /// <para>
        /// <para>The criteria's target status reason filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_TargetStatusReasonFilters")]
        public Amazon.Inspector2.Model.CisTargetStatusReasonFilter[] FilterCriteria_TargetStatusReasonFilter { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of scan results aggregated by a target resource to be returned
        /// in a single page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token from a previous request that's used to retrieve the next page
        /// of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TargetResourceAggregations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector2.Model.ListCisScanResultsAggregatedByTargetResourceResponse).
        /// Specifying the name of a property of type Amazon.Inspector2.Model.ListCisScanResultsAggregatedByTargetResourceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TargetResourceAggregations";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ScanArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ScanArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ScanArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
                context.Select = CreateSelectDelegate<Amazon.Inspector2.Model.ListCisScanResultsAggregatedByTargetResourceResponse, GetINS2CisScanResultsAggregatedByTargetResourceListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ScanArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.FilterCriteria_AccountIdFilter != null)
            {
                context.FilterCriteria_AccountIdFilter = new List<Amazon.Inspector2.Model.CisStringFilter>(this.FilterCriteria_AccountIdFilter);
            }
            if (this.FilterCriteria_CheckIdFilter != null)
            {
                context.FilterCriteria_CheckIdFilter = new List<Amazon.Inspector2.Model.CisStringFilter>(this.FilterCriteria_CheckIdFilter);
            }
            if (this.FilterCriteria_FailedChecksFilter != null)
            {
                context.FilterCriteria_FailedChecksFilter = new List<Amazon.Inspector2.Model.CisNumberFilter>(this.FilterCriteria_FailedChecksFilter);
            }
            if (this.FilterCriteria_PlatformFilter != null)
            {
                context.FilterCriteria_PlatformFilter = new List<Amazon.Inspector2.Model.CisStringFilter>(this.FilterCriteria_PlatformFilter);
            }
            if (this.FilterCriteria_StatusFilter != null)
            {
                context.FilterCriteria_StatusFilter = new List<Amazon.Inspector2.Model.CisResultStatusFilter>(this.FilterCriteria_StatusFilter);
            }
            if (this.FilterCriteria_TargetResourceIdFilter != null)
            {
                context.FilterCriteria_TargetResourceIdFilter = new List<Amazon.Inspector2.Model.CisStringFilter>(this.FilterCriteria_TargetResourceIdFilter);
            }
            if (this.FilterCriteria_TargetResourceTagFilter != null)
            {
                context.FilterCriteria_TargetResourceTagFilter = new List<Amazon.Inspector2.Model.TagFilter>(this.FilterCriteria_TargetResourceTagFilter);
            }
            if (this.FilterCriteria_TargetStatusFilter != null)
            {
                context.FilterCriteria_TargetStatusFilter = new List<Amazon.Inspector2.Model.CisTargetStatusFilter>(this.FilterCriteria_TargetStatusFilter);
            }
            if (this.FilterCriteria_TargetStatusReasonFilter != null)
            {
                context.FilterCriteria_TargetStatusReasonFilter = new List<Amazon.Inspector2.Model.CisTargetStatusReasonFilter>(this.FilterCriteria_TargetStatusReasonFilter);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ScanArn = this.ScanArn;
            #if MODULAR
            if (this.ScanArn == null && ParameterWasBound(nameof(this.ScanArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ScanArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SortBy = this.SortBy;
            context.SortOrder = this.SortOrder;
            
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
            var request = new Amazon.Inspector2.Model.ListCisScanResultsAggregatedByTargetResourceRequest();
            
            
             // populate FilterCriteria
            var requestFilterCriteriaIsNull = true;
            request.FilterCriteria = new Amazon.Inspector2.Model.CisScanResultsAggregatedByTargetResourceFilterCriteria();
            List<Amazon.Inspector2.Model.CisStringFilter> requestFilterCriteria_filterCriteria_AccountIdFilter = null;
            if (cmdletContext.FilterCriteria_AccountIdFilter != null)
            {
                requestFilterCriteria_filterCriteria_AccountIdFilter = cmdletContext.FilterCriteria_AccountIdFilter;
            }
            if (requestFilterCriteria_filterCriteria_AccountIdFilter != null)
            {
                request.FilterCriteria.AccountIdFilters = requestFilterCriteria_filterCriteria_AccountIdFilter;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CisStringFilter> requestFilterCriteria_filterCriteria_CheckIdFilter = null;
            if (cmdletContext.FilterCriteria_CheckIdFilter != null)
            {
                requestFilterCriteria_filterCriteria_CheckIdFilter = cmdletContext.FilterCriteria_CheckIdFilter;
            }
            if (requestFilterCriteria_filterCriteria_CheckIdFilter != null)
            {
                request.FilterCriteria.CheckIdFilters = requestFilterCriteria_filterCriteria_CheckIdFilter;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CisNumberFilter> requestFilterCriteria_filterCriteria_FailedChecksFilter = null;
            if (cmdletContext.FilterCriteria_FailedChecksFilter != null)
            {
                requestFilterCriteria_filterCriteria_FailedChecksFilter = cmdletContext.FilterCriteria_FailedChecksFilter;
            }
            if (requestFilterCriteria_filterCriteria_FailedChecksFilter != null)
            {
                request.FilterCriteria.FailedChecksFilters = requestFilterCriteria_filterCriteria_FailedChecksFilter;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CisStringFilter> requestFilterCriteria_filterCriteria_PlatformFilter = null;
            if (cmdletContext.FilterCriteria_PlatformFilter != null)
            {
                requestFilterCriteria_filterCriteria_PlatformFilter = cmdletContext.FilterCriteria_PlatformFilter;
            }
            if (requestFilterCriteria_filterCriteria_PlatformFilter != null)
            {
                request.FilterCriteria.PlatformFilters = requestFilterCriteria_filterCriteria_PlatformFilter;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CisResultStatusFilter> requestFilterCriteria_filterCriteria_StatusFilter = null;
            if (cmdletContext.FilterCriteria_StatusFilter != null)
            {
                requestFilterCriteria_filterCriteria_StatusFilter = cmdletContext.FilterCriteria_StatusFilter;
            }
            if (requestFilterCriteria_filterCriteria_StatusFilter != null)
            {
                request.FilterCriteria.StatusFilters = requestFilterCriteria_filterCriteria_StatusFilter;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CisStringFilter> requestFilterCriteria_filterCriteria_TargetResourceIdFilter = null;
            if (cmdletContext.FilterCriteria_TargetResourceIdFilter != null)
            {
                requestFilterCriteria_filterCriteria_TargetResourceIdFilter = cmdletContext.FilterCriteria_TargetResourceIdFilter;
            }
            if (requestFilterCriteria_filterCriteria_TargetResourceIdFilter != null)
            {
                request.FilterCriteria.TargetResourceIdFilters = requestFilterCriteria_filterCriteria_TargetResourceIdFilter;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.TagFilter> requestFilterCriteria_filterCriteria_TargetResourceTagFilter = null;
            if (cmdletContext.FilterCriteria_TargetResourceTagFilter != null)
            {
                requestFilterCriteria_filterCriteria_TargetResourceTagFilter = cmdletContext.FilterCriteria_TargetResourceTagFilter;
            }
            if (requestFilterCriteria_filterCriteria_TargetResourceTagFilter != null)
            {
                request.FilterCriteria.TargetResourceTagFilters = requestFilterCriteria_filterCriteria_TargetResourceTagFilter;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CisTargetStatusFilter> requestFilterCriteria_filterCriteria_TargetStatusFilter = null;
            if (cmdletContext.FilterCriteria_TargetStatusFilter != null)
            {
                requestFilterCriteria_filterCriteria_TargetStatusFilter = cmdletContext.FilterCriteria_TargetStatusFilter;
            }
            if (requestFilterCriteria_filterCriteria_TargetStatusFilter != null)
            {
                request.FilterCriteria.TargetStatusFilters = requestFilterCriteria_filterCriteria_TargetStatusFilter;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CisTargetStatusReasonFilter> requestFilterCriteria_filterCriteria_TargetStatusReasonFilter = null;
            if (cmdletContext.FilterCriteria_TargetStatusReasonFilter != null)
            {
                requestFilterCriteria_filterCriteria_TargetStatusReasonFilter = cmdletContext.FilterCriteria_TargetStatusReasonFilter;
            }
            if (requestFilterCriteria_filterCriteria_TargetStatusReasonFilter != null)
            {
                request.FilterCriteria.TargetStatusReasonFilters = requestFilterCriteria_filterCriteria_TargetStatusReasonFilter;
                requestFilterCriteriaIsNull = false;
            }
             // determine if request.FilterCriteria should be set to null
            if (requestFilterCriteriaIsNull)
            {
                request.FilterCriteria = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.ScanArn != null)
            {
                request.ScanArn = cmdletContext.ScanArn;
            }
            if (cmdletContext.SortBy != null)
            {
                request.SortBy = cmdletContext.SortBy;
            }
            if (cmdletContext.SortOrder != null)
            {
                request.SortOrder = cmdletContext.SortOrder;
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
        
        private Amazon.Inspector2.Model.ListCisScanResultsAggregatedByTargetResourceResponse CallAWSServiceOperation(IAmazonInspector2 client, Amazon.Inspector2.Model.ListCisScanResultsAggregatedByTargetResourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Inspector2", "ListCisScanResultsAggregatedByTargetResource");
            try
            {
                #if DESKTOP
                return client.ListCisScanResultsAggregatedByTargetResource(request);
                #elif CORECLR
                return client.ListCisScanResultsAggregatedByTargetResourceAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Inspector2.Model.CisStringFilter> FilterCriteria_AccountIdFilter { get; set; }
            public List<Amazon.Inspector2.Model.CisStringFilter> FilterCriteria_CheckIdFilter { get; set; }
            public List<Amazon.Inspector2.Model.CisNumberFilter> FilterCriteria_FailedChecksFilter { get; set; }
            public List<Amazon.Inspector2.Model.CisStringFilter> FilterCriteria_PlatformFilter { get; set; }
            public List<Amazon.Inspector2.Model.CisResultStatusFilter> FilterCriteria_StatusFilter { get; set; }
            public List<Amazon.Inspector2.Model.CisStringFilter> FilterCriteria_TargetResourceIdFilter { get; set; }
            public List<Amazon.Inspector2.Model.TagFilter> FilterCriteria_TargetResourceTagFilter { get; set; }
            public List<Amazon.Inspector2.Model.CisTargetStatusFilter> FilterCriteria_TargetStatusFilter { get; set; }
            public List<Amazon.Inspector2.Model.CisTargetStatusReasonFilter> FilterCriteria_TargetStatusReasonFilter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String ScanArn { get; set; }
            public Amazon.Inspector2.CisScanResultsAggregatedByTargetResourceSortBy SortBy { get; set; }
            public Amazon.Inspector2.CisSortOrder SortOrder { get; set; }
            public System.Func<Amazon.Inspector2.Model.ListCisScanResultsAggregatedByTargetResourceResponse, GetINS2CisScanResultsAggregatedByTargetResourceListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TargetResourceAggregations;
        }
        
    }
}
