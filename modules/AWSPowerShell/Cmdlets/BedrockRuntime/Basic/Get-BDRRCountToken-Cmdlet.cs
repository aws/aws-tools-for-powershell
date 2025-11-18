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
using Amazon.BedrockRuntime;
using Amazon.BedrockRuntime.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BDRR
{
    /// <summary>
    /// Returns the token count for a given inference request. This operation helps you estimate
    /// token usage before sending requests to foundation models by returning the token count
    /// that would be used if the same input were sent to the model in an inference request.
    /// 
    ///  
    /// <para>
    /// Token counting is model-specific because different models use different tokenization
    /// strategies. The token count returned by this operation will match the token count
    /// that would be charged if the same input were sent to the model in an <c>InvokeModel</c>
    /// or <c>Converse</c> request.
    /// </para><para>
    /// You can use this operation to:
    /// </para><ul><li><para>
    /// Estimate costs before sending inference requests.
    /// </para></li><li><para>
    /// Optimize prompts to fit within token limits.
    /// </para></li><li><para>
    /// Plan for token usage in your applications.
    /// </para></li></ul><para>
    /// This operation accepts the same input formats as <c>InvokeModel</c> and <c>Converse</c>,
    /// allowing you to count tokens for both raw text inputs and structured conversation
    /// formats.
    /// </para><para>
    /// The following operations are related to <c>CountTokens</c>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/bedrock/latest/API/API_runtime_InvokeModel.html">InvokeModel</a>
    /// - Sends inference requests to foundation models
    /// </para></li><li><para><a href="https://docs.aws.amazon.com/bedrock/latest/API/API_runtime_Converse.html">Converse</a>
    /// - Sends conversation-based inference requests to foundation models
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Get", "BDRRCountToken")]
    [OutputType("System.Int32")]
    [AWSCmdlet("Calls the Amazon Bedrock Runtime CountTokens API operation.", Operation = new[] {"CountTokens"}, SelectReturnType = typeof(Amazon.BedrockRuntime.Model.CountTokensResponse))]
    [AWSCmdletOutput("System.Int32 or Amazon.BedrockRuntime.Model.CountTokensResponse",
        "This cmdlet returns a collection of System.Int32 objects.",
        "The service call response (type Amazon.BedrockRuntime.Model.CountTokensResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetBDRRCountTokenCmdlet : AmazonBedrockRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Converse_AdditionalModelRequestField
        /// <summary>
        /// <para>
        /// <para>The additionalModelRequestFields of Converse input request to count tokens for. Use
        /// this field when you want to pass additional parameters that the model supports.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_Converse_AdditionalModelRequestFields")]
        public System.Management.Automation.PSObject Converse_AdditionalModelRequestField { get; set; }
        #endregion
        
        #region Parameter ToolChoice_Any
        /// <summary>
        /// <para>
        /// <para>The model must request at least one tool (no text is generated).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_Converse_ToolConfig_ToolChoice_Any")]
        public Amazon.BedrockRuntime.Model.AnyToolChoice ToolChoice_Any { get; set; }
        #endregion
        
        #region Parameter ToolChoice_Auto
        /// <summary>
        /// <para>
        /// <para>(Default). The Model automatically decides if a tool should be called or whether to
        /// generate text instead. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_Converse_ToolConfig_ToolChoice_Auto")]
        public Amazon.BedrockRuntime.Model.AutoToolChoice ToolChoice_Auto { get; set; }
        #endregion
        
        #region Parameter InvokeModel_Body
        /// <summary>
        /// <para>
        /// <para>The request body to count tokens for, formatted according to the model's expected
        /// input format. To learn about the input format for different models, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/model-parameters.html">Model
        /// inference parameters and responses</a>.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_InvokeModel_Body")]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] InvokeModel_Body { get; set; }
        #endregion
        
        #region Parameter Converse_Message
        /// <summary>
        /// <para>
        /// <para>An array of messages to count tokens for.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_Converse_Messages")]
        public Amazon.BedrockRuntime.Model.Message[] Converse_Message { get; set; }
        #endregion
        
        #region Parameter ModelId
        /// <summary>
        /// <para>
        /// <para>The unique identifier or ARN of the foundation model to use for token counting. Each
        /// model processes tokens differently, so the token count is specific to the model you
        /// specify.</para>
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
        public System.String ModelId { get; set; }
        #endregion
        
        #region Parameter Tool_Name
        /// <summary>
        /// <para>
        /// <para>The name of the tool that the model must request. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_Converse_ToolConfig_ToolChoice_Tool_Name")]
        public System.String Tool_Name { get; set; }
        #endregion
        
        #region Parameter Converse_System
        /// <summary>
        /// <para>
        /// <para>The system content blocks to count tokens for. System content provides instructions
        /// or context to the model about how it should behave or respond. The token count will
        /// include any system content provided.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_Converse_System")]
        public Amazon.BedrockRuntime.Model.SystemContentBlock[] Converse_System { get; set; }
        #endregion
        
        #region Parameter ToolConfig_Tool
        /// <summary>
        /// <para>
        /// <para>An array of tools that you want to pass to a model. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_Converse_ToolConfig_Tools")]
        public Amazon.BedrockRuntime.Model.Tool[] ToolConfig_Tool { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InputTokens'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockRuntime.Model.CountTokensResponse).
        /// Specifying the name of a property of type Amazon.BedrockRuntime.Model.CountTokensResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InputTokens";
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
                context.Select = CreateSelectDelegate<Amazon.BedrockRuntime.Model.CountTokensResponse, GetBDRRCountTokenCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Converse_AdditionalModelRequestField = this.Converse_AdditionalModelRequestField;
            if (this.Converse_Message != null)
            {
                context.Converse_Message = new List<Amazon.BedrockRuntime.Model.Message>(this.Converse_Message);
            }
            if (this.Converse_System != null)
            {
                context.Converse_System = new List<Amazon.BedrockRuntime.Model.SystemContentBlock>(this.Converse_System);
            }
            context.ToolChoice_Any = this.ToolChoice_Any;
            context.ToolChoice_Auto = this.ToolChoice_Auto;
            context.Tool_Name = this.Tool_Name;
            if (this.ToolConfig_Tool != null)
            {
                context.ToolConfig_Tool = new List<Amazon.BedrockRuntime.Model.Tool>(this.ToolConfig_Tool);
            }
            context.InvokeModel_Body = this.InvokeModel_Body;
            context.ModelId = this.ModelId;
            #if MODULAR
            if (this.ModelId == null && ParameterWasBound(nameof(this.ModelId)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            System.IO.MemoryStream _InvokeModel_BodyStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.BedrockRuntime.Model.CountTokensRequest();
                
                
                 // populate Input
                var requestInputIsNull = true;
                request.Input = new Amazon.BedrockRuntime.Model.CountTokensInput();
                Amazon.BedrockRuntime.Model.InvokeModelTokensRequest requestInput_input_InvokeModel = null;
                
                 // populate InvokeModel
                var requestInput_input_InvokeModelIsNull = true;
                requestInput_input_InvokeModel = new Amazon.BedrockRuntime.Model.InvokeModelTokensRequest();
                System.IO.MemoryStream requestInput_input_InvokeModel_invokeModel_Body = null;
                if (cmdletContext.InvokeModel_Body != null)
                {
                    _InvokeModel_BodyStream = new System.IO.MemoryStream(cmdletContext.InvokeModel_Body);
                    requestInput_input_InvokeModel_invokeModel_Body = _InvokeModel_BodyStream;
                }
                if (requestInput_input_InvokeModel_invokeModel_Body != null)
                {
                    requestInput_input_InvokeModel.Body = requestInput_input_InvokeModel_invokeModel_Body;
                    requestInput_input_InvokeModelIsNull = false;
                }
                 // determine if requestInput_input_InvokeModel should be set to null
                if (requestInput_input_InvokeModelIsNull)
                {
                    requestInput_input_InvokeModel = null;
                }
                if (requestInput_input_InvokeModel != null)
                {
                    request.Input.InvokeModel = requestInput_input_InvokeModel;
                    requestInputIsNull = false;
                }
                Amazon.BedrockRuntime.Model.ConverseTokensRequest requestInput_input_Converse = null;
                
                 // populate Converse
                var requestInput_input_ConverseIsNull = true;
                requestInput_input_Converse = new Amazon.BedrockRuntime.Model.ConverseTokensRequest();
                Amazon.Runtime.Documents.Document? requestInput_input_Converse_converse_AdditionalModelRequestField = null;
                if (cmdletContext.Converse_AdditionalModelRequestField != null)
                {
                    requestInput_input_Converse_converse_AdditionalModelRequestField = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.Converse_AdditionalModelRequestField);
                }
                if (requestInput_input_Converse_converse_AdditionalModelRequestField != null)
                {
                    requestInput_input_Converse.AdditionalModelRequestFields = requestInput_input_Converse_converse_AdditionalModelRequestField.Value;
                    requestInput_input_ConverseIsNull = false;
                }
                List<Amazon.BedrockRuntime.Model.Message> requestInput_input_Converse_converse_Message = null;
                if (cmdletContext.Converse_Message != null)
                {
                    requestInput_input_Converse_converse_Message = cmdletContext.Converse_Message;
                }
                if (requestInput_input_Converse_converse_Message != null)
                {
                    requestInput_input_Converse.Messages = requestInput_input_Converse_converse_Message;
                    requestInput_input_ConverseIsNull = false;
                }
                List<Amazon.BedrockRuntime.Model.SystemContentBlock> requestInput_input_Converse_converse_System = null;
                if (cmdletContext.Converse_System != null)
                {
                    requestInput_input_Converse_converse_System = cmdletContext.Converse_System;
                }
                if (requestInput_input_Converse_converse_System != null)
                {
                    requestInput_input_Converse.System = requestInput_input_Converse_converse_System;
                    requestInput_input_ConverseIsNull = false;
                }
                Amazon.BedrockRuntime.Model.ToolConfiguration requestInput_input_Converse_input_Converse_ToolConfig = null;
                
                 // populate ToolConfig
                var requestInput_input_Converse_input_Converse_ToolConfigIsNull = true;
                requestInput_input_Converse_input_Converse_ToolConfig = new Amazon.BedrockRuntime.Model.ToolConfiguration();
                List<Amazon.BedrockRuntime.Model.Tool> requestInput_input_Converse_input_Converse_ToolConfig_toolConfig_Tool = null;
                if (cmdletContext.ToolConfig_Tool != null)
                {
                    requestInput_input_Converse_input_Converse_ToolConfig_toolConfig_Tool = cmdletContext.ToolConfig_Tool;
                }
                if (requestInput_input_Converse_input_Converse_ToolConfig_toolConfig_Tool != null)
                {
                    requestInput_input_Converse_input_Converse_ToolConfig.Tools = requestInput_input_Converse_input_Converse_ToolConfig_toolConfig_Tool;
                    requestInput_input_Converse_input_Converse_ToolConfigIsNull = false;
                }
                Amazon.BedrockRuntime.Model.ToolChoice requestInput_input_Converse_input_Converse_ToolConfig_input_Converse_ToolConfig_ToolChoice = null;
                
                 // populate ToolChoice
                var requestInput_input_Converse_input_Converse_ToolConfig_input_Converse_ToolConfig_ToolChoiceIsNull = true;
                requestInput_input_Converse_input_Converse_ToolConfig_input_Converse_ToolConfig_ToolChoice = new Amazon.BedrockRuntime.Model.ToolChoice();
                Amazon.BedrockRuntime.Model.AnyToolChoice requestInput_input_Converse_input_Converse_ToolConfig_input_Converse_ToolConfig_ToolChoice_toolChoice_Any = null;
                if (cmdletContext.ToolChoice_Any != null)
                {
                    requestInput_input_Converse_input_Converse_ToolConfig_input_Converse_ToolConfig_ToolChoice_toolChoice_Any = cmdletContext.ToolChoice_Any;
                }
                if (requestInput_input_Converse_input_Converse_ToolConfig_input_Converse_ToolConfig_ToolChoice_toolChoice_Any != null)
                {
                    requestInput_input_Converse_input_Converse_ToolConfig_input_Converse_ToolConfig_ToolChoice.Any = requestInput_input_Converse_input_Converse_ToolConfig_input_Converse_ToolConfig_ToolChoice_toolChoice_Any;
                    requestInput_input_Converse_input_Converse_ToolConfig_input_Converse_ToolConfig_ToolChoiceIsNull = false;
                }
                Amazon.BedrockRuntime.Model.AutoToolChoice requestInput_input_Converse_input_Converse_ToolConfig_input_Converse_ToolConfig_ToolChoice_toolChoice_Auto = null;
                if (cmdletContext.ToolChoice_Auto != null)
                {
                    requestInput_input_Converse_input_Converse_ToolConfig_input_Converse_ToolConfig_ToolChoice_toolChoice_Auto = cmdletContext.ToolChoice_Auto;
                }
                if (requestInput_input_Converse_input_Converse_ToolConfig_input_Converse_ToolConfig_ToolChoice_toolChoice_Auto != null)
                {
                    requestInput_input_Converse_input_Converse_ToolConfig_input_Converse_ToolConfig_ToolChoice.Auto = requestInput_input_Converse_input_Converse_ToolConfig_input_Converse_ToolConfig_ToolChoice_toolChoice_Auto;
                    requestInput_input_Converse_input_Converse_ToolConfig_input_Converse_ToolConfig_ToolChoiceIsNull = false;
                }
                Amazon.BedrockRuntime.Model.SpecificToolChoice requestInput_input_Converse_input_Converse_ToolConfig_input_Converse_ToolConfig_ToolChoice_input_Converse_ToolConfig_ToolChoice_Tool = null;
                
                 // populate Tool
                var requestInput_input_Converse_input_Converse_ToolConfig_input_Converse_ToolConfig_ToolChoice_input_Converse_ToolConfig_ToolChoice_ToolIsNull = true;
                requestInput_input_Converse_input_Converse_ToolConfig_input_Converse_ToolConfig_ToolChoice_input_Converse_ToolConfig_ToolChoice_Tool = new Amazon.BedrockRuntime.Model.SpecificToolChoice();
                System.String requestInput_input_Converse_input_Converse_ToolConfig_input_Converse_ToolConfig_ToolChoice_input_Converse_ToolConfig_ToolChoice_Tool_tool_Name = null;
                if (cmdletContext.Tool_Name != null)
                {
                    requestInput_input_Converse_input_Converse_ToolConfig_input_Converse_ToolConfig_ToolChoice_input_Converse_ToolConfig_ToolChoice_Tool_tool_Name = cmdletContext.Tool_Name;
                }
                if (requestInput_input_Converse_input_Converse_ToolConfig_input_Converse_ToolConfig_ToolChoice_input_Converse_ToolConfig_ToolChoice_Tool_tool_Name != null)
                {
                    requestInput_input_Converse_input_Converse_ToolConfig_input_Converse_ToolConfig_ToolChoice_input_Converse_ToolConfig_ToolChoice_Tool.Name = requestInput_input_Converse_input_Converse_ToolConfig_input_Converse_ToolConfig_ToolChoice_input_Converse_ToolConfig_ToolChoice_Tool_tool_Name;
                    requestInput_input_Converse_input_Converse_ToolConfig_input_Converse_ToolConfig_ToolChoice_input_Converse_ToolConfig_ToolChoice_ToolIsNull = false;
                }
                 // determine if requestInput_input_Converse_input_Converse_ToolConfig_input_Converse_ToolConfig_ToolChoice_input_Converse_ToolConfig_ToolChoice_Tool should be set to null
                if (requestInput_input_Converse_input_Converse_ToolConfig_input_Converse_ToolConfig_ToolChoice_input_Converse_ToolConfig_ToolChoice_ToolIsNull)
                {
                    requestInput_input_Converse_input_Converse_ToolConfig_input_Converse_ToolConfig_ToolChoice_input_Converse_ToolConfig_ToolChoice_Tool = null;
                }
                if (requestInput_input_Converse_input_Converse_ToolConfig_input_Converse_ToolConfig_ToolChoice_input_Converse_ToolConfig_ToolChoice_Tool != null)
                {
                    requestInput_input_Converse_input_Converse_ToolConfig_input_Converse_ToolConfig_ToolChoice.Tool = requestInput_input_Converse_input_Converse_ToolConfig_input_Converse_ToolConfig_ToolChoice_input_Converse_ToolConfig_ToolChoice_Tool;
                    requestInput_input_Converse_input_Converse_ToolConfig_input_Converse_ToolConfig_ToolChoiceIsNull = false;
                }
                 // determine if requestInput_input_Converse_input_Converse_ToolConfig_input_Converse_ToolConfig_ToolChoice should be set to null
                if (requestInput_input_Converse_input_Converse_ToolConfig_input_Converse_ToolConfig_ToolChoiceIsNull)
                {
                    requestInput_input_Converse_input_Converse_ToolConfig_input_Converse_ToolConfig_ToolChoice = null;
                }
                if (requestInput_input_Converse_input_Converse_ToolConfig_input_Converse_ToolConfig_ToolChoice != null)
                {
                    requestInput_input_Converse_input_Converse_ToolConfig.ToolChoice = requestInput_input_Converse_input_Converse_ToolConfig_input_Converse_ToolConfig_ToolChoice;
                    requestInput_input_Converse_input_Converse_ToolConfigIsNull = false;
                }
                 // determine if requestInput_input_Converse_input_Converse_ToolConfig should be set to null
                if (requestInput_input_Converse_input_Converse_ToolConfigIsNull)
                {
                    requestInput_input_Converse_input_Converse_ToolConfig = null;
                }
                if (requestInput_input_Converse_input_Converse_ToolConfig != null)
                {
                    requestInput_input_Converse.ToolConfig = requestInput_input_Converse_input_Converse_ToolConfig;
                    requestInput_input_ConverseIsNull = false;
                }
                 // determine if requestInput_input_Converse should be set to null
                if (requestInput_input_ConverseIsNull)
                {
                    requestInput_input_Converse = null;
                }
                if (requestInput_input_Converse != null)
                {
                    request.Input.Converse = requestInput_input_Converse;
                    requestInputIsNull = false;
                }
                 // determine if request.Input should be set to null
                if (requestInputIsNull)
                {
                    request.Input = null;
                }
                if (cmdletContext.ModelId != null)
                {
                    request.ModelId = cmdletContext.ModelId;
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
            finally
            {
                if( _InvokeModel_BodyStream != null)
                {
                    _InvokeModel_BodyStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.BedrockRuntime.Model.CountTokensResponse CallAWSServiceOperation(IAmazonBedrockRuntime client, Amazon.BedrockRuntime.Model.CountTokensRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Runtime", "CountTokens");
            try
            {
                return client.CountTokensAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Management.Automation.PSObject Converse_AdditionalModelRequestField { get; set; }
            public List<Amazon.BedrockRuntime.Model.Message> Converse_Message { get; set; }
            public List<Amazon.BedrockRuntime.Model.SystemContentBlock> Converse_System { get; set; }
            public Amazon.BedrockRuntime.Model.AnyToolChoice ToolChoice_Any { get; set; }
            public Amazon.BedrockRuntime.Model.AutoToolChoice ToolChoice_Auto { get; set; }
            public System.String Tool_Name { get; set; }
            public List<Amazon.BedrockRuntime.Model.Tool> ToolConfig_Tool { get; set; }
            public byte[] InvokeModel_Body { get; set; }
            public System.String ModelId { get; set; }
            public System.Func<Amazon.BedrockRuntime.Model.CountTokensResponse, GetBDRRCountTokenCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InputTokens;
        }
        
    }
}
