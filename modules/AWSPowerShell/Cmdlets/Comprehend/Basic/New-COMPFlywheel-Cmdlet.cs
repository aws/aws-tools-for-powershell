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
using Amazon.Comprehend;
using Amazon.Comprehend.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.COMP
{
    /// <summary>
    /// A flywheel is an Amazon Web Services resource that orchestrates the ongoing training
    /// of a model for custom classification or custom entity recognition. You can create
    /// a flywheel to start with an existing trained model, or Comprehend can create and train
    /// a new model.
    /// 
    ///  
    /// <para>
    /// When you create the flywheel, Comprehend creates a data lake in your account. The
    /// data lake holds the training data and test data for all versions of the model.
    /// </para><para>
    /// To use a flywheel with an existing trained model, you specify the active model version.
    /// Comprehend copies the model's training data and test data into the flywheel's data
    /// lake.
    /// </para><para>
    /// To use the flywheel with a new model, you need to provide a dataset for training data
    /// (and optional test data) when you create the flywheel.
    /// </para><para>
    /// For more information about flywheels, see <a href="https://docs.aws.amazon.com/comprehend/latest/dg/flywheels-about.html">
    /// Flywheel overview</a> in the <i>Amazon Comprehend Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "COMPFlywheel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Comprehend.Model.CreateFlywheelResponse")]
    [AWSCmdlet("Calls the Amazon Comprehend CreateFlywheel API operation.", Operation = new[] {"CreateFlywheel"}, SelectReturnType = typeof(Amazon.Comprehend.Model.CreateFlywheelResponse))]
    [AWSCmdletOutput("Amazon.Comprehend.Model.CreateFlywheelResponse",
        "This cmdlet returns an Amazon.Comprehend.Model.CreateFlywheelResponse object containing multiple properties."
    )]
    public partial class NewCOMPFlywheelCmdlet : AmazonComprehendClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ActiveModelArn
        /// <summary>
        /// <para>
        /// <para>To associate an existing model with the flywheel, specify the Amazon Resource Number
        /// (ARN) of the model version. Do not set <c>TaskConfig</c> or <c>ModelType</c> if you
        /// specify an <c>ActiveModelArn</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ActiveModelArn { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the request. If you don't set the client request token, Amazon
        /// Comprehend generates one.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter DataAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that grants Amazon Comprehend the permissions
        /// required to access the flywheel data in the data lake.</para>
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
        public System.String DataAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter DataSecurityConfig_DataLakeKmsKeyId
        /// <summary>
        /// <para>
        /// <para>ID for the KMS key that Amazon Comprehend uses to encrypt the data in the data lake.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataSecurityConfig_DataLakeKmsKeyId { get; set; }
        #endregion
        
        #region Parameter DataLakeS3Uri
        /// <summary>
        /// <para>
        /// <para>Enter the S3 location for the data lake. You can specify a new S3 bucket or a new
        /// folder of an existing S3 bucket. The flywheel creates the data lake at this location.</para>
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
        public System.String DataLakeS3Uri { get; set; }
        #endregion
        
        #region Parameter EntityRecognitionConfig_EntityType
        /// <summary>
        /// <para>
        /// <para>Up to 25 entity types that the model is trained to recognize.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaskConfig_EntityRecognitionConfig_EntityTypes")]
        public Amazon.Comprehend.Model.EntityTypesListItem[] EntityRecognitionConfig_EntityType { get; set; }
        #endregion
        
        #region Parameter FlywheelName
        /// <summary>
        /// <para>
        /// <para>Name for the flywheel.</para>
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
        public System.String FlywheelName { get; set; }
        #endregion
        
        #region Parameter DocumentClassificationConfig_Label
        /// <summary>
        /// <para>
        /// <para>One or more labels to associate with the custom classifier.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaskConfig_DocumentClassificationConfig_Labels")]
        public System.String[] DocumentClassificationConfig_Label { get; set; }
        #endregion
        
        #region Parameter TaskConfig_LanguageCode
        /// <summary>
        /// <para>
        /// <para>Language code for the language that the model supports.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Comprehend.LanguageCode")]
        public Amazon.Comprehend.LanguageCode TaskConfig_LanguageCode { get; set; }
        #endregion
        
        #region Parameter DocumentClassificationConfig_Mode
        /// <summary>
        /// <para>
        /// <para>Classification mode indicates whether the documents are <c>MULTI_CLASS</c> or <c>MULTI_LABEL</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaskConfig_DocumentClassificationConfig_Mode")]
        [AWSConstantClassSource("Amazon.Comprehend.DocumentClassifierMode")]
        public Amazon.Comprehend.DocumentClassifierMode DocumentClassificationConfig_Mode { get; set; }
        #endregion
        
        #region Parameter DataSecurityConfig_ModelKmsKeyId
        /// <summary>
        /// <para>
        /// <para>ID for the KMS key that Amazon Comprehend uses to encrypt trained custom models. The
        /// ModelKmsKeyId can be either of the following formats:</para><ul><li><para>KMS Key ID: <c>"1234abcd-12ab-34cd-56ef-1234567890ab"</c></para></li><li><para>Amazon Resource Name (ARN) of a KMS Key: <c>"arn:aws:kms:us-west-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab"</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataSecurityConfig_ModelKmsKeyId { get; set; }
        #endregion
        
        #region Parameter ModelType
        /// <summary>
        /// <para>
        /// <para>The model type. You need to set <c>ModelType</c> if you are creating a flywheel for
        /// a new model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Comprehend.ModelType")]
        public Amazon.Comprehend.ModelType ModelType { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The ID number for a security group on an instance of your private VPC. Security groups
        /// on your VPC function serve as a virtual firewall to control inbound and outbound traffic
        /// and provides security for the resources that you’ll be accessing on the VPC. This
        /// ID number is preceded by "sg-", for instance: "sg-03b388029b0a285ea". For more information,
        /// see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/VPC_SecurityGroups.html">Security
        /// Groups for your VPC</a>. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSecurityConfig_VpcConfig_SecurityGroupIds")]
        public System.String[] VpcConfig_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter VpcConfig_Subnet
        /// <summary>
        /// <para>
        /// <para>The ID for each subnet being used in your private VPC. This subnet is a subset of
        /// the a range of IPv4 addresses used by the VPC and is specific to a given availability
        /// zone in the VPC’s Region. This ID number is preceded by "subnet-", for instance: "subnet-04ccf456919e69055".
        /// For more information, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/VPC_Subnets.html">VPCs
        /// and Subnets</a>. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSecurityConfig_VpcConfig_Subnets")]
        public System.String[] VpcConfig_Subnet { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to associate with this flywheel.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Comprehend.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter DataSecurityConfig_VolumeKmsKeyId
        /// <summary>
        /// <para>
        /// <para>ID for the KMS key that Amazon Comprehend uses to encrypt the volume.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataSecurityConfig_VolumeKmsKeyId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Comprehend.Model.CreateFlywheelResponse).
        /// Specifying the name of a property of type Amazon.Comprehend.Model.CreateFlywheelResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-COMPFlywheel (CreateFlywheel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Comprehend.Model.CreateFlywheelResponse, NewCOMPFlywheelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ActiveModelArn = this.ActiveModelArn;
            context.ClientRequestToken = this.ClientRequestToken;
            context.DataAccessRoleArn = this.DataAccessRoleArn;
            #if MODULAR
            if (this.DataAccessRoleArn == null && ParameterWasBound(nameof(this.DataAccessRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DataAccessRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DataLakeS3Uri = this.DataLakeS3Uri;
            #if MODULAR
            if (this.DataLakeS3Uri == null && ParameterWasBound(nameof(this.DataLakeS3Uri)))
            {
                WriteWarning("You are passing $null as a value for parameter DataLakeS3Uri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DataSecurityConfig_DataLakeKmsKeyId = this.DataSecurityConfig_DataLakeKmsKeyId;
            context.DataSecurityConfig_ModelKmsKeyId = this.DataSecurityConfig_ModelKmsKeyId;
            context.DataSecurityConfig_VolumeKmsKeyId = this.DataSecurityConfig_VolumeKmsKeyId;
            if (this.VpcConfig_SecurityGroupId != null)
            {
                context.VpcConfig_SecurityGroupId = new List<System.String>(this.VpcConfig_SecurityGroupId);
            }
            if (this.VpcConfig_Subnet != null)
            {
                context.VpcConfig_Subnet = new List<System.String>(this.VpcConfig_Subnet);
            }
            context.FlywheelName = this.FlywheelName;
            #if MODULAR
            if (this.FlywheelName == null && ParameterWasBound(nameof(this.FlywheelName)))
            {
                WriteWarning("You are passing $null as a value for parameter FlywheelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ModelType = this.ModelType;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Comprehend.Model.Tag>(this.Tag);
            }
            if (this.DocumentClassificationConfig_Label != null)
            {
                context.DocumentClassificationConfig_Label = new List<System.String>(this.DocumentClassificationConfig_Label);
            }
            context.DocumentClassificationConfig_Mode = this.DocumentClassificationConfig_Mode;
            if (this.EntityRecognitionConfig_EntityType != null)
            {
                context.EntityRecognitionConfig_EntityType = new List<Amazon.Comprehend.Model.EntityTypesListItem>(this.EntityRecognitionConfig_EntityType);
            }
            context.TaskConfig_LanguageCode = this.TaskConfig_LanguageCode;
            
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
            var request = new Amazon.Comprehend.Model.CreateFlywheelRequest();
            
            if (cmdletContext.ActiveModelArn != null)
            {
                request.ActiveModelArn = cmdletContext.ActiveModelArn;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.DataAccessRoleArn != null)
            {
                request.DataAccessRoleArn = cmdletContext.DataAccessRoleArn;
            }
            if (cmdletContext.DataLakeS3Uri != null)
            {
                request.DataLakeS3Uri = cmdletContext.DataLakeS3Uri;
            }
            
             // populate DataSecurityConfig
            var requestDataSecurityConfigIsNull = true;
            request.DataSecurityConfig = new Amazon.Comprehend.Model.DataSecurityConfig();
            System.String requestDataSecurityConfig_dataSecurityConfig_DataLakeKmsKeyId = null;
            if (cmdletContext.DataSecurityConfig_DataLakeKmsKeyId != null)
            {
                requestDataSecurityConfig_dataSecurityConfig_DataLakeKmsKeyId = cmdletContext.DataSecurityConfig_DataLakeKmsKeyId;
            }
            if (requestDataSecurityConfig_dataSecurityConfig_DataLakeKmsKeyId != null)
            {
                request.DataSecurityConfig.DataLakeKmsKeyId = requestDataSecurityConfig_dataSecurityConfig_DataLakeKmsKeyId;
                requestDataSecurityConfigIsNull = false;
            }
            System.String requestDataSecurityConfig_dataSecurityConfig_ModelKmsKeyId = null;
            if (cmdletContext.DataSecurityConfig_ModelKmsKeyId != null)
            {
                requestDataSecurityConfig_dataSecurityConfig_ModelKmsKeyId = cmdletContext.DataSecurityConfig_ModelKmsKeyId;
            }
            if (requestDataSecurityConfig_dataSecurityConfig_ModelKmsKeyId != null)
            {
                request.DataSecurityConfig.ModelKmsKeyId = requestDataSecurityConfig_dataSecurityConfig_ModelKmsKeyId;
                requestDataSecurityConfigIsNull = false;
            }
            System.String requestDataSecurityConfig_dataSecurityConfig_VolumeKmsKeyId = null;
            if (cmdletContext.DataSecurityConfig_VolumeKmsKeyId != null)
            {
                requestDataSecurityConfig_dataSecurityConfig_VolumeKmsKeyId = cmdletContext.DataSecurityConfig_VolumeKmsKeyId;
            }
            if (requestDataSecurityConfig_dataSecurityConfig_VolumeKmsKeyId != null)
            {
                request.DataSecurityConfig.VolumeKmsKeyId = requestDataSecurityConfig_dataSecurityConfig_VolumeKmsKeyId;
                requestDataSecurityConfigIsNull = false;
            }
            Amazon.Comprehend.Model.VpcConfig requestDataSecurityConfig_dataSecurityConfig_VpcConfig = null;
            
             // populate VpcConfig
            var requestDataSecurityConfig_dataSecurityConfig_VpcConfigIsNull = true;
            requestDataSecurityConfig_dataSecurityConfig_VpcConfig = new Amazon.Comprehend.Model.VpcConfig();
            List<System.String> requestDataSecurityConfig_dataSecurityConfig_VpcConfig_vpcConfig_SecurityGroupId = null;
            if (cmdletContext.VpcConfig_SecurityGroupId != null)
            {
                requestDataSecurityConfig_dataSecurityConfig_VpcConfig_vpcConfig_SecurityGroupId = cmdletContext.VpcConfig_SecurityGroupId;
            }
            if (requestDataSecurityConfig_dataSecurityConfig_VpcConfig_vpcConfig_SecurityGroupId != null)
            {
                requestDataSecurityConfig_dataSecurityConfig_VpcConfig.SecurityGroupIds = requestDataSecurityConfig_dataSecurityConfig_VpcConfig_vpcConfig_SecurityGroupId;
                requestDataSecurityConfig_dataSecurityConfig_VpcConfigIsNull = false;
            }
            List<System.String> requestDataSecurityConfig_dataSecurityConfig_VpcConfig_vpcConfig_Subnet = null;
            if (cmdletContext.VpcConfig_Subnet != null)
            {
                requestDataSecurityConfig_dataSecurityConfig_VpcConfig_vpcConfig_Subnet = cmdletContext.VpcConfig_Subnet;
            }
            if (requestDataSecurityConfig_dataSecurityConfig_VpcConfig_vpcConfig_Subnet != null)
            {
                requestDataSecurityConfig_dataSecurityConfig_VpcConfig.Subnets = requestDataSecurityConfig_dataSecurityConfig_VpcConfig_vpcConfig_Subnet;
                requestDataSecurityConfig_dataSecurityConfig_VpcConfigIsNull = false;
            }
             // determine if requestDataSecurityConfig_dataSecurityConfig_VpcConfig should be set to null
            if (requestDataSecurityConfig_dataSecurityConfig_VpcConfigIsNull)
            {
                requestDataSecurityConfig_dataSecurityConfig_VpcConfig = null;
            }
            if (requestDataSecurityConfig_dataSecurityConfig_VpcConfig != null)
            {
                request.DataSecurityConfig.VpcConfig = requestDataSecurityConfig_dataSecurityConfig_VpcConfig;
                requestDataSecurityConfigIsNull = false;
            }
             // determine if request.DataSecurityConfig should be set to null
            if (requestDataSecurityConfigIsNull)
            {
                request.DataSecurityConfig = null;
            }
            if (cmdletContext.FlywheelName != null)
            {
                request.FlywheelName = cmdletContext.FlywheelName;
            }
            if (cmdletContext.ModelType != null)
            {
                request.ModelType = cmdletContext.ModelType;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate TaskConfig
            var requestTaskConfigIsNull = true;
            request.TaskConfig = new Amazon.Comprehend.Model.TaskConfig();
            Amazon.Comprehend.LanguageCode requestTaskConfig_taskConfig_LanguageCode = null;
            if (cmdletContext.TaskConfig_LanguageCode != null)
            {
                requestTaskConfig_taskConfig_LanguageCode = cmdletContext.TaskConfig_LanguageCode;
            }
            if (requestTaskConfig_taskConfig_LanguageCode != null)
            {
                request.TaskConfig.LanguageCode = requestTaskConfig_taskConfig_LanguageCode;
                requestTaskConfigIsNull = false;
            }
            Amazon.Comprehend.Model.EntityRecognitionConfig requestTaskConfig_taskConfig_EntityRecognitionConfig = null;
            
             // populate EntityRecognitionConfig
            var requestTaskConfig_taskConfig_EntityRecognitionConfigIsNull = true;
            requestTaskConfig_taskConfig_EntityRecognitionConfig = new Amazon.Comprehend.Model.EntityRecognitionConfig();
            List<Amazon.Comprehend.Model.EntityTypesListItem> requestTaskConfig_taskConfig_EntityRecognitionConfig_entityRecognitionConfig_EntityType = null;
            if (cmdletContext.EntityRecognitionConfig_EntityType != null)
            {
                requestTaskConfig_taskConfig_EntityRecognitionConfig_entityRecognitionConfig_EntityType = cmdletContext.EntityRecognitionConfig_EntityType;
            }
            if (requestTaskConfig_taskConfig_EntityRecognitionConfig_entityRecognitionConfig_EntityType != null)
            {
                requestTaskConfig_taskConfig_EntityRecognitionConfig.EntityTypes = requestTaskConfig_taskConfig_EntityRecognitionConfig_entityRecognitionConfig_EntityType;
                requestTaskConfig_taskConfig_EntityRecognitionConfigIsNull = false;
            }
             // determine if requestTaskConfig_taskConfig_EntityRecognitionConfig should be set to null
            if (requestTaskConfig_taskConfig_EntityRecognitionConfigIsNull)
            {
                requestTaskConfig_taskConfig_EntityRecognitionConfig = null;
            }
            if (requestTaskConfig_taskConfig_EntityRecognitionConfig != null)
            {
                request.TaskConfig.EntityRecognitionConfig = requestTaskConfig_taskConfig_EntityRecognitionConfig;
                requestTaskConfigIsNull = false;
            }
            Amazon.Comprehend.Model.DocumentClassificationConfig requestTaskConfig_taskConfig_DocumentClassificationConfig = null;
            
             // populate DocumentClassificationConfig
            var requestTaskConfig_taskConfig_DocumentClassificationConfigIsNull = true;
            requestTaskConfig_taskConfig_DocumentClassificationConfig = new Amazon.Comprehend.Model.DocumentClassificationConfig();
            List<System.String> requestTaskConfig_taskConfig_DocumentClassificationConfig_documentClassificationConfig_Label = null;
            if (cmdletContext.DocumentClassificationConfig_Label != null)
            {
                requestTaskConfig_taskConfig_DocumentClassificationConfig_documentClassificationConfig_Label = cmdletContext.DocumentClassificationConfig_Label;
            }
            if (requestTaskConfig_taskConfig_DocumentClassificationConfig_documentClassificationConfig_Label != null)
            {
                requestTaskConfig_taskConfig_DocumentClassificationConfig.Labels = requestTaskConfig_taskConfig_DocumentClassificationConfig_documentClassificationConfig_Label;
                requestTaskConfig_taskConfig_DocumentClassificationConfigIsNull = false;
            }
            Amazon.Comprehend.DocumentClassifierMode requestTaskConfig_taskConfig_DocumentClassificationConfig_documentClassificationConfig_Mode = null;
            if (cmdletContext.DocumentClassificationConfig_Mode != null)
            {
                requestTaskConfig_taskConfig_DocumentClassificationConfig_documentClassificationConfig_Mode = cmdletContext.DocumentClassificationConfig_Mode;
            }
            if (requestTaskConfig_taskConfig_DocumentClassificationConfig_documentClassificationConfig_Mode != null)
            {
                requestTaskConfig_taskConfig_DocumentClassificationConfig.Mode = requestTaskConfig_taskConfig_DocumentClassificationConfig_documentClassificationConfig_Mode;
                requestTaskConfig_taskConfig_DocumentClassificationConfigIsNull = false;
            }
             // determine if requestTaskConfig_taskConfig_DocumentClassificationConfig should be set to null
            if (requestTaskConfig_taskConfig_DocumentClassificationConfigIsNull)
            {
                requestTaskConfig_taskConfig_DocumentClassificationConfig = null;
            }
            if (requestTaskConfig_taskConfig_DocumentClassificationConfig != null)
            {
                request.TaskConfig.DocumentClassificationConfig = requestTaskConfig_taskConfig_DocumentClassificationConfig;
                requestTaskConfigIsNull = false;
            }
             // determine if request.TaskConfig should be set to null
            if (requestTaskConfigIsNull)
            {
                request.TaskConfig = null;
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
        
        private Amazon.Comprehend.Model.CreateFlywheelResponse CallAWSServiceOperation(IAmazonComprehend client, Amazon.Comprehend.Model.CreateFlywheelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Comprehend", "CreateFlywheel");
            try
            {
                return client.CreateFlywheelAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ActiveModelArn { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.String DataAccessRoleArn { get; set; }
            public System.String DataLakeS3Uri { get; set; }
            public System.String DataSecurityConfig_DataLakeKmsKeyId { get; set; }
            public System.String DataSecurityConfig_ModelKmsKeyId { get; set; }
            public System.String DataSecurityConfig_VolumeKmsKeyId { get; set; }
            public List<System.String> VpcConfig_SecurityGroupId { get; set; }
            public List<System.String> VpcConfig_Subnet { get; set; }
            public System.String FlywheelName { get; set; }
            public Amazon.Comprehend.ModelType ModelType { get; set; }
            public List<Amazon.Comprehend.Model.Tag> Tag { get; set; }
            public List<System.String> DocumentClassificationConfig_Label { get; set; }
            public Amazon.Comprehend.DocumentClassifierMode DocumentClassificationConfig_Mode { get; set; }
            public List<Amazon.Comprehend.Model.EntityTypesListItem> EntityRecognitionConfig_EntityType { get; set; }
            public Amazon.Comprehend.LanguageCode TaskConfig_LanguageCode { get; set; }
            public System.Func<Amazon.Comprehend.Model.CreateFlywheelResponse, NewCOMPFlywheelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
