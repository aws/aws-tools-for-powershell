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
using Amazon.BedrockAgentCore;
using Amazon.BedrockAgentCore.Model;

namespace Amazon.PowerShell.Cmdlets.BAC
{
    /// <summary>
    /// Searches for and retrieves memory records from an AgentCore Memory resource based
    /// on specified search criteria. We recommend using pagination to ensure that the operation
    /// returns quickly and successfully.
    /// 
    ///  
    /// <para>
    /// To use this operation, you must have the <c>bedrock-agentcore:RetrieveMemoryRecords</c>
    /// permission.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Invoke", "BACMemoryRecord", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCore.Model.MemoryRecordSummary")]
    [AWSCmdlet("Calls the Amazon Bedrock AgentCore Data Plane Fronting Layer RetrieveMemoryRecords API operation.", Operation = new[] {"RetrieveMemoryRecords"}, SelectReturnType = typeof(Amazon.BedrockAgentCore.Model.RetrieveMemoryRecordsResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCore.Model.MemoryRecordSummary or Amazon.BedrockAgentCore.Model.RetrieveMemoryRecordsResponse",
        "This cmdlet returns a collection of Amazon.BedrockAgentCore.Model.MemoryRecordSummary objects.",
        "The service call response (type Amazon.BedrockAgentCore.Model.RetrieveMemoryRecordsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class InvokeBACMemoryRecordCmdlet : AmazonBedrockAgentCoreClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MemoryId
        /// <summary>
        /// <para>
        /// <para>The identifier of the AgentCore Memory resource from which to retrieve memory records.</para>
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
        public System.String MemoryId { get; set; }
        #endregion
        
        #region Parameter SearchCriteria_MemoryStrategyId
        /// <summary>
        /// <para>
        /// <para>The memory strategy identifier to filter memory records by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SearchCriteria_MemoryStrategyId { get; set; }
        #endregion
        
        #region Parameter SearchCriteria_MetadataFilter
        /// <summary>
        /// <para>
        /// <para>Filters to apply to metadata associated with a memory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchCriteria_MetadataFilters")]
        public Amazon.BedrockAgentCore.Model.MemoryMetadataFilterExpression[] SearchCriteria_MetadataFilter { get; set; }
        #endregion
        
        #region Parameter Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace to filter memory records by.</para>
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
        public System.String Namespace { get; set; }
        #endregion
        
        #region Parameter SearchCriteria_SearchQuery
        /// <summary>
        /// <para>
        /// <para>The search query to use for finding relevant memory records.</para>
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
        public System.String SearchCriteria_SearchQuery { get; set; }
        #endregion
        
        #region Parameter SearchCriteria_TopK
        /// <summary>
        /// <para>
        /// <para>The maximum number of top-scoring memory records to return. This value is used for
        /// semantic search ranking.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SearchCriteria_TopK { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in a single call. The default value is 20.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MemoryRecordSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCore.Model.RetrieveMemoryRecordsResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCore.Model.RetrieveMemoryRecordsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MemoryRecordSummaries";
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MemoryId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-BACMemoryRecord (RetrieveMemoryRecords)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCore.Model.RetrieveMemoryRecordsResponse, InvokeBACMemoryRecordCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.MemoryId = this.MemoryId;
            #if MODULAR
            if (this.MemoryId == null && ParameterWasBound(nameof(this.MemoryId)))
            {
                WriteWarning("You are passing $null as a value for parameter MemoryId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Namespace = this.Namespace;
            #if MODULAR
            if (this.Namespace == null && ParameterWasBound(nameof(this.Namespace)))
            {
                WriteWarning("You are passing $null as a value for parameter Namespace which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.SearchCriteria_MemoryStrategyId = this.SearchCriteria_MemoryStrategyId;
            if (this.SearchCriteria_MetadataFilter != null)
            {
                context.SearchCriteria_MetadataFilter = new List<Amazon.BedrockAgentCore.Model.MemoryMetadataFilterExpression>(this.SearchCriteria_MetadataFilter);
            }
            context.SearchCriteria_SearchQuery = this.SearchCriteria_SearchQuery;
            #if MODULAR
            if (this.SearchCriteria_SearchQuery == null && ParameterWasBound(nameof(this.SearchCriteria_SearchQuery)))
            {
                WriteWarning("You are passing $null as a value for parameter SearchCriteria_SearchQuery which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SearchCriteria_TopK = this.SearchCriteria_TopK;
            
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
            var request = new Amazon.BedrockAgentCore.Model.RetrieveMemoryRecordsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.MemoryId != null)
            {
                request.MemoryId = cmdletContext.MemoryId;
            }
            if (cmdletContext.Namespace != null)
            {
                request.Namespace = cmdletContext.Namespace;
            }
            
             // populate SearchCriteria
            var requestSearchCriteriaIsNull = true;
            request.SearchCriteria = new Amazon.BedrockAgentCore.Model.SearchCriteria();
            System.String requestSearchCriteria_searchCriteria_MemoryStrategyId = null;
            if (cmdletContext.SearchCriteria_MemoryStrategyId != null)
            {
                requestSearchCriteria_searchCriteria_MemoryStrategyId = cmdletContext.SearchCriteria_MemoryStrategyId;
            }
            if (requestSearchCriteria_searchCriteria_MemoryStrategyId != null)
            {
                request.SearchCriteria.MemoryStrategyId = requestSearchCriteria_searchCriteria_MemoryStrategyId;
                requestSearchCriteriaIsNull = false;
            }
            List<Amazon.BedrockAgentCore.Model.MemoryMetadataFilterExpression> requestSearchCriteria_searchCriteria_MetadataFilter = null;
            if (cmdletContext.SearchCriteria_MetadataFilter != null)
            {
                requestSearchCriteria_searchCriteria_MetadataFilter = cmdletContext.SearchCriteria_MetadataFilter;
            }
            if (requestSearchCriteria_searchCriteria_MetadataFilter != null)
            {
                request.SearchCriteria.MetadataFilters = requestSearchCriteria_searchCriteria_MetadataFilter;
                requestSearchCriteriaIsNull = false;
            }
            System.String requestSearchCriteria_searchCriteria_SearchQuery = null;
            if (cmdletContext.SearchCriteria_SearchQuery != null)
            {
                requestSearchCriteria_searchCriteria_SearchQuery = cmdletContext.SearchCriteria_SearchQuery;
            }
            if (requestSearchCriteria_searchCriteria_SearchQuery != null)
            {
                request.SearchCriteria.SearchQuery = requestSearchCriteria_searchCriteria_SearchQuery;
                requestSearchCriteriaIsNull = false;
            }
            System.Int32? requestSearchCriteria_searchCriteria_TopK = null;
            if (cmdletContext.SearchCriteria_TopK != null)
            {
                requestSearchCriteria_searchCriteria_TopK = cmdletContext.SearchCriteria_TopK.Value;
            }
            if (requestSearchCriteria_searchCriteria_TopK != null)
            {
                request.SearchCriteria.TopK = requestSearchCriteria_searchCriteria_TopK.Value;
                requestSearchCriteriaIsNull = false;
            }
             // determine if request.SearchCriteria should be set to null
            if (requestSearchCriteriaIsNull)
            {
                request.SearchCriteria = null;
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
        
        private Amazon.BedrockAgentCore.Model.RetrieveMemoryRecordsResponse CallAWSServiceOperation(IAmazonBedrockAgentCore client, Amazon.BedrockAgentCore.Model.RetrieveMemoryRecordsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock AgentCore Data Plane Fronting Layer", "RetrieveMemoryRecords");
            try
            {
                #if DESKTOP
                return client.RetrieveMemoryRecords(request);
                #elif CORECLR
                return client.RetrieveMemoryRecordsAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String MemoryId { get; set; }
            public System.String Namespace { get; set; }
            public System.String NextToken { get; set; }
            public System.String SearchCriteria_MemoryStrategyId { get; set; }
            public List<Amazon.BedrockAgentCore.Model.MemoryMetadataFilterExpression> SearchCriteria_MetadataFilter { get; set; }
            public System.String SearchCriteria_SearchQuery { get; set; }
            public System.Int32? SearchCriteria_TopK { get; set; }
            public System.Func<Amazon.BedrockAgentCore.Model.RetrieveMemoryRecordsResponse, InvokeBACMemoryRecordCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MemoryRecordSummaries;
        }
        
    }
}
