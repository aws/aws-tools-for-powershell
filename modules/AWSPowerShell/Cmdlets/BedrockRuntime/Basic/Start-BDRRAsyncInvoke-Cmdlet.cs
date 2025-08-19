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
    /// Starts an asynchronous invocation.
    /// 
    ///  
    /// <para>
    /// This operation requires permission for the <c>bedrock:InvokeModel</c> action.
    /// </para><important><para>
    /// To deny all inference access to resources that you specify in the modelId field, you
    /// need to deny access to the <c>bedrock:InvokeModel</c> and <c>bedrock:InvokeModelWithResponseStream</c>
    /// actions. Doing this also denies access to the resource through the Converse API actions
    /// (<a href="https://docs.aws.amazon.com/bedrock/latest/APIReference/API_runtime_Converse.html">Converse</a>
    /// and <a href="https://docs.aws.amazon.com/bedrock/latest/APIReference/API_runtime_ConverseStream.html">ConverseStream</a>).
    /// For more information see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/security_iam_id-based-policy-examples.html#security_iam_id-based-policy-examples-deny-inference">Deny
    /// access for inference on specific models</a>. 
    /// </para></important>
    /// </summary>
    [Cmdlet("Start", "BDRRAsyncInvoke", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Bedrock Runtime StartAsyncInvoke API operation.", Operation = new[] {"StartAsyncInvoke"}, SelectReturnType = typeof(Amazon.BedrockRuntime.Model.StartAsyncInvokeResponse))]
    [AWSCmdletOutput("System.String or Amazon.BedrockRuntime.Model.StartAsyncInvokeResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.BedrockRuntime.Model.StartAsyncInvokeResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartBDRRAsyncInvokeCmdlet : AmazonBedrockRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter S3OutputDataConfig_BucketOwner
        /// <summary>
        /// <para>
        /// <para>If the bucket belongs to another AWS account, specify that account's ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputDataConfig_S3OutputDataConfig_BucketOwner")]
        public System.String S3OutputDataConfig_BucketOwner { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>Specify idempotency token to ensure that requests are not duplicated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter S3OutputDataConfig_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>A KMS encryption key ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputDataConfig_S3OutputDataConfig_KmsKeyId")]
        public System.String S3OutputDataConfig_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter ModelId
        /// <summary>
        /// <para>
        /// <para>The model to invoke.</para>
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
        
        #region Parameter ModelInput
        /// <summary>
        /// <para>
        /// <para>Input to send to the model.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Management.Automation.PSObject ModelInput { get; set; }
        #endregion
        
        #region Parameter S3OutputDataConfig_S3Uri
        /// <summary>
        /// <para>
        /// <para>An object URI starting with <c>s3://</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputDataConfig_S3OutputDataConfig_S3Uri")]
        public System.String S3OutputDataConfig_S3Uri { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to apply to the invocation.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.BedrockRuntime.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InvocationArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockRuntime.Model.StartAsyncInvokeResponse).
        /// Specifying the name of a property of type Amazon.BedrockRuntime.Model.StartAsyncInvokeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InvocationArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ModelId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-BDRRAsyncInvoke (StartAsyncInvoke)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockRuntime.Model.StartAsyncInvokeResponse, StartBDRRAsyncInvokeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.ModelId = this.ModelId;
            #if MODULAR
            if (this.ModelId == null && ParameterWasBound(nameof(this.ModelId)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ModelInput = this.ModelInput;
            #if MODULAR
            if (this.ModelInput == null && ParameterWasBound(nameof(this.ModelInput)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelInput which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3OutputDataConfig_BucketOwner = this.S3OutputDataConfig_BucketOwner;
            context.S3OutputDataConfig_KmsKeyId = this.S3OutputDataConfig_KmsKeyId;
            context.S3OutputDataConfig_S3Uri = this.S3OutputDataConfig_S3Uri;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.BedrockRuntime.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.BedrockRuntime.Model.StartAsyncInvokeRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.ModelId != null)
            {
                request.ModelId = cmdletContext.ModelId;
            }
            if (cmdletContext.ModelInput != null)
            {
                request.ModelInput = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.ModelInput);
            }
            
             // populate OutputDataConfig
            request.OutputDataConfig = new Amazon.BedrockRuntime.Model.AsyncInvokeOutputDataConfig();
            Amazon.BedrockRuntime.Model.AsyncInvokeS3OutputDataConfig requestOutputDataConfig_outputDataConfig_S3OutputDataConfig = null;
            
             // populate S3OutputDataConfig
            var requestOutputDataConfig_outputDataConfig_S3OutputDataConfigIsNull = true;
            requestOutputDataConfig_outputDataConfig_S3OutputDataConfig = new Amazon.BedrockRuntime.Model.AsyncInvokeS3OutputDataConfig();
            System.String requestOutputDataConfig_outputDataConfig_S3OutputDataConfig_s3OutputDataConfig_BucketOwner = null;
            if (cmdletContext.S3OutputDataConfig_BucketOwner != null)
            {
                requestOutputDataConfig_outputDataConfig_S3OutputDataConfig_s3OutputDataConfig_BucketOwner = cmdletContext.S3OutputDataConfig_BucketOwner;
            }
            if (requestOutputDataConfig_outputDataConfig_S3OutputDataConfig_s3OutputDataConfig_BucketOwner != null)
            {
                requestOutputDataConfig_outputDataConfig_S3OutputDataConfig.BucketOwner = requestOutputDataConfig_outputDataConfig_S3OutputDataConfig_s3OutputDataConfig_BucketOwner;
                requestOutputDataConfig_outputDataConfig_S3OutputDataConfigIsNull = false;
            }
            System.String requestOutputDataConfig_outputDataConfig_S3OutputDataConfig_s3OutputDataConfig_KmsKeyId = null;
            if (cmdletContext.S3OutputDataConfig_KmsKeyId != null)
            {
                requestOutputDataConfig_outputDataConfig_S3OutputDataConfig_s3OutputDataConfig_KmsKeyId = cmdletContext.S3OutputDataConfig_KmsKeyId;
            }
            if (requestOutputDataConfig_outputDataConfig_S3OutputDataConfig_s3OutputDataConfig_KmsKeyId != null)
            {
                requestOutputDataConfig_outputDataConfig_S3OutputDataConfig.KmsKeyId = requestOutputDataConfig_outputDataConfig_S3OutputDataConfig_s3OutputDataConfig_KmsKeyId;
                requestOutputDataConfig_outputDataConfig_S3OutputDataConfigIsNull = false;
            }
            System.String requestOutputDataConfig_outputDataConfig_S3OutputDataConfig_s3OutputDataConfig_S3Uri = null;
            if (cmdletContext.S3OutputDataConfig_S3Uri != null)
            {
                requestOutputDataConfig_outputDataConfig_S3OutputDataConfig_s3OutputDataConfig_S3Uri = cmdletContext.S3OutputDataConfig_S3Uri;
            }
            if (requestOutputDataConfig_outputDataConfig_S3OutputDataConfig_s3OutputDataConfig_S3Uri != null)
            {
                requestOutputDataConfig_outputDataConfig_S3OutputDataConfig.S3Uri = requestOutputDataConfig_outputDataConfig_S3OutputDataConfig_s3OutputDataConfig_S3Uri;
                requestOutputDataConfig_outputDataConfig_S3OutputDataConfigIsNull = false;
            }
             // determine if requestOutputDataConfig_outputDataConfig_S3OutputDataConfig should be set to null
            if (requestOutputDataConfig_outputDataConfig_S3OutputDataConfigIsNull)
            {
                requestOutputDataConfig_outputDataConfig_S3OutputDataConfig = null;
            }
            if (requestOutputDataConfig_outputDataConfig_S3OutputDataConfig != null)
            {
                request.OutputDataConfig.S3OutputDataConfig = requestOutputDataConfig_outputDataConfig_S3OutputDataConfig;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.BedrockRuntime.Model.StartAsyncInvokeResponse CallAWSServiceOperation(IAmazonBedrockRuntime client, Amazon.BedrockRuntime.Model.StartAsyncInvokeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Runtime", "StartAsyncInvoke");
            try
            {
                return client.StartAsyncInvokeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.String ModelId { get; set; }
            public System.Management.Automation.PSObject ModelInput { get; set; }
            public System.String S3OutputDataConfig_BucketOwner { get; set; }
            public System.String S3OutputDataConfig_KmsKeyId { get; set; }
            public System.String S3OutputDataConfig_S3Uri { get; set; }
            public List<Amazon.BedrockRuntime.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.BedrockRuntime.Model.StartAsyncInvokeResponse, StartBDRRAsyncInvokeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InvocationArn;
        }
        
    }
}
