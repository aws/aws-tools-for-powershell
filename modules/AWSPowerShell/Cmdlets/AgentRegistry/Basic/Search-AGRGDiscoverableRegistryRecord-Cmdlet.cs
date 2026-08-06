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
        /// operators <c>$and</c> and <c>$or</c> on filterable fields.</para>
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
        /// <para> The natural language query to search for matching registry records.</para>
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
        /// <para> The maximum number of results to return. Valid values are 1 through 20. The default
        /// value is 10.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
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
            var request = new Amazon.AgentRegistry.Model.SearchDiscoverableRegistryRecordsRequest();
            
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
            public System.Int32? MaxResult { get; set; }
            public List<System.String> RegistryId { get; set; }
            public System.String SearchQuery { get; set; }
            public System.Func<Amazon.AgentRegistry.Model.SearchDiscoverableRegistryRecordsResponse, SearchAGRGDiscoverableRegistryRecordCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RegistryRecords;
        }
        
    }
}
