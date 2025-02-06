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
    /// <note><para>
    /// To use this API operation, your IAM role must have permissions to perform the <a href="https://docs.aws.amazon.com/lexv2/latest/APIReference/API_ListAggregatedUtterances.html">ListAggregatedUtterances</a>
    /// operation, which provides access to utterance-related analytics. See <a href="https://docs.aws.amazon.com/lexv2/latest/dg/monitoring-utterances.html">Viewing
    /// utterance statistics</a> for the IAM policy to apply to the IAM role.
    /// </para></note><para>
    /// Retrieves a list of metadata for individual user utterances to your bot. The following
    /// fields are required:
    /// </para><ul><li><para><c>startDateTime</c> and <c>endDateTime</c> – Define a time range for which you want
    /// to retrieve results.
    /// </para></li></ul><para>
    /// Of the optional fields, you can organize the results in the following ways:
    /// </para><ul><li><para>
    /// Use the <c>filters</c> field to filter the results and the <c>sortBy</c> field to
    /// specify the values by which to sort the results.
    /// </para></li><li><para>
    /// Use the <c>maxResults</c> field to limit the number of results to return in a single
    /// response and the <c>nextToken</c> field to return the next batch of results if the
    /// response does not return the full set of results.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Get", "LMBV2UtteranceAnalyticsDataList")]
    [OutputType("Amazon.LexModelsV2.Model.ListUtteranceAnalyticsDataResponse")]
    [AWSCmdlet("Calls the Amazon Lex Model Building V2 ListUtteranceAnalyticsData API operation.", Operation = new[] {"ListUtteranceAnalyticsData"}, SelectReturnType = typeof(Amazon.LexModelsV2.Model.ListUtteranceAnalyticsDataResponse))]
    [AWSCmdletOutput("Amazon.LexModelsV2.Model.ListUtteranceAnalyticsDataResponse",
        "This cmdlet returns an Amazon.LexModelsV2.Model.ListUtteranceAnalyticsDataResponse object containing multiple properties."
    )]
    public partial class GetLMBV2UtteranceAnalyticsDataListCmdlet : AmazonLexModelsV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BotId
        /// <summary>
        /// <para>
        /// <para>The identifier for the bot for which you want to retrieve utterance analytics.</para>
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
        /// utterance analytics.</para>
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
        public Amazon.LexModelsV2.Model.AnalyticsUtteranceFilter[] Filter { get; set; }
        #endregion
        
        #region Parameter SortBy_Name
        /// <summary>
        /// <para>
        /// <para>The measure by which to sort the utterance analytics data.</para><ul><li><para><c>Count</c> – The number of utterances.</para></li><li><para><c>UtteranceTimestamp</c> – The date and time of the utterance.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LexModelsV2.AnalyticsUtteranceSortByName")]
        public Amazon.LexModelsV2.AnalyticsUtteranceSortByName SortBy_Name { get; set; }
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
        /// to see utterance analytics.</para>
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
        /// <para>If the response from the ListUtteranceAnalyticsData operation contains more results
        /// than specified in the maxResults parameter, a token is returned in the response.</para><para>Use the returned token in the nextToken parameter of a ListUtteranceAnalyticsData
        /// request to return the next page of results. For a complete set of results, call the
        /// ListUtteranceAnalyticsData operation until the nextToken returned in the response
        /// is null.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LexModelsV2.Model.ListUtteranceAnalyticsDataResponse).
        /// Specifying the name of a property of type Amazon.LexModelsV2.Model.ListUtteranceAnalyticsDataResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LexModelsV2.Model.ListUtteranceAnalyticsDataResponse, GetLMBV2UtteranceAnalyticsDataListCmdlet>(Select) ??
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
                context.Filter = new List<Amazon.LexModelsV2.Model.AnalyticsUtteranceFilter>(this.Filter);
            }
            context.MaxResult = this.MaxResult;
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
            // create request
            var request = new Amazon.LexModelsV2.Model.ListUtteranceAnalyticsDataRequest();
            
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
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            
             // populate SortBy
            var requestSortByIsNull = true;
            request.SortBy = new Amazon.LexModelsV2.Model.UtteranceDataSortBy();
            Amazon.LexModelsV2.AnalyticsUtteranceSortByName requestSortBy_sortBy_Name = null;
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
        
        private Amazon.LexModelsV2.Model.ListUtteranceAnalyticsDataResponse CallAWSServiceOperation(IAmazonLexModelsV2 client, Amazon.LexModelsV2.Model.ListUtteranceAnalyticsDataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex Model Building V2", "ListUtteranceAnalyticsData");
            try
            {
                #if DESKTOP
                return client.ListUtteranceAnalyticsData(request);
                #elif CORECLR
                return client.ListUtteranceAnalyticsDataAsync(request).GetAwaiter().GetResult();
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
            public System.String BotId { get; set; }
            public System.DateTime? EndDateTime { get; set; }
            public List<Amazon.LexModelsV2.Model.AnalyticsUtteranceFilter> Filter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.LexModelsV2.AnalyticsUtteranceSortByName SortBy_Name { get; set; }
            public Amazon.LexModelsV2.AnalyticsSortOrder SortBy_Order { get; set; }
            public System.DateTime? StartDateTime { get; set; }
            public System.Func<Amazon.LexModelsV2.Model.ListUtteranceAnalyticsDataResponse, GetLMBV2UtteranceAnalyticsDataListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
