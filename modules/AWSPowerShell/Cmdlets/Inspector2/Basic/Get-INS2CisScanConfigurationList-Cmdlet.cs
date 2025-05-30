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
    /// Lists CIS scan configurations.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration. This cmdlet didn't autopaginate in V4, auto-pagination support was added in V5.
    /// </summary>
    [Cmdlet("Get", "INS2CisScanConfigurationList")]
    [OutputType("Amazon.Inspector2.Model.CisScanConfiguration")]
    [AWSCmdlet("Calls the Inspector2 ListCisScanConfigurations API operation.", Operation = new[] {"ListCisScanConfigurations"}, SelectReturnType = typeof(Amazon.Inspector2.Model.ListCisScanConfigurationsResponse))]
    [AWSCmdletOutput("Amazon.Inspector2.Model.CisScanConfiguration or Amazon.Inspector2.Model.ListCisScanConfigurationsResponse",
        "This cmdlet returns a collection of Amazon.Inspector2.Model.CisScanConfiguration objects.",
        "The service call response (type Amazon.Inspector2.Model.ListCisScanConfigurationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetINS2CisScanConfigurationListCmdlet : AmazonInspector2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>The CIS scan configuration sort by order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Inspector2.CisScanConfigurationsSortBy")]
        public Amazon.Inspector2.CisScanConfigurationsSortBy SortBy { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para>The CIS scan configuration sort order order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Inspector2.CisSortOrder")]
        public Amazon.Inspector2.CisSortOrder SortOrder { get; set; }
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
        /// <para>The maximum number of CIS scan configurations to be returned in a single page of results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ScanConfigurations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector2.Model.ListCisScanConfigurationsResponse).
        /// Specifying the name of a property of type Amazon.Inspector2.Model.ListCisScanConfigurationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ScanConfigurations";
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
                context.Select = CreateSelectDelegate<Amazon.Inspector2.Model.ListCisScanConfigurationsResponse, GetINS2CisScanConfigurationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.FilterCriteria_ScanConfigurationArnFilter != null)
            {
                context.FilterCriteria_ScanConfigurationArnFilter = new List<Amazon.Inspector2.Model.CisStringFilter>(this.FilterCriteria_ScanConfigurationArnFilter);
            }
            if (this.FilterCriteria_ScanNameFilter != null)
            {
                context.FilterCriteria_ScanNameFilter = new List<Amazon.Inspector2.Model.CisStringFilter>(this.FilterCriteria_ScanNameFilter);
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
            var request = new Amazon.Inspector2.Model.ListCisScanConfigurationsRequest();
            
            
             // populate FilterCriteria
            var requestFilterCriteriaIsNull = true;
            request.FilterCriteria = new Amazon.Inspector2.Model.ListCisScanConfigurationsFilterCriteria();
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
        
        private Amazon.Inspector2.Model.ListCisScanConfigurationsResponse CallAWSServiceOperation(IAmazonInspector2 client, Amazon.Inspector2.Model.ListCisScanConfigurationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Inspector2", "ListCisScanConfigurations");
            try
            {
                return client.ListCisScanConfigurationsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Inspector2.Model.CisStringFilter> FilterCriteria_ScanConfigurationArnFilter { get; set; }
            public List<Amazon.Inspector2.Model.CisStringFilter> FilterCriteria_ScanNameFilter { get; set; }
            public List<Amazon.Inspector2.Model.TagFilter> FilterCriteria_TargetResourceTagFilter { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.Inspector2.CisScanConfigurationsSortBy SortBy { get; set; }
            public Amazon.Inspector2.CisSortOrder SortOrder { get; set; }
            public System.Func<Amazon.Inspector2.Model.ListCisScanConfigurationsResponse, GetINS2CisScanConfigurationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ScanConfigurations;
        }
        
    }
}
