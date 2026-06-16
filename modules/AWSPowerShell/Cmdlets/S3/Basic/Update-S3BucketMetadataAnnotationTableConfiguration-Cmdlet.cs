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
    /// Updates the annotation table configuration for an Amazon S3 bucket's metadata configuration.
    /// Use this operation to enable or disable the annotation table, or to update its associated
    /// IAM role.
    /// 
    ///  
    /// <para>
    /// An annotation table is a queryable Iceberg table that contains records of all annotations
    /// attached to objects in the bucket. To use this operation, the bucket must have an
    /// existing Amazon S3 Metadata configuration.
    /// </para><para>
    /// To use this operation, you must have the <c>s3:UpdateBucketMetadataAnnotationTableConfiguration</c>
    /// permission. If you are specifying or changing the IAM role, you must also have <c>iam:PassRole</c>
    /// permission for the role.
    /// </para><para>
    /// The IAM role must have a trust policy that allows the Amazon S3 metadata service to
    /// assume it, and a permissions policy that grants the actions needed to read annotations
    /// from your bucket. The following examples show a trust policy and a permissions policy
    /// that you can adapt for your bucket and account.
    /// </para><para>
    /// The following operations are related to <c>UpdateBucketMetadataAnnotationTableConfiguration</c>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_CreateBucketMetadataConfiguration.html">CreateBucketMetadataConfiguration</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetBucketMetadataConfiguration.html">GetBucketMetadataConfiguration</a></para></li></ul>
    /// </summary>
    [Cmdlet("Update", "S3BucketMetadataAnnotationTableConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) UpdateBucketMetadataAnnotationTableConfiguration API operation.", Operation = new[] {"UpdateBucketMetadataAnnotationTableConfiguration"}, SelectReturnType = typeof(Amazon.S3.Model.UpdateBucketMetadataAnnotationTableConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.S3.Model.UpdateBucketMetadataAnnotationTableConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3.Model.UpdateBucketMetadataAnnotationTableConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateS3BucketMetadataAnnotationTableConfigurationCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the bucket whose annotation table configuration to update.</para>
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
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter ChecksumAlgorithm
        /// <summary>
        /// <para>
        /// <para>Checksum algorithm for the request payload.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ChecksumAlgorithm")]
        public Amazon.S3.ChecksumAlgorithm ChecksumAlgorithm { get; set; }
        #endregion
        
        #region Parameter AnnotationTableConfiguration_ConfigurationState
        /// <summary>
        /// <para>
        /// <para>The new configuration state to apply.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.S3.AnnotationConfigurationState")]
        public Amazon.S3.AnnotationConfigurationState AnnotationTableConfiguration_ConfigurationState { get; set; }
        #endregion
        
        #region Parameter ContentMD5
        /// <summary>
        /// <para>
        /// <para>Base64-encoded MD5 digest of the message body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContentMD5 { get; set; }
        #endregion
        
        #region Parameter ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// <para>The account ID of the expected bucket owner.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter AnnotationTableConfiguration_EncryptionConfiguration_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para> If server-side encryption with Key Management Service (KMS) keys (SSE-KMS) is specified,
        /// you must also specify the KMS key Amazon Resource Name (ARN). You must specify a customer-managed
        /// KMS key that's located in the same Region as the general purpose bucket that corresponds
        /// to the metadata table configuration. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AnnotationTableConfiguration_EncryptionConfiguration_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter AnnotationTableConfiguration_Role
        /// <summary>
        /// <para>
        /// <para>The new IAM role ARN to apply.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AnnotationTableConfiguration_Role { get; set; }
        #endregion
        
        #region Parameter AnnotationTableConfiguration_EncryptionConfiguration_SseAlgorithm
        /// <summary>
        /// <para>
        /// <para> The encryption type specified for a metadata table. To specify server-side encryption
        /// with Key Management Service (KMS) keys (SSE-KMS), use the <c>aws:kms</c> value. To
        /// specify server-side encryption with Amazon S3 managed keys (SSE-S3), use the <c>AES256</c>
        /// value. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.TableSseAlgorithm")]
        public Amazon.S3.TableSseAlgorithm AnnotationTableConfiguration_EncryptionConfiguration_SseAlgorithm { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.UpdateBucketMetadataAnnotationTableConfigurationResponse).
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-S3BucketMetadataAnnotationTableConfiguration (UpdateBucketMetadataAnnotationTableConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.UpdateBucketMetadataAnnotationTableConfigurationResponse, UpdateS3BucketMetadataAnnotationTableConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AnnotationTableConfiguration_ConfigurationState = this.AnnotationTableConfiguration_ConfigurationState;
            #if MODULAR
            if (this.AnnotationTableConfiguration_ConfigurationState == null && ParameterWasBound(nameof(this.AnnotationTableConfiguration_ConfigurationState)))
            {
                WriteWarning("You are passing $null as a value for parameter AnnotationTableConfiguration_ConfigurationState which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AnnotationTableConfiguration_EncryptionConfiguration_KmsKeyArn = this.AnnotationTableConfiguration_EncryptionConfiguration_KmsKeyArn;
            context.AnnotationTableConfiguration_EncryptionConfiguration_SseAlgorithm = this.AnnotationTableConfiguration_EncryptionConfiguration_SseAlgorithm;
            context.AnnotationTableConfiguration_Role = this.AnnotationTableConfiguration_Role;
            context.BucketName = this.BucketName;
            #if MODULAR
            if (this.BucketName == null && ParameterWasBound(nameof(this.BucketName)))
            {
                WriteWarning("You are passing $null as a value for parameter BucketName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ChecksumAlgorithm = this.ChecksumAlgorithm;
            context.ContentMD5 = this.ContentMD5;
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
            var request = new Amazon.S3.Model.UpdateBucketMetadataAnnotationTableConfigurationRequest();
            
            
             // populate AnnotationTableConfiguration
            var requestAnnotationTableConfigurationIsNull = true;
            request.AnnotationTableConfiguration = new Amazon.S3.Model.AnnotationTableConfigurationUpdates();
            Amazon.S3.AnnotationConfigurationState requestAnnotationTableConfiguration_annotationTableConfiguration_ConfigurationState = null;
            if (cmdletContext.AnnotationTableConfiguration_ConfigurationState != null)
            {
                requestAnnotationTableConfiguration_annotationTableConfiguration_ConfigurationState = cmdletContext.AnnotationTableConfiguration_ConfigurationState;
            }
            if (requestAnnotationTableConfiguration_annotationTableConfiguration_ConfigurationState != null)
            {
                request.AnnotationTableConfiguration.ConfigurationState = requestAnnotationTableConfiguration_annotationTableConfiguration_ConfigurationState;
                requestAnnotationTableConfigurationIsNull = false;
            }
            System.String requestAnnotationTableConfiguration_annotationTableConfiguration_Role = null;
            if (cmdletContext.AnnotationTableConfiguration_Role != null)
            {
                requestAnnotationTableConfiguration_annotationTableConfiguration_Role = cmdletContext.AnnotationTableConfiguration_Role;
            }
            if (requestAnnotationTableConfiguration_annotationTableConfiguration_Role != null)
            {
                request.AnnotationTableConfiguration.Role = requestAnnotationTableConfiguration_annotationTableConfiguration_Role;
                requestAnnotationTableConfigurationIsNull = false;
            }
            Amazon.S3.Model.MetadataTableEncryptionConfiguration requestAnnotationTableConfiguration_annotationTableConfiguration_EncryptionConfiguration = null;
            
             // populate EncryptionConfiguration
            var requestAnnotationTableConfiguration_annotationTableConfiguration_EncryptionConfigurationIsNull = true;
            requestAnnotationTableConfiguration_annotationTableConfiguration_EncryptionConfiguration = new Amazon.S3.Model.MetadataTableEncryptionConfiguration();
            System.String requestAnnotationTableConfiguration_annotationTableConfiguration_EncryptionConfiguration_annotationTableConfiguration_EncryptionConfiguration_KmsKeyArn = null;
            if (cmdletContext.AnnotationTableConfiguration_EncryptionConfiguration_KmsKeyArn != null)
            {
                requestAnnotationTableConfiguration_annotationTableConfiguration_EncryptionConfiguration_annotationTableConfiguration_EncryptionConfiguration_KmsKeyArn = cmdletContext.AnnotationTableConfiguration_EncryptionConfiguration_KmsKeyArn;
            }
            if (requestAnnotationTableConfiguration_annotationTableConfiguration_EncryptionConfiguration_annotationTableConfiguration_EncryptionConfiguration_KmsKeyArn != null)
            {
                requestAnnotationTableConfiguration_annotationTableConfiguration_EncryptionConfiguration.KmsKeyArn = requestAnnotationTableConfiguration_annotationTableConfiguration_EncryptionConfiguration_annotationTableConfiguration_EncryptionConfiguration_KmsKeyArn;
                requestAnnotationTableConfiguration_annotationTableConfiguration_EncryptionConfigurationIsNull = false;
            }
            Amazon.S3.TableSseAlgorithm requestAnnotationTableConfiguration_annotationTableConfiguration_EncryptionConfiguration_annotationTableConfiguration_EncryptionConfiguration_SseAlgorithm = null;
            if (cmdletContext.AnnotationTableConfiguration_EncryptionConfiguration_SseAlgorithm != null)
            {
                requestAnnotationTableConfiguration_annotationTableConfiguration_EncryptionConfiguration_annotationTableConfiguration_EncryptionConfiguration_SseAlgorithm = cmdletContext.AnnotationTableConfiguration_EncryptionConfiguration_SseAlgorithm;
            }
            if (requestAnnotationTableConfiguration_annotationTableConfiguration_EncryptionConfiguration_annotationTableConfiguration_EncryptionConfiguration_SseAlgorithm != null)
            {
                requestAnnotationTableConfiguration_annotationTableConfiguration_EncryptionConfiguration.SseAlgorithm = requestAnnotationTableConfiguration_annotationTableConfiguration_EncryptionConfiguration_annotationTableConfiguration_EncryptionConfiguration_SseAlgorithm;
                requestAnnotationTableConfiguration_annotationTableConfiguration_EncryptionConfigurationIsNull = false;
            }
             // determine if requestAnnotationTableConfiguration_annotationTableConfiguration_EncryptionConfiguration should be set to null
            if (requestAnnotationTableConfiguration_annotationTableConfiguration_EncryptionConfigurationIsNull)
            {
                requestAnnotationTableConfiguration_annotationTableConfiguration_EncryptionConfiguration = null;
            }
            if (requestAnnotationTableConfiguration_annotationTableConfiguration_EncryptionConfiguration != null)
            {
                request.AnnotationTableConfiguration.EncryptionConfiguration = requestAnnotationTableConfiguration_annotationTableConfiguration_EncryptionConfiguration;
                requestAnnotationTableConfigurationIsNull = false;
            }
             // determine if request.AnnotationTableConfiguration should be set to null
            if (requestAnnotationTableConfigurationIsNull)
            {
                request.AnnotationTableConfiguration = null;
            }
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
        
        private Amazon.S3.Model.UpdateBucketMetadataAnnotationTableConfigurationResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.UpdateBucketMetadataAnnotationTableConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "UpdateBucketMetadataAnnotationTableConfiguration");
            try
            {
                return client.UpdateBucketMetadataAnnotationTableConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.S3.AnnotationConfigurationState AnnotationTableConfiguration_ConfigurationState { get; set; }
            public System.String AnnotationTableConfiguration_EncryptionConfiguration_KmsKeyArn { get; set; }
            public Amazon.S3.TableSseAlgorithm AnnotationTableConfiguration_EncryptionConfiguration_SseAlgorithm { get; set; }
            public System.String AnnotationTableConfiguration_Role { get; set; }
            public System.String BucketName { get; set; }
            public Amazon.S3.ChecksumAlgorithm ChecksumAlgorithm { get; set; }
            public System.String ContentMD5 { get; set; }
            public System.String ExpectedBucketOwner { get; set; }
            public System.Func<Amazon.S3.Model.UpdateBucketMetadataAnnotationTableConfigurationResponse, UpdateS3BucketMetadataAnnotationTableConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
