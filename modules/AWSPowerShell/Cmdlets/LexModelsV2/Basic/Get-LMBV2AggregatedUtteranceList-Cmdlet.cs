/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Provides a list of utterances that users have sent to the bot.
    /// 
    ///  
    /// <para>
    /// Utterances are aggregated by the text of the utterance. For example, all instances
    /// where customers used the phrase "I want to order pizza" are aggregated into the same
    /// line in the response.
    /// </para><para>
    /// You can see both detected utterances and missed utterances. A detected utterance is
    /// where the bot properly recognized the utterance and activated the associated intent.
    /// A missed utterance was not recognized by the bot and didn't activate an intent.
    /// </para><para>
    /// Utterances can be aggregated for a bot alias or for a bot version, but not both at
    /// the same time.
    /// </para><para>
    /// Utterances statistics are not generated under the following conditions:
    /// </para><ul><li><para>
    /// The <c>childDirected</c> field was set to true when the bot was created.
    /// </para></li><li><para>
    /// You are using slot obfuscation with one or more slots.
    /// </para></li><li><para>
    /// You opted out of participating in improving Amazon Lex.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Get", "LMBV2AggregatedUtteranceList")]
    [OutputType("Amazon.LexModelsV2.Model.ListAggregatedUtterancesResponse")]
    [AWSCmdlet("Calls the Amazon Lex Model Building V2 ListAggregatedUtterances API operation.", Operation = new[] {"ListAggregatedUtterances"}, SelectReturnType = typeof(Amazon.LexModelsV2.Model.ListAggregatedUtterancesResponse))]
    [AWSCmdletOutput("Amazon.LexModelsV2.Model.ListAggregatedUtterancesResponse",
        "This cmdlet returns an Amazon.LexModelsV2.Model.ListAggregatedUtterancesResponse object containing multiple properties."
    )]
    public partial class GetLMBV2AggregatedUtteranceListCmdlet : AmazonLexModelsV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SortBy_Attribute
        /// <summary>
        /// <para>
        /// <para>The utterance attribute to sort by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LexModelsV2.AggregatedUtterancesSortAttribute")]
        public Amazon.LexModelsV2.AggregatedUtterancesSortAttribute SortBy_Attribute { get; set; }
        #endregion
        
        #region Parameter BotAliasId
        /// <summary>
        /// <para>
        /// <para>The identifier of the bot alias associated with this request. If you specify the bot
        /// alias, you can't specify the bot version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BotAliasId { get; set; }
        #endregion
        
        #region Parameter BotId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the bot associated with this request.</para>
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
        
        #region Parameter BotVersion
        /// <summary>
        /// <para>
        /// <para>The identifier of the bot version associated with this request. If you specify the
        /// bot version, you can't specify the bot alias.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BotVersion { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>Provides the specification of a filter used to limit the utterances in the response
        /// to only those that match the filter specification. You can only specify one filter
        /// and one string to filter on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.LexModelsV2.Model.AggregatedUtterancesFilter[] Filter { get; set; }
        #endregion
        
        #region Parameter LocaleId
        /// <summary>
        /// <para>
        /// <para>The identifier of the language and locale where the utterances were collected. For
        /// more information, see <a href="https://docs.aws.amazon.com/lexv2/latest/dg/how-languages.html">Supported
        /// languages</a>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String LocaleId { get; set; }
        #endregion
        
        #region Parameter SortBy_Order
        /// <summary>
        /// <para>
        /// <para>Specifies whether to sort the aggregated utterances in ascending or descending order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LexModelsV2.SortOrder")]
        public Amazon.LexModelsV2.SortOrder SortBy_Order { get; set; }
        #endregion
        
        #region Parameter RelativeAggregationDuration_TimeDimension
        /// <summary>
        /// <para>
        /// <para>The type of time period that the <c>timeValue</c> field represents. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("AggregationDuration_RelativeAggregationDuration_TimeDimension")]
        [AWSConstantClassSource("Amazon.LexModelsV2.TimeDimension")]
        public Amazon.LexModelsV2.TimeDimension RelativeAggregationDuration_TimeDimension { get; set; }
        #endregion
        
        #region Parameter RelativeAggregationDuration_TimeValue
        /// <summary>
        /// <para>
        /// <para>The period of the time window to gather statistics for. The valid value depends on
        /// the setting of the <c>timeDimension</c> field.</para><ul><li><para><c>Hours</c> - 1/3/6/12/24</para></li><li><para><c>Days</c> - 3</para></li><li><para><c>Weeks</c> - 1/2</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("AggregationDuration_RelativeAggregationDuration_TimeValue")]
        public System.Int32? RelativeAggregationDuration_TimeValue { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of utterances to return in each page of results. If there are fewer
        /// results than the maximum page size, only the actual number of results are returned.
        /// If you don't specify the <c>maxResults</c> parameter, 1,000 results are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the response from the <c>ListAggregatedUtterances</c> operation contains more results
        /// that specified in the <c>maxResults</c> parameter, a token is returned in the response.
        /// Use that token in the <c>nextToken</c> parameter to return the next page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LexModelsV2.Model.ListAggregatedUtterancesResponse).
        /// Specifying the name of a property of type Amazon.LexModelsV2.Model.ListAggregatedUtterancesResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.LexModelsV2.Model.ListAggregatedUtterancesResponse, GetLMBV2AggregatedUtteranceListCmdlet>(Select) ??
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
            context.RelativeAggregationDuration_TimeDimension = this.RelativeAggregationDuration_TimeDimension;
            #if MODULAR
            if (this.RelativeAggregationDuration_TimeDimension == null && ParameterWasBound(nameof(this.RelativeAggregationDuration_TimeDimension)))
            {
                WriteWarning("You are passing $null as a value for parameter RelativeAggregationDuration_TimeDimension which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RelativeAggregationDuration_TimeValue = this.RelativeAggregationDuration_TimeValue;
            #if MODULAR
            if (this.RelativeAggregationDuration_TimeValue == null && ParameterWasBound(nameof(this.RelativeAggregationDuration_TimeValue)))
            {
                WriteWarning("You are passing $null as a value for parameter RelativeAggregationDuration_TimeValue which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BotAliasId = this.BotAliasId;
            context.BotId = this.BotId;
            #if MODULAR
            if (this.BotId == null && ParameterWasBound(nameof(this.BotId)))
            {
                WriteWarning("You are passing $null as a value for parameter BotId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BotVersion = this.BotVersion;
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.LexModelsV2.Model.AggregatedUtterancesFilter>(this.Filter);
            }
            context.LocaleId = this.LocaleId;
            #if MODULAR
            if (this.LocaleId == null && ParameterWasBound(nameof(this.LocaleId)))
            {
                WriteWarning("You are passing $null as a value for parameter LocaleId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.SortBy_Attribute = this.SortBy_Attribute;
            context.SortBy_Order = this.SortBy_Order;
            
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
            var request = new Amazon.LexModelsV2.Model.ListAggregatedUtterancesRequest();
            
            
             // populate AggregationDuration
            var requestAggregationDurationIsNull = true;
            request.AggregationDuration = new Amazon.LexModelsV2.Model.UtteranceAggregationDuration();
            Amazon.LexModelsV2.Model.RelativeAggregationDuration requestAggregationDuration_aggregationDuration_RelativeAggregationDuration = null;
            
             // populate RelativeAggregationDuration
            var requestAggregationDuration_aggregationDuration_RelativeAggregationDurationIsNull = true;
            requestAggregationDuration_aggregationDuration_RelativeAggregationDuration = new Amazon.LexModelsV2.Model.RelativeAggregationDuration();
            Amazon.LexModelsV2.TimeDimension requestAggregationDuration_aggregationDuration_RelativeAggregationDuration_relativeAggregationDuration_TimeDimension = null;
            if (cmdletContext.RelativeAggregationDuration_TimeDimension != null)
            {
                requestAggregationDuration_aggregationDuration_RelativeAggregationDuration_relativeAggregationDuration_TimeDimension = cmdletContext.RelativeAggregationDuration_TimeDimension;
            }
            if (requestAggregationDuration_aggregationDuration_RelativeAggregationDuration_relativeAggregationDuration_TimeDimension != null)
            {
                requestAggregationDuration_aggregationDuration_RelativeAggregationDuration.TimeDimension = requestAggregationDuration_aggregationDuration_RelativeAggregationDuration_relativeAggregationDuration_TimeDimension;
                requestAggregationDuration_aggregationDuration_RelativeAggregationDurationIsNull = false;
            }
            System.Int32? requestAggregationDuration_aggregationDuration_RelativeAggregationDuration_relativeAggregationDuration_TimeValue = null;
            if (cmdletContext.RelativeAggregationDuration_TimeValue != null)
            {
                requestAggregationDuration_aggregationDuration_RelativeAggregationDuration_relativeAggregationDuration_TimeValue = cmdletContext.RelativeAggregationDuration_TimeValue.Value;
            }
            if (requestAggregationDuration_aggregationDuration_RelativeAggregationDuration_relativeAggregationDuration_TimeValue != null)
            {
                requestAggregationDuration_aggregationDuration_RelativeAggregationDuration.TimeValue = requestAggregationDuration_aggregationDuration_RelativeAggregationDuration_relativeAggregationDuration_TimeValue.Value;
                requestAggregationDuration_aggregationDuration_RelativeAggregationDurationIsNull = false;
            }
             // determine if requestAggregationDuration_aggregationDuration_RelativeAggregationDuration should be set to null
            if (requestAggregationDuration_aggregationDuration_RelativeAggregationDurationIsNull)
            {
                requestAggregationDuration_aggregationDuration_RelativeAggregationDuration = null;
            }
            if (requestAggregationDuration_aggregationDuration_RelativeAggregationDuration != null)
            {
                request.AggregationDuration.RelativeAggregationDuration = requestAggregationDuration_aggregationDuration_RelativeAggregationDuration;
                requestAggregationDurationIsNull = false;
            }
             // determine if request.AggregationDuration should be set to null
            if (requestAggregationDurationIsNull)
            {
                request.AggregationDuration = null;
            }
            if (cmdletContext.BotAliasId != null)
            {
                request.BotAliasId = cmdletContext.BotAliasId;
            }
            if (cmdletContext.BotId != null)
            {
                request.BotId = cmdletContext.BotId;
            }
            if (cmdletContext.BotVersion != null)
            {
                request.BotVersion = cmdletContext.BotVersion;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.LocaleId != null)
            {
                request.LocaleId = cmdletContext.LocaleId;
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
            request.SortBy = new Amazon.LexModelsV2.Model.AggregatedUtterancesSortBy();
            Amazon.LexModelsV2.AggregatedUtterancesSortAttribute requestSortBy_sortBy_Attribute = null;
            if (cmdletContext.SortBy_Attribute != null)
            {
                requestSortBy_sortBy_Attribute = cmdletContext.SortBy_Attribute;
            }
            if (requestSortBy_sortBy_Attribute != null)
            {
                request.SortBy.Attribute = requestSortBy_sortBy_Attribute;
                requestSortByIsNull = false;
            }
            Amazon.LexModelsV2.SortOrder requestSortBy_sortBy_Order = null;
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
        
        private Amazon.LexModelsV2.Model.ListAggregatedUtterancesResponse CallAWSServiceOperation(IAmazonLexModelsV2 client, Amazon.LexModelsV2.Model.ListAggregatedUtterancesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex Model Building V2", "ListAggregatedUtterances");
            try
            {
                #if DESKTOP
                return client.ListAggregatedUtterances(request);
                #elif CORECLR
                return client.ListAggregatedUtterancesAsync(request).GetAwaiter().GetResult();
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
            public Amazon.LexModelsV2.TimeDimension RelativeAggregationDuration_TimeDimension { get; set; }
            public System.Int32? RelativeAggregationDuration_TimeValue { get; set; }
            public System.String BotAliasId { get; set; }
            public System.String BotId { get; set; }
            public System.String BotVersion { get; set; }
            public List<Amazon.LexModelsV2.Model.AggregatedUtterancesFilter> Filter { get; set; }
            public System.String LocaleId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.LexModelsV2.AggregatedUtterancesSortAttribute SortBy_Attribute { get; set; }
            public Amazon.LexModelsV2.SortOrder SortBy_Order { get; set; }
            public System.Func<Amazon.LexModelsV2.Model.ListAggregatedUtterancesResponse, GetLMBV2AggregatedUtteranceListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
