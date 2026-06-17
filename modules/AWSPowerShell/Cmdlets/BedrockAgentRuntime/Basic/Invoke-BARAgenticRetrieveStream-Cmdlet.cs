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
using Amazon.BedrockAgentRuntime;
using Amazon.BedrockAgentRuntime.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BAR
{
    /// <summary>
    /// Retrieves information from one or more knowledge bases using an agentic approach.
    /// Agentic retrieval uses a foundation model to intelligently decompose complex queries
    /// into sub-queries and iteratively retrieve relevant information from your knowledge
    /// bases. This approach improves retrieval accuracy for complex, multi-step questions
    /// that a single retrieval pass might not fully address.
    /// 
    ///  
    /// <para>
    /// The operation returns results through a stream that includes retrieval results, trace
    /// events for visibility into the process, and a generated response synthesized from
    /// the results by default, which can be turned off.
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "BARAgenticRetrieveStream", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentRuntime.Model.AgenticRetrieveStreamResponseOutput")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Runtime AgenticRetrieveStream API operation.", Operation = new[] {"AgenticRetrieveStream"}, SelectReturnType = typeof(Amazon.BedrockAgentRuntime.Model.AgenticRetrieveStreamResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentRuntime.Model.AgenticRetrieveStreamResponseOutput or Amazon.BedrockAgentRuntime.Model.AgenticRetrieveStreamResponse",
        "This cmdlet returns an Amazon.BedrockAgentRuntime.Model.AgenticRetrieveStreamResponseOutput object.",
        "The service call response (type Amazon.BedrockAgentRuntime.Model.AgenticRetrieveStreamResponse) can be returned by specifying '-Select *'."
    )]
    public partial class InvokeBARAgenticRetrieveStreamCmdlet : AmazonBedrockAgentRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AgenticRetrieveConfiguration_FoundationModelType
        /// <summary>
        /// <para>
        /// <para>The type of foundation model to use. CUSTOM uses a specified model, MANAGED uses the
        /// service default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentRuntime.FoundationModelType")]
        public Amazon.BedrockAgentRuntime.FoundationModelType AgenticRetrieveConfiguration_FoundationModelType { get; set; }
        #endregion
        
        #region Parameter GenerateResponse
        /// <summary>
        /// <para>
        /// <para>Whether to generate a response based on the retrieved results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? GenerateResponse { get; set; }
        #endregion
        
        #region Parameter PolicyConfiguration_BedrockGuardrailConfiguration_GuardrailId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the guardrail.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PolicyConfiguration_BedrockGuardrailConfiguration_GuardrailId { get; set; }
        #endregion
        
        #region Parameter PolicyConfiguration_BedrockGuardrailConfiguration_GuardrailVersion
        /// <summary>
        /// <para>
        /// <para>The version of the guardrail to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PolicyConfiguration_BedrockGuardrailConfiguration_GuardrailVersion { get; set; }
        #endregion
        
        #region Parameter AgenticRetrieveConfiguration_MaxAgentIteration
        /// <summary>
        /// <para>
        /// <para>The maximum number of agent iterations for retrieval.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AgenticRetrieveConfiguration_MaxAgentIteration { get; set; }
        #endregion
        
        #region Parameter Message
        /// <summary>
        /// <para>
        /// <para>The list of messages for the agentic retrieval conversation.</para><para />
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
        [Alias("Messages")]
        public Amazon.BedrockAgentRuntime.Model.AgenticRetrieveMessage[] Message { get; set; }
        #endregion
        
        #region Parameter AgenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_ModelConfiguration_ModelArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Bedrock foundation model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AgenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_ModelConfiguration_ModelArn { get; set; }
        #endregion
        
        #region Parameter AgenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration_ModelArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Bedrock reranking model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AgenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration_ModelArn { get; set; }
        #endregion
        
        #region Parameter AgenticRetrieveConfiguration_RerankingModelType
        /// <summary>
        /// <para>
        /// <para>The type of reranking model to use. CUSTOM uses a specified model, MANAGED uses the
        /// service default. If not specified, defaults to MANAGED for managed embedding knowledge
        /// bases and NONE for custom embedding knowledge bases.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentRuntime.AgenticRetrieveRerankingModelType")]
        public Amazon.BedrockAgentRuntime.AgenticRetrieveRerankingModelType AgenticRetrieveConfiguration_RerankingModelType { get; set; }
        #endregion
        
        #region Parameter Retriever
        /// <summary>
        /// <para>
        /// <para>The list of retrievers to use for agentic retrieval.</para><para />
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
        [Alias("Retrievers")]
        public Amazon.BedrockAgentRuntime.Model.AgenticRetriever[] Retriever { get; set; }
        #endregion
        
        #region Parameter AgenticRetrieveConfiguration_FoundationModelConfiguration_Type
        /// <summary>
        /// <para>
        /// <para>The type of foundation model configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentRuntime.FoundationModelConfigurationType")]
        public Amazon.BedrockAgentRuntime.FoundationModelConfigurationType AgenticRetrieveConfiguration_FoundationModelConfiguration_Type { get; set; }
        #endregion
        
        #region Parameter AgenticRetrieveConfiguration_RerankingConfiguration_Type
        /// <summary>
        /// <para>
        /// <para>The type of reranking configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentRuntime.AgenticRetrieveRerankingConfigurationType")]
        public Amazon.BedrockAgentRuntime.AgenticRetrieveRerankingConfigurationType AgenticRetrieveConfiguration_RerankingConfiguration_Type { get; set; }
        #endregion
        
        #region Parameter UserContext_UserId
        /// <summary>
        /// <para>
        /// <para>The identifier of the user making the retrieval request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserContext_UserId { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Opaque continuation token for paginated results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Stream'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentRuntime.Model.AgenticRetrieveStreamResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentRuntime.Model.AgenticRetrieveStreamResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Stream";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-BARAgenticRetrieveStream (AgenticRetrieveStream)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentRuntime.Model.AgenticRetrieveStreamResponse, InvokeBARAgenticRetrieveStreamCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AgenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_ModelConfiguration_ModelArn = this.AgenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_ModelConfiguration_ModelArn;
            context.AgenticRetrieveConfiguration_FoundationModelConfiguration_Type = this.AgenticRetrieveConfiguration_FoundationModelConfiguration_Type;
            context.AgenticRetrieveConfiguration_FoundationModelType = this.AgenticRetrieveConfiguration_FoundationModelType;
            context.AgenticRetrieveConfiguration_MaxAgentIteration = this.AgenticRetrieveConfiguration_MaxAgentIteration;
            context.AgenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration_ModelArn = this.AgenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration_ModelArn;
            context.AgenticRetrieveConfiguration_RerankingConfiguration_Type = this.AgenticRetrieveConfiguration_RerankingConfiguration_Type;
            context.AgenticRetrieveConfiguration_RerankingModelType = this.AgenticRetrieveConfiguration_RerankingModelType;
            context.GenerateResponse = this.GenerateResponse;
            if (this.Message != null)
            {
                context.Message = new List<Amazon.BedrockAgentRuntime.Model.AgenticRetrieveMessage>(this.Message);
            }
            #if MODULAR
            if (this.Message == null && ParameterWasBound(nameof(this.Message)))
            {
                WriteWarning("You are passing $null as a value for parameter Message which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.PolicyConfiguration_BedrockGuardrailConfiguration_GuardrailId = this.PolicyConfiguration_BedrockGuardrailConfiguration_GuardrailId;
            context.PolicyConfiguration_BedrockGuardrailConfiguration_GuardrailVersion = this.PolicyConfiguration_BedrockGuardrailConfiguration_GuardrailVersion;
            if (this.Retriever != null)
            {
                context.Retriever = new List<Amazon.BedrockAgentRuntime.Model.AgenticRetriever>(this.Retriever);
            }
            #if MODULAR
            if (this.Retriever == null && ParameterWasBound(nameof(this.Retriever)))
            {
                WriteWarning("You are passing $null as a value for parameter Retriever which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UserContext_UserId = this.UserContext_UserId;
            
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
            var request = new Amazon.BedrockAgentRuntime.Model.AgenticRetrieveStreamRequest();
            
            
             // populate AgenticRetrieveConfiguration
            var requestAgenticRetrieveConfigurationIsNull = true;
            request.AgenticRetrieveConfiguration = new Amazon.BedrockAgentRuntime.Model.AgenticRetrieveConfiguration();
            Amazon.BedrockAgentRuntime.FoundationModelType requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelType = null;
            if (cmdletContext.AgenticRetrieveConfiguration_FoundationModelType != null)
            {
                requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelType = cmdletContext.AgenticRetrieveConfiguration_FoundationModelType;
            }
            if (requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelType != null)
            {
                request.AgenticRetrieveConfiguration.FoundationModelType = requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelType;
                requestAgenticRetrieveConfigurationIsNull = false;
            }
            System.Int32? requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_MaxAgentIteration = null;
            if (cmdletContext.AgenticRetrieveConfiguration_MaxAgentIteration != null)
            {
                requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_MaxAgentIteration = cmdletContext.AgenticRetrieveConfiguration_MaxAgentIteration.Value;
            }
            if (requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_MaxAgentIteration != null)
            {
                request.AgenticRetrieveConfiguration.MaxAgentIteration = requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_MaxAgentIteration.Value;
                requestAgenticRetrieveConfigurationIsNull = false;
            }
            Amazon.BedrockAgentRuntime.AgenticRetrieveRerankingModelType requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingModelType = null;
            if (cmdletContext.AgenticRetrieveConfiguration_RerankingModelType != null)
            {
                requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingModelType = cmdletContext.AgenticRetrieveConfiguration_RerankingModelType;
            }
            if (requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingModelType != null)
            {
                request.AgenticRetrieveConfiguration.RerankingModelType = requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingModelType;
                requestAgenticRetrieveConfigurationIsNull = false;
            }
            Amazon.BedrockAgentRuntime.Model.FoundationModelConfiguration requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration = null;
            
             // populate FoundationModelConfiguration
            var requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfigurationIsNull = true;
            requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration = new Amazon.BedrockAgentRuntime.Model.FoundationModelConfiguration();
            Amazon.BedrockAgentRuntime.FoundationModelConfigurationType requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_Type = null;
            if (cmdletContext.AgenticRetrieveConfiguration_FoundationModelConfiguration_Type != null)
            {
                requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_Type = cmdletContext.AgenticRetrieveConfiguration_FoundationModelConfiguration_Type;
            }
            if (requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_Type != null)
            {
                requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration.Type = requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_Type;
                requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfigurationIsNull = false;
            }
            Amazon.BedrockAgentRuntime.Model.BedrockFoundationModelConfiguration requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration = null;
            
             // populate BedrockFoundationModelConfiguration
            var requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfigurationIsNull = true;
            requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration = new Amazon.BedrockAgentRuntime.Model.BedrockFoundationModelConfiguration();
            Amazon.BedrockAgentRuntime.Model.BedrockFoundationModelModelConfiguration requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_ModelConfiguration = null;
            
             // populate ModelConfiguration
            var requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_ModelConfigurationIsNull = true;
            requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_ModelConfiguration = new Amazon.BedrockAgentRuntime.Model.BedrockFoundationModelModelConfiguration();
            System.String requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_ModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_ModelConfiguration_ModelArn = null;
            if (cmdletContext.AgenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_ModelConfiguration_ModelArn != null)
            {
                requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_ModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_ModelConfiguration_ModelArn = cmdletContext.AgenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_ModelConfiguration_ModelArn;
            }
            if (requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_ModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_ModelConfiguration_ModelArn != null)
            {
                requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_ModelConfiguration.ModelArn = requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_ModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_ModelConfiguration_ModelArn;
                requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_ModelConfigurationIsNull = false;
            }
             // determine if requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_ModelConfiguration should be set to null
            if (requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_ModelConfigurationIsNull)
            {
                requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_ModelConfiguration = null;
            }
            if (requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_ModelConfiguration != null)
            {
                requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration.ModelConfiguration = requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_ModelConfiguration;
                requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfigurationIsNull = false;
            }
             // determine if requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration should be set to null
            if (requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfigurationIsNull)
            {
                requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration = null;
            }
            if (requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration != null)
            {
                requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration.BedrockFoundationModelConfiguration = requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration;
                requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfigurationIsNull = false;
            }
             // determine if requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration should be set to null
            if (requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfigurationIsNull)
            {
                requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration = null;
            }
            if (requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration != null)
            {
                request.AgenticRetrieveConfiguration.FoundationModelConfiguration = requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_FoundationModelConfiguration;
                requestAgenticRetrieveConfigurationIsNull = false;
            }
            Amazon.BedrockAgentRuntime.Model.AgenticRetrieveRerankingConfiguration requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfiguration = null;
            
             // populate RerankingConfiguration
            var requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfigurationIsNull = true;
            requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfiguration = new Amazon.BedrockAgentRuntime.Model.AgenticRetrieveRerankingConfiguration();
            Amazon.BedrockAgentRuntime.AgenticRetrieveRerankingConfigurationType requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_Type = null;
            if (cmdletContext.AgenticRetrieveConfiguration_RerankingConfiguration_Type != null)
            {
                requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_Type = cmdletContext.AgenticRetrieveConfiguration_RerankingConfiguration_Type;
            }
            if (requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_Type != null)
            {
                requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfiguration.Type = requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_Type;
                requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfigurationIsNull = false;
            }
            Amazon.BedrockAgentRuntime.Model.AgenticRetrieveBedrockRerankingConfiguration requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration = null;
            
             // populate BedrockRerankingConfiguration
            var requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfigurationIsNull = true;
            requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration = new Amazon.BedrockAgentRuntime.Model.AgenticRetrieveBedrockRerankingConfiguration();
            Amazon.BedrockAgentRuntime.Model.AgenticRetrieveBedrockRerankingModelConfiguration requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration = null;
            
             // populate ModelConfiguration
            var requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfigurationIsNull = true;
            requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration = new Amazon.BedrockAgentRuntime.Model.AgenticRetrieveBedrockRerankingModelConfiguration();
            System.String requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration_ModelArn = null;
            if (cmdletContext.AgenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration_ModelArn != null)
            {
                requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration_ModelArn = cmdletContext.AgenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration_ModelArn;
            }
            if (requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration_ModelArn != null)
            {
                requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration.ModelArn = requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration_ModelArn;
                requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfigurationIsNull = false;
            }
             // determine if requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration should be set to null
            if (requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfigurationIsNull)
            {
                requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration = null;
            }
            if (requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration != null)
            {
                requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration.ModelConfiguration = requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration;
                requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfigurationIsNull = false;
            }
             // determine if requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration should be set to null
            if (requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfigurationIsNull)
            {
                requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration = null;
            }
            if (requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration != null)
            {
                requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfiguration.BedrockRerankingConfiguration = requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_agenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration;
                requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfigurationIsNull = false;
            }
             // determine if requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfiguration should be set to null
            if (requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfigurationIsNull)
            {
                requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfiguration = null;
            }
            if (requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfiguration != null)
            {
                request.AgenticRetrieveConfiguration.RerankingConfiguration = requestAgenticRetrieveConfiguration_agenticRetrieveConfiguration_RerankingConfiguration;
                requestAgenticRetrieveConfigurationIsNull = false;
            }
             // determine if request.AgenticRetrieveConfiguration should be set to null
            if (requestAgenticRetrieveConfigurationIsNull)
            {
                request.AgenticRetrieveConfiguration = null;
            }
            if (cmdletContext.GenerateResponse != null)
            {
                request.GenerateResponse = cmdletContext.GenerateResponse.Value;
            }
            if (cmdletContext.Message != null)
            {
                request.Messages = cmdletContext.Message;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            
             // populate PolicyConfiguration
            var requestPolicyConfigurationIsNull = true;
            request.PolicyConfiguration = new Amazon.BedrockAgentRuntime.Model.AgenticRetrievePolicyConfiguration();
            Amazon.BedrockAgentRuntime.Model.AgenticRetrieveBedrockGuardrailConfiguration requestPolicyConfiguration_policyConfiguration_BedrockGuardrailConfiguration = null;
            
             // populate BedrockGuardrailConfiguration
            var requestPolicyConfiguration_policyConfiguration_BedrockGuardrailConfigurationIsNull = true;
            requestPolicyConfiguration_policyConfiguration_BedrockGuardrailConfiguration = new Amazon.BedrockAgentRuntime.Model.AgenticRetrieveBedrockGuardrailConfiguration();
            System.String requestPolicyConfiguration_policyConfiguration_BedrockGuardrailConfiguration_policyConfiguration_BedrockGuardrailConfiguration_GuardrailId = null;
            if (cmdletContext.PolicyConfiguration_BedrockGuardrailConfiguration_GuardrailId != null)
            {
                requestPolicyConfiguration_policyConfiguration_BedrockGuardrailConfiguration_policyConfiguration_BedrockGuardrailConfiguration_GuardrailId = cmdletContext.PolicyConfiguration_BedrockGuardrailConfiguration_GuardrailId;
            }
            if (requestPolicyConfiguration_policyConfiguration_BedrockGuardrailConfiguration_policyConfiguration_BedrockGuardrailConfiguration_GuardrailId != null)
            {
                requestPolicyConfiguration_policyConfiguration_BedrockGuardrailConfiguration.GuardrailId = requestPolicyConfiguration_policyConfiguration_BedrockGuardrailConfiguration_policyConfiguration_BedrockGuardrailConfiguration_GuardrailId;
                requestPolicyConfiguration_policyConfiguration_BedrockGuardrailConfigurationIsNull = false;
            }
            System.String requestPolicyConfiguration_policyConfiguration_BedrockGuardrailConfiguration_policyConfiguration_BedrockGuardrailConfiguration_GuardrailVersion = null;
            if (cmdletContext.PolicyConfiguration_BedrockGuardrailConfiguration_GuardrailVersion != null)
            {
                requestPolicyConfiguration_policyConfiguration_BedrockGuardrailConfiguration_policyConfiguration_BedrockGuardrailConfiguration_GuardrailVersion = cmdletContext.PolicyConfiguration_BedrockGuardrailConfiguration_GuardrailVersion;
            }
            if (requestPolicyConfiguration_policyConfiguration_BedrockGuardrailConfiguration_policyConfiguration_BedrockGuardrailConfiguration_GuardrailVersion != null)
            {
                requestPolicyConfiguration_policyConfiguration_BedrockGuardrailConfiguration.GuardrailVersion = requestPolicyConfiguration_policyConfiguration_BedrockGuardrailConfiguration_policyConfiguration_BedrockGuardrailConfiguration_GuardrailVersion;
                requestPolicyConfiguration_policyConfiguration_BedrockGuardrailConfigurationIsNull = false;
            }
             // determine if requestPolicyConfiguration_policyConfiguration_BedrockGuardrailConfiguration should be set to null
            if (requestPolicyConfiguration_policyConfiguration_BedrockGuardrailConfigurationIsNull)
            {
                requestPolicyConfiguration_policyConfiguration_BedrockGuardrailConfiguration = null;
            }
            if (requestPolicyConfiguration_policyConfiguration_BedrockGuardrailConfiguration != null)
            {
                request.PolicyConfiguration.BedrockGuardrailConfiguration = requestPolicyConfiguration_policyConfiguration_BedrockGuardrailConfiguration;
                requestPolicyConfigurationIsNull = false;
            }
             // determine if request.PolicyConfiguration should be set to null
            if (requestPolicyConfigurationIsNull)
            {
                request.PolicyConfiguration = null;
            }
            if (cmdletContext.Retriever != null)
            {
                request.Retrievers = cmdletContext.Retriever;
            }
            
             // populate UserContext
            var requestUserContextIsNull = true;
            request.UserContext = new Amazon.BedrockAgentRuntime.Model.UserContext();
            System.String requestUserContext_userContext_UserId = null;
            if (cmdletContext.UserContext_UserId != null)
            {
                requestUserContext_userContext_UserId = cmdletContext.UserContext_UserId;
            }
            if (requestUserContext_userContext_UserId != null)
            {
                request.UserContext.UserId = requestUserContext_userContext_UserId;
                requestUserContextIsNull = false;
            }
             // determine if request.UserContext should be set to null
            if (requestUserContextIsNull)
            {
                request.UserContext = null;
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
        
        private Amazon.BedrockAgentRuntime.Model.AgenticRetrieveStreamResponse CallAWSServiceOperation(IAmazonBedrockAgentRuntime client, Amazon.BedrockAgentRuntime.Model.AgenticRetrieveStreamRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Runtime", "AgenticRetrieveStream");
            try
            {
                return client.AgenticRetrieveStreamAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AgenticRetrieveConfiguration_FoundationModelConfiguration_BedrockFoundationModelConfiguration_ModelConfiguration_ModelArn { get; set; }
            public Amazon.BedrockAgentRuntime.FoundationModelConfigurationType AgenticRetrieveConfiguration_FoundationModelConfiguration_Type { get; set; }
            public Amazon.BedrockAgentRuntime.FoundationModelType AgenticRetrieveConfiguration_FoundationModelType { get; set; }
            public System.Int32? AgenticRetrieveConfiguration_MaxAgentIteration { get; set; }
            public System.String AgenticRetrieveConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration_ModelArn { get; set; }
            public Amazon.BedrockAgentRuntime.AgenticRetrieveRerankingConfigurationType AgenticRetrieveConfiguration_RerankingConfiguration_Type { get; set; }
            public Amazon.BedrockAgentRuntime.AgenticRetrieveRerankingModelType AgenticRetrieveConfiguration_RerankingModelType { get; set; }
            public System.Boolean? GenerateResponse { get; set; }
            public List<Amazon.BedrockAgentRuntime.Model.AgenticRetrieveMessage> Message { get; set; }
            public System.String NextToken { get; set; }
            public System.String PolicyConfiguration_BedrockGuardrailConfiguration_GuardrailId { get; set; }
            public System.String PolicyConfiguration_BedrockGuardrailConfiguration_GuardrailVersion { get; set; }
            public List<Amazon.BedrockAgentRuntime.Model.AgenticRetriever> Retriever { get; set; }
            public System.String UserContext_UserId { get; set; }
            public System.Func<Amazon.BedrockAgentRuntime.Model.AgenticRetrieveStreamResponse, InvokeBARAgenticRetrieveStreamCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Stream;
        }
        
    }
}
