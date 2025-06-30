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
using Amazon.BedrockRuntime;
using Amazon.BedrockRuntime.Model;

namespace Amazon.PowerShell.Cmdlets.BDRR
{
    /// <summary>
    /// Invoke the specified Amazon Bedrock model to run inference using the prompt and inference
    /// parameters provided in the request body. The response is returned in a stream.
    /// 
    ///  
    /// <para>
    /// To see if a model supports streaming, call <a href="https://docs.aws.amazon.com/bedrock/latest/APIReference/API_GetFoundationModel.html">GetFoundationModel</a>
    /// and check the <c>responseStreamingSupported</c> field in the response.
    /// </para><note><para>
    /// The CLI doesn't support streaming operations in Amazon Bedrock, including <c>InvokeModelWithResponseStream</c>.
    /// </para></note><para>
    /// For example code, see <i>Invoke model with streaming code example</i> in the <i>Amazon
    /// Bedrock User Guide</i>. 
    /// </para><para>
    /// This operation requires permissions to perform the <c>bedrock:InvokeModelWithResponseStream</c>
    /// action. 
    /// </para><important><para>
    /// To deny all inference access to resources that you specify in the modelId field, you
    /// need to deny access to the <c>bedrock:InvokeModel</c> and <c>bedrock:InvokeModelWithResponseStream</c>
    /// actions. Doing this also denies access to the resource through the Converse API actions
    /// (<a href="https://docs.aws.amazon.com/bedrock/latest/APIReference/API_runtime_Converse.html">Converse</a>
    /// and <a href="https://docs.aws.amazon.com/bedrock/latest/APIReference/API_runtime_ConverseStream.html">ConverseStream</a>).
    /// For more information see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/security_iam_id-based-policy-examples.html#security_iam_id-based-policy-examples-deny-inference">Deny
    /// access for inference on specific models</a>. 
    /// </para></important><para>
    /// For troubleshooting some of the common errors you might encounter when using the <c>InvokeModelWithResponseStream</c>
    /// API, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/troubleshooting-api-error-codes.html">Troubleshooting
    /// Amazon Bedrock API Error Codes</a> in the Amazon Bedrock User Guide
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "BDRRModelWithResponseStream", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockRuntime.Model.InvokeModelWithResponseStreamResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Runtime InvokeModelWithResponseStream API operation.", Operation = new[] {"InvokeModelWithResponseStream"}, SelectReturnType = typeof(Amazon.BedrockRuntime.Model.InvokeModelWithResponseStreamResponse))]
    [AWSCmdletOutput("Amazon.BedrockRuntime.Model.InvokeModelWithResponseStreamResponse",
        "This cmdlet returns an Amazon.BedrockRuntime.Model.InvokeModelWithResponseStreamResponse object containing multiple properties."
    )]
    public partial class InvokeBDRRModelWithResponseStreamCmdlet : AmazonBedrockRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Accept
        /// <summary>
        /// <para>
        /// <para>The desired MIME type of the inference body in the response. The default value is
        /// <c>application/json</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Accept { get; set; }
        #endregion
        
        #region Parameter Body
        /// <summary>
        /// <para>
        /// <para>The prompt and inference parameters in the format specified in the <c>contentType</c>
        /// in the header. You must provide the body in JSON format. To see the format and content
        /// of the request and response bodies for different models, refer to <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/model-parameters.html">Inference
        /// parameters</a>. For more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/api-methods-run.html">Run
        /// inference</a> in the Bedrock User Guide.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Body { get; set; }
        #endregion
        
        #region Parameter ContentType
        /// <summary>
        /// <para>
        /// <para>The MIME type of the input data in the request. You must specify <c>application/json</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContentType { get; set; }
        #endregion
        
        #region Parameter GuardrailIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the guardrail that you want to use. If you don't provide
        /// a value, no guardrail is applied to the invocation.</para><para>An error is thrown in the following situations.</para><ul><li><para>You don't provide a guardrail identifier but you specify the <c>amazon-bedrock-guardrailConfig</c>
        /// field in the request body.</para></li><li><para>You enable the guardrail but the <c>contentType</c> isn't <c>application/json</c>.</para></li><li><para>You provide a guardrail identifier, but <c>guardrailVersion</c> isn't specified.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GuardrailIdentifier { get; set; }
        #endregion
        
        #region Parameter GuardrailVersion
        /// <summary>
        /// <para>
        /// <para>The version number for the guardrail. The value can also be <c>DRAFT</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GuardrailVersion { get; set; }
        #endregion
        
        #region Parameter ModelId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the model to invoke to run inference.</para><para>The <c>modelId</c> to provide depends on the type of model or throughput that you
        /// use:</para><ul><li><para>If you use a base model, specify the model ID or its ARN. For a list of model IDs
        /// for base models, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/model-ids.html#model-ids-arns">Amazon
        /// Bedrock base model IDs (on-demand throughput)</a> in the Amazon Bedrock User Guide.</para></li><li><para>If you use an inference profile, specify the inference profile ID or its ARN. For
        /// a list of inference profile IDs, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/cross-region-inference-support.html">Supported
        /// Regions and models for cross-region inference</a> in the Amazon Bedrock User Guide.</para></li><li><para>If you use a provisioned model, specify the ARN of the Provisioned Throughput. For
        /// more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/prov-thru-use.html">Run
        /// inference using a Provisioned Throughput</a> in the Amazon Bedrock User Guide.</para></li><li><para>If you use a custom model, specify the ARN of the custom model deployment (for on-demand
        /// inference) or the ARN of your provisioned model (for Provisioned Throughput). For
        /// more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/model-customization-use.html">Use
        /// a custom model in Amazon Bedrock</a> in the Amazon Bedrock User Guide.</para></li><li><para>If you use an <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/model-customization-import-model.html">imported
        /// model</a>, specify the ARN of the imported model. You can get the model ARN from a
        /// successful call to <a href="https://docs.aws.amazon.com/bedrock/latest/APIReference/API_CreateModelImportJob.html">CreateModelImportJob</a>
        /// or from the Imported models page in the Amazon Bedrock console.</para></li></ul>
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
        
        #region Parameter PerformanceConfigLatency
        /// <summary>
        /// <para>
        /// <para>Model performance settings for the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockRuntime.PerformanceConfigLatency")]
        public Amazon.BedrockRuntime.PerformanceConfigLatency PerformanceConfigLatency { get; set; }
        #endregion
        
        #region Parameter Trace
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable or disable the Bedrock trace. If enabled, you can see
        /// the full Bedrock trace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockRuntime.Trace")]
        public Amazon.BedrockRuntime.Trace Trace { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockRuntime.Model.InvokeModelWithResponseStreamResponse).
        /// Specifying the name of a property of type Amazon.BedrockRuntime.Model.InvokeModelWithResponseStreamResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ModelId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ModelId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ModelId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ModelId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-BDRRModelWithResponseStream (InvokeModelWithResponseStream)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockRuntime.Model.InvokeModelWithResponseStreamResponse, InvokeBDRRModelWithResponseStreamCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ModelId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Accept = this.Accept;
            context.Body = this.Body;
            context.ContentType = this.ContentType;
            context.GuardrailIdentifier = this.GuardrailIdentifier;
            context.GuardrailVersion = this.GuardrailVersion;
            context.ModelId = this.ModelId;
            #if MODULAR
            if (this.ModelId == null && ParameterWasBound(nameof(this.ModelId)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PerformanceConfigLatency = this.PerformanceConfigLatency;
            context.Trace = this.Trace;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _BodyStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.BedrockRuntime.Model.InvokeModelWithResponseStreamRequest();
                
                if (cmdletContext.Accept != null)
                {
                    request.Accept = cmdletContext.Accept;
                }
                if (cmdletContext.Body != null)
                {
                    _BodyStream = new System.IO.MemoryStream(cmdletContext.Body);
                    request.Body = _BodyStream;
                }
                if (cmdletContext.ContentType != null)
                {
                    request.ContentType = cmdletContext.ContentType;
                }
                if (cmdletContext.GuardrailIdentifier != null)
                {
                    request.GuardrailIdentifier = cmdletContext.GuardrailIdentifier;
                }
                if (cmdletContext.GuardrailVersion != null)
                {
                    request.GuardrailVersion = cmdletContext.GuardrailVersion;
                }
                if (cmdletContext.ModelId != null)
                {
                    request.ModelId = cmdletContext.ModelId;
                }
                if (cmdletContext.PerformanceConfigLatency != null)
                {
                    request.PerformanceConfigLatency = cmdletContext.PerformanceConfigLatency;
                }
                if (cmdletContext.Trace != null)
                {
                    request.Trace = cmdletContext.Trace;
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
                if( _BodyStream != null)
                {
                    _BodyStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.BedrockRuntime.Model.InvokeModelWithResponseStreamResponse CallAWSServiceOperation(IAmazonBedrockRuntime client, Amazon.BedrockRuntime.Model.InvokeModelWithResponseStreamRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Runtime", "InvokeModelWithResponseStream");
            try
            {
                #if DESKTOP
                return client.InvokeModelWithResponseStream(request);
                #elif CORECLR
                return client.InvokeModelWithResponseStreamAsync(request).GetAwaiter().GetResult();
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
            public System.String Accept { get; set; }
            public byte[] Body { get; set; }
            public System.String ContentType { get; set; }
            public System.String GuardrailIdentifier { get; set; }
            public System.String GuardrailVersion { get; set; }
            public System.String ModelId { get; set; }
            public Amazon.BedrockRuntime.PerformanceConfigLatency PerformanceConfigLatency { get; set; }
            public Amazon.BedrockRuntime.Trace Trace { get; set; }
            public System.Func<Amazon.BedrockRuntime.Model.InvokeModelWithResponseStreamResponse, InvokeBDRRModelWithResponseStreamCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
