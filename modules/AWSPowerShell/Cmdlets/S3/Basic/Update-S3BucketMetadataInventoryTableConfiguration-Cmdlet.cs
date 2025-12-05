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
using Amazon.S3;
using Amazon.S3.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Enables or disables a live inventory table for an S3 Metadata configuration on a general
    /// purpose bucket. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/metadata-tables-overview.html">Accelerating
    /// data discovery with S3 Metadata</a> in the <i>Amazon S3 User Guide</i>.
    /// 
    ///  <dl><dt>Permissions</dt><dd><para>
    /// To use this operation, you must have the following permissions. For more information,
    /// see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/metadata-tables-permissions.html">Setting
    /// up permissions for configuring metadata tables</a> in the <i>Amazon S3 User Guide</i>.
    /// </para><para>
    /// If you want to encrypt your inventory table with server-side encryption with Key Management
    /// Service (KMS) keys (SSE-KMS), you need additional permissions in your KMS key policy.
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/metadata-tables-permissions.html">
    /// Setting up permissions for configuring metadata tables</a> in the <i>Amazon S3 User
    /// Guide</i>.
    /// </para><ul><li><para><c>s3:UpdateBucketMetadataInventoryTableConfiguration</c></para></li><li><para><c>s3tables:CreateTableBucket</c></para></li><li><para><c>s3tables:CreateNamespace</c></para></li><li><para><c>s3tables:GetTable</c></para></li><li><para><c>s3tables:CreateTable</c></para></li><li><para><c>s3tables:PutTablePolicy</c></para></li><li><para><c>s3tables:PutTableEncryption</c></para></li><li><para><c>kms:DescribeKey</c></para></li></ul></dd></dl><para>
    /// The following operations are related to <c>UpdateBucketMetadataInventoryTableConfiguration</c>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_CreateBucketMetadataConfiguration.html">CreateBucketMetadataConfiguration</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_DeleteBucketMetadataConfiguration.html">DeleteBucketMetadataConfiguration</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetBucketMetadataConfiguration.html">GetBucketMetadataConfiguration</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_UpdateBucketMetadataJournalTableConfiguration.html">UpdateBucketMetadataJournalTableConfiguration</a></para></li></ul><important><para>
    /// You must URL encode any signed header values that contain spaces. For example, if
    /// your header value is <c>my file.txt</c>, containing two spaces after <c>my</c>, you
    /// must URL encode this value to <c>my%20%20file.txt</c>.
    /// </para></important>
    /// </summary>
    [Cmdlet("Update", "S3BucketMetadataInventoryTableConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) UpdateBucketMetadataInventoryTableConfiguration API operation.", Operation = new[] {"UpdateBucketMetadataInventoryTableConfiguration"}, SelectReturnType = typeof(Amazon.S3.Model.UpdateBucketMetadataInventoryTableConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.S3.Model.UpdateBucketMetadataInventoryTableConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3.Model.UpdateBucketMetadataInventoryTableConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateS3BucketMetadataInventoryTableConfigurationCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// The general purpose bucket that you want to update the inventory table configuration for.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter ChecksumAlgorithm
        /// <summary>
        /// <para>
        /// The checksum algorithm to use with your inventory table configuration update.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ChecksumAlgorithm")]
        public Amazon.S3.ChecksumAlgorithm ChecksumAlgorithm { get; set; }
        #endregion
        
        #region Parameter InventoryTableConfiguration_ConfigurationState
        /// <summary>
        /// <para>
        /// The state of the inventory table configuration.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.InventoryConfigurationState")]
        public Amazon.S3.InventoryConfigurationState InventoryTableConfiguration_ConfigurationState { get; set; }
        #endregion
        
        #region Parameter ContentMD5
        /// <summary>
        /// <para>
        /// The <c>Content-MD5</c> header for the inventory table configuration update.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContentMD5 { get; set; }
        #endregion
        
        #region Parameter ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// The account ID of the expected bucket owner. If the account ID that you provide does not 
        /// match the actual owner of the bucket, the request fails with the HTTP status code 
        /// <c>403 Forbidden</c> (access denied).
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para> If server-side encryption with Key Management Service (KMS) keys (SSE-KMS) is specified,
        /// you must also specify the KMS key Amazon Resource Name (ARN). You must specify a customer-managed
        /// KMS key that's located in the same Region as the general purpose bucket that corresponds
        /// to the metadata table configuration. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InventoryTableConfiguration_EncryptionConfiguration_KmsKeyArn")]
        public System.String EncryptionConfiguration_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_SseAlgorithm
        /// <summary>
        /// <para>
        /// <para> The encryption type specified for a metadata table. To specify server-side encryption
        /// with Key Management Service (KMS) keys (SSE-KMS), use the <c>aws:kms</c> value. To
        /// specify server-side encryption with Amazon S3 managed keys (SSE-S3), use the <c>AES256</c>
        /// value. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InventoryTableConfiguration_EncryptionConfiguration_SseAlgorithm")]
        [AWSConstantClassSource("Amazon.S3.TableSseAlgorithm")]
        public Amazon.S3.TableSseAlgorithm EncryptionConfiguration_SseAlgorithm { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.UpdateBucketMetadataInventoryTableConfigurationResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BucketName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-S3BucketMetadataInventoryTableConfiguration (UpdateBucketMetadataInventoryTableConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.UpdateBucketMetadataInventoryTableConfigurationResponse, UpdateS3BucketMetadataInventoryTableConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BucketName = this.BucketName;
            context.ChecksumAlgorithm = this.ChecksumAlgorithm;
            context.ContentMD5 = this.ContentMD5;
            context.InventoryTableConfiguration_ConfigurationState = this.InventoryTableConfiguration_ConfigurationState;
            context.EncryptionConfiguration_KmsKeyArn = this.EncryptionConfiguration_KmsKeyArn;
            context.EncryptionConfiguration_SseAlgorithm = this.EncryptionConfiguration_SseAlgorithm;
            context.ExpectedBucketOwner = this.ExpectedBucketOwner;
            
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
            var request = new Amazon.S3.Model.UpdateBucketMetadataInventoryTableConfigurationRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.ChecksumAlgorithm != null)
            {
                request.ChecksumAlgorithm = cmdletContext.ChecksumAlgorithm;
            }
            if (cmdletContext.ContentMD5 != null)
            {
                request.ContentMD5 = cmdletContext.ContentMD5;
            }
            
             // populate InventoryTableConfiguration
            var requestInventoryTableConfigurationIsNull = true;
            request.InventoryTableConfiguration = new Amazon.S3.Model.InventoryTableConfigurationUpdates();
            Amazon.S3.InventoryConfigurationState requestInventoryTableConfiguration_inventoryTableConfiguration_ConfigurationState = null;
            if (cmdletContext.InventoryTableConfiguration_ConfigurationState != null)
            {
                requestInventoryTableConfiguration_inventoryTableConfiguration_ConfigurationState = cmdletContext.InventoryTableConfiguration_ConfigurationState;
            }
            if (requestInventoryTableConfiguration_inventoryTableConfiguration_ConfigurationState != null)
            {
                request.InventoryTableConfiguration.ConfigurationState = requestInventoryTableConfiguration_inventoryTableConfiguration_ConfigurationState;
                requestInventoryTableConfigurationIsNull = false;
            }
            Amazon.S3.Model.MetadataTableEncryptionConfiguration requestInventoryTableConfiguration_inventoryTableConfiguration_EncryptionConfiguration = null;
            
             // populate EncryptionConfiguration
            var requestInventoryTableConfiguration_inventoryTableConfiguration_EncryptionConfigurationIsNull = true;
            requestInventoryTableConfiguration_inventoryTableConfiguration_EncryptionConfiguration = new Amazon.S3.Model.MetadataTableEncryptionConfiguration();
            System.String requestInventoryTableConfiguration_inventoryTableConfiguration_EncryptionConfiguration_encryptionConfiguration_KmsKeyArn = null;
            if (cmdletContext.EncryptionConfiguration_KmsKeyArn != null)
            {
                requestInventoryTableConfiguration_inventoryTableConfiguration_EncryptionConfiguration_encryptionConfiguration_KmsKeyArn = cmdletContext.EncryptionConfiguration_KmsKeyArn;
            }
            if (requestInventoryTableConfiguration_inventoryTableConfiguration_EncryptionConfiguration_encryptionConfiguration_KmsKeyArn != null)
            {
                requestInventoryTableConfiguration_inventoryTableConfiguration_EncryptionConfiguration.KmsKeyArn = requestInventoryTableConfiguration_inventoryTableConfiguration_EncryptionConfiguration_encryptionConfiguration_KmsKeyArn;
                requestInventoryTableConfiguration_inventoryTableConfiguration_EncryptionConfigurationIsNull = false;
            }
            Amazon.S3.TableSseAlgorithm requestInventoryTableConfiguration_inventoryTableConfiguration_EncryptionConfiguration_encryptionConfiguration_SseAlgorithm = null;
            if (cmdletContext.EncryptionConfiguration_SseAlgorithm != null)
            {
                requestInventoryTableConfiguration_inventoryTableConfiguration_EncryptionConfiguration_encryptionConfiguration_SseAlgorithm = cmdletContext.EncryptionConfiguration_SseAlgorithm;
            }
            if (requestInventoryTableConfiguration_inventoryTableConfiguration_EncryptionConfiguration_encryptionConfiguration_SseAlgorithm != null)
            {
                requestInventoryTableConfiguration_inventoryTableConfiguration_EncryptionConfiguration.SseAlgorithm = requestInventoryTableConfiguration_inventoryTableConfiguration_EncryptionConfiguration_encryptionConfiguration_SseAlgorithm;
                requestInventoryTableConfiguration_inventoryTableConfiguration_EncryptionConfigurationIsNull = false;
            }
             // determine if requestInventoryTableConfiguration_inventoryTableConfiguration_EncryptionConfiguration should be set to null
            if (requestInventoryTableConfiguration_inventoryTableConfiguration_EncryptionConfigurationIsNull)
            {
                requestInventoryTableConfiguration_inventoryTableConfiguration_EncryptionConfiguration = null;
            }
            if (requestInventoryTableConfiguration_inventoryTableConfiguration_EncryptionConfiguration != null)
            {
                request.InventoryTableConfiguration.EncryptionConfiguration = requestInventoryTableConfiguration_inventoryTableConfiguration_EncryptionConfiguration;
                requestInventoryTableConfigurationIsNull = false;
            }
             // determine if request.InventoryTableConfiguration should be set to null
            if (requestInventoryTableConfigurationIsNull)
            {
                request.InventoryTableConfiguration = null;
            }
            if (cmdletContext.ExpectedBucketOwner != null)
            {
                request.ExpectedBucketOwner = cmdletContext.ExpectedBucketOwner;
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
        
        private Amazon.S3.Model.UpdateBucketMetadataInventoryTableConfigurationResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.UpdateBucketMetadataInventoryTableConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "UpdateBucketMetadataInventoryTableConfiguration");
            try
            {
                return client.UpdateBucketMetadataInventoryTableConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String BucketName { get; set; }
            public Amazon.S3.ChecksumAlgorithm ChecksumAlgorithm { get; set; }
            public System.String ContentMD5 { get; set; }
            public Amazon.S3.InventoryConfigurationState InventoryTableConfiguration_ConfigurationState { get; set; }
            public System.String EncryptionConfiguration_KmsKeyArn { get; set; }
            public Amazon.S3.TableSseAlgorithm EncryptionConfiguration_SseAlgorithm { get; set; }
            public System.String ExpectedBucketOwner { get; set; }
            public System.Func<Amazon.S3.Model.UpdateBucketMetadataInventoryTableConfigurationResponse, UpdateS3BucketMetadataInventoryTableConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
