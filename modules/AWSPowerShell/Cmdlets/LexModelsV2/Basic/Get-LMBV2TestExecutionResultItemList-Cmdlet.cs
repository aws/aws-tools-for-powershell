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
using Amazon.LexModelsV2;
using Amazon.LexModelsV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LMBV2
{
    /// <summary>
    /// Gets a list of test execution result items.
    /// </summary>
    [Cmdlet("Get", "LMBV2TestExecutionResultItemList")]
    [OutputType("Amazon.LexModelsV2.Model.TestExecutionResultItems")]
    [AWSCmdlet("Calls the Amazon Lex Model Building V2 ListTestExecutionResultItems API operation.", Operation = new[] {"ListTestExecutionResultItems"}, SelectReturnType = typeof(Amazon.LexModelsV2.Model.ListTestExecutionResultItemsResponse))]
    [AWSCmdletOutput("Amazon.LexModelsV2.Model.TestExecutionResultItems or Amazon.LexModelsV2.Model.ListTestExecutionResultItemsResponse",
        "This cmdlet returns an Amazon.LexModelsV2.Model.TestExecutionResultItems object.",
        "The service call response (type Amazon.LexModelsV2.Model.ListTestExecutionResultItemsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetLMBV2TestExecutionResultItemListCmdlet : AmazonLexModelsV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConversationLevelTestResultsFilterBy_EndToEndResult
        /// <summary>
        /// <para>
        /// <para>The selection of matched or mismatched end-to-end status to filter test set results
        /// data at the conversation level.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResultFilterBy_ConversationLevelTestResultsFilterBy_EndToEndResult")]
        [AWSConstantClassSource("Amazon.LexModelsV2.TestResultMatchStatus")]
        public Amazon.LexModelsV2.TestResultMatchStatus ConversationLevelTestResultsFilterBy_EndToEndResult { get; set; }
        #endregion
        
        #region Parameter ResultFilterBy_ResultTypeFilter
        /// <summary>
        /// <para>
        /// <para>Specifies which results to filter. See <a href="https://docs.aws.amazon.com/lexv2/latest/dg/test-results-details-test-set.html">Test
        /// result details"&gt;Test results details</a> for details about different types of results.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.LexModelsV2.TestResultTypeFilter")]
        public Amazon.LexModelsV2.TestResultTypeFilter ResultFilterBy_ResultTypeFilter { get; set; }
        #endregion
        
        #region Parameter TestExecutionId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the test execution to list the result items.</para>
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
        public System.String TestExecutionId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of test execution result items to return in each page. If there
        /// are fewer results than the max page size, only the actual number of results are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the response from the <c>ListTestExecutionResultItems</c> operation contains more
        /// results than specified in the <c>maxResults</c> parameter, a token is returned in
        /// the response. Use that token in the <c>nextToken</c> parameter to return the next
        /// page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TestExecutionResults'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LexModelsV2.Model.ListTestExecutionResultItemsResponse).
        /// Specifying the name of a property of type Amazon.LexModelsV2.Model.ListTestExecutionResultItemsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TestExecutionResults";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LexModelsV2.Model.ListTestExecutionResultItemsResponse, GetLMBV2TestExecutionResultItemListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ConversationLevelTestResultsFilterBy_EndToEndResult = this.ConversationLevelTestResultsFilterBy_EndToEndResult;
            context.ResultFilterBy_ResultTypeFilter = this.ResultFilterBy_ResultTypeFilter;
            #if MODULAR
            if (this.ResultFilterBy_ResultTypeFilter == null && ParameterWasBound(nameof(this.ResultFilterBy_ResultTypeFilter)))
            {
                WriteWarning("You are passing $null as a value for parameter ResultFilterBy_ResultTypeFilter which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TestExecutionId = this.TestExecutionId;
            #if MODULAR
            if (this.TestExecutionId == null && ParameterWasBound(nameof(this.TestExecutionId)))
            {
                WriteWarning("You are passing $null as a value for parameter TestExecutionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LexModelsV2.Model.ListTestExecutionResultItemsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            
             // populate ResultFilterBy
            var requestResultFilterByIsNull = true;
            request.ResultFilterBy = new Amazon.LexModelsV2.Model.TestExecutionResultFilterBy();
            Amazon.LexModelsV2.TestResultTypeFilter requestResultFilterBy_resultFilterBy_ResultTypeFilter = null;
            if (cmdletContext.ResultFilterBy_ResultTypeFilter != null)
            {
                requestResultFilterBy_resultFilterBy_ResultTypeFilter = cmdletContext.ResultFilterBy_ResultTypeFilter;
            }
            if (requestResultFilterBy_resultFilterBy_ResultTypeFilter != null)
            {
                request.ResultFilterBy.ResultTypeFilter = requestResultFilterBy_resultFilterBy_ResultTypeFilter;
                requestResultFilterByIsNull = false;
            }
            Amazon.LexModelsV2.Model.ConversationLevelTestResultsFilterBy requestResultFilterBy_resultFilterBy_ConversationLevelTestResultsFilterBy = null;
            
             // populate ConversationLevelTestResultsFilterBy
            var requestResultFilterBy_resultFilterBy_ConversationLevelTestResultsFilterByIsNull = true;
            requestResultFilterBy_resultFilterBy_ConversationLevelTestResultsFilterBy = new Amazon.LexModelsV2.Model.ConversationLevelTestResultsFilterBy();
            Amazon.LexModelsV2.TestResultMatchStatus requestResultFilterBy_resultFilterBy_ConversationLevelTestResultsFilterBy_conversationLevelTestResultsFilterBy_EndToEndResult = null;
            if (cmdletContext.ConversationLevelTestResultsFilterBy_EndToEndResult != null)
            {
                requestResultFilterBy_resultFilterBy_ConversationLevelTestResultsFilterBy_conversationLevelTestResultsFilterBy_EndToEndResult = cmdletContext.ConversationLevelTestResultsFilterBy_EndToEndResult;
            }
            if (requestResultFilterBy_resultFilterBy_ConversationLevelTestResultsFilterBy_conversationLevelTestResultsFilterBy_EndToEndResult != null)
            {
                requestResultFilterBy_resultFilterBy_ConversationLevelTestResultsFilterBy.EndToEndResult = requestResultFilterBy_resultFilterBy_ConversationLevelTestResultsFilterBy_conversationLevelTestResultsFilterBy_EndToEndResult;
                requestResultFilterBy_resultFilterBy_ConversationLevelTestResultsFilterByIsNull = false;
            }
             // determine if requestResultFilterBy_resultFilterBy_ConversationLevelTestResultsFilterBy should be set to null
            if (requestResultFilterBy_resultFilterBy_ConversationLevelTestResultsFilterByIsNull)
            {
                requestResultFilterBy_resultFilterBy_ConversationLevelTestResultsFilterBy = null;
            }
            if (requestResultFilterBy_resultFilterBy_ConversationLevelTestResultsFilterBy != null)
            {
                request.ResultFilterBy.ConversationLevelTestResultsFilterBy = requestResultFilterBy_resultFilterBy_ConversationLevelTestResultsFilterBy;
                requestResultFilterByIsNull = false;
            }
             // determine if request.ResultFilterBy should be set to null
            if (requestResultFilterByIsNull)
            {
                request.ResultFilterBy = null;
            }
            if (cmdletContext.TestExecutionId != null)
            {
                request.TestExecutionId = cmdletContext.TestExecutionId;
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
        
        private Amazon.LexModelsV2.Model.ListTestExecutionResultItemsResponse CallAWSServiceOperation(IAmazonLexModelsV2 client, Amazon.LexModelsV2.Model.ListTestExecutionResultItemsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex Model Building V2", "ListTestExecutionResultItems");
            try
            {
                return client.ListTestExecutionResultItemsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String NextToken { get; set; }
            public Amazon.LexModelsV2.TestResultMatchStatus ConversationLevelTestResultsFilterBy_EndToEndResult { get; set; }
            public Amazon.LexModelsV2.TestResultTypeFilter ResultFilterBy_ResultTypeFilter { get; set; }
            public System.String TestExecutionId { get; set; }
            public System.Func<Amazon.LexModelsV2.Model.ListTestExecutionResultItemsResponse, GetLMBV2TestExecutionResultItemListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TestExecutionResults;
        }
        
    }
}
