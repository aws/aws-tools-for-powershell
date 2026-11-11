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
    /// Exports the data of an enhanced snapshot to an Amazon S3 location. Managed Service
    /// for Apache Flink assumes the IAM role that you specify in <c>ExportDestinationConfiguration</c>
    /// to write the snapshot data. The snapshot must be in the <c>READY</c> status.
    /// 
    ///  
    /// <para>
    /// This operation is asynchronous. To track the progress of the export, use <c>DescribeSnapshotOperation</c>.
    /// </para><para>
    /// A snapshot can have only one export in progress at a time. If an export of the snapshot
    /// is already in progress, <c>LimitExceededException</c> is returned.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/managed-flink/latest/java/snapshots-import-export.html">Import
    /// and export</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Export", "KINA2Snapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KinesisAnalyticsV2.Model.ExportSnapshotResponse")]
    [AWSCmdlet("Calls the Amazon Kinesis Analytics V2 ExportSnapshot API operation.", Operation = new[] {"ExportSnapshot"}, SelectReturnType = typeof(Amazon.KinesisAnalyticsV2.Model.ExportSnapshotResponse))]
    [AWSCmdletOutput("Amazon.KinesisAnalyticsV2.Model.ExportSnapshotResponse",
        "This cmdlet returns an Amazon.KinesisAnalyticsV2.Model.ExportSnapshotResponse object containing multiple properties."
    )]
    public partial class ExportKINA2SnapshotCmdlet : AmazonKinesisAnalyticsV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ExportDestinationConfiguration_DestinationS3PrefixLocation_BucketARN
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
        public System.String ExportDestinationConfiguration_DestinationS3PrefixLocation_BucketARN { get; set; }
        #endregion
        
        #region Parameter ExportDestinationConfiguration_DestinationType
        /// <summary>
        /// <para>
        /// <para>The type of the destination location. The only supported value is <c>S3</c>.</para>
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
        public Amazon.KinesisAnalyticsV2.StorageLocationType ExportDestinationConfiguration_DestinationType { get; set; }
        #endregion
        
        #region Parameter ExportDestinationConfiguration_ExportRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that Managed Service for Apache Flink assumes to write the
        /// snapshot data to the destination location. For information about the permissions that
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
        public System.String ExportDestinationConfiguration_ExportRoleArn { get; set; }
        #endregion
        
        #region Parameter ExportDestinationConfiguration_DestinationEncryptionConfiguration_KeyId
        /// <summary>
        /// <para>
        /// <para>The KMS key used for encryption. <c>KeyId</c> is used only when <c>KeyType</c> is
        /// <c>CUSTOMER_MANAGED_KEY</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExportDestinationConfiguration_DestinationEncryptionConfiguration_KeyId { get; set; }
        #endregion
        
        #region Parameter ExportDestinationConfiguration_DestinationS3PrefixLocation_KeyPrefix
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
        public System.String ExportDestinationConfiguration_DestinationS3PrefixLocation_KeyPrefix { get; set; }
        #endregion
        
        #region Parameter ExportDestinationConfiguration_DestinationEncryptionConfiguration_KeyType
        /// <summary>
        /// <para>
        /// <para>Specifies the type of key used for encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisAnalyticsV2.KeyType")]
        public Amazon.KinesisAnalyticsV2.KeyType ExportDestinationConfiguration_DestinationEncryptionConfiguration_KeyType { get; set; }
        #endregion
        
        #region Parameter SnapshotName
        /// <summary>
        /// <para>
        /// <para>The name of the enhanced snapshot to export.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisAnalyticsV2.Model.ExportSnapshotResponse).
        /// Specifying the name of a property of type Amazon.KinesisAnalyticsV2.Model.ExportSnapshotResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Export-KINA2Snapshot (ExportSnapshot)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KinesisAnalyticsV2.Model.ExportSnapshotResponse, ExportKINA2SnapshotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ExportDestinationConfiguration_DestinationEncryptionConfiguration_KeyId = this.ExportDestinationConfiguration_DestinationEncryptionConfiguration_KeyId;
            context.ExportDestinationConfiguration_DestinationEncryptionConfiguration_KeyType = this.ExportDestinationConfiguration_DestinationEncryptionConfiguration_KeyType;
            context.ExportDestinationConfiguration_DestinationS3PrefixLocation_BucketARN = this.ExportDestinationConfiguration_DestinationS3PrefixLocation_BucketARN;
            #if MODULAR
            if (this.ExportDestinationConfiguration_DestinationS3PrefixLocation_BucketARN == null && ParameterWasBound(nameof(this.ExportDestinationConfiguration_DestinationS3PrefixLocation_BucketARN)))
            {
                WriteWarning("You are passing $null as a value for parameter ExportDestinationConfiguration_DestinationS3PrefixLocation_BucketARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExportDestinationConfiguration_DestinationS3PrefixLocation_KeyPrefix = this.ExportDestinationConfiguration_DestinationS3PrefixLocation_KeyPrefix;
            #if MODULAR
            if (this.ExportDestinationConfiguration_DestinationS3PrefixLocation_KeyPrefix == null && ParameterWasBound(nameof(this.ExportDestinationConfiguration_DestinationS3PrefixLocation_KeyPrefix)))
            {
                WriteWarning("You are passing $null as a value for parameter ExportDestinationConfiguration_DestinationS3PrefixLocation_KeyPrefix which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExportDestinationConfiguration_DestinationType = this.ExportDestinationConfiguration_DestinationType;
            #if MODULAR
            if (this.ExportDestinationConfiguration_DestinationType == null && ParameterWasBound(nameof(this.ExportDestinationConfiguration_DestinationType)))
            {
                WriteWarning("You are passing $null as a value for parameter ExportDestinationConfiguration_DestinationType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExportDestinationConfiguration_ExportRoleArn = this.ExportDestinationConfiguration_ExportRoleArn;
            #if MODULAR
            if (this.ExportDestinationConfiguration_ExportRoleArn == null && ParameterWasBound(nameof(this.ExportDestinationConfiguration_ExportRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ExportDestinationConfiguration_ExportRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SnapshotName = this.SnapshotName;
            #if MODULAR
            if (this.SnapshotName == null && ParameterWasBound(nameof(this.SnapshotName)))
            {
                WriteWarning("You are passing $null as a value for parameter SnapshotName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.KinesisAnalyticsV2.Model.ExportSnapshotRequest();
            
            
             // populate ExportDestinationConfiguration
            var requestExportDestinationConfigurationIsNull = true;
            request.ExportDestinationConfiguration = new Amazon.KinesisAnalyticsV2.Model.ExportDestinationConfiguration();
            Amazon.KinesisAnalyticsV2.StorageLocationType requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationType = null;
            if (cmdletContext.ExportDestinationConfiguration_DestinationType != null)
            {
                requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationType = cmdletContext.ExportDestinationConfiguration_DestinationType;
            }
            if (requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationType != null)
            {
                request.ExportDestinationConfiguration.DestinationType = requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationType;
                requestExportDestinationConfigurationIsNull = false;
            }
            System.String requestExportDestinationConfiguration_exportDestinationConfiguration_ExportRoleArn = null;
            if (cmdletContext.ExportDestinationConfiguration_ExportRoleArn != null)
            {
                requestExportDestinationConfiguration_exportDestinationConfiguration_ExportRoleArn = cmdletContext.ExportDestinationConfiguration_ExportRoleArn;
            }
            if (requestExportDestinationConfiguration_exportDestinationConfiguration_ExportRoleArn != null)
            {
                request.ExportDestinationConfiguration.ExportRoleArn = requestExportDestinationConfiguration_exportDestinationConfiguration_ExportRoleArn;
                requestExportDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisAnalyticsV2.Model.SnapshotEncryptionConfiguration requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationEncryptionConfiguration = null;
            
             // populate DestinationEncryptionConfiguration
            var requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationEncryptionConfigurationIsNull = true;
            requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationEncryptionConfiguration = new Amazon.KinesisAnalyticsV2.Model.SnapshotEncryptionConfiguration();
            System.String requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationEncryptionConfiguration_exportDestinationConfiguration_DestinationEncryptionConfiguration_KeyId = null;
            if (cmdletContext.ExportDestinationConfiguration_DestinationEncryptionConfiguration_KeyId != null)
            {
                requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationEncryptionConfiguration_exportDestinationConfiguration_DestinationEncryptionConfiguration_KeyId = cmdletContext.ExportDestinationConfiguration_DestinationEncryptionConfiguration_KeyId;
            }
            if (requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationEncryptionConfiguration_exportDestinationConfiguration_DestinationEncryptionConfiguration_KeyId != null)
            {
                requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationEncryptionConfiguration.KeyId = requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationEncryptionConfiguration_exportDestinationConfiguration_DestinationEncryptionConfiguration_KeyId;
                requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationEncryptionConfigurationIsNull = false;
            }
            Amazon.KinesisAnalyticsV2.KeyType requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationEncryptionConfiguration_exportDestinationConfiguration_DestinationEncryptionConfiguration_KeyType = null;
            if (cmdletContext.ExportDestinationConfiguration_DestinationEncryptionConfiguration_KeyType != null)
            {
                requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationEncryptionConfiguration_exportDestinationConfiguration_DestinationEncryptionConfiguration_KeyType = cmdletContext.ExportDestinationConfiguration_DestinationEncryptionConfiguration_KeyType;
            }
            if (requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationEncryptionConfiguration_exportDestinationConfiguration_DestinationEncryptionConfiguration_KeyType != null)
            {
                requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationEncryptionConfiguration.KeyType = requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationEncryptionConfiguration_exportDestinationConfiguration_DestinationEncryptionConfiguration_KeyType;
                requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationEncryptionConfigurationIsNull = false;
            }
             // determine if requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationEncryptionConfiguration should be set to null
            if (requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationEncryptionConfigurationIsNull)
            {
                requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationEncryptionConfiguration = null;
            }
            if (requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationEncryptionConfiguration != null)
            {
                request.ExportDestinationConfiguration.DestinationEncryptionConfiguration = requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationEncryptionConfiguration;
                requestExportDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisAnalyticsV2.Model.S3PrefixLocation requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationS3PrefixLocation = null;
            
             // populate DestinationS3PrefixLocation
            var requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationS3PrefixLocationIsNull = true;
            requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationS3PrefixLocation = new Amazon.KinesisAnalyticsV2.Model.S3PrefixLocation();
            System.String requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationS3PrefixLocation_exportDestinationConfiguration_DestinationS3PrefixLocation_BucketARN = null;
            if (cmdletContext.ExportDestinationConfiguration_DestinationS3PrefixLocation_BucketARN != null)
            {
                requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationS3PrefixLocation_exportDestinationConfiguration_DestinationS3PrefixLocation_BucketARN = cmdletContext.ExportDestinationConfiguration_DestinationS3PrefixLocation_BucketARN;
            }
            if (requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationS3PrefixLocation_exportDestinationConfiguration_DestinationS3PrefixLocation_BucketARN != null)
            {
                requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationS3PrefixLocation.BucketARN = requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationS3PrefixLocation_exportDestinationConfiguration_DestinationS3PrefixLocation_BucketARN;
                requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationS3PrefixLocationIsNull = false;
            }
            System.String requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationS3PrefixLocation_exportDestinationConfiguration_DestinationS3PrefixLocation_KeyPrefix = null;
            if (cmdletContext.ExportDestinationConfiguration_DestinationS3PrefixLocation_KeyPrefix != null)
            {
                requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationS3PrefixLocation_exportDestinationConfiguration_DestinationS3PrefixLocation_KeyPrefix = cmdletContext.ExportDestinationConfiguration_DestinationS3PrefixLocation_KeyPrefix;
            }
            if (requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationS3PrefixLocation_exportDestinationConfiguration_DestinationS3PrefixLocation_KeyPrefix != null)
            {
                requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationS3PrefixLocation.KeyPrefix = requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationS3PrefixLocation_exportDestinationConfiguration_DestinationS3PrefixLocation_KeyPrefix;
                requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationS3PrefixLocationIsNull = false;
            }
             // determine if requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationS3PrefixLocation should be set to null
            if (requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationS3PrefixLocationIsNull)
            {
                requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationS3PrefixLocation = null;
            }
            if (requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationS3PrefixLocation != null)
            {
                request.ExportDestinationConfiguration.DestinationS3PrefixLocation = requestExportDestinationConfiguration_exportDestinationConfiguration_DestinationS3PrefixLocation;
                requestExportDestinationConfigurationIsNull = false;
            }
             // determine if request.ExportDestinationConfiguration should be set to null
            if (requestExportDestinationConfigurationIsNull)
            {
                request.ExportDestinationConfiguration = null;
            }
            if (cmdletContext.SnapshotName != null)
            {
                request.SnapshotName = cmdletContext.SnapshotName;
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
        
        private Amazon.KinesisAnalyticsV2.Model.ExportSnapshotResponse CallAWSServiceOperation(IAmazonKinesisAnalyticsV2 client, Amazon.KinesisAnalyticsV2.Model.ExportSnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Analytics V2", "ExportSnapshot");
            try
            {
                return client.ExportSnapshotAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ExportDestinationConfiguration_DestinationEncryptionConfiguration_KeyId { get; set; }
            public Amazon.KinesisAnalyticsV2.KeyType ExportDestinationConfiguration_DestinationEncryptionConfiguration_KeyType { get; set; }
            public System.String ExportDestinationConfiguration_DestinationS3PrefixLocation_BucketARN { get; set; }
            public System.String ExportDestinationConfiguration_DestinationS3PrefixLocation_KeyPrefix { get; set; }
            public Amazon.KinesisAnalyticsV2.StorageLocationType ExportDestinationConfiguration_DestinationType { get; set; }
            public System.String ExportDestinationConfiguration_ExportRoleArn { get; set; }
            public System.String SnapshotName { get; set; }
            public System.Func<Amazon.KinesisAnalyticsV2.Model.ExportSnapshotResponse, ExportKINA2SnapshotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
