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
using Amazon.Bedrock;
using Amazon.Bedrock.Model;

namespace Amazon.PowerShell.Cmdlets.BDR
{
    /// <summary>
    /// Creates a fine-tuning job to customize a base model.
    /// 
    ///  
    /// <para>
    /// You specify the base foundation model and the location of the training data. After
    /// the model-customization job completes successfully, your custom model resource will
    /// be ready to use. Training data contains input and output text for each record in a
    /// JSONL format. Optionally, you can specify validation data in the same format as the
    /// training data. Bedrock returns validation loss metrics and output generations after
    /// the job completes. 
    /// </para><para>
    ///  Model-customization jobs are asynchronous and the completion time depends on the
    /// base model and the training/validation data size. To monitor a job, use the <code>GetModelCustomizationJob</code>
    /// operation to retrieve the job status.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/custom-models.html">Custom
    /// models</a> in the Bedrock User Guide.
    /// </para>
    /// </summary>
    [Cmdlet("New", "BDRModelCustomizationJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Bedrock CreateModelCustomizationJob API operation.", Operation = new[] {"CreateModelCustomizationJob"}, SelectReturnType = typeof(Amazon.Bedrock.Model.CreateModelCustomizationJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.Bedrock.Model.CreateModelCustomizationJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Bedrock.Model.CreateModelCustomizationJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewBDRModelCustomizationJobCmdlet : AmazonBedrockClientCmdlet, IExecutor
    {
        
        #region Parameter BaseModelIdentifier
        /// <summary>
        /// <para>
        /// <para>Name of the base model.</para>
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
        public System.String BaseModelIdentifier { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>Unique token value that you can provide. The GetModelCustomizationJob response includes
        /// the same token value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter CustomModelKmsKeyId
        /// <summary>
        /// <para>
        /// <para>The custom model is encrypted at rest using this key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomModelKmsKeyId { get; set; }
        #endregion
        
        #region Parameter CustomModelName
        /// <summary>
        /// <para>
        /// <para>Enter a name for the custom model.</para>
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
        public System.String CustomModelName { get; set; }
        #endregion
        
        #region Parameter CustomModelTag
        /// <summary>
        /// <para>
        /// <para>Assign tags to the custom model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomModelTags")]
        public Amazon.Bedrock.Model.Tag[] CustomModelTag { get; set; }
        #endregion
        
        #region Parameter HyperParameter
        /// <summary>
        /// <para>
        /// <para>Parameters related to tuning the model.</para>
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
        [Alias("HyperParameters")]
        public System.Collections.Hashtable HyperParameter { get; set; }
        #endregion
        
        #region Parameter JobName
        /// <summary>
        /// <para>
        /// <para>Enter a unique name for the fine-tuning job.</para>
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
        public System.String JobName { get; set; }
        #endregion
        
        #region Parameter JobTag
        /// <summary>
        /// <para>
        /// <para>Assign tags to the job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobTags")]
        public Amazon.Bedrock.Model.Tag[] JobTag { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM role that Bedrock can assume to perform tasks
        /// on your behalf. For example, during model training, Bedrock needs your permission
        /// to read input data from an S3 bucket, write model artifacts to an S3 bucket. To pass
        /// this role to Bedrock, the caller of this API must have the <code>iam:PassRole</code>
        /// permission. </para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter OutputDataConfig_S3Uri
        /// <summary>
        /// <para>
        /// <para>The S3 URI where the output data is stored.</para>
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
        public System.String OutputDataConfig_S3Uri { get; set; }
        #endregion
        
        #region Parameter TrainingDataConfig_S3Uri
        /// <summary>
        /// <para>
        /// <para>The S3 URI where the training data is stored.</para>
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
        public System.String TrainingDataConfig_S3Uri { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>VPC configuration security group Ids.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfig_SecurityGroupIds")]
        public System.String[] VpcConfig_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SubnetId
        /// <summary>
        /// <para>
        /// <para>VPC configuration subnets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfig_SubnetIds")]
        public System.String[] VpcConfig_SubnetId { get; set; }
        #endregion
        
        #region Parameter ValidationDataConfig_Validator
        /// <summary>
        /// <para>
        /// <para>Information about the validators.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValidationDataConfig_Validators")]
        public Amazon.Bedrock.Model.Validator[] ValidationDataConfig_Validator { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Bedrock.Model.CreateModelCustomizationJobResponse).
        /// Specifying the name of a property of type Amazon.Bedrock.Model.CreateModelCustomizationJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.JobName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BDRModelCustomizationJob (CreateModelCustomizationJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Bedrock.Model.CreateModelCustomizationJobResponse, NewBDRModelCustomizationJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BaseModelIdentifier = this.BaseModelIdentifier;
            #if MODULAR
            if (this.BaseModelIdentifier == null && ParameterWasBound(nameof(this.BaseModelIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter BaseModelIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientRequestToken = this.ClientRequestToken;
            context.CustomModelKmsKeyId = this.CustomModelKmsKeyId;
            context.CustomModelName = this.CustomModelName;
            #if MODULAR
            if (this.CustomModelName == null && ParameterWasBound(nameof(this.CustomModelName)))
            {
                WriteWarning("You are passing $null as a value for parameter CustomModelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.CustomModelTag != null)
            {
                context.CustomModelTag = new List<Amazon.Bedrock.Model.Tag>(this.CustomModelTag);
            }
            if (this.HyperParameter != null)
            {
                context.HyperParameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.HyperParameter.Keys)
                {
                    context.HyperParameter.Add((String)hashKey, (String)(this.HyperParameter[hashKey]));
                }
            }
            #if MODULAR
            if (this.HyperParameter == null && ParameterWasBound(nameof(this.HyperParameter)))
            {
                WriteWarning("You are passing $null as a value for parameter HyperParameter which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.JobName = this.JobName;
            #if MODULAR
            if (this.JobName == null && ParameterWasBound(nameof(this.JobName)))
            {
                WriteWarning("You are passing $null as a value for parameter JobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.JobTag != null)
            {
                context.JobTag = new List<Amazon.Bedrock.Model.Tag>(this.JobTag);
            }
            context.OutputDataConfig_S3Uri = this.OutputDataConfig_S3Uri;
            #if MODULAR
            if (this.OutputDataConfig_S3Uri == null && ParameterWasBound(nameof(this.OutputDataConfig_S3Uri)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputDataConfig_S3Uri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TrainingDataConfig_S3Uri = this.TrainingDataConfig_S3Uri;
            #if MODULAR
            if (this.TrainingDataConfig_S3Uri == null && ParameterWasBound(nameof(this.TrainingDataConfig_S3Uri)))
            {
                WriteWarning("You are passing $null as a value for parameter TrainingDataConfig_S3Uri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ValidationDataConfig_Validator != null)
            {
                context.ValidationDataConfig_Validator = new List<Amazon.Bedrock.Model.Validator>(this.ValidationDataConfig_Validator);
            }
            if (this.VpcConfig_SecurityGroupId != null)
            {
                context.VpcConfig_SecurityGroupId = new List<System.String>(this.VpcConfig_SecurityGroupId);
            }
            if (this.VpcConfig_SubnetId != null)
            {
                context.VpcConfig_SubnetId = new List<System.String>(this.VpcConfig_SubnetId);
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
            var request = new Amazon.Bedrock.Model.CreateModelCustomizationJobRequest();
            
            if (cmdletContext.BaseModelIdentifier != null)
            {
                request.BaseModelIdentifier = cmdletContext.BaseModelIdentifier;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.CustomModelKmsKeyId != null)
            {
                request.CustomModelKmsKeyId = cmdletContext.CustomModelKmsKeyId;
            }
            if (cmdletContext.CustomModelName != null)
            {
                request.CustomModelName = cmdletContext.CustomModelName;
            }
            if (cmdletContext.CustomModelTag != null)
            {
                request.CustomModelTags = cmdletContext.CustomModelTag;
            }
            if (cmdletContext.HyperParameter != null)
            {
                request.HyperParameters = cmdletContext.HyperParameter;
            }
            if (cmdletContext.JobName != null)
            {
                request.JobName = cmdletContext.JobName;
            }
            if (cmdletContext.JobTag != null)
            {
                request.JobTags = cmdletContext.JobTag;
            }
            
             // populate OutputDataConfig
            var requestOutputDataConfigIsNull = true;
            request.OutputDataConfig = new Amazon.Bedrock.Model.OutputDataConfig();
            System.String requestOutputDataConfig_outputDataConfig_S3Uri = null;
            if (cmdletContext.OutputDataConfig_S3Uri != null)
            {
                requestOutputDataConfig_outputDataConfig_S3Uri = cmdletContext.OutputDataConfig_S3Uri;
            }
            if (requestOutputDataConfig_outputDataConfig_S3Uri != null)
            {
                request.OutputDataConfig.S3Uri = requestOutputDataConfig_outputDataConfig_S3Uri;
                requestOutputDataConfigIsNull = false;
            }
             // determine if request.OutputDataConfig should be set to null
            if (requestOutputDataConfigIsNull)
            {
                request.OutputDataConfig = null;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            
             // populate TrainingDataConfig
            var requestTrainingDataConfigIsNull = true;
            request.TrainingDataConfig = new Amazon.Bedrock.Model.TrainingDataConfig();
            System.String requestTrainingDataConfig_trainingDataConfig_S3Uri = null;
            if (cmdletContext.TrainingDataConfig_S3Uri != null)
            {
                requestTrainingDataConfig_trainingDataConfig_S3Uri = cmdletContext.TrainingDataConfig_S3Uri;
            }
            if (requestTrainingDataConfig_trainingDataConfig_S3Uri != null)
            {
                request.TrainingDataConfig.S3Uri = requestTrainingDataConfig_trainingDataConfig_S3Uri;
                requestTrainingDataConfigIsNull = false;
            }
             // determine if request.TrainingDataConfig should be set to null
            if (requestTrainingDataConfigIsNull)
            {
                request.TrainingDataConfig = null;
            }
            
             // populate ValidationDataConfig
            var requestValidationDataConfigIsNull = true;
            request.ValidationDataConfig = new Amazon.Bedrock.Model.ValidationDataConfig();
            List<Amazon.Bedrock.Model.Validator> requestValidationDataConfig_validationDataConfig_Validator = null;
            if (cmdletContext.ValidationDataConfig_Validator != null)
            {
                requestValidationDataConfig_validationDataConfig_Validator = cmdletContext.ValidationDataConfig_Validator;
            }
            if (requestValidationDataConfig_validationDataConfig_Validator != null)
            {
                request.ValidationDataConfig.Validators = requestValidationDataConfig_validationDataConfig_Validator;
                requestValidationDataConfigIsNull = false;
            }
             // determine if request.ValidationDataConfig should be set to null
            if (requestValidationDataConfigIsNull)
            {
                request.ValidationDataConfig = null;
            }
            
             // populate VpcConfig
            var requestVpcConfigIsNull = true;
            request.VpcConfig = new Amazon.Bedrock.Model.VpcConfig();
            List<System.String> requestVpcConfig_vpcConfig_SecurityGroupId = null;
            if (cmdletContext.VpcConfig_SecurityGroupId != null)
            {
                requestVpcConfig_vpcConfig_SecurityGroupId = cmdletContext.VpcConfig_SecurityGroupId;
            }
            if (requestVpcConfig_vpcConfig_SecurityGroupId != null)
            {
                request.VpcConfig.SecurityGroupIds = requestVpcConfig_vpcConfig_SecurityGroupId;
                requestVpcConfigIsNull = false;
            }
            List<System.String> requestVpcConfig_vpcConfig_SubnetId = null;
            if (cmdletContext.VpcConfig_SubnetId != null)
            {
                requestVpcConfig_vpcConfig_SubnetId = cmdletContext.VpcConfig_SubnetId;
            }
            if (requestVpcConfig_vpcConfig_SubnetId != null)
            {
                request.VpcConfig.SubnetIds = requestVpcConfig_vpcConfig_SubnetId;
                requestVpcConfigIsNull = false;
            }
             // determine if request.VpcConfig should be set to null
            if (requestVpcConfigIsNull)
            {
                request.VpcConfig = null;
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
        
        private Amazon.Bedrock.Model.CreateModelCustomizationJobResponse CallAWSServiceOperation(IAmazonBedrock client, Amazon.Bedrock.Model.CreateModelCustomizationJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock", "CreateModelCustomizationJob");
            try
            {
                #if DESKTOP
                return client.CreateModelCustomizationJob(request);
                #elif CORECLR
                return client.CreateModelCustomizationJobAsync(request).GetAwaiter().GetResult();
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
            public System.String BaseModelIdentifier { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.String CustomModelKmsKeyId { get; set; }
            public System.String CustomModelName { get; set; }
            public List<Amazon.Bedrock.Model.Tag> CustomModelTag { get; set; }
            public Dictionary<System.String, System.String> HyperParameter { get; set; }
            public System.String JobName { get; set; }
            public List<Amazon.Bedrock.Model.Tag> JobTag { get; set; }
            public System.String OutputDataConfig_S3Uri { get; set; }
            public System.String RoleArn { get; set; }
            public System.String TrainingDataConfig_S3Uri { get; set; }
            public List<Amazon.Bedrock.Model.Validator> ValidationDataConfig_Validator { get; set; }
            public List<System.String> VpcConfig_SecurityGroupId { get; set; }
            public List<System.String> VpcConfig_SubnetId { get; set; }
            public System.Func<Amazon.Bedrock.Model.CreateModelCustomizationJobResponse, NewBDRModelCustomizationJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobArn;
        }
        
    }
}
