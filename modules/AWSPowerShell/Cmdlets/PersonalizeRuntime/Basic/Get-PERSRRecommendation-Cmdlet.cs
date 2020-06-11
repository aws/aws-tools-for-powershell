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
    /// Returns a list of recommended items. The required input depends on the recipe type
    /// used to create the solution backing the campaign, as follows:
    /// 
    ///  <ul><li><para>
    /// RELATED_ITEMS - <code>itemId</code> required, <code>userId</code> not used
    /// </para></li><li><para>
    /// USER_PERSONALIZATION - <code>itemId</code> optional, <code>userId</code> required
    /// </para></li></ul><note><para>
    /// Campaigns that are backed by a solution created using a recipe of type PERSONALIZED_RANKING
    /// use the API.
    /// </para></note>
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
        
        #region Parameter CampaignArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the campaign to use for getting recommendations.</para>
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
        /// <para>The ARN of the filter to apply to the returned recommendations. For more information,
        /// see <a href="https://docs.aws.amazon.com/personalize/latest/dg/filters.html">Using
        /// Filters with Amazon Personalize</a>.</para><para>When using this parameter, be sure the filter resource is <code>ACTIVE</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilterArn { get; set; }
        #endregion
        
        #region Parameter ItemId
        /// <summary>
        /// <para>
        /// <para>The item ID to provide recommendations for.</para><para>Required for <code>RELATED_ITEMS</code> recipe type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ItemId { get; set; }
        #endregion
        
        #region Parameter NumResult
        /// <summary>
        /// <para>
        /// <para>The number of results to return. The default is 25. The maximum is 500.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NumResults")]
        public System.Int32? NumResult { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>The user ID to provide recommendations for.</para><para>Required for <code>USER_PERSONALIZATION</code> recipe type.</para>
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
                    context.Context.Add((String)hashKey, (String)(this.Context[hashKey]));
                }
            }
            context.FilterArn = this.FilterArn;
            context.ItemId = this.ItemId;
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
            if (cmdletContext.ItemId != null)
            {
                request.ItemId = cmdletContext.ItemId;
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
            public System.String ItemId { get; set; }
            public System.Int32? NumResult { get; set; }
            public System.String UserId { get; set; }
            public System.Func<Amazon.PersonalizeRuntime.Model.GetRecommendationsResponse, GetPERSRRecommendationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ItemList;
        }
        
    }
}
