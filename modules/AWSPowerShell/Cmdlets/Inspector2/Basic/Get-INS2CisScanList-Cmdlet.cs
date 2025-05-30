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
    /// Returns a CIS scan list.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration. This cmdlet didn't autopaginate in V4, auto-pagination support was added in V5.
    /// </summary>
    [Cmdlet("Get", "INS2CisScanList")]
    [OutputType("Amazon.Inspector2.Model.CisScan")]
    [AWSCmdlet("Calls the Inspector2 ListCisScans API operation.", Operation = new[] {"ListCisScans"}, SelectReturnType = typeof(Amazon.Inspector2.Model.ListCisScansResponse))]
    [AWSCmdletOutput("Amazon.Inspector2.Model.CisScan or Amazon.Inspector2.Model.ListCisScansResponse",
        "This cmdlet returns a collection of Amazon.Inspector2.Model.CisScan objects.",
        "The service call response (type Amazon.Inspector2.Model.ListCisScansResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetINS2CisScanListCmdlet : AmazonInspector2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DetailLevel
        /// <summary>
        /// <para>
        /// <para>The detail applied to the CIS scan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Inspector2.ListCisScansDetailLevel")]
        public Amazon.Inspector2.ListCisScansDetailLevel DetailLevel { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_FailedChecksFilter
        /// <summary>
        /// <para>
        /// <para>The list of failed checks filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_FailedChecksFilters")]
        public Amazon.Inspector2.Model.CisNumberFilter[] FilterCriteria_FailedChecksFilter { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_ScanArnFilter
        /// <summary>
        /// <para>
        /// <para>The list of scan ARN filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_ScanArnFilters")]
        public Amazon.Inspector2.Model.CisStringFilter[] FilterCriteria_ScanArnFilter { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_ScanAtFilter
        /// <summary>
        /// <para>
        /// <para>The list of scan at filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_ScanAtFilters")]
        public Amazon.Inspector2.Model.CisDateFilter[] FilterCriteria_ScanAtFilter { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_ScanConfigurationArnFilter
        /// <summary>
        /// <para>
        /// <para>The list of scan configuration ARN filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_ScanConfigurationArnFilters")]
        public Amazon.Inspector2.Model.CisStringFilter[] FilterCriteria_ScanConfigurationArnFilter { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_ScanNameFilter
        /// <summary>
        /// <para>
        /// <para>The list of scan name filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_ScanNameFilters")]
        public Amazon.Inspector2.Model.CisStringFilter[] FilterCriteria_ScanNameFilter { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_ScanStatusFilter
        /// <summary>
        /// <para>
        /// <para>The list of scan status filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_ScanStatusFilters")]
        public Amazon.Inspector2.Model.CisScanStatusFilter[] FilterCriteria_ScanStatusFilter { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_ScheduledByFilter
        /// <summary>
        /// <para>
        /// <para>The list of scheduled by filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_ScheduledByFilters")]
        public Amazon.Inspector2.Model.CisStringFilter[] FilterCriteria_ScheduledByFilter { get; set; }
        #endregion
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>The CIS scans sort by order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Inspector2.ListCisScansSortBy")]
        public Amazon.Inspector2.ListCisScansSortBy SortBy { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para>The CIS scans sort order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Inspector2.CisSortOrder")]
        public Amazon.Inspector2.CisSortOrder SortOrder { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_TargetAccountIdFilter
        /// <summary>
        /// <para>
        /// <para>The list of target account ID filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_TargetAccountIdFilters")]
        public Amazon.Inspector2.Model.CisStringFilter[] FilterCriteria_TargetAccountIdFilter { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_TargetResourceIdFilter
        /// <summary>
        /// <para>
        /// <para>The list of target resource ID filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_TargetResourceIdFilters")]
        public Amazon.Inspector2.Model.CisStringFilter[] FilterCriteria_TargetResourceIdFilter { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_TargetResourceTagFilter
        /// <summary>
        /// <para>
        /// <para>The list of target resource tag filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_TargetResourceTagFilters")]
        public Amazon.Inspector2.Model.TagFilter[] FilterCriteria_TargetResourceTagFilter { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to be returned.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token from a previous request that's used to retrieve the next page
        /// of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Scans'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector2.Model.ListCisScansResponse).
        /// Specifying the name of a property of type Amazon.Inspector2.Model.ListCisScansResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Scans";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// This cmdlet didn't autopaginate in V4. To preserve the V4 autopagination behavior for all cmdlets, run Set-AWSAutoIterationMode -IterationMode v4.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
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
                context.Select = CreateSelectDelegate<Amazon.Inspector2.Model.ListCisScansResponse, GetINS2CisScanListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DetailLevel = this.DetailLevel;
            if (this.FilterCriteria_FailedChecksFilter != null)
            {
                context.FilterCriteria_FailedChecksFilter = new List<Amazon.Inspector2.Model.CisNumberFilter>(this.FilterCriteria_FailedChecksFilter);
            }
            if (this.FilterCriteria_ScanArnFilter != null)
            {
                context.FilterCriteria_ScanArnFilter = new List<Amazon.Inspector2.Model.CisStringFilter>(this.FilterCriteria_ScanArnFilter);
            }
            if (this.FilterCriteria_ScanAtFilter != null)
            {
                context.FilterCriteria_ScanAtFilter = new List<Amazon.Inspector2.Model.CisDateFilter>(this.FilterCriteria_ScanAtFilter);
            }
            if (this.FilterCriteria_ScanConfigurationArnFilter != null)
            {
                context.FilterCriteria_ScanConfigurationArnFilter = new List<Amazon.Inspector2.Model.CisStringFilter>(this.FilterCriteria_ScanConfigurationArnFilter);
            }
            if (this.FilterCriteria_ScanNameFilter != null)
            {
                context.FilterCriteria_ScanNameFilter = new List<Amazon.Inspector2.Model.CisStringFilter>(this.FilterCriteria_ScanNameFilter);
            }
            if (this.FilterCriteria_ScanStatusFilter != null)
            {
                context.FilterCriteria_ScanStatusFilter = new List<Amazon.Inspector2.Model.CisScanStatusFilter>(this.FilterCriteria_ScanStatusFilter);
            }
            if (this.FilterCriteria_ScheduledByFilter != null)
            {
                context.FilterCriteria_ScheduledByFilter = new List<Amazon.Inspector2.Model.CisStringFilter>(this.FilterCriteria_ScheduledByFilter);
            }
            if (this.FilterCriteria_TargetAccountIdFilter != null)
            {
                context.FilterCriteria_TargetAccountIdFilter = new List<Amazon.Inspector2.Model.CisStringFilter>(this.FilterCriteria_TargetAccountIdFilter);
            }
            if (this.FilterCriteria_TargetResourceIdFilter != null)
            {
                context.FilterCriteria_TargetResourceIdFilter = new List<Amazon.Inspector2.Model.CisStringFilter>(this.FilterCriteria_TargetResourceIdFilter);
            }
            if (this.FilterCriteria_TargetResourceTagFilter != null)
            {
                context.FilterCriteria_TargetResourceTagFilter = new List<Amazon.Inspector2.Model.TagFilter>(this.FilterCriteria_TargetResourceTagFilter);
            }
            context.MaxResult = this.MaxResult;
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.Inspector2.Model.ListCisScansRequest();
            
            if (cmdletContext.DetailLevel != null)
            {
                request.DetailLevel = cmdletContext.DetailLevel;
            }
            
             // populate FilterCriteria
            var requestFilterCriteriaIsNull = true;
            request.FilterCriteria = new Amazon.Inspector2.Model.ListCisScansFilterCriteria();
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
            List<Amazon.Inspector2.Model.CisStringFilter> requestFilterCriteria_filterCriteria_ScanArnFilter = null;
            if (cmdletContext.FilterCriteria_ScanArnFilter != null)
            {
                requestFilterCriteria_filterCriteria_ScanArnFilter = cmdletContext.FilterCriteria_ScanArnFilter;
            }
            if (requestFilterCriteria_filterCriteria_ScanArnFilter != null)
            {
                request.FilterCriteria.ScanArnFilters = requestFilterCriteria_filterCriteria_ScanArnFilter;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CisDateFilter> requestFilterCriteria_filterCriteria_ScanAtFilter = null;
            if (cmdletContext.FilterCriteria_ScanAtFilter != null)
            {
                requestFilterCriteria_filterCriteria_ScanAtFilter = cmdletContext.FilterCriteria_ScanAtFilter;
            }
            if (requestFilterCriteria_filterCriteria_ScanAtFilter != null)
            {
                request.FilterCriteria.ScanAtFilters = requestFilterCriteria_filterCriteria_ScanAtFilter;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CisStringFilter> requestFilterCriteria_filterCriteria_ScanConfigurationArnFilter = null;
            if (cmdletContext.FilterCriteria_ScanConfigurationArnFilter != null)
            {
                requestFilterCriteria_filterCriteria_ScanConfigurationArnFilter = cmdletContext.FilterCriteria_ScanConfigurationArnFilter;
            }
            if (requestFilterCriteria_filterCriteria_ScanConfigurationArnFilter != null)
            {
                request.FilterCriteria.ScanConfigurationArnFilters = requestFilterCriteria_filterCriteria_ScanConfigurationArnFilter;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CisStringFilter> requestFilterCriteria_filterCriteria_ScanNameFilter = null;
            if (cmdletContext.FilterCriteria_ScanNameFilter != null)
            {
                requestFilterCriteria_filterCriteria_ScanNameFilter = cmdletContext.FilterCriteria_ScanNameFilter;
            }
            if (requestFilterCriteria_filterCriteria_ScanNameFilter != null)
            {
                request.FilterCriteria.ScanNameFilters = requestFilterCriteria_filterCriteria_ScanNameFilter;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CisScanStatusFilter> requestFilterCriteria_filterCriteria_ScanStatusFilter = null;
            if (cmdletContext.FilterCriteria_ScanStatusFilter != null)
            {
                requestFilterCriteria_filterCriteria_ScanStatusFilter = cmdletContext.FilterCriteria_ScanStatusFilter;
            }
            if (requestFilterCriteria_filterCriteria_ScanStatusFilter != null)
            {
                request.FilterCriteria.ScanStatusFilters = requestFilterCriteria_filterCriteria_ScanStatusFilter;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CisStringFilter> requestFilterCriteria_filterCriteria_ScheduledByFilter = null;
            if (cmdletContext.FilterCriteria_ScheduledByFilter != null)
            {
                requestFilterCriteria_filterCriteria_ScheduledByFilter = cmdletContext.FilterCriteria_ScheduledByFilter;
            }
            if (requestFilterCriteria_filterCriteria_ScheduledByFilter != null)
            {
                request.FilterCriteria.ScheduledByFilters = requestFilterCriteria_filterCriteria_ScheduledByFilter;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CisStringFilter> requestFilterCriteria_filterCriteria_TargetAccountIdFilter = null;
            if (cmdletContext.FilterCriteria_TargetAccountIdFilter != null)
            {
                requestFilterCriteria_filterCriteria_TargetAccountIdFilter = cmdletContext.FilterCriteria_TargetAccountIdFilter;
            }
            if (requestFilterCriteria_filterCriteria_TargetAccountIdFilter != null)
            {
                request.FilterCriteria.TargetAccountIdFilters = requestFilterCriteria_filterCriteria_TargetAccountIdFilter;
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
             // determine if request.FilterCriteria should be set to null
            if (requestFilterCriteriaIsNull)
            {
                request.FilterCriteria = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.SortBy != null)
            {
                request.SortBy = cmdletContext.SortBy;
            }
            if (cmdletContext.SortOrder != null)
            {
                request.SortOrder = cmdletContext.SortOrder;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            var _shouldAutoIterate = !(SessionState.PSVariable.GetValue("AWSPowerShell_AutoIteration_Mode")?.ToString() == "v4");
            
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
                
            } while (!_userControllingPaging && _shouldAutoIterate && AutoIterationHelpers.HasValue(_nextToken));
            
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
        
        private Amazon.Inspector2.Model.ListCisScansResponse CallAWSServiceOperation(IAmazonInspector2 client, Amazon.Inspector2.Model.ListCisScansRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Inspector2", "ListCisScans");
            try
            {
                return client.ListCisScansAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Inspector2.ListCisScansDetailLevel DetailLevel { get; set; }
            public List<Amazon.Inspector2.Model.CisNumberFilter> FilterCriteria_FailedChecksFilter { get; set; }
            public List<Amazon.Inspector2.Model.CisStringFilter> FilterCriteria_ScanArnFilter { get; set; }
            public List<Amazon.Inspector2.Model.CisDateFilter> FilterCriteria_ScanAtFilter { get; set; }
            public List<Amazon.Inspector2.Model.CisStringFilter> FilterCriteria_ScanConfigurationArnFilter { get; set; }
            public List<Amazon.Inspector2.Model.CisStringFilter> FilterCriteria_ScanNameFilter { get; set; }
            public List<Amazon.Inspector2.Model.CisScanStatusFilter> FilterCriteria_ScanStatusFilter { get; set; }
            public List<Amazon.Inspector2.Model.CisStringFilter> FilterCriteria_ScheduledByFilter { get; set; }
            public List<Amazon.Inspector2.Model.CisStringFilter> FilterCriteria_TargetAccountIdFilter { get; set; }
            public List<Amazon.Inspector2.Model.CisStringFilter> FilterCriteria_TargetResourceIdFilter { get; set; }
            public List<Amazon.Inspector2.Model.TagFilter> FilterCriteria_TargetResourceTagFilter { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.Inspector2.ListCisScansSortBy SortBy { get; set; }
            public Amazon.Inspector2.CisSortOrder SortOrder { get; set; }
            public System.Func<Amazon.Inspector2.Model.ListCisScansResponse, GetINS2CisScanListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Scans;
        }
        
    }
}
