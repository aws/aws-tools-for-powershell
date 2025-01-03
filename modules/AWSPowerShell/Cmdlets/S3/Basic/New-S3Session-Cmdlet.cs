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
using Amazon.S3;
using Amazon.S3.Model;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Creates a session that establishes temporary security credentials to support fast
    /// authentication and authorization for the Zonal endpoint API operations on directory
    /// buckets. For more information about Zonal endpoint API operations that include the
    /// Availability Zone in the request endpoint, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-express-APIs.html">S3
    /// Express One Zone APIs</a> in the <i>Amazon S3 User Guide</i>. 
    /// 
    ///  
    /// <para>
    /// To make Zonal endpoint API requests on a directory bucket, use the <c>CreateSession</c>
    /// API operation. Specifically, you grant <c>s3express:CreateSession</c> permission to
    /// a bucket in a bucket policy or an IAM identity-based policy. Then, you use IAM credentials
    /// to make the <c>CreateSession</c> API request on the bucket, which returns temporary
    /// security credentials that include the access key ID, secret access key, session token,
    /// and expiration. These credentials have associated permissions to access the Zonal
    /// endpoint API operations. After the session is created, you don’t need to use other
    /// policies to grant permissions to each Zonal endpoint API individually. Instead, in
    /// your Zonal endpoint API requests, you sign your requests by applying the temporary
    /// security credentials of the session to the request headers and following the SigV4
    /// protocol for authentication. You also apply the session token to the <c>x-amz-s3session-token</c>
    /// request header for authorization. Temporary security credentials are scoped to the
    /// bucket and expire after 5 minutes. After the expiration time, any calls that you make
    /// with those credentials will fail. You must use IAM credentials again to make a <c>CreateSession</c>
    /// API request that generates a new set of temporary credentials for use. Temporary credentials
    /// cannot be extended or refreshed beyond the original specified interval.
    /// </para><para>
    /// If you use Amazon Web Services SDKs, SDKs handle the session token refreshes automatically
    /// to avoid service interruptions when a session expires. We recommend that you use the
    /// Amazon Web Services SDKs to initiate and manage requests to the CreateSession API.
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-express-optimizing-performance-guidelines-design-patterns.html#s3-express-optimizing-performance-session-authentication">Performance
    /// guidelines and design patterns</a> in the <i>Amazon S3 User Guide</i>.
    /// </para><note><ul><li><para>
    /// You must make requests for this API operation to the Zonal endpoint. These endpoints
    /// support virtual-hosted-style requests in the format <c>https://<i>bucket-name</i>.s3express-<i>zone-id</i>.<i>region-code</i>.amazonaws.com</c>.
    /// Path-style requests are not supported. For more information about endpoints in Availability
    /// Zones, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/endpoint-directory-buckets-AZ.html">Regional
    /// and Zonal endpoints for directory buckets in Availability Zones</a> in the <i>Amazon
    /// S3 User Guide</i>. For more information about endpoints in Local Zones, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-lzs-for-directory-buckets.html">Concepts
    /// for directory buckets in Local Zones</a> in the <i>Amazon S3 User Guide</i>.
    /// </para></li><li><para><b><c>CopyObject</c> API operation</b> - Unlike other Zonal endpoint API operations,
    /// the <c>CopyObject</c> API operation doesn't use the temporary security credentials
    /// returned from the <c>CreateSession</c> API operation for authentication and authorization.
    /// For information about authentication and authorization of the <c>CopyObject</c> API
    /// operation on directory buckets, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_CopyObject.html">CopyObject</a>.
    /// </para></li><li><para><b><c>HeadBucket</c> API operation</b> - Unlike other Zonal endpoint API operations,
    /// the <c>HeadBucket</c> API operation doesn't use the temporary security credentials
    /// returned from the <c>CreateSession</c> API operation for authentication and authorization.
    /// For information about authentication and authorization of the <c>HeadBucket</c> API
    /// operation on directory buckets, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_HeadBucket.html">HeadBucket</a>.
    /// </para></li></ul></note><dl><dt>Permissions</dt><dd><para>
    /// To obtain temporary security credentials, you must create a bucket policy or an IAM
    /// identity-based policy that grants <c>s3express:CreateSession</c> permission to the
    /// bucket. In a policy, you can have the <c>s3express:SessionMode</c> condition key to
    /// control who can create a <c>ReadWrite</c> or <c>ReadOnly</c> session. For more information
    /// about <c>ReadWrite</c> or <c>ReadOnly</c> sessions, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_CreateSession.html#API_CreateSession_RequestParameters"><c>x-amz-create-session-mode</c></a>. For example policies, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-express-security-iam-example-bucket-policies.html">Example
    /// bucket policies for S3 Express One Zone</a> and <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-express-security-iam-identity-policies.html">Amazon
    /// Web Services Identity and Access Management (IAM) identity-based policies for S3 Express
    /// One Zone</a> in the <i>Amazon S3 User Guide</i>. 
    /// </para><para>
    /// To grant cross-account access to Zonal endpoint API operations, the bucket policy
    /// should also grant both accounts the <c>s3express:CreateSession</c> permission.
    /// </para><para>
    /// If you want to encrypt objects with SSE-KMS, you must also have the <c>kms:GenerateDataKey</c>
    /// and the <c>kms:Decrypt</c> permissions in IAM identity-based policies and KMS key
    /// policies for the target KMS key.
    /// </para></dd><dt>Encryption</dt><dd><para>
    /// For directory buckets, there are only two supported options for server-side encryption:
    /// server-side encryption with Amazon S3 managed keys (SSE-S3) (<c>AES256</c>) and server-side
    /// encryption with KMS keys (SSE-KMS) (<c>aws:kms</c>). We recommend that the bucket's
    /// default encryption uses the desired encryption configuration and you don't override
    /// the bucket default encryption in your <c>CreateSession</c> requests or <c>PUT</c>
    /// object requests. Then, new objects are automatically encrypted with the desired encryption
    /// settings. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-express-serv-side-encryption.html">Protecting
    /// data with server-side encryption</a> in the <i>Amazon S3 User Guide</i>. For more
    /// information about the encryption overriding behaviors in directory buckets, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-express-specifying-kms-encryption.html">Specifying
    /// server-side encryption with KMS for new object uploads</a>.
    /// </para><para>
    /// For <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-express-differences.html#s3-express-differences-api-operations">Zonal
    /// endpoint (object-level) API operations</a> except <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_CopyObject.html">CopyObject</a>
    /// and <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_UploadPartCopy.html">UploadPartCopy</a>,
    /// you authenticate and authorize requests through <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_CreateSession.html">CreateSession</a>
    /// for low latency. To encrypt new objects in a directory bucket with SSE-KMS, you must
    /// specify SSE-KMS as the directory bucket's default encryption configuration with a
    /// KMS key (specifically, a <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#customer-cmk">customer
    /// managed key</a>). Then, when a session is created for Zonal endpoint API operations,
    /// new objects are automatically encrypted and decrypted with SSE-KMS and S3 Bucket Keys
    /// during the session.
    /// </para><note><para>
    ///  Only 1 <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#customer-cmk">customer
    /// managed key</a> is supported per directory bucket for the lifetime of the bucket.
    /// The <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#aws-managed-cmk">Amazon
    /// Web Services managed key</a> (<c>aws/s3</c>) isn't supported. After you specify SSE-KMS
    /// as your bucket's default encryption configuration with a customer managed key, you
    /// can't change the customer managed key for the bucket's SSE-KMS configuration. 
    /// </para></note><para>
    /// In the Zonal endpoint API calls (except <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_CopyObject.html">CopyObject</a>
    /// and <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_UploadPartCopy.html">UploadPartCopy</a>)
    /// using the REST API, you can't override the values of the encryption settings (<c>x-amz-server-side-encryption</c>,
    /// <c>x-amz-server-side-encryption-aws-kms-key-id</c>, <c>x-amz-server-side-encryption-context</c>,
    /// and <c>x-amz-server-side-encryption-bucket-key-enabled</c>) from the <c>CreateSession</c>
    /// request. You don't need to explicitly specify these encryption settings values in
    /// Zonal endpoint API calls, and Amazon S3 will use the encryption settings values from
    /// the <c>CreateSession</c> request to protect new objects in the directory bucket. 
    /// </para><note><para>
    /// When you use the CLI or the Amazon Web Services SDKs, for <c>CreateSession</c>, the
    /// session token refreshes automatically to avoid service interruptions when a session
    /// expires. The CLI or the Amazon Web Services SDKs use the bucket's default encryption
    /// configuration for the <c>CreateSession</c> request. It's not supported to override
    /// the encryption settings values in the <c>CreateSession</c> request. Also, in the Zonal
    /// endpoint API calls (except <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_CopyObject.html">CopyObject</a>
    /// and <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_UploadPartCopy.html">UploadPartCopy</a>),
    /// it's not supported to override the values of the encryption settings from the <c>CreateSession</c>
    /// request. 
    /// </para></note></dd><dt>HTTP Host header syntax</dt><dd><para><b>Directory buckets </b> - The HTTP Host header syntax is <c><i>Bucket-name</i>.s3express-<i>zone-id</i>.<i>region-code</i>.amazonaws.com</c>.
    /// </para></dd></dl>
    /// </summary>
    [Cmdlet("New", "S3Session", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.S3.Model.SessionCredentials")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) CreateSession API operation.", Operation = new[] {"CreateSession"}, SelectReturnType = typeof(Amazon.S3.Model.CreateSessionResponse))]
    [AWSCmdletOutput("Amazon.S3.Model.SessionCredentials or Amazon.S3.Model.CreateSessionResponse",
        "This cmdlet returns an Amazon.S3.Model.SessionCredentials object.",
        "The service call response (type Amazon.S3.Model.CreateSessionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewS3SessionCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BucketKeyEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether Amazon S3 should use an S3 Bucket Key for object encryption with server-side encryption using KMS keys (SSE-KMS).</para><para>S3 Bucket Keys are always enabled for <c>GET</c> and <c>PUT</c> operations in a directory bucket and can't be disabled.
        /// S3 Bucket Keys aren't supported, when you copy SSE-KMS encrypted objects from general purpose buckets to directory buckets, from directory buckets to general purpose buckets, or between directory buckets, 
        /// through <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_CopyObject.html">CopyObject</a>, <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_UploadPartCopy.html">UploadPartCopy</a>, 
        /// <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/directory-buckets-objects-Batch-Ops">the Copy operation in Batch Operations</a>, or <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/create-import-job">the import jobs</a>. 
        /// In this case, Amazon S3 makes a call to KMS every time a copy request is made for a KMS-encrypted object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? BucketKeyEnabled { get; set; }
        #endregion
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// The name of the bucket that you create a session for.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter ServerSideEncryption
        /// <summary>
        /// <para>
        /// <para>The server-side encryption algorithm to use when you store objects in the directory bucket.</para><para>For directory buckets, there are only two supported options for server-side encryption: server-side encryption with Amazon S3 managed keys (SSE-S3) (<c>AES256</c>) and server-side encryption with KMS keys (SSE-KMS) (<c>aws:kms</c>). 
        /// By default, Amazon S3 encrypts data with SSE-S3. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-express-serv-side-encryption.html">Protecting data with server-side encryption</a> in the <i>Amazon S3 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ServerSideEncryptionMethod")]
        public Amazon.S3.ServerSideEncryptionMethod ServerSideEncryption { get; set; }
        #endregion
        
        #region Parameter SessionMode
        /// <summary>
        /// <para>
        /// Specifies the mode of the session that will be created, either <c>ReadWrite</c> or <c>ReadOnly</c>. By default, a <c>ReadWrite</c> session is created. 
        /// 
        /// A <c>ReadWrite</c> session is capable of executing all the Zonal endpoint API operations on a directory bucket. 
        /// A <c>ReadOnly</c> session is constrained to execute the following Zonal endpoint API operations: <c>GetObject</c>, <c>HeadObject</c>, <c>ListObjectsV2</c>, <c>GetObjectAttributes</c>, <c>ListParts</c>, and <c>ListMultipartUploads</c>.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.SessionMode")]
        public Amazon.S3.SessionMode SessionMode { get; set; }
        #endregion
        
        #region Parameter SSEKMSEncryptionContext
        /// <summary>
        /// <para>
        /// <para>Specifies the Amazon Web Services KMS Encryption Context as an additional encryption context to use for object encryption. 
        /// The value of this header is a Base64-encoded string of a UTF-8 encoded JSON, which contains the encryption context as key-value pairs. 
        /// This value is stored as object metadata and automatically gets passed on to Amazon Web Services KMS for future <c>GetObject</c> operations on this object.</para><para><b>General purpose buckets</b> - This value must be explicitly added during <c>CopyObject</c> operations if you want an additional encryption context for your object. 
        /// For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/UsingKMSEncryption.html#encryption-context">Encryption context</a> in the <i>Amazon S3 User Guide</i>.</para><para><b>Directory buckets</b> - You can optionally provide an explicit encryption context value. The value must match the default encryption context - the bucket Amazon Resource Name (ARN). 
        /// An additional encryption context value is not supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SSEKMSEncryptionContext { get; set; }
        #endregion
        
        #region Parameter SSEKMSKeyId
        /// <summary>
        /// <para>
        /// <para>If you specify <c>x-amz-server-side-encryption</c> with <c>aws:kms</c>, you must specify the <c>x-amz-server-side-encryption-aws-kms-key-id</c> header with the ID (Key ID or Key ARN) of the KMS symmetric encryption customer managed key to use. 
        /// Otherwise, you get an HTTP <c>400 Bad Request</c> error. Only use the key ID or key ARN. The key alias format of the KMS key isn't supported. 
        /// Also, if the KMS key doesn't exist in the same account that't issuing the command, you must use the full Key ARN not the Key ID. </para><para>Your SSE-KMS configuration can only support 1 <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#customer-cmk">customer managed key</a> per directory bucket for the lifetime of the bucket. <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#aws-managed-cmk">Amazon Web Services managed key</a> (<c>aws/s3</c>) isn't supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SSEKMSKeyId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Credentials'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.CreateSessionResponse).
        /// Specifying the name of a property of type Amazon.S3.Model.CreateSessionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Credentials";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BucketName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BucketName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BucketName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            this._AWSSignerType = "s3";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BucketName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-S3Session (CreateSession)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.CreateSessionResponse, NewS3SessionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BucketName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BucketName = this.BucketName;
            context.SessionMode = this.SessionMode;
            context.ServerSideEncryption = this.ServerSideEncryption;
            context.SSEKMSKeyId = this.SSEKMSKeyId;
            context.SSEKMSEncryptionContext = this.SSEKMSEncryptionContext;
            context.BucketKeyEnabled = this.BucketKeyEnabled;
            
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
            var request = new Amazon.S3.Model.CreateSessionRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.SessionMode != null)
            {
                request.SessionMode = cmdletContext.SessionMode;
            }
            if (cmdletContext.ServerSideEncryption != null)
            {
                request.ServerSideEncryption = cmdletContext.ServerSideEncryption;
            }
            if (cmdletContext.SSEKMSKeyId != null)
            {
                request.SSEKMSKeyId = cmdletContext.SSEKMSKeyId;
            }
            if (cmdletContext.SSEKMSEncryptionContext != null)
            {
                request.SSEKMSEncryptionContext = cmdletContext.SSEKMSEncryptionContext;
            }
            if (cmdletContext.BucketKeyEnabled != null)
            {
                request.BucketKeyEnabled = cmdletContext.BucketKeyEnabled.Value;
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
        
        private Amazon.S3.Model.CreateSessionResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.CreateSessionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "CreateSession");
            try
            {
                #if DESKTOP
                return client.CreateSession(request);
                #elif CORECLR
                return client.CreateSessionAsync(request).GetAwaiter().GetResult();
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
            public System.String BucketName { get; set; }
            public Amazon.S3.SessionMode SessionMode { get; set; }
            public Amazon.S3.ServerSideEncryptionMethod ServerSideEncryption { get; set; }
            public System.String SSEKMSKeyId { get; set; }
            public System.String SSEKMSEncryptionContext { get; set; }
            public System.Boolean? BucketKeyEnabled { get; set; }
            public System.Func<Amazon.S3.Model.CreateSessionResponse, NewS3SessionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Credentials;
        }
        
    }
}
