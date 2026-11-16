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
using Amazon.OpenSearchMemory;
using Amazon.OpenSearchMemory.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.OSM
{
    /// <summary>
    /// Searches a space's memories by relevance. The query is a subset of the OpenSearch
    /// Query DSL. The service validates it, limits the search to the requested strategies
    /// and to the actor in <c>actorId</c>, and returns one ranked list of memories. You can
    /// page through only a limited number of results. A request past that limit fails with
    /// <c>ValidationException</c> (reason <c>invalidNextToken</c>), and the message gives
    /// the limit.
    /// 
    ///  
    /// <para>
    /// Memories past their expiry (set from the space's <c>memoryExpiryDays</c> when each
    /// memory is written) are left out of the results. Only current memories are returned:
    /// a memory that consolidation has superseded (an older version of a fact that a newer
    /// memory replaced) is left out.
    /// </para><para>
    /// If the results are larger than 5 MiB, the request fails with <c>ValidationException</c>
    /// (reason <c>queryBodyTooLarge</c>). Lower <c>maxResults</c>.
    /// </para><para>
    /// If the request would exceed the service's rate for embedding requests, it fails with
    /// <c>ThrottlingException</c>. Retry with exponential backoff.
    /// </para><para>
    /// If the space uses a customer managed AWS KMS key, the call can also fail because of
    /// the key. It fails with <c>AccessDeniedException</c> if you aren't allowed to use the
    /// key, and with <c>ThrottlingException</c> if AWS KMS throttles the request. It fails
    /// with <c>ValidationException</c> if the key is disabled, pending deletion, or deleted.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Search", "OSMMemory", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.OpenSearchMemory.Model.MemorySearchSummary")]
    [AWSCmdlet("Calls the Amazon OpenSearch Memory SearchMemories API operation.", Operation = new[] {"SearchMemories"}, SelectReturnType = typeof(Amazon.OpenSearchMemory.Model.SearchMemoriesResponse))]
    [AWSCmdletOutput("Amazon.OpenSearchMemory.Model.MemorySearchSummary or Amazon.OpenSearchMemory.Model.SearchMemoriesResponse",
        "This cmdlet returns a collection of Amazon.OpenSearchMemory.Model.MemorySearchSummary objects.",
        "The service call response (type Amazon.OpenSearchMemory.Model.SearchMemoriesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SearchOSMMemoryCmdlet : AmazonOpenSearchMemoryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ActorId
        /// <summary>
        /// <para>
        /// <para>The actor whose memories to search (exact match). Required: every search covers exactly
        /// one actor, and a memory stored without an actor is never returned. This is the only
        /// way to filter by actor: a query that references <c>system_metadata.actor_id</c> fails
        /// with <c>ValidationException</c> (reason <c>nonFilterableField</c>).</para>
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
        public System.String ActorId { get; set; }
        #endregion
        
        #region Parameter MemoryStrategy
        /// <summary>
        /// <para>
        /// <para>The strategies to search, as a list of selectors. Each selector names a memory type
        /// and, optionally, specific strategy names of that type. A space can hold several strategies
        /// of the same type. A selector without <c>memoryStrategyNames</c> searches every strategy
        /// of its type, and omitting <c>memoryStrategies</c> searches every strategy in the space.
        /// A name that is not a declared strategy of that type fails with <c>ValidationException</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MemoryStrategies")]
        public Amazon.OpenSearchMemory.Model.StrategySelector[] MemoryStrategy { get; set; }
        #endregion
        
        #region Parameter Query
        /// <summary>
        /// <para>
        /// <para>The query: a subset of the OpenSearch Query DSL (see <c>SearchQuery</c>). You can't
        /// use the actor and session fields <c>system_metadata.actor_id</c> and <c>system_metadata.session_id</c>
        /// here. Use the top-level <c>actorId</c> to filter by actor. Searching memories doesn't
        /// filter by session.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Management.Automation.PSObject Query { get; set; }
        #endregion
        
        #region Parameter Sort
        /// <summary>
        /// <para>
        /// <para>The sort order (see <c>SearchSort</c>). Omit to return the most relevant memories
        /// first.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Management.Automation.PSObject Sort { get; set; }
        #endregion
        
        #region Parameter SpaceId
        /// <summary>
        /// <para>
        /// <para>The space to search. Use <c>actorId</c> to narrow the search within it.</para>
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
        public System.String SpaceId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of memories to return, from 1 to 100. The default is 20.</para>
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
        /// <para>The token for the next set of results. Use the value returned in the previous response
        /// in the next request to retrieve the next set of results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Memories'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchMemory.Model.SearchMemoriesResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchMemory.Model.SearchMemoriesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Memories";
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
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.ActorId),
                nameof(this.SpaceId)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-OSMMemory (SearchMemories)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpenSearchMemory.Model.SearchMemoriesResponse, SearchOSMMemoryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ActorId = this.ActorId;
            #if MODULAR
            if (this.ActorId == null && ParameterWasBound(nameof(this.ActorId)))
            {
                WriteWarning("You are passing $null as a value for parameter ActorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            if (this.MemoryStrategy != null)
            {
                context.MemoryStrategy = new List<Amazon.OpenSearchMemory.Model.StrategySelector>(this.MemoryStrategy);
            }
            context.NextToken = this.NextToken;
            context.Query = this.Query;
            #if MODULAR
            if (this.Query == null && ParameterWasBound(nameof(this.Query)))
            {
                WriteWarning("You are passing $null as a value for parameter Query which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Sort = this.Sort;
            context.SpaceId = this.SpaceId;
            #if MODULAR
            if (this.SpaceId == null && ParameterWasBound(nameof(this.SpaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter SpaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.OpenSearchMemory.Model.SearchMemoriesRequest();
            
            if (cmdletContext.ActorId != null)
            {
                request.ActorId = cmdletContext.ActorId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.MemoryStrategy != null)
            {
                request.MemoryStrategies = cmdletContext.MemoryStrategy;
            }
            if (cmdletContext.Query != null)
            {
                request.Query = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.Query);
            }
            if (cmdletContext.Sort != null)
            {
                request.Sort = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.Sort);
            }
            if (cmdletContext.SpaceId != null)
            {
                request.SpaceId = cmdletContext.SpaceId;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
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
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
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
        
        private Amazon.OpenSearchMemory.Model.SearchMemoriesResponse CallAWSServiceOperation(IAmazonOpenSearchMemory client, Amazon.OpenSearchMemory.Model.SearchMemoriesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon OpenSearch Memory", "SearchMemories");
            try
            {
                return client.SearchMemoriesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ActorId { get; set; }
            public int? MaxResult { get; set; }
            public List<Amazon.OpenSearchMemory.Model.StrategySelector> MemoryStrategy { get; set; }
            public System.String NextToken { get; set; }
            public System.Management.Automation.PSObject Query { get; set; }
            public System.Management.Automation.PSObject Sort { get; set; }
            public System.String SpaceId { get; set; }
            public System.Func<Amazon.OpenSearchMemory.Model.SearchMemoriesResponse, SearchOSMMemoryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Memories;
        }
        
    }
}
