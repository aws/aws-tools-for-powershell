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
using Amazon.Bedrock;
using Amazon.Bedrock.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BDR
{
    /// <summary>
    /// Creates a new custom model in Amazon Bedrock. After the model is active, you can use
    /// it for inference.
    /// 
    ///  
    /// <para>
    /// To use the model for inference, you must purchase Provisioned Throughput for it. You
    /// can't use On-demand inference with these custom models. For more information about
    /// Provisioned Throughput, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/prov-throughput.html">Provisioned
    /// Throughput</a>.
    /// </para><para>
    /// The model appears in <c>ListCustomModels</c> with a <c>customizationType</c> of <c>imported</c>.
    /// To track the status of the new model, you use the <c>GetCustomModel</c> API operation.
    /// The model can be in the following states:
    /// </para><ul><li><para><c>Creating</c> - Initial state during validation and registration
    /// </para></li><li><para><c>Active</c> - Model is ready for use in inference
    /// </para></li><li><para><c>Failed</c> - Creation process encountered an error
    /// </para></li></ul><para><b>Related APIs</b></para><ul><li><para><a href="https://docs.aws.amazon.com/bedrock/latest/APIReference/API_GetCustomModel.html">GetCustomModel</a></para></li><li><para><a href="https://docs.aws.amazon.com/bedrock/latest/APIReference/API_ListCustomModels.html">ListCustomModels</a></para></li><li><para><a href="https://docs.aws.amazon.com/bedrock/latest/APIReference/API_DeleteCustomModel.html">DeleteCustomModel</a></para></li></ul>
    /// </summary>
    [Cmdlet("New", "BDRCustomModel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Bedrock CreateCustomModel API operation.", Operation = new[] {"CreateCustomModel"}, SelectReturnType = typeof(Amazon.Bedrock.Model.CreateCustomModelResponse))]
    [AWSCmdletOutput("System.String or Amazon.Bedrock.Model.CreateCustomModelResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Bedrock.Model.CreateCustomModelResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewBDRCustomModelCmdlet : AmazonBedrockClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the API request completes no more
        /// than one time. If this token matches a previous request, Amazon Bedrock ignores the
        /// request, but does not return an error. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter ModelKmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the customer managed KMS key to encrypt the custom
        /// model. If you don't provide a KMS key, Amazon Bedrock uses an Amazon Web Services-managed
        /// KMS key to encrypt the model. </para><para>If you provide a customer managed KMS key, your Amazon Bedrock service role must have
        /// permissions to use it. For more information see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/encryption-import-model.html">Encryption
        /// of imported models</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelKmsKeyArn { get; set; }
        #endregion
        
        #region Parameter ModelName
        /// <summary>
        /// <para>
        /// <para>A unique name for the custom model.</para>
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
        public System.String ModelName { get; set; }
        #endregion
        
        #region Parameter ModelTag
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs to associate with the custom model resource. You can use
        /// these tags to organize and identify your resources.</para><para>For more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/tagging.html">Tagging
        /// resources</a> in the <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/what-is-service.html">Amazon
        /// Bedrock User Guide</a>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelTags")]
        public Amazon.Bedrock.Model.Tag[] ModelTag { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM service role that Amazon Bedrock assumes
        /// to perform tasks on your behalf. This role must have permissions to access the Amazon
        /// S3 bucket containing your model artifacts and the KMS key (if specified). For more
        /// information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/model-import-iam-role.html">Setting
        /// up an IAM service role for importing models</a> in the Amazon Bedrock User Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter S3DataSource_S3Uri
        /// <summary>
        /// <para>
        /// <para>The URI of the Amazon S3 data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelSourceConfig_S3DataSource_S3Uri")]
        public System.String S3DataSource_S3Uri { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ModelArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Bedrock.Model.CreateCustomModelResponse).
        /// Specifying the name of a property of type Amazon.Bedrock.Model.CreateCustomModelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ModelArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ModelName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BDRCustomModel (CreateCustomModel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Bedrock.Model.CreateCustomModelResponse, NewBDRCustomModelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.ModelKmsKeyArn = this.ModelKmsKeyArn;
            context.ModelName = this.ModelName;
            #if MODULAR
            if (this.ModelName == null && ParameterWasBound(nameof(this.ModelName)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3DataSource_S3Uri = this.S3DataSource_S3Uri;
            if (this.ModelTag != null)
            {
                context.ModelTag = new List<Amazon.Bedrock.Model.Tag>(this.ModelTag);
            }
            context.RoleArn = this.RoleArn;
            
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
            var request = new Amazon.Bedrock.Model.CreateCustomModelRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.ModelKmsKeyArn != null)
            {
                request.ModelKmsKeyArn = cmdletContext.ModelKmsKeyArn;
            }
            if (cmdletContext.ModelName != null)
            {
                request.ModelName = cmdletContext.ModelName;
            }
            
             // populate ModelSourceConfig
            var requestModelSourceConfigIsNull = true;
            request.ModelSourceConfig = new Amazon.Bedrock.Model.ModelDataSource();
            Amazon.Bedrock.Model.S3DataSource requestModelSourceConfig_modelSourceConfig_S3DataSource = null;
            
             // populate S3DataSource
            var requestModelSourceConfig_modelSourceConfig_S3DataSourceIsNull = true;
            requestModelSourceConfig_modelSourceConfig_S3DataSource = new Amazon.Bedrock.Model.S3DataSource();
            System.String requestModelSourceConfig_modelSourceConfig_S3DataSource_s3DataSource_S3Uri = null;
            if (cmdletContext.S3DataSource_S3Uri != null)
            {
                requestModelSourceConfig_modelSourceConfig_S3DataSource_s3DataSource_S3Uri = cmdletContext.S3DataSource_S3Uri;
            }
            if (requestModelSourceConfig_modelSourceConfig_S3DataSource_s3DataSource_S3Uri != null)
            {
                requestModelSourceConfig_modelSourceConfig_S3DataSource.S3Uri = requestModelSourceConfig_modelSourceConfig_S3DataSource_s3DataSource_S3Uri;
                requestModelSourceConfig_modelSourceConfig_S3DataSourceIsNull = false;
            }
             // determine if requestModelSourceConfig_modelSourceConfig_S3DataSource should be set to null
            if (requestModelSourceConfig_modelSourceConfig_S3DataSourceIsNull)
            {
                requestModelSourceConfig_modelSourceConfig_S3DataSource = null;
            }
            if (requestModelSourceConfig_modelSourceConfig_S3DataSource != null)
            {
                request.ModelSourceConfig.S3DataSource = requestModelSourceConfig_modelSourceConfig_S3DataSource;
                requestModelSourceConfigIsNull = false;
            }
             // determine if request.ModelSourceConfig should be set to null
            if (requestModelSourceConfigIsNull)
            {
                request.ModelSourceConfig = null;
            }
            if (cmdletContext.ModelTag != null)
            {
                request.ModelTags = cmdletContext.ModelTag;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
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
        
        private Amazon.Bedrock.Model.CreateCustomModelResponse CallAWSServiceOperation(IAmazonBedrock client, Amazon.Bedrock.Model.CreateCustomModelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock", "CreateCustomModel");
            try
            {
                return client.CreateCustomModelAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ModelKmsKeyArn { get; set; }
            public System.String ModelName { get; set; }
            public System.String S3DataSource_S3Uri { get; set; }
            public List<Amazon.Bedrock.Model.Tag> ModelTag { get; set; }
            public System.String RoleArn { get; set; }
            public System.Func<Amazon.Bedrock.Model.CreateCustomModelResponse, NewBDRCustomModelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ModelArn;
        }
        
    }
}
