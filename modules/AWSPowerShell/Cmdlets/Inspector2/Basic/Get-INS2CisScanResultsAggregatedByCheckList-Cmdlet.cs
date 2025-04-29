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
using Amazon.Inspector2;
using Amazon.Inspector2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.INS2
{
    /// <summary>
    /// Lists scan results aggregated by checks.
    /// </summary>
    [Cmdlet("Get", "INS2CisScanResultsAggregatedByCheckList")]
    [OutputType("Amazon.Inspector2.Model.CisCheckAggregation")]
    [AWSCmdlet("Calls the Inspector2 ListCisScanResultsAggregatedByChecks API operation.", Operation = new[] {"ListCisScanResultsAggregatedByChecks"}, SelectReturnType = typeof(Amazon.Inspector2.Model.ListCisScanResultsAggregatedByChecksResponse))]
    [AWSCmdletOutput("Amazon.Inspector2.Model.CisCheckAggregation or Amazon.Inspector2.Model.ListCisScanResultsAggregatedByChecksResponse",
        "This cmdlet returns a collection of Amazon.Inspector2.Model.CisCheckAggregation objects.",
        "The service call response (type Amazon.Inspector2.Model.ListCisScanResultsAggregatedByChecksResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetINS2CisScanResultsAggregatedByCheckListCmdlet : AmazonInspector2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        
        #region Parameter FilterCriteria_FailedResourcesFilter
        /// <summary>
        /// <para>
        /// <para>The criteria's failed resources filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_FailedResourcesFilters")]
        public Amazon.Inspector2.Model.CisNumberFilter[] FilterCriteria_FailedResourcesFilter { get; set; }
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
        
        #region Parameter FilterCriteria_SecurityLevelFilter
        /// <summary>
        /// <para>
        /// <para>The criteria's security level filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_SecurityLevelFilters")]
        public Amazon.Inspector2.Model.CisSecurityLevelFilter[] FilterCriteria_SecurityLevelFilter { get; set; }
        #endregion
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>The sort by order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Inspector2.CisScanResultsAggregatedByChecksSortBy")]
        public Amazon.Inspector2.CisScanResultsAggregatedByChecksSortBy SortBy { get; set; }
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
        
        #region Parameter FilterCriteria_TitleFilter
        /// <summary>
        /// <para>
        /// <para>The criteria's title filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_TitleFilters")]
        public Amazon.Inspector2.Model.CisStringFilter[] FilterCriteria_TitleFilter { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of scan results aggregated by checks to be returned in a single
        /// page of results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CheckAggregations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector2.Model.ListCisScanResultsAggregatedByChecksResponse).
        /// Specifying the name of a property of type Amazon.Inspector2.Model.ListCisScanResultsAggregatedByChecksResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CheckAggregations";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Inspector2.Model.ListCisScanResultsAggregatedByChecksResponse, GetINS2CisScanResultsAggregatedByCheckListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.FilterCriteria_AccountIdFilter != null)
            {
                context.FilterCriteria_AccountIdFilter = new List<Amazon.Inspector2.Model.CisStringFilter>(this.FilterCriteria_AccountIdFilter);
            }
            if (this.FilterCriteria_CheckIdFilter != null)
            {
                context.FilterCriteria_CheckIdFilter = new List<Amazon.Inspector2.Model.CisStringFilter>(this.FilterCriteria_CheckIdFilter);
            }
            if (this.FilterCriteria_FailedResourcesFilter != null)
            {
                context.FilterCriteria_FailedResourcesFilter = new List<Amazon.Inspector2.Model.CisNumberFilter>(this.FilterCriteria_FailedResourcesFilter);
            }
            if (this.FilterCriteria_PlatformFilter != null)
            {
                context.FilterCriteria_PlatformFilter = new List<Amazon.Inspector2.Model.CisStringFilter>(this.FilterCriteria_PlatformFilter);
            }
            if (this.FilterCriteria_SecurityLevelFilter != null)
            {
                context.FilterCriteria_SecurityLevelFilter = new List<Amazon.Inspector2.Model.CisSecurityLevelFilter>(this.FilterCriteria_SecurityLevelFilter);
            }
            if (this.FilterCriteria_TitleFilter != null)
            {
                context.FilterCriteria_TitleFilter = new List<Amazon.Inspector2.Model.CisStringFilter>(this.FilterCriteria_TitleFilter);
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
            var request = new Amazon.Inspector2.Model.ListCisScanResultsAggregatedByChecksRequest();
            
            
             // populate FilterCriteria
            var requestFilterCriteriaIsNull = true;
            request.FilterCriteria = new Amazon.Inspector2.Model.CisScanResultsAggregatedByChecksFilterCriteria();
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
            List<Amazon.Inspector2.Model.CisNumberFilter> requestFilterCriteria_filterCriteria_FailedResourcesFilter = null;
            if (cmdletContext.FilterCriteria_FailedResourcesFilter != null)
            {
                requestFilterCriteria_filterCriteria_FailedResourcesFilter = cmdletContext.FilterCriteria_FailedResourcesFilter;
            }
            if (requestFilterCriteria_filterCriteria_FailedResourcesFilter != null)
            {
                request.FilterCriteria.FailedResourcesFilters = requestFilterCriteria_filterCriteria_FailedResourcesFilter;
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
            List<Amazon.Inspector2.Model.CisSecurityLevelFilter> requestFilterCriteria_filterCriteria_SecurityLevelFilter = null;
            if (cmdletContext.FilterCriteria_SecurityLevelFilter != null)
            {
                requestFilterCriteria_filterCriteria_SecurityLevelFilter = cmdletContext.FilterCriteria_SecurityLevelFilter;
            }
            if (requestFilterCriteria_filterCriteria_SecurityLevelFilter != null)
            {
                request.FilterCriteria.SecurityLevelFilters = requestFilterCriteria_filterCriteria_SecurityLevelFilter;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CisStringFilter> requestFilterCriteria_filterCriteria_TitleFilter = null;
            if (cmdletContext.FilterCriteria_TitleFilter != null)
            {
                requestFilterCriteria_filterCriteria_TitleFilter = cmdletContext.FilterCriteria_TitleFilter;
            }
            if (requestFilterCriteria_filterCriteria_TitleFilter != null)
            {
                request.FilterCriteria.TitleFilters = requestFilterCriteria_filterCriteria_TitleFilter;
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
        
        private Amazon.Inspector2.Model.ListCisScanResultsAggregatedByChecksResponse CallAWSServiceOperation(IAmazonInspector2 client, Amazon.Inspector2.Model.ListCisScanResultsAggregatedByChecksRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Inspector2", "ListCisScanResultsAggregatedByChecks");
            try
            {
                return client.ListCisScanResultsAggregatedByChecksAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Inspector2.Model.CisNumberFilter> FilterCriteria_FailedResourcesFilter { get; set; }
            public List<Amazon.Inspector2.Model.CisStringFilter> FilterCriteria_PlatformFilter { get; set; }
            public List<Amazon.Inspector2.Model.CisSecurityLevelFilter> FilterCriteria_SecurityLevelFilter { get; set; }
            public List<Amazon.Inspector2.Model.CisStringFilter> FilterCriteria_TitleFilter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String ScanArn { get; set; }
            public Amazon.Inspector2.CisScanResultsAggregatedByChecksSortBy SortBy { get; set; }
            public Amazon.Inspector2.CisSortOrder SortOrder { get; set; }
            public System.Func<Amazon.Inspector2.Model.ListCisScanResultsAggregatedByChecksResponse, GetINS2CisScanResultsAggregatedByCheckListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CheckAggregations;
        }
        
    }
}
