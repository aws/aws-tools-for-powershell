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
        "The service call response (type Amazon.PersonalizeRuntime.Model.GetPersonalizedRankingResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetPERSRPersonalizedRankingCmdlet : AmazonPersonalizeRuntimeClientCmdlet, IExecutor
    {
        
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
        /// <para>The Amazon Resource Name (ARN) of a filter you created to include or exclude items
        /// from recommendations for a given user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilterArn { get; set; }
        #endregion
        
        #region Parameter InputList
        /// <summary>
        /// <para>
        /// <para>A list of items (by <code>itemId</code>) to rank. If an item was not included in the
        /// training dataset, the item is appended to the end of the reranked list. The maximum
        /// is 500.</para>
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
                context.Select = CreateSelectDelegate<Amazon.PersonalizeRuntime.Model.GetPersonalizedRankingResponse, GetPERSRPersonalizedRankingCmdlet>(Select) ??
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
            if (cmdletContext.InputList != null)
            {
                request.InputList = cmdletContext.InputList;
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
                #if DESKTOP
                return client.GetPersonalizedRanking(request);
                #elif CORECLR
                return client.GetPersonalizedRankingAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> InputList { get; set; }
            public System.String UserId { get; set; }
            public System.Func<Amazon.PersonalizeRuntime.Model.GetPersonalizedRankingResponse, GetPERSRPersonalizedRankingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PersonalizedRanking;
        }
        
    }
}
