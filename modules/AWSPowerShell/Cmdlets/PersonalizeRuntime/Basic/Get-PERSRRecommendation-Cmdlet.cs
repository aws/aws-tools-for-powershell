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
using Amazon.PersonalizeRuntime;
using Amazon.PersonalizeRuntime.Model;

namespace Amazon.PowerShell.Cmdlets.PERSR
{
    /// <summary>
    /// Returns a list of recommended items. For campaigns, the campaign's Amazon Resource
    /// Name (ARN) is required and the required user and item input depends on the recipe
    /// type used to create the solution backing the campaign as follows:
    /// 
    ///  <ul><li><para>
    /// USER_PERSONALIZATION - <c>userId</c> required, <c>itemId</c> not used
    /// </para></li><li><para>
    /// RELATED_ITEMS - <c>itemId</c> required, <c>userId</c> not used
    /// </para></li></ul><note><para>
    /// Campaigns that are backed by a solution created using a recipe of type PERSONALIZED_RANKING
    /// use the API.
    /// </para></note><para>
    ///  For recommenders, the recommender's ARN is required and the required item and user
    /// input depends on the use case (domain-based recipe) backing the recommender. For information
    /// on use case requirements see <a href="https://docs.aws.amazon.com/personalize/latest/dg/domain-use-cases.html">Choosing
    /// recommender use cases</a>. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "PERSRRecommendation")]
    [OutputType("Amazon.PersonalizeRuntime.Model.PredictedItem")]
    [AWSCmdlet("Calls the Amazon Personalize Runtime GetRecommendations API operation.", Operation = new[] {"GetRecommendations"}, SelectReturnType = typeof(Amazon.PersonalizeRuntime.Model.GetRecommendationsResponse))]
    [AWSCmdletOutput("Amazon.PersonalizeRuntime.Model.PredictedItem or Amazon.PersonalizeRuntime.Model.GetRecommendationsResponse",
        "This cmdlet returns a collection of Amazon.PersonalizeRuntime.Model.PredictedItem objects.",
        "The service call response (type Amazon.PersonalizeRuntime.Model.GetRecommendationsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetPERSRRecommendationCmdlet : AmazonPersonalizeRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CampaignArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the campaign to use for getting recommendations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String CampaignArn { get; set; }
        #endregion
        
        #region Parameter Context
        /// <summary>
        /// <para>
        /// <para>The contextual metadata to use when getting recommendations. Contextual metadata includes
        /// any interaction information that might be relevant when getting a user's recommendations,
        /// such as the user's current location or device type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable Context { get; set; }
        #endregion
        
        #region Parameter FilterArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the filter to apply to the returned recommendations. For more information,
        /// see <a href="https://docs.aws.amazon.com/personalize/latest/dg/filter.html">Filtering
        /// Recommendations</a>.</para><para>When using this parameter, be sure the filter resource is <c>ACTIVE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilterArn { get; set; }
        #endregion
        
        #region Parameter FilterValue
        /// <summary>
        /// <para>
        /// <para>The values to use when filtering recommendations. For each placeholder parameter in
        /// your filter expression, provide the parameter name (in matching case) as a key and
        /// the filter value(s) as the corresponding value. Separate multiple values for one parameter
        /// with a comma. </para><para>For filter expressions that use an <c>INCLUDE</c> element to include items, you must
        /// provide values for all parameters that are defined in the expression. For filters
        /// with expressions that use an <c>EXCLUDE</c> element to exclude items, you can omit
        /// the <c>filter-values</c>.In this case, Amazon Personalize doesn't use that portion
        /// of the expression to filter recommendations.</para><para>For more information, see <a href="https://docs.aws.amazon.com/personalize/latest/dg/filter.html">Filtering
        /// recommendations and user segments</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterValues")]
        public System.Collections.Hashtable FilterValue { get; set; }
        #endregion
        
        #region Parameter ItemId
        /// <summary>
        /// <para>
        /// <para>The item ID to provide recommendations for.</para><para>Required for <c>RELATED_ITEMS</c> recipe type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ItemId { get; set; }
        #endregion
        
        #region Parameter MetadataColumn
        /// <summary>
        /// <para>
        /// <para>If you enabled metadata in recommendations when you created or updated the campaign
        /// or recommender, specify the metadata columns from your Items dataset to include in
        /// item recommendations. The map key is <c>ITEMS</c> and the value is a list of column
        /// names from your Items dataset. The maximum number of columns you can provide is 10.</para><para> For information about enabling metadata for a campaign, see <a href="https://docs.aws.amazon.com/personalize/latest/dg/create-campaign-return-metadata.html">Enabling
        /// metadata in recommendations for a campaign</a>. For information about enabling metadata
        /// for a recommender, see <a href="https://docs.aws.amazon.com/personalize/latest/dg/create-recommender-return-metadata.html">Enabling
        /// metadata in recommendations for a recommender</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetadataColumns")]
        public System.Collections.Hashtable MetadataColumn { get; set; }
        #endregion
        
        #region Parameter NumResult
        /// <summary>
        /// <para>
        /// <para>The number of results to return. The default is 25. If you are including metadata
        /// in recommendations, the maximum is 50. Otherwise, the maximum is 500.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NumResults")]
        public System.Int32? NumResult { get; set; }
        #endregion
        
        #region Parameter Promotion
        /// <summary>
        /// <para>
        /// <para>The promotions to apply to the recommendation request. A promotion defines additional
        /// business rules that apply to a configurable subset of recommended items.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Promotions")]
        public Amazon.PersonalizeRuntime.Model.Promotion[] Promotion { get; set; }
        #endregion
        
        #region Parameter RecommenderArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the recommender to use to get recommendations. Provide
        /// a recommender ARN if you created a Domain dataset group with a recommender for a domain
        /// use case.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RecommenderArn { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>The user ID to provide recommendations for.</para><para>Required for <c>USER_PERSONALIZATION</c> recipe type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ItemList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PersonalizeRuntime.Model.GetRecommendationsResponse).
        /// Specifying the name of a property of type Amazon.PersonalizeRuntime.Model.GetRecommendationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ItemList";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CampaignArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CampaignArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CampaignArn' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.PersonalizeRuntime.Model.GetRecommendationsResponse, GetPERSRRecommendationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CampaignArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CampaignArn = this.CampaignArn;
            if (this.Context != null)
            {
                context.Context = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Context.Keys)
                {
                    context.Context.Add((String)hashKey, (String)(this.Context[hashKey]));
                }
            }
            context.FilterArn = this.FilterArn;
            if (this.FilterValue != null)
            {
                context.FilterValue = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.FilterValue.Keys)
                {
                    context.FilterValue.Add((String)hashKey, (String)(this.FilterValue[hashKey]));
                }
            }
            context.ItemId = this.ItemId;
            if (this.MetadataColumn != null)
            {
                context.MetadataColumn = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.MetadataColumn.Keys)
                {
                    object hashValue = this.MetadataColumn[hashKey];
                    if (hashValue == null)
                    {
                        context.MetadataColumn.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<System.String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((System.String)s);
                    }
                    context.MetadataColumn.Add((String)hashKey, valueSet);
                }
            }
            context.NumResult = this.NumResult;
            if (this.Promotion != null)
            {
                context.Promotion = new List<Amazon.PersonalizeRuntime.Model.Promotion>(this.Promotion);
            }
            context.RecommenderArn = this.RecommenderArn;
            context.UserId = this.UserId;
            
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
            var request = new Amazon.PersonalizeRuntime.Model.GetRecommendationsRequest();
            
            if (cmdletContext.CampaignArn != null)
            {
                request.CampaignArn = cmdletContext.CampaignArn;
            }
            if (cmdletContext.Context != null)
            {
                request.Context = cmdletContext.Context;
            }
            if (cmdletContext.FilterArn != null)
            {
                request.FilterArn = cmdletContext.FilterArn;
            }
            if (cmdletContext.FilterValue != null)
            {
                request.FilterValues = cmdletContext.FilterValue;
            }
            if (cmdletContext.ItemId != null)
            {
                request.ItemId = cmdletContext.ItemId;
            }
            if (cmdletContext.MetadataColumn != null)
            {
                request.MetadataColumns = cmdletContext.MetadataColumn;
            }
            if (cmdletContext.NumResult != null)
            {
                request.NumResults = cmdletContext.NumResult.Value;
            }
            if (cmdletContext.Promotion != null)
            {
                request.Promotions = cmdletContext.Promotion;
            }
            if (cmdletContext.RecommenderArn != null)
            {
                request.RecommenderArn = cmdletContext.RecommenderArn;
            }
            if (cmdletContext.UserId != null)
            {
                request.UserId = cmdletContext.UserId;
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
        
        private Amazon.PersonalizeRuntime.Model.GetRecommendationsResponse CallAWSServiceOperation(IAmazonPersonalizeRuntime client, Amazon.PersonalizeRuntime.Model.GetRecommendationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Personalize Runtime", "GetRecommendations");
            try
            {
                #if DESKTOP
                return client.GetRecommendations(request);
                #elif CORECLR
                return client.GetRecommendationsAsync(request).GetAwaiter().GetResult();
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
            public System.String CampaignArn { get; set; }
            public Dictionary<System.String, System.String> Context { get; set; }
            public System.String FilterArn { get; set; }
            public Dictionary<System.String, System.String> FilterValue { get; set; }
            public System.String ItemId { get; set; }
            public Dictionary<System.String, List<System.String>> MetadataColumn { get; set; }
            public System.Int32? NumResult { get; set; }
            public List<Amazon.PersonalizeRuntime.Model.Promotion> Promotion { get; set; }
            public System.String RecommenderArn { get; set; }
            public System.String UserId { get; set; }
            public System.Func<Amazon.PersonalizeRuntime.Model.GetRecommendationsResponse, GetPERSRRecommendationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ItemList;
        }
        
    }
}
