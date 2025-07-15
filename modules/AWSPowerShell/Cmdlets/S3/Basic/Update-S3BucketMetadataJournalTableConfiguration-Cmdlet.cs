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
    /// Enables or disables journal table record expiration for an S3 Metadata configuration
    /// on a general purpose bucket. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/metadata-tables-overview.html">Accelerating
    /// data discovery with S3 Metadata</a> in the <i>Amazon S3 User Guide</i>.
    /// 
    ///  <dl><dt>Permissions</dt><dd><para>
    /// To use this operation, you must have the <c>s3:UpdateBucketMetadataJournalTableConfiguration</c>
    /// permission. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/metadata-tables-permissions.html">Setting
    /// up permissions for configuring metadata tables</a> in the <i>Amazon S3 User Guide</i>.
    /// 
    /// </para></dd></dl><para>
    /// The following operations are related to <c>UpdateBucketMetadataJournalTableConfiguration</c>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_CreateBucketMetadataConfiguration.html">CreateBucketMetadataConfiguration</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_DeleteBucketMetadataConfiguration.html">DeleteBucketMetadataConfiguration</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetBucketMetadataConfiguration.html">GetBucketMetadataConfiguration</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_UpdateBucketMetadataInventoryTableConfiguration.html">UpdateBucketMetadataInventoryTableConfiguration</a></para></li></ul>
    /// </summary>
    [Cmdlet("Update", "S3BucketMetadataJournalTableConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) UpdateBucketMetadataJournalTableConfiguration API operation.", Operation = new[] {"UpdateBucketMetadataJournalTableConfiguration"}, SelectReturnType = typeof(Amazon.S3.Model.UpdateBucketMetadataJournalTableConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.S3.Model.UpdateBucketMetadataJournalTableConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3.Model.UpdateBucketMetadataJournalTableConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateS3BucketMetadataJournalTableConfigurationCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// The general purpose bucket that you want to update the journal table configuration for.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter ChecksumAlgorithm
        /// <summary>
        /// <para>
        /// The checksum algorithm to use with your journal table configuration update.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ChecksumAlgorithm")]
        public Amazon.S3.ChecksumAlgorithm ChecksumAlgorithm { get; set; }
        #endregion
        
        #region Parameter JournalTableConfiguration_ConfigurationState
        /// <summary>
        /// <para>
        /// The state of the journal table configuration.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.JournalConfigurationState")]
        public Amazon.S3.JournalConfigurationState JournalTableConfiguration_ConfigurationState { get; set; }
        #endregion
        
        #region Parameter ContentMD5
        /// <summary>
        /// <para>
        /// The <c>Content-MD5</c> header for the journal table configuration update.
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
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JournalTableConfiguration_EncryptionConfiguration_KmsKeyArn")]
        public System.String EncryptionConfiguration_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_SseAlgorithm
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JournalTableConfiguration_EncryptionConfiguration_SseAlgorithm")]
        [AWSConstantClassSource("Amazon.S3.TableSseAlgorithm")]
        public Amazon.S3.TableSseAlgorithm EncryptionConfiguration_SseAlgorithm { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.UpdateBucketMetadataJournalTableConfigurationResponse).
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-S3BucketMetadataJournalTableConfiguration (UpdateBucketMetadataJournalTableConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.UpdateBucketMetadataJournalTableConfigurationResponse, UpdateS3BucketMetadataJournalTableConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BucketName = this.BucketName;
            context.ChecksumAlgorithm = this.ChecksumAlgorithm;
            context.ContentMD5 = this.ContentMD5;
            context.JournalTableConfiguration_ConfigurationState = this.JournalTableConfiguration_ConfigurationState;
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
            var request = new Amazon.S3.Model.UpdateBucketMetadataJournalTableConfigurationRequest();
            
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
            
             // populate JournalTableConfiguration
            var requestJournalTableConfigurationIsNull = true;
            request.JournalTableConfiguration = new Amazon.S3.Model.JournalTableConfigurationUpdates();
            Amazon.S3.JournalConfigurationState requestJournalTableConfiguration_journalTableConfiguration_ConfigurationState = null;
            if (cmdletContext.JournalTableConfiguration_ConfigurationState != null)
            {
                requestJournalTableConfiguration_journalTableConfiguration_ConfigurationState = cmdletContext.JournalTableConfiguration_ConfigurationState;
            }
            if (requestJournalTableConfiguration_journalTableConfiguration_ConfigurationState != null)
            {
                request.JournalTableConfiguration.ConfigurationState = requestJournalTableConfiguration_journalTableConfiguration_ConfigurationState;
                requestJournalTableConfigurationIsNull = false;
            }
            Amazon.S3.Model.MetadataTableEncryptionConfiguration requestJournalTableConfiguration_journalTableConfiguration_EncryptionConfiguration = null;
            
             // populate EncryptionConfiguration
            var requestJournalTableConfiguration_journalTableConfiguration_EncryptionConfigurationIsNull = true;
            requestJournalTableConfiguration_journalTableConfiguration_EncryptionConfiguration = new Amazon.S3.Model.MetadataTableEncryptionConfiguration();
            System.String requestJournalTableConfiguration_journalTableConfiguration_EncryptionConfiguration_encryptionConfiguration_KmsKeyArn = null;
            if (cmdletContext.EncryptionConfiguration_KmsKeyArn != null)
            {
                requestJournalTableConfiguration_journalTableConfiguration_EncryptionConfiguration_encryptionConfiguration_KmsKeyArn = cmdletContext.EncryptionConfiguration_KmsKeyArn;
            }
            if (requestJournalTableConfiguration_journalTableConfiguration_EncryptionConfiguration_encryptionConfiguration_KmsKeyArn != null)
            {
                requestJournalTableConfiguration_journalTableConfiguration_EncryptionConfiguration.KmsKeyArn = requestJournalTableConfiguration_journalTableConfiguration_EncryptionConfiguration_encryptionConfiguration_KmsKeyArn;
                requestJournalTableConfiguration_journalTableConfiguration_EncryptionConfigurationIsNull = false;
            }
            Amazon.S3.TableSseAlgorithm requestJournalTableConfiguration_journalTableConfiguration_EncryptionConfiguration_encryptionConfiguration_SseAlgorithm = null;
            if (cmdletContext.EncryptionConfiguration_SseAlgorithm != null)
            {
                requestJournalTableConfiguration_journalTableConfiguration_EncryptionConfiguration_encryptionConfiguration_SseAlgorithm = cmdletContext.EncryptionConfiguration_SseAlgorithm;
            }
            if (requestJournalTableConfiguration_journalTableConfiguration_EncryptionConfiguration_encryptionConfiguration_SseAlgorithm != null)
            {
                requestJournalTableConfiguration_journalTableConfiguration_EncryptionConfiguration.SseAlgorithm = requestJournalTableConfiguration_journalTableConfiguration_EncryptionConfiguration_encryptionConfiguration_SseAlgorithm;
                requestJournalTableConfiguration_journalTableConfiguration_EncryptionConfigurationIsNull = false;
            }
             // determine if requestJournalTableConfiguration_journalTableConfiguration_EncryptionConfiguration should be set to null
            if (requestJournalTableConfiguration_journalTableConfiguration_EncryptionConfigurationIsNull)
            {
                requestJournalTableConfiguration_journalTableConfiguration_EncryptionConfiguration = null;
            }
            if (requestJournalTableConfiguration_journalTableConfiguration_EncryptionConfiguration != null)
            {
                request.JournalTableConfiguration.EncryptionConfiguration = requestJournalTableConfiguration_journalTableConfiguration_EncryptionConfiguration;
                requestJournalTableConfigurationIsNull = false;
            }
             // determine if request.JournalTableConfiguration should be set to null
            if (requestJournalTableConfigurationIsNull)
            {
                request.JournalTableConfiguration = null;
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
        
        private Amazon.S3.Model.UpdateBucketMetadataJournalTableConfigurationResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.UpdateBucketMetadataJournalTableConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "UpdateBucketMetadataJournalTableConfiguration");
            try
            {
                return client.UpdateBucketMetadataJournalTableConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.S3.JournalConfigurationState JournalTableConfiguration_ConfigurationState { get; set; }
            public System.String EncryptionConfiguration_KmsKeyArn { get; set; }
            public Amazon.S3.TableSseAlgorithm EncryptionConfiguration_SseAlgorithm { get; set; }
            public System.String ExpectedBucketOwner { get; set; }
            public System.Func<Amazon.S3.Model.UpdateBucketMetadataJournalTableConfigurationResponse, UpdateS3BucketMetadataJournalTableConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
