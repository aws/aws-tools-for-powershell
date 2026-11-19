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
using Amazon.AgentRegistry;
using Amazon.AgentRegistry.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AGRG
{
    /// <summary>
    /// Searches the discoverable registry records in a registry using a natural language
    /// query. Returns metadata for the matching records ordered by relevance.
    /// 
    ///  
    /// <para>
    ///  Returns at most 1000 results across all pages when <c>searchType</c> is <c>KEYWORD</c>,
    /// and at most 20 results when it is <c>HYBRID</c> or <c>SEMANTIC</c>. To retrieve more
    /// records, refine the query or filters, or use <c>ListDiscoverableRegistryRecords</c>
    /// to list every record.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Search", "AGRGDiscoverableRegistryRecord", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AgentRegistry.Model.RegistryRecordSummary")]
    [AWSCmdlet("Calls the Agent Registry SearchDiscoverableRegistryRecords API operation.", Operation = new[] {"SearchDiscoverableRegistryRecords"}, SelectReturnType = typeof(Amazon.AgentRegistry.Model.SearchDiscoverableRegistryRecordsResponse))]
    [AWSCmdletOutput("Amazon.AgentRegistry.Model.RegistryRecordSummary or Amazon.AgentRegistry.Model.SearchDiscoverableRegistryRecordsResponse",
        "This cmdlet returns a collection of Amazon.AgentRegistry.Model.RegistryRecordSummary objects.",
        "The service call response (type Amazon.AgentRegistry.Model.SearchDiscoverableRegistryRecordsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SearchAGRGDiscoverableRegistryRecordCmdlet : AmazonAgentRegistryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para> An optional structured JSON metadata filter that narrows the search results. Supports
        /// the field-level operators <c>$eq</c>, <c>$ne</c>, and <c>$in</c>, and the logical
        /// operators <c>$and</c> and <c>$or</c> on filterable fields.</para><para> Specifies additional filtering on custom metadata fields using the <c>customMetadata.{key}</c>
        /// prefix. For example, to filter by a custom metadata field: <c>{"customMetadata.environment":
        /// {"$eq": "production"}}</c>. For a Boolean field, you can also use a native JSON boolean
        /// value, for example: <c>{"customMetadata.requiresApproval": {"$eq": true}}</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public System.Management.Automation.PSObject Filter { get; set; }
        #endregion
        
        #region Parameter RegistryId
        /// <summary>
        /// <para>
        /// <para> The registry identifiers to search within. Currently, you must specify exactly one
        /// registry identifier. You can provide either the full Amazon Web Services Resource
        /// Name (ARN) or the registry ID.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("RegistryIds")]
        public System.String[] RegistryId { get; set; }
        #endregion
        
        #region Parameter SearchQuery
        /// <summary>
        /// <para>
        /// <para> The natural language query to search for matching registry records. If you specify
        /// an empty string, the operation returns the records that match the <c>filters</c>,
        /// most recently updated first, up to the result limit for the <c>searchType</c>.</para>
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
        public System.String SearchQuery { get; set; }
        #endregion
        
        #region Parameter SearchType
        /// <summary>
        /// <para>
        /// <para> Specifies how the service ranks registry records against the search query. If you
        /// omit this parameter, the service uses <c>HYBRID</c> in Amazon Web Services Regions
        /// that support semantic search and <c>KEYWORD</c> in Regions that do not. The response
        /// reports the search type that the service used. Valid values are the following:</para><ul><li><para><c>KEYWORD</c> – Ranks records by keyword match between the query terms and the record
        /// name, description, descriptors, and custom metadata text values. Available in every
        /// Amazon Web Services Region.</para></li><li><para><c>SEMANTIC</c> – Ranks records by semantic similarity to the query and returns the
        /// most similar records, up to <c>maxResults</c>, even when none of them closely matches
        /// the query.</para></li><li><para><c>HYBRID</c> – Combines keyword ranking and semantic ranking.</para></li></ul><para><c>HYBRID</c> and <c>SEMANTIC</c> are available in a limited number of Regions. If
        /// you specify either one in a Region that does not support semantic search, the request
        /// fails with a <c>ValidationException</c> that has the reason <c>UnsupportedInRegion</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AgentRegistry.SearchType")]
        public Amazon.AgentRegistry.SearchType SearchType { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para> The maximum number of results to return in one page. Valid values are 1 through 50
        /// when <c>searchType</c> is <c>KEYWORD</c>, and 1 through 20 when it is <c>HYBRID</c>
        /// or <c>SEMANTIC</c>. The default value is 10.</para>
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
        /// <para> The pagination token from a previous response. Use it to retrieve the next page of
        /// results, and send the same <c>searchQuery</c>, <c>registryIds</c>, <c>filters</c>,
        /// and <c>searchType</c> that you used for the first page. If any of them differ, the
        /// request fails with a <c>ValidationException</c>. A pagination token expires 15 minutes
        /// after the service returns the first page.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RegistryRecords'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AgentRegistry.Model.SearchDiscoverableRegistryRecordsResponse).
        /// Specifying the name of a property of type Amazon.AgentRegistry.Model.SearchDiscoverableRegistryRecordsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RegistryRecords";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RegistryId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-AGRGDiscoverableRegistryRecord (SearchDiscoverableRegistryRecords)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AgentRegistry.Model.SearchDiscoverableRegistryRecordsResponse, SearchAGRGDiscoverableRegistryRecordCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Filter = this.Filter;
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
            context.NextToken = this.NextToken;
            if (this.RegistryId != null)
            {
                context.RegistryId = new List<System.String>(this.RegistryId);
            }
            #if MODULAR
            if (this.RegistryId == null && ParameterWasBound(nameof(this.RegistryId)))
            {
                WriteWarning("You are passing $null as a value for parameter RegistryId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SearchQuery = this.SearchQuery;
            #if MODULAR
            if (this.SearchQuery == null && ParameterWasBound(nameof(this.SearchQuery)))
            {
                WriteWarning("You are passing $null as a value for parameter SearchQuery which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SearchType = this.SearchType;
            
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
            var request = new Amazon.AgentRegistry.Model.SearchDiscoverableRegistryRecordsRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.Filter);
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.RegistryId != null)
            {
                request.RegistryIds = cmdletContext.RegistryId;
            }
            if (cmdletContext.SearchQuery != null)
            {
                request.SearchQuery = cmdletContext.SearchQuery;
            }
            if (cmdletContext.SearchType != null)
            {
                request.SearchType = cmdletContext.SearchType;
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
        
        private Amazon.AgentRegistry.Model.SearchDiscoverableRegistryRecordsResponse CallAWSServiceOperation(IAmazonAgentRegistry client, Amazon.AgentRegistry.Model.SearchDiscoverableRegistryRecordsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Agent Registry", "SearchDiscoverableRegistryRecords");
            try
            {
                return client.SearchDiscoverableRegistryRecordsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Management.Automation.PSObject Filter { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> RegistryId { get; set; }
            public System.String SearchQuery { get; set; }
            public Amazon.AgentRegistry.SearchType SearchType { get; set; }
            public System.Func<Amazon.AgentRegistry.Model.SearchDiscoverableRegistryRecordsResponse, SearchAGRGDiscoverableRegistryRecordCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RegistryRecords;
        }
        
    }
}
