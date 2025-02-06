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
using Amazon.S3;
using Amazon.S3.Model;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// The <c>HEAD</c> operation retrieves metadata from an object without returning the
    /// object itself. This operation is useful if you're interested only in an object's metadata.
    /// 
    ///  <note><para>
    /// A <c>HEAD</c> request has the same options as a <c>GET</c> operation on an object.
    /// The response is identical to the <c>GET</c> response except that there is no response
    /// body. Because of this, if the <c>HEAD</c> request generates an error, it returns a
    /// generic code, such as <c>400 Bad Request</c>, <c>403 Forbidden</c>, <c>404 Not Found</c>,
    /// <c>405 Method Not Allowed</c>, <c>412 Precondition Failed</c>, or <c>304 Not Modified</c>.
    /// It's not possible to retrieve the exact exception of these error codes.
    /// </para></note><para>
    /// Request headers are limited to 8 KB in size. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/RESTCommonRequestHeaders.html">Common
    /// Request Headers</a>.
    /// </para><dl><dt>Permissions</dt><dd><ul><li><para><b>General purpose bucket permissions</b> - To use <c>HEAD</c>, you must have the
    /// <c>s3:GetObject</c> permission. You need the relevant read object (or version) permission
    /// for this operation. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/list_amazons3.html">Actions,
    /// resources, and condition keys for Amazon S3</a> in the <i>Amazon S3 User Guide</i>.
    /// For more information about the permissions to S3 API operations by S3 resource types,
    /// see <a href="/AmazonS3/latest/userguide/using-with-s3-policy-actions.html">Required
    /// permissions for Amazon S3 API operations</a> in the <i>Amazon S3 User Guide</i>.
    /// </para><para>
    /// If the object you request doesn't exist, the error that Amazon S3 returns depends
    /// on whether you also have the <c>s3:ListBucket</c> permission.
    /// </para><ul><li><para>
    /// If you have the <c>s3:ListBucket</c> permission on the bucket, Amazon S3 returns an
    /// HTTP status code <c>404 Not Found</c> error.
    /// </para></li><li><para>
    /// If you don’t have the <c>s3:ListBucket</c> permission, Amazon S3 returns an HTTP status
    /// code <c>403 Forbidden</c> error.
    /// </para></li></ul></li><li><para><b>Directory bucket permissions</b> - To grant access to this API operation on a
    /// directory bucket, we recommend that you use the <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_CreateSession.html"><c>CreateSession</c></a> API operation for session-based authorization. Specifically,
    /// you grant the <c>s3express:CreateSession</c> permission to the directory bucket in
    /// a bucket policy or an IAM identity-based policy. Then, you make the <c>CreateSession</c>
    /// API call on the bucket to obtain a session token. With the session token in your request
    /// header, you can make API requests to this operation. After the session token expires,
    /// you make another <c>CreateSession</c> API call to generate a new session token for
    /// use. Amazon Web Services CLI or SDKs create session and refresh the session token
    /// automatically to avoid service interruptions when a session expires. For more information
    /// about authorization, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_CreateSession.html"><c>CreateSession</c></a>.
    /// </para><para>
    /// If you enable <c>x-amz-checksum-mode</c> in the request and the object is encrypted
    /// with Amazon Web Services Key Management Service (Amazon Web Services KMS), you must
    /// also have the <c>kms:GenerateDataKey</c> and <c>kms:Decrypt</c> permissions in IAM
    /// identity-based policies and KMS key policies for the KMS key to retrieve the checksum
    /// of the object.
    /// </para></li></ul></dd><dt>Encryption</dt><dd><note><para>
    /// Encryption request headers, like <c>x-amz-server-side-encryption</c>, should not be
    /// sent for <c>HEAD</c> requests if your object uses server-side encryption with Key
    /// Management Service (KMS) keys (SSE-KMS), dual-layer server-side encryption with Amazon
    /// Web Services KMS keys (DSSE-KMS), or server-side encryption with Amazon S3 managed
    /// encryption keys (SSE-S3). The <c>x-amz-server-side-encryption</c> header is used when
    /// you <c>PUT</c> an object to S3 and want to specify the encryption method. If you include
    /// this header in a <c>HEAD</c> request for an object that uses these types of keys,
    /// you’ll get an HTTP <c>400 Bad Request</c> error. It's because the encryption method
    /// can't be changed when you retrieve the object.
    /// </para></note><para>
    /// If you encrypt an object by using server-side encryption with customer-provided encryption
    /// keys (SSE-C) when you store the object in Amazon S3, then when you retrieve the metadata
    /// from the object, you must use the following headers to provide the encryption key
    /// for the server to be able to retrieve the object's metadata. The headers are: 
    /// </para><ul><li><para><c>x-amz-server-side-encryption-customer-algorithm</c></para></li><li><para><c>x-amz-server-side-encryption-customer-key</c></para></li><li><para><c>x-amz-server-side-encryption-customer-key-MD5</c></para></li></ul><para>
    /// For more information about SSE-C, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/ServerSideEncryptionCustomerKeys.html">Server-Side
    /// Encryption (Using Customer-Provided Encryption Keys)</a> in the <i>Amazon S3 User
    /// Guide</i>.
    /// </para><note><para><b>Directory bucket </b> - For directory buckets, there are only two supported options
    /// for server-side encryption: SSE-S3 and SSE-KMS. SSE-C isn't supported. For more information,
    /// see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-express-serv-side-encryption.html">Protecting
    /// data with server-side encryption</a> in the <i>Amazon S3 User Guide</i>. 
    /// </para></note></dd><dt>Versioning</dt><dd><ul><li><para>
    /// If the current version of the object is a delete marker, Amazon S3 behaves as if the
    /// object was deleted and includes <c>x-amz-delete-marker: true</c> in the response.
    /// </para></li><li><para>
    /// If the specified version is a delete marker, the response returns a <c>405 Method
    /// Not Allowed</c> error and the <c>Last-Modified: timestamp</c> response header.
    /// </para></li></ul><note><ul><li><para><b>Directory buckets</b> - Delete marker is not supported for directory buckets.
    /// </para></li><li><para><b>Directory buckets</b> - S3 Versioning isn't enabled and supported for directory
    /// buckets. For this API operation, only the <c>null</c> value of the version ID is supported
    /// by directory buckets. You can only specify <c>null</c> to the <c>versionId</c> query
    /// parameter in the request.
    /// </para></li></ul></note></dd><dt>HTTP Host header syntax</dt><dd><para><b>Directory buckets </b> - The HTTP Host header syntax is <c><i>Bucket-name</i>.s3express-<i>zone-id</i>.<i>region-code</i>.amazonaws.com</c>.
    /// </para><note><para>
    /// For directory buckets, you must make requests for this API operation to the Zonal
    /// endpoint. These endpoints support virtual-hosted-style requests in the format <c>https://<i>bucket-name</i>.s3express-<i>zone-id</i>.<i>region-code</i>.amazonaws.com/<i>key-name</i></c>. Path-style requests are not supported. For more information about endpoints
    /// in Availability Zones, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-express-Regions-and-Zones.html">Regional
    /// and Zonal endpoints for directory buckets in Availability Zones</a> in the <i>Amazon
    /// S3 User Guide</i>. For more information about endpoints in Local Zones, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-lzs-for-directory-buckets.html">Available
    /// Local Zone for directory buckets</a> in the <i>Amazon S3 User Guide</i>.
    /// </para></note></dd></dl><para>
    /// The following actions are related to <c>HeadObject</c>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetObject.html">GetObject</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetObjectAttributes.html">GetObjectAttributes</a></para></li></ul>
    /// </summary>
    [Cmdlet("Get", "S3ObjectMetadata")]
    [OutputType("Amazon.S3.Model.GetObjectMetadataResponse")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) GetObjectMetadata API operation.", Operation = new[] {"GetObjectMetadata"}, SelectReturnType = typeof(Amazon.S3.Model.GetObjectMetadataResponse))]
    [AWSCmdletOutput("Amazon.S3.Model.GetObjectMetadataResponse",
        "This cmdlet returns an Amazon.S3.Model.GetObjectMetadataResponse object containing multiple properties."
    )]
    public partial class GetS3ObjectMetadataCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the bucket that contains the object.</para><para><b>Directory buckets</b> - When you use this operation with a directory bucket, you
        /// must use virtual-hosted-style requests in the format <c><i>Bucket_name</i>.s3express-<i>az_id</i>.<i>region</i>.amazonaws.com</c>.
        /// Path-style requests are not supported. Directory bucket names must be unique in the
        /// chosen Availability Zone. Bucket names must follow the format <c><i>bucket_base_name</i>--<i>az-id</i>--x-s3</c>
        /// (for example, <c><i>DOC-EXAMPLE-BUCKET</i>--<i>usw2-az1</i>--x-s3</c>). For information
        /// about bucket naming restrictions, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/directory-bucket-naming-rules.html">Directory
        /// bucket naming rules</a> in the <i>Amazon S3 User Guide</i>.</para><para><b>Access points</b> - When you use this action with an access point, you must provide
        /// the alias of the access point in place of the bucket name or specify the access point
        /// ARN. When using the access point ARN, you must direct requests to the access point
        /// hostname. The access point hostname takes the form <i>AccessPointName</i>-<i>AccountId</i>.s3-accesspoint.<i>Region</i>.amazonaws.com.
        /// When using this action with an access point through the Amazon Web Services SDKs,
        /// you provide the access point ARN in place of the bucket name. For more information
        /// about access point ARNs, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/using-access-points.html">Using
        /// access points</a> in the <i>Amazon S3 User Guide</i>.</para><note><para>Access points and Object Lambda access points are not supported by directory buckets.</para></note><para><b>S3 on Outposts</b> - When you use this action with Amazon S3 on Outposts, you
        /// must direct requests to the S3 on Outposts hostname. The S3 on Outposts hostname takes
        /// the form <c><i>AccessPointName</i>-<i>AccountId</i>.<i>outpostID</i>.s3-outposts.<i>Region</i>.amazonaws.com</c>.
        /// When you use this action with S3 on Outposts through the Amazon Web Services SDKs,
        /// you provide the Outposts access point ARN in place of the bucket name. For more information
        /// about S3 on Outposts ARNs, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/S3onOutposts.html">What
        /// is S3 on Outposts?</a> in the <i>Amazon S3 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter ChecksumMode
        /// <summary>
        /// <para>
        /// <para>This must be enabled to retrieve the checksum.</para><para><b>General purpose buckets</b> - If you enable checksum mode and the object is uploaded with a <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_Checksum.html">checksum</a> 
        /// and encrypted with an Key Management Service (KMS) key, you must have permission to use the <c>kms:Decrypt</c> action to retrieve the checksum.</para><para><b>Directory buckets</b> - If you enable <c>ChecksumMode</c> and the object is encrypted with Amazon Web Services Key Management Service (Amazon Web Services KMS), 
        /// you must also have the <c>kms:GenerateDataKey</c> and <c>kms:Decrypt</c> permissions in IAM identity-based policies and KMS key policies for the KMS key to retrieve the 
        /// checksum of the object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ChecksumMode")]
        public Amazon.S3.ChecksumMode ChecksumMode { get; set; }
        #endregion
        
        #region Parameter EtagToMatch
        /// <summary>
        /// <para>
        /// ETag to be matched as a pre-condition for returning the object,
        /// otherwise a PreconditionFailed signal is returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EtagToMatch { get; set; }
        #endregion
        
        #region Parameter EtagToNotMatch
        /// <summary>
        /// <para>
        /// ETag that should not be matched as a pre-condition for returning the object,
        /// otherwise a NotModified (304) signal is returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EtagToNotMatch { get; set; }
        #endregion
        
        #region Parameter ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// <para>The account ID of the expected bucket owner. If the account ID that you provide does
        /// not match the actual owner of the bucket, the request fails with the HTTP status code
        /// <c>403 Forbidden</c> (access denied).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter Key
        /// <summary>
        /// <para>
        /// The key of the object.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String Key { get; set; }
        #endregion
        
        #region Parameter UtcModifiedSinceDate
        /// <summary>
        /// <para>
        /// Returns the object only if it has been modified since the specified time, 
        /// otherwise returns a PreconditionFailed.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? UtcModifiedSinceDate { get; set; }
        #endregion
        
        #region Parameter PartNumber
        /// <summary>
        /// <para>
        /// Part number of the object being read. This is a positive integer between 1 and 10,000.
        /// Effectively performs a 'ranged' HEAD request for the part specified.
        /// Useful querying about the size of the part and the number of parts in this object.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PartNumber { get; set; }
        #endregion
        
        #region Parameter RequestPayer
        /// <summary>
        /// <para>
        /// Confirms that the requester knows that she or he will be charged for the request.
        /// Bucket owners need not specify this parameter in their requests.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.RequestPayer")]
        public Amazon.S3.RequestPayer RequestPayer { get; set; }
        #endregion
        
        #region Parameter ResponseCacheControl
        /// <summary>
        /// <para>
        /// <para>Sets the <c>Cache-Control</c> header of the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResponseCacheControl { get; set; }
        #endregion
        
        #region Parameter ResponseContentDisposition
        /// <summary>
        /// <para>
        /// <para>Sets the <c>Content-Disposition</c> header of the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResponseContentDisposition { get; set; }
        #endregion
        
        #region Parameter ResponseContentEncoding
        /// <summary>
        /// <para>
        /// <para>Sets the <c>Content-Encoding</c> header of the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResponseContentEncoding { get; set; }
        #endregion
        
        #region Parameter ResponseContentLanguage
        /// <summary>
        /// <para>
        /// <para>Sets the <c>Content-Language</c> header of the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResponseContentLanguage { get; set; }
        #endregion
        
        #region Parameter ResponseContentType
        /// <summary>
        /// <para>
        /// <para>Sets the <c>Content-Type</c> header of the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResponseContentType { get; set; }
        #endregion
        
        #region Parameter ResponseExpire
        /// <summary>
        /// <para>
        /// <para>Sets the <c>Expires</c> header of the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResponseExpires")]
        public System.DateTime? ResponseExpire { get; set; }
        #endregion
        
        #region Parameter ServerSideEncryptionCustomerMethod
        /// <summary>
        /// <para>
        /// The Server-side encryption algorithm to be used with the customer provided key.
        ///  
        ///  <note><para>This functionality is not supported for directory buckets.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ServerSideEncryptionCustomerMethod")]
        public Amazon.S3.ServerSideEncryptionCustomerMethod ServerSideEncryptionCustomerMethod { get; set; }
        #endregion
        
        #region Parameter ServerSideEncryptionCustomerProvidedKey
        /// <summary>
        /// <para>
        /// The base64-encoded encryption key for Amazon S3 to use to decrypt the object
        /// <para>Using the encryption key you provide as part of your request Amazon S3 manages both the encryption, as it writes 
        /// to disks, and decryption, when you access your objects. Therefore, you don't need to maintain any data encryption code. The only 
        /// thing you do is manage the encryption keys you provide.</para><para>When you retrieve an object, you must provide the same encryption key as part of your request. Amazon S3 first verifies 
        /// the encryption key you provided matches, and then decrypts the object before returning the object data to you.</para><para>Important: Amazon S3 does not store the encryption key you provide.</para><note><para>This functionality is not supported for directory buckets.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServerSideEncryptionCustomerProvidedKey { get; set; }
        #endregion
        
        #region Parameter ServerSideEncryptionCustomerProvidedKeyMD5
        /// <summary>
        /// <para>
        /// The MD5 of the customer encryption key specified in the ServerSideEncryptionCustomerProvidedKey property. The MD5 is
        /// base 64 encoded. This field is optional, the SDK will calculate the MD5 if this is not set.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServerSideEncryptionCustomerProvidedKeyMD5 { get; set; }
        #endregion
        
        #region Parameter UtcUnmodifiedSinceDate
        /// <summary>
        /// <para>
        /// Returns the object only if it has not been modified since the specified time, 
        /// otherwise returns a PreconditionFailed.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? UtcUnmodifiedSinceDate { get; set; }
        #endregion
        
        #region Parameter VersionId
        /// <summary>
        /// <para>
        /// <para>Version ID used to reference a specific version of the object.</para><note><para>For directory buckets in this API operation, only the <c>null</c> value of the
        /// version ID is supported.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VersionId { get; set; }
        #endregion
        
        #region Parameter ModifiedSinceDate
        /// <summary>
        /// <para>
        /// <para>This property is deprecated. Setting this property results in non-UTC DateTimes not
        /// being marshalled correctly. Use ModifiedSinceDateUtc instead. Setting either ModifiedSinceDate or
        /// ModifiedSinceDateUtc results in both ModifiedSinceDate and ModifiedSinceDateUtc being assigned,
        /// the latest assignment to either one of the two property is reflected in the value of both.
        /// ModifiedSinceDate is provided for backwards compatibility only and assigning a non-Utc DateTime
        /// to it results in the wrong timestamp being passed to the service.</para>
        /// Returns the object only if it has been modified since the specified time, 
        /// otherwise returns a PreconditionFailed.
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This parameter is deprecated and may result in the wrong timestamp being passed to the service, use UtcModifiedSinceDate instead.")]
        public System.DateTime? ModifiedSinceDate { get; set; }
        #endregion
        
        #region Parameter UnmodifiedSinceDate
        /// <summary>
        /// <para>
        /// <para>This property is deprecated. Setting this property results in non-UTC DateTimes not
        /// being marshalled correctly. Use UnmodifiedSinceDateUtc instead. Setting either UnmodifiedSinceDate or
        /// UnmodifiedSinceDateUtc results in both UnmodifiedSinceDate and UnmodifiedSinceDateUtc being assigned,
        /// the latest assignment to either one of the two property is reflected in the value of both.
        /// UnmodifiedSinceDate is provided for backwards compatibility only and assigning a non-Utc DateTime
        /// to it results in the wrong timestamp being passed to the service.</para>
        /// Returns the object only if it has not been modified since the specified time, 
        /// otherwise returns a PreconditionFailed.
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This parameter is deprecated and may result in the wrong timestamp being passed to the service, use UtcUnmodifiedSinceDate instead.")]
        public System.DateTime? UnmodifiedSinceDate { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.GetObjectMetadataResponse).
        /// Specifying the name of a property of type Amazon.S3.Model.GetObjectMetadataResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "s3";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.GetObjectMetadataResponse, GetS3ObjectMetadataCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BucketName = this.BucketName;
            context.ChecksumMode = this.ChecksumMode;
            context.EtagToMatch = this.EtagToMatch;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ModifiedSinceDate = this.ModifiedSinceDate;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.UtcModifiedSinceDate = this.UtcModifiedSinceDate;
            context.EtagToNotMatch = this.EtagToNotMatch;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.UnmodifiedSinceDate = this.UnmodifiedSinceDate;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.UtcUnmodifiedSinceDate = this.UtcUnmodifiedSinceDate;
            context.Key = this.Key;
            context.VersionId = this.VersionId;
            context.ServerSideEncryptionCustomerMethod = this.ServerSideEncryptionCustomerMethod;
            context.ServerSideEncryptionCustomerProvidedKey = this.ServerSideEncryptionCustomerProvidedKey;
            context.ServerSideEncryptionCustomerProvidedKeyMD5 = this.ServerSideEncryptionCustomerProvidedKeyMD5;
            context.PartNumber = this.PartNumber;
            context.RequestPayer = this.RequestPayer;
            context.ExpectedBucketOwner = this.ExpectedBucketOwner;
            context.ResponseCacheControl = this.ResponseCacheControl;
            context.ResponseContentDisposition = this.ResponseContentDisposition;
            context.ResponseContentEncoding = this.ResponseContentEncoding;
            context.ResponseContentLanguage = this.ResponseContentLanguage;
            context.ResponseContentType = this.ResponseContentType;
            context.ResponseExpire = this.ResponseExpire;
            
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
            var request = new Amazon.S3.Model.GetObjectMetadataRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.ChecksumMode != null)
            {
                request.ChecksumMode = cmdletContext.ChecksumMode;
            }
            if (cmdletContext.EtagToMatch != null)
            {
                request.EtagToMatch = cmdletContext.EtagToMatch;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.ModifiedSinceDate != null)
            {
                if (cmdletContext.UtcModifiedSinceDate != null)
                {
                    throw new System.ArgumentException("Parameters ModifiedSinceDate and UtcModifiedSinceDate are mutually exclusive.", nameof(this.ModifiedSinceDate));
                }
                request.ModifiedSinceDate = cmdletContext.ModifiedSinceDate.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.UtcModifiedSinceDate != null)
            {
                request.ModifiedSinceDateUtc = cmdletContext.UtcModifiedSinceDate.Value;
            }
            if (cmdletContext.EtagToNotMatch != null)
            {
                request.EtagToNotMatch = cmdletContext.EtagToNotMatch;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.UnmodifiedSinceDate != null)
            {
                if (cmdletContext.UtcUnmodifiedSinceDate != null)
                {
                    throw new System.ArgumentException("Parameters UnmodifiedSinceDate and UtcUnmodifiedSinceDate are mutually exclusive.", nameof(this.UnmodifiedSinceDate));
                }
                request.UnmodifiedSinceDate = cmdletContext.UnmodifiedSinceDate.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.UtcUnmodifiedSinceDate != null)
            {
                request.UnmodifiedSinceDateUtc = cmdletContext.UtcUnmodifiedSinceDate.Value;
            }
            if (cmdletContext.Key != null)
            {
                request.Key = cmdletContext.Key;
            }
            if (cmdletContext.VersionId != null)
            {
                request.VersionId = cmdletContext.VersionId;
            }
            if (cmdletContext.ServerSideEncryptionCustomerMethod != null)
            {
                request.ServerSideEncryptionCustomerMethod = cmdletContext.ServerSideEncryptionCustomerMethod;
            }
            if (cmdletContext.ServerSideEncryptionCustomerProvidedKey != null)
            {
                request.ServerSideEncryptionCustomerProvidedKey = cmdletContext.ServerSideEncryptionCustomerProvidedKey;
            }
            if (cmdletContext.ServerSideEncryptionCustomerProvidedKeyMD5 != null)
            {
                request.ServerSideEncryptionCustomerProvidedKeyMD5 = cmdletContext.ServerSideEncryptionCustomerProvidedKeyMD5;
            }
            if (cmdletContext.PartNumber != null)
            {
                request.PartNumber = cmdletContext.PartNumber.Value;
            }
            if (cmdletContext.RequestPayer != null)
            {
                request.RequestPayer = cmdletContext.RequestPayer;
            }
            if (cmdletContext.ExpectedBucketOwner != null)
            {
                request.ExpectedBucketOwner = cmdletContext.ExpectedBucketOwner;
            }
            if (cmdletContext.ResponseCacheControl != null)
            {
                request.ResponseCacheControl = cmdletContext.ResponseCacheControl;
            }
            if (cmdletContext.ResponseContentDisposition != null)
            {
                request.ResponseContentDisposition = cmdletContext.ResponseContentDisposition;
            }
            if (cmdletContext.ResponseContentEncoding != null)
            {
                request.ResponseContentEncoding = cmdletContext.ResponseContentEncoding;
            }
            if (cmdletContext.ResponseContentLanguage != null)
            {
                request.ResponseContentLanguage = cmdletContext.ResponseContentLanguage;
            }
            if (cmdletContext.ResponseContentType != null)
            {
                request.ResponseContentType = cmdletContext.ResponseContentType;
            }
            if (cmdletContext.ResponseExpire != null)
            {
                request.ResponseExpires = cmdletContext.ResponseExpire.Value;
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
        
        private Amazon.S3.Model.GetObjectMetadataResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.GetObjectMetadataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "GetObjectMetadata");
            try
            {
                #if DESKTOP
                return client.GetObjectMetadata(request);
                #elif CORECLR
                return client.GetObjectMetadataAsync(request).GetAwaiter().GetResult();
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
            public Amazon.S3.ChecksumMode ChecksumMode { get; set; }
            public System.String EtagToMatch { get; set; }
            [System.ObsoleteAttribute]
            public System.DateTime? ModifiedSinceDate { get; set; }
            public System.DateTime? UtcModifiedSinceDate { get; set; }
            public System.String EtagToNotMatch { get; set; }
            [System.ObsoleteAttribute]
            public System.DateTime? UnmodifiedSinceDate { get; set; }
            public System.DateTime? UtcUnmodifiedSinceDate { get; set; }
            public System.String Key { get; set; }
            public System.String VersionId { get; set; }
            public Amazon.S3.ServerSideEncryptionCustomerMethod ServerSideEncryptionCustomerMethod { get; set; }
            public System.String ServerSideEncryptionCustomerProvidedKey { get; set; }
            public System.String ServerSideEncryptionCustomerProvidedKeyMD5 { get; set; }
            public System.Int32? PartNumber { get; set; }
            public Amazon.S3.RequestPayer RequestPayer { get; set; }
            public System.String ExpectedBucketOwner { get; set; }
            public System.String ResponseCacheControl { get; set; }
            public System.String ResponseContentDisposition { get; set; }
            public System.String ResponseContentEncoding { get; set; }
            public System.String ResponseContentLanguage { get; set; }
            public System.String ResponseContentType { get; set; }
            public System.DateTime? ResponseExpire { get; set; }
            public System.Func<Amazon.S3.Model.GetObjectMetadataResponse, GetS3ObjectMetadataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
