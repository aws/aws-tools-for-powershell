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
using Amazon.DevOpsGuru;
using Amazon.DevOpsGuru.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DGURU
{
    /// <summary>
    /// Returns a list of the anomalies that belong to an insight that you specify using
    /// its ID.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "DGURUAnomaliesForInsightList")]
    [OutputType("Amazon.DevOpsGuru.Model.ListAnomaliesForInsightResponse")]
    [AWSCmdlet("Calls the Amazon DevOps Guru ListAnomaliesForInsight API operation.", Operation = new[] {"ListAnomaliesForInsight"}, SelectReturnType = typeof(Amazon.DevOpsGuru.Model.ListAnomaliesForInsightResponse))]
    [AWSCmdletOutput("Amazon.DevOpsGuru.Model.ListAnomaliesForInsightResponse",
        "This cmdlet returns an Amazon.DevOpsGuru.Model.ListAnomaliesForInsightResponse object containing multiple properties."
    )]
    public partial class GetDGURUAnomaliesForInsightListCmdlet : AmazonDevOpsGuruClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter InsightId
        /// <summary>
        /// <para>
        /// <para> The ID of the insight. The returned anomalies belong to this insight. </para>
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
        public System.String InsightId { get; set; }
        #endregion
        
        #region Parameter ServiceCollection_ServiceName
        /// <summary>
        /// <para>
        /// <para>An array of strings that each specifies the name of an Amazon Web Services service.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_ServiceCollection_ServiceNames")]
        public System.String[] ServiceCollection_ServiceName { get; set; }
        #endregion
        
        #region Parameter StartTimeRange
        /// <summary>
        /// <para>
        /// <para> A time range used to specify when the requested anomalies started. All returned anomalies
        /// started during this time range. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.DevOpsGuru.Model.StartTimeRange StartTimeRange { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return with a single call. To retrieve the remaining
        /// results, make another call with the returned <c>nextToken</c> value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token to use to retrieve the next page of results for this operation.
        /// If this value is null, it retrieves the first page.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DevOpsGuru.Model.ListAnomaliesForInsightResponse).
        /// Specifying the name of a property of type Amazon.DevOpsGuru.Model.ListAnomaliesForInsightResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.DevOpsGuru.Model.ListAnomaliesForInsightResponse, GetDGURUAnomaliesForInsightListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountId = this.AccountId;
            if (this.ServiceCollection_ServiceName != null)
            {
                context.ServiceCollection_ServiceName = new List<System.String>(this.ServiceCollection_ServiceName);
            }
            context.InsightId = this.InsightId;
            #if MODULAR
            if (this.InsightId == null && ParameterWasBound(nameof(this.InsightId)))
            {
                WriteWarning("You are passing $null as a value for parameter InsightId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.StartTimeRange = this.StartTimeRange;
            
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
            var request = new Amazon.DevOpsGuru.Model.ListAnomaliesForInsightRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.DevOpsGuru.Model.ListAnomaliesForInsightFilters();
            Amazon.DevOpsGuru.Model.ServiceCollection requestFilters_filters_ServiceCollection = null;
            
             // populate ServiceCollection
            var requestFilters_filters_ServiceCollectionIsNull = true;
            requestFilters_filters_ServiceCollection = new Amazon.DevOpsGuru.Model.ServiceCollection();
            List<System.String> requestFilters_filters_ServiceCollection_serviceCollection_ServiceName = null;
            if (cmdletContext.ServiceCollection_ServiceName != null)
            {
                requestFilters_filters_ServiceCollection_serviceCollection_ServiceName = cmdletContext.ServiceCollection_ServiceName;
            }
            if (requestFilters_filters_ServiceCollection_serviceCollection_ServiceName != null)
            {
                requestFilters_filters_ServiceCollection.ServiceNames = requestFilters_filters_ServiceCollection_serviceCollection_ServiceName;
                requestFilters_filters_ServiceCollectionIsNull = false;
            }
             // determine if requestFilters_filters_ServiceCollection should be set to null
            if (requestFilters_filters_ServiceCollectionIsNull)
            {
                requestFilters_filters_ServiceCollection = null;
            }
            if (requestFilters_filters_ServiceCollection != null)
            {
                request.Filters.ServiceCollection = requestFilters_filters_ServiceCollection;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.InsightId != null)
            {
                request.InsightId = cmdletContext.InsightId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.StartTimeRange != null)
            {
                request.StartTimeRange = cmdletContext.StartTimeRange;
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
        
        private Amazon.DevOpsGuru.Model.ListAnomaliesForInsightResponse CallAWSServiceOperation(IAmazonDevOpsGuru client, Amazon.DevOpsGuru.Model.ListAnomaliesForInsightRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DevOps Guru", "ListAnomaliesForInsight");
            try
            {
                return client.ListAnomaliesForInsightAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public List<System.String> ServiceCollection_ServiceName { get; set; }
            public System.String InsightId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.DevOpsGuru.Model.StartTimeRange StartTimeRange { get; set; }
            public System.Func<Amazon.DevOpsGuru.Model.ListAnomaliesForInsightResponse, GetDGURUAnomaliesForInsightListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
