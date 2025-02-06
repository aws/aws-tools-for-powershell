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
using Amazon.BedrockAgentRuntime;
using Amazon.BedrockAgentRuntime.Model;

namespace Amazon.PowerShell.Cmdlets.BAR
{
    /// <summary>
    /// Generates an SQL query from a natural language query. For more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/knowledge-base-generate-query.html">Generate
    /// a query for structured data</a> in the Amazon Bedrock User Guide.
    /// </summary>
    [Cmdlet("Invoke", "BARGenerateQuery", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentRuntime.Model.GeneratedQuery")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Runtime GenerateQuery API operation.", Operation = new[] {"GenerateQuery"}, SelectReturnType = typeof(Amazon.BedrockAgentRuntime.Model.GenerateQueryResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentRuntime.Model.GeneratedQuery or Amazon.BedrockAgentRuntime.Model.GenerateQueryResponse",
        "This cmdlet returns a collection of Amazon.BedrockAgentRuntime.Model.GeneratedQuery objects.",
        "The service call response (type Amazon.BedrockAgentRuntime.Model.GenerateQueryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class InvokeBARGenerateQueryCmdlet : AmazonBedrockAgentRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter KnowledgeBaseConfiguration_KnowledgeBaseArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the knowledge base</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TransformationConfiguration_TextToSqlConfiguration_KnowledgeBaseConfiguration_KnowledgeBaseArn")]
        public System.String KnowledgeBaseConfiguration_KnowledgeBaseArn { get; set; }
        #endregion
        
        #region Parameter TransformationConfiguration_Mode
        /// <summary>
        /// <para>
        /// <para>The mode of the transformation.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.BedrockAgentRuntime.QueryTransformationMode")]
        public Amazon.BedrockAgentRuntime.QueryTransformationMode TransformationConfiguration_Mode { get; set; }
        #endregion
        
        #region Parameter QueryGenerationInput_Text
        /// <summary>
        /// <para>
        /// <para>The text of the query.</para>
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
        public System.String QueryGenerationInput_Text { get; set; }
        #endregion
        
        #region Parameter QueryGenerationInput_Type
        /// <summary>
        /// <para>
        /// <para>The type of the query.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.BedrockAgentRuntime.InputQueryType")]
        public Amazon.BedrockAgentRuntime.InputQueryType QueryGenerationInput_Type { get; set; }
        #endregion
        
        #region Parameter TextToSqlConfiguration_Type
        /// <summary>
        /// <para>
        /// <para>The type of resource to use in transformation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TransformationConfiguration_TextToSqlConfiguration_Type")]
        [AWSConstantClassSource("Amazon.BedrockAgentRuntime.TextToSqlConfigurationType")]
        public Amazon.BedrockAgentRuntime.TextToSqlConfigurationType TextToSqlConfiguration_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Queries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentRuntime.Model.GenerateQueryResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentRuntime.Model.GenerateQueryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Queries";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.KnowledgeBaseConfiguration_KnowledgeBaseArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-BARGenerateQuery (GenerateQuery)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentRuntime.Model.GenerateQueryResponse, InvokeBARGenerateQueryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.QueryGenerationInput_Text = this.QueryGenerationInput_Text;
            #if MODULAR
            if (this.QueryGenerationInput_Text == null && ParameterWasBound(nameof(this.QueryGenerationInput_Text)))
            {
                WriteWarning("You are passing $null as a value for parameter QueryGenerationInput_Text which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.QueryGenerationInput_Type = this.QueryGenerationInput_Type;
            #if MODULAR
            if (this.QueryGenerationInput_Type == null && ParameterWasBound(nameof(this.QueryGenerationInput_Type)))
            {
                WriteWarning("You are passing $null as a value for parameter QueryGenerationInput_Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TransformationConfiguration_Mode = this.TransformationConfiguration_Mode;
            #if MODULAR
            if (this.TransformationConfiguration_Mode == null && ParameterWasBound(nameof(this.TransformationConfiguration_Mode)))
            {
                WriteWarning("You are passing $null as a value for parameter TransformationConfiguration_Mode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KnowledgeBaseConfiguration_KnowledgeBaseArn = this.KnowledgeBaseConfiguration_KnowledgeBaseArn;
            context.TextToSqlConfiguration_Type = this.TextToSqlConfiguration_Type;
            
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
            var request = new Amazon.BedrockAgentRuntime.Model.GenerateQueryRequest();
            
            
             // populate QueryGenerationInput
            var requestQueryGenerationInputIsNull = true;
            request.QueryGenerationInput = new Amazon.BedrockAgentRuntime.Model.QueryGenerationInput();
            System.String requestQueryGenerationInput_queryGenerationInput_Text = null;
            if (cmdletContext.QueryGenerationInput_Text != null)
            {
                requestQueryGenerationInput_queryGenerationInput_Text = cmdletContext.QueryGenerationInput_Text;
            }
            if (requestQueryGenerationInput_queryGenerationInput_Text != null)
            {
                request.QueryGenerationInput.Text = requestQueryGenerationInput_queryGenerationInput_Text;
                requestQueryGenerationInputIsNull = false;
            }
            Amazon.BedrockAgentRuntime.InputQueryType requestQueryGenerationInput_queryGenerationInput_Type = null;
            if (cmdletContext.QueryGenerationInput_Type != null)
            {
                requestQueryGenerationInput_queryGenerationInput_Type = cmdletContext.QueryGenerationInput_Type;
            }
            if (requestQueryGenerationInput_queryGenerationInput_Type != null)
            {
                request.QueryGenerationInput.Type = requestQueryGenerationInput_queryGenerationInput_Type;
                requestQueryGenerationInputIsNull = false;
            }
             // determine if request.QueryGenerationInput should be set to null
            if (requestQueryGenerationInputIsNull)
            {
                request.QueryGenerationInput = null;
            }
            
             // populate TransformationConfiguration
            var requestTransformationConfigurationIsNull = true;
            request.TransformationConfiguration = new Amazon.BedrockAgentRuntime.Model.TransformationConfiguration();
            Amazon.BedrockAgentRuntime.QueryTransformationMode requestTransformationConfiguration_transformationConfiguration_Mode = null;
            if (cmdletContext.TransformationConfiguration_Mode != null)
            {
                requestTransformationConfiguration_transformationConfiguration_Mode = cmdletContext.TransformationConfiguration_Mode;
            }
            if (requestTransformationConfiguration_transformationConfiguration_Mode != null)
            {
                request.TransformationConfiguration.Mode = requestTransformationConfiguration_transformationConfiguration_Mode;
                requestTransformationConfigurationIsNull = false;
            }
            Amazon.BedrockAgentRuntime.Model.TextToSqlConfiguration requestTransformationConfiguration_transformationConfiguration_TextToSqlConfiguration = null;
            
             // populate TextToSqlConfiguration
            var requestTransformationConfiguration_transformationConfiguration_TextToSqlConfigurationIsNull = true;
            requestTransformationConfiguration_transformationConfiguration_TextToSqlConfiguration = new Amazon.BedrockAgentRuntime.Model.TextToSqlConfiguration();
            Amazon.BedrockAgentRuntime.TextToSqlConfigurationType requestTransformationConfiguration_transformationConfiguration_TextToSqlConfiguration_textToSqlConfiguration_Type = null;
            if (cmdletContext.TextToSqlConfiguration_Type != null)
            {
                requestTransformationConfiguration_transformationConfiguration_TextToSqlConfiguration_textToSqlConfiguration_Type = cmdletContext.TextToSqlConfiguration_Type;
            }
            if (requestTransformationConfiguration_transformationConfiguration_TextToSqlConfiguration_textToSqlConfiguration_Type != null)
            {
                requestTransformationConfiguration_transformationConfiguration_TextToSqlConfiguration.Type = requestTransformationConfiguration_transformationConfiguration_TextToSqlConfiguration_textToSqlConfiguration_Type;
                requestTransformationConfiguration_transformationConfiguration_TextToSqlConfigurationIsNull = false;
            }
            Amazon.BedrockAgentRuntime.Model.TextToSqlKnowledgeBaseConfiguration requestTransformationConfiguration_transformationConfiguration_TextToSqlConfiguration_transformationConfiguration_TextToSqlConfiguration_KnowledgeBaseConfiguration = null;
            
             // populate KnowledgeBaseConfiguration
            var requestTransformationConfiguration_transformationConfiguration_TextToSqlConfiguration_transformationConfiguration_TextToSqlConfiguration_KnowledgeBaseConfigurationIsNull = true;
            requestTransformationConfiguration_transformationConfiguration_TextToSqlConfiguration_transformationConfiguration_TextToSqlConfiguration_KnowledgeBaseConfiguration = new Amazon.BedrockAgentRuntime.Model.TextToSqlKnowledgeBaseConfiguration();
            System.String requestTransformationConfiguration_transformationConfiguration_TextToSqlConfiguration_transformationConfiguration_TextToSqlConfiguration_KnowledgeBaseConfiguration_knowledgeBaseConfiguration_KnowledgeBaseArn = null;
            if (cmdletContext.KnowledgeBaseConfiguration_KnowledgeBaseArn != null)
            {
                requestTransformationConfiguration_transformationConfiguration_TextToSqlConfiguration_transformationConfiguration_TextToSqlConfiguration_KnowledgeBaseConfiguration_knowledgeBaseConfiguration_KnowledgeBaseArn = cmdletContext.KnowledgeBaseConfiguration_KnowledgeBaseArn;
            }
            if (requestTransformationConfiguration_transformationConfiguration_TextToSqlConfiguration_transformationConfiguration_TextToSqlConfiguration_KnowledgeBaseConfiguration_knowledgeBaseConfiguration_KnowledgeBaseArn != null)
            {
                requestTransformationConfiguration_transformationConfiguration_TextToSqlConfiguration_transformationConfiguration_TextToSqlConfiguration_KnowledgeBaseConfiguration.KnowledgeBaseArn = requestTransformationConfiguration_transformationConfiguration_TextToSqlConfiguration_transformationConfiguration_TextToSqlConfiguration_KnowledgeBaseConfiguration_knowledgeBaseConfiguration_KnowledgeBaseArn;
                requestTransformationConfiguration_transformationConfiguration_TextToSqlConfiguration_transformationConfiguration_TextToSqlConfiguration_KnowledgeBaseConfigurationIsNull = false;
            }
             // determine if requestTransformationConfiguration_transformationConfiguration_TextToSqlConfiguration_transformationConfiguration_TextToSqlConfiguration_KnowledgeBaseConfiguration should be set to null
            if (requestTransformationConfiguration_transformationConfiguration_TextToSqlConfiguration_transformationConfiguration_TextToSqlConfiguration_KnowledgeBaseConfigurationIsNull)
            {
                requestTransformationConfiguration_transformationConfiguration_TextToSqlConfiguration_transformationConfiguration_TextToSqlConfiguration_KnowledgeBaseConfiguration = null;
            }
            if (requestTransformationConfiguration_transformationConfiguration_TextToSqlConfiguration_transformationConfiguration_TextToSqlConfiguration_KnowledgeBaseConfiguration != null)
            {
                requestTransformationConfiguration_transformationConfiguration_TextToSqlConfiguration.KnowledgeBaseConfiguration = requestTransformationConfiguration_transformationConfiguration_TextToSqlConfiguration_transformationConfiguration_TextToSqlConfiguration_KnowledgeBaseConfiguration;
                requestTransformationConfiguration_transformationConfiguration_TextToSqlConfigurationIsNull = false;
            }
             // determine if requestTransformationConfiguration_transformationConfiguration_TextToSqlConfiguration should be set to null
            if (requestTransformationConfiguration_transformationConfiguration_TextToSqlConfigurationIsNull)
            {
                requestTransformationConfiguration_transformationConfiguration_TextToSqlConfiguration = null;
            }
            if (requestTransformationConfiguration_transformationConfiguration_TextToSqlConfiguration != null)
            {
                request.TransformationConfiguration.TextToSqlConfiguration = requestTransformationConfiguration_transformationConfiguration_TextToSqlConfiguration;
                requestTransformationConfigurationIsNull = false;
            }
             // determine if request.TransformationConfiguration should be set to null
            if (requestTransformationConfigurationIsNull)
            {
                request.TransformationConfiguration = null;
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
        
        private Amazon.BedrockAgentRuntime.Model.GenerateQueryResponse CallAWSServiceOperation(IAmazonBedrockAgentRuntime client, Amazon.BedrockAgentRuntime.Model.GenerateQueryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Runtime", "GenerateQuery");
            try
            {
                #if DESKTOP
                return client.GenerateQuery(request);
                #elif CORECLR
                return client.GenerateQueryAsync(request).GetAwaiter().GetResult();
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
            public System.String QueryGenerationInput_Text { get; set; }
            public Amazon.BedrockAgentRuntime.InputQueryType QueryGenerationInput_Type { get; set; }
            public Amazon.BedrockAgentRuntime.QueryTransformationMode TransformationConfiguration_Mode { get; set; }
            public System.String KnowledgeBaseConfiguration_KnowledgeBaseArn { get; set; }
            public Amazon.BedrockAgentRuntime.TextToSqlConfigurationType TextToSqlConfiguration_Type { get; set; }
            public System.Func<Amazon.BedrockAgentRuntime.Model.GenerateQueryResponse, InvokeBARGenerateQueryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Queries;
        }
        
    }
}
