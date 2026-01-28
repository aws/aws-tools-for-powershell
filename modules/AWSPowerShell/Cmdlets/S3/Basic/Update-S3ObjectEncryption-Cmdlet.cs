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
    /// <note><para>
    /// This operation is not supported for directory buckets or Amazon S3 on Outposts buckets.
    /// 
    /// </para></note><para>
    ///  Updates the server-side encryption type of an existing encrypted object in a general
    /// purpose bucket. You can use the <c>UpdateObjectEncryption</c> operation to change
    /// encrypted objects from server-side encryption with Amazon S3 managed keys (SSE-S3)
    /// to server-side encryption with Key Management Service (KMS) keys (SSE-KMS), or to
    /// apply S3 Bucket Keys. You can also use the <c>UpdateObjectEncryption</c> operation
    /// to change the customer-managed KMS key used to encrypt your data so that you can comply
    /// with custom key-rotation standards. 
    /// </para><para>
    /// Using the <c>UpdateObjectEncryption</c> operation, you can atomically update the server-side
    /// encryption type of an existing object in a general purpose bucket without any data
    /// movement. The <c>UpdateObjectEncryption</c> operation uses envelope encryption to
    /// re-encrypt the data key used to encrypt and decrypt your object with your newly specified
    /// server-side encryption type. In other words, when you use the <c>UpdateObjectEncryption</c>
    /// operation, your data isn't copied, archived objects in the S3 Glacier Flexible Retrieval
    /// and S3 Glacier Deep Archive storage classes aren't restored, and objects in the S3
    /// Intelligent-Tiering storage class aren't moved between tiers. Additionally, the <c>UpdateObjectEncryption</c>
    /// operation preserves all object metadata properties, including the storage class, creation
    /// date, last modified date, ETag, and checksum properties. For more information, see
    /// <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/update-sse-encryption.html">
    /// Updating server-side encryption for existing objects</a> in the <i>Amazon S3 User
    /// Guide</i>.
    /// </para><para>
    /// By default, all <c>UpdateObjectEncryption</c> requests that specify a customer-managed
    /// KMS key are restricted to KMS keys that are owned by the bucket owner's Amazon Web
    /// Services account. If you're using Organizations, you can request the ability to use
    /// KMS keys owned by other member accounts within your organization by contacting Amazon
    /// Web Services Support.
    /// </para><note><para>
    /// Source objects that are unencrypted, or encrypted with either dual-layer server-side
    /// encryption with KMS keys (DSSE-KMS) or server-side encryption with customer-provided
    /// keys (SSE-C) aren't supported by this operation. Additionally, you cannot specify
    /// SSE-S3 encryption as the requested new encryption type <c>UpdateObjectEncryption</c>
    /// request.
    /// </para></note><dl><dt>Permissions</dt><dd><ul><li><para>
    /// To use the <c>UpdateObjectEncryption</c> operation, you must have the following permissions:
    /// </para><ul><li><para><c>s3:PutObject</c></para></li><li><para><c>s3:UpdateObjectEncryption</c></para></li><li><para><c>kms:Encrypt</c></para></li><li><para><c>kms:Decrypt</c></para></li><li><para><c>kms:GenerateDataKey</c></para></li><li><para><c>kms:ReEncrypt*</c></para></li></ul></li><li><para>
    /// If you're using Organizations, to use this operation with customer-managed KMS keys
    /// from other Amazon Web Services accounts within your organization, you must have the
    /// <c>organizations:DescribeAccount</c> permission.
    /// </para></li></ul></dd></dl><dl><dt>Errors</dt><dd><ul><li><para>
    /// You might receive an <c>InvalidRequest</c> error for several reasons. Depending on
    /// the reason for the error, you might receive one of the following messages:
    /// </para><ul><li><para>
    /// The <c>UpdateObjectEncryption</c> operation doesn't supported unencrypted source objects.
    /// Only source objects encrypted with SSE-S3 or SSE-KMS are supported.
    /// </para></li><li><para>
    /// The <c>UpdateObjectEncryption</c> operation doesn't support source objects with the
    /// encryption type DSSE-KMS or SSE-C. Only source objects encrypted with SSE-S3 or SSE-KMS
    /// are supported.
    /// </para></li><li><para>
    /// The <c>UpdateObjectEncryption</c> operation doesn't support updating the encryption
    /// type to DSSE-KMS or SSE-C. Modify the request to specify SSE-KMS for the updated encryption
    /// type, and then try again.
    /// </para></li><li><para>
    /// Requests that modify an object encryption configuration require Amazon Web Services
    /// Signature Version 4. Modify the request to use Amazon Web Services Signature Version
    /// 4, and then try again.
    /// </para></li><li><para>
    /// Requests that modify an object encryption configuration require a valid new encryption
    /// type. Valid values are <c>SSEKMS</c>. Modify the request to specify SSE-KMS for the
    /// updated encryption type, and then try again.
    /// </para></li><li><para>
    /// Requests that modify an object's encryption type to SSE-KMS require an Amazon Web
    /// Services KMS key Amazon Resource Name (ARN). Modify the request to specify a KMS key
    /// ARN, and then try again.
    /// </para></li><li><para>
    /// Requests that modify an object's encryption type to SSE-KMS require a valid Amazon
    /// Web Services KMS key Amazon Resource Name (ARN). Confirm that you have a correctly
    /// formatted KMS key ARN in your request, and then try again.
    /// </para></li><li><para>
    /// The <c>BucketKeyEnabled</c> value isn't valid. Valid values are <c>true</c> or <c>false</c>.
    /// Modify the request to specify a valid value, and then try again.
    /// </para></li></ul></li><li><para>
    /// You might receive an <c>AccessDenied</c> error for several reasons. Depending on the
    /// reason for the error, you might receive one of the following messages:
    /// </para><ul><li><para>
    /// The Amazon Web Services KMS key in the request must be owned by the same account as
    /// the bucket. Modify the request to specify a KMS key from the same account, and then
    /// try again.
    /// </para></li><li><para>
    /// The bucket owner's account was approved to make <c>UpdateObjectEncryption</c> requests
    /// that use any Amazon Web Services KMS key in their organization, but the bucket owner's
    /// account isn't part of an organization in Organizations. Make sure that the bucket
    /// owner's account and the specified KMS key belong to the same organization, and then
    /// try again. 
    /// </para></li><li><para>
    /// The specified Amazon Web Services KMS key must be from the same organization in Organizations
    /// as the bucket. Specify a KMS key that belongs to the same organization as the bucket,
    /// and then try again. 
    /// </para></li><li><para>
    /// The encryption type for the specified object can’t be updated because that object
    /// is protected by S3 Object Lock. If the object has a governance-mode retention period
    /// or a legal hold, you must first remove the Object Lock status on the object before
    /// you issue your <c>UpdateObjectEncryption</c> request. You can't use the <c>UpdateObjectEncryption</c>
    /// operation with objects that have an Object Lock compliance mode retention period applied
    /// to them.
    /// </para></li></ul></li></ul></dd></dl>
    /// </summary>
    [Cmdlet("Update", "S3ObjectEncryption", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.S3.RequestCharged")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) UpdateObjectEncryption API operation.", Operation = new[] {"UpdateObjectEncryption"}, SelectReturnType = typeof(Amazon.S3.Model.UpdateObjectEncryptionResponse))]
    [AWSCmdletOutput("Amazon.S3.RequestCharged or Amazon.S3.Model.UpdateObjectEncryptionResponse",
        "This cmdlet returns an Amazon.S3.RequestCharged object.",
        "The service call response (type Amazon.S3.Model.UpdateObjectEncryptionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateS3ObjectEncryptionCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ObjectEncryption_SSEKMS_BucketKeyEnabled
        /// <summary>
        /// <para>
        /// <para> Specifies whether Amazon S3 should use an S3 Bucket Key for object encryption with
        /// server-side encryption using Key Management Service (KMS) keys (SSE-KMS). If this
        /// value isn't specified, it defaults to <c>false</c>. Setting this value to <c>true</c>
        /// causes Amazon S3 to use an S3 Bucket Key for object encryption with SSE-KMS. For more
        /// information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/bucket-key.html">
        /// Using Amazon S3 Bucket Keys</a> in the <i>Amazon S3 User Guide</i>. </para><para>Valid Values: <c>true</c> | <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ObjectEncryption_SSEKMS_BucketKeyEnabled { get; set; }
        #endregion
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// <para> The name of the general purpose bucket that contains the specified object key name.
        /// </para><para>When you use this operation with an access point attached to a general purpose bucket,
        /// you must either provide the alias of the access point in place of the bucket name
        /// or you must specify the access point Amazon Resource Name (ARN). When using the access
        /// point ARN, you must direct requests to the access point hostname. The access point
        /// hostname takes the form <c><i>AccessPointName</i>-<i>AccountId</i>.s3-accesspoint.<i>Region</i>.amazonaws.com</c>.
        /// When using this operation with an access point through the Amazon Web Services SDKs,
        /// you provide the access point ARN in place of the bucket name. For more information
        /// about access point ARNs, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/access-points-naming.html">
        /// Referencing access points</a> in the <i>Amazon S3 User Guide</i>.</para>
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
        /// <para> Indicates the algorithm used to create the checksum for the object when you use an
        /// Amazon Web Services SDK. This header doesn't provide any additional functionality
        /// if you don't use the SDK. When you send this header, there must be a corresponding
        /// <c>x-amz-checksum</c> or <c>x-amz-trailer</c> header sent. Otherwise, Amazon S3 fails
        /// the request with the HTTP status code <c>400 Bad Request</c>. For more information,
        /// see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/checking-object-integrity.html">
        /// Checking object integrity </a> in the <i>Amazon S3 User Guide</i>. </para><para>If you provide an individual checksum, Amazon S3 ignores any provided <c>ChecksumAlgorithm</c>
        /// parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ChecksumAlgorithm")]
        public Amazon.S3.ChecksumAlgorithm ChecksumAlgorithm { get; set; }
        #endregion
        
        #region Parameter ContentMD5
        /// <summary>
        /// <para>
        /// <para> The MD5 hash for the request body. For requests made using the Amazon Web Services
        /// Command Line Interface (CLI) or Amazon Web Services SDKs, this field is calculated
        /// automatically. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContentMD5 { get; set; }
        #endregion
        
        #region Parameter ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// <para> The account ID of the expected bucket owner. If the account ID that you provide doesn't
        /// match the actual owner of the bucket, the request fails with the HTTP status code
        /// <c>403 Forbidden</c> (access denied). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter Key
        /// <summary>
        /// <para>
        /// <para> The key name of the object that you want to update the server-side encryption type
        /// for. </para>
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
        public System.String Key { get; set; }
        #endregion
        
        #region Parameter ObjectEncryption_SSEKMS_KMSKeyArn
        /// <summary>
        /// <para>
        /// <para> Specifies the Amazon Web Services KMS key Amazon Resource Name (ARN) to use for the
        /// updated server-side encryption type. Required if <c>ObjectEncryption</c> specifies
        /// <c>SSEKMS</c>. </para><note><para>You must specify the full Amazon Web Services KMS key ARN. The KMS key ID and KMS
        /// key alias aren't supported.</para></note><para>Pattern: (<c>arn:aws[-a-z0-9]*:kms:[-a-z0-9]*:[0-9]{12}:key/.+</c>)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ObjectEncryption_SSEKMS_KMSKeyArn { get; set; }
        #endregion
        
        #region Parameter RequestPayer
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.RequestPayer")]
        public Amazon.S3.RequestPayer RequestPayer { get; set; }
        #endregion
        
        #region Parameter VersionId
        /// <summary>
        /// <para>
        /// <para> The version ID of the object that you want to update the server-side encryption type
        /// for. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VersionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RequestCharged'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.UpdateObjectEncryptionResponse).
        /// Specifying the name of a property of type Amazon.S3.Model.UpdateObjectEncryptionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RequestCharged";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-S3ObjectEncryption (UpdateObjectEncryption)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.UpdateObjectEncryptionResponse, UpdateS3ObjectEncryptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            context.Key = this.Key;
            #if MODULAR
            if (this.Key == null && ParameterWasBound(nameof(this.Key)))
            {
                WriteWarning("You are passing $null as a value for parameter Key which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ObjectEncryption_SSEKMS_BucketKeyEnabled = this.ObjectEncryption_SSEKMS_BucketKeyEnabled;
            context.ObjectEncryption_SSEKMS_KMSKeyArn = this.ObjectEncryption_SSEKMS_KMSKeyArn;
            context.RequestPayer = this.RequestPayer;
            context.VersionId = this.VersionId;
            
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
            var request = new Amazon.S3.Model.UpdateObjectEncryptionRequest();
            
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
            if (cmdletContext.Key != null)
            {
                request.Key = cmdletContext.Key;
            }
            
             // populate ObjectEncryption
            var requestObjectEncryptionIsNull = true;
            request.ObjectEncryption = new Amazon.S3.Model.ObjectEncryption();
            Amazon.S3.Model.SSEKMSEncryption requestObjectEncryption_objectEncryption_SSEKMS = null;
            
             // populate SSEKMS
            var requestObjectEncryption_objectEncryption_SSEKMSIsNull = true;
            requestObjectEncryption_objectEncryption_SSEKMS = new Amazon.S3.Model.SSEKMSEncryption();
            System.Boolean? requestObjectEncryption_objectEncryption_SSEKMS_objectEncryption_SSEKMS_BucketKeyEnabled = null;
            if (cmdletContext.ObjectEncryption_SSEKMS_BucketKeyEnabled != null)
            {
                requestObjectEncryption_objectEncryption_SSEKMS_objectEncryption_SSEKMS_BucketKeyEnabled = cmdletContext.ObjectEncryption_SSEKMS_BucketKeyEnabled.Value;
            }
            if (requestObjectEncryption_objectEncryption_SSEKMS_objectEncryption_SSEKMS_BucketKeyEnabled != null)
            {
                requestObjectEncryption_objectEncryption_SSEKMS.BucketKeyEnabled = requestObjectEncryption_objectEncryption_SSEKMS_objectEncryption_SSEKMS_BucketKeyEnabled.Value;
                requestObjectEncryption_objectEncryption_SSEKMSIsNull = false;
            }
            System.String requestObjectEncryption_objectEncryption_SSEKMS_objectEncryption_SSEKMS_KMSKeyArn = null;
            if (cmdletContext.ObjectEncryption_SSEKMS_KMSKeyArn != null)
            {
                requestObjectEncryption_objectEncryption_SSEKMS_objectEncryption_SSEKMS_KMSKeyArn = cmdletContext.ObjectEncryption_SSEKMS_KMSKeyArn;
            }
            if (requestObjectEncryption_objectEncryption_SSEKMS_objectEncryption_SSEKMS_KMSKeyArn != null)
            {
                requestObjectEncryption_objectEncryption_SSEKMS.KMSKeyArn = requestObjectEncryption_objectEncryption_SSEKMS_objectEncryption_SSEKMS_KMSKeyArn;
                requestObjectEncryption_objectEncryption_SSEKMSIsNull = false;
            }
             // determine if requestObjectEncryption_objectEncryption_SSEKMS should be set to null
            if (requestObjectEncryption_objectEncryption_SSEKMSIsNull)
            {
                requestObjectEncryption_objectEncryption_SSEKMS = null;
            }
            if (requestObjectEncryption_objectEncryption_SSEKMS != null)
            {
                request.ObjectEncryption.SSEKMS = requestObjectEncryption_objectEncryption_SSEKMS;
                requestObjectEncryptionIsNull = false;
            }
             // determine if request.ObjectEncryption should be set to null
            if (requestObjectEncryptionIsNull)
            {
                request.ObjectEncryption = null;
            }
            if (cmdletContext.RequestPayer != null)
            {
                request.RequestPayer = cmdletContext.RequestPayer;
            }
            if (cmdletContext.VersionId != null)
            {
                request.VersionId = cmdletContext.VersionId;
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
        
        private Amazon.S3.Model.UpdateObjectEncryptionResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.UpdateObjectEncryptionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "UpdateObjectEncryption");
            try
            {
                return client.UpdateObjectEncryptionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ExpectedBucketOwner { get; set; }
            public System.String Key { get; set; }
            public System.Boolean? ObjectEncryption_SSEKMS_BucketKeyEnabled { get; set; }
            public System.String ObjectEncryption_SSEKMS_KMSKeyArn { get; set; }
            public Amazon.S3.RequestPayer RequestPayer { get; set; }
            public System.String VersionId { get; set; }
            public System.Func<Amazon.S3.Model.UpdateObjectEncryptionResponse, UpdateS3ObjectEncryptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RequestCharged;
        }
        
    }
}
