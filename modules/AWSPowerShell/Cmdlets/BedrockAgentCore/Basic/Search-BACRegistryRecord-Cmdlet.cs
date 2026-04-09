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
    /// Searches for registry records using semantic, lexical, or hybrid queries. Returns
    /// metadata for matching records ordered by relevance within the specified registry.
    /// </summary>
    [Cmdlet("Search", "BACRegistryRecord", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCore.Model.RegistryRecordSummary")]
    [AWSCmdlet("Calls the Amazon Bedrock AgentCore Data Plane Fronting Layer SearchRegistryRecords API operation.", Operation = new[] {"SearchRegistryRecords"}, SelectReturnType = typeof(Amazon.BedrockAgentCore.Model.SearchRegistryRecordsResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCore.Model.RegistryRecordSummary or Amazon.BedrockAgentCore.Model.SearchRegistryRecordsResponse",
        "This cmdlet returns a collection of Amazon.BedrockAgentCore.Model.RegistryRecordSummary objects.",
        "The service call response (type Amazon.BedrockAgentCore.Model.SearchRegistryRecordsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SearchBACRegistryRecordCmdlet : AmazonBedrockAgentCoreClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para> A metadata filter expression to narrow search results. Uses structured JSON operators
        /// including field-level operators (<c>$eq</c>, <c>$ne</c>, <c>$in</c>) and logical operators
        /// (<c>$and</c>, <c>$or</c>) on filterable fields (<c>name</c>, <c>descriptorType</c>,
        /// <c>version</c>). For example, to filter by descriptor type: <c>{"descriptorType":
        /// {"$eq": "MCP"}}</c>. To combine filters: <c>{"$and": [{"descriptorType": {"$eq": "MCP"}},
        /// {"name": {"$eq": "my-tool"}}]}</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public System.Management.Automation.PSObject Filter { get; set; }
        #endregion
        
        #region Parameter RegistryId
        /// <summary>
        /// <para>
        /// <para> The list of registry identifiers to search within. Currently, you can specify exactly
        /// one registry identifier. You can provide either the full Amazon Web Services Resource
        /// Name (ARN) or the 12-character alphanumeric registry ID.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
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
        /// <para> The search query to find matching registry records.</para>
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
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para> The maximum number of records to return in a single call. Valid values are 1 through
        /// 20. The default value is 10.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RegistryRecords'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCore.Model.SearchRegistryRecordsResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCore.Model.SearchRegistryRecordsResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RegistryId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-BACRegistryRecord (SearchRegistryRecords)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCore.Model.SearchRegistryRecordsResponse, SearchBACRegistryRecordCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Filter = this.Filter;
            context.MaxResult = this.MaxResult;
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
            var request = new Amazon.BedrockAgentCore.Model.SearchRegistryRecordsRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.Filter);
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.RegistryId != null)
            {
                request.RegistryIds = cmdletContext.RegistryId;
            }
            if (cmdletContext.SearchQuery != null)
            {
                request.SearchQuery = cmdletContext.SearchQuery;
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
        
        private Amazon.BedrockAgentCore.Model.SearchRegistryRecordsResponse CallAWSServiceOperation(IAmazonBedrockAgentCore client, Amazon.BedrockAgentCore.Model.SearchRegistryRecordsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock AgentCore Data Plane Fronting Layer", "SearchRegistryRecords");
            try
            {
                return client.SearchRegistryRecordsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public List<System.String> RegistryId { get; set; }
            public System.String SearchQuery { get; set; }
            public System.Func<Amazon.BedrockAgentCore.Model.SearchRegistryRecordsResponse, SearchBACRegistryRecordCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RegistryRecords;
        }
        
    }
}
