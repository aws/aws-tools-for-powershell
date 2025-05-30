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
using Amazon.LexModelsV2;
using Amazon.LexModelsV2.Model;

namespace Amazon.PowerShell.Cmdlets.LMBV2
{
    /// <summary>
    /// Retrieves summary metrics for the intents in your bot. The following fields are required:
    /// 
    ///  <ul><li><para><c>metrics</c> – A list of <a href="https://docs.aws.amazon.com/lexv2/latest/APIReference/API_AnalyticsIntentMetric.html">AnalyticsIntentMetric</a>
    /// objects. In each object, use the <c>name</c> field to specify the metric to calculate,
    /// the <c>statistic</c> field to specify whether to calculate the <c>Sum</c>, <c>Average</c>,
    /// or <c>Max</c> number, and the <c>order</c> field to specify whether to sort the results
    /// in <c>Ascending</c> or <c>Descending</c> order.
    /// </para></li><li><para><c>startDateTime</c> and <c>endDateTime</c> – Define a time range for which you want
    /// to retrieve results.
    /// </para></li></ul><para>
    /// Of the optional fields, you can organize the results in the following ways:
    /// </para><ul><li><para>
    /// Use the <c>filters</c> field to filter the results, the <c>groupBy</c> field to specify
    /// categories by which to group the results, and the <c>binBy</c> field to specify time
    /// intervals by which to group the results.
    /// </para></li><li><para>
    /// Use the <c>maxResults</c> field to limit the number of results to return in a single
    /// response and the <c>nextToken</c> field to return the next batch of results if the
    /// response does not return the full set of results.
    /// </para></li></ul><para>
    /// Note that an <c>order</c> field exists in both <c>binBy</c> and <c>metrics</c>. You
    /// can specify only one <c>order</c> in a given request.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "LMBV2IntentMetricList")]
    [OutputType("Amazon.LexModelsV2.Model.ListIntentMetricsResponse")]
    [AWSCmdlet("Calls the Amazon Lex Model Building V2 ListIntentMetrics API operation.", Operation = new[] {"ListIntentMetrics"}, SelectReturnType = typeof(Amazon.LexModelsV2.Model.ListIntentMetricsResponse))]
    [AWSCmdletOutput("Amazon.LexModelsV2.Model.ListIntentMetricsResponse",
        "This cmdlet returns an Amazon.LexModelsV2.Model.ListIntentMetricsResponse object containing multiple properties."
    )]
    public partial class GetLMBV2IntentMetricListCmdlet : AmazonLexModelsV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BinBy
        /// <summary>
        /// <para>
        /// <para>A list of objects, each of which contains specifications for organizing the results
        /// by time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.LexModelsV2.Model.AnalyticsBinBySpecification[] BinBy { get; set; }
        #endregion
        
        #region Parameter BotId
        /// <summary>
        /// <para>
        /// <para>The identifier for the bot for which you want to retrieve intent metrics.</para>
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
        /// intent metrics.</para>
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
        public Amazon.LexModelsV2.Model.AnalyticsIntentFilter[] Filter { get; set; }
        #endregion
        
        #region Parameter GroupBy
        /// <summary>
        /// <para>
        /// <para>A list of objects, each of which specifies how to group the results. You can group
        /// by the following criteria:</para><ul><li><para><c>IntentName</c> – The name of the intent.</para></li><li><para><c>IntentEndState</c> – The final state of the intent. The possible end states are
        /// detailed in <a href="https://docs.aws.amazon.com/analytics-key-definitions-intents">Key
        /// definitions</a> in the user guide.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.LexModelsV2.Model.AnalyticsIntentGroupBySpecification[] GroupBy { get; set; }
        #endregion
        
        #region Parameter Metric
        /// <summary>
        /// <para>
        /// <para>A list of objects, each of which contains a metric you want to list, the statistic
        /// for the metric you want to return, and the order by which to organize the results.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Metrics")]
        public Amazon.LexModelsV2.Model.AnalyticsIntentMetric[] Metric { get; set; }
        #endregion
        
        #region Parameter StartDateTime
        /// <summary>
        /// <para>
        /// <para>The timestamp that marks the beginning of the range of time for which you want to
        /// see intent metrics.</para>
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
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the response from the ListIntentMetrics operation contains more results than specified
        /// in the maxResults parameter, a token is returned in the response.</para><para>Use the returned token in the nextToken parameter of a ListIntentMetrics request to
        /// return the next page of results. For a complete set of results, call the ListIntentMetrics
        /// operation until the nextToken returned in the response is null.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LexModelsV2.Model.ListIntentMetricsResponse).
        /// Specifying the name of a property of type Amazon.LexModelsV2.Model.ListIntentMetricsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BotId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BotId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BotId' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.LexModelsV2.Model.ListIntentMetricsResponse, GetLMBV2IntentMetricListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BotId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.BinBy != null)
            {
                context.BinBy = new List<Amazon.LexModelsV2.Model.AnalyticsBinBySpecification>(this.BinBy);
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
                context.Filter = new List<Amazon.LexModelsV2.Model.AnalyticsIntentFilter>(this.Filter);
            }
            if (this.GroupBy != null)
            {
                context.GroupBy = new List<Amazon.LexModelsV2.Model.AnalyticsIntentGroupBySpecification>(this.GroupBy);
            }
            context.MaxResult = this.MaxResult;
            if (this.Metric != null)
            {
                context.Metric = new List<Amazon.LexModelsV2.Model.AnalyticsIntentMetric>(this.Metric);
            }
            #if MODULAR
            if (this.Metric == null && ParameterWasBound(nameof(this.Metric)))
            {
                WriteWarning("You are passing $null as a value for parameter Metric which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NextToken = this.NextToken;
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
            // create request
            var request = new Amazon.LexModelsV2.Model.ListIntentMetricsRequest();
            
            if (cmdletContext.BinBy != null)
            {
                request.BinBy = cmdletContext.BinBy;
            }
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
            if (cmdletContext.GroupBy != null)
            {
                request.GroupBy = cmdletContext.GroupBy;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.Metric != null)
            {
                request.Metrics = cmdletContext.Metric;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.StartDateTime != null)
            {
                request.StartDateTime = cmdletContext.StartDateTime.Value;
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
        
        private Amazon.LexModelsV2.Model.ListIntentMetricsResponse CallAWSServiceOperation(IAmazonLexModelsV2 client, Amazon.LexModelsV2.Model.ListIntentMetricsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex Model Building V2", "ListIntentMetrics");
            try
            {
                #if DESKTOP
                return client.ListIntentMetrics(request);
                #elif CORECLR
                return client.ListIntentMetricsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.LexModelsV2.Model.AnalyticsBinBySpecification> BinBy { get; set; }
            public System.String BotId { get; set; }
            public System.DateTime? EndDateTime { get; set; }
            public List<Amazon.LexModelsV2.Model.AnalyticsIntentFilter> Filter { get; set; }
            public List<Amazon.LexModelsV2.Model.AnalyticsIntentGroupBySpecification> GroupBy { get; set; }
            public System.Int32? MaxResult { get; set; }
            public List<Amazon.LexModelsV2.Model.AnalyticsIntentMetric> Metric { get; set; }
            public System.String NextToken { get; set; }
            public System.DateTime? StartDateTime { get; set; }
            public System.Func<Amazon.LexModelsV2.Model.ListIntentMetricsResponse, GetLMBV2IntentMetricListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
