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
using Amazon.QConnect;
using Amazon.QConnect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.QC
{
    /// <summary>
    /// <important><para>
    /// This API will be discontinued starting June 1, 2024. To receive generative responses
    /// after March 1, 2024, you will need to create a new Assistant in the Amazon Connect
    /// console and integrate the Amazon Q in Connect JavaScript library (amazon-q-connectjs)
    /// into your applications.
    /// </para></important><para>
    /// Performs a manual search against the specified assistant. To retrieve recommendations
    /// for an assistant, use <a href="https://docs.aws.amazon.com/amazon-q-connect/latest/APIReference/API_GetRecommendations.html">GetRecommendations</a>.
    /// 
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration. This cmdlet didn't autopaginate in V4, auto-pagination support was added in V5.<br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Search", "QCAssistant", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QConnect.Model.ResultData")]
    [AWSCmdlet("Calls the Amazon Q Connect QueryAssistant API operation.", Operation = new[] {"QueryAssistant"}, SelectReturnType = typeof(Amazon.QConnect.Model.QueryAssistantResponse))]
    [AWSCmdletOutput("Amazon.QConnect.Model.ResultData or Amazon.QConnect.Model.QueryAssistantResponse",
        "This cmdlet returns a collection of Amazon.QConnect.Model.ResultData objects.",
        "The service call response (type Amazon.QConnect.Model.QueryAssistantResponse) can be returned by specifying '-Select *'."
    )]
    [System.ObsoleteAttribute("QueryAssistant API will be discontinued starting June 1, 2024. To receive generative responses after March 1, 2024 you will need to create a new Assistant in the Connect console and integrate the Amazon Q in Connect JavaScript library (amazon-q-connectjs) into your applications.")]
    public partial class SearchQCAssistantCmdlet : AmazonQConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AssistantId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Q in Connect assistant. Can be either the ID or the ARN.
        /// URLs cannot contain the ARN.</para>
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
        public System.String AssistantId { get; set; }
        #endregion
        
        #region Parameter IntentInputData_IntentId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Q intent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("QueryInputData_IntentInputData_IntentId")]
        public System.String IntentInputData_IntentId { get; set; }
        #endregion
        
        #region Parameter OverrideKnowledgeBaseSearchType
        /// <summary>
        /// <para>
        /// <para>The search type to be used against the Knowledge Base for this request. The values
        /// can be <c>SEMANTIC</c> which uses vector embeddings or <c>HYBRID</c> which use vector
        /// embeddings and raw text.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QConnect.KnowledgeBaseSearchType")]
        public Amazon.QConnect.KnowledgeBaseSearchType OverrideKnowledgeBaseSearchType { get; set; }
        #endregion
        
        #region Parameter QueryCondition
        /// <summary>
        /// <para>
        /// <para>Information about how to query content.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.QConnect.Model.QueryCondition[] QueryCondition { get; set; }
        #endregion
        
        #region Parameter QueryText
        /// <summary>
        /// <para>
        /// <para>The text to search for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String QueryText { get; set; }
        #endregion
        
        #region Parameter SessionId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Q in Connect session. Can be either the ID or the ARN.
        /// URLs cannot contain the ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SessionId { get; set; }
        #endregion
        
        #region Parameter QueryTextInputData_Text
        /// <summary>
        /// <para>
        /// <para>The text to search for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("QueryInputData_QueryTextInputData_Text")]
        public System.String QueryTextInputData_Text { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return per page.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Results'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QConnect.Model.QueryAssistantResponse).
        /// Specifying the name of a property of type Amazon.QConnect.Model.QueryAssistantResponse will result in that property being returned.
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
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// This cmdlet didn't autopaginate in V4. To preserve the V4 autopagination behavior for all cmdlets, run Set-AWSAutoIterationMode -IterationMode v4.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AssistantId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-QCAssistant (QueryAssistant)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QConnect.Model.QueryAssistantResponse, SearchQCAssistantCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssistantId = this.AssistantId;
            #if MODULAR
            if (this.AssistantId == null && ParameterWasBound(nameof(this.AssistantId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssistantId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            context.NextToken = this.NextToken;
            context.OverrideKnowledgeBaseSearchType = this.OverrideKnowledgeBaseSearchType;
            if (this.QueryCondition != null)
            {
                context.QueryCondition = new List<Amazon.QConnect.Model.QueryCondition>(this.QueryCondition);
            }
            context.IntentInputData_IntentId = this.IntentInputData_IntentId;
            context.QueryTextInputData_Text = this.QueryTextInputData_Text;
            context.QueryText = this.QueryText;
            context.SessionId = this.SessionId;
            
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
            var request = new Amazon.QConnect.Model.QueryAssistantRequest();
            
            if (cmdletContext.AssistantId != null)
            {
                request.AssistantId = cmdletContext.AssistantId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.OverrideKnowledgeBaseSearchType != null)
            {
                request.OverrideKnowledgeBaseSearchType = cmdletContext.OverrideKnowledgeBaseSearchType;
            }
            if (cmdletContext.QueryCondition != null)
            {
                request.QueryCondition = cmdletContext.QueryCondition;
            }
            
             // populate QueryInputData
            var requestQueryInputDataIsNull = true;
            request.QueryInputData = new Amazon.QConnect.Model.QueryInputData();
            Amazon.QConnect.Model.IntentInputData requestQueryInputData_queryInputData_IntentInputData = null;
            
             // populate IntentInputData
            var requestQueryInputData_queryInputData_IntentInputDataIsNull = true;
            requestQueryInputData_queryInputData_IntentInputData = new Amazon.QConnect.Model.IntentInputData();
            System.String requestQueryInputData_queryInputData_IntentInputData_intentInputData_IntentId = null;
            if (cmdletContext.IntentInputData_IntentId != null)
            {
                requestQueryInputData_queryInputData_IntentInputData_intentInputData_IntentId = cmdletContext.IntentInputData_IntentId;
            }
            if (requestQueryInputData_queryInputData_IntentInputData_intentInputData_IntentId != null)
            {
                requestQueryInputData_queryInputData_IntentInputData.IntentId = requestQueryInputData_queryInputData_IntentInputData_intentInputData_IntentId;
                requestQueryInputData_queryInputData_IntentInputDataIsNull = false;
            }
             // determine if requestQueryInputData_queryInputData_IntentInputData should be set to null
            if (requestQueryInputData_queryInputData_IntentInputDataIsNull)
            {
                requestQueryInputData_queryInputData_IntentInputData = null;
            }
            if (requestQueryInputData_queryInputData_IntentInputData != null)
            {
                request.QueryInputData.IntentInputData = requestQueryInputData_queryInputData_IntentInputData;
                requestQueryInputDataIsNull = false;
            }
            Amazon.QConnect.Model.QueryTextInputData requestQueryInputData_queryInputData_QueryTextInputData = null;
            
             // populate QueryTextInputData
            var requestQueryInputData_queryInputData_QueryTextInputDataIsNull = true;
            requestQueryInputData_queryInputData_QueryTextInputData = new Amazon.QConnect.Model.QueryTextInputData();
            System.String requestQueryInputData_queryInputData_QueryTextInputData_queryTextInputData_Text = null;
            if (cmdletContext.QueryTextInputData_Text != null)
            {
                requestQueryInputData_queryInputData_QueryTextInputData_queryTextInputData_Text = cmdletContext.QueryTextInputData_Text;
            }
            if (requestQueryInputData_queryInputData_QueryTextInputData_queryTextInputData_Text != null)
            {
                requestQueryInputData_queryInputData_QueryTextInputData.Text = requestQueryInputData_queryInputData_QueryTextInputData_queryTextInputData_Text;
                requestQueryInputData_queryInputData_QueryTextInputDataIsNull = false;
            }
             // determine if requestQueryInputData_queryInputData_QueryTextInputData should be set to null
            if (requestQueryInputData_queryInputData_QueryTextInputDataIsNull)
            {
                requestQueryInputData_queryInputData_QueryTextInputData = null;
            }
            if (requestQueryInputData_queryInputData_QueryTextInputData != null)
            {
                request.QueryInputData.QueryTextInputData = requestQueryInputData_queryInputData_QueryTextInputData;
                requestQueryInputDataIsNull = false;
            }
             // determine if request.QueryInputData should be set to null
            if (requestQueryInputDataIsNull)
            {
                request.QueryInputData = null;
            }
            if (cmdletContext.QueryText != null)
            {
                request.QueryText = cmdletContext.QueryText;
            }
            if (cmdletContext.SessionId != null)
            {
                request.SessionId = cmdletContext.SessionId;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            var _shouldAutoIterate = !(SessionState.PSVariable.GetValue("AWSPowerShell_AutoIteration_Mode")?.ToString() == "v4");
            
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
                
            } while (!_userControllingPaging && _shouldAutoIterate && AutoIterationHelpers.HasValue(_nextToken));
            
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
        
        private Amazon.QConnect.Model.QueryAssistantResponse CallAWSServiceOperation(IAmazonQConnect client, Amazon.QConnect.Model.QueryAssistantRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Q Connect", "QueryAssistant");
            try
            {
                return client.QueryAssistantAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AssistantId { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.QConnect.KnowledgeBaseSearchType OverrideKnowledgeBaseSearchType { get; set; }
            public List<Amazon.QConnect.Model.QueryCondition> QueryCondition { get; set; }
            public System.String IntentInputData_IntentId { get; set; }
            public System.String QueryTextInputData_Text { get; set; }
            public System.String QueryText { get; set; }
            public System.String SessionId { get; set; }
            public System.Func<Amazon.QConnect.Model.QueryAssistantResponse, SearchQCAssistantCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Results;
        }
        
    }
}
