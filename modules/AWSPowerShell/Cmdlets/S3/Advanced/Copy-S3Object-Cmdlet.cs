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
using System.Management.Automation;
using System.Linq;
using Amazon.PowerShell.Common;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using System.IO;
using Amazon.PowerShell.Utils;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Amazon.Runtime;
using AWSRegion = Amazon.PowerShell.Common.AWSRegion;
using System.Text;
using Amazon.Runtime.CredentialManagement;
using Amazon.Util;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// <para>
    /// Copies an S3 object to another object in S3, or downloads one or more objects from S3 to the local file system.
    /// Note that you can also use the 
    /// <a href="https://docs.aws.amazon.com/powershell/latest/reference/index.html?page=Read-S3Object.html&tocid=Read-S3Object">Read-S3Object</a> 
    /// cmdlet to download one or more objects to the local file system.
    /// </para>
    /// <para>
    /// You can pipe an Amazon.S3.Model.S3Object instance to this cmdlet and its members will be used to
    /// satisfy the BucketName, Key and optionally VersionId (if an S3ObjectVersion instance is supplied), parameters
    /// when downloading or copying a single object.
    /// </para>
    /// </summary>
    [Cmdlet("Copy", "S3Object", DefaultParameterSetName = CopySingleObjectToLocalFile, SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Low)]
    [OutputType(new[] { typeof(S3Object), typeof(FileInfo), typeof(DirectoryInfo) })]
    [AWSCmdlet("Calls the Amazon S3 CopyObject API operation to copy an existing S3 object to another S3 destination (bucket and/or object),"
                    + " or download a single S3 object to a local file or folder or download object(s) matching a supplied"
                    + " key prefix to a folder.",
                    Operation = new [] {"CopyObject"})]
    [AWSCmdletOutput("Amazon.S3.Model.S3Object or System.IO.FileInfo or System.IO.DirectoryInfo",
        "When copying an object to another object in S3 the cmdlet returns an Amazon.S3.Model.S3Object referencing the new object. "
            + " When copying a single object from S3 to the local file system the cmdlet returns a FileInfo instance representing the local file. "
            + " When copying multiple objects to a local folder the cmdlet returns a DirectoryInfo instance to the folder."
    )]
    public class CopyS3ObjectCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        const string CopySingleObjectToLocalFile = "CopySingleObjectToLocalFile";
        const string CopySingleObjectToLocalFolder = "CopySingleObjectToLocalFolder";
        const string CopyMultipleObjectsToLocalFolder = "CopyMultipleObjectsToLocalFolder";
        const string CopyS3ObjectToS3Object = "CopyS3ObjectToS3Object";

        private const long OneGigabyte = 1024 * 1024 * 1024;
        private const long FiveGigabytes = 5 * OneGigabyte;

        protected override bool IsSensitiveRequest { get; set; } = true;

        protected override bool IsSensitiveResponse { get; set; } = true;

        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// The name of the bucket containing the source object.
        /// </para>
        ///  
        /// <para>
        /// When using this action with an access point, you must direct requests to the access
        /// point hostname. The access point hostname takes the form <i>AccessPointName</i>-<i>AccountId</i>.s3-accesspoint.<i>Region</i>.amazonaws.com.
        /// When using this action with an access point through the Amazon Web Services SDKs,
        /// you provide the access point ARN in place of the bucket name. For more information
        /// about access point ARNs, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/using-access-points.html">Using
        /// access points</a> in the <i>Amazon S3 User Guide</i>.
        /// </para>
        ///  
        /// <para>
        /// When you use this action with Amazon S3 on Outposts, you must direct requests to the
        /// S3 on Outposts hostname. The S3 on Outposts hostname takes the form <code> <i>AccessPointName</i>-<i>AccountId</i>.<i>outpostID</i>.s3-outposts.<i>Region</i>.amazonaws.com</code>.
        /// When you use this action with S3 on Outposts through the Amazon Web Services SDKs,
        /// you provide the Outposts access point ARN in place of the bucket name. For more information
        /// about S3 on Outposts ARNs, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/S3onOutposts.html">What
        /// is S3 on Outposts</a> in the <i>Amazon S3 User Guide</i>.
        /// </para>
        /// </summary>
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("SourceBucket")]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String BucketName { get; set; }
        #endregion

        #region Parameter Key
        /// <summary>
        /// The key of the single source object to copy.
        /// </summary>
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = CopySingleObjectToLocalFile)]
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = CopyS3ObjectToS3Object)]
        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = CopySingleObjectToLocalFolder)]
        [Alias("SourceKey")]
        [Amazon.PowerShell.Common.AWSRequiredParameter(ParameterSets = new[] { CopySingleObjectToLocalFile, CopyS3ObjectToS3Object })]
        public System.String Key { get; set; }
        #endregion

        #region Parameter VersionId
        /// <summary>
        /// Specifies the version of the source object to copy.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = CopySingleObjectToLocalFile)]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = CopySingleObjectToLocalFolder)]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = CopyS3ObjectToS3Object)]
        [Alias("SourceVersionId")]
        public System.String VersionId { get; set; }
        #endregion

        #region Copy to S3 Target Parameters

        #region Parameter DestinationKey
        /// <summary>
        /// The key for the copy of the source S3 object.
        /// </summary>
        [Parameter(Position = 2, ParameterSetName = CopyS3ObjectToS3Object, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public System.String DestinationKey { get; set; }
        #endregion

        #region Parameter DestinationBucket
        /// <summary>
        /// <para>
        /// The name of the bucket that will contain the copied object.
        /// If not specified, the copy is to another S3 object in the source bucket.
        /// </para>
        ///  
        /// <para>
        /// When using this action with an access point, you must direct requests to the access
        /// point hostname. The access point hostname takes the form <i>AccessPointName</i>-<i>AccountId</i>.s3-accesspoint.<i>Region</i>.amazonaws.com.
        /// When using this action with an access point through the Amazon Web Services SDKs,
        /// you provide the access point ARN in place of the bucket name. For more information
        /// about access point ARNs, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/using-access-points.html">Using
        /// access points</a> in the <i>Amazon S3 User Guide</i>.
        /// </para>
        ///  
        /// <para>
        /// When you use this action with Amazon S3 on Outposts, you must direct requests to the
        /// S3 on Outposts hostname. The S3 on Outposts hostname takes the form <code> <i>AccessPointName</i>-<i>AccountId</i>.<i>outpostID</i>.s3-outposts.<i>Region</i>.amazonaws.com</code>.
        /// When you use this action with S3 on Outposts through the Amazon Web Services SDKs,
        /// you provide the Outposts access point ARN in place of the bucket name. For more information
        /// about S3 on Outposts ARNs, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/S3onOutposts.html">What
        /// is S3 on Outposts</a> in the <i>Amazon S3 User Guide</i>.
        /// </para>
        /// </summary>
        [Parameter(Position = 3, ParameterSetName = CopyS3ObjectToS3Object, ValueFromPipelineByPropertyName = true)]
        public System.String DestinationBucket { get; set; }
        #endregion

        #region Parameter MetadataDirective
        /// <summary>
        /// Specifies whether the metadata is copied from the source object or replaced with metadata provided in the request.
        /// Valid values are COPY or REPLACE. COPY is the default if not specified.
        /// </summary>
        [Parameter(ParameterSetName = CopyS3ObjectToS3Object, ValueFromPipelineByPropertyName = true)]
        public Amazon.S3.S3MetadataDirective MetadataDirective { get; set; }
        #endregion

        #region Parameter ContentType
        /// <summary>
        /// Sets the content type of the target object; if not specified an attempt is made to infer it using the destination
        /// or source object keys.
        /// </summary>
        [Parameter(ParameterSetName = CopyS3ObjectToS3Object, ValueFromPipelineByPropertyName = true)]
        public System.String ContentType { get; set; }
        #endregion
        /// <summary>
        /// Specifies the Region that the source bucket resides in; If not specified an attempt is made to infer it using the Region
        /// set in your credential profile. The -Region parameter specifies the Destination Region. 
        /// </summary>
        #region Parameter SourceRegion
        [Parameter(ParameterSetName = CopyS3ObjectToS3Object, ValueFromPipelineByPropertyName = true)]
        public Object SourceRegion { get; set; }

        #endregion

        #region Parameter CannedACLName
        /// <summary>
        /// Specifies the canned ACL (access control list) of permissions to be applied to the S3 bucket.
        /// Please refer to <a href="http://docs.aws.amazon.com/sdkfornet/v3/apidocs/Index.html?page=S3/TS3_S3CannedACL.html&tocid=Amazon_S3_S3CannedACL">Amazon.S3.Model.S3CannedACL</a> for information on S3 Canned ACLs.
        /// </summary>
        [Parameter(ParameterSetName = CopyS3ObjectToS3Object, ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.S3CannedACL")]
        public Amazon.S3.S3CannedACL CannedACLName { get; set; }
        #endregion

        #region Parameter PublicReadOnly
        /// <summary>
        /// If set, applies an ACL making the bucket public with read-only permissions
        /// </summary>
        [Parameter(ParameterSetName = CopyS3ObjectToS3Object, ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PublicReadOnly { get; set; }
        #endregion

        #region Parameter PublicReadWrite
        /// <summary>
        /// If set, applies an ACL making the bucket public with read-write permissions
        /// </summary>
        [Parameter(ParameterSetName = CopyS3ObjectToS3Object, ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PublicReadWrite { get; set; }
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
        [Parameter(ParameterSetName = CopyS3ObjectToS3Object, ValueFromPipelineByPropertyName = true)]
        public Amazon.S3.S3StorageClass StorageClass { get; set; }
        #endregion

        #region Parameter StandardStorage
        /// <summary>
        /// Specifies the STANDARD storage class, which is the default storage class for S3 objects.
        /// Provides a 99.999999999% durability guarantee.
        /// </summary>
        [Parameter(ParameterSetName = CopyS3ObjectToS3Object, ValueFromPipelineByPropertyName = true)]
        public SwitchParameter StandardStorage { get; set; }
        #endregion

        #region Parameter ReducedRedundancyStorage
        /// <summary>
        /// Specifies S3 should use REDUCED_REDUNDANCY storage class for the object. This
        /// provides a reduced (99.99%) durability guarantee at a lower
        /// cost as compared to the STANDARD storage class. Use this
        /// storage class for non-mission critical data or for data
        /// that doesn’t require the higher level of durability that S3
        /// provides with the STANDARD storage class.
        /// </summary>
        [Parameter(ParameterSetName = CopyS3ObjectToS3Object, ValueFromPipelineByPropertyName = true)]
        public SwitchParameter ReducedRedundancyStorage { get; set; }
        #endregion

        #region Parameter ServerSideEncryption
        /// <summary>
        /// <para>
        /// The server-side encryption algorithm used when storing this object in Amazon S3 (for
        /// example, AES256, <code>aws:kms</code>).
        /// </para>
        /// </summary>
        [Parameter(ParameterSetName = CopyS3ObjectToS3Object, ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ServerSideEncryptionMethod")]
        public Amazon.S3.ServerSideEncryptionMethod ServerSideEncryption { get; set; }
        #endregion

        #region Parameter ServerSideEncryptionKeyManagementServiceKeyId
        /// <summary>
        /// Specifies the AWS KMS key for Amazon S3 to use to encrypt the object.
        /// <para>
        /// Specifies the Amazon Web Services KMS key ID to use for object encryption. All GET
        /// and PUT requests for an object protected by Amazon Web Services KMS will fail if not
        /// made via SSL or using SigV4. For information about configuring using any of the officially
        /// supported Amazon Web Services SDKs and Amazon Web Services CLI, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/UsingAWSSDK.html#specify-signature-version">Specifying
        /// the Signature Version in Request Authentication</a> in the <i>Amazon S3 User Guide</i>.
        /// </para>
        /// </summary>
        [Parameter(ParameterSetName = CopyS3ObjectToS3Object, ValueFromPipelineByPropertyName = true)]
        public System.String ServerSideEncryptionKeyManagementServiceKeyId { get; set; }
        #endregion

        #region Parameter WebsiteRedirectLocation
        /// <summary>
        /// <para>
        /// If the bucket is configured as a website, redirects requests for this object to another
        /// object in the same bucket or to an external URL. Amazon S3 stores the value of this
        /// header in the object metadata. This value is unique to each object and is not copied
        /// when using the <code>x-amz-metadata-directive</code> header. Instead, you may opt
        /// to provide this header in combination with the directive.
        /// </para>
        /// </summary>
        [Parameter(ParameterSetName = CopyS3ObjectToS3Object, ValueFromPipelineByPropertyName = true)]
        public System.String WebsiteRedirectLocation { get; set; }
        #endregion

        #region Parameter Metadata
        /// <summary>
        /// Metadata headers to set on the object.
        /// </summary>
        [Parameter(ParameterSetName = CopyS3ObjectToS3Object, ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable Metadata { get; set; }
        #endregion

        #region Parameter HeaderCollection
        /// <summary>
        /// Response headers to set on the object.
        /// </summary>
        [Parameter(ParameterSetName = CopyS3ObjectToS3Object, ValueFromPipelineByPropertyName = true)]
        [Alias("Headers")]
        public System.Collections.Hashtable HeaderCollection { get; set; }
        #endregion

        #region Parameter TagSet

        /// <summary>
        /// One or more tags to apply to the object.
        /// </summary>
        [Parameter(ParameterSetName = CopyS3ObjectToS3Object, ValueFromPipelineByPropertyName = true)]
        public Tag[] TagSet { get; set; }

        #endregion

        #endregion

        #region Copy to Local File Parameters

        #region Parameter LocalFile
        /// <summary>
        /// The full path to the local file that will be created.
        /// </summary>
        [Parameter(Position = 2, ParameterSetName = CopySingleObjectToLocalFile, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Alias("File")]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String LocalFile { get; set; }
        #endregion

        #endregion

        #region Copy to Local Folder Parameters

        #region Parameter LocalFolder
        /// <summary>
        /// <para>
        /// The path to a local folder that will contain the downloaded object. If a relative path
        /// is supplied, it will be resolved to a full path using the current session's location.
        /// </para>
        /// <para>
        /// When copying to a local folder the object key is used as the filename. Note that object
        /// keys that are not valid filenames for the host system could cause an exception to be thrown.
        /// </para>
        /// </summary>
        [Parameter(ParameterSetName = CopySingleObjectToLocalFolder, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = CopyMultipleObjectsToLocalFolder, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Alias("Folder")]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String LocalFolder { get; set; }
        #endregion

        #region Parameter KeyPrefix
        /// <summary>
        /// Used to download multiple objects to the specified local folder. The supplied prefix
        /// will be used to determine the set of objects to download that share the same key prefix.
        /// You must specify either this parameter, or the -Key parameter, to determine what object(s) to 
        /// download.
        /// </summary>
        [Parameter(ParameterSetName = CopyMultipleObjectsToLocalFolder, ValueFromPipelineByPropertyName = true)]
        [Alias("SourcePrefix")]
        public System.String KeyPrefix { get; set; }
        #endregion

        #endregion

        #region Parameter ETagToMatch
        /// <summary>
        /// Copies the object if its entity tag (ETag) matches the specified tag; otherwise return a PreconditionFailed.
        /// </summary>
        [Parameter(ParameterSetName = CopyS3ObjectToS3Object, ValueFromPipelineByPropertyName = true)]
        public System.String ETagToMatch { get; set; }
        #endregion

        #region Parameter ETagToNotMatch
        /// <summary>
        /// Copies the object if its entity tag (ETag) is different than the specified Etag; otherwise returns an error.
        /// </summary>
        [Parameter(ParameterSetName = CopyS3ObjectToS3Object, ValueFromPipelineByPropertyName = true)]
        public System.String ETagToNotMatch { get; set; }
        #endregion

        #region Parameter ModifiedSinceDate
        /// <summary>
        /// Copies the object if it has been modified since the specified time; otherwise returns an error.
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This property is deprecated and may result in the wrong timestamp being passed to" +
            " the service, use UtcModifiedSinceDate instead.")]
        public System.DateTime ModifiedSinceDate { get; set; }
        #endregion

        #region Parameter UnmodifiedSinceDate
        /// <summary>
        /// Copies the object if it hasn't been modified since the specified time; otherwise returns a PreconditionFailed.
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This property is deprecated and may result in the wrong timestamp being passed to" +
            " the service, use UtcUnmodifiedSinceDate instead.")]
        public System.DateTime UnmodifiedSinceDate { get; set; }
        #endregion

        #region Parameter UtcModifiedSinceDate
        /// <summary>
        /// Copies the object if it has been modified since the specified time; otherwise returns an error.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime UtcModifiedSinceDate { get; set; }
        #endregion

        #region Parameter UtcUnmodifiedSinceDate
        /// <summary>
        /// Copies the object if it hasn't been modified since the specified time; otherwise returns a PreconditionFailed.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime UtcUnmodifiedSinceDate { get; set; }
        #endregion

        #region Parameter CopySourceServerSideEncryptionCustomerMethod
        /// <summary>
        /// Specifies the server-side encryption algorithm used on the source object with the customer provided key.
        /// Allowable values: None or AES256.
        /// </summary>
        [Parameter(ParameterSetName = CopyS3ObjectToS3Object, ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ServerSideEncryptionCustomerMethod")]
        public Amazon.S3.ServerSideEncryptionCustomerMethod CopySourceServerSideEncryptionCustomerMethod { get; set; }
        #endregion

        #region Parameter CopySourceServerSideEncryptionCustomerProvidedKey
        /// <summary>
        /// Specifies base64-encoded encryption key for Amazon S3 used on the source object.
        /// </summary>
        [Parameter(ParameterSetName = CopyS3ObjectToS3Object, ValueFromPipelineByPropertyName = true)]
        public System.String CopySourceServerSideEncryptionCustomerProvidedKey { get; set; }
        #endregion

        #region Parameter CopySourceServerSideEncryptionCustomerProvidedKeyMD5
        /// <summary>
        /// Specifies base64-encoded MD5 of the encryption key for Amazon S3 used on the source object. This field is optional, the SDK will calculate the MD5 if this is not set.
        /// </summary>
        [Parameter(ParameterSetName = CopyS3ObjectToS3Object, ValueFromPipelineByPropertyName = true)]
        public System.String CopySourceServerSideEncryptionCustomerProvidedKeyMD5 { get; set; }
        #endregion

        #region Parameter ServerSideEncryptionCustomerMethod
        /// <summary>
        /// Specifies the server-side encryption algorithm to be used with the customer provided key.
        /// Allowable values: None or AES256.
        /// </summary>
        [Parameter(ParameterSetName = CopyS3ObjectToS3Object, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = CopySingleObjectToLocalFolder, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = CopySingleObjectToLocalFile, ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ServerSideEncryptionCustomerMethod")]
        public Amazon.S3.ServerSideEncryptionCustomerMethod ServerSideEncryptionCustomerMethod { get; set; }
        #endregion

        #region Parameter ServerSideEncryptionCustomerProvidedKey
        /// <summary>
        /// Specifies base64-encoded encryption key for Amazon S3 to use to decrypt the object.
        /// </summary>
        [Parameter(ParameterSetName = CopyS3ObjectToS3Object, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = CopySingleObjectToLocalFolder, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = CopySingleObjectToLocalFile, ValueFromPipelineByPropertyName = true)]
        public System.String ServerSideEncryptionCustomerProvidedKey { get; set; }
        #endregion

        #region Parameter ServerSideEncryptionCustomerProvidedKeyMD5
        /// <summary>
        /// Specifies base64-encoded MD5 of the encryption key for Amazon S3 to use to decrypt the object. This field is optional, 
        /// the SDK will calculate the MD5 if this is not set.
        /// </summary>
        [Parameter(ParameterSetName = CopyS3ObjectToS3Object, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = CopySingleObjectToLocalFolder, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = CopySingleObjectToLocalFile, ValueFromPipelineByPropertyName = true)]
        public System.String ServerSideEncryptionCustomerProvidedKeyMD5 { get; set; }
        #endregion

        #region Parameter ChecksumAlgorithm
        /// <summary>
        /// Indicates the algorithm you want Amazon S3 to use to create the checksum for the object.
        /// For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/checking-object-integrity.html">Checking
        /// object integrity</a> in the <i>Amazon S3 User Guide</i>.
        /// </summary>
        [Parameter(ParameterSetName = CopyS3ObjectToS3Object, ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ChecksumAlgorithm")]
        public ChecksumAlgorithm ChecksumAlgorithm { get; set; }
        #endregion

        #region Parameter ChecksumMode
        /// <summary>
        /// Specifies base64-encoded MD5 of the encryption key for Amazon S3 to use to decrypt the object. This field is optional, 
        /// the SDK will calculate the MD5 if this is not set.
        /// </summary>
        [Parameter(ParameterSetName = CopyS3ObjectToS3Object, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = CopySingleObjectToLocalFolder, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = CopySingleObjectToLocalFile, ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ChecksumMode")]
        public ChecksumMode ChecksumMode { get; set; }
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

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (!ConfirmShouldProceed(this.Force.IsPresent, this.Key, "Copy-S3Object (CopyObject)"))
                return;

            var context = new CmdletContext
            {
                SourceBucket = this.BucketName,
                SourceKey = this.Key,
                SourceVersionId = this.VersionId,
                DestinationBucket = this.DestinationBucket,
                DestinationKey = this.DestinationKey,
                SourceRegion = this.SourceRegion,
                ContentType = this.ContentType,
                ETagToMatch = this.ETagToMatch,
                ETagToNotMatch = this.ETagToNotMatch,
                WebsiteRedirectLocation = this.WebsiteRedirectLocation,

                ServerSideEncryptionKeyManagementServiceKeyId = this.ServerSideEncryptionKeyManagementServiceKeyId,

                ServerSideEncryptionCustomerMethod = this.ServerSideEncryptionCustomerMethod,
                ServerSideEncryptionCustomerProvidedKey = this.ServerSideEncryptionCustomerProvidedKey,
                ServerSideEncryptionCustomerProvidedKeyMD5 = this.ServerSideEncryptionCustomerProvidedKeyMD5,

                CopySourceServerSideEncryptionCustomerMethod = this.CopySourceServerSideEncryptionCustomerMethod,
                CopySourceServerSideEncryptionCustomerProvidedKey = this.CopySourceServerSideEncryptionCustomerProvidedKey,
                CopySourceServerSideEncryptionCustomerProvidedKeyMD5 = this.CopySourceServerSideEncryptionCustomerProvidedKeyMD5,

                ChecksumAlgorithm = this.ChecksumAlgorithm,
                ChecksumMode = this.ChecksumMode,

                Metadata = this.Metadata,
                Headers = this.HeaderCollection
            };

            // this makes things simpler later
            if (string.IsNullOrEmpty(context.DestinationBucket))
                context.DestinationBucket = context.SourceBucket;
            if (string.IsNullOrEmpty(context.DestinationKey))
                context.DestinationKey = context.SourceKey;

            switch (this.ParameterSetName)
            {
                case CopySingleObjectToLocalFile:
                    context.LocalFile = this.LocalFile;
                    break;

                case CopySingleObjectToLocalFolder:
                    // transform to download to local file
                    var path = PSHelpers.PSPathToAbsolute(this.SessionState.Path, PSHelpers.PSPathToAbsolute(this.SessionState.Path, this.LocalFolder));
                    context.LocalFile = Path.Combine(path, this.Key);
                    break;

                case CopyMultipleObjectsToLocalFolder:
                    context.OriginalKeyPrefix = this.KeyPrefix;
                    context.KeyPrefix = ReadS3ObjectCmdlet.rootIndicators.Contains<string>(this.KeyPrefix, StringComparer.OrdinalIgnoreCase)
                        ? "/" : AmazonS3Helper.CleanKey(this.KeyPrefix);

                    context.LocalFolder = PSHelpers.PSPathToAbsolute(this.SessionState.Path, this.LocalFolder);
                    break;

                case CopyS3ObjectToS3Object:
                    context.TagSet = this.TagSet;
                    break;
            }

            if (ParameterWasBound("UtcModifiedSinceDate"))
                context.UtcModifiedSinceDate = this.UtcModifiedSinceDate;
            if (ParameterWasBound("UtcUnmodifiedSinceDate"))
                context.UtcUnmodifiedSinceDate = this.UtcUnmodifiedSinceDate;
#pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound("ModifiedSinceDate"))
                context.ModifiedSinceDate = this.ModifiedSinceDate;
            if (ParameterWasBound("UnmodifiedSinceDate"))
                context.UnmodifiedSinceDate = this.UnmodifiedSinceDate;
#pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute

            if (ParameterWasBound("MetadataDirective"))
                context.MetadataDirective = this.MetadataDirective;

            if (!string.IsNullOrEmpty(this.CannedACLName))
            {
                context.CannedACL = this.CannedACLName;
            }
            else if (this.PublicReadOnly.IsPresent)
            {
                context.CannedACL = S3CannedACL.PublicRead;
            }
            else if (this.PublicReadWrite.IsPresent)
            {
                context.CannedACL = S3CannedACL.PublicReadWrite;
            }

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
            {
                context.ServerSideEncryptionMethod = AmazonS3Helper.Convert(this.ServerSideEncryption);
            }

            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }

        #region IExecutor Members

        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

            if (!string.IsNullOrEmpty(cmdletContext.LocalFile))
                return CopyS3ObjectToLocalFile(context);

            if (!string.IsNullOrEmpty(cmdletContext.KeyPrefix))
                return CopyS3ObjectsToLocalFolder(context);

            // S3 requires multi-part operation for objects > 5GB
            var objectSize = GetSourceObjectData(cmdletContext.SourceBucket, cmdletContext.SourceKey).Size;
            return objectSize > FiveGigabytes ? MultipartCopyS3ObjectToS3(context, objectSize) : CopyS3ObjectToS3(context);
        }

        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }

        #endregion
        private S3Object GetSourceObjectData(string bucketName, string objectKey)
        {

            var copySourceRegionArgs = new StandaloneRegionArguments
            {
                Region = this.SourceRegion,
                ProfileLocation = this.ProfileLocation
            };
            copySourceRegionArgs.TryGetRegion(true, out var region, out var regionSource, SessionState);
            var sourceRegionClient = CreateClient(_CurrentCredentials, region);

            var request = new ListObjectsRequest
            {
                BucketName = bucketName,
                Prefix = objectKey.TrimStart('/')
            };

            var response = CallAWSServiceOperation(sourceRegionClient, request);
            return response.S3Objects[0];

        }

        private S3Object GetObjectData(IAmazonS3 s3Client, string bucketName, string objectKey)
        {
            // The underlying S3 api does not like listing with prefixes starting with / so strip
            // (eg Copy-S3Object -BucketName test-bucket -Key /data/sample.txt -DestinationKey /data/sample-copy.txt)

            var request = new ListObjectsRequest
            {
                BucketName = bucketName,
                Prefix = objectKey.TrimStart('/')
            };

            var response = CallAWSServiceOperation(s3Client, request);
            return response.S3Objects[0];
        }

        #region S3 to S3 Copy

        private object CopyS3ObjectToS3(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

            var request = new CopyObjectRequest();

            request.SourceBucket = cmdletContext.SourceBucket;
            request.SourceKey = cmdletContext.SourceKey;
            if (cmdletContext.SourceVersionId != null)
                request.SourceVersionId = cmdletContext.SourceVersionId;

            request.DestinationBucket = cmdletContext.DestinationBucket;
            request.DestinationKey = cmdletContext.DestinationKey;
            if (cmdletContext.ContentType != null)
                request.ContentType = cmdletContext.ContentType;
            if (cmdletContext.ETagToMatch != null)
                request.ETagToMatch = cmdletContext.ETagToMatch;
            if (cmdletContext.ETagToNotMatch != null)
                request.ETagToNotMatch = cmdletContext.ETagToNotMatch;
            if (cmdletContext.MetadataDirective != null)
                request.MetadataDirective = cmdletContext.MetadataDirective.Value;
            if (cmdletContext.CannedACL != null)
                request.CannedACL = cmdletContext.CannedACL.Value;
            if (cmdletContext.StorageClass != null)
                request.StorageClass = cmdletContext.StorageClass.Value;
            if (cmdletContext.ServerSideEncryptionMethod != null)
                request.ServerSideEncryptionMethod = cmdletContext.ServerSideEncryptionMethod.Value;
            if (cmdletContext.WebsiteRedirectLocation != null)
                request.WebsiteRedirectLocation = cmdletContext.WebsiteRedirectLocation;
            if (cmdletContext.ServerSideEncryptionKeyManagementServiceKeyId != null)
                request.ServerSideEncryptionKeyManagementServiceKeyId = cmdletContext.ServerSideEncryptionKeyManagementServiceKeyId;
            if (cmdletContext.UtcModifiedSinceDate.HasValue)
                request.ModifiedSinceDateUtc = cmdletContext.UtcModifiedSinceDate.Value;
            if (cmdletContext.UtcUnmodifiedSinceDate.HasValue)
                request.UnmodifiedSinceDateUtc = cmdletContext.UtcUnmodifiedSinceDate.Value;
#pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.ModifiedSinceDate.HasValue)
            {
                if (cmdletContext.UtcModifiedSinceDate != null)
                {
                    throw new ArgumentException("Parameters ModifiedSinceDate and UtcModifiedSinceDate are mutually exclusive.");
                }
                request.ModifiedSinceDate = cmdletContext.ModifiedSinceDate.Value;
            }
            if (cmdletContext.UnmodifiedSinceDate.HasValue)
            {
                if (cmdletContext.UtcUnmodifiedSinceDate != null)
                {
                    throw new ArgumentException("Parameters UnmodifiedSinceDate and UtcUnmodifiedSinceDate are mutually exclusive.");
                }
                request.UnmodifiedSinceDate = cmdletContext.UnmodifiedSinceDate.Value;
            }
#pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute

            request.CopySourceServerSideEncryptionCustomerMethod = cmdletContext.CopySourceServerSideEncryptionCustomerMethod;
            request.CopySourceServerSideEncryptionCustomerProvidedKey = cmdletContext.CopySourceServerSideEncryptionCustomerProvidedKey;
            request.CopySourceServerSideEncryptionCustomerProvidedKeyMD5 = cmdletContext.CopySourceServerSideEncryptionCustomerProvidedKeyMD5;

            request.ServerSideEncryptionCustomerMethod = cmdletContext.ServerSideEncryptionCustomerMethod;
            request.ServerSideEncryptionCustomerProvidedKey = cmdletContext.ServerSideEncryptionCustomerProvidedKey;
            request.ServerSideEncryptionCustomerProvidedKeyMD5 = cmdletContext.ServerSideEncryptionCustomerProvidedKeyMD5;

            request.ChecksumAlgorithm = cmdletContext.ChecksumAlgorithm;

            if (cmdletContext.TagSet != null)
                request.TagSet.AddRange(cmdletContext.TagSet);

            AmazonS3Helper.SetMetadataAndHeaders(request, cmdletContext.Metadata, cmdletContext.Headers);

            // issue call
            using (var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint))
            {
                Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3", "CopyObject");

                CmdletOutput output;
                try
                {
                    var response = CallAWSServiceOperation(client, request);
                    var objectData = GetObjectData(Client,
                                                   request.DestinationBucket, 
                                                   string.IsNullOrEmpty(cmdletContext.DestinationKey) 
                                                    ? cmdletContext.SourceKey : cmdletContext.DestinationKey);
                    output = new CmdletOutput
                    {
                        PipelineOutput = objectData,
                        ServiceResponse = response
                    };
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }

                return output;
            }
        }

        #endregion

        #region S3 to S3 MultiPart Copy

        private object MultipartCopyS3ObjectToS3(ExecutorContext context, long objectSize)
        {
            var cmdletContext = context as CmdletContext;
            const string activityFormat = "Copying {0}:{1} to {2}:{3}";
            const string msgFormat = "Copied {0:N0} of {1:N0} bytes";
            CmdletOutput output = null;

            var activity = string.Format(activityFormat, 
                                         cmdletContext.SourceBucket, 
                                         cmdletContext.SourceKey,
                                         cmdletContext.DestinationBucket, 
                                         cmdletContext.DestinationKey);
                                                               
            Utils.Common.WriteVerboseEndpointMessage(this, Client.Config, "Amazon S3", "CopyObject");

            WriteProgressRecord(activity, string.Format(msgFormat, 0, objectSize), 0);

            var initiateRequest = new InitiateMultipartUploadRequest();
            PopulateRequest(cmdletContext, initiateRequest);
            var initiateResponse = CallAWSServiceOperation(Client, initiateRequest);
            var uploadId = initiateResponse.UploadId;

            var copyController = new MultiPartObjectCopyController(Client, uploadId, objectSize, cmdletContext);

            try
            {
                copyController.Run();
                while (true)
                {
                    Thread.Sleep(1000);

                    var percentDone = (int)((double)copyController.BytesUploaded / objectSize * 100);

                    var progressMsg = string.Format(msgFormat, copyController.BytesUploaded, objectSize);
                    WriteProgressRecord(activity, progressMsg, percentDone);

                    if (copyController.ShouldExit())
                        break;
                }

                if (copyController.Error != null)
                {
                    // leaving uploadId set will cause us to abort the upload so the
                    // user is not charged for incomplete uploads
                    throw new Exception("Error during upload copy of part", copyController.Error);
                }

                var completeRequest = new CompleteMultipartUploadRequest
                {
                    UploadId = uploadId,
                    BucketName = cmdletContext.DestinationBucket,
                    Key = cmdletContext.DestinationKey,
                    PartETags = copyController.ETags
                };

                CallAWSServiceOperation(Client, completeRequest);
                uploadId = null;
            }
            finally
            {
                if (string.IsNullOrEmpty(uploadId))
                {
                    WriteProgressCompleteRecord(activity, "Copy object completed");

                    var objectData = GetObjectData(Client, cmdletContext.DestinationBucket, cmdletContext.DestinationKey);
                    output = new CmdletOutput
                    {
                        PipelineOutput = objectData
                    };
                }
                else
                {
                    var abortRequest = new AbortMultipartUploadRequest
                    {
                        UploadId = uploadId,
                        BucketName = cmdletContext.DestinationBucket,
                        Key = cmdletContext.DestinationKey
                    };
                    CallAWSServiceOperation(Client, abortRequest);
                    WriteProgressCompleteRecord(activity, "Operation failed");
                }
            }

            return output;
        }

        private void PopulateRequest(CmdletContext cmdletContext, InitiateMultipartUploadRequest request)
        {
            request.BucketName = cmdletContext.DestinationBucket;
            request.Key = cmdletContext.DestinationKey;

            if (cmdletContext.ContentType != null)
                request.ContentType = cmdletContext.ContentType;
            if (cmdletContext.CannedACL != null)
                request.CannedACL = cmdletContext.CannedACL.Value;
            if (cmdletContext.StorageClass != null)
                request.StorageClass = cmdletContext.StorageClass.Value;

            if (cmdletContext.ServerSideEncryptionMethod != null)
                request.ServerSideEncryptionMethod = cmdletContext.ServerSideEncryptionMethod.Value;
            if (cmdletContext.ServerSideEncryptionKeyManagementServiceKeyId != null)
                request.ServerSideEncryptionKeyManagementServiceKeyId = cmdletContext.ServerSideEncryptionKeyManagementServiceKeyId;

            request.ServerSideEncryptionCustomerMethod = cmdletContext.ServerSideEncryptionCustomerMethod;
            request.ServerSideEncryptionCustomerProvidedKey = cmdletContext.ServerSideEncryptionCustomerProvidedKey;
            request.ServerSideEncryptionCustomerProvidedKeyMD5 = cmdletContext.ServerSideEncryptionCustomerProvidedKeyMD5;

            request.ChecksumAlgorithm = cmdletContext.ChecksumAlgorithm;

            if (cmdletContext.WebsiteRedirectLocation != null)
                request.WebsiteRedirectLocation = cmdletContext.WebsiteRedirectLocation;

            if (cmdletContext.TagSet != null)
                request.TagSet.AddRange(cmdletContext.TagSet);

            AmazonS3Helper.SetMetadataAndHeaders(request, cmdletContext.Metadata, cmdletContext.Headers);
        }

        #endregion

        #region S3 to Local File or Folder Copy

        private object CopyS3ObjectToLocalFile(ExecutorContext context)
        {
            // Adapted from Read-S3Object's single file mode
            var cmdletContext = context as CmdletContext;
            var request = new TransferUtilityDownloadRequest
            {
                BucketName = cmdletContext.SourceBucket,
                FilePath = cmdletContext.LocalFile,
                Key = cmdletContext.SourceKey
            };

            if (!string.IsNullOrEmpty(cmdletContext.SourceVersionId))
                request.VersionId = cmdletContext.SourceVersionId;
            if (cmdletContext.UtcModifiedSinceDate.HasValue)
                request.ModifiedSinceDateUtc = cmdletContext.UtcModifiedSinceDate.Value;
            if (cmdletContext.UtcUnmodifiedSinceDate.HasValue)
                request.UnmodifiedSinceDateUtc = cmdletContext.UtcUnmodifiedSinceDate.Value;
#pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.ModifiedSinceDate.HasValue)
            {
                if (cmdletContext.UtcModifiedSinceDate != null)
                {
                    throw new ArgumentException("Parameters ModifiedSinceDate and UtcModifiedSinceDate are mutually exclusive.");
                }
                request.ModifiedSinceDate = cmdletContext.ModifiedSinceDate.Value;
            }
            if (cmdletContext.UnmodifiedSinceDate.HasValue)
            {
                if (cmdletContext.UtcUnmodifiedSinceDate != null)
                {
                    throw new ArgumentException("Parameters UnmodifiedSinceDate and UtcUnmodifiedSinceDate are mutually exclusive.");
                }
                request.UnmodifiedSinceDate = cmdletContext.UnmodifiedSinceDate.Value;
            }
#pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute

            request.ServerSideEncryptionCustomerMethod = cmdletContext.ServerSideEncryptionCustomerMethod;
            request.ServerSideEncryptionCustomerProvidedKey = cmdletContext.ServerSideEncryptionCustomerProvidedKey;
            request.ServerSideEncryptionCustomerProvidedKeyMD5 = cmdletContext.ServerSideEncryptionCustomerProvidedKeyMD5;

            request.ChecksumMode = cmdletContext.ChecksumMode;

            CmdletOutput output;
            using (var tu = new TransferUtility(Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint)))
            {
                Utils.Common.WriteVerboseEndpointMessage(this, Client.Config, "Amazon S3", "GetObject");

                var runner = new ProgressRunner(this);
                var tracker = new ReadS3ObjectCmdlet.DownloadFileProgressTracker(runner, handler => request.WriteObjectProgressEvent += handler, cmdletContext.SourceKey);

                output = runner.SafeRun(() => tu.Download(request), tracker);
                if (output.ErrorResponse == null)
                    output.PipelineOutput = new FileInfo(cmdletContext.LocalFile);
            }

            return output;
        }

        private object CopyS3ObjectsToLocalFolder(ExecutorContext context)
        {
            // Adapted from Read-S3Object's folder download
            var cmdletContext = context as CmdletContext;
            var request = new TransferUtilityDownloadDirectoryRequest
            {
                BucketName = cmdletContext.SourceBucket,
                LocalDirectory = cmdletContext.LocalFolder,
                S3Directory = cmdletContext.KeyPrefix
            };

            if (cmdletContext.UtcModifiedSinceDate.HasValue)
                request.ModifiedSinceDateUtc = cmdletContext.UtcModifiedSinceDate.Value;
            if (cmdletContext.UtcUnmodifiedSinceDate.HasValue)
                request.UnmodifiedSinceDateUtc = cmdletContext.UtcUnmodifiedSinceDate.Value;
#pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.ModifiedSinceDate.HasValue)
            {
                if (cmdletContext.UtcModifiedSinceDate != null)
                {
                    throw new ArgumentException("Parameters ModifiedSinceDate and UtcModifiedSinceDate are mutually exclusive.");
                }
                request.ModifiedSinceDate = cmdletContext.ModifiedSinceDate.Value;
            }
            if (cmdletContext.UnmodifiedSinceDate.HasValue)
            {
                if (cmdletContext.UtcUnmodifiedSinceDate != null)
                {
                    throw new ArgumentException("Parameters UnmodifiedSinceDate and UtcUnmodifiedSinceDate are mutually exclusive.");
                }
                request.UnmodifiedSinceDate = cmdletContext.UnmodifiedSinceDate.Value;
            }
#pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute

            CmdletOutput output;
            using (var tu = new TransferUtility(Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint)))
            {
                Utils.Common.WriteVerboseEndpointMessage(this, Client.Config, "Amazon S3 object download APIs");

                var runner = new ProgressRunner(this);
                var tracker = new ReadS3ObjectCmdlet.DownloadFolderProgressTracker(runner, handler => request.DownloadedDirectoryProgressEvent += handler);

                output = runner.SafeRun(() => tu.DownloadDirectory(request), tracker);
                if (output.ErrorResponse == null)
                    output.PipelineOutput = new DirectoryInfo(cmdletContext.LocalFolder);

                WriteVerbose(string.Format("Downloaded {0} object(s) from bucket '{1}' with keyprefix '{2}' to '{3}'",
                    tracker.DownloadedCount,
                    cmdletContext.SourceBucket,
                    cmdletContext.OriginalKeyPrefix,
                    cmdletContext.LocalFolder));
            }

            return output;
        }

        #endregion

        #region AWS Service Operation Call

        private Amazon.S3.Model.CopyObjectResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.CopyObjectRequest request)
        {
            try
            {
#if DESKTOP
                return client.CopyObject(request);
#elif CORECLR
                return client.CopyObjectAsync(request).GetAwaiter().GetResult();
#else
#error "Unknown build edition"
#endif
            }
            catch (AmazonServiceException exc)
            {
                TestForNameResolutionException(client, exc);
            }

            return null;
        }

        private Amazon.S3.Model.ListObjectsResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.ListObjectsRequest request)
        {
            try
            {
#if DESKTOP
                return client.ListObjects(request);
#elif CORECLR
                return client.ListObjectsAsync(request).GetAwaiter().GetResult();
#else
#error "Unknown build edition"
#endif
            }
            catch (AmazonServiceException exc)
            {
                TestForNameResolutionException(client, exc);
            }

            return null;
        }

        private Amazon.S3.Model.InitiateMultipartUploadResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.InitiateMultipartUploadRequest request)
        {
            try
            {
#if DESKTOP
                return client.InitiateMultipartUpload(request);
#elif CORECLR
                return client.InitiateMultipartUploadAsync(request).GetAwaiter().GetResult();
#else
#error "Unknown build edition"
#endif
            }
            catch (AmazonServiceException exc)
            {
                TestForNameResolutionException(client, exc);
            }

            return null;
        }

        private Amazon.S3.Model.CompleteMultipartUploadResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.CompleteMultipartUploadRequest request)
        {
            // not testing for name resolution error here since it would have already
            // failed during the init call
#if DESKTOP
            return client.CompleteMultipartUpload(request);
#elif CORECLR
            return client.CompleteMultipartUploadAsync(request).GetAwaiter().GetResult();
#else
#error "Unknown build edition"
#endif
        }

        private Amazon.S3.Model.AbortMultipartUploadResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.AbortMultipartUploadRequest request)
        {
            // not testing for name resolution error here since it would have already
            // failed during the init call
#if DESKTOP
            return client.AbortMultipartUpload(request);
#elif CORECLR
            return client.AbortMultipartUploadAsync(request).GetAwaiter().GetResult();
#else
#error "Unknown build edition"
#endif
        }

        private void TestForNameResolutionException(IAmazonS3 client, Exception exc)
        {
            var webException = exc.InnerException as System.Net.WebException;
            if (webException != null)
            {
                throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
            }

            throw exc;
        }

        #endregion

        internal class CmdletContext : ExecutorContext
        {
            public String SourceBucket { get; set; }
            public String SourceKey { get; set; }
            public String DestinationBucket { get; set; }
            public String DestinationKey { get; set; }
            public Object SourceRegion { get; set; }
            public String LocalFile { get; set; }
            public String LocalFolder { get; set; }
            public String OriginalKeyPrefix { get; set; }
            public String KeyPrefix { get; set; }
            public String ContentType { get; set; }
            public String ETagToMatch { get; set; }
            public String ETagToNotMatch { get; set; }
            [System.ObsoleteAttribute]
            public DateTime? ModifiedSinceDate { get; set; }
            [System.ObsoleteAttribute]
            public DateTime? UnmodifiedSinceDate { get; set; }
            public DateTime? UtcModifiedSinceDate { get; set; }
            public DateTime? UtcUnmodifiedSinceDate { get; set; }
            public S3MetadataDirective? MetadataDirective { get; set; }
            public S3CannedACL CannedACL { get; set; }
            public String SourceVersionId { get; set; }
            public S3StorageClass StorageClass { get; set; }
            public ServerSideEncryptionMethod ServerSideEncryptionMethod { get; set; }
            public string ServerSideEncryptionKeyManagementServiceKeyId { get; set; }

            public ServerSideEncryptionCustomerMethod CopySourceServerSideEncryptionCustomerMethod { get; set; }
            public string CopySourceServerSideEncryptionCustomerProvidedKey { get; set; }
            public string CopySourceServerSideEncryptionCustomerProvidedKeyMD5 { get; set; }

            public ServerSideEncryptionCustomerMethod ServerSideEncryptionCustomerMethod { get; set; }
            public string ServerSideEncryptionCustomerProvidedKey { get; set; }
            public string ServerSideEncryptionCustomerProvidedKeyMD5 { get; set; }

            public Hashtable Metadata { get; set; }
            public Hashtable Headers { get; set; }

            public String WebsiteRedirectLocation { get; set; }

            public Tag[] TagSet { get; set; }

            public ChecksumAlgorithm ChecksumAlgorithm { get; set; }
            public ChecksumMode ChecksumMode { get; set; }
        }
       
        internal class MultiPartObjectCopyController
        {
            private static readonly long MinPartSize = 5 * (long)Math.Pow(2, 20);
            private const int MaxNumberOfParts = 10000;
            private const int MaxWorkerThreads = 5;

            private readonly object _lock = new object();

            private readonly long _objectSize;
            private long _bytesUploaded;
            private readonly CmdletContext _context;
            private readonly string _uploadId;
            private readonly IAmazonS3 _s3Client;
            private int _nextPartToUpload = -1;
            private Exception _errorException;

            /// <summary>
            /// Byte range for each part and the service's etag value
            /// on completion of the part upload
            /// </summary>
            public class PartDetail
            {
                public int PartNumber { get; set; }
                public long StartByte { get; set; }
                public long Size { get; set; }
                public string ETag { get; set; }

                public string ChecksumSHA1 { get; set; }
                public string ChecksumSHA256 { get; set; }
                public string ChecksumCRC32 { get; set; }
                public string ChecksumCRC32C { get; set; }

                public PartETag ToPartETag()
                {
                    var partETag = new PartETag(PartNumber, ETag);
                    partETag.ChecksumSHA1 = ChecksumSHA1;
                    partETag.ChecksumSHA256 = ChecksumSHA256;
                    partETag.ChecksumCRC32 = ChecksumCRC32;
                    partETag.ChecksumCRC32C = ChecksumCRC32C;

                    return partETag;
                }
            }

            /// <summary>
            /// Contains the collection of parts we need to process
            /// </summary>
            private readonly List<PartDetail> _parts = new List<PartDetail>();

            /// <summary>
            /// The number of parts we've broken the upload into, based on
            /// the max allowed by S3 in conjunction with the minimum part size
            /// </summary>
            public int NumberOfParts { get { return _parts.Count; } }

            public long BytesUploaded
            {
                get
                {
                    long uploaded;
                    lock (_lock)
                    {
                        uploaded = _bytesUploaded;
                    }

                    return uploaded;
                }
            }

            /// <summary>
            /// If set, an error was trapped by one of the upload threads
            /// and the outer code should quit (ShouldExit will yield true)
            /// and report this to the user. The exception is posted by the
            /// first thread to encounter an error; errors on other threads
            /// are dropped on the floor.
            /// </summary>
            public Exception Error
            {
                get
                {
                    lock (_lock)
                    {
                        return _errorException;
                    }
                }

                private set
                {
                    lock (_lock)
                    {
                        if (_errorException == null)
                        {
                            _errorException = value;
                        }
                    }
                }
            }

            public MultiPartObjectCopyController(IAmazonS3 s3Client, string uploadId, long objectSize, CmdletContext context)
            {
                _s3Client = s3Client;
                _uploadId = uploadId;
                _context = context;
                _objectSize = objectSize;

                PartitionIntoParts();
            }

            /// <summary>
            /// Indicates to the caller we're done either because we've encountered an error or
            /// all parts have been processed
            /// </summary>
            /// <returns></returns>
            public bool ShouldExit()
            {
                lock (_lock)
                {
                    if (Error != null)
                        return true;

                    if (_bytesUploaded == _objectSize)
                        return true;
                }

                return false;
            }

            /// <summary>
            /// Launches threads to process the part list and immediately
            /// exits back to the caller.
            /// </summary>
            public void Run()
            {
                var threadCount = _parts.Count > MaxWorkerThreads ? MaxWorkerThreads : 2;
                for (var i = 0; i < threadCount; i++)
                {
                    ThreadPool.QueueUserWorkItem(UploadPartCopyThreadWorker, this);
                    Thread.Sleep(100);
                }
            }

            public List<PartETag> ETags
            {
                get
                {
                    return _parts.Select(p => p.ToPartETag()).ToList();
                }
            }

            private static void UploadPartCopyThreadWorker(object state)
            {
                var _this = state as MultiPartObjectCopyController;
                Debug.Assert(_this != null, "_this != null");

#if DEBUG
                Thread.CurrentThread.Name = string.Format("UploadPartCopyThreadWorker {0}:{1}", 
                                                          _this._context.DestinationBucket, 
                                                          _this._context.DestinationKey);
#endif

                var part = _this.NextPartToUpload;
                while (part != null)
                {
                    var copyPartRequest = new CopyPartRequest
                    {
                        UploadId = _this._uploadId,
                        PartNumber = part.PartNumber,
                        FirstByte = part.StartByte,
                        LastByte = part.StartByte + part.Size - 1
                    };
                    _this.PopulateRequest(copyPartRequest);

                    try
                    {
                        var response = _this.CallAWSServiceOperation(_this._s3Client, copyPartRequest);
                        part.ETag = response.ETag;
                        part.ChecksumSHA1 = response.ChecksumSHA1;
                        part.ChecksumSHA256 = response.ChecksumSHA256;
                        part.ChecksumCRC32 = response.ChecksumCRC32;
                        part.ChecksumCRC32C = response.ChecksumCRC32C;
                        lock (_this._lock)
                        {
                            _this._bytesUploaded += part.Size;
                        }
                    }
                    catch (Exception e)
                    {
                        _this.Error = e;
                    }

                    part = _this.NextPartToUpload;
                }
            }

            private PartDetail NextPartToUpload
            {
                get
                {
                    if (Error == null)
                    {
                        var partIndex = Interlocked.Increment(ref _nextPartToUpload);
                        if (partIndex < _parts.Count)
                            return _parts[partIndex];
                    }
                        
                    return null;
                }
            }

            private void PopulateRequest(CopyPartRequest request)
            {
                request.SourceBucket = _context.SourceBucket;
                request.SourceKey = _context.SourceKey;
                request.DestinationBucket = _context.DestinationBucket;
                request.DestinationKey = _context.DestinationKey;
                if (string.IsNullOrEmpty(_context.SourceVersionId))
                    request.SourceVersionId = _context.SourceVersionId;
                if (_context.ETagToMatch != null)
                    request.ETagToMatch = new List<string> { _context.ETagToMatch };
                if (_context.ETagToNotMatch != null)
                    request.ETagsToNotMatch = new List<string> { _context.ETagToNotMatch };
                if (_context.UtcModifiedSinceDate.HasValue)
                    request.ModifiedSinceDate = _context.UtcModifiedSinceDate.Value;
                if (_context.UtcUnmodifiedSinceDate.HasValue)
                    request.UnmodifiedSinceDate = _context.UtcUnmodifiedSinceDate.Value;
#pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
                if (_context.ModifiedSinceDate.HasValue)
                {
                    if (_context.UtcModifiedSinceDate != null)
                    {
                        throw new ArgumentException("Parameters ModifiedSinceDate and UtcModifiedSinceDate are mutually exclusive.");
                    }
                    request.ModifiedSinceDate = _context.ModifiedSinceDate.Value;
                }
                if (_context.UnmodifiedSinceDate.HasValue)
                {
                    if (_context.UtcUnmodifiedSinceDate != null)
                    {
                        throw new ArgumentException("Parameters UnmodifiedSinceDate and UtcUnmodifiedSinceDate are mutually exclusive.");
                    }
                    request.UnmodifiedSinceDate = _context.UnmodifiedSinceDate.Value;
                }
#pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute

                request.CopySourceServerSideEncryptionCustomerMethod = _context.CopySourceServerSideEncryptionCustomerMethod;
                request.CopySourceServerSideEncryptionCustomerProvidedKey = _context.CopySourceServerSideEncryptionCustomerProvidedKey;
                request.CopySourceServerSideEncryptionCustomerProvidedKeyMD5 = _context.CopySourceServerSideEncryptionCustomerProvidedKeyMD5;

                request.ServerSideEncryptionCustomerMethod = _context.ServerSideEncryptionCustomerMethod;
                request.ServerSideEncryptionCustomerProvidedKey = _context.ServerSideEncryptionCustomerProvidedKey;
                request.ServerSideEncryptionCustomerProvidedKeyMD5 = _context.ServerSideEncryptionCustomerProvidedKeyMD5;
            }

            private void PartitionIntoParts()
            {
                var partSize = (long)Math.Ceiling((double)_objectSize / MaxNumberOfParts);
                if (partSize < MinPartSize)
                {
                    partSize = MinPartSize;
                }

                long startByte = 0;
                var remaining = _objectSize;
                var partNumber = 1;
                while (remaining > 0)
                {
                    var part = new PartDetail
                    {
                        PartNumber = partNumber++,
                        StartByte = startByte,
                        Size = (remaining > partSize) ? partSize : remaining
                    };
                    
                    _parts.Add(part);

                    remaining -= part.Size;
                    startByte = part.StartByte + part.Size;
                }
            }

            private Amazon.S3.Model.CopyPartResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.CopyPartRequest request)
            {
                // not testing for name resolution error here, since it would have already failed
                // in the init call
#if DESKTOP
                return client.CopyPart(request);
#elif CORECLR
                return client.CopyPartAsync(request).GetAwaiter().GetResult();
#else
#error "Unknown build edition"
#endif
            }
        }
    }
}
