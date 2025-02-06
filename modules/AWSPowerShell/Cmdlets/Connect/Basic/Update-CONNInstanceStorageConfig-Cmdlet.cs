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
using Amazon.Connect;
using Amazon.Connect.Model;

namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// This API is in preview release for Amazon Connect and is subject to change.
    /// 
    ///  
    /// <para>
    /// Updates an existing configuration for a resource type. This API is idempotent.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CONNInstanceStorageConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Connect Service UpdateInstanceStorageConfig API operation.", Operation = new[] {"UpdateInstanceStorageConfig"}, SelectReturnType = typeof(Amazon.Connect.Model.UpdateInstanceStorageConfigResponse))]
    [AWSCmdletOutput("None or Amazon.Connect.Model.UpdateInstanceStorageConfigResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Connect.Model.UpdateInstanceStorageConfigResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateCONNInstanceStorageConfigCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AssociationId
        /// <summary>
        /// <para>
        /// <para>The existing association identifier that uniquely identifies the resource type and
        /// storage config for the given instance ID.</para>
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
        public System.String AssociationId { get; set; }
        #endregion
        
        #region Parameter StorageConfig_AssociationId
        /// <summary>
        /// <para>
        /// <para>The existing association identifier that uniquely identifies the resource type and
        /// storage config for the given instance ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageConfig_AssociationId { get; set; }
        #endregion
        
        #region Parameter S3Config_BucketName
        /// <summary>
        /// <para>
        /// <para>The S3 bucket name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfig_S3Config_BucketName")]
        public System.String S3Config_BucketName { get; set; }
        #endregion
        
        #region Parameter S3Config_BucketPrefix
        /// <summary>
        /// <para>
        /// <para>The S3 bucket prefix.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfig_S3Config_BucketPrefix")]
        public System.String S3Config_BucketPrefix { get; set; }
        #endregion
        
        #region Parameter StorageConfigKinesisVideoStreamConfigEncryptionConfigEncryptionType
        /// <summary>
        /// <para>
        /// <para>The type of encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfig_KinesisVideoStreamConfig_EncryptionConfig_EncryptionType")]
        [AWSConstantClassSource("Amazon.Connect.EncryptionType")]
        public Amazon.Connect.EncryptionType StorageConfigKinesisVideoStreamConfigEncryptionConfigEncryptionType { get; set; }
        #endregion
        
        #region Parameter StorageConfigS3ConfigEncryptionConfigEncryptionType
        /// <summary>
        /// <para>
        /// <para>The type of encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfig_S3Config_EncryptionConfig_EncryptionType")]
        [AWSConstantClassSource("Amazon.Connect.EncryptionType")]
        public Amazon.Connect.EncryptionType StorageConfigS3ConfigEncryptionConfigEncryptionType { get; set; }
        #endregion
        
        #region Parameter KinesisFirehoseConfig_FirehoseArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the delivery stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfig_KinesisFirehoseConfig_FirehoseArn")]
        public System.String KinesisFirehoseConfig_FirehoseArn { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter StorageConfigKinesisVideoStreamConfigEncryptionConfigKeyId
        /// <summary>
        /// <para>
        /// <para>The full ARN of the encryption key. </para><note><para>Be sure to provide the full ARN of the encryption key, not just the ID.</para><para>Amazon Connect supports only KMS keys with the default key spec of <a href="https://docs.aws.amazon.com/kms/latest/developerguide/asymmetric-key-specs.html#key-spec-symmetric-default"><c>SYMMETRIC_DEFAULT</c></a>. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfig_KinesisVideoStreamConfig_EncryptionConfig_KeyId")]
        public System.String StorageConfigKinesisVideoStreamConfigEncryptionConfigKeyId { get; set; }
        #endregion
        
        #region Parameter StorageConfigS3ConfigEncryptionConfigKeyId
        /// <summary>
        /// <para>
        /// <para>The full ARN of the encryption key. </para><note><para>Be sure to provide the full ARN of the encryption key, not just the ID.</para><para>Amazon Connect supports only KMS keys with the default key spec of <a href="https://docs.aws.amazon.com/kms/latest/developerguide/asymmetric-key-specs.html#key-spec-symmetric-default"><c>SYMMETRIC_DEFAULT</c></a>. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfig_S3Config_EncryptionConfig_KeyId")]
        public System.String StorageConfigS3ConfigEncryptionConfigKeyId { get; set; }
        #endregion
        
        #region Parameter KinesisVideoStreamConfig_Prefix
        /// <summary>
        /// <para>
        /// <para>The prefix of the video stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfig_KinesisVideoStreamConfig_Prefix")]
        public System.String KinesisVideoStreamConfig_Prefix { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>A valid resource type.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Connect.InstanceStorageResourceType")]
        public Amazon.Connect.InstanceStorageResourceType ResourceType { get; set; }
        #endregion
        
        #region Parameter KinesisVideoStreamConfig_RetentionPeriodHour
        /// <summary>
        /// <para>
        /// <para>The number of hours data is retained in the stream. Kinesis Video Streams retains
        /// the data in a data store that is associated with the stream.</para><para>The default value is 0, indicating that the stream does not persist data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfig_KinesisVideoStreamConfig_RetentionPeriodHours")]
        public System.Int32? KinesisVideoStreamConfig_RetentionPeriodHour { get; set; }
        #endregion
        
        #region Parameter StorageConfig_StorageType
        /// <summary>
        /// <para>
        /// <para>A valid storage type.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Connect.StorageType")]
        public Amazon.Connect.StorageType StorageConfig_StorageType { get; set; }
        #endregion
        
        #region Parameter KinesisStreamConfig_StreamArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the data stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfig_KinesisStreamConfig_StreamArn")]
        public System.String KinesisStreamConfig_StreamArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.UpdateInstanceStorageConfigResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AssociationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CONNInstanceStorageConfig (UpdateInstanceStorageConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.UpdateInstanceStorageConfigResponse, UpdateCONNInstanceStorageConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssociationId = this.AssociationId;
            #if MODULAR
            if (this.AssociationId == null && ParameterWasBound(nameof(this.AssociationId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssociationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceType = this.ResourceType;
            #if MODULAR
            if (this.ResourceType == null && ParameterWasBound(nameof(this.ResourceType)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StorageConfig_AssociationId = this.StorageConfig_AssociationId;
            context.KinesisFirehoseConfig_FirehoseArn = this.KinesisFirehoseConfig_FirehoseArn;
            context.KinesisStreamConfig_StreamArn = this.KinesisStreamConfig_StreamArn;
            context.StorageConfigKinesisVideoStreamConfigEncryptionConfigEncryptionType = this.StorageConfigKinesisVideoStreamConfigEncryptionConfigEncryptionType;
            context.StorageConfigKinesisVideoStreamConfigEncryptionConfigKeyId = this.StorageConfigKinesisVideoStreamConfigEncryptionConfigKeyId;
            context.KinesisVideoStreamConfig_Prefix = this.KinesisVideoStreamConfig_Prefix;
            context.KinesisVideoStreamConfig_RetentionPeriodHour = this.KinesisVideoStreamConfig_RetentionPeriodHour;
            context.S3Config_BucketName = this.S3Config_BucketName;
            context.S3Config_BucketPrefix = this.S3Config_BucketPrefix;
            context.StorageConfigS3ConfigEncryptionConfigEncryptionType = this.StorageConfigS3ConfigEncryptionConfigEncryptionType;
            context.StorageConfigS3ConfigEncryptionConfigKeyId = this.StorageConfigS3ConfigEncryptionConfigKeyId;
            context.StorageConfig_StorageType = this.StorageConfig_StorageType;
            #if MODULAR
            if (this.StorageConfig_StorageType == null && ParameterWasBound(nameof(this.StorageConfig_StorageType)))
            {
                WriteWarning("You are passing $null as a value for parameter StorageConfig_StorageType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Connect.Model.UpdateInstanceStorageConfigRequest();
            
            if (cmdletContext.AssociationId != null)
            {
                request.AssociationId = cmdletContext.AssociationId;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
            }
            
             // populate StorageConfig
            var requestStorageConfigIsNull = true;
            request.StorageConfig = new Amazon.Connect.Model.InstanceStorageConfig();
            System.String requestStorageConfig_storageConfig_AssociationId = null;
            if (cmdletContext.StorageConfig_AssociationId != null)
            {
                requestStorageConfig_storageConfig_AssociationId = cmdletContext.StorageConfig_AssociationId;
            }
            if (requestStorageConfig_storageConfig_AssociationId != null)
            {
                request.StorageConfig.AssociationId = requestStorageConfig_storageConfig_AssociationId;
                requestStorageConfigIsNull = false;
            }
            Amazon.Connect.StorageType requestStorageConfig_storageConfig_StorageType = null;
            if (cmdletContext.StorageConfig_StorageType != null)
            {
                requestStorageConfig_storageConfig_StorageType = cmdletContext.StorageConfig_StorageType;
            }
            if (requestStorageConfig_storageConfig_StorageType != null)
            {
                request.StorageConfig.StorageType = requestStorageConfig_storageConfig_StorageType;
                requestStorageConfigIsNull = false;
            }
            Amazon.Connect.Model.KinesisFirehoseConfig requestStorageConfig_storageConfig_KinesisFirehoseConfig = null;
            
             // populate KinesisFirehoseConfig
            var requestStorageConfig_storageConfig_KinesisFirehoseConfigIsNull = true;
            requestStorageConfig_storageConfig_KinesisFirehoseConfig = new Amazon.Connect.Model.KinesisFirehoseConfig();
            System.String requestStorageConfig_storageConfig_KinesisFirehoseConfig_kinesisFirehoseConfig_FirehoseArn = null;
            if (cmdletContext.KinesisFirehoseConfig_FirehoseArn != null)
            {
                requestStorageConfig_storageConfig_KinesisFirehoseConfig_kinesisFirehoseConfig_FirehoseArn = cmdletContext.KinesisFirehoseConfig_FirehoseArn;
            }
            if (requestStorageConfig_storageConfig_KinesisFirehoseConfig_kinesisFirehoseConfig_FirehoseArn != null)
            {
                requestStorageConfig_storageConfig_KinesisFirehoseConfig.FirehoseArn = requestStorageConfig_storageConfig_KinesisFirehoseConfig_kinesisFirehoseConfig_FirehoseArn;
                requestStorageConfig_storageConfig_KinesisFirehoseConfigIsNull = false;
            }
             // determine if requestStorageConfig_storageConfig_KinesisFirehoseConfig should be set to null
            if (requestStorageConfig_storageConfig_KinesisFirehoseConfigIsNull)
            {
                requestStorageConfig_storageConfig_KinesisFirehoseConfig = null;
            }
            if (requestStorageConfig_storageConfig_KinesisFirehoseConfig != null)
            {
                request.StorageConfig.KinesisFirehoseConfig = requestStorageConfig_storageConfig_KinesisFirehoseConfig;
                requestStorageConfigIsNull = false;
            }
            Amazon.Connect.Model.KinesisStreamConfig requestStorageConfig_storageConfig_KinesisStreamConfig = null;
            
             // populate KinesisStreamConfig
            var requestStorageConfig_storageConfig_KinesisStreamConfigIsNull = true;
            requestStorageConfig_storageConfig_KinesisStreamConfig = new Amazon.Connect.Model.KinesisStreamConfig();
            System.String requestStorageConfig_storageConfig_KinesisStreamConfig_kinesisStreamConfig_StreamArn = null;
            if (cmdletContext.KinesisStreamConfig_StreamArn != null)
            {
                requestStorageConfig_storageConfig_KinesisStreamConfig_kinesisStreamConfig_StreamArn = cmdletContext.KinesisStreamConfig_StreamArn;
            }
            if (requestStorageConfig_storageConfig_KinesisStreamConfig_kinesisStreamConfig_StreamArn != null)
            {
                requestStorageConfig_storageConfig_KinesisStreamConfig.StreamArn = requestStorageConfig_storageConfig_KinesisStreamConfig_kinesisStreamConfig_StreamArn;
                requestStorageConfig_storageConfig_KinesisStreamConfigIsNull = false;
            }
             // determine if requestStorageConfig_storageConfig_KinesisStreamConfig should be set to null
            if (requestStorageConfig_storageConfig_KinesisStreamConfigIsNull)
            {
                requestStorageConfig_storageConfig_KinesisStreamConfig = null;
            }
            if (requestStorageConfig_storageConfig_KinesisStreamConfig != null)
            {
                request.StorageConfig.KinesisStreamConfig = requestStorageConfig_storageConfig_KinesisStreamConfig;
                requestStorageConfigIsNull = false;
            }
            Amazon.Connect.Model.KinesisVideoStreamConfig requestStorageConfig_storageConfig_KinesisVideoStreamConfig = null;
            
             // populate KinesisVideoStreamConfig
            var requestStorageConfig_storageConfig_KinesisVideoStreamConfigIsNull = true;
            requestStorageConfig_storageConfig_KinesisVideoStreamConfig = new Amazon.Connect.Model.KinesisVideoStreamConfig();
            System.String requestStorageConfig_storageConfig_KinesisVideoStreamConfig_kinesisVideoStreamConfig_Prefix = null;
            if (cmdletContext.KinesisVideoStreamConfig_Prefix != null)
            {
                requestStorageConfig_storageConfig_KinesisVideoStreamConfig_kinesisVideoStreamConfig_Prefix = cmdletContext.KinesisVideoStreamConfig_Prefix;
            }
            if (requestStorageConfig_storageConfig_KinesisVideoStreamConfig_kinesisVideoStreamConfig_Prefix != null)
            {
                requestStorageConfig_storageConfig_KinesisVideoStreamConfig.Prefix = requestStorageConfig_storageConfig_KinesisVideoStreamConfig_kinesisVideoStreamConfig_Prefix;
                requestStorageConfig_storageConfig_KinesisVideoStreamConfigIsNull = false;
            }
            System.Int32? requestStorageConfig_storageConfig_KinesisVideoStreamConfig_kinesisVideoStreamConfig_RetentionPeriodHour = null;
            if (cmdletContext.KinesisVideoStreamConfig_RetentionPeriodHour != null)
            {
                requestStorageConfig_storageConfig_KinesisVideoStreamConfig_kinesisVideoStreamConfig_RetentionPeriodHour = cmdletContext.KinesisVideoStreamConfig_RetentionPeriodHour.Value;
            }
            if (requestStorageConfig_storageConfig_KinesisVideoStreamConfig_kinesisVideoStreamConfig_RetentionPeriodHour != null)
            {
                requestStorageConfig_storageConfig_KinesisVideoStreamConfig.RetentionPeriodHours = requestStorageConfig_storageConfig_KinesisVideoStreamConfig_kinesisVideoStreamConfig_RetentionPeriodHour.Value;
                requestStorageConfig_storageConfig_KinesisVideoStreamConfigIsNull = false;
            }
            Amazon.Connect.Model.EncryptionConfig requestStorageConfig_storageConfig_KinesisVideoStreamConfig_storageConfig_KinesisVideoStreamConfig_EncryptionConfig = null;
            
             // populate EncryptionConfig
            var requestStorageConfig_storageConfig_KinesisVideoStreamConfig_storageConfig_KinesisVideoStreamConfig_EncryptionConfigIsNull = true;
            requestStorageConfig_storageConfig_KinesisVideoStreamConfig_storageConfig_KinesisVideoStreamConfig_EncryptionConfig = new Amazon.Connect.Model.EncryptionConfig();
            Amazon.Connect.EncryptionType requestStorageConfig_storageConfig_KinesisVideoStreamConfig_storageConfig_KinesisVideoStreamConfig_EncryptionConfig_storageConfigKinesisVideoStreamConfigEncryptionConfigEncryptionType = null;
            if (cmdletContext.StorageConfigKinesisVideoStreamConfigEncryptionConfigEncryptionType != null)
            {
                requestStorageConfig_storageConfig_KinesisVideoStreamConfig_storageConfig_KinesisVideoStreamConfig_EncryptionConfig_storageConfigKinesisVideoStreamConfigEncryptionConfigEncryptionType = cmdletContext.StorageConfigKinesisVideoStreamConfigEncryptionConfigEncryptionType;
            }
            if (requestStorageConfig_storageConfig_KinesisVideoStreamConfig_storageConfig_KinesisVideoStreamConfig_EncryptionConfig_storageConfigKinesisVideoStreamConfigEncryptionConfigEncryptionType != null)
            {
                requestStorageConfig_storageConfig_KinesisVideoStreamConfig_storageConfig_KinesisVideoStreamConfig_EncryptionConfig.EncryptionType = requestStorageConfig_storageConfig_KinesisVideoStreamConfig_storageConfig_KinesisVideoStreamConfig_EncryptionConfig_storageConfigKinesisVideoStreamConfigEncryptionConfigEncryptionType;
                requestStorageConfig_storageConfig_KinesisVideoStreamConfig_storageConfig_KinesisVideoStreamConfig_EncryptionConfigIsNull = false;
            }
            System.String requestStorageConfig_storageConfig_KinesisVideoStreamConfig_storageConfig_KinesisVideoStreamConfig_EncryptionConfig_storageConfigKinesisVideoStreamConfigEncryptionConfigKeyId = null;
            if (cmdletContext.StorageConfigKinesisVideoStreamConfigEncryptionConfigKeyId != null)
            {
                requestStorageConfig_storageConfig_KinesisVideoStreamConfig_storageConfig_KinesisVideoStreamConfig_EncryptionConfig_storageConfigKinesisVideoStreamConfigEncryptionConfigKeyId = cmdletContext.StorageConfigKinesisVideoStreamConfigEncryptionConfigKeyId;
            }
            if (requestStorageConfig_storageConfig_KinesisVideoStreamConfig_storageConfig_KinesisVideoStreamConfig_EncryptionConfig_storageConfigKinesisVideoStreamConfigEncryptionConfigKeyId != null)
            {
                requestStorageConfig_storageConfig_KinesisVideoStreamConfig_storageConfig_KinesisVideoStreamConfig_EncryptionConfig.KeyId = requestStorageConfig_storageConfig_KinesisVideoStreamConfig_storageConfig_KinesisVideoStreamConfig_EncryptionConfig_storageConfigKinesisVideoStreamConfigEncryptionConfigKeyId;
                requestStorageConfig_storageConfig_KinesisVideoStreamConfig_storageConfig_KinesisVideoStreamConfig_EncryptionConfigIsNull = false;
            }
             // determine if requestStorageConfig_storageConfig_KinesisVideoStreamConfig_storageConfig_KinesisVideoStreamConfig_EncryptionConfig should be set to null
            if (requestStorageConfig_storageConfig_KinesisVideoStreamConfig_storageConfig_KinesisVideoStreamConfig_EncryptionConfigIsNull)
            {
                requestStorageConfig_storageConfig_KinesisVideoStreamConfig_storageConfig_KinesisVideoStreamConfig_EncryptionConfig = null;
            }
            if (requestStorageConfig_storageConfig_KinesisVideoStreamConfig_storageConfig_KinesisVideoStreamConfig_EncryptionConfig != null)
            {
                requestStorageConfig_storageConfig_KinesisVideoStreamConfig.EncryptionConfig = requestStorageConfig_storageConfig_KinesisVideoStreamConfig_storageConfig_KinesisVideoStreamConfig_EncryptionConfig;
                requestStorageConfig_storageConfig_KinesisVideoStreamConfigIsNull = false;
            }
             // determine if requestStorageConfig_storageConfig_KinesisVideoStreamConfig should be set to null
            if (requestStorageConfig_storageConfig_KinesisVideoStreamConfigIsNull)
            {
                requestStorageConfig_storageConfig_KinesisVideoStreamConfig = null;
            }
            if (requestStorageConfig_storageConfig_KinesisVideoStreamConfig != null)
            {
                request.StorageConfig.KinesisVideoStreamConfig = requestStorageConfig_storageConfig_KinesisVideoStreamConfig;
                requestStorageConfigIsNull = false;
            }
            Amazon.Connect.Model.S3Config requestStorageConfig_storageConfig_S3Config = null;
            
             // populate S3Config
            var requestStorageConfig_storageConfig_S3ConfigIsNull = true;
            requestStorageConfig_storageConfig_S3Config = new Amazon.Connect.Model.S3Config();
            System.String requestStorageConfig_storageConfig_S3Config_s3Config_BucketName = null;
            if (cmdletContext.S3Config_BucketName != null)
            {
                requestStorageConfig_storageConfig_S3Config_s3Config_BucketName = cmdletContext.S3Config_BucketName;
            }
            if (requestStorageConfig_storageConfig_S3Config_s3Config_BucketName != null)
            {
                requestStorageConfig_storageConfig_S3Config.BucketName = requestStorageConfig_storageConfig_S3Config_s3Config_BucketName;
                requestStorageConfig_storageConfig_S3ConfigIsNull = false;
            }
            System.String requestStorageConfig_storageConfig_S3Config_s3Config_BucketPrefix = null;
            if (cmdletContext.S3Config_BucketPrefix != null)
            {
                requestStorageConfig_storageConfig_S3Config_s3Config_BucketPrefix = cmdletContext.S3Config_BucketPrefix;
            }
            if (requestStorageConfig_storageConfig_S3Config_s3Config_BucketPrefix != null)
            {
                requestStorageConfig_storageConfig_S3Config.BucketPrefix = requestStorageConfig_storageConfig_S3Config_s3Config_BucketPrefix;
                requestStorageConfig_storageConfig_S3ConfigIsNull = false;
            }
            Amazon.Connect.Model.EncryptionConfig requestStorageConfig_storageConfig_S3Config_storageConfig_S3Config_EncryptionConfig = null;
            
             // populate EncryptionConfig
            var requestStorageConfig_storageConfig_S3Config_storageConfig_S3Config_EncryptionConfigIsNull = true;
            requestStorageConfig_storageConfig_S3Config_storageConfig_S3Config_EncryptionConfig = new Amazon.Connect.Model.EncryptionConfig();
            Amazon.Connect.EncryptionType requestStorageConfig_storageConfig_S3Config_storageConfig_S3Config_EncryptionConfig_storageConfigS3ConfigEncryptionConfigEncryptionType = null;
            if (cmdletContext.StorageConfigS3ConfigEncryptionConfigEncryptionType != null)
            {
                requestStorageConfig_storageConfig_S3Config_storageConfig_S3Config_EncryptionConfig_storageConfigS3ConfigEncryptionConfigEncryptionType = cmdletContext.StorageConfigS3ConfigEncryptionConfigEncryptionType;
            }
            if (requestStorageConfig_storageConfig_S3Config_storageConfig_S3Config_EncryptionConfig_storageConfigS3ConfigEncryptionConfigEncryptionType != null)
            {
                requestStorageConfig_storageConfig_S3Config_storageConfig_S3Config_EncryptionConfig.EncryptionType = requestStorageConfig_storageConfig_S3Config_storageConfig_S3Config_EncryptionConfig_storageConfigS3ConfigEncryptionConfigEncryptionType;
                requestStorageConfig_storageConfig_S3Config_storageConfig_S3Config_EncryptionConfigIsNull = false;
            }
            System.String requestStorageConfig_storageConfig_S3Config_storageConfig_S3Config_EncryptionConfig_storageConfigS3ConfigEncryptionConfigKeyId = null;
            if (cmdletContext.StorageConfigS3ConfigEncryptionConfigKeyId != null)
            {
                requestStorageConfig_storageConfig_S3Config_storageConfig_S3Config_EncryptionConfig_storageConfigS3ConfigEncryptionConfigKeyId = cmdletContext.StorageConfigS3ConfigEncryptionConfigKeyId;
            }
            if (requestStorageConfig_storageConfig_S3Config_storageConfig_S3Config_EncryptionConfig_storageConfigS3ConfigEncryptionConfigKeyId != null)
            {
                requestStorageConfig_storageConfig_S3Config_storageConfig_S3Config_EncryptionConfig.KeyId = requestStorageConfig_storageConfig_S3Config_storageConfig_S3Config_EncryptionConfig_storageConfigS3ConfigEncryptionConfigKeyId;
                requestStorageConfig_storageConfig_S3Config_storageConfig_S3Config_EncryptionConfigIsNull = false;
            }
             // determine if requestStorageConfig_storageConfig_S3Config_storageConfig_S3Config_EncryptionConfig should be set to null
            if (requestStorageConfig_storageConfig_S3Config_storageConfig_S3Config_EncryptionConfigIsNull)
            {
                requestStorageConfig_storageConfig_S3Config_storageConfig_S3Config_EncryptionConfig = null;
            }
            if (requestStorageConfig_storageConfig_S3Config_storageConfig_S3Config_EncryptionConfig != null)
            {
                requestStorageConfig_storageConfig_S3Config.EncryptionConfig = requestStorageConfig_storageConfig_S3Config_storageConfig_S3Config_EncryptionConfig;
                requestStorageConfig_storageConfig_S3ConfigIsNull = false;
            }
             // determine if requestStorageConfig_storageConfig_S3Config should be set to null
            if (requestStorageConfig_storageConfig_S3ConfigIsNull)
            {
                requestStorageConfig_storageConfig_S3Config = null;
            }
            if (requestStorageConfig_storageConfig_S3Config != null)
            {
                request.StorageConfig.S3Config = requestStorageConfig_storageConfig_S3Config;
                requestStorageConfigIsNull = false;
            }
             // determine if request.StorageConfig should be set to null
            if (requestStorageConfigIsNull)
            {
                request.StorageConfig = null;
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
        
        private Amazon.Connect.Model.UpdateInstanceStorageConfigResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.UpdateInstanceStorageConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "UpdateInstanceStorageConfig");
            try
            {
                #if DESKTOP
                return client.UpdateInstanceStorageConfig(request);
                #elif CORECLR
                return client.UpdateInstanceStorageConfigAsync(request).GetAwaiter().GetResult();
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
            public System.String AssociationId { get; set; }
            public System.String InstanceId { get; set; }
            public Amazon.Connect.InstanceStorageResourceType ResourceType { get; set; }
            public System.String StorageConfig_AssociationId { get; set; }
            public System.String KinesisFirehoseConfig_FirehoseArn { get; set; }
            public System.String KinesisStreamConfig_StreamArn { get; set; }
            public Amazon.Connect.EncryptionType StorageConfigKinesisVideoStreamConfigEncryptionConfigEncryptionType { get; set; }
            public System.String StorageConfigKinesisVideoStreamConfigEncryptionConfigKeyId { get; set; }
            public System.String KinesisVideoStreamConfig_Prefix { get; set; }
            public System.Int32? KinesisVideoStreamConfig_RetentionPeriodHour { get; set; }
            public System.String S3Config_BucketName { get; set; }
            public System.String S3Config_BucketPrefix { get; set; }
            public Amazon.Connect.EncryptionType StorageConfigS3ConfigEncryptionConfigEncryptionType { get; set; }
            public System.String StorageConfigS3ConfigEncryptionConfigKeyId { get; set; }
            public Amazon.Connect.StorageType StorageConfig_StorageType { get; set; }
            public System.Func<Amazon.Connect.Model.UpdateInstanceStorageConfigResponse, UpdateCONNInstanceStorageConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
