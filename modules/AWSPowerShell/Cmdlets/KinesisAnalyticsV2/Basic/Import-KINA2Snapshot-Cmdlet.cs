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
using Amazon.KinesisAnalyticsV2;
using Amazon.KinesisAnalyticsV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.KINA2
{
    /// <summary>
    /// Imports an Apache Flink savepoint from an Amazon S3 location as an enhanced snapshot.
    /// Managed Service for Apache Flink assumes the IAM role that you specify in <c>ImportSourceConfiguration</c>
    /// to read the savepoint data.
    /// 
    ///  
    /// <para>
    /// This operation is asynchronous. The response returns the snapshot ARN with the <c>CREATING</c>
    /// status. To track the progress of the import, use <c>DescribeSnapshotOperation</c>.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/managed-flink/latest/java/snapshots-import-export.html">Import
    /// and export</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Import", "KINA2Snapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KinesisAnalyticsV2.Model.ImportSnapshotResponse")]
    [AWSCmdlet("Calls the Amazon Kinesis Analytics V2 ImportSnapshot API operation.", Operation = new[] {"ImportSnapshot"}, SelectReturnType = typeof(Amazon.KinesisAnalyticsV2.Model.ImportSnapshotResponse))]
    [AWSCmdletOutput("Amazon.KinesisAnalyticsV2.Model.ImportSnapshotResponse",
        "This cmdlet returns an Amazon.KinesisAnalyticsV2.Model.ImportSnapshotResponse object containing multiple properties."
    )]
    public partial class ImportKINA2SnapshotCmdlet : AmazonKinesisAnalyticsV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ImportSourceConfiguration_SourceS3PrefixLocation_BucketARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the Amazon S3 bucket.</para>
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
        public System.String ImportSourceConfiguration_SourceS3PrefixLocation_BucketARN { get; set; }
        #endregion
        
        #region Parameter ImportSourceConfiguration_ImportRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that Managed Service for Apache Flink assumes to read the
        /// savepoint data from the source location. For information about the permissions that
        /// this role requires, see <a href="https://docs.aws.amazon.com/managed-flink/latest/java/snapshots-import-export.html">Import
        /// and export</a>.</para>
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
        public System.String ImportSourceConfiguration_ImportRoleArn { get; set; }
        #endregion
        
        #region Parameter DestinationEncryptionConfiguration_KeyId
        /// <summary>
        /// <para>
        /// <para>The KMS key used for encryption. <c>KeyId</c> is used only when <c>KeyType</c> is
        /// <c>CUSTOMER_MANAGED_KEY</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationEncryptionConfiguration_KeyId { get; set; }
        #endregion
        
        #region Parameter ImportSourceConfiguration_SourceEncryptionConfiguration_KeyId
        /// <summary>
        /// <para>
        /// <para>The KMS key used for encryption. <c>KeyId</c> is used only when <c>KeyType</c> is
        /// <c>CUSTOMER_MANAGED_KEY</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ImportSourceConfiguration_SourceEncryptionConfiguration_KeyId { get; set; }
        #endregion
        
        #region Parameter ImportSourceConfiguration_SourceS3PrefixLocation_KeyPrefix
        /// <summary>
        /// <para>
        /// <para>The key prefix in the Amazon S3 bucket.</para>
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
        public System.String ImportSourceConfiguration_SourceS3PrefixLocation_KeyPrefix { get; set; }
        #endregion
        
        #region Parameter DestinationEncryptionConfiguration_KeyType
        /// <summary>
        /// <para>
        /// <para>Specifies the type of key used for encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisAnalyticsV2.KeyType")]
        public Amazon.KinesisAnalyticsV2.KeyType DestinationEncryptionConfiguration_KeyType { get; set; }
        #endregion
        
        #region Parameter ImportSourceConfiguration_SourceEncryptionConfiguration_KeyType
        /// <summary>
        /// <para>
        /// <para>Specifies the type of key used for encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisAnalyticsV2.KeyType")]
        public Amazon.KinesisAnalyticsV2.KeyType ImportSourceConfiguration_SourceEncryptionConfiguration_KeyType { get; set; }
        #endregion
        
        #region Parameter SnapshotDescription
        /// <summary>
        /// <para>
        /// <para>A summary description of the snapshot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnapshotDescription { get; set; }
        #endregion
        
        #region Parameter SnapshotFormat
        /// <summary>
        /// <para>
        /// <para>The format of the snapshot being imported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisAnalyticsV2.SnapshotFormat")]
        public Amazon.KinesisAnalyticsV2.SnapshotFormat SnapshotFormat { get; set; }
        #endregion
        
        #region Parameter SnapshotName
        /// <summary>
        /// <para>
        /// <para>The name of the enhanced snapshot. The name must be unique among the snapshots in
        /// your account and Region. You can't reuse the name of an existing snapshot, including
        /// a snapshot in the <c>FAILED</c> status, until you delete that snapshot. Names that
        /// begin with <c>SYSTEMSNAPSHOT</c> are reserved.</para>
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
        public System.String SnapshotName { get; set; }
        #endregion
        
        #region Parameter ImportSourceConfiguration_SourceType
        /// <summary>
        /// <para>
        /// <para>The type of the source location. The only supported value is <c>S3</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.KinesisAnalyticsV2.StorageLocationType")]
        public Amazon.KinesisAnalyticsV2.StorageLocationType ImportSourceConfiguration_SourceType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of one or more tags to assign to the snapshot. A tag is a key-value pair that
        /// identifies a snapshot. For more information, see <a href="https://docs.aws.amazon.com/kinesisanalytics/latest/java/how-tagging.html">Using
        /// Tagging</a>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.KinesisAnalyticsV2.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisAnalyticsV2.Model.ImportSnapshotResponse).
        /// Specifying the name of a property of type Amazon.KinesisAnalyticsV2.Model.ImportSnapshotResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SnapshotName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-KINA2Snapshot (ImportSnapshot)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KinesisAnalyticsV2.Model.ImportSnapshotResponse, ImportKINA2SnapshotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DestinationEncryptionConfiguration_KeyId = this.DestinationEncryptionConfiguration_KeyId;
            context.DestinationEncryptionConfiguration_KeyType = this.DestinationEncryptionConfiguration_KeyType;
            context.ImportSourceConfiguration_ImportRoleArn = this.ImportSourceConfiguration_ImportRoleArn;
            #if MODULAR
            if (this.ImportSourceConfiguration_ImportRoleArn == null && ParameterWasBound(nameof(this.ImportSourceConfiguration_ImportRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ImportSourceConfiguration_ImportRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ImportSourceConfiguration_SourceEncryptionConfiguration_KeyId = this.ImportSourceConfiguration_SourceEncryptionConfiguration_KeyId;
            context.ImportSourceConfiguration_SourceEncryptionConfiguration_KeyType = this.ImportSourceConfiguration_SourceEncryptionConfiguration_KeyType;
            context.ImportSourceConfiguration_SourceS3PrefixLocation_BucketARN = this.ImportSourceConfiguration_SourceS3PrefixLocation_BucketARN;
            #if MODULAR
            if (this.ImportSourceConfiguration_SourceS3PrefixLocation_BucketARN == null && ParameterWasBound(nameof(this.ImportSourceConfiguration_SourceS3PrefixLocation_BucketARN)))
            {
                WriteWarning("You are passing $null as a value for parameter ImportSourceConfiguration_SourceS3PrefixLocation_BucketARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ImportSourceConfiguration_SourceS3PrefixLocation_KeyPrefix = this.ImportSourceConfiguration_SourceS3PrefixLocation_KeyPrefix;
            #if MODULAR
            if (this.ImportSourceConfiguration_SourceS3PrefixLocation_KeyPrefix == null && ParameterWasBound(nameof(this.ImportSourceConfiguration_SourceS3PrefixLocation_KeyPrefix)))
            {
                WriteWarning("You are passing $null as a value for parameter ImportSourceConfiguration_SourceS3PrefixLocation_KeyPrefix which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ImportSourceConfiguration_SourceType = this.ImportSourceConfiguration_SourceType;
            #if MODULAR
            if (this.ImportSourceConfiguration_SourceType == null && ParameterWasBound(nameof(this.ImportSourceConfiguration_SourceType)))
            {
                WriteWarning("You are passing $null as a value for parameter ImportSourceConfiguration_SourceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SnapshotDescription = this.SnapshotDescription;
            context.SnapshotFormat = this.SnapshotFormat;
            context.SnapshotName = this.SnapshotName;
            #if MODULAR
            if (this.SnapshotName == null && ParameterWasBound(nameof(this.SnapshotName)))
            {
                WriteWarning("You are passing $null as a value for parameter SnapshotName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.KinesisAnalyticsV2.Model.Tag>(this.Tag);
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
            var request = new Amazon.KinesisAnalyticsV2.Model.ImportSnapshotRequest();
            
            
             // populate DestinationEncryptionConfiguration
            var requestDestinationEncryptionConfigurationIsNull = true;
            request.DestinationEncryptionConfiguration = new Amazon.KinesisAnalyticsV2.Model.SnapshotEncryptionConfiguration();
            System.String requestDestinationEncryptionConfiguration_destinationEncryptionConfiguration_KeyId = null;
            if (cmdletContext.DestinationEncryptionConfiguration_KeyId != null)
            {
                requestDestinationEncryptionConfiguration_destinationEncryptionConfiguration_KeyId = cmdletContext.DestinationEncryptionConfiguration_KeyId;
            }
            if (requestDestinationEncryptionConfiguration_destinationEncryptionConfiguration_KeyId != null)
            {
                request.DestinationEncryptionConfiguration.KeyId = requestDestinationEncryptionConfiguration_destinationEncryptionConfiguration_KeyId;
                requestDestinationEncryptionConfigurationIsNull = false;
            }
            Amazon.KinesisAnalyticsV2.KeyType requestDestinationEncryptionConfiguration_destinationEncryptionConfiguration_KeyType = null;
            if (cmdletContext.DestinationEncryptionConfiguration_KeyType != null)
            {
                requestDestinationEncryptionConfiguration_destinationEncryptionConfiguration_KeyType = cmdletContext.DestinationEncryptionConfiguration_KeyType;
            }
            if (requestDestinationEncryptionConfiguration_destinationEncryptionConfiguration_KeyType != null)
            {
                request.DestinationEncryptionConfiguration.KeyType = requestDestinationEncryptionConfiguration_destinationEncryptionConfiguration_KeyType;
                requestDestinationEncryptionConfigurationIsNull = false;
            }
             // determine if request.DestinationEncryptionConfiguration should be set to null
            if (requestDestinationEncryptionConfigurationIsNull)
            {
                request.DestinationEncryptionConfiguration = null;
            }
            
             // populate ImportSourceConfiguration
            var requestImportSourceConfigurationIsNull = true;
            request.ImportSourceConfiguration = new Amazon.KinesisAnalyticsV2.Model.ImportSourceConfiguration();
            System.String requestImportSourceConfiguration_importSourceConfiguration_ImportRoleArn = null;
            if (cmdletContext.ImportSourceConfiguration_ImportRoleArn != null)
            {
                requestImportSourceConfiguration_importSourceConfiguration_ImportRoleArn = cmdletContext.ImportSourceConfiguration_ImportRoleArn;
            }
            if (requestImportSourceConfiguration_importSourceConfiguration_ImportRoleArn != null)
            {
                request.ImportSourceConfiguration.ImportRoleArn = requestImportSourceConfiguration_importSourceConfiguration_ImportRoleArn;
                requestImportSourceConfigurationIsNull = false;
            }
            Amazon.KinesisAnalyticsV2.StorageLocationType requestImportSourceConfiguration_importSourceConfiguration_SourceType = null;
            if (cmdletContext.ImportSourceConfiguration_SourceType != null)
            {
                requestImportSourceConfiguration_importSourceConfiguration_SourceType = cmdletContext.ImportSourceConfiguration_SourceType;
            }
            if (requestImportSourceConfiguration_importSourceConfiguration_SourceType != null)
            {
                request.ImportSourceConfiguration.SourceType = requestImportSourceConfiguration_importSourceConfiguration_SourceType;
                requestImportSourceConfigurationIsNull = false;
            }
            Amazon.KinesisAnalyticsV2.Model.SnapshotEncryptionConfiguration requestImportSourceConfiguration_importSourceConfiguration_SourceEncryptionConfiguration = null;
            
             // populate SourceEncryptionConfiguration
            var requestImportSourceConfiguration_importSourceConfiguration_SourceEncryptionConfigurationIsNull = true;
            requestImportSourceConfiguration_importSourceConfiguration_SourceEncryptionConfiguration = new Amazon.KinesisAnalyticsV2.Model.SnapshotEncryptionConfiguration();
            System.String requestImportSourceConfiguration_importSourceConfiguration_SourceEncryptionConfiguration_importSourceConfiguration_SourceEncryptionConfiguration_KeyId = null;
            if (cmdletContext.ImportSourceConfiguration_SourceEncryptionConfiguration_KeyId != null)
            {
                requestImportSourceConfiguration_importSourceConfiguration_SourceEncryptionConfiguration_importSourceConfiguration_SourceEncryptionConfiguration_KeyId = cmdletContext.ImportSourceConfiguration_SourceEncryptionConfiguration_KeyId;
            }
            if (requestImportSourceConfiguration_importSourceConfiguration_SourceEncryptionConfiguration_importSourceConfiguration_SourceEncryptionConfiguration_KeyId != null)
            {
                requestImportSourceConfiguration_importSourceConfiguration_SourceEncryptionConfiguration.KeyId = requestImportSourceConfiguration_importSourceConfiguration_SourceEncryptionConfiguration_importSourceConfiguration_SourceEncryptionConfiguration_KeyId;
                requestImportSourceConfiguration_importSourceConfiguration_SourceEncryptionConfigurationIsNull = false;
            }
            Amazon.KinesisAnalyticsV2.KeyType requestImportSourceConfiguration_importSourceConfiguration_SourceEncryptionConfiguration_importSourceConfiguration_SourceEncryptionConfiguration_KeyType = null;
            if (cmdletContext.ImportSourceConfiguration_SourceEncryptionConfiguration_KeyType != null)
            {
                requestImportSourceConfiguration_importSourceConfiguration_SourceEncryptionConfiguration_importSourceConfiguration_SourceEncryptionConfiguration_KeyType = cmdletContext.ImportSourceConfiguration_SourceEncryptionConfiguration_KeyType;
            }
            if (requestImportSourceConfiguration_importSourceConfiguration_SourceEncryptionConfiguration_importSourceConfiguration_SourceEncryptionConfiguration_KeyType != null)
            {
                requestImportSourceConfiguration_importSourceConfiguration_SourceEncryptionConfiguration.KeyType = requestImportSourceConfiguration_importSourceConfiguration_SourceEncryptionConfiguration_importSourceConfiguration_SourceEncryptionConfiguration_KeyType;
                requestImportSourceConfiguration_importSourceConfiguration_SourceEncryptionConfigurationIsNull = false;
            }
             // determine if requestImportSourceConfiguration_importSourceConfiguration_SourceEncryptionConfiguration should be set to null
            if (requestImportSourceConfiguration_importSourceConfiguration_SourceEncryptionConfigurationIsNull)
            {
                requestImportSourceConfiguration_importSourceConfiguration_SourceEncryptionConfiguration = null;
            }
            if (requestImportSourceConfiguration_importSourceConfiguration_SourceEncryptionConfiguration != null)
            {
                request.ImportSourceConfiguration.SourceEncryptionConfiguration = requestImportSourceConfiguration_importSourceConfiguration_SourceEncryptionConfiguration;
                requestImportSourceConfigurationIsNull = false;
            }
            Amazon.KinesisAnalyticsV2.Model.S3PrefixLocation requestImportSourceConfiguration_importSourceConfiguration_SourceS3PrefixLocation = null;
            
             // populate SourceS3PrefixLocation
            var requestImportSourceConfiguration_importSourceConfiguration_SourceS3PrefixLocationIsNull = true;
            requestImportSourceConfiguration_importSourceConfiguration_SourceS3PrefixLocation = new Amazon.KinesisAnalyticsV2.Model.S3PrefixLocation();
            System.String requestImportSourceConfiguration_importSourceConfiguration_SourceS3PrefixLocation_importSourceConfiguration_SourceS3PrefixLocation_BucketARN = null;
            if (cmdletContext.ImportSourceConfiguration_SourceS3PrefixLocation_BucketARN != null)
            {
                requestImportSourceConfiguration_importSourceConfiguration_SourceS3PrefixLocation_importSourceConfiguration_SourceS3PrefixLocation_BucketARN = cmdletContext.ImportSourceConfiguration_SourceS3PrefixLocation_BucketARN;
            }
            if (requestImportSourceConfiguration_importSourceConfiguration_SourceS3PrefixLocation_importSourceConfiguration_SourceS3PrefixLocation_BucketARN != null)
            {
                requestImportSourceConfiguration_importSourceConfiguration_SourceS3PrefixLocation.BucketARN = requestImportSourceConfiguration_importSourceConfiguration_SourceS3PrefixLocation_importSourceConfiguration_SourceS3PrefixLocation_BucketARN;
                requestImportSourceConfiguration_importSourceConfiguration_SourceS3PrefixLocationIsNull = false;
            }
            System.String requestImportSourceConfiguration_importSourceConfiguration_SourceS3PrefixLocation_importSourceConfiguration_SourceS3PrefixLocation_KeyPrefix = null;
            if (cmdletContext.ImportSourceConfiguration_SourceS3PrefixLocation_KeyPrefix != null)
            {
                requestImportSourceConfiguration_importSourceConfiguration_SourceS3PrefixLocation_importSourceConfiguration_SourceS3PrefixLocation_KeyPrefix = cmdletContext.ImportSourceConfiguration_SourceS3PrefixLocation_KeyPrefix;
            }
            if (requestImportSourceConfiguration_importSourceConfiguration_SourceS3PrefixLocation_importSourceConfiguration_SourceS3PrefixLocation_KeyPrefix != null)
            {
                requestImportSourceConfiguration_importSourceConfiguration_SourceS3PrefixLocation.KeyPrefix = requestImportSourceConfiguration_importSourceConfiguration_SourceS3PrefixLocation_importSourceConfiguration_SourceS3PrefixLocation_KeyPrefix;
                requestImportSourceConfiguration_importSourceConfiguration_SourceS3PrefixLocationIsNull = false;
            }
             // determine if requestImportSourceConfiguration_importSourceConfiguration_SourceS3PrefixLocation should be set to null
            if (requestImportSourceConfiguration_importSourceConfiguration_SourceS3PrefixLocationIsNull)
            {
                requestImportSourceConfiguration_importSourceConfiguration_SourceS3PrefixLocation = null;
            }
            if (requestImportSourceConfiguration_importSourceConfiguration_SourceS3PrefixLocation != null)
            {
                request.ImportSourceConfiguration.SourceS3PrefixLocation = requestImportSourceConfiguration_importSourceConfiguration_SourceS3PrefixLocation;
                requestImportSourceConfigurationIsNull = false;
            }
             // determine if request.ImportSourceConfiguration should be set to null
            if (requestImportSourceConfigurationIsNull)
            {
                request.ImportSourceConfiguration = null;
            }
            if (cmdletContext.SnapshotDescription != null)
            {
                request.SnapshotDescription = cmdletContext.SnapshotDescription;
            }
            if (cmdletContext.SnapshotFormat != null)
            {
                request.SnapshotFormat = cmdletContext.SnapshotFormat;
            }
            if (cmdletContext.SnapshotName != null)
            {
                request.SnapshotName = cmdletContext.SnapshotName;
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
        
        private Amazon.KinesisAnalyticsV2.Model.ImportSnapshotResponse CallAWSServiceOperation(IAmazonKinesisAnalyticsV2 client, Amazon.KinesisAnalyticsV2.Model.ImportSnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Analytics V2", "ImportSnapshot");
            try
            {
                return client.ImportSnapshotAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DestinationEncryptionConfiguration_KeyId { get; set; }
            public Amazon.KinesisAnalyticsV2.KeyType DestinationEncryptionConfiguration_KeyType { get; set; }
            public System.String ImportSourceConfiguration_ImportRoleArn { get; set; }
            public System.String ImportSourceConfiguration_SourceEncryptionConfiguration_KeyId { get; set; }
            public Amazon.KinesisAnalyticsV2.KeyType ImportSourceConfiguration_SourceEncryptionConfiguration_KeyType { get; set; }
            public System.String ImportSourceConfiguration_SourceS3PrefixLocation_BucketARN { get; set; }
            public System.String ImportSourceConfiguration_SourceS3PrefixLocation_KeyPrefix { get; set; }
            public Amazon.KinesisAnalyticsV2.StorageLocationType ImportSourceConfiguration_SourceType { get; set; }
            public System.String SnapshotDescription { get; set; }
            public Amazon.KinesisAnalyticsV2.SnapshotFormat SnapshotFormat { get; set; }
            public System.String SnapshotName { get; set; }
            public List<Amazon.KinesisAnalyticsV2.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.KinesisAnalyticsV2.Model.ImportSnapshotResponse, ImportKINA2SnapshotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
