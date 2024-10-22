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
using Amazon.TranscribeService;
using Amazon.TranscribeService.Model;

namespace Amazon.PowerShell.Cmdlets.TRS
{
    /// <summary>
    /// Creates a new custom language model.
    /// 
    ///  
    /// <para>
    /// When creating a new custom language model, you must specify:
    /// </para><ul><li><para>
    /// If you want a Wideband (audio sample rates over 16,000 Hz) or Narrowband (audio sample
    /// rates under 16,000 Hz) base model
    /// </para></li><li><para>
    /// The location of your training and tuning files (this must be an Amazon S3 URI)
    /// </para></li><li><para>
    /// The language of your model
    /// </para></li><li><para>
    /// A unique name for your model
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("New", "TRSLanguageModel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.TranscribeService.Model.CreateLanguageModelResponse")]
    [AWSCmdlet("Calls the Amazon Transcribe Service CreateLanguageModel API operation.", Operation = new[] {"CreateLanguageModel"}, SelectReturnType = typeof(Amazon.TranscribeService.Model.CreateLanguageModelResponse))]
    [AWSCmdletOutput("Amazon.TranscribeService.Model.CreateLanguageModelResponse",
        "This cmdlet returns an Amazon.TranscribeService.Model.CreateLanguageModelResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewTRSLanguageModelCmdlet : AmazonTranscribeServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BaseModelName
        /// <summary>
        /// <para>
        /// <para>The Amazon Transcribe standard language model, or base model, used to create your
        /// custom language model. Amazon Transcribe offers two options for base models: Wideband
        /// and Narrowband.</para><para>If the audio you want to transcribe has a sample rate of 16,000 Hz or greater, choose
        /// <c>WideBand</c>. To transcribe audio with a sample rate less than 16,000 Hz, choose
        /// <c>NarrowBand</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.TranscribeService.BaseModelName")]
        public Amazon.TranscribeService.BaseModelName BaseModelName { get; set; }
        #endregion
        
        #region Parameter InputDataConfig_DataAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM role that has permissions to access the Amazon
        /// S3 bucket that contains your input files. If the role that you specify doesn’t have
        /// the appropriate permissions to access the specified Amazon S3 location, your request
        /// fails.</para><para>IAM role ARNs have the format <c>arn:partition:iam::account:role/role-name-with-path</c>.
        /// For example: <c>arn:aws:iam::111122223333:role/Admin</c>.</para><para>For more information, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_identifiers.html#identifiers-arns">IAM
        /// ARNs</a>.</para>
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
        public System.String InputDataConfig_DataAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter LanguageCode
        /// <summary>
        /// <para>
        /// <para>The language code that represents the language of your model. Each custom language
        /// model must contain terms in only one language, and the language you select for your
        /// custom language model must match the language of your training and tuning data.</para><para>For a list of supported languages and their associated language codes, refer to the
        /// <a href="https://docs.aws.amazon.com/transcribe/latest/dg/supported-languages.html">Supported
        /// languages</a> table. Note that US English (<c>en-US</c>) is the only language supported
        /// with Amazon Transcribe Medical.</para><para>A custom language model can only be used to transcribe files in the same language
        /// as the model. For example, if you create a custom language model using US English
        /// (<c>en-US</c>), you can only apply this model to files that contain English audio.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.TranscribeService.CLMLanguageCode")]
        public Amazon.TranscribeService.CLMLanguageCode LanguageCode { get; set; }
        #endregion
        
        #region Parameter ModelName
        /// <summary>
        /// <para>
        /// <para>A unique name, chosen by you, for your custom language model.</para><para>This name is case sensitive, cannot contain spaces, and must be unique within an Amazon
        /// Web Services account. If you try to create a new custom language model with the same
        /// name as an existing custom language model, you get a <c>ConflictException</c> error.</para>
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
        
        #region Parameter InputDataConfig_S3Uri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 location (URI) of the text files you want to use to train your custom
        /// language model.</para><para>Here's an example URI path: <c>s3://DOC-EXAMPLE-BUCKET/my-model-training-data/</c></para>
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
        public System.String InputDataConfig_S3Uri { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Adds one or more custom tags, each in the form of a key:value pair, to a new custom
        /// language model at the time you create this new model.</para><para>To learn more about using tags with Amazon Transcribe, refer to <a href="https://docs.aws.amazon.com/transcribe/latest/dg/tagging.html">Tagging
        /// resources</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.TranscribeService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter InputDataConfig_TuningDataS3Uri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 location (URI) of the text files you want to use to tune your custom
        /// language model.</para><para>Here's an example URI path: <c>s3://DOC-EXAMPLE-BUCKET/my-model-tuning-data/</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InputDataConfig_TuningDataS3Uri { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TranscribeService.Model.CreateLanguageModelResponse).
        /// Specifying the name of a property of type Amazon.TranscribeService.Model.CreateLanguageModelResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ModelName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-TRSLanguageModel (CreateLanguageModel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TranscribeService.Model.CreateLanguageModelResponse, NewTRSLanguageModelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BaseModelName = this.BaseModelName;
            #if MODULAR
            if (this.BaseModelName == null && ParameterWasBound(nameof(this.BaseModelName)))
            {
                WriteWarning("You are passing $null as a value for parameter BaseModelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InputDataConfig_DataAccessRoleArn = this.InputDataConfig_DataAccessRoleArn;
            #if MODULAR
            if (this.InputDataConfig_DataAccessRoleArn == null && ParameterWasBound(nameof(this.InputDataConfig_DataAccessRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter InputDataConfig_DataAccessRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InputDataConfig_S3Uri = this.InputDataConfig_S3Uri;
            #if MODULAR
            if (this.InputDataConfig_S3Uri == null && ParameterWasBound(nameof(this.InputDataConfig_S3Uri)))
            {
                WriteWarning("You are passing $null as a value for parameter InputDataConfig_S3Uri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InputDataConfig_TuningDataS3Uri = this.InputDataConfig_TuningDataS3Uri;
            context.LanguageCode = this.LanguageCode;
            #if MODULAR
            if (this.LanguageCode == null && ParameterWasBound(nameof(this.LanguageCode)))
            {
                WriteWarning("You are passing $null as a value for parameter LanguageCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ModelName = this.ModelName;
            #if MODULAR
            if (this.ModelName == null && ParameterWasBound(nameof(this.ModelName)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.TranscribeService.Model.Tag>(this.Tag);
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
            var request = new Amazon.TranscribeService.Model.CreateLanguageModelRequest();
            
            if (cmdletContext.BaseModelName != null)
            {
                request.BaseModelName = cmdletContext.BaseModelName;
            }
            
             // populate InputDataConfig
            var requestInputDataConfigIsNull = true;
            request.InputDataConfig = new Amazon.TranscribeService.Model.InputDataConfig();
            System.String requestInputDataConfig_inputDataConfig_DataAccessRoleArn = null;
            if (cmdletContext.InputDataConfig_DataAccessRoleArn != null)
            {
                requestInputDataConfig_inputDataConfig_DataAccessRoleArn = cmdletContext.InputDataConfig_DataAccessRoleArn;
            }
            if (requestInputDataConfig_inputDataConfig_DataAccessRoleArn != null)
            {
                request.InputDataConfig.DataAccessRoleArn = requestInputDataConfig_inputDataConfig_DataAccessRoleArn;
                requestInputDataConfigIsNull = false;
            }
            System.String requestInputDataConfig_inputDataConfig_S3Uri = null;
            if (cmdletContext.InputDataConfig_S3Uri != null)
            {
                requestInputDataConfig_inputDataConfig_S3Uri = cmdletContext.InputDataConfig_S3Uri;
            }
            if (requestInputDataConfig_inputDataConfig_S3Uri != null)
            {
                request.InputDataConfig.S3Uri = requestInputDataConfig_inputDataConfig_S3Uri;
                requestInputDataConfigIsNull = false;
            }
            System.String requestInputDataConfig_inputDataConfig_TuningDataS3Uri = null;
            if (cmdletContext.InputDataConfig_TuningDataS3Uri != null)
            {
                requestInputDataConfig_inputDataConfig_TuningDataS3Uri = cmdletContext.InputDataConfig_TuningDataS3Uri;
            }
            if (requestInputDataConfig_inputDataConfig_TuningDataS3Uri != null)
            {
                request.InputDataConfig.TuningDataS3Uri = requestInputDataConfig_inputDataConfig_TuningDataS3Uri;
                requestInputDataConfigIsNull = false;
            }
             // determine if request.InputDataConfig should be set to null
            if (requestInputDataConfigIsNull)
            {
                request.InputDataConfig = null;
            }
            if (cmdletContext.LanguageCode != null)
            {
                request.LanguageCode = cmdletContext.LanguageCode;
            }
            if (cmdletContext.ModelName != null)
            {
                request.ModelName = cmdletContext.ModelName;
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
        
        private Amazon.TranscribeService.Model.CreateLanguageModelResponse CallAWSServiceOperation(IAmazonTranscribeService client, Amazon.TranscribeService.Model.CreateLanguageModelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Transcribe Service", "CreateLanguageModel");
            try
            {
                #if DESKTOP
                return client.CreateLanguageModel(request);
                #elif CORECLR
                return client.CreateLanguageModelAsync(request).GetAwaiter().GetResult();
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
            public Amazon.TranscribeService.BaseModelName BaseModelName { get; set; }
            public System.String InputDataConfig_DataAccessRoleArn { get; set; }
            public System.String InputDataConfig_S3Uri { get; set; }
            public System.String InputDataConfig_TuningDataS3Uri { get; set; }
            public Amazon.TranscribeService.CLMLanguageCode LanguageCode { get; set; }
            public System.String ModelName { get; set; }
            public List<Amazon.TranscribeService.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.TranscribeService.Model.CreateLanguageModelResponse, NewTRSLanguageModelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
