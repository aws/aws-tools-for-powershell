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
using Amazon.BedrockAgentCore;
using Amazon.BedrockAgentCore.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BAC
{
    /// <summary>
    /// Searches the web and returns a ranked list of results. Each result includes a text
    /// extract from the page.
    /// 
    ///  
    /// <para>
    /// You can filter the results by domain and by publication date.
    /// </para><para>
    /// To use this operation, you must have the <c>bedrock-agentcore:InvokeWebSearch</c>
    /// permission on the resource <c>arn:${Partition}:bedrock-agentcore:${Region}:aws:tool/web-search.v1</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "BACWebSearch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCore.Model.WebSearchResult")]
    [AWSCmdlet("Calls the Amazon Bedrock AgentCore Data Plane Fronting Layer InvokeWebSearch API operation.", Operation = new[] {"InvokeWebSearch"}, SelectReturnType = typeof(Amazon.BedrockAgentCore.Model.InvokeWebSearchResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCore.Model.WebSearchResult or Amazon.BedrockAgentCore.Model.InvokeWebSearchResponse",
        "This cmdlet returns a collection of Amazon.BedrockAgentCore.Model.WebSearchResult objects.",
        "The service call response (type Amazon.BedrockAgentCore.Model.InvokeWebSearchResponse) can be returned by specifying '-Select *'."
    )]
    public partial class InvokeBACWebSearchCmdlet : AmazonBedrockAgentCoreClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Filters_DomainFilter_Exclude
        /// <summary>
        /// <para>
        /// <para>The domains to never return results from.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Filters_DomainFilter_Exclude { get; set; }
        #endregion
        
        #region Parameter Filters_DomainFilter_Include
        /// <summary>
        /// <para>
        /// <para>The domains to return results from. Results from other domains are not returned.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Filters_DomainFilter_Include { get; set; }
        #endregion
        
        #region Parameter Filters_PublishedDateFilter_PublishedAfter
        /// <summary>
        /// <para>
        /// <para>The earliest publication time of the results, inclusive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filters_PublishedDateFilter_PublishedAfter { get; set; }
        #endregion
        
        #region Parameter Filters_PublishedDateFilter_PublishedBefore
        /// <summary>
        /// <para>
        /// <para>The latest publication time of the results, inclusive. A date without a time, such
        /// as one passed to the AWS CLI, means midnight UTC. To include a whole day, use the
        /// last second of that day, for example <c>2026-01-31T23:59:59Z</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filters_PublishedDateFilter_PublishedBefore { get; set; }
        #endregion
        
        #region Parameter SearchQuery
        /// <summary>
        /// <para>
        /// <para>The text to search for.</para>
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
        public System.String SearchQuery { get; set; }
        #endregion
        
        #region Parameter WebSearchId
        /// <summary>
        /// <para>
        /// <para>The identifier of the web search tool to invoke. The Amazon Web Services-managed web
        /// search tool is <c>web-search.v1</c>.</para>
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
        public System.String WebSearchId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return. Defaults to 25.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Results'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCore.Model.InvokeWebSearchResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCore.Model.InvokeWebSearchResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Results";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WebSearchId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-BACWebSearch (InvokeWebSearch)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCore.Model.InvokeWebSearchResponse, InvokeBACWebSearchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filters_DomainFilter_Exclude != null)
            {
                context.Filters_DomainFilter_Exclude = new List<System.String>(this.Filters_DomainFilter_Exclude);
            }
            if (this.Filters_DomainFilter_Include != null)
            {
                context.Filters_DomainFilter_Include = new List<System.String>(this.Filters_DomainFilter_Include);
            }
            context.Filters_PublishedDateFilter_PublishedAfter = this.Filters_PublishedDateFilter_PublishedAfter;
            context.Filters_PublishedDateFilter_PublishedBefore = this.Filters_PublishedDateFilter_PublishedBefore;
            context.MaxResult = this.MaxResult;
            context.SearchQuery = this.SearchQuery;
            #if MODULAR
            if (this.SearchQuery == null && ParameterWasBound(nameof(this.SearchQuery)))
            {
                WriteWarning("You are passing $null as a value for parameter SearchQuery which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WebSearchId = this.WebSearchId;
            #if MODULAR
            if (this.WebSearchId == null && ParameterWasBound(nameof(this.WebSearchId)))
            {
                WriteWarning("You are passing $null as a value for parameter WebSearchId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BedrockAgentCore.Model.InvokeWebSearchRequest();
            
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.BedrockAgentCore.Model.WebSearchFilters();
            Amazon.BedrockAgentCore.Model.DomainFilter requestFilters_filters_DomainFilter = null;
            
             // populate DomainFilter
            var requestFilters_filters_DomainFilterIsNull = true;
            requestFilters_filters_DomainFilter = new Amazon.BedrockAgentCore.Model.DomainFilter();
            List<System.String> requestFilters_filters_DomainFilter_filters_DomainFilter_Exclude = null;
            if (cmdletContext.Filters_DomainFilter_Exclude != null)
            {
                requestFilters_filters_DomainFilter_filters_DomainFilter_Exclude = cmdletContext.Filters_DomainFilter_Exclude;
            }
            if (requestFilters_filters_DomainFilter_filters_DomainFilter_Exclude != null)
            {
                requestFilters_filters_DomainFilter.Exclude = requestFilters_filters_DomainFilter_filters_DomainFilter_Exclude;
                requestFilters_filters_DomainFilterIsNull = false;
            }
            List<System.String> requestFilters_filters_DomainFilter_filters_DomainFilter_Include = null;
            if (cmdletContext.Filters_DomainFilter_Include != null)
            {
                requestFilters_filters_DomainFilter_filters_DomainFilter_Include = cmdletContext.Filters_DomainFilter_Include;
            }
            if (requestFilters_filters_DomainFilter_filters_DomainFilter_Include != null)
            {
                requestFilters_filters_DomainFilter.Include = requestFilters_filters_DomainFilter_filters_DomainFilter_Include;
                requestFilters_filters_DomainFilterIsNull = false;
            }
             // determine if requestFilters_filters_DomainFilter should be set to null
            if (requestFilters_filters_DomainFilterIsNull)
            {
                requestFilters_filters_DomainFilter = null;
            }
            if (requestFilters_filters_DomainFilter != null)
            {
                request.Filters.DomainFilter = requestFilters_filters_DomainFilter;
                requestFiltersIsNull = false;
            }
            Amazon.BedrockAgentCore.Model.PublishedDateFilter requestFilters_filters_PublishedDateFilter = null;
            
             // populate PublishedDateFilter
            var requestFilters_filters_PublishedDateFilterIsNull = true;
            requestFilters_filters_PublishedDateFilter = new Amazon.BedrockAgentCore.Model.PublishedDateFilter();
            System.DateTime? requestFilters_filters_PublishedDateFilter_filters_PublishedDateFilter_PublishedAfter = null;
            if (cmdletContext.Filters_PublishedDateFilter_PublishedAfter != null)
            {
                requestFilters_filters_PublishedDateFilter_filters_PublishedDateFilter_PublishedAfter = cmdletContext.Filters_PublishedDateFilter_PublishedAfter.Value;
            }
            if (requestFilters_filters_PublishedDateFilter_filters_PublishedDateFilter_PublishedAfter != null)
            {
                requestFilters_filters_PublishedDateFilter.PublishedAfter = requestFilters_filters_PublishedDateFilter_filters_PublishedDateFilter_PublishedAfter.Value;
                requestFilters_filters_PublishedDateFilterIsNull = false;
            }
            System.DateTime? requestFilters_filters_PublishedDateFilter_filters_PublishedDateFilter_PublishedBefore = null;
            if (cmdletContext.Filters_PublishedDateFilter_PublishedBefore != null)
            {
                requestFilters_filters_PublishedDateFilter_filters_PublishedDateFilter_PublishedBefore = cmdletContext.Filters_PublishedDateFilter_PublishedBefore.Value;
            }
            if (requestFilters_filters_PublishedDateFilter_filters_PublishedDateFilter_PublishedBefore != null)
            {
                requestFilters_filters_PublishedDateFilter.PublishedBefore = requestFilters_filters_PublishedDateFilter_filters_PublishedDateFilter_PublishedBefore.Value;
                requestFilters_filters_PublishedDateFilterIsNull = false;
            }
             // determine if requestFilters_filters_PublishedDateFilter should be set to null
            if (requestFilters_filters_PublishedDateFilterIsNull)
            {
                requestFilters_filters_PublishedDateFilter = null;
            }
            if (requestFilters_filters_PublishedDateFilter != null)
            {
                request.Filters.PublishedDateFilter = requestFilters_filters_PublishedDateFilter;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.SearchQuery != null)
            {
                request.SearchQuery = cmdletContext.SearchQuery;
            }
            if (cmdletContext.WebSearchId != null)
            {
                request.WebSearchId = cmdletContext.WebSearchId;
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
        
        private Amazon.BedrockAgentCore.Model.InvokeWebSearchResponse CallAWSServiceOperation(IAmazonBedrockAgentCore client, Amazon.BedrockAgentCore.Model.InvokeWebSearchRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock AgentCore Data Plane Fronting Layer", "InvokeWebSearch");
            try
            {
                return client.InvokeWebSearchAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> Filters_DomainFilter_Exclude { get; set; }
            public List<System.String> Filters_DomainFilter_Include { get; set; }
            public System.DateTime? Filters_PublishedDateFilter_PublishedAfter { get; set; }
            public System.DateTime? Filters_PublishedDateFilter_PublishedBefore { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String SearchQuery { get; set; }
            public System.String WebSearchId { get; set; }
            public System.Func<Amazon.BedrockAgentCore.Model.InvokeWebSearchResponse, InvokeBACWebSearchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Results;
        }
        
    }
}
