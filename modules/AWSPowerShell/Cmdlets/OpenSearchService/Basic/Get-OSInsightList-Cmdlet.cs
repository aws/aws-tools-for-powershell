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
using Amazon.OpenSearchService;
using Amazon.OpenSearchService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.OS
{
    /// <summary>
    /// Lists insights for an Amazon OpenSearch Service domain or Amazon Web Services account.
    /// Returns a paginated list of insights based on the specified entity, filters, time
    /// range, and sort order.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "OSInsightList")]
    [OutputType("Amazon.OpenSearchService.Model.Insight")]
    [AWSCmdlet("Calls the Amazon OpenSearch Service ListInsights API operation.", Operation = new[] {"ListInsights"}, SelectReturnType = typeof(Amazon.OpenSearchService.Model.ListInsightsResponse))]
    [AWSCmdletOutput("Amazon.OpenSearchService.Model.Insight or Amazon.OpenSearchService.Model.ListInsightsResponse",
        "This cmdlet returns a collection of Amazon.OpenSearchService.Model.Insight objects.",
        "The service call response (type Amazon.OpenSearchService.Model.ListInsightsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetOSInsightListCmdlet : AmazonOpenSearchServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter TimeRange_From
        /// <summary>
        /// <para>
        /// <para>The start of the time range, in epoch milliseconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? TimeRange_From { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para>The sort order for the results. Possible values are <c>ASC</c> (ascending) and <c>DESC</c>
        /// (descending).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.OpenSearchService.InsightSortOrder")]
        public Amazon.OpenSearchService.InsightSortOrder SortOrder { get; set; }
        #endregion
        
        #region Parameter TimeRange_To
        /// <summary>
        /// <para>
        /// <para>The end of the time range, in epoch milliseconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? TimeRange_To { get; set; }
        #endregion
        
        #region Parameter Entity_Type
        /// <summary>
        /// <para>
        /// <para>The type of the entity. Possible values are <c>Account</c> and <c>DomainName</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.OpenSearchService.InsightEntityType")]
        public Amazon.OpenSearchService.InsightEntityType Entity_Type { get; set; }
        #endregion
        
        #region Parameter Entity_Value
        /// <summary>
        /// <para>
        /// <para>The value of the entity. For <c>DomainName</c>, this is the domain name. For <c>Account</c>,
        /// this is the Amazon Web Services account ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Entity_Value { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>An optional parameter that specifies the maximum number of results to return. You
        /// can use <c>NextToken</c> to get the next page of results. Valid values are 1 to 500.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If your initial <c>ListInsights</c> operation returns a <c>NextToken</c>, include
        /// the returned <c>NextToken</c> in subsequent <c>ListInsights</c> operations to retrieve
        /// the next page of results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Insights'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchService.Model.ListInsightsResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchService.Model.ListInsightsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Insights";
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
                context.Select = CreateSelectDelegate<Amazon.OpenSearchService.Model.ListInsightsResponse, GetOSInsightListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Entity_Type = this.Entity_Type;
            #if MODULAR
            if (this.Entity_Type == null && ParameterWasBound(nameof(this.Entity_Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Entity_Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Entity_Value = this.Entity_Value;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.SortOrder = this.SortOrder;
            context.TimeRange_From = this.TimeRange_From;
            context.TimeRange_To = this.TimeRange_To;
            
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
            var request = new Amazon.OpenSearchService.Model.ListInsightsRequest();
            
            
             // populate Entity
            var requestEntityIsNull = true;
            request.Entity = new Amazon.OpenSearchService.Model.InsightEntity();
            Amazon.OpenSearchService.InsightEntityType requestEntity_entity_Type = null;
            if (cmdletContext.Entity_Type != null)
            {
                requestEntity_entity_Type = cmdletContext.Entity_Type;
            }
            if (requestEntity_entity_Type != null)
            {
                request.Entity.Type = requestEntity_entity_Type;
                requestEntityIsNull = false;
            }
            System.String requestEntity_entity_Value = null;
            if (cmdletContext.Entity_Value != null)
            {
                requestEntity_entity_Value = cmdletContext.Entity_Value;
            }
            if (requestEntity_entity_Value != null)
            {
                request.Entity.Value = requestEntity_entity_Value;
                requestEntityIsNull = false;
            }
             // determine if request.Entity should be set to null
            if (requestEntityIsNull)
            {
                request.Entity = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.SortOrder != null)
            {
                request.SortOrder = cmdletContext.SortOrder;
            }
            
             // populate TimeRange
            var requestTimeRangeIsNull = true;
            request.TimeRange = new Amazon.OpenSearchService.Model.InsightTimeRange();
            System.Int64? requestTimeRange_timeRange_From = null;
            if (cmdletContext.TimeRange_From != null)
            {
                requestTimeRange_timeRange_From = cmdletContext.TimeRange_From.Value;
            }
            if (requestTimeRange_timeRange_From != null)
            {
                request.TimeRange.From = requestTimeRange_timeRange_From.Value;
                requestTimeRangeIsNull = false;
            }
            System.Int64? requestTimeRange_timeRange_To = null;
            if (cmdletContext.TimeRange_To != null)
            {
                requestTimeRange_timeRange_To = cmdletContext.TimeRange_To.Value;
            }
            if (requestTimeRange_timeRange_To != null)
            {
                request.TimeRange.To = requestTimeRange_timeRange_To.Value;
                requestTimeRangeIsNull = false;
            }
             // determine if request.TimeRange should be set to null
            if (requestTimeRangeIsNull)
            {
                request.TimeRange = null;
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
        
        private Amazon.OpenSearchService.Model.ListInsightsResponse CallAWSServiceOperation(IAmazonOpenSearchService client, Amazon.OpenSearchService.Model.ListInsightsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon OpenSearch Service", "ListInsights");
            try
            {
                return client.ListInsightsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.OpenSearchService.InsightEntityType Entity_Type { get; set; }
            public System.String Entity_Value { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.OpenSearchService.InsightSortOrder SortOrder { get; set; }
            public System.Int64? TimeRange_From { get; set; }
            public System.Int64? TimeRange_To { get; set; }
            public System.Func<Amazon.OpenSearchService.Model.ListInsightsResponse, GetOSInsightListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Insights;
        }
        
    }
}
