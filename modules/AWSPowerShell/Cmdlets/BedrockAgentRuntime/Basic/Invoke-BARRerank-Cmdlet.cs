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
    /// Reranks the relevance of sources based on queries. For more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/rerank.html">Improve
    /// the relevance of query responses with a reranker model</a>.
    /// </summary>
    [Cmdlet("Invoke", "BARRerank", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentRuntime.Model.RerankResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Runtime Rerank API operation.", Operation = new[] {"Rerank"}, SelectReturnType = typeof(Amazon.BedrockAgentRuntime.Model.RerankResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentRuntime.Model.RerankResponse",
        "This cmdlet returns an Amazon.BedrockAgentRuntime.Model.RerankResponse object containing multiple properties."
    )]
    public partial class InvokeBARRerankCmdlet : AmazonBedrockAgentRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ModelConfiguration_AdditionalModelRequestField
        /// <summary>
        /// <para>
        /// <para>A JSON object whose keys are request fields for the model and whose values are values
        /// for those fields.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration_AdditionalModelRequestFields")]
        public System.Collections.Hashtable ModelConfiguration_AdditionalModelRequestField { get; set; }
        #endregion
        
        #region Parameter ModelConfiguration_ModelArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the reranker model.</para>
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
        [Alias("RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration_ModelArn")]
        public System.String ModelConfiguration_ModelArn { get; set; }
        #endregion
        
        #region Parameter BedrockRerankingConfiguration_NumberOfResult
        /// <summary>
        /// <para>
        /// <para>The number of results to return after reranking.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RerankingConfiguration_BedrockRerankingConfiguration_NumberOfResults")]
        public System.Int32? BedrockRerankingConfiguration_NumberOfResult { get; set; }
        #endregion
        
        #region Parameter Query
        /// <summary>
        /// <para>
        /// <para>An array of objects, each of which contains information about a query to submit to
        /// the reranker model.</para>
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
        [Alias("Queries")]
        public Amazon.BedrockAgentRuntime.Model.RerankQuery[] Query { get; set; }
        #endregion
        
        #region Parameter Source
        /// <summary>
        /// <para>
        /// <para>An array of objects, each of which contains information about the sources to rerank.</para>
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
        [Alias("Sources")]
        public Amazon.BedrockAgentRuntime.Model.RerankSource[] Source { get; set; }
        #endregion
        
        #region Parameter RerankingConfiguration_Type
        /// <summary>
        /// <para>
        /// <para>The type of reranker that the configurations apply to.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.BedrockAgentRuntime.RerankingConfigurationType")]
        public Amazon.BedrockAgentRuntime.RerankingConfigurationType RerankingConfiguration_Type { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the total number of results was greater than could fit in a response, a token is
        /// returned in the <c>nextToken</c> field. You can enter that token in this field to
        /// return the next batch of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentRuntime.Model.RerankResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentRuntime.Model.RerankResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-BARRerank (Rerank)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentRuntime.Model.RerankResponse, InvokeBARRerankCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.NextToken = this.NextToken;
            if (this.Query != null)
            {
                context.Query = new List<Amazon.BedrockAgentRuntime.Model.RerankQuery>(this.Query);
            }
            #if MODULAR
            if (this.Query == null && ParameterWasBound(nameof(this.Query)))
            {
                WriteWarning("You are passing $null as a value for parameter Query which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ModelConfiguration_AdditionalModelRequestField != null)
            {
                context.ModelConfiguration_AdditionalModelRequestField = new Dictionary<System.String, Amazon.Runtime.Documents.Document>(StringComparer.Ordinal);
                foreach (var hashKey in this.ModelConfiguration_AdditionalModelRequestField.Keys)
                {
                    context.ModelConfiguration_AdditionalModelRequestField.Add((String)hashKey, Amazon.PowerShell.Common.DocumentHelper.ToDocument(this.ModelConfiguration_AdditionalModelRequestField[hashKey]));
                }
            }
            context.ModelConfiguration_ModelArn = this.ModelConfiguration_ModelArn;
            #if MODULAR
            if (this.ModelConfiguration_ModelArn == null && ParameterWasBound(nameof(this.ModelConfiguration_ModelArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelConfiguration_ModelArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BedrockRerankingConfiguration_NumberOfResult = this.BedrockRerankingConfiguration_NumberOfResult;
            context.RerankingConfiguration_Type = this.RerankingConfiguration_Type;
            #if MODULAR
            if (this.RerankingConfiguration_Type == null && ParameterWasBound(nameof(this.RerankingConfiguration_Type)))
            {
                WriteWarning("You are passing $null as a value for parameter RerankingConfiguration_Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Source != null)
            {
                context.Source = new List<Amazon.BedrockAgentRuntime.Model.RerankSource>(this.Source);
            }
            #if MODULAR
            if (this.Source == null && ParameterWasBound(nameof(this.Source)))
            {
                WriteWarning("You are passing $null as a value for parameter Source which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BedrockAgentRuntime.Model.RerankRequest();
            
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.Query != null)
            {
                request.Queries = cmdletContext.Query;
            }
            
             // populate RerankingConfiguration
            var requestRerankingConfigurationIsNull = true;
            request.RerankingConfiguration = new Amazon.BedrockAgentRuntime.Model.RerankingConfiguration();
            Amazon.BedrockAgentRuntime.RerankingConfigurationType requestRerankingConfiguration_rerankingConfiguration_Type = null;
            if (cmdletContext.RerankingConfiguration_Type != null)
            {
                requestRerankingConfiguration_rerankingConfiguration_Type = cmdletContext.RerankingConfiguration_Type;
            }
            if (requestRerankingConfiguration_rerankingConfiguration_Type != null)
            {
                request.RerankingConfiguration.Type = requestRerankingConfiguration_rerankingConfiguration_Type;
                requestRerankingConfigurationIsNull = false;
            }
            Amazon.BedrockAgentRuntime.Model.BedrockRerankingConfiguration requestRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration = null;
            
             // populate BedrockRerankingConfiguration
            var requestRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfigurationIsNull = true;
            requestRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration = new Amazon.BedrockAgentRuntime.Model.BedrockRerankingConfiguration();
            System.Int32? requestRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_bedrockRerankingConfiguration_NumberOfResult = null;
            if (cmdletContext.BedrockRerankingConfiguration_NumberOfResult != null)
            {
                requestRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_bedrockRerankingConfiguration_NumberOfResult = cmdletContext.BedrockRerankingConfiguration_NumberOfResult.Value;
            }
            if (requestRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_bedrockRerankingConfiguration_NumberOfResult != null)
            {
                requestRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration.NumberOfResults = requestRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_bedrockRerankingConfiguration_NumberOfResult.Value;
                requestRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfigurationIsNull = false;
            }
            Amazon.BedrockAgentRuntime.Model.BedrockRerankingModelConfiguration requestRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration = null;
            
             // populate ModelConfiguration
            var requestRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_ModelConfigurationIsNull = true;
            requestRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration = new Amazon.BedrockAgentRuntime.Model.BedrockRerankingModelConfiguration();
            Dictionary<System.String, Amazon.Runtime.Documents.Document> requestRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration_modelConfiguration_AdditionalModelRequestField = null;
            if (cmdletContext.ModelConfiguration_AdditionalModelRequestField != null)
            {
                requestRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration_modelConfiguration_AdditionalModelRequestField = cmdletContext.ModelConfiguration_AdditionalModelRequestField;
            }
            if (requestRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration_modelConfiguration_AdditionalModelRequestField != null)
            {
                requestRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration.AdditionalModelRequestFields = requestRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration_modelConfiguration_AdditionalModelRequestField;
                requestRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_ModelConfigurationIsNull = false;
            }
            System.String requestRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration_modelConfiguration_ModelArn = null;
            if (cmdletContext.ModelConfiguration_ModelArn != null)
            {
                requestRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration_modelConfiguration_ModelArn = cmdletContext.ModelConfiguration_ModelArn;
            }
            if (requestRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration_modelConfiguration_ModelArn != null)
            {
                requestRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration.ModelArn = requestRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration_modelConfiguration_ModelArn;
                requestRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_ModelConfigurationIsNull = false;
            }
             // determine if requestRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration should be set to null
            if (requestRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_ModelConfigurationIsNull)
            {
                requestRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration = null;
            }
            if (requestRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration != null)
            {
                requestRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration.ModelConfiguration = requestRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration;
                requestRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfigurationIsNull = false;
            }
             // determine if requestRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration should be set to null
            if (requestRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfigurationIsNull)
            {
                requestRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration = null;
            }
            if (requestRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration != null)
            {
                request.RerankingConfiguration.BedrockRerankingConfiguration = requestRerankingConfiguration_rerankingConfiguration_BedrockRerankingConfiguration;
                requestRerankingConfigurationIsNull = false;
            }
             // determine if request.RerankingConfiguration should be set to null
            if (requestRerankingConfigurationIsNull)
            {
                request.RerankingConfiguration = null;
            }
            if (cmdletContext.Source != null)
            {
                request.Sources = cmdletContext.Source;
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
        
        private Amazon.BedrockAgentRuntime.Model.RerankResponse CallAWSServiceOperation(IAmazonBedrockAgentRuntime client, Amazon.BedrockAgentRuntime.Model.RerankRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Runtime", "Rerank");
            try
            {
                return client.RerankAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String NextToken { get; set; }
            public List<Amazon.BedrockAgentRuntime.Model.RerankQuery> Query { get; set; }
            public Dictionary<System.String, Amazon.Runtime.Documents.Document> ModelConfiguration_AdditionalModelRequestField { get; set; }
            public System.String ModelConfiguration_ModelArn { get; set; }
            public System.Int32? BedrockRerankingConfiguration_NumberOfResult { get; set; }
            public Amazon.BedrockAgentRuntime.RerankingConfigurationType RerankingConfiguration_Type { get; set; }
            public List<Amazon.BedrockAgentRuntime.Model.RerankSource> Source { get; set; }
            public System.Func<Amazon.BedrockAgentRuntime.Model.RerankResponse, InvokeBARRerankCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
