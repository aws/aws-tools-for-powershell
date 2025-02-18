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
using Amazon.PersonalizeRuntime;
using Amazon.PersonalizeRuntime.Model;

namespace Amazon.PowerShell.Cmdlets.PERSR
{
    /// <summary>
    /// Re-ranks a list of recommended items for the given user. The first item in the list
    /// is deemed the most likely item to be of interest to the user.
    /// 
    ///  <note><para>
    /// The solution backing the campaign must have been created using a recipe of type PERSONALIZED_RANKING.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "PERSRPersonalizedRanking")]
    [OutputType("Amazon.PersonalizeRuntime.Model.PredictedItem")]
    [AWSCmdlet("Calls the Amazon Personalize Runtime GetPersonalizedRanking API operation.", Operation = new[] {"GetPersonalizedRanking"}, SelectReturnType = typeof(Amazon.PersonalizeRuntime.Model.GetPersonalizedRankingResponse))]
    [AWSCmdletOutput("Amazon.PersonalizeRuntime.Model.PredictedItem or Amazon.PersonalizeRuntime.Model.GetPersonalizedRankingResponse",
        "This cmdlet returns a collection of Amazon.PersonalizeRuntime.Model.PredictedItem objects.",
        "The service call response (type Amazon.PersonalizeRuntime.Model.GetPersonalizedRankingResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetPERSRPersonalizedRankingCmdlet : AmazonPersonalizeRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CampaignArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the campaign to use for generating the personalized
        /// ranking.</para>
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
        /// <para>The Amazon Resource Name (ARN) of a filter you created to include items or exclude
        /// items from recommendations for a given user. For more information, see <a href="https://docs.aws.amazon.com/personalize/latest/dg/filter.html">Filtering
        /// Recommendations</a>.</para>
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
        /// Recommendations</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterValues")]
        public System.Collections.Hashtable FilterValue { get; set; }
        #endregion
        
        #region Parameter InputList
        /// <summary>
        /// <para>
        /// <para>A list of items (by <c>itemId</c>) to rank. If an item was not included in the training
        /// dataset, the item is appended to the end of the reranked list. If you are including
        /// metadata in recommendations, the maximum is 50. Otherwise, the maximum is 500.</para>
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
        public System.String[] InputList { get; set; }
        #endregion
        
        #region Parameter MetadataColumn
        /// <summary>
        /// <para>
        /// <para>If you enabled metadata in recommendations when you created or updated the campaign,
        /// specify metadata columns from your Items dataset to include in the personalized ranking.
        /// The map key is <c>ITEMS</c> and the value is a list of column names from your Items
        /// dataset. The maximum number of columns you can provide is 10.</para><para> For information about enabling metadata for a campaign, see <a href="https://docs.aws.amazon.com/personalize/latest/dg/campaigns.html#create-campaign-return-metadata">Enabling
        /// metadata in recommendations for a campaign</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetadataColumns")]
        public System.Collections.Hashtable MetadataColumn { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>The user for which you want the campaign to provide a personalized ranking.</para>
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
        public System.String UserId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PersonalizedRanking'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PersonalizeRuntime.Model.GetPersonalizedRankingResponse).
        /// Specifying the name of a property of type Amazon.PersonalizeRuntime.Model.GetPersonalizedRankingResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PersonalizedRanking";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PersonalizeRuntime.Model.GetPersonalizedRankingResponse, GetPERSRPersonalizedRankingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CampaignArn = this.CampaignArn;
            #if MODULAR
            if (this.CampaignArn == null && ParameterWasBound(nameof(this.CampaignArn)))
            {
                WriteWarning("You are passing $null as a value for parameter CampaignArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Context != null)
            {
                context.Context = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Context.Keys)
                {
                    context.Context.Add((String)hashKey, (System.String)(this.Context[hashKey]));
                }
            }
            context.FilterArn = this.FilterArn;
            if (this.FilterValue != null)
            {
                context.FilterValue = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.FilterValue.Keys)
                {
                    context.FilterValue.Add((String)hashKey, (System.String)(this.FilterValue[hashKey]));
                }
            }
            if (this.InputList != null)
            {
                context.InputList = new List<System.String>(this.InputList);
            }
            #if MODULAR
            if (this.InputList == null && ParameterWasBound(nameof(this.InputList)))
            {
                WriteWarning("You are passing $null as a value for parameter InputList which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            context.UserId = this.UserId;
            #if MODULAR
            if (this.UserId == null && ParameterWasBound(nameof(this.UserId)))
            {
                WriteWarning("You are passing $null as a value for parameter UserId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PersonalizeRuntime.Model.GetPersonalizedRankingRequest();
            
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
            if (cmdletContext.InputList != null)
            {
                request.InputList = cmdletContext.InputList;
            }
            if (cmdletContext.MetadataColumn != null)
            {
                request.MetadataColumns = cmdletContext.MetadataColumn;
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
        
        private Amazon.PersonalizeRuntime.Model.GetPersonalizedRankingResponse CallAWSServiceOperation(IAmazonPersonalizeRuntime client, Amazon.PersonalizeRuntime.Model.GetPersonalizedRankingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Personalize Runtime", "GetPersonalizedRanking");
            try
            {
                return client.GetPersonalizedRankingAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> InputList { get; set; }
            public Dictionary<System.String, List<System.String>> MetadataColumn { get; set; }
            public System.String UserId { get; set; }
            public System.Func<Amazon.PersonalizeRuntime.Model.GetPersonalizedRankingResponse, GetPERSRPersonalizedRankingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PersonalizedRanking;
        }
        
    }
}
