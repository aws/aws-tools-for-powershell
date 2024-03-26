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
using Amazon.BedrockAgentRuntime;
using Amazon.BedrockAgentRuntime.Model;

namespace Amazon.PowerShell.Cmdlets.BAR
{
    /// <summary>
    /// Queries a knowledge base and retrieves information from it.
    /// </summary>
    [Cmdlet("Invoke", "BARRetrieve", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentRuntime.Model.RetrieveResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Runtime Retrieve API operation.", Operation = new[] {"Retrieve"}, SelectReturnType = typeof(Amazon.BedrockAgentRuntime.Model.RetrieveResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentRuntime.Model.RetrieveResponse",
        "This cmdlet returns an Amazon.BedrockAgentRuntime.Model.RetrieveResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class InvokeBARRetrieveCmdlet : AmazonBedrockAgentRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter KnowledgeBaseId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the knowledge base to query.</para>
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
        public System.String KnowledgeBaseId { get; set; }
        #endregion
        
        #region Parameter VectorSearchConfiguration_NumberOfResult
        /// <summary>
        /// <para>
        /// <para>The number of source chunks to retrieve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_VectorSearchConfiguration_NumberOfResults")]
        public System.Int32? VectorSearchConfiguration_NumberOfResult { get; set; }
        #endregion
        
        #region Parameter VectorSearchConfiguration_OverrideSearchType
        /// <summary>
        /// <para>
        /// <para>By default, Amazon Bedrock decides a search strategy for you. If you're using an Amazon
        /// OpenSearch Serverless vector store that contains a filterable text field, you can
        /// specify whether to query the knowledge base with a <c>HYBRID</c> search using both
        /// vector embeddings and raw text, or <c>SEMANTIC</c> search using only vector embeddings.
        /// For other vector store configurations, only <c>SEMANTIC</c> search is available. For
        /// more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/knowledge-base-test.html">Test
        /// a knowledge base</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_VectorSearchConfiguration_OverrideSearchType")]
        [AWSConstantClassSource("Amazon.BedrockAgentRuntime.SearchType")]
        public Amazon.BedrockAgentRuntime.SearchType VectorSearchConfiguration_OverrideSearchType { get; set; }
        #endregion
        
        #region Parameter RetrievalQuery_Text
        /// <summary>
        /// <para>
        /// <para>The text of the query made to the knowledge base.</para>
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
        public System.String RetrievalQuery_Text { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If there are more results than can fit in the response, the response returns a <c>nextToken</c>.
        /// Use this token in the <c>nextToken</c> field of another request to retrieve the next
        /// batch of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentRuntime.Model.RetrieveResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentRuntime.Model.RetrieveResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the KnowledgeBaseId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^KnowledgeBaseId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^KnowledgeBaseId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.KnowledgeBaseId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-BARRetrieve (Retrieve)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentRuntime.Model.RetrieveResponse, InvokeBARRetrieveCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.KnowledgeBaseId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.KnowledgeBaseId = this.KnowledgeBaseId;
            #if MODULAR
            if (this.KnowledgeBaseId == null && ParameterWasBound(nameof(this.KnowledgeBaseId)))
            {
                WriteWarning("You are passing $null as a value for parameter KnowledgeBaseId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.VectorSearchConfiguration_NumberOfResult = this.VectorSearchConfiguration_NumberOfResult;
            context.VectorSearchConfiguration_OverrideSearchType = this.VectorSearchConfiguration_OverrideSearchType;
            context.RetrievalQuery_Text = this.RetrievalQuery_Text;
            #if MODULAR
            if (this.RetrievalQuery_Text == null && ParameterWasBound(nameof(this.RetrievalQuery_Text)))
            {
                WriteWarning("You are passing $null as a value for parameter RetrievalQuery_Text which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BedrockAgentRuntime.Model.RetrieveRequest();
            
            if (cmdletContext.KnowledgeBaseId != null)
            {
                request.KnowledgeBaseId = cmdletContext.KnowledgeBaseId;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            
             // populate RetrievalConfiguration
            var requestRetrievalConfigurationIsNull = true;
            request.RetrievalConfiguration = new Amazon.BedrockAgentRuntime.Model.KnowledgeBaseRetrievalConfiguration();
            Amazon.BedrockAgentRuntime.Model.KnowledgeBaseVectorSearchConfiguration requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration = null;
            
             // populate VectorSearchConfiguration
            var requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfigurationIsNull = true;
            requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration = new Amazon.BedrockAgentRuntime.Model.KnowledgeBaseVectorSearchConfiguration();
            System.Int32? requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_vectorSearchConfiguration_NumberOfResult = null;
            if (cmdletContext.VectorSearchConfiguration_NumberOfResult != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_vectorSearchConfiguration_NumberOfResult = cmdletContext.VectorSearchConfiguration_NumberOfResult.Value;
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_vectorSearchConfiguration_NumberOfResult != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration.NumberOfResults = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_vectorSearchConfiguration_NumberOfResult.Value;
                requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfigurationIsNull = false;
            }
            Amazon.BedrockAgentRuntime.SearchType requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_vectorSearchConfiguration_OverrideSearchType = null;
            if (cmdletContext.VectorSearchConfiguration_OverrideSearchType != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_vectorSearchConfiguration_OverrideSearchType = cmdletContext.VectorSearchConfiguration_OverrideSearchType;
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_vectorSearchConfiguration_OverrideSearchType != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration.OverrideSearchType = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_vectorSearchConfiguration_OverrideSearchType;
                requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfigurationIsNull = false;
            }
             // determine if requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration should be set to null
            if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfigurationIsNull)
            {
                requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration = null;
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration != null)
            {
                request.RetrievalConfiguration.VectorSearchConfiguration = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration;
                requestRetrievalConfigurationIsNull = false;
            }
             // determine if request.RetrievalConfiguration should be set to null
            if (requestRetrievalConfigurationIsNull)
            {
                request.RetrievalConfiguration = null;
            }
            
             // populate RetrievalQuery
            var requestRetrievalQueryIsNull = true;
            request.RetrievalQuery = new Amazon.BedrockAgentRuntime.Model.KnowledgeBaseQuery();
            System.String requestRetrievalQuery_retrievalQuery_Text = null;
            if (cmdletContext.RetrievalQuery_Text != null)
            {
                requestRetrievalQuery_retrievalQuery_Text = cmdletContext.RetrievalQuery_Text;
            }
            if (requestRetrievalQuery_retrievalQuery_Text != null)
            {
                request.RetrievalQuery.Text = requestRetrievalQuery_retrievalQuery_Text;
                requestRetrievalQueryIsNull = false;
            }
             // determine if request.RetrievalQuery should be set to null
            if (requestRetrievalQueryIsNull)
            {
                request.RetrievalQuery = null;
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
        
        private Amazon.BedrockAgentRuntime.Model.RetrieveResponse CallAWSServiceOperation(IAmazonBedrockAgentRuntime client, Amazon.BedrockAgentRuntime.Model.RetrieveRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Runtime", "Retrieve");
            try
            {
                #if DESKTOP
                return client.Retrieve(request);
                #elif CORECLR
                return client.RetrieveAsync(request).GetAwaiter().GetResult();
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
            public System.String KnowledgeBaseId { get; set; }
            public System.String NextToken { get; set; }
            public System.Int32? VectorSearchConfiguration_NumberOfResult { get; set; }
            public Amazon.BedrockAgentRuntime.SearchType VectorSearchConfiguration_OverrideSearchType { get; set; }
            public System.String RetrievalQuery_Text { get; set; }
            public System.Func<Amazon.BedrockAgentRuntime.Model.RetrieveResponse, InvokeBARRetrieveCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
