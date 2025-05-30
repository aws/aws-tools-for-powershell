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
using Amazon.LexModelsV2;
using Amazon.LexModelsV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LMBV2
{
    /// <summary>
    /// Retrieves a list of metadata for individual user sessions with your bot. The <c>startDateTime</c>
    /// and <c>endDateTime</c> fields are required. These fields define a time range for which
    /// you want to retrieve results. Of the optional fields, you can organize the results
    /// in the following ways:
    /// 
    ///  <ul><li><para>
    /// Use the <c>filters</c> field to filter the results and the <c>sortBy</c> field to
    /// specify the values by which to sort the results.
    /// </para></li><li><para>
    /// Use the <c>maxResults</c> field to limit the number of results to return in a single
    /// response and the <c>nextToken</c> field to return the next batch of results if the
    /// response does not return the full set of results.
    /// </para></li></ul><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration. This cmdlet didn't autopaginate in V4, auto-pagination support was added in V5.
    /// </summary>
    [Cmdlet("Get", "LMBV2SessionAnalyticsDataList")]
    [OutputType("Amazon.LexModelsV2.Model.ListSessionAnalyticsDataResponse")]
    [AWSCmdlet("Calls the Amazon Lex Model Building V2 ListSessionAnalyticsData API operation.", Operation = new[] {"ListSessionAnalyticsData"}, SelectReturnType = typeof(Amazon.LexModelsV2.Model.ListSessionAnalyticsDataResponse))]
    [AWSCmdletOutput("Amazon.LexModelsV2.Model.ListSessionAnalyticsDataResponse",
        "This cmdlet returns an Amazon.LexModelsV2.Model.ListSessionAnalyticsDataResponse object containing multiple properties."
    )]
    public partial class GetLMBV2SessionAnalyticsDataListCmdlet : AmazonLexModelsV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BotId
        /// <summary>
        /// <para>
        /// <para>The identifier for the bot for which you want to retrieve session analytics.</para>
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
        public System.String BotId { get; set; }
        #endregion
        
        #region Parameter EndDateTime
        /// <summary>
        /// <para>
        /// <para>The date and time that marks the end of the range of time for which you want to see
        /// session analytics.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? EndDateTime { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>A list of objects, each of which describes a condition by which you want to filter
        /// the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.LexModelsV2.Model.AnalyticsSessionFilter[] Filter { get; set; }
        #endregion
        
        #region Parameter SortBy_Name
        /// <summary>
        /// <para>
        /// <para>The measure by which to sort the session analytics data.</para><ul><li><para><c>conversationStartTime</c> – The date and time when the conversation began. A conversation
        /// is defined as a unique combination of a <c>sessionId</c> and an <c>originatingRequestId</c>.</para></li><li><para><c>numberOfTurns</c> – The number of turns that the session took.</para></li><li><para><c>conversationDurationSeconds</c> – The duration of the conversation in seconds.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LexModelsV2.AnalyticsSessionSortByName")]
        public Amazon.LexModelsV2.AnalyticsSessionSortByName SortBy_Name { get; set; }
        #endregion
        
        #region Parameter SortBy_Order
        /// <summary>
        /// <para>
        /// <para>Specifies whether to sort the results in ascending or descending order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LexModelsV2.AnalyticsSortOrder")]
        public Amazon.LexModelsV2.AnalyticsSortOrder SortBy_Order { get; set; }
        #endregion
        
        #region Parameter StartDateTime
        /// <summary>
        /// <para>
        /// <para>The date and time that marks the beginning of the range of time for which you want
        /// to see session analytics.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? StartDateTime { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in each page of results. If there are fewer
        /// results than the maximum page size, only the actual number of results are returned.</para>
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
        /// <para>If the response from the ListSessionAnalyticsData operation contains more results
        /// than specified in the maxResults parameter, a token is returned in the response.</para><para>Use the returned token in the nextToken parameter of a ListSessionAnalyticsData request
        /// to return the next page of results. For a complete set of results, call the ListSessionAnalyticsData
        /// operation until the nextToken returned in the response is null.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LexModelsV2.Model.ListSessionAnalyticsDataResponse).
        /// Specifying the name of a property of type Amazon.LexModelsV2.Model.ListSessionAnalyticsDataResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.LexModelsV2.Model.ListSessionAnalyticsDataResponse, GetLMBV2SessionAnalyticsDataListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BotId = this.BotId;
            #if MODULAR
            if (this.BotId == null && ParameterWasBound(nameof(this.BotId)))
            {
                WriteWarning("You are passing $null as a value for parameter BotId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EndDateTime = this.EndDateTime;
            #if MODULAR
            if (this.EndDateTime == null && ParameterWasBound(nameof(this.EndDateTime)))
            {
                WriteWarning("You are passing $null as a value for parameter EndDateTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.LexModelsV2.Model.AnalyticsSessionFilter>(this.Filter);
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
            context.SortBy_Name = this.SortBy_Name;
            context.SortBy_Order = this.SortBy_Order;
            context.StartDateTime = this.StartDateTime;
            #if MODULAR
            if (this.StartDateTime == null && ParameterWasBound(nameof(this.StartDateTime)))
            {
                WriteWarning("You are passing $null as a value for parameter StartDateTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.LexModelsV2.Model.ListSessionAnalyticsDataRequest();
            
            if (cmdletContext.BotId != null)
            {
                request.BotId = cmdletContext.BotId;
            }
            if (cmdletContext.EndDateTime != null)
            {
                request.EndDateTime = cmdletContext.EndDateTime.Value;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            
             // populate SortBy
            var requestSortByIsNull = true;
            request.SortBy = new Amazon.LexModelsV2.Model.SessionDataSortBy();
            Amazon.LexModelsV2.AnalyticsSessionSortByName requestSortBy_sortBy_Name = null;
            if (cmdletContext.SortBy_Name != null)
            {
                requestSortBy_sortBy_Name = cmdletContext.SortBy_Name;
            }
            if (requestSortBy_sortBy_Name != null)
            {
                request.SortBy.Name = requestSortBy_sortBy_Name;
                requestSortByIsNull = false;
            }
            Amazon.LexModelsV2.AnalyticsSortOrder requestSortBy_sortBy_Order = null;
            if (cmdletContext.SortBy_Order != null)
            {
                requestSortBy_sortBy_Order = cmdletContext.SortBy_Order;
            }
            if (requestSortBy_sortBy_Order != null)
            {
                request.SortBy.Order = requestSortBy_sortBy_Order;
                requestSortByIsNull = false;
            }
             // determine if request.SortBy should be set to null
            if (requestSortByIsNull)
            {
                request.SortBy = null;
            }
            if (cmdletContext.StartDateTime != null)
            {
                request.StartDateTime = cmdletContext.StartDateTime.Value;
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
        
        private Amazon.LexModelsV2.Model.ListSessionAnalyticsDataResponse CallAWSServiceOperation(IAmazonLexModelsV2 client, Amazon.LexModelsV2.Model.ListSessionAnalyticsDataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex Model Building V2", "ListSessionAnalyticsData");
            try
            {
                return client.ListSessionAnalyticsDataAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String BotId { get; set; }
            public System.DateTime? EndDateTime { get; set; }
            public List<Amazon.LexModelsV2.Model.AnalyticsSessionFilter> Filter { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.LexModelsV2.AnalyticsSessionSortByName SortBy_Name { get; set; }
            public Amazon.LexModelsV2.AnalyticsSortOrder SortBy_Order { get; set; }
            public System.DateTime? StartDateTime { get; set; }
            public System.Func<Amazon.LexModelsV2.Model.ListSessionAnalyticsDataResponse, GetLMBV2SessionAnalyticsDataListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
