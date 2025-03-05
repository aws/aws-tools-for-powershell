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
using System.IO;
using System.Linq;
using System.Management.Automation;
using Amazon.PowerShell.Common;
using Amazon.PowerShell.Utils;
using Amazon.S3;
using Amazon.S3.Transfer;
using Amazon.S3.Model;
using Amazon.Runtime;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// <para>
    /// Uploads a local file, text content or a folder hierarchy of files to Amazon S3, placing them into the specified bucket
    /// using the specified key (single object) or key prefix (multiple objects).
    /// </para>
    /// <para>
    /// If you are uploading large files, Write-S3Object cmdlet will use multipart upload to fulfill the request. 
    /// If a multipart upload is interrupted, Write-S3Object cmdlet will attempt to abort the multipart upload.
    /// Under certain circumstances (network outage, power failure, etc.), Write-S3Object cmdlet will not be able to abort the multipart upload. 
    /// In this case, in order to stop getting charged for the storage of uploaded parts, 
    /// you should manually invoke the Remove-S3MultipartUploads to abort the incomplete multipart uploads.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "S3Object", DefaultParameterSetName = ParamSet_FromLocalFile, ConfirmImpact = ConfirmImpact.Low, SupportsShouldProcess = true)]
    [AWSCmdlet("Uploads one or more files from the local file system to an S3 bucket.", Operation = new[] { "PutObject", "InitiateMultipartUpload", "UploadPart", "CompleteMultipartUpload" })]
    public class WriteS3ObjectCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        const string ParamSet_FromLocalFile = "UploadSingleFile";
        const string ParamSet_FromLocalFileChecksum = "UploadSingleFileChecksum";
        const string ParamSet_FromContent = "UploadFromContent";
        const string ParamSet_FromLocalFolder = "UploadFolder";
        const string ParamSet_FromStream = "UploadFromStream";
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();


        // Part size range in bytes (refer https://docs.aws.amazon.com/AmazonS3/latest/userguide/qfacts.html)
        const long MinPartSize = 5L * 1024 * 1024;
        const long MaxPartSize = 5L * 1024 * 1024 * 1024;

        // try and anticipate all the ways a user might mean 'write everything to root'
        readonly string[] rootIndicators = new string[] { "/", @"\" };

        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// The name of the bucket that will hold the uploaded content.
        /// </para>
        ///  
        /// <para>
        ///  <b>Directory buckets</b> - When you use this operation with a directory bucket, you
        /// must use virtual-hosted-style requests in the format <c> <i>Bucket_name</i>.s3express-<i>az_id</i>.<i>region</i>.amazonaws.com</c>.
        /// Path-style requests are not supported. Directory bucket names must be unique in the
        /// chosen Availability Zone. Bucket names must follow the format <c> <i>bucket_base_name</i>--<i>az-id</i>--x-s3</c>
        /// (for example, <c> <i>DOC-EXAMPLE-BUCKET</i>--<i>usw2-az1</i>--x-s3</c>). For information
        /// about bucket naming restrictions, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/directory-bucket-naming-rules.html">Directory
        /// bucket naming rules</a> in the <i>Amazon S3 User Guide</i>.
        /// </para>
        ///  
        /// <para>
        ///  <b>Access points</b> - When you use this action with an access point, you must provide
        /// the alias of the access point in place of the bucket name or specify the access point
        /// ARN. When using the access point ARN, you must direct requests to the access point
        /// hostname. The access point hostname takes the form <i>AccessPointName</i>-<i>AccountId</i>.s3-accesspoint.<i>Region</i>.amazonaws.com.
        /// When using this action with an access point through the Amazon Web Services SDKs,
        /// you provide the access point ARN in place of the bucket name. For more information
        /// about access point ARNs, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/using-access-points.html">Using
        /// access points</a> in the <i>Amazon S3 User Guide</i>.
        /// </para>
        ///  <note> 
        /// <para>
        /// Access points and Object Lambda access points are not supported by directory buckets.
        /// </para>
        ///  </note> 
        /// <para>
        ///  <b>S3 on Outposts</b> - When you use this action with Amazon S3 on Outposts, you
        /// must direct requests to the S3 on Outposts hostname. The S3 on Outposts hostname takes
        /// the form <c> <i>AccessPointName</i>-<i>AccountId</i>.<i>outpostID</i>.s3-outposts.<i>Region</i>.amazonaws.com</c>.
        /// When you use this action with S3 on Outposts through the Amazon Web Services SDKs,
        /// you provide the Outposts access point ARN in place of the bucket name. For more information
        /// about S3 on Outposts ARNs, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/S3onOutposts.html">What
        /// is S3 on Outposts?</a> in the <i>Amazon S3 User Guide</i>.
        /// </para>
        /// </summary>
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String BucketName { get; set; }
        #endregion

        #region Upload Single File Params

        #region Parameter Key
        /// <summary>
        /// The key that will be used to identify the object in S3. If the -File parameter is specified, -Key is optional
        /// and the object key can be inferred from the filename value supplied to the -File parameter.
        /// </summary>
        [Parameter(Position = 1, ParameterSetName = ParamSet_FromLocalFile, ValueFromPipelineByPropertyName = true)]
        [Parameter(Position = 1, ParameterSetName = ParamSet_FromLocalFileChecksum, ValueFromPipelineByPropertyName = true)]
        [Parameter(Position = 1, ParameterSetName = ParamSet_FromContent, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Parameter(Position = 1, ParameterSetName = ParamSet_FromStream, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.AWSRequiredParameter(ParameterSets = new[] { ParamSet_FromContent, ParamSet_FromStream })]
        public System.String Key { get; set; }
        #endregion

        #region Parameter File
        /// <summary>
        /// The full path to the local file to be uploaded.
        /// </summary>
        [Parameter(Position = 2, ParameterSetName = ParamSet_FromLocalFile, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Parameter(Position = 2, ParameterSetName = ParamSet_FromLocalFileChecksum, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String File { get; set; }
        #endregion

        #endregion

        #region Upload Stream Params

        #region Parameter Stream
        /// <summary>
        /// <para>
        /// <para>The stream to be uploaded.</para>
        /// </para>
        /// <para>The cmdlet accepts a parameter of type string, string[], System.IO.FileInfo or System.IO.Stream.</para>
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_FromStream, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public object Stream { get; set; }
        #endregion

        #region Parameter Content
        /// <summary>
        /// Specifies text content that will be used to set the content of the object in S3. Use a here-string to
        /// specify multiple lines of text.
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_FromContent, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Alias("Text")]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Content { get; set; }
        #endregion

        #endregion

        #region Upload Folder Params

        #region Parameter KeyPrefix
        /// <summary>
        /// <para>
        /// The common key prefix that will be used for the objects uploaded to S3. Use this parameter when uploading
        /// multiple objects. Each object's final key will be of the form 'keyprefix/filename'.
        /// </para>
        /// <para>
        /// To indicate that all content should be uploaded to the root of the bucket, specify a KeyPrefix of '\'
        /// or '/'.
        /// </para>
        /// </summary>
        [Alias("Prefix")]
        [Parameter(Position = 1, ParameterSetName = ParamSet_FromLocalFolder, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String KeyPrefix { get; set; }
        #endregion

        #region Parameter Folder
        /// <summary>
        /// The full path to a local folder; all content in the folder will be uploaded to the
        /// specified bucket and key. Sub-folders in the folder will only be uploaded if the
        /// Recurse switch is specified.
        /// </summary>
        [Alias("Directory")]
        [Parameter(Position = 2, ParameterSetName = ParamSet_FromLocalFolder, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Folder { get; set; }
        #endregion

        #region Parameter Recurse
        /// <summary>
        /// If set, all sub-folders beneath the folder set in LocalFolder will also be uploaded.
        /// The folder structure will be mirrored in S3.
        /// Defaults off [false].
        /// </summary>
        [Parameter(Position = 3, ParameterSetName = ParamSet_FromLocalFolder, ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Recurse { get; set; }
        #endregion

        #region Parameter SearchPattern
        /// <summary>
        /// The search pattern used to determine which files in the directory are uploaded.
        /// </summary>
        [Alias("Pattern")]
        [Parameter(Position = 4, ParameterSetName = ParamSet_FromLocalFolder, ValueFromPipelineByPropertyName = true)]
        public System.String SearchPattern { get; set; }
        #endregion

        #endregion

        #region Canned ACLs

        #region Parameter CannedACLName
        /// <summary>
        /// Specifies the name of the canned ACL (access control list) of permissions to be applied to the S3 object(s).
        /// Please refer to <a href="http://docs.aws.amazon.com/sdkfornet/v3/apidocs/Index.html?page=S3/TS3_S3CannedACL.html&tocid=Amazon_S3_S3CannedACL">Amazon.S3.Model.S3CannedACL</a> for information on S3 Canned ACLs.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.S3CannedACL")]
        public Amazon.S3.S3CannedACL CannedACLName { get; set; }
        #endregion

        #region Parameter PublicReadOnly 
        /// <summary>
        /// If set, applies an ACL making the S3 object(s) public with read-only permissions
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PublicReadOnly { get; set; }
        #endregion

        #region Parameter PublicReadWrite
        /// <summary>
        /// If set, applies an ACL making the S3 object(s) public with read-write permissions
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PublicReadWrite { get; set; }
        #endregion

        #endregion

        #region Parameter ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// <para>The account ID of the expected bucket owner. If the account ID that you provide does
        /// not match the actual owner of the bucket, the request fails with the HTTP status code
        /// <code>403 Forbidden</code> (access denied).</para>
        /// </para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = ParamSet_FromContent)]
        public System.String ExpectedBucketOwner { get; set; }
        #endregion

        #region Shared Params

        #region Parameter ContentType 
        /// <summary>
        /// <para>
        /// Specifies the MIME type of the content being uploaded. The default behavior if
        /// this parameter is not specified is to inspect the file extension to determine the
        /// content type.
        /// </para>
        /// <para>
        /// <bNote:</b> if this parameter is used when uploading a folder of files the 
        /// specified content type will be applied to all of the uploaded files, overriding the 
        /// default behavior to inspect file extensions.
        /// </para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContentType { get; set; }
        #endregion

        #region Parameter StorageClass

        // NOTE: This parameter does not use the marker attribute for automated validate set
        // updating because it would cause GLACIER to be added as a valid value. S3 does not
        // support use of GLACIER as a storage class on PutObject, it must be handled as a
        // lifecycle configuration
        // http://docs.aws.amazon.com/AmazonS3/latest/API/RESTObjectPUT.html

        /// <summary>
        /// Specifies the storage class for the object.
        /// Please refer to <a href="http://docs.aws.amazon.com/AmazonS3/latest/dev/storage-class-intro.html">Storage Classes</a> for information on S3 storage classes.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.S3.S3StorageClass StorageClass { get; set; }
        #endregion

        #region Parameter StandardStorage
        /// <summary>
        /// <para>
        /// Specifies the STANDARD storage class, which is the default storage class for S3 objects.
        /// Provides a 99.999999999% durability guarantee.
        /// </para>
        /// <para>
        /// This parameter is deprecated. Please use the StorageClass parameter instead.
        /// </para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter StandardStorage { get; set; }
        #endregion

        #region Parameter ReducedRedundancyStorage
        /// <summary>
        /// <para>
        /// Specifies S3 should use REDUCED_REDUNDANCY storage class for the object. This
        /// provides a reduced (99.99%) durability guarantee at a lower
        /// cost as compared to the STANDARD storage class. Use this
        /// storage class for non-mission critical data or for data
        /// that does not require the higher level of durability that S3
        /// provides with the STANDARD storage class.
        /// </para>
        /// <para>
        /// This parameter is deprecated. Please use the StorageClass parameter instead.
        /// </para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter ReducedRedundancyStorage { get; set; }
        #endregion

        #region Parameter ServerSideEncryption
        /// <summary>
        /// The server-side encryption algorithm used when storing this object in Amazon S3
        /// Allowable values: None, AES256, aws:kms.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ServerSideEncryptionMethod")]
        public Amazon.S3.ServerSideEncryptionMethod ServerSideEncryption { get; set; }
        #endregion

        #region Parameter ServerSideEncryptionKeyManagementServiceKeyId
        /// <summary>
        /// The id of the AWS Key Management Service key that Amazon S3 should use to encrypt and decrypt the object.
        /// If a key id is not specified, the default key will be used for encryption and decryption.
        /// <para>
        /// If <code>x-amz-server-side-encryption</code> has a valid value of <code>aws:kms</code>,
        /// this header specifies the ID of the Amazon Web Services Key Management Service (Amazon
        /// Web Services KMS) symmetric encryption customer managed key that was used for the
        /// object. If you specify <code>x-amz-server-side-encryption:aws:kms</code>, but do not
        /// provide<code> x-amz-server-side-encryption-aws-kms-key-id</code>, Amazon S3 uses the
        /// Amazon Web Services managed key to protect the data. If the KMS key does not exist
        /// in the same account issuing the command, you must use the full ARN and not just the
        /// ID. 
        /// </para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServerSideEncryptionKeyManagementServiceKeyId { get; set; }
        #endregion

        #region Parameter ServerSideEncryptionCustomerMethod
        /// <summary>
        /// Specifies the server-side encryption algorithm to be used with the customer provided key.
        /// Allowable values: None or AES256.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ServerSideEncryptionCustomerMethod")]
        public Amazon.S3.ServerSideEncryptionCustomerMethod ServerSideEncryptionCustomerMethod { get; set; }
        #endregion

        #region Parameter ServerSideEncryptionCustomerProvidedKey
        /// <summary>
        /// Specifies base64-encoded encryption key for Amazon S3 to use to encrypt the object.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServerSideEncryptionCustomerProvidedKey { get; set; }
        #endregion

        #region Parameter ServerSideEncryptionCustomerProvidedKeyMD5
        /// <summary>
        /// Specifies base64-encoded MD5 of the encryption key for Amazon S3 to use to decrypt the object. This field is optional, the SDK will calculate the MD5 if this is not set.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServerSideEncryptionCustomerProvidedKeyMD5 { get; set; }
        #endregion

        #region Parameter Metadata
        /// <summary>
        /// Metadata headers to set on the object.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable Metadata { get; set; }
        #endregion

        #region Parameter HeaderCollection
        /// <summary>
        /// Response headers to set on the object.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Headers")]
        public System.Collections.Hashtable HeaderCollection { get; set; }
        #endregion

        #region Parameter TagSet

        /// <summary>
        /// One or more tags to apply to the object.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public Tag[] TagSet { get; set; }

        #endregion

        #region Parameter ChecksumAlgorithm
        /// <summary>
        /// Indicates the algorithm you want Amazon S3 to use to create the checksum for the object.
        /// For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/checking-object-integrity.html">Checking
        /// object integrity</a> in the <i>Amazon S3 User Guide</i>.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = ParamSet_FromLocalFile)]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = ParamSet_FromContent)]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = ParamSet_FromStream)]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = ParamSet_FromLocalFileChecksum, Mandatory = true)]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = ParamSet_FromLocalFolder)]
        [AWSRequiredParameter(ParameterSets = new[] { ParamSet_FromLocalFileChecksum })]
        [AWSConstantClassSource("Amazon.S3.ChecksumAlgorithm")]
        public ChecksumAlgorithm ChecksumAlgorithm { get; set; }
        #endregion

        #region Parameter ChecksumValue
        /// <summary>
        /// The checksum of the object base64 encoded with the alorithm specified in the <code>ChecksumAlgorithm</code> parameter. This checksum is only present if the checksum was uploaded
        /// with the object. When you use an API operation on an object that was uploaded using multipart uploads, this value may not be a direct checksum value of the full object. 
        /// Instead, it's a calculation based on the checksum values of each individual part. For more information about how checksums are calculated
        /// with multipart uploads, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/checking-object-integrity.html#large-object-checksums">
        /// Checking object integrity</a> in the <i>Amazon S3 User Guide</i>."
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = ParamSet_FromLocalFileChecksum)]
        public String ChecksumValue { get; set; }
        #endregion

        #region Parameter MpuObjectSize
        /// <summary>
        /// The expected total object size of the multipart upload request. If there's a mismatch
        /// between the specified object size value and the actual object size value, it results in an
        /// <code>HTTP 400 InvalidRequest</code> error. This value is ignored if the operation is not a
        /// multipart upload.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = ParamSet_FromLocalFile)]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = ParamSet_FromLocalFileChecksum)]
        public long? MpuObjectSize { get; set; }
        #endregion

        #region Parameter RequestPayer
        /// <summary>
        /// <para>
        /// <para>Confirms that the requester knows that they will be charged for the request. 
        /// Bucket owners need not specify this parameter in their requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.RequestPayer")]
        public Amazon.S3.RequestPayer RequestPayer { get; set; }
        #endregion

        #endregion

        #region TransferUtility Params

        #region Parameter ConcurrentServiceRequest
        /// <summary>
        /// This property determines how many active threads will be used to upload the file .
        /// This property is only applicable if the file being uploaded is larger than 16 MB, in which case TransferUtility 
        /// is used to upload multiple parts in parallel.
        /// The default value is 10.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConcurrentServiceRequests")]
        public System.Int32? ConcurrentServiceRequest { get; set; }
        #endregion

        #region Parameter CalculateContentMD5Header
        /// <summary>
        /// This property determines whether the Content-MD5 header should be calculated for upload.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [Obsolete("This parameter is redundant in the latest version of the S3 module, which automatically calculates a checksum to verify data integrity")]
        public bool CalculateContentMD5Header { get; set; }
        #endregion

        #region Parameter PartSize
        /// <summary>
        /// This property determines the part size of the upload. 
        /// The uploaded file will be divided into parts of the size specified and
        /// uploaded to Amazon S3 individually. The part size can be between 5 MB to 5 GB.
        /// <para>You can specify this value in one of two ways:</para>
        /// <ul><li><para>The part size in bytes. For example, 6291456.</para></li>
        /// <li><para>The part size with a size suffix. You can use bytes, KB, MB, GB. For example, 6291456bytes, 15.12MB, "15.12 MB".</para></li></ul>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public FileSize PartSize { get; set; }
        #endregion

        #endregion

        #region Parameter IfNoneMatch
        /// <summary>
        /// <para>Uploads the object only if the object key name does not already exist in the bucket specified. Otherwise, 
        /// Amazon S3 returns a <code>412 Precondition Failed</code> error.</para> <para>If a conflicting operation occurs 
        /// during the upload S3 returns a <code>409 ConditionalRequestConflict</code> response. On a 409 failure you should 
        /// re-initiate the multipart upload with <code>CreateMultipartUpload</code> and re-upload each part.</para> <para>Expects 
        /// the '*' (asterisk) character.</para> <para>For more information about conditional requests, 
        /// see <a href="https://tools.ietf.org/html/rfc7232">RFC 7232</a>, or <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/conditional-requests.html">Conditional requests</a> 
        /// in the <i>Amazon S3 User Guide</i>.</para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IfNoneMatch { get; set; }
        #endregion

        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion

        #region Parameter EnableLegacyKeyCleaning
        /// <summary>
        /// Specifies whether to use legacy key cleaning behavior for S3 key names. When this switch is present,
        /// the cmdlet will clean key names by removing leading spaces, forward slashes (/), and backslashes (\),
        /// converting all backslashes to forward slashes, and removing trailing spaces. When not specified,
        /// the legacy key cleaning is disabled.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter EnableLegacyKeyCleaning { get; set; }
        #endregion

        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (!ConfirmShouldProceed(this.Force.IsPresent, this.BucketName, "Write-S3Object (PutObject)"))
                return;

            var context = new CmdletContext
            {
                BucketName = this.BucketName
            };

            if (this.Key != null)
            {
                context.Key = this.Key;

                if (this.EnableLegacyKeyCleaning.IsPresent)
                {
                    context.Key= AmazonS3Helper.CleanKey(this.Key);
                    base.UserAgentAddition = AmazonS3Helper.GetCleanKeyUserAgentAdditionString(this.Key, context.Key);
                }
            }

            if (this.ParameterSetName == ParamSet_FromLocalFile || this.ParameterSetName == ParamSet_FromLocalFileChecksum)
            {
                context.File = PSHelpers.PSPathToAbsolute(this.SessionState.Path, this.File.Trim());
                if (string.IsNullOrEmpty(context.Key))
                    context.Key = Path.GetFileName(context.File);
            }
            else if (this.ParameterSetName == ParamSet_FromStream)
            {
                context.Stream = this.Stream;
            }
            else if (this.ParameterSetName == ParamSet_FromContent)
            {
                context.Content = this.Content;
            }
            else
            {
                context.Folder = PSHelpers.PSPathToAbsolute(this.SessionState.Path, this.Folder.Trim());
                context.Recurse = this.Recurse.IsPresent;
                context.OriginalKeyPrefix = this.KeyPrefix;
                if (!rootIndicators.Contains<string>(this.KeyPrefix, StringComparer.OrdinalIgnoreCase))
                {
                    context.KeyPrefix = this.KeyPrefix;

                    if (this.EnableLegacyKeyCleaning.IsPresent)
                    {
                        context.KeyPrefix = AmazonS3Helper.CleanKey(this.KeyPrefix);
                        base.UserAgentAddition = AmazonS3Helper.GetCleanKeyUserAgentAdditionString(this.KeyPrefix, context.KeyPrefix);
                    }
                }
                if (!string.IsNullOrEmpty(this.SearchPattern))
                    context.SearchPattern = this.SearchPattern;
            }

            if (!string.IsNullOrEmpty(this.CannedACLName))
            {
                context.CannedACL = this.CannedACLName;
            }
            else if (this.PublicReadOnly.IsPresent)
                context.CannedACL = S3CannedACL.PublicRead;
            else if (this.PublicReadWrite.IsPresent)
                context.CannedACL = S3CannedACL.PublicReadWrite;

            if (this.ExpectedBucketOwner != null)
                context.ExpectedBucketOwner = this.ExpectedBucketOwner;

            context.ContentType = this.ContentType;

            if (ParameterWasBound("StorageClass"))
                context.StorageClass = this.StorageClass;
            else
            {
                if (this.StandardStorage.IsPresent)
                    context.StorageClass = S3StorageClass.Standard;
                else if (this.ReducedRedundancyStorage.IsPresent)
                    context.StorageClass = S3StorageClass.ReducedRedundancy;
            }

            if (!string.IsNullOrEmpty(this.ServerSideEncryption))
                context.ServerSideEncryptionMethod = AmazonS3Helper.Convert(this.ServerSideEncryption);

            if (!string.IsNullOrEmpty(this.ServerSideEncryptionCustomerMethod))
                context.ServerSideEncryptionCustomerMethod = this.ServerSideEncryptionCustomerMethod;

            context.ServerSideEncryptionCustomerProvidedKey = this.ServerSideEncryptionCustomerProvidedKey;
            context.ServerSideEncryptionCustomerProvidedKeyMD5 = this.ServerSideEncryptionCustomerProvidedKeyMD5;
            context.ServerSideEncryptionKeyManagementServiceKeyId = this.ServerSideEncryptionKeyManagementServiceKeyId;

            if (this.ConcurrentServiceRequest.HasValue)
            {
                if (this.ConcurrentServiceRequest.Value <= 0)                
                    throw new ArgumentOutOfRangeException("ConcurrentServiceRequests", 
                        "ConcurrentServiceRequests should be set to a positive integer value.");
                
                context.ConcurrentServiceRequests = this.ConcurrentServiceRequest.Value;
            }

            context.Metadata = this.Metadata;
            context.Headers = this.HeaderCollection;
            context.TagSet = this.TagSet;

#pragma warning disable CS0618 // A class member was marked with the Obsolete attribute
            context.CalculateContentMD5Header = this.CalculateContentMD5Header;
#pragma warning restore CS0618 // A class member was marked with the Obsolete attribute

            if (this.ChecksumAlgorithm != null)
            {
                context.ChecksumAlgorithm = this.ChecksumAlgorithm;
            }

            if (!string.IsNullOrEmpty(this.ChecksumValue))
                context.ChecksumValue = this.ChecksumValue;

            if (this.MpuObjectSize != null)
            {
                long mpuObjectSize = this.MpuObjectSize.Value;
                context.MpuObjectSize = mpuObjectSize;
            }

            if (this.PartSize != null)
            {
                if (this.PartSize.FileSizeInBytes < MinPartSize || this.PartSize.FileSizeInBytes > MaxPartSize)
                    throw new ArgumentException("PartSize", string.Format("PartSize must be between {0} and {1} (bytes).", MinPartSize, MaxPartSize));

                context.PartSize = this.PartSize.FileSizeInBytes;
            }

            if (!string.IsNullOrEmpty(this.IfNoneMatch))
                context.IfNoneMatch = this.IfNoneMatch;

            context.RequestPayer = this.RequestPayer;

            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }

        #region IExecutor Members

        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

            if (!string.IsNullOrEmpty(cmdletContext.File) || cmdletContext.Stream != null)
                return UploadFileToS3(cmdletContext);

            if (!string.IsNullOrEmpty(cmdletContext.Content))
                return UploadTextToS3(cmdletContext);

            if (!string.IsNullOrEmpty(cmdletContext.Folder))
                return UploadFolderToS3(cmdletContext);
            
            ThrowExecutionError("Expected File, Content or Folder parameter values to define content to upload to S3", this);
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion

        // Uploads inline content to S3. We cannot write this to a text file first, as
        // SDK will use tempfile extension (.tmp) to set content-type, overriding what
        // the user has specified. Therefore we use a PutObject call instead of using the
        // transfer manager.
        CmdletOutput UploadTextToS3(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var request = new PutObjectRequest
            {
                BucketName = cmdletContext.BucketName,
                Key = cmdletContext.Key,
                ContentBody = cmdletContext.Content
            };

            if (cmdletContext.CannedACL != null)
                request.CannedACL = cmdletContext.CannedACL.Value;
            if (!string.IsNullOrEmpty(cmdletContext.ContentType))
                request.ContentType = cmdletContext.ContentType;
            if (cmdletContext.StorageClass != null)
                request.StorageClass = cmdletContext.StorageClass.Value;
            if (cmdletContext.ServerSideEncryptionMethod != null)
                request.ServerSideEncryptionMethod = cmdletContext.ServerSideEncryptionMethod.Value;

            if (cmdletContext.ServerSideEncryptionCustomerMethod != null)
                request.ServerSideEncryptionCustomerMethod = cmdletContext.ServerSideEncryptionCustomerMethod;
            if (cmdletContext.ServerSideEncryptionCustomerProvidedKey != null)
                request.ServerSideEncryptionCustomerProvidedKey = cmdletContext.ServerSideEncryptionCustomerProvidedKey;
            if (cmdletContext.ServerSideEncryptionCustomerProvidedKeyMD5 != null)
                request.ServerSideEncryptionCustomerProvidedKeyMD5 = cmdletContext.ServerSideEncryptionCustomerProvidedKeyMD5;
            if (cmdletContext.ServerSideEncryptionKeyManagementServiceKeyId != null)
                request.ServerSideEncryptionKeyManagementServiceKeyId = cmdletContext.ServerSideEncryptionKeyManagementServiceKeyId;
            if (cmdletContext.TagSet != null)
                request.TagSet = new List<Tag>(cmdletContext.TagSet);
            if (cmdletContext.ChecksumAlgorithm != null)
                request.ChecksumAlgorithm = cmdletContext.ChecksumAlgorithm;
            if (!string.IsNullOrEmpty(cmdletContext.IfNoneMatch))
                request.IfNoneMatch = cmdletContext.IfNoneMatch;
            if (cmdletContext.ExpectedBucketOwner != null)
                request.ExpectedBucketOwner = cmdletContext.ExpectedBucketOwner;
            

#pragma warning disable CS0618 // A class member was marked with the Obsolete attribute
            request.CalculateContentMD5Header = cmdletContext.CalculateContentMD5Header;
#pragma warning restore CS0618 // A class member was marked with the Obsolete attribute

            if (cmdletContext.RequestPayer != null)
            {
                request.RequestPayer = cmdletContext.RequestPayer;
            }

            AmazonS3Helper.SetMetadataAndHeaders(request, cmdletContext.Metadata, cmdletContext.Headers);

            CmdletOutput output;

            using (var client = CreateClient(_CurrentCredentials, _RegionEndpoint))
            {
                Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3", "PutObject");

                var runner = new ProgressRunner(this);
                var tracker = new UploadTextProgressTracker(runner, handler => request.StreamTransferProgress += handler, cmdletContext.Key);

                output = runner.SafeRun(() => CallAWSServiceOperation(client, request), tracker);
            }

            return output;
        }

        private CmdletOutput UploadFileToS3(ExecutorContext context)
        {
            System.IO.Stream _Stream = null;

            try
            {
                var cmdletContext = context as CmdletContext;
                var request = new TransferUtilityUploadRequest
                                {
                                    BucketName = cmdletContext.BucketName,
                                    Key = cmdletContext.Key
                                };

                if (!string.IsNullOrEmpty(cmdletContext.File))
                {
                    request.FilePath = cmdletContext.File;
                }
                else if (cmdletContext.Stream != null)
                {
                    _Stream = Amazon.PowerShell.Common.StreamParameterConverter.TransformToStream(cmdletContext.Stream);
                    request.InputStream = _Stream;
                }

                if (cmdletContext.CannedACL != null)
                    request.CannedACL = cmdletContext.CannedACL.Value;
                if (!string.IsNullOrEmpty(cmdletContext.ContentType))
                    request.ContentType = cmdletContext.ContentType;
                if (cmdletContext.StorageClass != null)
                    request.StorageClass = cmdletContext.StorageClass.Value;
                if (cmdletContext.ServerSideEncryptionMethod != null)
                    request.ServerSideEncryptionMethod = cmdletContext.ServerSideEncryptionMethod.Value;

                if (cmdletContext.ServerSideEncryptionCustomerMethod != null)
                    request.ServerSideEncryptionCustomerMethod = cmdletContext.ServerSideEncryptionCustomerMethod;
                if (cmdletContext.ServerSideEncryptionCustomerProvidedKey != null)
                    request.ServerSideEncryptionCustomerProvidedKey = cmdletContext.ServerSideEncryptionCustomerProvidedKey;
                if (cmdletContext.ServerSideEncryptionCustomerProvidedKeyMD5 != null)
                    request.ServerSideEncryptionCustomerProvidedKeyMD5 = cmdletContext.ServerSideEncryptionCustomerProvidedKeyMD5;
                if (cmdletContext.ServerSideEncryptionKeyManagementServiceKeyId != null)
                    request.ServerSideEncryptionKeyManagementServiceKeyId = cmdletContext.ServerSideEncryptionKeyManagementServiceKeyId;
                if (cmdletContext.TagSet != null)
                    request.TagSet = new List<Tag>(cmdletContext.TagSet);
                if (cmdletContext.ChecksumAlgorithm != null)
                    request.ChecksumAlgorithm = cmdletContext.ChecksumAlgorithm;

                if (!string.IsNullOrEmpty(cmdletContext.ChecksumValue))
                {
                    switch (cmdletContext.ChecksumAlgorithm.Value)
                    {
                        case "CRC32":
                            request.ChecksumCRC32 = cmdletContext.ChecksumValue;
                            break;
                        case "CRC32C":
                            request.ChecksumCRC32C = cmdletContext.ChecksumValue;
                            break;
                        case "CRC64NVME":
                            request.ChecksumCRC64NVME = cmdletContext.ChecksumValue;
                            break;
                        case "SHA1":
                            request.ChecksumSHA1 = cmdletContext.ChecksumValue;
                            break;
                        case "SHA256":
                            request.ChecksumSHA256 = cmdletContext.ChecksumValue;
                            break;
                    }
                }

                if (cmdletContext.MpuObjectSize != null)
                {
                    long mpuObjectSize = cmdletContext.MpuObjectSize.Value;
                    request.MpuObjectSize = mpuObjectSize;
                }

                if (!string.IsNullOrEmpty(cmdletContext.IfNoneMatch))
                    request.IfNoneMatch = cmdletContext.IfNoneMatch;

#pragma warning disable CS0618 // A class member was marked with the Obsolete attribute
                request.CalculateContentMD5Header = cmdletContext.CalculateContentMD5Header;
#pragma warning restore CS0618 // A class member was marked with the Obsolete attribute

                if (cmdletContext.PartSize != null)
                    request.PartSize = cmdletContext.PartSize.Value;

                if (cmdletContext.RequestPayer != null)
                {
                    request.RequestPayer = cmdletContext.RequestPayer;
                }

                var transferUtilityConfig = new TransferUtilityConfig();
                if (cmdletContext.ConcurrentServiceRequests.HasValue)
                    transferUtilityConfig.ConcurrentServiceRequests = cmdletContext.ConcurrentServiceRequests.Value;

                AmazonS3Helper.SetMetadataAndHeaders(request, cmdletContext.Metadata, cmdletContext.Headers);

                CmdletOutput output;
                using (var tu = new TransferUtility(Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint), transferUtilityConfig))
                {
                    Utils.Common.WriteVerboseEndpointMessage(this, Client.Config, "Amazon S3 object upload APIs");

                    var runner = new ProgressRunner(this);
                
                    string fileName = string.IsNullOrEmpty(cmdletContext.File) ? cmdletContext.Key : cmdletContext.File;
                    var tracker = new UploadFileProgressTracker(runner, handler => request.UploadProgressEvent += handler, fileName);

                    output = runner.SafeRun(() => tu.Upload(request), tracker);
                }

                return output;
            }
            finally
            {
                if( _Stream != null)
                {
                    _Stream.Dispose();
                }
            }
        }

        private CmdletOutput UploadFolderToS3(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var request = new TransferUtilityUploadDirectoryRequest
            {
                Directory = cmdletContext.Folder,
                BucketName = cmdletContext.BucketName,
                KeyPrefix = cmdletContext.KeyPrefix,
                ContentType = cmdletContext.ContentType
            };

            if (cmdletContext.Recurse)
                request.SearchOption = SearchOption.AllDirectories;
            else
                request.SearchOption = SearchOption.TopDirectoryOnly;
            if (!string.IsNullOrEmpty(cmdletContext.SearchPattern))
                request.SearchPattern = cmdletContext.SearchPattern;

            if (cmdletContext.CannedACL != null)
                request.CannedACL = cmdletContext.CannedACL.Value;
            if (cmdletContext.StorageClass != null)
                request.StorageClass = cmdletContext.StorageClass.Value;
            if (cmdletContext.ServerSideEncryptionMethod != null)
                request.ServerSideEncryptionMethod = cmdletContext.ServerSideEncryptionMethod.Value;
            if (cmdletContext.ServerSideEncryptionKeyManagementServiceKeyId != null)
                request.ServerSideEncryptionKeyManagementServiceKeyId = cmdletContext.ServerSideEncryptionKeyManagementServiceKeyId;
            if (cmdletContext.TagSet != null)
                request.TagSet = new List<Tag>(cmdletContext.TagSet);

#pragma warning disable CS0618 // A class member was marked with the Obsolete attribute
            request.CalculateContentMD5Header = cmdletContext.CalculateContentMD5Header;
#pragma warning restore CS0618 // A class member was marked with the Obsolete attribute

            if (cmdletContext.ChecksumAlgorithm != null)
            {
                request.ChecksumAlgorithm = cmdletContext.ChecksumAlgorithm;
            }

            if (cmdletContext.RequestPayer != null)
            {
                request.RequestPayer = cmdletContext.RequestPayer;
            }
            

            AmazonS3Helper.SetExtraRequestFields(request, cmdletContext);

            CmdletOutput output;
            using (var tu = new TransferUtility(Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint)))
            {
                Utils.Common.WriteVerboseEndpointMessage(this, Client.Config, "Amazon S3 object upload APIs");

                var runner = new ProgressRunner(this);
                var tracker = new UploadFolderProgressTracker(runner, handler => request.UploadDirectoryProgressEvent += handler, cmdletContext.Folder);
                output = runner.SafeRun(() => tu.UploadDirectory(request), tracker);

                WriteVerbose(string.Format("Uploaded {0} object(s) to bucket '{1}' from '{2}' with keyprefix '{3}'",
                                           tracker.UploadedCount,
                                           cmdletContext.BucketName,
                                           cmdletContext.Folder,
                                           cmdletContext.OriginalKeyPrefix));
            }

            return output;
        }

        #region AWS Service Operation Call

        private Amazon.S3.Model.PutObjectResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.PutObjectRequest request)
        {
            try
            {
                return client.PutObjectAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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

        internal class CmdletContext : ExecutorContext
        {
            public String BucketName { get; set; }

            public String Key { get; set; }
            public String File { get; set; }
            public object Stream { get; set; }
            public String Content { get; set; }

            public String OriginalKeyPrefix { get; set; }
            public String KeyPrefix { get; set; }
            public String Folder { get; set; }
            public bool Recurse { get; set; }
            public string SearchPattern { get; set; }

            public S3CannedACL CannedACL { get; set; }
            public String ContentType { get; set; }
            public S3StorageClass StorageClass { get; set; }
            public ServerSideEncryptionMethod ServerSideEncryptionMethod { get; set; }
            public string ServerSideEncryptionKeyManagementServiceKeyId { get; set; }
            public ServerSideEncryptionCustomerMethod ServerSideEncryptionCustomerMethod { get; set; }
            public string ServerSideEncryptionCustomerProvidedKey { get; set; }
            public string ServerSideEncryptionCustomerProvidedKeyMD5 { get; set; }

            public ChecksumAlgorithm ChecksumAlgorithm { get; set; }
            public String ChecksumValue { get; set; }
            public long? MpuObjectSize { get; set; }

            public string ExpectedBucketOwner { get; set;}
            public Hashtable Metadata { get; set; }
            public Hashtable Headers { get; set; }

            public Tag[] TagSet { get; set; }

            public int? ConcurrentServiceRequests { get; set; }

            public bool CalculateContentMD5Header { get; set; }

            public long? PartSize { get; set; }

            public String IfNoneMatch { get; set; }

            public RequestPayer RequestPayer { get; set; }
        }

        #region Progress Trackers

        internal class UploadTextProgressTracker : ProgressTracker<StreamTransferProgressArgs>
        {
            int _currentPercent = 0;
            readonly string _key;

            const string UploadingFileActivity = "Uploading";
            const string ProgressMsgFormat = "File {0}...{1}%";

            public override string Activity
            {
                get { return UploadingFileActivity; }
            }

            public UploadTextProgressTracker(ProgressRunner runner, Action<EventHandler<StreamTransferProgressArgs>> subscribe, string key)
                : base(runner, subscribe)
            {
                this._key = key;

                ReportProgress(0, ProgressMsgFormat, _key, 0);
            }

            public override void ReportProgress(StreamTransferProgressArgs args)
            {
                if (args.PercentDone != _currentPercent)
                {
                    _currentPercent = args.PercentDone;
                    ReportProgress(args.PercentDone, ProgressMsgFormat, _key, args.PercentDone);
                }
            }
        }

        internal class UploadFileProgressTracker : ProgressTracker<UploadProgressArgs>
        {
            int _currentPercent = 0;
            readonly string _fileName;

            const string UploadingFileActivity = "Uploading";
            const string ProgressMsgFormat = "File {0}...{1}%";

            public override string Activity
            {
                get { return UploadingFileActivity; }
            }

            public UploadFileProgressTracker(ProgressRunner runner, Action<EventHandler<UploadProgressArgs>> subscribe, string fileName)
                : base(runner, subscribe)
            {
                this._fileName = fileName;

                ReportProgress(0, ProgressMsgFormat, _fileName, 0);
            }

            public override void ReportProgress(UploadProgressArgs args)
            {
                if (args.PercentDone != _currentPercent)
                {
                    _currentPercent = args.PercentDone;
                    ReportProgress(_currentPercent, ProgressMsgFormat, _fileName, _currentPercent);
                }
            }
        }

        internal class UploadFolderProgressTracker : ProgressTracker<UploadDirectoryProgressArgs>
        {
            private int _filesCompleted = 0;
            private readonly string _startingFolder;

            private const string UploadingFolderActivity = "Uploading";
            private const string ProgressMsgFormat = "Uploaded {0} of {1} files from {2}, processing: {3}";

            public override string Activity
            {
                get { return UploadingFolderActivity; }
            }

            public int UploadedCount
            {
                get { return _filesCompleted; }
            }

            public UploadFolderProgressTracker(ProgressRunner runner, Action<EventHandler<UploadDirectoryProgressArgs>> subscribe, string startingFolder)
                : base(runner, subscribe)
            {
                this._startingFolder = startingFolder;

                ReportProgress(0, "Starting upload from {0}", _startingFolder);
            }

            public override void ReportProgress(UploadDirectoryProgressArgs args)
            {
                // Transfer util has an intermittent bug where it will send uploaded > total
                // for number of files. Still tracking it down, but this makes the progress
                // update safe for pshell users
                if (args.NumberOfFilesUploaded <= args.TotalNumberOfFiles)
                {
                    _filesCompleted = args.NumberOfFilesUploaded;

                    var currentPercent = (int)(((float)args.TransferredBytes / args.TotalBytes) * 100);
                    ReportProgress(currentPercent,
                                   ProgressMsgFormat,
                                   args.NumberOfFilesUploaded,
                                   args.TotalNumberOfFiles,
                                   _startingFolder,
                                   args.CurrentFile.Substring(_startingFolder.Length + 1));
                }
            }
        }

        #endregion
    }
}
