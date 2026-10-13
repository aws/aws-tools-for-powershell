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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Creates a training session in Amazon SageMaker. A training session provisions compute
    /// resources for fine-tuning a foundation model using Low-Rank Adaptation (LoRA). After
    /// the session is created, you can submit training operations and sample inference requests
    /// through the Amazon SageMaker Training Session Runtime API.
    /// 
    ///  
    /// <para>
    /// The following operations are related to <c>CreateTrainingSession</c>:
    /// </para><ul><li><para><c>DescribeTrainingSession</c></para></li><li><para><c>ListTrainingSessions</c></para></li><li><para><c>StopTrainingSession</c></para></li><li><para><c>DeleteTrainingSession</c></para></li></ul>
    /// </summary>
    [Cmdlet("New", "SMTrainingSession", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateTrainingSession API operation.", Operation = new[] {"CreateTrainingSession"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateTrainingSessionResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateTrainingSessionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateTrainingSessionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSMTrainingSessionCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ModelConfig_AcceptEula
        /// <summary>
        /// <para>
        /// <para>Specifies whether you accept the end-user license agreement (EULA) for gated models.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ModelConfig_AcceptEula { get; set; }
        #endregion
        
        #region Parameter LoraConfig_Alpha
        /// <summary>
        /// <para>
        /// <para>The Low-Rank Adaptation (LoRA) scaling factor.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? LoraConfig_Alpha { get; set; }
        #endregion
        
        #region Parameter ModelConfig_BaseModelArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the base foundation model from SageMaker Hub.</para>
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
        public System.String ModelConfig_BaseModelArn { get; set; }
        #endregion
        
        #region Parameter OutputConfig_S3Location_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the KMS key used to encrypt output data. If not
        /// specified, the default Amazon S3 encryption is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputConfig_S3Location_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter ModelPackageGroupArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the model package group where checkpoints and fine-tuned
        /// model artifacts are published.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelPackageGroupArn { get; set; }
        #endregion
        
        #region Parameter OutputConfig_S3Location_Path
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 path where training session outputs are stored.</para>
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
        public System.String OutputConfig_S3Location_Path { get; set; }
        #endregion
        
        #region Parameter LoraConfig_Rank
        /// <summary>
        /// <para>
        /// <para>The rank of the Low-Rank Adaptation (LoRA) adapter matrices.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? LoraConfig_Rank { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that Amazon SageMaker assumes to access
        /// resources on your behalf. The role must have permissions to access the output S3 path
        /// and model package group.</para>
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
        
        #region Parameter VpcConfig_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The VPC security group IDs, in the form <c>sg-xxxxxxxx</c>. Specify the security groups
        /// for the VPC that is specified in the <c>Subnets</c> field.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfig_SecurityGroupIds")]
        public System.String[] VpcConfig_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter VpcConfig_Subnet
        /// <summary>
        /// <para>
        /// <para>The ID of the subnets in the VPC to which you want to connect your training job or
        /// model. For information about the availability of specific instance types, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/instance-types-az.html">Supported
        /// Instance Types and Availability Zones</a>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfig_Subnets")]
        public System.String[] VpcConfig_Subnet { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of key-value pairs to apply to the training session as tags. For more information,
        /// see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">Tagging
        /// Amazon Web Services Resources</a>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TrainingSessionName
        /// <summary>
        /// <para>
        /// <para>The name of the training session.</para>
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
        public System.String TrainingSessionName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TrainingSessionArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateTrainingSessionResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateTrainingSessionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TrainingSessionArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TrainingSessionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMTrainingSession (CreateTrainingSession)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateTrainingSessionResponse, NewSMTrainingSessionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.LoraConfig_Alpha = this.LoraConfig_Alpha;
            #if MODULAR
            if (this.LoraConfig_Alpha == null && ParameterWasBound(nameof(this.LoraConfig_Alpha)))
            {
                WriteWarning("You are passing $null as a value for parameter LoraConfig_Alpha which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LoraConfig_Rank = this.LoraConfig_Rank;
            #if MODULAR
            if (this.LoraConfig_Rank == null && ParameterWasBound(nameof(this.LoraConfig_Rank)))
            {
                WriteWarning("You are passing $null as a value for parameter LoraConfig_Rank which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ModelConfig_AcceptEula = this.ModelConfig_AcceptEula;
            context.ModelConfig_BaseModelArn = this.ModelConfig_BaseModelArn;
            #if MODULAR
            if (this.ModelConfig_BaseModelArn == null && ParameterWasBound(nameof(this.ModelConfig_BaseModelArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelConfig_BaseModelArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ModelPackageGroupArn = this.ModelPackageGroupArn;
            context.OutputConfig_S3Location_KmsKeyArn = this.OutputConfig_S3Location_KmsKeyArn;
            context.OutputConfig_S3Location_Path = this.OutputConfig_S3Location_Path;
            #if MODULAR
            if (this.OutputConfig_S3Location_Path == null && ParameterWasBound(nameof(this.OutputConfig_S3Location_Path)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputConfig_S3Location_Path which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
            }
            context.TrainingSessionName = this.TrainingSessionName;
            #if MODULAR
            if (this.TrainingSessionName == null && ParameterWasBound(nameof(this.TrainingSessionName)))
            {
                WriteWarning("You are passing $null as a value for parameter TrainingSessionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.VpcConfig_SecurityGroupId != null)
            {
                context.VpcConfig_SecurityGroupId = new List<System.String>(this.VpcConfig_SecurityGroupId);
            }
            if (this.VpcConfig_Subnet != null)
            {
                context.VpcConfig_Subnet = new List<System.String>(this.VpcConfig_Subnet);
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
            var request = new Amazon.SageMaker.Model.CreateTrainingSessionRequest();
            
            
             // populate LoraConfig
            var requestLoraConfigIsNull = true;
            request.LoraConfig = new Amazon.SageMaker.Model.LoraConfig();
            System.Int32? requestLoraConfig_loraConfig_Alpha = null;
            if (cmdletContext.LoraConfig_Alpha != null)
            {
                requestLoraConfig_loraConfig_Alpha = cmdletContext.LoraConfig_Alpha.Value;
            }
            if (requestLoraConfig_loraConfig_Alpha != null)
            {
                request.LoraConfig.Alpha = requestLoraConfig_loraConfig_Alpha.Value;
                requestLoraConfigIsNull = false;
            }
            System.Int32? requestLoraConfig_loraConfig_Rank = null;
            if (cmdletContext.LoraConfig_Rank != null)
            {
                requestLoraConfig_loraConfig_Rank = cmdletContext.LoraConfig_Rank.Value;
            }
            if (requestLoraConfig_loraConfig_Rank != null)
            {
                request.LoraConfig.Rank = requestLoraConfig_loraConfig_Rank.Value;
                requestLoraConfigIsNull = false;
            }
             // determine if request.LoraConfig should be set to null
            if (requestLoraConfigIsNull)
            {
                request.LoraConfig = null;
            }
            
             // populate ModelConfig
            var requestModelConfigIsNull = true;
            request.ModelConfig = new Amazon.SageMaker.Model.TrainingSessionModelConfig();
            System.Boolean? requestModelConfig_modelConfig_AcceptEula = null;
            if (cmdletContext.ModelConfig_AcceptEula != null)
            {
                requestModelConfig_modelConfig_AcceptEula = cmdletContext.ModelConfig_AcceptEula.Value;
            }
            if (requestModelConfig_modelConfig_AcceptEula != null)
            {
                request.ModelConfig.AcceptEula = requestModelConfig_modelConfig_AcceptEula.Value;
                requestModelConfigIsNull = false;
            }
            System.String requestModelConfig_modelConfig_BaseModelArn = null;
            if (cmdletContext.ModelConfig_BaseModelArn != null)
            {
                requestModelConfig_modelConfig_BaseModelArn = cmdletContext.ModelConfig_BaseModelArn;
            }
            if (requestModelConfig_modelConfig_BaseModelArn != null)
            {
                request.ModelConfig.BaseModelArn = requestModelConfig_modelConfig_BaseModelArn;
                requestModelConfigIsNull = false;
            }
             // determine if request.ModelConfig should be set to null
            if (requestModelConfigIsNull)
            {
                request.ModelConfig = null;
            }
            if (cmdletContext.ModelPackageGroupArn != null)
            {
                request.ModelPackageGroupArn = cmdletContext.ModelPackageGroupArn;
            }
            
             // populate OutputConfig
            var requestOutputConfigIsNull = true;
            request.OutputConfig = new Amazon.SageMaker.Model.TrainingSessionOutputConfig();
            Amazon.SageMaker.Model.TrainingSessionS3Location requestOutputConfig_outputConfig_S3Location = null;
            
             // populate S3Location
            var requestOutputConfig_outputConfig_S3LocationIsNull = true;
            requestOutputConfig_outputConfig_S3Location = new Amazon.SageMaker.Model.TrainingSessionS3Location();
            System.String requestOutputConfig_outputConfig_S3Location_outputConfig_S3Location_KmsKeyArn = null;
            if (cmdletContext.OutputConfig_S3Location_KmsKeyArn != null)
            {
                requestOutputConfig_outputConfig_S3Location_outputConfig_S3Location_KmsKeyArn = cmdletContext.OutputConfig_S3Location_KmsKeyArn;
            }
            if (requestOutputConfig_outputConfig_S3Location_outputConfig_S3Location_KmsKeyArn != null)
            {
                requestOutputConfig_outputConfig_S3Location.KmsKeyArn = requestOutputConfig_outputConfig_S3Location_outputConfig_S3Location_KmsKeyArn;
                requestOutputConfig_outputConfig_S3LocationIsNull = false;
            }
            System.String requestOutputConfig_outputConfig_S3Location_outputConfig_S3Location_Path = null;
            if (cmdletContext.OutputConfig_S3Location_Path != null)
            {
                requestOutputConfig_outputConfig_S3Location_outputConfig_S3Location_Path = cmdletContext.OutputConfig_S3Location_Path;
            }
            if (requestOutputConfig_outputConfig_S3Location_outputConfig_S3Location_Path != null)
            {
                requestOutputConfig_outputConfig_S3Location.Path = requestOutputConfig_outputConfig_S3Location_outputConfig_S3Location_Path;
                requestOutputConfig_outputConfig_S3LocationIsNull = false;
            }
             // determine if requestOutputConfig_outputConfig_S3Location should be set to null
            if (requestOutputConfig_outputConfig_S3LocationIsNull)
            {
                requestOutputConfig_outputConfig_S3Location = null;
            }
            if (requestOutputConfig_outputConfig_S3Location != null)
            {
                request.OutputConfig.S3Location = requestOutputConfig_outputConfig_S3Location;
                requestOutputConfigIsNull = false;
            }
             // determine if request.OutputConfig should be set to null
            if (requestOutputConfigIsNull)
            {
                request.OutputConfig = null;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TrainingSessionName != null)
            {
                request.TrainingSessionName = cmdletContext.TrainingSessionName;
            }
            
             // populate VpcConfig
            var requestVpcConfigIsNull = true;
            request.VpcConfig = new Amazon.SageMaker.Model.VpcConfig();
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
            List<System.String> requestVpcConfig_vpcConfig_Subnet = null;
            if (cmdletContext.VpcConfig_Subnet != null)
            {
                requestVpcConfig_vpcConfig_Subnet = cmdletContext.VpcConfig_Subnet;
            }
            if (requestVpcConfig_vpcConfig_Subnet != null)
            {
                request.VpcConfig.Subnets = requestVpcConfig_vpcConfig_Subnet;
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
        
        private Amazon.SageMaker.Model.CreateTrainingSessionResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateTrainingSessionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateTrainingSession");
            try
            {
                return client.CreateTrainingSessionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? LoraConfig_Alpha { get; set; }
            public System.Int32? LoraConfig_Rank { get; set; }
            public System.Boolean? ModelConfig_AcceptEula { get; set; }
            public System.String ModelConfig_BaseModelArn { get; set; }
            public System.String ModelPackageGroupArn { get; set; }
            public System.String OutputConfig_S3Location_KmsKeyArn { get; set; }
            public System.String OutputConfig_S3Location_Path { get; set; }
            public System.String RoleArn { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.String TrainingSessionName { get; set; }
            public List<System.String> VpcConfig_SecurityGroupId { get; set; }
            public List<System.String> VpcConfig_Subnet { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateTrainingSessionResponse, NewSMTrainingSessionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TrainingSessionArn;
        }
        
    }
}
