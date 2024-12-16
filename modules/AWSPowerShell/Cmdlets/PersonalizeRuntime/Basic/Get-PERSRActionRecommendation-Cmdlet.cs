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
    /// Returns a list of recommended actions in sorted in descending order by prediction
    /// score. Use the <c>GetActionRecommendations</c> API if you have a custom campaign that
    /// deploys a solution version trained with a PERSONALIZED_ACTIONS recipe. 
    /// 
    ///  
    /// <para>
    /// For more information about PERSONALIZED_ACTIONS recipes, see <a href="https://docs.aws.amazon.com/personalize/latest/dg/nexts-best-action-recipes.html">PERSONALIZED_ACTIONS
    /// recipes</a>. For more information about getting action recommendations, see <a href="https://docs.aws.amazon.com/personalize/latest/dg/get-action-recommendations.html">Getting
    /// action recommendations</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "PERSRActionRecommendation")]
    [OutputType("Amazon.PersonalizeRuntime.Model.GetActionRecommendationsResponse")]
    [AWSCmdlet("Calls the Amazon Personalize Runtime GetActionRecommendations API operation.", Operation = new[] {"GetActionRecommendations"}, SelectReturnType = typeof(Amazon.PersonalizeRuntime.Model.GetActionRecommendationsResponse))]
    [AWSCmdletOutput("Amazon.PersonalizeRuntime.Model.GetActionRecommendationsResponse",
        "This cmdlet returns an Amazon.PersonalizeRuntime.Model.GetActionRecommendationsResponse object containing multiple properties."
    )]
    public partial class GetPERSRActionRecommendationCmdlet : AmazonPersonalizeRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CampaignArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the campaign to use for getting action recommendations.
        /// This campaign must deploy a solution version trained with a PERSONALIZED_ACTIONS recipe.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String CampaignArn { get; set; }
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
        /// with a comma. </para><para>For filter expressions that use an <c>INCLUDE</c> element to include actions, you
        /// must provide values for all parameters that are defined in the expression. For filters
        /// with expressions that use an <c>EXCLUDE</c> element to exclude actions, you can omit
        /// the <c>filter-values</c>. In this case, Amazon Personalize doesn't use that portion
        /// of the expression to filter recommendations.</para><para>For more information, see <a href="https://docs.aws.amazon.com/personalize/latest/dg/filter.html">Filtering
        /// recommendations and user segments</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterValues")]
        public System.Collections.Hashtable FilterValue { get; set; }
        #endregion
        
        #region Parameter NumResult
        /// <summary>
        /// <para>
        /// <para>The number of results to return. The default is 5. The maximum is 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NumResults")]
        public System.Int32? NumResult { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>The user ID of the user to provide action recommendations for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PersonalizeRuntime.Model.GetActionRecommendationsResponse).
        /// Specifying the name of a property of type Amazon.PersonalizeRuntime.Model.GetActionRecommendationsResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.PersonalizeRuntime.Model.GetActionRecommendationsResponse, GetPERSRActionRecommendationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CampaignArn = this.CampaignArn;
            context.FilterArn = this.FilterArn;
            if (this.FilterValue != null)
            {
                context.FilterValue = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.FilterValue.Keys)
                {
                    context.FilterValue.Add((String)hashKey, (System.String)(this.FilterValue[hashKey]));
                }
            }
            context.NumResult = this.NumResult;
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
            var request = new Amazon.PersonalizeRuntime.Model.GetActionRecommendationsRequest();
            
            if (cmdletContext.CampaignArn != null)
            {
                request.CampaignArn = cmdletContext.CampaignArn;
            }
            if (cmdletContext.FilterArn != null)
            {
                request.FilterArn = cmdletContext.FilterArn;
            }
            if (cmdletContext.FilterValue != null)
            {
                request.FilterValues = cmdletContext.FilterValue;
            }
            if (cmdletContext.NumResult != null)
            {
                request.NumResults = cmdletContext.NumResult.Value;
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
        
        private Amazon.PersonalizeRuntime.Model.GetActionRecommendationsResponse CallAWSServiceOperation(IAmazonPersonalizeRuntime client, Amazon.PersonalizeRuntime.Model.GetActionRecommendationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Personalize Runtime", "GetActionRecommendations");
            try
            {
                #if DESKTOP
                return client.GetActionRecommendations(request);
                #elif CORECLR
                return client.GetActionRecommendationsAsync(request).GetAwaiter().GetResult();
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
            public System.String FilterArn { get; set; }
            public Dictionary<System.String, System.String> FilterValue { get; set; }
            public System.Int32? NumResult { get; set; }
            public System.String UserId { get; set; }
            public System.Func<Amazon.PersonalizeRuntime.Model.GetActionRecommendationsResponse, GetPERSRActionRecommendationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
