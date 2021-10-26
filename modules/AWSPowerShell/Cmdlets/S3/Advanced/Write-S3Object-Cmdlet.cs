/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
        const string ParamSet_FromContent = "UploadFromContent";
        const string ParamSet_FromLocalFolder = "UploadFolder";
        const string ParamSet_FromStream = "UploadFromStream";

        // Part size range in bytes (refer https://docs.aws.amazon.com/AmazonS3/latest/userguide/qfacts.html)
        const long MinPartSize = 5L * 1024 * 1024;
        const long MaxPartSize = 5L * 1024 * 1024 * 1024;

        // try and anticipate all the ways a user might mean 'write everything to root'
        readonly string[] rootIndicators = new string[] { "/", @"\" };

        #region Parameter BucketName
        /// <summary>
        /// <para>The name of the bucket that will hold the uploaded content.</para><para>When using this API with an access point, you must direct requests to the access point hostname. 
        /// The access point hostname takes the form <i>AccessPointName</i>-<i>AccountId</i>.s3-accesspoint.<i>Region</i>.amazonaws.com. 
        /// When using this operation using an access point through the AWS SDKs, you provide the access point 
        /// ARN in place of the bucket name. For more information about access point ARNs, see 
        /// <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/using-access-points.html">Using Access Points</a> 
        /// in the <i>Amazon Simple Storage Service Developer Guide</i>.</para>
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
        /// Specifies the encryption used on the server to store the content.
        /// Allowable values: None, AES256, aws:kms.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ServerSideEncryptionMethod")]
        public Amazon.S3.ServerSideEncryptionMethod ServerSideEncryption { get; set; }
        #endregion

        #region Parameter ServerSideEncryptionKeyManagementServiceKeyId
        /// <summary>
        /// Specifies the AWS KMS key for Amazon S3 to use to encrypt the object.
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

            if (!ConfirmShouldProceed(this.Force.IsPresent, this.BucketName, "Write-S3Object (PutObject)"))
                return;

            var context = new CmdletContext
            {
                BucketName = this.BucketName
            };

            if (this.Key != null)
                context.Key = AmazonS3Helper.CleanKey(this.Key);

            if (this.ParameterSetName == ParamSet_FromLocalFile)
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
                    context.KeyPrefix = AmazonS3Helper.CleanKey(this.KeyPrefix);
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
            context.CalculateContentMD5Header = this.CalculateContentMD5Header;

            if (this.PartSize != null)
            {
                if (this.PartSize.FileSizeInBytes < MinPartSize || this.PartSize.FileSizeInBytes > MaxPartSize)
                    throw new ArgumentException("PartSize", string.Format("PartSize must be between {0} and {1} (bytes).", MinPartSize, MaxPartSize));

                context.PartSize = this.PartSize.FileSizeInBytes;
            }

            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }

        #region IExecutor Members

        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

            if (!string.IsNullOrEmpty(cmdletContext.File) || cmdletContext.Stream!=null)
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

            request.CalculateContentMD5Header = cmdletContext.CalculateContentMD5Header;

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
                else if(cmdletContext.Stream!=null)
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

                request.CalculateContentMD5Header = cmdletContext.CalculateContentMD5Header;

                if (cmdletContext.PartSize != null)
                    request.PartSize = cmdletContext.PartSize.Value;

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

            request.CalculateContentMD5Header = cmdletContext.CalculateContentMD5Header;

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
#if DESKTOP
                return client.PutObject(request);
#elif CORECLR
                return client.PutObjectAsync(request).GetAwaiter().GetResult();
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

            public Hashtable Metadata { get; set; }
            public Hashtable Headers { get; set; }

            public Tag[] TagSet { get; set; }

            public int? ConcurrentServiceRequests { get; set; }

            public bool CalculateContentMD5Header { get; set; }

            public long? PartSize { get; set; }
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
